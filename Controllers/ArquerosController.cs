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
using Microsoft.AspNetCore.Hosting;
using System.Data.SqlClient;


namespace Arqueria.Controllers

{
    public class ArquerosController : Controller
    {
        private readonly ArqueriaDbContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;


        List<Arquero> ListaArqueros;
        public ArquerosController(ArqueriaDbContext context,
                                  IWebHostEnvironment hostingEnviroment)
        {
            _context = context;
            _hostingEnvironment = hostingEnviroment;
            ListaArqueros= _context.Arquero.Include("ClubNavigation").ToList();
        }

        public IActionResult Index(string campobusqueda)
        {
            return View(ListaArqueros);
        }
        public IActionResult ListaArquero(string campobusqueda)
        {
            var resultadoBusqueda=ListaArqueros;
            if(!String.IsNullOrEmpty(campobusqueda)){
                resultadoBusqueda=ListaArqueros.Where(a=>a.Nombre.ToUpper().Contains(campobusqueda.ToUpper())
                || a.Apellido.ToUpper().Contains(campobusqueda.ToUpper()) || a.ClubNavigation.Nombre.ToUpper().Contains(campobusqueda.ToUpper())
                ).ToList<Arquero>();
            }
            return View(resultadoBusqueda);
        }
        public IActionResult Order(string Nombre)
        { 
            ListaArqueros.Sort((x,y) => string.Compare(x.Nombre, y.Nombre));
            return View(ListaArqueros);
        }

        public IActionResult Editar(int Id, string Nombre, string Apellido, string Club)//int Id, string Nombre, string Apellido, string Club
        { 
            //var user=ListaArqueros.Where(a=> a.Id==Id).FirstOrDefault();
            ViewBag.Nombre= Nombre;
            ViewBag.Apellido= Apellido;
            TempData["Nombre"]= Nombre;
            TempData["Apellido"]= Apellido;

            var arquero = new ArqueroEditarDto();
            arquero.Clubes = _context.Club.Select(c => new System.Web.Mvc.SelectListItem{
                Value = c.Id.ToString(),
                Text  = c.Nombre
            });
            arquero.ClubId= Convert.ToInt32(Club);
            return View(arquero);
           
            
        }

        [HttpPost]
        public IActionResult Editar(ArqueroEditarDto arquero){
            //Guardamos en la base o tocamos la lista
            if(ModelState.IsValid){
                var arqueroAnterior=ListaArqueros.Where(a => a.Id == arquero.Id).FirstOrDefault();
                if(arqueroAnterior != null){
                    arqueroAnterior.Nombre= arquero.Nombre;
                    arqueroAnterior.Apellido= arquero.Apellido;
                    arqueroAnterior.ClubNavigation = _context.Club.Find(arquero.ClubId);
                    _context.SaveChanges();
                    
                    try
                    {
                        string carpetaFotos = Path.Combine(_hostingEnvironment.WebRootPath, "imagenes");
                        string nombreArchivo = arquero.Id + "." + arquero.Foto.FileName.Split('.')[^1];
                        string rutaCompleta = Path.Combine(carpetaFotos, nombreArchivo);
                        string bak = nombreArchivo +".bak";
                        if (System.IO.File.Exists(rutaCompleta)){
                            System.IO.File.Replace(rutaCompleta, rutaCompleta,bak);
                        }
                        else{
                            arquero.Foto.CopyTo(new FileStream(rutaCompleta, FileMode.Create));       
                        }
                    }
                    catch (System.Exception)
                    {
                        return RedirectToAction("ListaArquero"); 
                    }
                    return RedirectToAction("ListaArquero");
                }
                else{

                    return View(arquero);
                }
            
            }
            return View(arquero);
        }


        public IActionResult Crear()
        {
            var arquero = new ArqueroCrearDto();
            arquero.Clubes = _context.Club.Select(c => new System.Web.Mvc.SelectListItem{
                Value = c.Id.ToString(),
                Text  = c.Nombre
            });
            return View(arquero);
        }
        [HttpPost, ActionName("Crear")]
        public IActionResult GuardarNuevoArquero(ArqueroCrearDto arqueroFormulario){

            if(arqueroFormulario.Foto!=null){
                // CON ESTO SUBIMOS LA IMAGEN AL SERVER
                //Guardar la ruta de la imagen en la base de datos, se setea
                //arqueroFormulario.Imagen= nombreArchivo;
            }

            //validacion ID existente
            if(ModelState.IsValid){
                Arquero nuevoArquero = new Arquero();
                nuevoArquero.Nombre = arqueroFormulario.Nombre;
                nuevoArquero.Apellido = arqueroFormulario.Apellido;
                nuevoArquero.ClubNavigation = _context.Club.Find(arqueroFormulario.ClubId);
                _context.Arquero.Add(nuevoArquero);
                
                _context.SaveChanges();

                try
                {
                    string carpetaFotos = Path.Combine(_hostingEnvironment.WebRootPath, "imagenes");
                    string nombreArchivo = nuevoArquero.Id + "." + arqueroFormulario.Foto.FileName.Split('.')[^1];
                    string rutaCompleta = Path.Combine(carpetaFotos, nombreArchivo);
                    arqueroFormulario.Foto.CopyTo(new FileStream(rutaCompleta, FileMode.Create));       
                }
                catch (System.Exception)
                {
                    return RedirectToAction("ListaArquero"); 
                }

                return RedirectToAction("ListaArquero"); 
            
            }
            else{
                return View(arqueroFormulario);
            }
        }

       [HttpPost,ActionName("Borrar")]
        public IActionResult Borrar(int Id)
        {
            var arquero= ListaArqueros.Where(a=> a.Id==Id).FirstOrDefault();
           // var participantes = _context.Participacion.ToList();
           // participantes.Find(Id);
           try
           {
             _context.Arquero.Remove(arquero);
             _context.SaveChanges();
             
           }
           catch (System.Exception)
           {
            var noBorra="No puede borrar un arquero que ya participó.";
            TempData["Error"] = noBorra;
            return RedirectToAction("Detalle", new{Id=Id});

           }
           var siBorra = "Se borro correctamente al arquero.";
           TempData["Borrado"] = siBorra;
           return RedirectToAction("ListaArquero");
        }
        public IActionResult Detalle(int id){

            var arquero= ListaArqueros.Where(a=> a.Id==id).FirstOrDefault();
            
            return View(arquero);
        }

        public IActionResult IrHome(){
            return RedirectToAction("Index","Home");
        }
        public IActionResult IrAClub(int id){
            return RedirectToAction("Detalle","Clubes",new {id=id});
        }
        
        
    }

 }