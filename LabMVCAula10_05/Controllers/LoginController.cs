using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LabMVCAula10_05.Request;

namespace LabMVCAula10_05.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Logar(LoginRequest _login)
        {
            if(_login.Login == null || _login.Senha == null)
            {
                return Redirect("/Login");
            }
            var login = _login;
            return Redirect("/");
        }
    }
}