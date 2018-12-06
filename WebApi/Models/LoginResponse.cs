using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Web.Helpers;

namespace WebApi.Models
{
    public class LoginResponse
    {
        public string User { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public string Token { get; set; }
        public bool Autorized { get; set; }
        public int Type { get; set; }
        public int Rank { get; set; }


        public LoginResponse(string user, string pass)
        {
            User = user;
            Pass = pass;
        }

        public void Autenticate(OracleConnection conn)
        {
            string sql = $"select * from Usuario where id='{User.ToLower()}'";
            string hashPass = string.Empty;
            int type = -1, rank = -1;

            using (var cmd = new OracleCommand(sql, conn))
            {
                cmd.CommandType = CommandType.Text;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        hashPass = dr["Senha"].ToString();
                        type = Convert.ToInt32(dr["Tipo"]);
                        rank = Convert.ToInt32(dr["Classe"]);
                        Name = dr["Nome"].ToString();
                    }
                }

                Autorized = hashPass != string.Empty && hashPass == Crypto.SHA256(Pass);
                Type = type;
                Rank = rank;
            }
        }
    }
}