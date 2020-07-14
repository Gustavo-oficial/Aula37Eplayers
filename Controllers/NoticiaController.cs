using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aula37E_players.Models;
using Microsoft.AspNetCore.Http;

namespace Aula37E_players.Controllers
{
    public class NoticiaController : Controller
    {

        Noticias noticiaModel = new Noticias();
        public IActionResult Index()
        {
            ViewBag.Noticias = noticiaModel.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Noticias novaNoticia   = new Noticias();
            novaNoticia.IdNoticia = Int32.Parse(form["IdNoticia"]);
            novaNoticia.Titulo    = form["Titulo"];
            novaNoticia.Imagem   = form["Imagem"];

            noticiaModel.Create(novaNoticia);            
            ViewBag.Noticias = noticiaModel.ReadAll();

            return LocalRedirect("~/Noticia");
        }
    }
}