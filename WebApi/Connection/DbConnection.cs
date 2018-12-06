using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;

namespace WebApi.Connection
{
    public static class DbConnection
    {
        static OracleConnection conn;
        const string connString = "Data Source=localhost:1521/xe;User Id=engsoft;Password=Engenhariasoft;";
        
        static public OracleConnection NewConnetion()
        {
            conn = new OracleConnection(connString);

            try {

                conn.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Nao foi possivel conectar ao banco de dados. Error: " + ex.InnerException);
            }

            return conn;
        }

        static public OracleConnection GetInstance()
        {
            if (conn != null && conn.State == ConnectionState.Open)
            {
                return conn;
            }
            else
            {
                return NewConnetion();
            }
        }
        static public void Dispose() => conn.Dispose();
    }
}