using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace inicio.Models
{
    public class moEmpleadoEF
    {
        private conNorthwind db = new conNorthwind();
    //    List<Employees> listaEmpleados = omoEmpleadoEF.ListarFiltro(TamPagina, NumRegistro, Apellido, Nombre);
        public List<Employees> ListarFiltro(int TamPagina, int NumRegistro, String Apellido, String Nombre)
        {
            List<Employees> lenEmployees = new List<Employees>();
            lenEmployees = (from emp in db.Employees where emp.LastName.Contains(Apellido) && emp.FirstName.Contains(Nombre) select emp).OrderBy(e => e.EmployeeID).Skip(NumRegistro).Take(TamPagina).ToList();

     //       List<Employees> listaEmpleados = (from emp in db.Employees select emp).ToList();
            return lenEmployees;
        }

        //        omoEmpleado.ConsEmpleadoPorID(ID)
        public Employees ConsEmpleadoPorID(int? ID)  //ConsEmpleadoPorID(ID);
        {
            Employees oEmpleado = new Employees();
            oEmpleado = (from emp in db.Employees where emp.EmployeeID == ID select emp).FirstOrDefault();
            return oEmpleado;
        }


        public int NumRegistrosfiltro(String Apellido, String Nombre)
        {
            int NumRegistros = (from emp in db.Employees where emp.LastName.Contains(Apellido) && emp.FirstName.Contains(Nombre) select emp).Count();
            return NumRegistros;
        }

        //   omoEmpleado.Editar(oEmpleado);
        public void Editar(Employees oenEmpleado)
        {
            using (conNorthwind db = new conNorthwind())
            {
                try
                {
                    Employees editar = (from e in db.Employees where e.EmployeeID == oenEmpleado.EmployeeID select e).Single();
                    editar.LastName = oenEmpleado.LastName;
                    editar.FirstName = oenEmpleado.FirstName;
       //             db.Entry(editar).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception ex)      
                {
                    throw new Exception("Error en (moEmpleadoEF - Editar(oEmpleado))) = " + ex.Message);
                }
            }
        }
        //   omoEmpleado.AltaEmpleado(oEmpleado);
        public void AltaEmpleado(Employees oenEmpleado)
        {
            using (conNorthwind db = new conNorthwind())
            {
                try
                {
                    db.Employees.Add(oenEmpleado);
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en (moEmpleadoEF - AltaEmpleado(oEmpleado))) = " + ex.Message);
                }
            }
        }
        //      omoEmpleado.BajaEmpleado(ID);
        public void BajaEmpleado(int? ID)
        {
            using (conNorthwind db = new conNorthwind())
            {
                try
                {
                    Employees oEmpleado = (from e in db.Employees where e.EmployeeID == ID select e).Single();
                    db.Entry(oEmpleado).State = System.Data.Entity.EntityState.Deleted;
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error en (moEmpleadoEF - BajaEmpleado(int ID))) = " + ex.Message);
                }
            }
        }

    }
}