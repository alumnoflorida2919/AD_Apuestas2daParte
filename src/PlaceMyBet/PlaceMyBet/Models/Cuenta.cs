using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;

namespace PlaceMyBet.Models
{
    public class Cuenta
    {
        //NO SE SI TIENE QUE CREAR EL CONSTRUCTOR DE CUENTA PARA INSERTAR DATOS
        /*
        public Cuenta(int cuentaId, string nombreBanco, double saldo, string usuarioId)
        {
            CuentaId = cuentaId;
            NombreBanco = nombreBanco;
            Saldo = saldo;
            UsuarioId = usuarioId;
        }*/
        public string CuentaId { get; set; }
        public string NombreBanco { get; set; }
        public double Saldo { get; set; }
        //public string UsuarioEmail { get; set; } esta es la propiedad de usuarioId
        //PRIMERO SE CREA EL USUARIO Y LUEGO LA CUENTA
        public string UsuarioId { get; set; }//FK de email de usuario
        public Usuario Usuario { get; set; }

        public Cuenta()
        {

        }
    }
}