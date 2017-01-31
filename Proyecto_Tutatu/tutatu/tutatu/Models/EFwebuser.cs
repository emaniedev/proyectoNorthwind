using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using tutatu.Models;

namespace tutatu.Models
{
    public class EFwebuser
    {
        private tutatuUsa datos = new tutatuUsa();


        /// <summary>
        /// Crea un nuevo usuario de la web con todos los datos requeridos.
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="pass"></param>
        /// <param name="nom"></param>
        /// <param name="ape"></param>
        /// <param name="email"></param>
        /// <param name="bday"></param>
        /// <param name="sexo"></param>
        public void crearWebUser (string nick, string pass, string nom, string ape, string email, DateTime bday, string sexo)
    {
            usuarios nuevoUser = new usuarios();
            webuser nuevo = new webuser();
            DateTime hoy = DateTime.Now;
            nuevoUser.nickname = nick;
            nuevoUser.pass1 = pass;
            nuevoUser.pass2 = pass;
            nuevoUser.date_reg = hoy;
            nuevo.fname = nom;
            nuevo.sname = ape;
            nuevo.email = email;
            nuevo.b_date = bday;
            nuevo.sexo = sexo;
            nuevoUser.webuser.Add(nuevo);
            

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
        /// Autentica un usuario en la web. Devuelve un 1 si el usuario se ha logueado correctamente y 0 en caso contrario.
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="pass"></param>
        public short loguear (string nick, string pass, bool check)
        {
            
            usuarios omWebuserIn = new usuarios();
            usuarios omWebuserBD = new usuarios();

            omWebuserIn.nickname = nick;
            omWebuserIn.pass1 = pass;
            omWebuserBD.nickname = "";
            omWebuserBD.pass1 = "";
            try
            {
                omWebuserBD = (from usr in datos.usuarios where usr.nickname == nick && usr.pass1 == pass select usr).FirstOrDefault();

                if (omWebuserBD != null)
                {
                    if (omWebuserBD.pass1 == omWebuserIn.pass1)
                    {

                        
                        
                        
                        
                        

                    }
                    return omWebuserBD.id_u;
                }
                else
                {
                    return  -1;
                    throw new Exception("no se ha encontrado ninguna coincidencia.");
                }

            }
            catch (Exception e)
            {

                throw e;
            }
            

            
    }

        /// <summary>
        /// Autentica un usuario en la web. Devuelve un 1 si el usuario se ha logueado correctamente y 0 en caso contrario.
        /// </summary>
        /// <param name="nick"></param>
        /// <param name="pass"></param>
        public short loguear (string nick, string pass, bool check)
        {
            
            usuarios omWebuserIn = new usuarios();
            usuarios omWebuserBD = new usuarios();

            omWebuserIn.nickname = nick;
            omWebuserIn.pass1 = pass;
            omWebuserBD.nickname = "";
            omWebuserBD.pass1 = "";
            try
            {
                omWebuserBD = (from usr in datos.usuarios where usr.nickname == nick && usr.pass1 == pass select usr).FirstOrDefault();

                if (omWebuserBD != null)
                {
                    if (omWebuserBD.pass1 == omWebuserIn.pass1)
                    {

                        
                        
                        
                        
                        

                    }
                    return omWebuserBD.id_u;
                }
                else
                {
                    return  -1;
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
                string nameGreetings = (from usr in datos.webuser where usr.id_u == idu select usr.fname).FirstOrDefault();

                return nameGreetings;

            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public void desloguear()
        {
            
        }
}
  
}