using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Connection;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FuncionarioController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Funcionario> Get()
        {
            var toReturn = new Funcionario().Get(DbConnection.GetInstance());

            return toReturn;
        }

        // GET api/<controller>/5
        public IEnumerable<Funcionario> Get(long id)
        {
            var toReturn = new Funcionario().Get(DbConnection.GetInstance(), id);

            return toReturn;
        }

        // POST api/<controller>
        public bool Post([FromBody]Funcionario value)
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

        // PUT api/<controller>/5
        public bool Put(long id, [FromBody]Funcionario value)
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

        // DELETE api/<controller>/5
        public bool Delete(long id)
        {
            try
            {
                var toDelete = new Funcionario().Delete(DbConnection.GetInstance(), id);
            }
            catch
            {
                return false;
            }

            return true;

        }
    }
}