using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Comentario
    {
        [AttributeType(PrimaryKey = true)]
        [AutoIncrement(Auto = true)]
        public int Id { get; set; }
        public int IdChamado { get; set; }
        public string Usuario { get; set; }

        public Comentario(string usuario, int idChamado)
        {
            Usuario = usuario;
            IdChamado = idChamado;
        }

        public Comentario() { }
    }
}