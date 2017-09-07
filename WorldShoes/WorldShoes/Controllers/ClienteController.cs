﻿using MVC.Model.DataBase;
using MVC.Model.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WorldShoes.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult CreateCliente()
        {
            var u = new Usuario();

            return View(u);
        }

        public ActionResult GravarCliente(Usuario u)
        {
            
           
                DBConfig.Instance.UsuarioRepository.Salvar(u);

                return RedirectToAction("CreateCliente");
            
            
        }

        public ActionResult Login(String email, String senha)
        {
            var u = DBConfig.Instance.UsuarioRepository.findLoginAndSenha(email,senha);

            

            if (u != null)
            {
                ViewBag.Message = "Pessoa Encontrada";
                return View("Index", u);
            }

            ViewBag.Message = "Ops! Usuário não encontrado. Confira seus dados ou crie uma conta";
            return View("CreateCliente");
        }

    }
}