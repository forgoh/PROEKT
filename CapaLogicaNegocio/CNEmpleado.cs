using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data.SqlClient;

namespace CapaLogicaNegocio
{
   public class CNEmpleado
    {   //CREAR OBJETO CAPA DATOS DE EMPLEADO.. INSTANCIA
        private CDEmpleado ObjDatos = new CDEmpleado();

       //VARIABLES...ENCAPSULAMIENTO
        private String _Usuario;
        private String _Contraseña;

        //METODOS SET 
        public String Usuario
        {
            set {
                    if (value=="ЛОГИН" ) { _Usuario = "Введите логин!"; }
                    else  { _Usuario = value; }
                }

           get {
                    return _Usuario;   
               }
        }
        public String Contraseña
        {
            set {
                if (value == "ПАРОЛЬ" ) { _Contraseña = "Введите пароль!"; }
                else { _Contraseña = value; }
                }

            get { return _Contraseña; }
        }

        //FUNCIONES
        public SqlDataReader IniciarSesion()
        {
            SqlDataReader Loguear;
            Loguear=ObjDatos.iniciarSesion(_Usuario,_Contraseña);
            
            return Loguear;
        }

    }
}
