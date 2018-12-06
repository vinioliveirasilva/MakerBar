using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Connection;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ChamadoController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Chamado> Get()
        {
            var toReturn = new Chamado().Get(DbConnection.GetInstance());

            return toReturn;
        }

        // GET api/<controller>/5
        public IEnumerable<Chamado> Get(long id)
        {   
            var toReturn = new Chamado().Get(DbConnection.GetInstance(), id);

            return toReturn;
        }

        // POST api/<controller>
        public bool Post([FromBody]Chamado value)
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
        public bool Put(long id, [FromBody]Chamado value)
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
                var toDelete = new Chamado().Delete(DbConnection.GetInstance(), id);
            }
            catch
            {
                return false;
            }

            return true;
            
        }
    }
}