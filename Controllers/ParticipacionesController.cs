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
    public class ParticipacionesController : Controller
    {
        private readonly ArqueriaDbContext _context;


        public ParticipacionesController(ArqueriaDbContext context)
        {
            _context = context;
        }


        public IActionResult Participacion(int Torneo)
        {
            List<ParticipacionDto> participantesVista = new List<ParticipacionDto>();
            Dictionary<int, List<ParticipacionDto>> participanteByCatId = new Dictionary<int, List<ParticipacionDto>>();

            _context.Participacion.Include(p => p.ArqueroNavigation).ThenInclude( a => a.ClubNavigation)
                                                                    .Include(p => p.CategoriaNavigation)
                                                                    .Include(p => p.DianaNavigation)
                                                                    .Where(p => p.Torneo == Torneo)
                                                                    .ToList()
                                                                    .ForEach(p =>{
                                                                        var part = new ParticipacionDto(){
                                                                            arquero = p.ArqueroNavigation,
                                                                            categoria = p.CategoriaNavigation,
                                                                            diana = p.DianaNavigation,
                                                                            Id = p.Id,
                                                                            mosca = p.Mosca,
                                                                            primerTreinta = p.PrimerTreinta,
                                                                            puesto = p.Puesto,
                                                                            puntaje = p.Puntaje
                                                                        };
                                                                        if(!participanteByCatId.ContainsKey(part.categoria.Id)){
                                                                            participanteByCatId.Add(p.Categoria, new List<ParticipacionDto>());    
                                                                        }
                                                                        participanteByCatId[p.Categoria].Add(part);
                                                                    });
            foreach(int key in participanteByCatId.Keys){
                participantesVista.AddRange(participanteByCatId[key].OrderBy(p => p.puesto));
            }

            ListaParticipacionDto datosDeLaVista = new ListaParticipacionDto(){
                torneo = _context.Torneo.Where(t => t.Id == Torneo).FirstOrDefault(),
                participantes = participantesVista
             };

            return View(datosDeLaVista);
        }
        [HttpPost, ActionName("Participacion")]
        public IActionResult GuardarCambiosParticipaciones(IFormCollection values){

            Dictionary<int, int> puntajeById = new Dictionary<int, int>();
            Dictionary<int, int> moscaById = new Dictionary<int, int>();
            Dictionary<int, int> puestoById = new Dictionary<int, int>();
            Dictionary<int, bool> primerTreintaById = new Dictionary<int, bool>();
            Dictionary<string,List<string>> puestosPorCat = new Dictionary<string,List<string>>();

            int cantidadDePrimerTreintas = values.Keys.Where(k => k.Contains("primerTreinta"))
                                                      .Count(k => values[k].Contains("true"));
           

            if(cantidadDePrimerTreintas <=1){
                values.Keys.Where(k => !k.Equals("torneo.Id") && !k.Equals("__RequestVerificationToken"))
                            .Where(k => k.Split('.')[1].Equals("Id"))
                            .ToList()
                            .ForEach(k =>{
                                int id = Convert.ToInt32(values[k]);
                                string posP = k.Split('.')[0];
                                int puntaje = Convert.ToInt32(values[posP + ".puntaje"]);
                                puntajeById.Add(id, puntaje);
                                moscaById.Add(id, Convert.ToInt32(values[posP + ".mosca"]));
                                primerTreintaById.Add(id, values[posP + ".primerTreinta"].Contains("true"));
                                string categoria = values[posP + ".categoria.Nombre"];
                                if(!puestosPorCat.ContainsKey(categoria)){
                                    puestosPorCat.Add(categoria, new List<string>());
                                }
                                puestosPorCat[categoria].Add(id + "-" + puntaje);
                            }
                );

                puestosPorCat.Keys.ToList().ForEach(categoria => {
                    int i = 0;
                    puestosPorCat[categoria].OrderByDescending(p => {
                        i = 1;
                        return Convert.ToInt32(p.Split("-")[1]);
                    }).Select(p => {
                        puestoById.Add(Convert.ToInt32(p.Split("-")[0]), i);
                        i++;
                        return p;
                    }).ToList().ForEach(p =>{
                        int puntaje = Convert.ToInt32(p.Split("-")[1]);
                        int id = Convert.ToInt32(p.Split("-")[0]);
                        puntajeById.Keys.Where(k => k != id && puntajeById[k] == puntaje)
                                        .ToList()
                                        .ForEach(k =>{
                                            if(moscaById[k] < moscaById[id] && puestoById[k] < puestoById[id]){
                                                int aux = puestoById[k];
                                                puestoById[k] = puestoById[id];
                                                puestoById[id] = aux;
                                            } else if (moscaById[k] > moscaById[id] && puestoById[k] > puestoById[id]){
                                                int aux = puestoById[id];
                                                puestoById[id] = puestoById[k];
                                                puestoById[k] = aux;
                                            }
                                        });
                                        
                    });
                });

                _context.Participacion.Where(p => moscaById.Keys.Contains(p.Id))
                                    .ToList()
                                    .ForEach(p =>{
                                        p.Mosca = moscaById[p.Id];
                                        p.Puntaje = puntajeById[p.Id];
                                        p.PrimerTreinta = primerTreintaById[p.Id];
                                        p.Puesto = puestoById[p.Id];
                                    });

                _context.SaveChanges();
            }
            else{
                ViewBag.errorPrimerTreinta = "Seleccionó más de un primer treinta.";
            }
            
            int idTorneo =  Convert.ToInt32(values["torneo.Id"]);

            return Participacion(idTorneo);
        }
        public IActionResult Agregar(int id)
        {
            var participante = new InscripcionDto();

            List<int> inscriptos = _context.Participacion.Where(p => p.Torneo == id)
                                                         .Select(p => p.Arquero)
                                                         .ToList();
            participante.Arqueros = _context.Arquero.Where(a => !inscriptos.Contains(a.Id)).Select( a => new System.Web.Mvc.SelectListItem{
                Value = a.Id.ToString(),
                Text = a.Nombre
            });
            participante.Categorias = _context.Categoria.Select( c => new System.Web.Mvc.SelectListItem{
                Value = c.Id.ToString(),
                Text = c.Nombre
            });
            participante.Dianas = _context.Diana.Select( d => new System.Web.Mvc.SelectListItem{
                Value = d.Id.ToString(),
                Text = d.Nombre
            });
            participante.Torneos = _context.Torneo.Select( a => new System.Web.Mvc.SelectListItem{
                Value = a.Id.ToString(),
                Text = a.Nombre
            });
            participante.TorneoId = id;
            return View(participante);
        }
        [HttpPost, ActionName("Agregar")]
        public IActionResult GuardarNuevoParticipante(InscripcionDto iForm){
            if(ModelState.IsValid){

                Participacion nuevoParticipante = new Participacion();

                var inscriptos =_context.Participacion.ToList();    
                nuevoParticipante.ArqueroNavigation = _context.Arquero.Find(iForm.ArqueroId);
                nuevoParticipante.CategoriaNavigation = _context.Categoria.Find(iForm.CategoriaID);
                nuevoParticipante.DianaNavigation = _context.Diana.Find(iForm.DianaId);
                nuevoParticipante.Mosca= 0;
                nuevoParticipante.Puesto = 0;
                nuevoParticipante.Puntaje = 0;
                nuevoParticipante.Torneo = iForm.TorneoId;
                _context.Participacion.Add(nuevoParticipante);
                _context.SaveChanges();

                return RedirectToAction("Participacion", new {Torneo = iForm.TorneoId});
            }
            else{
                return View(iForm);

            }
        }
        
        public IActionResult IrAListaTorneo(int id){
            return RedirectToAction("ListaTorneo","Torneos",new {id=id});
        }

        public IActionResult Order(int Torneo , string campobusqueda){

            ListaParticipacionDto datosDeLaVista = new ListaParticipacionDto(){
                torneo = _context.Torneo.Where(t => t.Id == Torneo).FirstOrDefault(),
                participantes = _context.Participacion.Include(p => p.ArqueroNavigation).ThenInclude( a => a.ClubNavigation)
                                                      .Include(p => p.CategoriaNavigation)
                                                      .Include(p => p.DianaNavigation)
                                                      .Where(p => p.Torneo == Torneo)
                                                      .OrderBy(p => p.Puesto)
                                                      .GroupBy(p => p.Categoria)
                                                      .SelectMany(p => p)
                                                      .Select(p => new ParticipacionDto(){
                                                            Id = p.Id,
                                                            arquero = p.ArqueroNavigation,
                                                            categoria = p.CategoriaNavigation,
                                                            diana = p.DianaNavigation,
                                                            mosca = p.Mosca,
                                                            primerTreinta = p.PrimerTreinta,
                                                            puesto = p.Puesto,
                                                            puntaje = p.Puntaje
                                                        })
                                                        .ToList()                                
            };
           
            return View(datosDeLaVista);
            
        }
    }

       

 }