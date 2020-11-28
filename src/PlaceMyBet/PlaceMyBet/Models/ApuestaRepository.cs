using Microsoft.EntityFrameworkCore;
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
                //incluir Mercado y no salga nulo
                apuestas = context.Apuesta.Include(prop => prop.Mercado).ToList();
            }
            return apuestas;
        }
        //metodo para sacar la apuesta con dto e inlude
        internal List<ApuestaDTO> RetrieveDTO()
        {
            List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuesta
                    .Select(p => ToDTO(p))
                    .ToList();
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
        internal void Save(Apuesta a)
        {
            //Agregar fecha
            DateTime time = DateTime.Now;
            a.fecha = time;
            //Recuperar mercado asociado
            MercadoRepository mercadoRepository = new MercadoRepository();
            Mercado mercado = mercadoRepository.Retrieve(a.MercadoId);            
            PlaceMyBetContext context = new PlaceMyBetContext();            
            //Actualizo en Mercado el dinero apostado y actualizo la cuota de apuesta (la traigo de mercado)
            if (a.TipoOverUnder.ToLower() == "over")
            {
                mercado.DineroApostadoOver += a.DineroApostado;
                a.Cuota = mercado.CuotaOver;
            }
            else
            {
                mercado.DineroApostadoUnder+= a.DineroApostado;
                a.Cuota = mercado.CuotaUnder;
            }
            context.Mercado.Update(mercado);
            context.SaveChanges();
            //actualizo cuota Under y Over en mercado, 
            mercado.CuotaOver=mercadoRepository.CuotaOver(a);
            mercado.CuotaUnder = mercadoRepository.CuotaUnder(a);
            context.Apuesta.Add(a);
            context.Mercado.Update(mercado);
            context.Mercado.Update(mercado);
            context.SaveChanges();
        }        
        //convertiremos una apuesta en una ApuestaDTO 
        //en la Apuesta a2 traemos a traves de context todo lo de apuestas e incluimos lo de mercado. 
        // y el FirsOrDefault quiere decir traeme el mercado (apu => apu.ApuestaId) que sea igual a ApuestaId(a.ApuestaId)
        public static ApuestaDTO ToDTO(Apuesta a)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            Apuesta a2 = context.Apuesta.Include(apu => apu.Mercado).FirstOrDefault(apu => apu.ApuestaId == a.ApuestaId);
            return new ApuestaDTO(a2.UsuarioId, a2.Mercado.EventoId, a2.TipoOverUnder, a2.Cuota, a2.DineroApostado);
        }  
    }
}