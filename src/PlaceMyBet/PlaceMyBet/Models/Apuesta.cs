using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta()
        {

        }
        public Apuesta(int apuestaId, double mercadoOverUnder, string tipoOverUnder, double cuota, double dineroApostado, DateTime fecha, string usuarioId, int mercadoId)
        {
            ApuestaId=apuestaId;
            MercadoOverUnder = mercadoOverUnder;
            TipoOverUnder = tipoOverUnder.ToLower();
            Cuota = cuota;
            DineroApostado = dineroApostado;
            this.fecha = fecha;
            UsuarioId = usuarioId;
            MercadoId = mercadoId;
        }

        public int ApuestaId { get; set; }
        public double MercadoOverUnder { get; set; }
        public string TipoOverUnder { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        public DateTime fecha { get; set; }
        //public int Mercado_id_mercado { get; set; }//este el la FK de mercadosId, se tiene que borrar?? 
        //public string Usuario_Email { get; set; }//este es la foreign key de usuario Id, se tiene que borrar??
        //USUARIO 1- N APUESTA
        public string UsuarioId { get; set; }//clave foranea de usuarioEmail
        public Usuario Usuario { get; set; }//una apuesta solo puede ser hecha por un usuario
        //MERCADO 1-N APUESTA
        public Mercado Mercado { get; set; }//las apuestas solo se hacen a un mercado concreto
        public int MercadoId { get; set; }//Clave foranea MercadoId

    }
    public class ApuestaDTO
    {
        public ApuestaDTO(string usuario_Email, int eventoId, string tipoOverUnder, double cuota, double dineroApostado)
        {
            Usuario_Email = usuario_Email;
            EventoId = eventoId;
            TipoOverUnder = tipoOverUnder;
            Cuota = cuota;
            DineroApostado = dineroApostado;
        }

        public string Usuario_Email { get; set; }        
        public int EventoId { get; set; }
        public string TipoOverUnder { get; set; }
        public double Cuota { get; set; }
        public double DineroApostado { get; set; }
        
    }
    //Creo el constructor con los datos que quiero mostrar
    public class ApuestaFiltroDinero
    {
        public ApuestaFiltroDinero(string tipoOverUnder, string equipoLocal, string equipoVisitante)
        {            
            TipoOverUnder = tipoOverUnder;
            EquipoLocal = equipoLocal;
            EquipoVisitante = equipoVisitante;
        }

        public string TipoOverUnder { get; set; }
        public string EquipoLocal { get; set; }
        public string EquipoVisitante { get; set; }

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
