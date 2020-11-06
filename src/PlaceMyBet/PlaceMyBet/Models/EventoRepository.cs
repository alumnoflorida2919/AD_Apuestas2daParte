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
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;uid=root;pwd=;Convert Zero Datetime=true;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Evento> Retrieve() //internal es como un public pero un poco mas restrictivo
        {
            MySqlConnection con=Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from Eventos";

            try
            {

                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                Evento e = null;
                List<Evento> eventos = new List<Evento>(); 
                while (res.Read())

                {
                    Debug.WriteLine("Recuperado:" + res.GetInt32(0) + " " + res.GetString(1) + " " + res.GetString(2) + " " + res.GetDateTime(3));
                    e = new Evento(res.GetInt32(0), res.GetString(1), res.GetString(2), res.GetDateTime(3));
                    eventos.Add(e);
                }
                con.Close();
                return eventos;
            }
            catch(MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }
        }
        internal List<EventoDTO> RetrieveDTO() //internal es como un public pero un poco mas restrictivo
        {
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
            }
        }
    }
}