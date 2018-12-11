using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Helper;

namespace WebApi.Models
{
    public class ItensFabricacao
    {
        [AttributeType(PrimaryKey = true)]
        [AutoIncrement(Auto = true)]
        public int Id { get; set; }

        [AttributeType(ForeignKey = true)]
        public int IdItem { get; set; }

        [AttributeType(ForeignKey = true)]
        public int IdFabricacao { get; set; }
    }
}