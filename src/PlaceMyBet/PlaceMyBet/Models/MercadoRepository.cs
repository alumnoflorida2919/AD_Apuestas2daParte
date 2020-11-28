using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class MercadoRepository
    {
        const double cuota= 0.95;
        /// <summary>
        /// Muestra todos los mercados
        /// </summary>
        /// <returns>devuelve una lista de mercados</returns>
        internal List<Mercado> Retrieve()
        {
            List<Mercado> mercados = new List<Mercado>();
            using (PlaceMyBetContext context =new PlaceMyBetContext())
            {
                mercados = context.Mercado.ToList();
            }
            return mercados;
        }
        /// <summary>
        /// Devuelvo una lista de mercados con determinado id
        /// </summary>
        /// <returns></returns>
        internal Mercado Retrieve(int id)
        {
            Mercado mercados;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercado
                    .Where(s => s.MercadoId == id)
                    .FirstOrDefault();
            }
            return mercados;
        }
        internal void Save(Mercado m)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();

            context.Mercado.Add(m);
            context.SaveChanges();
        }
        internal List<MercadoDTO> RetrieveDTO()
        {/*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from mercados";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            MercadoDTO m = null;
            List<MercadoDTO> mercados = new List<MercadoDTO>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));
                m = new MercadoDTO(res.GetDouble(1), res.GetDouble(2), res.GetDouble(3));
                mercados.Add(m);
                
            }
            con.Close();
            return mercados;*/
            return null;
        }

        ///Metodo para acumular el dinero apostado en su celda correspondiente (overo o under)
        public void SumaApuesta(Apuesta a)
        {
            //MySqlConnection con = Connect();
            //MySqlCommand command = con.CreateCommand();
            // para que aunque introduzcas puntos no te transforme el sql en comas
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            if (a.TipoOverUnder.ToLower() == "over")
            {    
                //string consulta = string.Format("UPDATE mercados SET DineroApostadoOver = (DineroApostadoOver + '{0}') WHERE id_mercado ='{1}';", a.DineroApostado, a.Mercado_id_mercado);
                //command.CommandText = consulta;                
                //Debug.WriteLine("comando" + command.CommandText);
            }
            else{
                //string consulta = string.Format("UPDATE mercados SET DineroApostadoUnder = (DineroApostadoUnder + '{0}') WHERE id_mercado ='{1}';", a.DineroApostado, a.Mercado_id_mercado);
                //command.CommandText = consulta;
                //Debug.WriteLine("comando" + command.CommandText);
            }
            ///cuando tenermos una de las dos condiciones, cargamos la consulta en el command, abrimos conexion, hacemos consulta
            ///y cerramos conexion
            /*try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException e)
            {

            }*/
            
        }
        public void ActualizarCuotas(Apuesta a)
        {   
           
        }
        /// <summary>
        /// recojo el objeto mercado cargado del retrive y lo recorro haciendole una condicion
        /// </summary>
       
        internal double CuotaOver(Apuesta a)
        {
            List<Mercado> m = new List<Mercado>();
            m = Retrieve();
            for(int i=0; i < m.Count; i++)
            {
                if (m[i].MercadoId == a.MercadoId)
                {
                    double probOver;
                    probOver = m[i].DineroApostadoOver / (m[i].DineroApostadoOver + m[i].DineroApostadoUnder);
                    return Math.Round((1 / probOver) * cuota, 2, MidpointRounding.AwayFromZero);
                }
            }
            return 0;
        }
        internal double CuotaUnder(Apuesta a)
        {
            List<Mercado> m = new List<Mercado>();
            m = Retrieve();
            for (int i = 0; i < m.Count; i++)
            {
                if (m[i].MercadoId == a.MercadoId)
                {
                    double probUnder;
                    probUnder = m[i].DineroApostadoUnder / (m[i].DineroApostadoOver + m[i].DineroApostadoUnder);
                    return Math.Round((1 / probUnder) * cuota, 2, MidpointRounding.AwayFromZero);
                }
            }
            return 0;
        }
        /// <summary>
        /// traer todo de los mercados de un tipo y un evento determinado
        /// </summary>
      
        internal List<Mercado> GiveMeMarket(double tipo,int evento)
        {/*
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;
            //string consulta=string.Format("SELECT * FROM mercados WHERE (OverUnder = '{0}') AND (Eventos_Identificador_evento = '{1}');",tipo,evento);
            command.CommandText = "SELECT * FROM mercados WHERE OverUnder = @O AND Eventos_Identificador_evento = @E";
            command.Parameters.AddWithValue("@O", tipo);
            command.Parameters.AddWithValue("@E", evento);
            //me quedo haciendo el try catch de la consulta
            try
            {
                con.Open();
                MySqlDataReader res = command.ExecuteReader();
                Mercado m = null;
                List<Mercado> mercados = new List<Mercado>();
                while (res.Read())
                {
                    Debug.WriteLine("Recuperado: " + res.GetInt32(0) + " " + res.GetDouble(1) + " " + res.GetDouble(2) + " " + res.GetDouble(3) + " " + res.GetDouble(4) + " " + res.GetDouble(5) + " " + res.GetInt32(6));
                    m = new Mercado(res.GetInt32(0), res.GetDouble(1), res.GetDouble(2), res.GetDouble(3), res.GetDouble(4), res.GetDouble(5), res.GetInt32(6));
                    mercados.Add(m);
                }
                con.Close();
                return mercados;
            }
            catch(MySqlException e)
            {
                Debug.WriteLine("Se ha producido un error de conexion");
                return null;
            }*/
            return null;
        }

    }
}