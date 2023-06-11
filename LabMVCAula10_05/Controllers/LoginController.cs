using System.Web.Mvc;
using LabMVCAula10_05.ModelViews;
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
            if(_login.Login == null || string.IsNullOrEmpty(_login.Login) || string.IsNullOrEmpty(_login.Senha))
            {
                return View("index", new ErroModelView{ Mensagem = "Login ou senha invalida"});
            }

            if(_login.Login == "charles" && _login.Senha == "123456")
            {
                Session["usuario_logado"] = _login;
                return Redirect("/");
            }
            return View("index", new ErroModelView { Mensagem = "Login ou senha invalida"});
  
        }
    }
}