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


namespace Arqueria.Controllers

{
    public class TorneosController : Controller
    {
        private readonly ArqueriaDbContext _context;
        List<Torneo> listaTorneos;
        public TorneosController(ArqueriaDbContext context)
        {
            _context = context;
            listaTorneos= _context.Torneo.Include(t => t.CampeonatoNavigation).ToList();
        }
         public IActionResult IrHome(){
            return RedirectToAction("Index","Home");
        }

        public IActionResult Index(string campobusqueda)
        {
            var resultadoBusqueda=listaTorneos;
            if(!String.IsNullOrEmpty(campobusqueda)){
                resultadoBusqueda=_context.Torneo.Include(t => t.CampeonatoNavigation).Where(a=>a.Nombre.ToUpper().Contains(campobusqueda.ToUpper())).ToList<Torneo>();
            }
            return View(resultadoBusqueda);
        }
        public IActionResult ListaTorneo(string campobusqueda)
        {
            var resultadoBusqueda=listaTorneos;
            if(!String.IsNullOrEmpty(campobusqueda)){
                resultadoBusqueda=_context.Torneo.Include(t => t.CampeonatoNavigation).Where(a=>a.Nombre.ToUpper().Contains(campobusqueda.ToUpper())).ToList<Torneo>();
            }
            return View(resultadoBusqueda);
        }
         public IActionResult Crear()
        {
            var torneo = new CrearTorneoDto();
            torneo.Campeonatos = _context.Campeonato.Select(c => new System.Web.Mvc.SelectListItem{
                Value = c.Id.ToString(),
                Text = c.Anio
            });
            return View(torneo);
        }
        [HttpPost, ActionName("Crear")]
        public IActionResult GuardarNuevoTorneo(CrearTorneoDto tForm){
            //var nuevonombre = _context.Torneo.Where(t => t.Nombre.Replace(" ", string.Empty).ToLower() == tForm.Nombre.Replace(" ", string.Empty).ToLower()).FirstOrDefault();
            //var fecha = _context.Torneo.Where(t => t.Fecha == tForm.Fecha).FirstOrDefault();
            //var campeonato = _context.Campeonato.Find(tForm.CampeonatoId);
            Torneo nuevoTorneo = new Torneo();
            nuevoTorneo.Nombre = tForm.Nombre;
            nuevoTorneo.Fecha = tForm.Fecha;
            nuevoTorneo.CampeonatoNavigation = _context.Campeonato.Find(tForm.CampeonatoId);
            Console.WriteLine(nuevoTorneo.CampeonatoNavigation.Anio);

            /*
            if (nuevoTorneo.Fecha != null)
            {
                ModelState.AddModelError("Fecha", "El Torneo ya se encuentra registrado.");
                return View(nuevoTorneo);
            }*/
            _context.Torneo.Add(nuevoTorneo);
            _context.SaveChanges();
            


            return RedirectToAction("ListaTorneo");
        }

        public IActionResult IraInscripcion( int  torneoId ){
            return RedirectToAction("Participacion","Participaciones",new {Torneo = torneoId});
        }
        public IActionResult IraTorneo(int torneoId){
            return RedirectToAction("Order", "Participaciones",new {Torneo = torneoId});
        }

        public IActionResult Order(DateTime Fecha){
            listaTorneos = listaTorneos.OrderByDescending( t => t.Fecha).ToList();
            return View(listaTorneos);
        }


    }



}

