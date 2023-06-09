﻿using LabMVCAula10_05.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LabMVCAula10_05.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

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

        public ActionResult Cadastro()
        {
            ViewBag.NotasAlunos = Aluno.GetListaNotasAlunos();


            return View(new Aluno());
        }

        [HttpPost]
        public ActionResult Salvar(Aluno aluno)
        {
            Aluno.Salvar(aluno);
 
            return RedirectToAction("Cadastro");
        }

        [HttpPost]
        public ActionResult Excluir(int matricula)
        {
            Aluno.Excluir(matricula);

            return RedirectToAction("Cadastro");
        }
    }
}
