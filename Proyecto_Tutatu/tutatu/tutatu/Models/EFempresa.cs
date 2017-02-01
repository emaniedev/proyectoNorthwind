using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tutatu.Models
{
    public class EFempresa
    {
        private tutatuUsa datos = new tutatuUsa();


        /// <summary>
        /// Crea una empresa pasandole todos los campos
        /// </summary>
        /// <param name="nick">string</param>
        /// <param name="pass">string</param>
        /// <param name="nom">string</param>
        /// <param name="cif">string</param>
        /// <param name="addr">string can null</param>
        /// <param name="phon">int can null</param>
        /// <param name="own">string</param>
        /// <param name="email">string can null</param>
        /// <param name="web">string</param>
        /// <param name="services">string</param>
        /// <param name="trayec">string</param>
        public void crearEmpresa(string nick, string pass, string nom, string cif, string addr, string phon, string own, string email, string web, string services, string trayec)
        {
            usuarios nuevoUser = new usuarios();
            empresa nuevo = new empresa();
            DateTime hoy = DateTime.Now;
            nuevoUser.nickname = nick;
            nuevoUser.pass1 = pass;
            nuevoUser.pass2 = pass;
            nuevoUser.date_reg = hoy;
            nuevo.name = nom;
            nuevo.cif = cif;
            nuevo.address = addr;
            nuevo.phone = phon;
            nuevo.owner = own;
            nuevo.email = email;
            nuevo.web = web;
            nuevo.services = services;
            nuevo.trayectoria = trayec;
            nuevoUser.empresa.Add(nuevo);

            try
            {
                datos.usuarios.Add(nuevoUser);

                datos.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }



        }


        /// <summary>
        /// Autentica una empresa en la web. Devuelve un 1 si el usuario se ha logueado correctamente y 0 en caso contrario.
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="pass"></param>
        public short loguear(string nick, string pass, bool check)
        {

            
            usuarios omEmpresaBD = new usuarios();

            
            omEmpresaBD.nickname = "";
            omEmpresaBD.pass1 = "";
            try
            {
                omEmpresaBD = (from usr in datos.usuarios where usr.nickname == nick && usr.pass1 == pass select usr).FirstOrDefault();

                if (omEmpresaBD != null)
                {


                    return omEmpresaBD.id_u;

                }
                else
                {
                    return -1;
                    throw new Exception("no se ha encontrado ninguna coincidencia.");
                }

            }
            catch (Exception e)
            {

                throw e;
            }



        }



        public string saludo(short idu)
        {
            try
            {
                string nameGreetings = (from emp in datos.empresa where emp.id_u == idu select emp.name).FirstOrDefault();

                return nameGreetings;

            }
            catch (Exception e)
            {

                throw e;
            }

        }
    }
}