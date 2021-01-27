using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Arqueria.Models
{
    public partial class Club
    {
        public Club()
        {
            Arquero = new HashSet<Arquero>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre para el Club.")]
        public string Nombre { get; set; }
        public string Imagen { get; set; }

        public virtual ICollection<Arquero> Arquero { get; set; }
    }
}
