using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using inicio.EntidadesNegocio;
using System.Data.SqlClient;
using System.Data;
using inicio.CapaDatos;
// Esta libreria me da 
using System.Configuration;

namespace inicio.CapaNegocio
{
    public class cnEmpleado
    {
        //    String CadenaConexion = "Data Source =.\\sqlexpress;Initial Catalog = northwind; User ID = paco";
        //    String CadenaConexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\Northwind.mdf;Integrated Security=True";
        String CadenaConexion = ConfigurationManager.ConnectionStrings["conNWlocal"].ConnectionString;
        String ValidacionEmpleado;
        public List<enEmpleado> Listar()
        { 
            List<enEmpleado> lenEmpleado = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                { 
                    con.Open();
                    cdEmpleado ocdEmpleado = new cdEmpleado();
                    lenEmpleado = ocdEmpleado.Listar(con);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error en SQLException (cnEmpleado - Listar()) = " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en (cnEmpleado - Listar()) = " + ex.Message);
                }
            }
            return lenEmpleado;
        }
        //  ListaFiltro(TamPagina, NumRegistro, Apellido, Nombre);
        public List<enEmpleado> ListaFiltro(int TamPagina, int NumRegistro, String Ape, String Nom)
        {
            List<enEmpleado> lenEmpleado = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    cdEmpleado ocdEmpleado = new cdEmpleado();
                    lenEmpleado = ocdEmpleado.ListaFiltro(con, TamPagina, NumRegistro, Ape, Nom);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error en SQLException (cnEmpleado - ListaFiltro()) = " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en (cnEmpleado - ListaFiltro()) = " + ex.Message);
                }
            }
            return lenEmpleado;
        }
        // ConsEmpleadoPorID(ID);
        public enEmpleado ConsEmpleadoPorID(int? ID)
        {
            enEmpleado oenEmpleado = null;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    cdEmpleado ocdEmpleado = new cdEmpleado();
                    oenEmpleado = ocdEmpleado.ConsEmpleadoPorID(con, ID);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error en SQLException (cnEmpleado - ConsEmpleadoPorID()) = " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en (cnEmpleado - ConsEmpleadoPorID()) = " + ex.Message);
                }
            }
            return oenEmpleado;
        }
        //  Editar(oenEmpleado);
        public int Editar(enEmpleado oenEmpleado)
        {
            int resultado = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    cdEmpleado ocdEmpleado = new cdEmpleado();
                    resultado = ocdEmpleado.Editar(con, oenEmpleado);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error en SQLException (cnEmpleado - Editar(con, oenEmpleado)) = " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en (cnEmpleado - Editar(con, oenEmpleado)) = " + ex.Message);
                }
            }
            return resultado;
        }
        //  NumRegistrosFiltro(Apellido, Nombre);
        public int NumRegistrosFiltro(String Ape, String Nom)
        {
            int NumReg = 0;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    cdEmpleado ocdEmpleado = new cdEmpleado();
                    NumReg = ocdEmpleado.NumRegistrosFiltro(con, Ape, Nom);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error en SQLException (cnEmpleado - ListaFiltro()) = " + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en (cnEmpleado - ListaFiltro()) = " + ex.Message);
                }
            }
            return NumReg;
        }
        //   ocnEmpleado.BajaEmpleado(ID);
        public int BajaEmpleado(int? ID)
        {
            int resultado = -1;
            using (SqlConnection con = new SqlConnection(CadenaConexion))
            {
                try
                {
                    con.Open();
                    cdEmpleado ocdEmpleado = new cdEmpleado();
                    resultado = ocdEmpleado.BajaEmpleado(con, ID);
                    con.Close();
                }
                catch (SqlException ex)
                {
                    throw new Exception("Error en SQLException (cnEmpleado - BajaEmpleado(int? ID)) =" + ex.Message);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en cnEmpleado.BajaEmpleado(int? ID) = " + ex.Message);
                }
            } //con.close(); con.Dispose();
            return (resultado);
        }
        //   ocnEmpleado.AltaEmpleado(oenEmpleado);
        /// Metodo para insertar un registro en la tabla Empleado
        /// Me devuelve un int (-1=fallo y 1=Bien).
        /// Todos los métodos pueden generar una excepcion.
        /// En el objeto oenEmpleado que recibe, IdEmpleado=0 porque no se usa.
        public int AltaEmpleado(enEmpleado oenEmpleado)
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
                        resultado = ocdEmpleado.AltaEmpleado(con, oenEmpleado);
                        con.Close();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception("Error en SQLException (cnEmpleado - AltaEmpleado(enEmpleado oenEmpleado)) =" + ex.Message);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error en cnEmpleado.AltaEmpleado(enEmpleado oenEmpleado) = " + ex.Message);
                    }
                } //con.close(); con.Dispose();
            }
            else
            {
                throw new Exception("Error en cnEmpleado.AltaEmplado(enEmpleado oenEmpleado) -> validación datos:" + ValidacionEmpleado);
            }
            return (resultado);
        }

        private bool ValidarEmpleado(enEmpleado oenEmpleado)
        {
            if (string.IsNullOrEmpty(oenEmpleado.Nombre)) ValidacionEmpleado += "El campo Nombre es obligatorio";
            if (string.IsNullOrEmpty(oenEmpleado.Apellido)) ValidacionEmpleado += "El campo Apellido es obligatorio";
            if (ValidacionEmpleado == null)
                return true;
            else
                return false;
        }
    }
}