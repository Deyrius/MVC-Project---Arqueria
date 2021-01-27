using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Arqueria.Models
{
    public partial class Participacion
    {
        public int Id { get; set; }
        public int Arquero { get; set; }
        public int Torneo { get; set; }
        public int Categoria { get; set; }
        public int Diana { get; set; }
        public int Puntaje { get; set; }
        public int Mosca { get; set; }
        public int Puesto { get; set; }
        public bool PrimerTreinta { get; set; }

        public virtual Arquero ArqueroNavigation { get; set; }
        public virtual Categoria CategoriaNavigation { get; set; }
        public virtual Diana DianaNavigation { get; set; }
        public virtual Torneo TorneoNavigation { get; set; }
    }
}
