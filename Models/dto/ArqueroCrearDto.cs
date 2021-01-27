using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;



namespace Arqueria.Models
{
    public partial class ArqueroCrearDto
    {
        [Required(ErrorMessage = "Necesita un Apellido.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Necesita un Nombre.")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Seleccione un club.")]
        public int ClubId {get;set;}

        public IEnumerable<SelectListItem> Clubes { get; set; }   
        public string Imagen { get; set; }

        [NotMapped()]
        public IFormFile Foto {get;set;}
    }
}