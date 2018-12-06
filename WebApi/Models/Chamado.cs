using System;
using WebApi.EnumTypes;
using WebApi.Helper;

namespace WebApi.Models
{
    public class Chamado
    {
        [AttributeType(PrimaryKey = true)]
        [AutoIncrement(Auto = true)]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Problema { get; set; }
        public int Status { get; set; }
        public int Prioridade { get; set; }
        public string Data_Abertura { get; set; }
        public string Data_Fechamento { get; set; }

        public Chamado() { }

        public Chamado(string titulo, string problema, int status, int prioridade)
        {
            Titulo = titulo;
            Problema = problema;
            Status = status;
            Prioridade = prioridade;
            Data_Abertura = DateTime.Now.Date.ToString();
            Data_Fechamento = null;
        }
    }
}