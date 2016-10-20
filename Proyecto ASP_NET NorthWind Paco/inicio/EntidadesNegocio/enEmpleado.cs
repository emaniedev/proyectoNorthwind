using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inicio.EntidadesNegocio
{
    public class enEmpleado
    {
        private int? idEmpleado;
        private string apellido;
        private string nombre;
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
        //   Esta es la forma abreviada de definir clases y propiedades
        /* public class enEmpleado
           {
              public int? enEmpleados.IdEmpleado { get; set; }
              public string enEmpleados.Apellido { get; set; }
              public string enEmpleados.Nombre { get; set; }

            }  */
    }
}