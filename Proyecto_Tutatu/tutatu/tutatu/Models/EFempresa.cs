using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tutatu.Models
{
    public class EFempresa
    {
        private tutatuUsa datos = new tutatuUsa();

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
    }
}