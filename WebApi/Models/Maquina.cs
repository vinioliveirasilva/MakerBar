using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Maquina
    {
        [AttributeType(PrimaryKey = true)]
        [AutoIncrement(Auto = true)]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}