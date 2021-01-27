using System;
using System.Collections.Generic;

namespace Arqueria.Models
{
    public partial class Campeonato
    {
        public Campeonato()
        {
            Torneo = new HashSet<Torneo>();
        }

        public int Id { get; set; }
        public string Anio { get; set; }
        public int? PrimerPuesto { get; set; }
        public int? SegundoPuesto { get; set; }
        public int? TercerPuesto { get; set; }

        public virtual Arquero PrimerPuestoNavigation { get; set; }
        public virtual Arquero SegundoPuestoNavigation { get; set; }
        public virtual Arquero TercerPuestoNavigation { get; set; }
        public virtual ICollection<Torneo> Torneo { get; set; }
    }
}
