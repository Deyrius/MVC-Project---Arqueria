using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Arqueria.Models
{
    public class ListaParticipacionDto
    {
        public Torneo torneo{get;set;}

        public List<ParticipacionDto> participantes{get;set;}
    }
}