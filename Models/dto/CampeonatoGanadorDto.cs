using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Arqueria.Models
{
    public class CampeonatoGanadorDto
    {
        public Arquero arquero {get;set;}

        public Categoria categoria {get;set;}

        public int puntaje {get;set;}

        public int puesto {get;set;}
    }
}