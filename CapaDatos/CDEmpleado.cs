using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CDEmpleado
    {
       private CDConexion conexion = new CDConexion();
       private SqlDataReader leer;

       public SqlDataReader iniciarSesion(string user, string pass)
       {
           SqlCommand command = new SqlCommand("SpLogin", conexion.AbrirConexion());
           command.CommandType = CommandType.StoredProcedure;
           command.Parameters.AddWithValue("@Usuario", user);
           command.Parameters.AddWithValue("@Password", pass);
           leer = command.ExecuteReader();
          
           return leer;
         
       }

     

    }
}