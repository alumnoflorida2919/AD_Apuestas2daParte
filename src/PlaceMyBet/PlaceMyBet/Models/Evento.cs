using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Evento
    {
        public Evento()
        {

        }
        public Evento(int eventoId, string equipoLocal, string equipoVisitante, DateTime fecha)
        {
            EventoId = eventoId;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            Fecha = fecha;
        }

        public int EventoId { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }
        //EVENTO SE CREA ANTES QUE MERCADOS. EVENTOS 1 - N MERCADOS
        public List<Mercado> Mercados { get; set; }//un eventos puede tener varios mercados
    }
    public class EventoDTO
    {
        public EventoDTO(string equipoLocal, string equipoVisitante, DateTime fecha)
        {
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            Fecha = fecha;
        }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }
    }
}