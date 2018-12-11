using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Estoque
    {
        [AttributeType(PrimaryKey = true)]
        [AutoIncrement(Auto = true)]
        public string Id { get; set; }

        [AttributeType(ForeignKey = true)]
        public int IdFabricacao { get; set; }

        [AttributeType(ForeignKey = true)]
        public int IdPedido { get; set; }
    }
}