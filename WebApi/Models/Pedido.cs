using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Pedido
    {
        [AttributeType(PrimaryKey = true)]
        [AutoIncrement(Auto = true)]
        public int Id { get; set; }

        [AttributeType(ForeignKey = true)]
        public int IdCliente { get; set; }
        public string Identificador { get; set; }
    }
}