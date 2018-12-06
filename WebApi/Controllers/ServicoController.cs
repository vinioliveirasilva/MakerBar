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
    public class ServicoController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Servico> Get()
        {
            var toReturn = new Servico().Get(DbConnection.GetInstance());

            return toReturn;
        }

        // GET api/<controller>/5
        public IEnumerable<Servico> Get(long id)
        {
            var toReturn = new Servico().Get(DbConnection.GetInstance(), id);

            return toReturn;
        }

        // POST api/<controller>
        public bool Post([FromBody]Servico value)
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
        public bool Put(long id, [FromBody]Servico value)
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
                var toDelete = new Servico().Delete(DbConnection.GetInstance(), id);
            }
            catch
            {
                return false;
            }

            return true;

        }
    }
}