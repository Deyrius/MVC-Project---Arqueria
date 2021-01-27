using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Arqueria.Models
{
    public partial class Categoria
    {
        public Categoria()
        {
            Participacion = new HashSet<Participacion>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Ingrese un nombre para la categoria.")]
        public string Nombre { get; set; }

        public virtual ICollection<Participacion> Participacion { get; set; }
    }
}
