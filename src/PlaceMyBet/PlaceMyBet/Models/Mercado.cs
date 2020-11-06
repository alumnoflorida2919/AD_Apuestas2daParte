using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(int id_mercado, double overUnder, double cuotaOver, double cuotaUnder, double dineroApostadoOver, double dineroApostadoUnder, int eventos_Identificador_evento)
        {
            this.id_mercado = id_mercado;
            OverUnder = overUnder;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroApostadoOver = dineroApostadoOver;
            DineroApostadoUnder = dineroApostadoUnder;
            Eventos_Identificador_evento = eventos_Identificador_evento;
        }

        public int id_mercado { get; set; }
        public double OverUnder { get; set; }
        public double CuotaOver { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroApostadoOver { get; set; }
        public double DineroApostadoUnder { get; set; }
        public int Eventos_Identificador_evento { get; set; }
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