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
            SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.SingleResult);  //almacena el resultado de la consulta en el reader
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
            SqlDataReader reader = comando.ExecuteReader(System.Data.CommandBehavior.SingleResult);  //almacena el resultado de la consulta en el reader.
            int retorno = comando.ExecuteNonQuery();

            return retorno;
        }
    }
}