using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace Arqueria.Models
{
    public partial class Arquero
    {
        public Arquero()
        {
            CampeonatoPrimerPuestoNavigation = new HashSet<Campeonato>();
            CampeonatoSegundoPuestoNavigation = new HashSet<Campeonato>();
            CampeonatoTercerPuestoNavigation = new HashSet<Campeonato>();
            Participacion = new HashSet<Participacion>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Necesita un apellido.")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "Necesita un nombre.")]
        public string Nombre { get; set; }
        [Required]
        public int Club { get; set; }
        public string Imagen { get; set; }

        [NotMapped()]
        public IFormFile Foto {get;set;}

        public virtual Club ClubNavigation { get; set; }
        public virtual ICollection<Campeonato> CampeonatoPrimerPuestoNavigation { get; set; }
        public virtual ICollection<Campeonato> CampeonatoSegundoPuestoNavigation { get; set; }
        public virtual ICollection<Campeonato> CampeonatoTercerPuestoNavigation { get; set; }
        public virtual ICollection<Participacion> Participacion { get; set; }
    }
}
