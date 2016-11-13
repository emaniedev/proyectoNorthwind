using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tutatu.Models
{
    public class EFnoticia
    {
        private tutatuEF datos = new tutatuEF();

        public void crearNoticia (string asunto, int zona, string contenido, short id)
        {
            

            usuarios nuevoUser = (from usr in datos.usuarios where usr.id_u == id select usr).SingleOrDefault();
            noticia nuevo = new noticia();         
            DateTime hoy = DateTime.Now;
           
            nuevo.asunto = asunto;
            nuevo.zone_id = (short) zona;
            nuevo.content = contenido;
            nuevo.date = hoy;
            nuevo.id_u = id;
            
           
            

            try
            {

                nuevoUser.noticia.Add(nuevo);

                datos.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Se ha producido un error al crear la noticia");
            }
        }

    }
}