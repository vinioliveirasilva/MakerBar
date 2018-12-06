using System.Web.Http;
using WebApi.Connection;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class LoginController : ApiController
    {

        // POST api/<controller>
        public LoginResponse Post([FromBody]LoginResponse Login)
        {
            var login = new LoginResponse(Login.User, Login.Pass);

            login.Autenticate(DbConnection.GetInstance());

            return login;
        }
    }
}