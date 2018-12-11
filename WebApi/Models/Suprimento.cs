using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Suprimento
    {
        [AttributeType(PrimaryKey = true)]
        [AutoIncrement(Auto = true)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int PesoInicial { get; set; }
        public int PesoFinal { get; set; }
        public int Status { get; set; }
    }
}