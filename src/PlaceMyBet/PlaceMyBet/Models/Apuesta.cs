using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int id_apuesta, double mercadoOverUnder, string tipoOverUnder, double cuota, double dineroApostado, DateTime fecha, int mercado_id_mercado, string usuario_Email)
        {
            this.id_apuesta = id_apuesta;
            MercadoOverUnder = mercadoOverUnder;
            TipoOverUnder = tipoOverUnder.ToLower();
            Cuota = cuota;
            DineroApostado = dineroApostado;
            this.fecha = fecha;
            Mercado_id_mercado = mercado_id_mercado;
            Usuario_Email = usuario_Email;
            
            
        }

        public int id_apuesta { get; set; }
        public double MercadoOverUnder { get; set; }
        public string TipoOverUnder { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public DateTime fecha { get; set; }
        public int Mercado_id_mercado { get; set; }
        public string Usuario_Email { get; set; }
    }
    public class ApuestaDTO
    {
        public ApuestaDTO( string usuario_Email, double mercadoOverUnder,double cuota, string tipoOverUnder, double dineroApostado, DateTime fecha)
        {
            Usuario_Email = usuario_Email;
            TipoOverUnder = tipoOverUnder.ToLower();
            Cuota = cuota;
            MercadoOverUnder = mercadoOverUnder;        
            DineroApostado = dineroApostado;
            this.fecha = fecha;
        }
        public string Usuario_Email { get; set; }
        public double MercadoOverUnder { get; set; }        
        public double Cuota { get; set; }
        public string TipoOverUnder { get; set; }
        public double DineroApostado { get; set; }
        public DateTime fecha { get; set; }
    }   

    public class ApuestaFilter
    {
        public ApuestaFilter(string tipoOverUnder, double cuota,  double dineroApostado, int evento)
        {
            Evento = evento;
            TipoOverUnder = tipoOverUnder.ToLower();
            Cuota = cuota;        
            DineroApostado = dineroApostado;
        
        }
    
        public int Evento { get; set; }
        public double Cuota { get; set; }
        public string TipoOverUnder { get; set; }
        public double DineroApostado { get; set; }    
    }
    /// <summary>
    /// Recupera string tipoOverUnder, double cuota, double dineroApostado, int evento=> viene de otra tabla,
    /// del filtrado por email y tipo
    /// </summary>    
     
    public class ApuestaFilter2
    {/// <summary>
     /// lo que quiero mostrar, creado por el constructor
     /// </summary> 
        public ApuestaFilter2(double mercadoOverUnder, string tipoOverUnder, double cuota, double dineroApostado)
        {
            MercadoOverUnder = mercadoOverUnder;
            TipoOverUnder = tipoOverUnder.ToLower();
            Cuota = cuota;
            DineroApostado = dineroApostado;      
        }        
        public double MercadoOverUnder { get; set; }
        public string TipoOverUnder { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }       
    }

}
