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

    public class CategoriasController : Controller
    {
        private readonly ArqueriaDbContext _context;
        List<Categoria> listaCategorias;
        public CategoriasController(ArqueriaDbContext context)
        {
            _context = context;
            listaCategorias = _context.Categoria.ToList<Categoria>();
        }

        public IActionResult ListaCategoria(Categoria categoria)
        {
            var categorias = listaCategorias;
            return View (categorias);
        }

        public IActionResult Editar(int Id, string Nombre)
        {
            return View();
        }

        [HttpPost]
        
        public IActionResult Editar(Categoria categoria)
        {
            if(ModelState.IsValid){
                var categoriaAnterior = listaCategorias.Where(c => c.Id == categoria.Id).FirstOrDefault();
                if (categoriaAnterior == null){
                    ModelState.AddModelError("Id", "No existe la categoria");
                    return View();
                }
                categoriaAnterior.Nombre = categoria.Nombre;
                _context.SaveChanges();
                return RedirectToAction("ListaCategoria");
            }
            return View(categoria);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost, ActionName("Crear")]

        public IActionResult GuardarNuevaCategoria(Categoria categoriaFormulario)
        {
            if(categoriaFormulario.Nombre == null){return View();}

            var nombre = _context.Categoria.Where(c => c.Nombre.Replace(" ", string.Empty).ToLower()
             == categoriaFormulario.Nombre.Replace(" ", string.Empty).ToLower()).FirstOrDefault();

            if (nombre != null)
            {
                ModelState.AddModelError("Nombre", "La categoria ya se encuentra registrada.");
                return View();
            }
            _context.Categoria.Add(categoriaFormulario);
            _context.SaveChanges();
            return RedirectToAction("ListaCategoria");
        }

        [HttpPost, ActionName("Borrar")]

        public IActionResult Borrar(int Id)
        {
             var categoria= listaCategorias.Where(c=> c.Id==Id).FirstOrDefault();
            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return RedirectToAction("ListaCategoria");
        }

        public IActionResult IrHome(){
            return RedirectToAction("Index","Home");
        }
    }
}