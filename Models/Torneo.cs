using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Arqueria.Models
{
    public partial class Torneo
    {
        public Torneo()
        {
            Participacion = new HashSet<Participacion>();
        }

        public string Nombre { get; set; }
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int? Campeonato { get; set; }

        public virtual Campeonato CampeonatoNavigation { get; set; }
        public virtual ICollection<Participacion> Participacion { get; set; }

        public string MostrarFecha(){
            return this.Fecha.Day + "/" + this.Fecha.Month + "/" + this.Fecha.Year;
        }
    }
}
