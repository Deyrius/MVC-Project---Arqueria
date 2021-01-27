
using System;
using System.Collections.Generic;

namespace Arqueria.Models
{
    public class ArqueroConPuntaje
    {
        public Arquero arquero {get; set;}
        public Categoria categoria {get; set;}
        public List<int> puntajes {get; set;}
        public int puntaje {get; set;}
        public int cantParticipaciones {get; set;}
        public bool participoEnElUltimoTorneo {get; set;}

        public ArqueroConPuntaje(){
            this.participoEnElUltimoTorneo = false;
            this.puntaje = 0;
            this.cantParticipaciones = 0;
            this.puntajes = new List<int>();
        }
    }
}