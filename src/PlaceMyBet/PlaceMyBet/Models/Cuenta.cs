using Org.BouncyCastle.Math;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;

namespace PlaceMyBet.Models
{
    public class Cuenta
    {
        public int CuentaId { get; set; }
        public string NombreBanco { get; set; }
        public double Saldo { get; set; }
        public string UsuarioEmail { get; set; }
        //PRIMERO SE CREA EL USUARIO Y LUEGO LA CUENTA
        public string UsuarioId { get; set; }//FK de email de usuario
        public Usuario Usuario { get; set; }

        public Cuenta()
        {

        }
    }
}