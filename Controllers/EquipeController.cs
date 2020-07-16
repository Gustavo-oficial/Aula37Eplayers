using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Aula37E_players.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

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
            
            var file    = form.Files[0];
            var folder  = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/Equipes");

            if(file != null)
            {
                if(!Directory.Exists(folder)){
                    Directory.CreateDirectory(folder);
                }

                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/", folder, file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))  
                {  
                    file.CopyTo(stream);  
                }
                novaEquipe.Imagem   = file.FileName;
            }
            else
            {
                novaEquipe.Imagem   = "padrao.png";
            }

            equipe.Create(novaEquipe);            
            ViewBag.Equipes = equipe.ReadAll();

            return LocalRedirect("~/Equipe");
        }


          [Route("Equipe/{id}")]
        public IActionResult Excluir(int id)
        {
            equipe.Delete(id);
            ViewBag.Equipes = equipe.ReadAll();
            return LocalRedirect("~/Equipe");
        }
    }
}