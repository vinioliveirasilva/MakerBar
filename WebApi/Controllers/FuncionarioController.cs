using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Mvc;
using WebApi.Connection;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FuncionarioController : Controller
    {
        public ActionResult Teste()
        {
            //var toReturn = new Funcionario().Get(DbConnection.GetInstance());

            return View();
        }

        public ActionResult GetFuncionarios()
        {
            return PartialView();
        }

        public IEnumerable<Item> Get(long id)
        {
            var toReturn = new Item().Get(DbConnection.GetInstance(), id);

            return toReturn;
        }

        public bool Post([FromBody]Item value)
        {
            try
            {
                value.Insert(DbConnection.GetInstance());
            }
            catch
            {
                return false;
            }

            return true;

        }

        public bool Put(long id, [FromBody]Item value)
        {
            try
            {
                value.Update(DbConnection.GetInstance(), id);
            }
            catch
            {
                return false;
            }

            return true;

        }

        public bool Delete(long id)
        {
            try
            {
                var toDelete = new Item().Delete(DbConnection.GetInstance(), id);
            }
            catch
            {
                return false;
            }

            return true;

        }
    }
}