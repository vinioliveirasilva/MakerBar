using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Cliente
    {
        [AttributeType(PrimaryKey = true)]
        public string Cnpj { get; set; }
        public string EmpEnd { get; set; }
        public string EmpNome { get; set; }
        public string Contato { get; set; }
        public string TelEmp { get; set; }
        public string TelCel { get; set; }
        public string Email { get; set; }

        public Cliente() { }

        public Cliente(string cnpj, string empEnd, string empNome, string contato, string telEmp, string telCel, string email)
        {
            Cnpj = cnpj;
            EmpEnd = empEnd;
            EmpNome = empNome;
            Contato = contato;
            TelEmp = telEmp;
            TelCel = telCel;
            Email = email;
        }
    }
}