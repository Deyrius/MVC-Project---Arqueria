using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Arqueria.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;



namespace Arqueria.Controllers
{
    public class ClubesController : Controller
    {
        private readonly ArqueriaDbContext _context;
        List<Club> listaClubes;
        public ClubesController(ArqueriaDbContext context)
        {
            _context = context;
            listaClubes= _context.Club.ToList<Club>();
        }
     
        public IActionResult ListaClubes(string campobusqueda = null)
        {
            var resultadoBusqueda=listaClubes;
            if(!String.IsNullOrEmpty(campobusqueda)){
                resultadoBusqueda=listaClubes.Where(a=>a.Nombre.ToUpper().Replace(" ","").Contains
                (campobusqueda.ToUpper().Replace(" ",""))).ToList<Club>();
            }

            return View(resultadoBusqueda);
        }
        public IActionResult Editar(int Id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Editar(Club clubFormulario, IFormCollection Editar){
            if(ModelState.IsValid){
                var club =_context.Club.First( c => c.Id == clubFormulario.Id);
                if (club == null)
                {
                    ModelState.AddModelError("Id", "No existe el club");
                    return View();
                }
                club.Nombre = clubFormulario.Nombre;
                _context.SaveChanges();
                return RedirectToAction("ListaClubes");
            }
            return View(clubFormulario);
        }
         public IActionResult Crear()
        {
            return View();
        }
        [HttpPost, ActionName("Crear")]
        public IActionResult GuardarNuevoClub(Club clubFormulario){
            
            var imagen ="src='@Url.Content( "+"~/imagenes/"+ "+ @Nombre.Replace("+ ", String.Empty).ToLower()+ " +".jpg)";
            clubFormulario.Imagen = imagen;

            if(clubFormulario.Nombre == null){return View();}

            var nombre = _context.Club.Where(c => c.Nombre.Replace(" ", string.Empty).ToLower()
             == clubFormulario.Nombre.Replace(" ", string.Empty).ToLower()).FirstOrDefault();
             Console.WriteLine(nombre);

            if (nombre != null)
            {
                ModelState.AddModelError("Nombre", "El Club ya se encuentra registrado.");
                return View();
            }

            _context.Club.Add(clubFormulario);
            _context.SaveChanges();
            return RedirectToAction("ListaClubes");
        }

        public IActionResult Detalle(int id){
             var club= listaClubes.Where(c=> c.Id==id).FirstOrDefault();
            //  var arqueros = _context.Arquero.Include(a => a.Id)
            //                                .Include(a => a.Nombre)   
            //                                .Include(a => a.Apellido)
            //                                .Where(a => a.Club == id)
            //                                .FirstOrDefault();
            
             return View(club);
            
        }

        public IActionResult Order(string Nombre)
        {
            ViewBag.MensajeBienvenida="--ViewBag del controller Arquero--";       
            listaClubes.Reverse();
            return View(listaClubes);
        }
        public IActionResult IrHome(){
            return RedirectToAction("Index","Home");
        }
    }
}