using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Connection;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UsuarioController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Usuario> Get()
        {
            var toReturn = new Usuario().Get(DbConnection.GetInstance());

            return toReturn;
        }

        // GET api/<controller>/5
        public IEnumerable<Usuario> Get(long id)
        {
            var toReturn = new Usuario().Get(DbConnection.GetInstance(), id);

            return toReturn;
        }

        // POST api/<controller>
        public bool Post([FromBody]Usuario value)
        {
            try
            {
                value.Senha = System.Web.Helpers.Crypto.SHA256(value.Senha);
                value.Nome = value.Nome.ToLower();

                value.Insert(DbConnection.GetInstance());
            }
            catch
            {
                return false;
            }

            return true;

        }

        // PUT api/<controller>/5
        public bool Put(long id, [FromBody]Usuario value)
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
                var toDelete = new Usuario().Delete(DbConnection.GetInstance(), id);
            }
            catch
            {
                return false;
            }

            return true;

        }
    }
}