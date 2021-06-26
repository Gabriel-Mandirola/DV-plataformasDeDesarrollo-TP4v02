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

        public bool IsUsuarioBloqueado(int dni)
        {
            Usuario user = this.Usuarios.Where(user => user.Dni == dni && user.Bloqueado == true).First();
            return user == null ? false : true;
        }

        public Usuario FindUserForDNI(int dni)
        {
            try {
            return this.Usuarios.ToList().Find(user => user.Dni == dni);

            }
            catch { 
            return null;
            }
           
        }

        public bool autenticarUsuario(int dni, String password)
        {
            Usuario usuarioEncontrado = this.FindUserForDNI(dni);
            if (usuarioEncontrado == null) return false; // DNI no encontrado
            if (usuarioEncontrado.Password != Utils.Encriptar(password)) return false; // Contraseña incorrecta          
            this.usuarioLogeado = usuarioEncontrado;
            return true;
        }

        public Usuario GetUsuarioLogeado() { return this.usuarioLogeado; }

        public bool ExisteEmail(string email)
        {
            try
            {
                return this.Usuarios.Where(user => user.Email == email).First() != null;
            } catch
            {
                return false;
            }
            

        }

        public bool AgregarUsuario(int dni, String nombre, String email, String password, bool isAdmin, bool bloqueado)
        {
            try
            {
                Usuario nuevo = new Usuario {
                    Dni = dni,
                    Nombre = nombre,
                    Email = email,
                    Password = password,
                    IsAdmin = isAdmin,
                    Bloqueado = bloqueado
                };
                contexto.Usuarios.Add(nuevo);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
