using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using inicio.EntidadesNegocio;
using System.Data.SqlClient;
using System.Data;


namespace inicio.CapaDatos
{
    public class cdEmpleado
    {   //  ListaFiltro(con, Ape,Nom)
        //  ListaFiltro(con, TamPagina, NumRegistro, Ape, Nom);
        public List<enEmpleado> ListaFiltro(SqlConnection con, int TamPagina, int NumRegistro, String Ape, String Nom)
        {
            List<enEmpleado> lenEmpleado = null;
            String sql = "SELECT * FROM Employees WHERE LastName like '%" + Ape + "%' AND FirstName like '%" + Nom + "%'";
            sql += " ORDER BY EmployeeID OFFSET " + NumRegistro + " ROWS FETCH NEXT " + TamPagina + " ROWS ONLY";
            SqlCommand comando = new SqlCommand(sql, con);
            SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleResult);
            if (reader != null)
            {
                lenEmpleado = new List<enEmpleado>();
                while (reader.Read())
                {
                    enEmpleado oenEmpleado = ObtenerEmpleado(reader);
                    lenEmpleado.Add(oenEmpleado);
                }
            }
            return lenEmpleado;
        }
        public List<enEmpleado> Listar(SqlConnection con)
        {
            List<enEmpleado> lenEmpleado = null;
            SqlCommand comando = new SqlCommand("SELECT * FROM Employees", con);
            SqlDataReader reader = comando.ExecuteReader(CommandBehavior.SingleResult);
            if (reader != null)
            {
                lenEmpleado = new List<enEmpleado>();
                while (reader.Read())
                {
                    enEmpleado oenEmpleado = ObtenerEmpleado(reader);
                    lenEmpleado.Add(oenEmpleado);
                }
            }
            return lenEmpleado;
        }
        //  ConsEmpleadoPorID(con, ID);
        public enEmpleado ConsEmpleadoPorID(SqlConnection con, int? ID)
        {
            enEmpleado oenEmpleado = null;
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Employees WHERE EmployeeID = " + ID;
            comando.Connection = con;
            SqlDataReader reader = comando.ExecuteReader();
            if (reader.HasRows)
            {
                oenEmpleado = new enEmpleado();
                reader.Read();
                oenEmpleado = ObtenerEmpleado(reader);
            }
            return oenEmpleado;
        }
        // Editar(con, oenEmpleado)
        public int Editar(SqlConnection con, enEmpleado oenEmpleado)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "UPDATE Employees SET LastName=@LastName, FirstName=@FirstName WHERE EmployeeID =" + oenEmpleado.IdEmpleado;
            comando.Parameters.AddWithValue("@LastName", oenEmpleado.Apellido);
            comando.Parameters.AddWithValue("@FirstName", oenEmpleado.Nombre);
            comando.Connection = con;
            int retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        //   NumRegistrosFiltro(con, Ape, Nom);
        public int NumRegistrosFiltro(SqlConnection con, String Ape, String Nom)
        {
            int NumReg = 0;
            String sql = "SELECT count(*) FROM Employees WHERE LastName like '%" + Ape + "%' AND FirstName like '%" + Nom + "%'";
            SqlCommand comando = new SqlCommand(sql, con);
            NumReg = Convert.ToInt32(comando.ExecuteScalar());
            return NumReg;
        }
        //   ocdEmpleado.BajaEmpleado(con, ID);
        public int BajaEmpleado(SqlConnection con, int? IdEmpleado)
        {     /// En el parámetro me llega el Id del registro a dar de baja
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "DELETE FROM Employees WHERE EmployeeID = " + IdEmpleado;
            comando.Connection = con;
            int retorno = comando.ExecuteNonQuery();
            return retorno;
        }
        //   ocdEmpleado.AltaEmpleado(con, oenEmpleado);
        /// Metodo para insertar un registro en la tabla Alumno
        /// Me devuelve un int (-1=fallo y 1=Bien).
        /// Todos los métodos pueden generar una excepcion.
        /// En el objeto oAlumno que recibe, IdAlumno=0 porque no se usa.
        public int AltaEmpleado(SqlConnection con, enEmpleado oenEmpleado)
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
        private enEmpleado ObtenerEmpleado(IDataReader reader)
        {
            enEmpleado oenEmpleado = new enEmpleado();
            oenEmpleado.IdEmpleado = Convert.ToInt16(reader["EmployeeID"]);
            oenEmpleado.IdEmpleado = (int)reader["EmployeeID"];
            oenEmpleado.Nombre = (reader["FirstName"]).ToString();
            oenEmpleado.Apellido = (string)reader["LastName"];
            return oenEmpleado;
        }
    }
}