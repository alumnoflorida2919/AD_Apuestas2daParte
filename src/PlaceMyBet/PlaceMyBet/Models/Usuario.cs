using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class Usuario
    {
        public Usuario(string usuarioId, string nombre, string apellido, int edad)
        {
            UsuarioId = usuarioId;
            Nombre = nombre;
            Apellido = apellido;
            this.edad = edad;
        }
        public Usuario()
        {

        }

        public string UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int edad { get; set; }
        //EL USUARIO SE CREA ANTES Q LA CUENTA. USUARIO 1 - 1 CUENTA
        public Cuenta Cuenta { get; set; }
        //USUARIO 1 - N APUESTAS
        public List<Apuesta> Apuestas { get; set; }//relacion con Apuesta 1 n un usuario puede hacer varias apuestas
    }
}