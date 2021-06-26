using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TP2_Grupo4.Models
{
    public class Agencia
    {
           
        private Context contexto;
        public DbSet<Alojamiento> Alojamientos { get; set; }

        public Agencia()
        {
            inicializarAtributos();
        }
        private void inicializarAtributos()
        {
            try
            {

                //creo un contexto
                contexto = new Context();

                //cargo los usuarios
                contexto.Alojamientos.Load();
            }
            catch (Exception)
            {
            }
        }

    }
}
