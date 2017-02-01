using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tutatu.Models
{
    public class EFusuarios
    {
        private tutatuUsa datos = new tutatuUsa();
         
        public List<usuarios> listaUsuarios()
        {
            List<usuarios> lomUsuarios;

            lomUsuarios = (from usr in datos.usuarios select usr).ToList();


            return lomUsuarios;
        }



        

    }
}