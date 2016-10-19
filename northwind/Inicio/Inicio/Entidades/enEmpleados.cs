using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inicio.Entidades
{
    public class enEmpleados
    {
        public int? idEmpleado;
        public string apellido;
        public string nombre;
        //preguntar a paco si los get/set definen la variable o no

        public int? IdEmpleado
        {
            get { return idEmpleado; }
            set { idEmpleado = value; }
        }

        public string Apellido
        {
            get { return apellido; }
            set { apellido = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
    }
}