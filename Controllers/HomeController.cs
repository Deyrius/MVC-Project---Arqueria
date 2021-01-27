using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Arqueria.Models;

namespace Arqueria.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult IrAClubes(){

         return RedirectToAction("ListaClubes","Clubes");
        }
        public IActionResult IrAArqueros(){
            return RedirectToAction("ListaArquero","Arqueros");
        }
        public IActionResult IrACapmpeonatos(){
            return RedirectToAction("ListaCampeonato","Campeonatos");
        }
        public IActionResult IrATorneos(){
            return RedirectToAction("ListaTorneo","Torneos");
        }

        public IActionResult IrACategorias(){
            return RedirectToAction("ListaCategoria","Categorias");
        }

        public IActionResult IrADianas(){
            return RedirectToAction("ListaDiana","Dianas");
        }
  
    }
}
