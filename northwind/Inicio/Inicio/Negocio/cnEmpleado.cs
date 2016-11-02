using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inicio.Entidades;
using System.Data.SqlClient;
using System.Data;
using Inicio.Datos;
using System.Configuration;

namespace Inicio.Negocio
{
    public class cnEmpleado
    {
       // private string CadenaConexion = "Data Source=(LocalDB)\\v11.0;AttachDbFilename=|DataDirectory|\\Northwind.mdf;Integrated Security=True"; //escapar las barras 
       // private string CadenaConexion = "Data Source=.\\sqlexpress;Initial Catalog=Northwind;User ID=sa";
        string CadenaConexion = ConfigurationManager.ConnectionStrings["connCasa"].ConnectionString;
        string validacionEmpleado;

        public List<enEmpleados> listar(){
            List<enEmpleados> lenEmpleado = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try {
                    con.Open();
                    cdEmpleado cdEmpleado = new cdEmpleado();
                    lenEmpleado = cdEmpleado.Listar(con);
                    con.Close();
                }
                catch (SqlException sx)
                {
                    throw new Exception("Error en SqlException: cnEmpleados.listar \n" + sx.Message);
                }
                catch (Exception e) {
                    throw new Exception("Error PatataException: cnEmpleados.listar \n" + e.Message);
                }

            }

            return lenEmpleado;
        }

        public List<enEmpleados> listarFiltro(int tPag, int nPag, String ape, String nom)
        {
            List<enEmpleados> lenEmpleado = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    cdEmpleado cdEmpleado = new cdEmpleado();
                    lenEmpleado = cdEmpleado.ListarFiltro(con,tPag, nPag, ape, nom);
                    con.Close();
                }
                catch (SqlException sx)
                {
                    throw new Exception("Error en SqlException: cnEmpleados.listarFiltro \n" + sx.Message);
                }
                catch (Exception e)
                {
                    throw new Exception("Error PatataException: cnEmpleados.listarFiltro \n" + e.Message);
                }

            }
            return lenEmpleado;

        }

        //consEmpleadoPorId(id)
        public enEmpleados consEmpleadoPorId(int?id)
        {
            enEmpleados oenEmpleado = new enEmpleados();
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    cdEmpleado cdEmpleado = new cdEmpleado();
                    oenEmpleado = cdEmpleado.consEmpleadoPorId(con, id);
                    con.Close();
                }
                catch (SqlException sx)
                {
                    throw new Exception("Error en SqlException: cnEmpleados.consEmpleadosPorId \n" + sx.Message);
                }
                catch (Exception e)
                {
                    throw new Exception("Error PatataException: cnEmpleados.consEmpleadosPorId \n" + e.Message);
                }

            }

            return oenEmpleado;
        }
        //Editar

        public int edit(Inicio.Entidades.enEmpleados oenEmpleado)
        {
            int resultado = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
 
            {
                
                try
                {
                    con.Open();
                    cdEmpleado cdEmpleado = new cdEmpleado();
                    resultado = cdEmpleado.edit(con, oenEmpleado);
                    con.Close();
                }
                catch (SqlException sx)
                {
                    throw new Exception("Error en SqlException: cnEmpleados.edit \n" + sx.Message);
                }
                catch (Exception e)
                {
                    throw new Exception("Error PatataException: cnEmpleados.edit \n" + e.Message);
                }

            }

            return resultado;
        }


        public int nRegistrosFiltro(string ape, string nom)
        {
            int nRegistro = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    cdEmpleado cdEmpleado = new cdEmpleado();
                    nRegistro = cdEmpleado.nRegistrosFiltro(con, ape, nom);
                    con.Close();
                }
                catch (SqlException sx)
                {
                    throw new Exception("Error en SqlException: cnEmpleados.nRegistrosFiltro \n" + sx.Message);
                }
                catch (Exception e)
                {
                    throw new Exception("Error PatataException: cnEmpleados.nRegistrosFiltro \n" + e.Message);
                }

            }
            return nRegistro;

        }


        //Borrar

        public int borrarPorId(int? id)
        {
            enEmpleados oenEmpleado = new enEmpleados();
            int resultado = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    cdEmpleado cdEmpleado = new cdEmpleado();
                    resultado = cdEmpleado.borrarPorId(con, id);
                    con.Close();
                }
                catch (SqlException sx)
                {
                    throw new Exception("Error en SqlException: cnEmpleados.borrarPorId \n" + sx.Message);
                }
                catch (Exception e)
                {
                    throw new Exception("Error PatataException: cnEmpleados.borrarPorId \n" + e.Message);
                }

            }

            return resultado;
        }

        //Crear Empleado
        /// Metodo para insertar un registro en la tabla Empleado
        /// Me devuelve un int (-1=fallo y 1=Bien).
        /// Todos los métodos pueden generar una excepcion.
        /// En el objeto oenEmpleado que recibe, IdEmpleado=0 porque no se usa.
        public int altaEmpleado(enEmpleados oenEmpleado)
        {
            //  Validamos los datos para dar alta del empleado
            int resultado = -1;
            if (ValidarEmpleado(oenEmpleado))
            {
                // Modificamos los datos del empleado que me llega como parámetro.
                using (SqlConnection con = new SqlConnection(CadenaConexion))
                {
                    try
                    {
                        con.Open();
                        cdEmpleado ocdEmpleado = new cdEmpleado();
                        resultado = ocdEmpleado.altaEmpleado(con, oenEmpleado);
                        con.Close();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en SQLException cnEmpleado.altaEmpleado =" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error en cnEmpleado.altaEmpleado = " + ex.Message);
                    }
                } //con.close(); con.Dispose();
            }
            else
            {
                throw new Exception("Error en cnEmpleado.AltaEmplado => validación datos:" + validacionEmpleado);
            }
            return (resultado);
        }

        private bool ValidarEmpleado(enEmpleados oenEmpleado)
        {
            if (string.IsNullOrEmpty(oenEmpleado.Nombre)) validacionEmpleado += "El campo Nombre es obligatorio";
            if (string.IsNullOrEmpty(oenEmpleado.Apellido)) validacionEmpleado += "El campo Apellido es obligatorio";
            if (validacionEmpleado == null)
                return true;
            else
                return false;
        }



    }
}