using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Connection;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Funcionario
    {
        [AttributeType(PrimaryKey = true)]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string TelCel { get; set; }
        public string End { get; set; }

        public Funcionario(string cpf, string nome, string email, string telCel, string end)
        {
            Cpf = cpf;
            Nome = nome;
            Email = email;
            TelCel = telCel;
            End = end;
        }

        public Funcionario() { }
    }
}