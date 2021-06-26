using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using TP2_Grupo4.Models;
using TP2_Grupo4.Helpers;
using System.Linq;

namespace TP2_Grupo4
{
    public class AgenciaManager
    {
        private Context contexto;
        private Agencia agencia;
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        private Usuario usuarioLogeado;
        public AgenciaManager()
        {
            this.agencia = new Agencia();
            this.usuarioLogeado = null;
            inicializarAtributos();
        }
        private void inicializarAtributos()
        {
            try
            {

                //creo un contexto
                contexto = new Context();

                //cargo los usuarios
                contexto.Usuarios.Load();
                contexto.Reservas.Load();
            }
            catch (Exception)
            {
            }
        }
        public Agencia GetAgencia()
        {
            return this.agencia;
        }
    }
}
