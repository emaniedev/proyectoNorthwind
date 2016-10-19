using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Inicio.Models;

namespace Inicio.Models
{
    public class modelEmpleadoEF
    {
        private modelNorthwindEF db = new modelNorthwindEF() ;

        public List<Employees> listarFiltro(int tamPagina, int numRegistro, string apellido, string nombre)
        {
            List<Employees> listaEmpleados = (from emp in db.Employees where emp.LastName.Contains(apellido) && emp.FirstName.Contains(nombre) select emp).OrderBy(e => e.EmployeeID).Skip(numRegistro).Take(tamPagina).ToList();


            return listaEmpleados;
            
        }

        public int nRegistroslistarFiltro(string apellido, string nombre)
        {
            List<Employees> listaEmpleados = (from emp in db.Employees where emp.LastName.Contains(apellido) && emp.FirstName.Contains(nombre) select emp).ToList();


            return listaEmpleados.Count();

        }

        public Employees consEmpleadoPorId(int? id)
        {
            Employees employee = (from emp in db.Employees where emp.EmployeeID==id select emp).Single();

            return employee;
        }

        public int edit (Employees employee)
        {
            int resultado;
            try {
                //Utilizamos un objeto del contexto de la bd.
                Employees emple = (from emp in db.Employees where emp.EmployeeID == employee.EmployeeID select emp).Single();
                //Cambiamos los atributos del objeto.
                emple.EmployeeID = employee.EmployeeID;
                emple.FirstName = employee.FirstName;
                emple.LastName = employee.LastName;
                //Hacemos que el contexto se salve en al bd.
                db.SaveChanges();
                resultado = 1;
            } catch (Exception e)
            {
                resultado = 0;
                throw new Exception();

            }
            return resultado;
        }

        public int delete (Employees employee)
        {
            int resultado;
            try
            {
                Employees emple = (from emp in db.Employees where emp.EmployeeID == employee.EmployeeID select emp).Single();
                db.Employees.Remove(emple);
                resultado = 1;
            }
            catch (Exception e)
            {
                resultado = 0;
                throw new Exception();

            }
            return resultado;
        }
    }
}