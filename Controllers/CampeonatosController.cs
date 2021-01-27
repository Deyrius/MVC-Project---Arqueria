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
    public class CampeonatosController : Controller
    {
        private readonly ArqueriaDbContext _context;
        List<Campeonato> listaCampeonatos;
        public CampeonatosController(ArqueriaDbContext context)
        {
            _context = context;
            listaCampeonatos= _context.Campeonato.ToList<Campeonato>();
        }
        public IActionResult ListaCampeonato(string campobusqueda = null)
        {
            var resultadoBusqueda=listaCampeonatos;
            if(!String.IsNullOrEmpty(campobusqueda)){
                resultadoBusqueda=listaCampeonatos.Where(a=>a.Anio.ToUpper().Replace(" ","").Contains
                (campobusqueda.ToUpper().Replace(" ",""))).ToList<Campeonato>();
            }

            return View(resultadoBusqueda);
        }
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost, ActionName("Crear")]
        public IActionResult GuardarNuevoCampeonato(Campeonato campeonatoFormulario){

            if (campeonatoFormulario.Anio == null){return View();}
            
            var anio = _context.Campeonato.Where(c => c.Anio.Replace(" ", string.Empty).ToLower()
             == campeonatoFormulario.Anio.Replace(" ", string.Empty).ToLower()).FirstOrDefault();

            if (anio != null)
            {
                ModelState.AddModelError("Anio", "El Campeonato ya se encuentra registrado.");
                return View();
            }
            _context.Campeonato.Add(campeonatoFormulario);
            _context.SaveChanges();
            return RedirectToAction("ListaCampeonato");
        }

        public IActionResult CampeonatoGanadores(int campeonatoId){

            int idUltimoTorneo = _context.Torneo.Include(t => t.CampeonatoNavigation)
                                                .Where(t => t.CampeonatoNavigation.Id == campeonatoId)
                                                .OrderBy(t => t.Fecha)
                                                .ToList()[^1].Id;

            Dictionary<int, List<ArqueroConPuntaje>> arqueroByCategoriaId = new Dictionary<int, List<ArqueroConPuntaje>>();

            _context.Participacion.Include(p => p.TorneoNavigation)
                                .ThenInclude(t => t.CampeonatoNavigation)
                                .Include(p => p.ArqueroNavigation).ThenInclude(a => a.ClubNavigation)
                                .Include(p => p.CategoriaNavigation)
                                .Where(p => p.TorneoNavigation.CampeonatoNavigation.Id == campeonatoId)
                                .ToList().ForEach(p => {
                                    if(!arqueroByCategoriaId.ContainsKey(p.Categoria)){
                                        arqueroByCategoriaId.Add(p.Categoria, new List<ArqueroConPuntaje>());
                                    }
                                    bool agregarArquero = true;

                                    foreach (ArqueroConPuntaje arqueroCont in arqueroByCategoriaId[p.Categoria])
                                    {
                                        if(arqueroCont.arquero.Id == p.Arquero){
                                            agregarArquero = false;
                                            break;
                                        }
                                    }

                                    if(agregarArquero){
                                        arqueroByCategoriaId[p.Categoria].Add(new ArqueroConPuntaje(){
                                            arquero = p.ArqueroNavigation,
                                            categoria = p.CategoriaNavigation,
                                            participoEnElUltimoTorneo = p.Torneo == idUltimoTorneo
                                        });
                                    }

                                    foreach(ArqueroConPuntaje arqueroCont in arqueroByCategoriaId[p.Categoria]){
                                        if(arqueroCont.arquero.Id == p.Arquero){
                                            arqueroCont.cantParticipaciones += 1;
                                            arqueroCont.puntajes.Add(p.Puntaje);
                                            if(!arqueroCont.participoEnElUltimoTorneo){
                                                arqueroCont.participoEnElUltimoTorneo = p.Torneo == idUltimoTorneo;
                                            }
                                            Console.WriteLine(arqueroCont.arquero.Nombre + " " + arqueroCont.puntaje);
                                            if(arqueroCont.participoEnElUltimoTorneo && arqueroCont.cantParticipaciones >= 5){
                                                arqueroCont.puntaje = Convert.ToInt32(arqueroCont.puntajes.OrderBy(p => p).Take(5).Average());
                                                Console.WriteLine(arqueroCont.arquero.Nombre + " " +arqueroCont.puntaje);
                                            }
                                        }
                                    }
                                });

            List<CampeonatoGanadorDto> datosVista = new List<CampeonatoGanadorDto>();
            foreach (int categoriaId in arqueroByCategoriaId.Keys)
            {
                List<ArqueroConPuntaje> ordered = new List<ArqueroConPuntaje>();
                foreach(ArqueroConPuntaje arqueroCont in arqueroByCategoriaId[categoriaId]){
                    if(arqueroCont.puntaje > 0){
                        ordered.Add(arqueroCont);
                    }
                }
                int pos = 1;
                foreach(ArqueroConPuntaje arqueroCont in ordered.OrderByDescending(p => p.puntaje).ToList().Take(3)){
                    datosVista.Add(new CampeonatoGanadorDto(){
                        arquero = arqueroCont.arquero,
                        categoria = arqueroCont.categoria,
                        puesto = pos++,
                        puntaje = arqueroCont.puntaje                       
                    });
                }
                pos = 0;
            }
            return View(datosVista);
        }
        public IActionResult IrHome(){
            return RedirectToAction("Index","Home");
        }



    }


}