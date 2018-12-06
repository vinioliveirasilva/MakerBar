using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebApi.Helper;

namespace WebApi.Connection
{
    static public class DbInterface
    {
        public static bool Insert<T>(this T value, OracleConnection conn)
        {            
            Type Table = value.GetType();
            var properties = Table.GetProperties();
            var autoIncProperty = Table.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(AutoIncrement))).FirstOrDefault();

            var TableColumns = string.Empty;
            var TableValues = string.Empty;

            for (int i = 0; i < properties.Count(); i++) 
            {
                if (properties[i].Name != autoIncProperty?.Name)
                {
                    var separator = (i < properties.Count() - 1) ? "," : string.Empty;

                    TableColumns += $"{properties[i].Name}{separator}";
                    TableValues += $"'{properties[i].GetValue(value)}'{separator}";
                }
            }

            string sql = $"insert into { Table.Name } ({ TableColumns }) VALUES ({ TableValues })";

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }

            return true;
        }

        public static IEnumerable<T> Get<T>(this T value, OracleConnection conn, long? PkValue = null, string OPkName = null)
        {
            Type Table = value.GetType();
            var PkName = Table.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(AttributeType))).First().Name;

            var toReturn = new List<T> { };
            string sql = $"select * from { Table.Name }{ (PkValue != null ? $" Where { (OPkName == string.Empty ? PkName : OPkName)} = {PkValue}" : string.Empty) }";

            using (var cmd = new OracleCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        T obj = (T)Activator.CreateInstance(Table);
                        var properties = Table.GetProperties();

                        foreach (var property in properties)
                        {
                            var dataType = obj.GetType().GetProperty(property.Name).PropertyType;

                            Table.GetProperty(property.Name).SetValue(obj, Convert.ChangeType(dr[property.Name], dataType));
                        }

                        toReturn.Add(obj);
                    }
                }
            }
            return toReturn;
        }

        public static bool Update<T>(this T value, OracleConnection conn, long? PkValue = null)
        {
            Type Table = value.GetType();
            var properties = Table.GetProperties();
            var PkName = Table.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(AttributeType))).First().Name;
            var autoIncProperty = Table.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(AutoIncrement))).FirstOrDefault();

            string setColumnsValues = string.Empty;

            for (int i = 0; i < properties.Count(); i++)
            {
                if (properties[i].Name != autoIncProperty?.Name)
                {
                    var separator = (i < properties.Count() - 1) ? "," : string.Empty;

                    setColumnsValues += $"{properties[i].Name} = '{properties[i].GetValue(value)}'{separator}";
                }
            }

            string sql = $"UPDATE { Table.Name } SET { setColumnsValues } Where { PkName } = { PkValue }";

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }

            return true;
        }

        public static bool Delete<T>(this T value, OracleConnection conn, long? PkValue = null)
        {
            Type Table = value.GetType();
            var PkName = Table.GetProperties().Where(prop => Attribute.IsDefined(prop, typeof(AttributeType))).First().Name;

            string sql = $"DELETE FROM {Table.Name} Where { PkName } = '{ PkValue }'";

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            return true;
        }
    }
}