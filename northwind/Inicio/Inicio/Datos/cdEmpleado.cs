using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inicio.Entidades;
using System.Data.SqlClient;
using System.Data;

namespace Inicio.Datos
{
    public class cdEmpleado
    {
        public List<enEmpleados> Listar(SqlConnection con)
        {


            List<enEmpleados> lenEmpleado = null;

            SqlCommand comando = new SqlCommand("SELECT * FROM Employees",con);  //comando que almacena el string sql en la db que se pase por parametro
            SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.SingleResult);  //almacena el resultado de la consulta en el reader
            if (reader != null)
            {
                lenEmpleado = new List<enEmpleados>();
                while (reader.Read())
                {
                    enEmpleados oenEmpleado = ObtenerEmpleado(reader);
                    lenEmpleado.Add(oenEmpleado);
                }
            }
            return lenEmpleado;
        }

        public List<enEmpleados> ListarFiltro(SqlConnection con,int tPag, int nPag, String ape, String nom)
        {

            List<enEmpleados> lenEmpleado = null;
            string sql = "SELECT * FROM Employees WHERE LastName LIKE '%" + ape + "%' AND FirstName LIKE '%" + nom + "%'";
            sql += "ORDER BY EmployeeID OFFSET " + nPag + " ROWS FETCH NEXT " + tPag +" ROWS ONLY";
            SqlCommand comando = new SqlCommand(sql, con);  //comando que almacena el string sql en la db que se pase por parametro
            SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.SingleResult);  //almacena el resultado de la consulta en el reader
            if (reader != null)
            {
                lenEmpleado = new List<enEmpleados>();
                while (reader.Read())
                {
                    enEmpleados oenEmpleado = ObtenerEmpleado(reader);
                    lenEmpleado.Add(oenEmpleado);
                }
            }
            return lenEmpleado;
        }
        //ConsultaEmpleados por id
        //Metodo tipo para consultar por id
        public enEmpleados consEmpleadoPorId(SqlConnection con, int? id)
        {


            enEmpleados oenEmpleado = null;

            SqlCommand comando = new SqlCommand("SELECT * FROM Employees WHERE EmployeeID="+ id , con);  //comando que almacena el string sql en la db que se pase por parametro
            SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.SingleResult);  //almacena el resultado de la consulta en el reader
            if (reader.HasRows)
            {
                oenEmpleado = new enEmpleados();
                reader.Read();
                
                oenEmpleado = ObtenerEmpleado(reader);
            
                
            }
            return oenEmpleado;
        }

        //Mantenimiento
        //Editar 
        public int edit(SqlConnection con,enEmpleados oenEmpleado)
        {
            string sql = "UPDATE Employees SET LastName=@LastName, FirstName=@FirstName WHERE EmployeeID=" + oenEmpleado.IdEmpleado;
            SqlCommand comando = new SqlCommand(sql , con);  //comando que almacena el string sql en la db que se pase por parametro
            comando.Parameters.AddWithValue("@LastName", oenEmpleado.Apellido);
            comando.Parameters.AddWithValue("@FirstName", oenEmpleado.Nombre);
           // SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.SingleResult);  //almacena el resultado de la consulta en el reader
            int retorno = comando.ExecuteNonQuery();
           
            return retorno;
        }


        private enEmpleados ObtenerEmpleado(IDataReader reader)
        {
            enEmpleados oenEmpleado = new enEmpleados();
            oenEmpleado.IdEmpleado = (int) reader["EmployeeID"];
            oenEmpleado.Nombre = (string) reader["FirstName"];
            oenEmpleado.Apellido = (string) reader["LastName"];
            
            return oenEmpleado;
        }

        public int nRegistrosFiltro(SqlConnection con, String ape, String nom)
        {

            int nRegistros = 0;
            string sql = "SELECT COUNT(*) FROM Employees WHERE LastName LIKE '%" + ape + "%' AND FirstName LIKE '%" + nom + "%';";

            SqlCommand comando = new SqlCommand(sql, con);  //comando que almacena el string sql en la db que se pase por parametro
            nRegistros = (int) comando.ExecuteScalar();  //almacena el resultado de la consulta en el reader
            
            return nRegistros;
        }

        public int borrarPorId(SqlConnection con, int? id)
        {
            string sql = "DELETE FROM Employees WHERE EmployeeID=" + id;
            SqlCommand comando = new SqlCommand(sql, con);  //comando que almacena el string sql en la db que se pase por parametro.
            //SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.SingleResult);  //almacena el resultado de la consulta en el reader.
            int retorno = comando.ExecuteNonQuery();

            return retorno;
        }


        //Crear empleado
        ///  ocdEmpleado.AltaEmpleado(con, oenEmpleado);
        /// Metodo para insertar un registro en la tabla Alumno
        /// Me devuelve un int (-1=fallo y 1=Bien).
        /// Todos los métodos pueden generar una excepcion.
        /// En el objeto oAlumno que recibe, IdAlumno=0 porque no se usa.
        public int altaEmpleado(SqlConnection con, enEmpleados oenEmpleado)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "INSERT INTO Employees (LastName, FirstName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo, PhotoPath)";
            comando.CommandText += "VALUES(@LastName, @FirstName, @Title, @TitleOfCourtesy, @BirthDate, @HireDate, @Address, @City, @Region, @PostalCode, @Country, @HomePhone, @Extension, @Notes, @ReportsTo, @PhotoPath)";
            comando.Parameters.AddWithValue("@LastName", oenEmpleado.Apellido);
            comando.Parameters.AddWithValue("@FirstName", oenEmpleado.Nombre);
            comando.Parameters.AddWithValue("@Title", "");
            comando.Parameters.AddWithValue("@TitleOfCourtesy", "");
            comando.Parameters.AddWithValue("@BirthDate", Convert.ToDateTime("27/01/1966 0:00:00"));
            comando.Parameters.AddWithValue("@HireDate", Convert.ToDateTime("27/01/1966 0:00:00"));
            comando.Parameters.AddWithValue("@Address", "");
            comando.Parameters.AddWithValue("@City", "");
            comando.Parameters.AddWithValue("@Region", "");
            comando.Parameters.AddWithValue("@PostalCode", "");
            comando.Parameters.AddWithValue("@Country", "");
            comando.Parameters.AddWithValue("@HomePhone", "");
            comando.Parameters.AddWithValue("@Extension", "");
            //        comando.Parameters.AddWithValue("@Photo", Convert.ToByte("",0));
            comando.Parameters.AddWithValue("@Notes", "");
            comando.Parameters.AddWithValue("@ReportsTo", 2);
            comando.Parameters.AddWithValue("@PhotoPath", "");
            comando.Connection = con;
            int retorno = comando.ExecuteNonQuery();
            return retorno;
        }
    }
}