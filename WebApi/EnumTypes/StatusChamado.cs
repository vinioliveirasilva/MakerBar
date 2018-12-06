using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.EnumTypes
{
    public enum StatusChamado
    {
        Desconhecido = 0,
        EmAberto = 1,
        EmProcessamento = 2,
        Bloqueado = 3,
        Concluido = 4,
        Cancelado = 5
    }
}