using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Arqueria.Models
{
    public partial class Diana
    {
        public Diana()
        {
            Participacion = new HashSet<Participacion>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre para la diana")]
        public string Nombre { get; set; }

        public virtual ICollection<Participacion> Participacion { get; set; }
    }
}
