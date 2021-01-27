using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Arqueria.Models;

namespace Arqueria.Controllers
{
    public class DianasController : Controller
    {
        private readonly ArqueriaDbContext _context;
        List<Diana> listaDianas;
        public DianasController(ArqueriaDbContext context)
        {
            _context = context;
            listaDianas= _context.Diana.ToList<Diana>();
        }
        /*static List<Diana> ListaDianas = new List<Diana>()
        {
            new Diana(){Id = 1, Nombre = "E40"},
            new Diana(){Id = 2, Nombre = "E60"},
            new Diana(){Id = 3, Nombre = "E80"},
            new Diana(){Id = 4, Nombre = "E80I"},
            new Diana(){Id = 5, Nombre = "Triple Spot"},          
        };*/

        public IActionResult ListaDiana(Diana diana)
        {
            var dianas = listaDianas;
            return View (dianas);
        }
        public IActionResult Editar(int Id, string Nombre)
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Editar(Diana diana){
            if(ModelState.IsValid){
                var dianaAnterior = listaDianas.Where(d => d.Id == diana.Id).FirstOrDefault();
                if (dianaAnterior == null)
                {
                    ModelState.AddModelError("Id", "No existe la diana");
                    return View();
                }
                dianaAnterior.Nombre = diana.Nombre;
                _context.SaveChanges();
                return RedirectToAction("ListaDiana");
            }
            return View(diana);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost, ActionName("Crear")]

        public IActionResult GuardarNuevaDiana(Diana dianaFormulario)
        {
            if(dianaFormulario.Nombre == null){return View();}
            
            var nombre = _context.Club.Where(d => d.Nombre.Replace(" ", string.Empty).ToLower()
             == dianaFormulario.Nombre.Replace(" ", string.Empty).ToLower()).FirstOrDefault();

            if (nombre != null)
            {
                ModelState.AddModelError("Nombre", "La Diana ya se encuentra registrada.");
                return View();
            }
            _context.Diana.Add(dianaFormulario);
            _context.SaveChanges();
            return RedirectToAction("ListaDiana");
        }

        [HttpPost, ActionName("Borrar")]

        public IActionResult Borrar(int Id)
        {
            var diana = listaDianas.Where(d => d.Id == Id).FirstOrDefault();
            _context.Diana.Remove(diana);
            _context.SaveChanges();
            return RedirectToAction("ListaDiana");
        }

        public IActionResult IrHome(){
            return RedirectToAction("Index","Home");
        }
        


    }
}