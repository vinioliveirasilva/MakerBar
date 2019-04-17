using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Helpers
{
    public static class ExtensionMethods
    {
        public static Cliente RemoveMask(this Cliente cli)
        {
            cli.Cpf = cli.Cpf.RemoveMask();
            cli.TelCel = cli.TelCel.RemoveMask();
            cli.TelRes = cli.TelRes.RemoveMask();

            return cli;
        }


        static string RemoveMask(this string toRemove)
        {
            var listaParaRemover = new List<char> {'.', ',', '/', '\\', '-', '(', ')', ' '};

            foreach(var i in listaParaRemover)
            {
                while(toRemove.Contains(i))
                {
                    toRemove = toRemove.Remove(toRemove.IndexOf(i), 1);
                }
            }

            return toRemove;
        }
    }
}