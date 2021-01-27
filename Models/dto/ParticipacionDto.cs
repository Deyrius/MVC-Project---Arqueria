using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;


namespace Arqueria.Models
{
    public class ParticipacionDto
    {
        public int Id { get; set; }
        public Arquero arquero {get;set;}

        public Diana diana {get;set;}

        public Categoria categoria {get;set;}

        public int puntaje{get;set;}

        public int mosca{get;set;}

        public int puesto{get;set;}

        public bool primerTreinta{get;set;}
        
    }
}