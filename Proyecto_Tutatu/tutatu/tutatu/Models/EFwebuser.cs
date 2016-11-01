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

}
  
}