using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Usuario
    {
        [AttributeType(PrimaryKey = true)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Tipo { get; set; } 
        public int Classe { get; set; }
    }
}