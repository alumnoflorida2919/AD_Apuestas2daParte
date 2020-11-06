using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PlaceMyBet.Models
{
    public class UsuarioRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=127.0.0.1;Port=3306;Database=placemybet;uid=root;pwd=;Convert Zero Datetime=true;SslMode=none";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Usuario> Retrieve()
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "select * from usuarios";

            con.Open();
            MySqlDataReader res = command.ExecuteReader();
            Usuario u = null;
            List<Usuario> usuarios = new List<Usuario>();
            while (res.Read())
            {
                Debug.WriteLine("Recuperado: "+res.GetString(0)+" "+res.GetString(1)+" "+res.GetString(2)+" "+res.GetInt32(3));
                u = new Usuario(res.GetString(0), res.GetString(1), res.GetString(2), res.GetInt32(3));
                usuarios.Add(u);
            }
            con.Close();
            return usuarios;
        }
    }
}