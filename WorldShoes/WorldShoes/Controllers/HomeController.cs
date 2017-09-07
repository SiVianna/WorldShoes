using MVC.Model.DataBase;
using MVC.Model.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace WorldShoes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int page = 1, int pageSize = 9)
        {
            this.PreencherCategoriasEFabricantes();
            var produtos = DBConfig.Instance.ProdutoRepository.AgruparPorNome();
            PagedList<Produto> paginacao = new PagedList<Produto>(produtos, page, pageSize);
            ViewBag.Acao = "Index";
            return View(paginacao);
        }


        


        public ActionResult ProdutosPorCategoria(int id, int page = 1, int pageSize = 9)
        {
            PreencherCategoriasEFabricantes();
            var produtos = DBConfig.Instance.ProdutoRepository.BuscarPorCategoria(id);
            PagedList<Produto> paginacao = new PagedList<Produto>(produtos, page, pageSize);
            ViewBag.Id = id;
            ViewBag.Acao = "ProdutosPorCategoria";
            return View(paginacao);
        }

        public ActionResult ProdutosPorMarca(int id, int page = 1, int pageSize = 9)
        {
            PreencherCategoriasEFabricantes();
            var produtos = DBConfig.Instance.ProdutoRepository.BuscarPorMarca(id);
            PagedList<Produto> paginacao = new PagedList<Produto>(produtos, page, pageSize);
            ViewBag.Id = id;
            ViewBag.Acao = "ProdutosPorMarca";
            return View(paginacao);
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


        private void PreencherCategoriasEFabricantes()
        {
            ViewBag.Categorias = DBConfig.Instance.CategoriaRepository.FindAll().Where(c => c.Produtos.Count() > 0).OrderBy(c => c.Nome);
            ViewBag.Fabricantes = DBConfig.Instance.FabricanteRepository.FindAll().Where(F => F.Produtos.Count() > 0).OrderBy(f => f.razao_social);
        }

    }
}