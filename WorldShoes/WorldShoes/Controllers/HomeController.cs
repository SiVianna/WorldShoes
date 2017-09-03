using MVC.Model.DataBase;
using MVC.Model.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorldShoes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var usuarios = DBConfig.Instance;
            return View();
        }
        //popopopopopopopopo
        //Sobre flavio
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult CreateUsuario()
        {
            var u = new Usuario();

            return View(u);
        }

        public ActionResult GravarUsuario(Usuario u)
        {
            DBConfig.Instance.UsuarioRepository.Salvar(u);

            return RedirectToAction("Index");
        }

        public ActionResult Login()
        {
            return View();
        }

    }
}