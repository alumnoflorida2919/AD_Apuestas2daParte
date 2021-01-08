using Microsoft.EntityFrameworkCore;
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
                //Incluir Evento y no salga nulo
                mercados = context.Mercado.Include(p => p.Evento).ToList();
                
            }
            return mercados;
        }

        internal ApuestaFilterId RetrieveFilter(int id)
        {
            ApuestaFilterId apuestaFilterId;
            Mercado mercado;
            PlaceMyBetContext context = new PlaceMyBetContext();
            mercado = context.Mercado
                .Where(s => s.MercadoId == id)
                .FirstOrDefault();
               
           apuestaFilterId =ToDTOFilter(mercado);
            return apuestaFilterId;
        }

        public static ApuestaFilterId ToDTOFilter(Mercado mercado)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Mercado m = context.Mercado.Include(apu => apu.Apuestas).FirstOrDefault();
            return new ApuestaFilterId(m.Apuestas.DineroApostado, m.Apuestas.TipoOverUnder, m.Apuestas.UsuarioId);
        }

        //Convertir Mercado en MercadoDTO
        internal List<MercadoDTO> RetrieveDTO()
        {
            List<MercadoDTO> mercados = new List<MercadoDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercado
                    .Select(p => ToDTO(p))
                    .ToList();
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
        public static MercadoDTO ToDTO(Mercado m)
        {
            return new MercadoDTO(m.OverUnder, m.CuotaOver, m.CuotaUnder);
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
    }
}