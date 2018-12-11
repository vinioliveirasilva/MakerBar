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
        public string Endereco { get; set; }
        public string Nome { get; set; }
        public string TelRes { get; set; }
        public string TelCel { get; set; }
        public string Email { get; set; }
    }
}