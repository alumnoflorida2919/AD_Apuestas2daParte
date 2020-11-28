using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class EventoRepository
    {
        /// <summary>
        /// muestro todos los eventos
        /// </summary>
        /// <returns>devuelvo una lista de eventos</returns>
        internal List<Evento> Retrieve() //internal es como un public pero un poco mas restrictivo
        {
            List<Evento> eventos = new List<Evento>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Evento.ToList();
            }                
                return eventos;
        }
        /// <summary>
        /// guardar un evento
        /// </summary>
        /// <returns></returns>
        internal void Save(Evento e)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Evento.Add(e);
            context.SaveChanges();
        }
        internal void Update(int id, string local, string visitante)
        {
            Evento eventos;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Evento
                    .Where(s => s.EventoId == id)
                    .FirstOrDefault();
                eventos.EquipoLocal = local;
                eventos.EquipoVisitante = visitante;
                context.Evento.Update(eventos);
                context.SaveChanges();
            }          

        }
        internal void DeleteEvent(int id)
        {
            Evento eventos;
            PlaceMyBetContext context = new PlaceMyBetContext();
            eventos = context.Evento
                    .Where(s => s.EventoId == id)
                    .FirstOrDefault();
            context.Evento.Remove(eventos);
            context.SaveChanges();
        }
    }
}