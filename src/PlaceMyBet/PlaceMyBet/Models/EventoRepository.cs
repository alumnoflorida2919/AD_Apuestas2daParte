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

        internal List<EventoDTO> RetrieveDTO() //internal es como un public pero un poco mas restrictivo
        {/*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Eventos";

            try
            {

                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                EventoDTO e = null;
                List<EventoDTO> eventos = new List<EventoDTO>();
                while (res.Read())

                {
                    Debug.WriteLine("Recuperado:" + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    e = new EventoDTO(res.GetString(1), res.GetString(2), res.GetDateTime(3));
                    eventos.Add(e);
                }
                con.Close();
                return eventos;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }*/
            return null;
        }
    }
}