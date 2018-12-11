using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Connection;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Item
    {
        [AttributeType(PrimaryKey = true)]
        [AutoIncrement(Auto = true)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public int Qualidade { get; set; }
        public int Resistencia { get; set; }
        public string Arquivo { get; set; }
        public int Quantidade { get; set; }

        [AttributeType(ForeignKey = true)]
        public int IdPedido { get; set; }
    }
}