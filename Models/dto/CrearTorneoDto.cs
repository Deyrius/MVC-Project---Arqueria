using System.Collections.Generic;
using System.Web.Mvc;
using System;
using System.ComponentModel.DataAnnotations;


namespace Arqueria.Models
{
    public partial class CrearTorneoDto
    {
        public string Nombre {get;set;}
        public DateTime Fecha { get; set; }
        public int CampeonatoId {get;set;}
        public IEnumerable<SelectListItem> Campeonatos { get; set; }  






    }
}