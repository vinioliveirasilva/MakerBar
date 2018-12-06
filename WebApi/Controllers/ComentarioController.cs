using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Connection;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ComentarioController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Comentario> Get()
        {
            var toReturn = new Comentario().Get(DbConnection.GetInstance());

            return toReturn;
        }

        // GET api/<controller>/5
        public IEnumerable<Comentario> Get(long id)
        {
            var toReturn = new Comentario().Get(DbConnection.GetInstance(), id);

            return toReturn;
        }

        // POST api/<controller>
        public bool Post([FromBody]Comentario value)
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
        public bool Put(long id, [FromBody]Comentario value)
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
                var toDelete = new Comentario().Delete(DbConnection.GetInstance(), id);
            }
            catch
            {
                return false;
            }

            return true;

        }
    }
}