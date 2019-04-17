using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string returnURL)
        {
            ViewBag.ReturnUrl = returnURL;
            return View(new Login());
        }

        [Authorize(Roles = "0,1")]
        public ActionResult CreateCliente()
        {
            return PartialView("CreateCliente");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (makerbarEntities db = new makerbarEntities())
                {
                    var vLogin = db.Login.Where(p => p.Email.Equals(login.Email)).FirstOrDefault();

                    if (vLogin != null)
                    {
                        if (Equals(vLogin.Ativo, 1))
                        {
                            if (Equals(vLogin.Senha, login.Senha))
                            {
                                FormsAuthentication.SetAuthCookie(vLogin.Email, false);

                                if (Url.IsLocalUrl(returnUrl)
                                && returnUrl.Length > 1
                                && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//")
                                && returnUrl.StartsWith("/\\"))
                                {
                                    return Redirect(returnUrl);
                                }

                                Session["Nome"] = vLogin.Nome;
                                return RedirectToAction("Home", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Senha informada Inválida!!!");
                                return View("Index", new Login());
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Usuário sem acesso para usar o sistema!!!");
                            return View("Index", new Login());
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "E-mail informado inválido!!!");
                        return View("Index", new Login());
                    }
                }
            }
            return View(login);
        }
        [Authorize(Roles = "0,1")]
        public ActionResult Home()
        {
            return View();
        }
    }
}