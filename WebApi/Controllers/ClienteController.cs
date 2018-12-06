using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Connection;
using WebApi.Models;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClienteController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Cliente> Get()
        {
            var toReturn = new Cliente().Get(DbConnection.GetInstance());

            return toReturn;
        }

        // GET api/<controller>/5
        public IEnumerable<Cliente> Get(long id)
        {
            var toReturn = new Cliente().Get(DbConnection.GetInstance(), id);

            return toReturn;
        }

        // POST api/<controller>
        public bool Post([FromBody]Cliente value)
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
        public bool Put(long id, [FromBody]Cliente value)
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
                var toDelete = new Cliente().Delete(DbConnection.GetInstance(), id);
            }
            catch
            {
                return false;
            }

            return true;

        }
    }
}