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
    public class EquipeController : Controller
    {

        Equipe equipe = new Equipe();
        public IActionResult Index()
        {
            ViewBag.Equipes = equipe.ReadAll();
            return View();
        }

        public IActionResult Cadastrar(IFormCollection form)
        {
            Equipe novaEquipe   = new Equipe();
            novaEquipe.IdEquipe = Int32.Parse(form["IdEquipe"]);
            novaEquipe.Nome     = form["Nome"];
            novaEquipe.Imagem   = form["Imagem"];

            equipe.Create(novaEquipe);            
            ViewBag.Equipes = equipe.ReadAll();

            return LocalRedirect("~/Equipe");
        }
    }
}