using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class ApuestaRepository
    {
        /// <summary>
        /// Metodo para sacar todas las apuestas
        /// </summary>
        /// <returns>lista de apuestas</returns>
        internal List<Apuesta> Retrieve()
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            using(PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuesta.ToList();
            }
            return apuestas;
        }
        /// <summary>
        /// devuelvo la apuesta con un id determinado
        /// </summary>
        internal Apuesta Retrieve(int id)
        {
            Apuesta apuestas;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuesta
                    .Where(s => s.ApuestaId == id)
                    .FirstOrDefault();
            }
            return apuestas;
        }
        internal List<ApuestaDTO> RetrieveDTO()
        {

            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            //command.CommandText = "select * from apuestas";

            //con.Open();
            ///MySqlDataReader res = command.ExecuteReader();
            ApuestaDTO a = null;
            List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
            /*while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetString(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDateTime(5) + " " + res.GetInt32(6) + " " + res.GetString(7));
                a = new ApuestaDTO(res.GetString(7),res.GetDouble(1), res.GetDouble(3),res.GetString(2), res.GetDouble(4), res.GetDateTime(5));
                apuestas.Add(a);
            }*/
            //con.Close();
            //return apuestas;
            return null;
        }
        internal void Save(Apuesta a)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            /// para que aunque introduzcas puntos no te transforme el sql en comas
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
            ///Creo el metodo para ingresar la fecha de ahora
            DateTime time=DateTime.Now;
            string timeNow;
            timeNow = time.ToString("yyyy-MM-dd HH:mm tt");
            ///creo metodos en la consulta para poder saber si es over o under
            //command.CommandText = "INSERT INTO apuestas (MercadoOverUnder, TipoOverUnder, Cuota, DineroApostado, Fecha, Mercado_id_mercado, Usuario_Email) VALUES ('" + a.MercadoOverUnder + "','" + a.TipoOverUnder + "'," + datoCuota(a.Mercado_id_mercado, a.TipoOverUnder) + ",'" + a.DineroApostado + "','" + timeNow + "'," + a.Mercado_id_mercado + ",'" + a.Usuario_Email + "');";
            //Debug.WriteLine("comando" + command.CommandText);
            
            ///abro conexiones, creo objeto MercadoRepository para poder acceder a los metodos inplantados de SumaApuesta(a)
            ///y ActualizarCuotas(a), le paso un objeto apuesta para extraer la información para saber donde hacer la actualizacion
            //try
            //{
                //con.Open();
                //command.ExecuteNonQuery();
                MercadoRepository mercado = new MercadoRepository();
                mercado.SumaApuesta(a);
                mercado.ActualizarCuotas(a);

                //con.Close();
            //}
            //catch(MySqlException e)
            {
                Debug.WriteLine("se ha producido un error de conexion");
            }

        }
        /// <summary>
        /// consulta para traer de apuestas los campos de abajo fitrado por email y tipo.
        /// </summary>       
        internal List<ApuestaFilter> GiveApuesta(string email, string tipo)
        {
            /*MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT apuestas.TipoOverUnder, apuestas.Cuota, apuestas.DineroApostado, " +
                "mercados.Eventos_Identificador_evento FROM apuestas " +
                "LEFT JOIN mercados ON apuestas.Mercado_id_mercado = mercados.id_mercado" +
                " WHERE apuestas.Usuario_Email = @E AND apuestas.TipoOverUnder = @T";
            command.Parameters.AddWithValue("@E", email);
            command.Parameters.AddWithValue("@T", tipo);
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                ApuestaFilter a = null;
                List<ApuestaFilter> apuestas = new List<ApuestaFilter>();
                while (res.Read())
                {
                    //TENGO QUE CONTROLAR Y MODIFICAR LO QUE ME DEVUELVE LA LISTA DE APUESTAS PORQUE EL EJERCICIO NO ME PIDE TODO
                    //DE APUESTAS, SI NO ALGUNOS PARAMETROS
                    //el debug realmente solo sirve para saber lo que tenemos, debe coincidir los campos con lo que le meto a "a"
                    Debug.WriteLine("Recuperado: " + res.GetString(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " +  res.GetInt32(3));
                    a = new ApuestaFilter(res.GetString(0), res.GetDouble(1), res.GetDouble(2),res.GetInt32(3));
                    apuestas.Add(a);
                }
                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }*/
            return null;
           
        }
        /// <summary>
        /// filtrado de apuestas segun mercado y email
        /// </summary>        
        internal List<ApuestaFilter2> GiveApuesta2(int mercado,string email)
        {
            /*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT apuestas.MercadoOverUnder, apuestas.TipoOverUnder, apuestas.Cuota," +
                " apuestas.DineroApostado FROM apuestas WHERE " +
                "apuestas.Mercado_id_mercado = @M AND apuestas.Usuario_Email = @E ";
            command.Parameters.AddWithValue("@M", mercado);
            command.Parameters.AddWithValue("@E", email);
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                ApuestaFilter2 a = null;
                List<ApuestaFilter2> apuestas = new List<ApuestaFilter2>();
                while (res.Read())
                {
                    //TENGO QUE CONTROLAR Y MODIFICAR LO QUE ME DEVUELVE LA LISTA DE APUESTAS PORQUE EL EJERCICIO NO ME PIDE TODO
                    //DE APUESTAS, SI NO ALGUNOS PARAMETROS
                    //el debug realmente solo sirve para saber lo que tenemos, debe coincidir los campos con lo que le meto a "a"
                    Debug.WriteLine("Recuperado: " + res.GetDouble(0) + " " + res.GetString(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3));
                    a = new ApuestaFilter2(res.GetDouble(0), res.GetString(1), res.GetDouble(2), res.GetDouble(3));
                    apuestas.Add(a);
                }
                con.Close();
                return apuestas;
            }
            catch (MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }*/
            return null;

        }
        ///el metodo para sacar el dato no lo utilizamos xq puede haber en mercados los mismos tipos, 
        ///vendria de la consulta datoIdMercado(a.MercadoOverUnder)
        private string datoIdMercado(double tipo)
        {
            return string.Format("(select id_mercado from mercados where OverUnder LIKE '{0}')", tipo);
        }
        ///Metodos para saber si es over o under 
        private string datoCuota(int mercado, string tipo)
        {
            if (tipo == "over")
            {
                return string.Format("(select CuotaOver from mercados where id_mercado like '{0}')", mercado);
            }
            

            else if(tipo=="under")
            {
                return string.Format("(select CuotaUnder from mercados where id_mercado like '{0}')", mercado);
            }
            else
            {
                return "Error";
            }
        }
    }
}