using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using tutatu.Models;

namespace tutatu.Models
{
    public class EFwebuser
    {
        private tutatuEF datos = new tutatuEF();


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
        public int loguear (string nick, string pass)
        {
            int logued = 0;
            usuarios omWebuserIn = new usuarios();
            usuarios omWebuserBD = new usuarios();

            omWebuserIn.nickname = nick;
            omWebuserIn.pass1 = pass;

            try
            {
                omWebuserBD = (from usr in datos.usuarios where usr.nickname == nick select usr).Single();

                if (omWebuserBD.pass1 == omWebuserIn.pass1)
                {
                    logued = 1;   
                }
            }
            catch (Exception)
            {

                throw;
            }

            return logued;

        }
}
  
}