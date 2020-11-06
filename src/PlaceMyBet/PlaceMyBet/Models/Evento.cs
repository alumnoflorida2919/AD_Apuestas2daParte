using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Evento
    {
        public Evento(int identificador_evento, string equipoLocal, string equipoVisitante, DateTime fecha)
        {
            Identificador_evento = identificador_evento;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
            Fecha = fecha;
        }

        public int Identificador_evento { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }
        public DateTime Fecha { get; set; }
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