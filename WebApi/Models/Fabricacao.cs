using System;
using WebApi.EnumTypes;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Fabricacao
    {
        [AttributeType(PrimaryKey = true)]
        [AutoIncrement(Auto = true)]
        public int Id { get; set; }

        [AttributeType(ForeignKey = true)]
        public int IdMaquina { get; set; }

        [AttributeType(ForeignKey = true)]
        public int IdPedido { get; set; }

        [AttributeType(ForeignKey = true)]
        public int IdSuprimento { get; set; }
    }
}