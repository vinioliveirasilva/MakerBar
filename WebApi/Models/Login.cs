using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Login
    {
        [AttributeType(PrimaryKey = true)]
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Tipo { get; set; } 
    }
}