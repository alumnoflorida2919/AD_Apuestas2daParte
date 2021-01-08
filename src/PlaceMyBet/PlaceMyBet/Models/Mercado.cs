using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado()
        {

        }
        public Mercado(int mercadoId, double overUnder, double cuotaOver, double cuotaUnder, double dineroApostadoOver, double dineroApostadoUnder, int eventoId)
        {
            MercadoId = mercadoId;
            OverUnder = overUnder;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroApostadoOver = dineroApostadoOver;
            DineroApostadoUnder = dineroApostadoUnder;
            EventoId = eventoId;
        }

        public int MercadoId { get; set; }
        public double OverUnder { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroApostadoOver { get; set; }
        public double DineroApostadoUnder { get; set; }
        //public int EventosId { get; set; } esta propiedad es la fk de EventoId
        //MERCADOS 1 - N APUESTAS
        public List<Apuesta> Apuestas { get; set; }//en un mercado puede haber muchas apuestas
        //SE CREA PRIMERO EVENTO Y LUEGO MERCADO. EVENTOS 1 - N MERCADOS.
        public int EventoId { get; set; }//FK de EventoId
        public Evento Evento { get; set; }//lo relaciono con evento

    }
    public class MercadoDTO
    {
        public MercadoDTO(double overUnder, double cuotaOver, double cuotaUnder)
        {
            OverUnder = overUnder;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
        }
        public double OverUnder { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
    }
    

}