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

        public ActionResult Produtos()
        {
            var produtos = DBConfig.Instance.ProdutoRepository.AgruparPorNome();
            return View(produtos);
        }

        public ActionResult DetalhesProduto(int id = 0)
        {
            Produto produto = DBConfig.Instance.ProdutoRepository.PrimeiroProduto(id);
            if (produto != null)
            {
                var produtosRelacionados = DBConfig.Instance.ProdutoRepository.FindAll().Where(p => Equals(p.Categoria.Nome, produto.Categoria.Nome)).ToList();
                produtosRelacionados.Remove(produto);
                ViewBag.produtosRelacionados = produtosRelacionados;
                ViewBag.produtoComOutrasCores = DBConfig.Instance.ProdutoRepository.FindAll().Where(p => Equals(p.Nome, produto.Nome)).ToList();
                return View(produto);
            }
            return RedirectToAction("Produtos");
        }

    }
}