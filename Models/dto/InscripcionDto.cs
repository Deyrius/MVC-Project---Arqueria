using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Arqueria.Models
{
    public partial class InscripcionDto
    {
        public int TorneoId {get;set;} 
        public IEnumerable<SelectListItem> Torneos { get; set; }
         public int ArqueroId {get;set;}

        public IEnumerable<SelectListItem> Arqueros { get; set; }   

        public int DianaId {get;set;}

        public IEnumerable<SelectListItem> Dianas { get; set; }   
        public int CategoriaID {get;set;}

        public IEnumerable<SelectListItem> Categorias { get; set; }
    }
}