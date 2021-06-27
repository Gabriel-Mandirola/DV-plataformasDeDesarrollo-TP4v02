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
                this.Usuarios = contexto.Usuarios;
                this.Reservas = contexto.Reservas;
            }
            catch (Exception)
            {
            }
        }

        public bool AgregarReserva(DateTime fechaDesde, DateTime fechaHasta, int codigoAlojamiento, int dniUsuario, double precio)
        {
            Alojamiento alojamiento = this.GetAgencia().FindAlojamientoForCodigo(codigoAlojamiento);
            Usuario usuario = this.FindUserForDNI(dniUsuario);
            if (alojamiento == null || usuario == null) return false;

            // Timestamp = Id
            String timestamp = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            //this.reservas.Add(new Reserva(timestamp, fechaDesde,fechaHasta,alojamiento,usuario, precio));
            return true;
        }
        public bool ModificarReserva(String id, DateTime fechaDesde, DateTime fechaHasta, int codigoAlojamiento, int dniUsuario)
        {
            int indexReserva = this.findIndexReservaPorId(id);
            if (indexReserva == -1) return false;

            Alojamiento alojamiento = this.agencia.FindAlojamientoForCodigo(codigoAlojamiento);
            Usuario usuario = this.FindUserForDNI(dniUsuario);
            if (alojamiento == null || usuario == null) return false;

            this.reservas[indexReserva].SetFechaDesde(fechaDesde);
            this.reservas[indexReserva].SetFechaHasta(fechaHasta);
            this.reservas[indexReserva].SetAlojamiento(alojamiento);
            this.reservas[indexReserva].SetUsuario(usuario);
            this.reservas[indexReserva].SetPrecio(alojamiento.PrecioTotalDelAlojamiento());
            return true;
        }
        public bool EliminarReserva(String id)
        {
            int indexReserva = this.findIndexReservaPorId(id);
            if (indexReserva == -1) return false;

            this.reservas.RemoveAt(indexReserva);
            return true;
        }

        #region USUARIO
        public bool IsUsuarioBloqueado(int dni)
        {
            Usuario user = this.Usuarios.ToList().Find(user => user.Dni == dni && user.Bloqueado == true);
            return user == null ? false : true;
        }

        public Usuario FindUserForDNI(int dni)
        {
            return this.Usuarios.ToList().Find(user => user.Dni == dni);
        }
        public bool autenticarUsuario(int dni, String password)
        {
            Usuario usuarioEncontrado = this.FindUserForDNI(dni);
            if (usuarioEncontrado == null) return false; // DNI no encontrado
            if (usuarioEncontrado.Password != Utils.Encriptar(password)) return false; // Contraseña incorrecta          
            this.usuarioLogeado = usuarioEncontrado;
            return true;
        }
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
                    Password = Utils.Encriptar(password),
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
        public bool ModificarUsuario(int dni, String nombre, String email, String password = "")
        {
            try
            {
                var usuario = this.Usuarios.ToList().Find(u => u.Dni == dni);
                usuario.Nombre = nombre;
                usuario.Email = email;
                usuario.Password = Utils.Encriptar(password);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarUsuario(int dni)
        {
            try
            {
                var usuario = this.Usuarios.ToList().Find(u => u.Dni == dni);
                contexto.Usuarios.Remove(usuario);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool BloquearUsuario(int dni)
        {
            Usuario usuario = this.Usuarios.AsNoTracking().ToList().Find(u => u.Dni == dni);
            if (usuario == null) return false;
            usuario.Bloqueado = true;
            return true;
        }

        #endregion

        #region INFO PARA LAS VISTAS
        public List<String> OpcionesDelSelectDeTiposDeAlojamientos()
        {
            return new List<String>() { "todos", "hotel", "cabaña" };
        }
        public List<String> OpcionesDelSelectDePersonas()
        {
            List<String> opciones = new List<String>() { "todas" };
            for (int i = 1; i <= Agencia.MAXIMA_CANTIDAD_DE_PERSONAS_POR_ALOJAMIENTO; i++)
                opciones.Add(i.ToString());
            return opciones;
        }
        public List<String> OpcionesDelSelectDeEstrellas()
        {
            List<String> opciones = new List<String>() { "todas" };
            for (int i = Agencia.MINIMA_CANTIDAD_DE_ESTRELLAS; i <= Agencia.MAXIMA_CANTIDAD_DE_ESTRELLAS; i++)
                opciones.Add(i.ToString());
            return opciones;
        }
        public List<String> OpcionesDelSelectDeBarrios()
        {
            List<String> tipos = new List<string>() { "todos" };
            foreach (Alojamiento al in this.agencia.Alojamientos)
                tipos.Add(al.Barrio);
            return tipos.Distinct().ToList();
        }
        public List<String> OpcionesDelSelectDeCiudades()
        {
            List<String> tipos = new List<string>() { "todas" };
            foreach (Alojamiento al in this.agencia.Alojamientos)
                tipos.Add(al.Ciudad);
            return tipos.Distinct().ToList();
        }
        public List<String> OpcionesDelSelectParaElOrdenamiento()
        {
            return new List<String>() { "fecha de creacion", "personas", "estrellas" };
        }
        #endregion

        #region FILTRAR
        public List<List<String>> FiltrarAlojamientos(
            String tipoAlojamiento, 
            String ciudad, 
            String barrio, 
            double precioMin, 
            double precioMax, 
            String estrellas, 
            String personas)
        {
            List<List<String>> alojamientosFiltrados = new List<List<string>>();
            switch (tipoAlojamiento)
            {
                case "todos":
                    alojamientosFiltrados = this.agencia.AlojamientosToLista();
                    break;
                case "hotel":
                    //alojamientosFiltrados = this.agencia.GetHoteles();
                    break;
                case "cabaña":
                    //alojamientosFiltrados = this.agencia.GetCabanias();
                    break;
            }
            
            var alojamientos = from alojamiento in this.contexto.Alojamientos
                               where alojamiento.Tipo == tipoAlojamiento
                               select alojamiento;
            if (ciudad != "todas")
                alojamientos = from alojamiento in this.contexto.Alojamientos
                           where alojamiento.Ciudad == ciudad
                               select alojamiento;

            if(barrio!= "todos")
                alojamientos = alojamientos.Where(a => a.Barrio == barrio);
            if(estrellas != "todas")
                alojamientos = alojamientos.Where(a => a.Estrellas == int.Parse(estrellas));
            if(personas != "todas")
                alojamientos = alojamientos.Where(a => a.CantidadDePersonas == int.Parse(personas));
            if (precioMin - precioMax != 0)
            {
                var alojamientos = from alojamiento in this.contexto.Alojamientos
                                        where alojamiento.Id >= 5
                                        orderby alojamiento.Id
                                        select alojamiento;
            }

            //if (ciudad != "todas")
            //{
            //    alojamientosFiltrados = alojamientosFiltrados.GetAlojamientosPorCiudad(ciudad);
            //    if (alojamientosFiltrados == null) return null;

            //}

            //if (barrio != "todos")
            //{
            //    alojamientosFiltrados = alojamientosFiltrados.GetAlojamientosPorBarrio(barrio);
            //    if (alojamientosFiltrados == null) return null;
            //}

            //if (precioMin - precioMax != 0)
            //{
            //    alojamientosFiltrados = alojamientosFiltrados.GetAllAlojamientos(precioMin, precioMax);
            //    if (alojamientosFiltrados == null) return null;
            //}
            //if (estrellas != "todas")
            //{
            //    alojamientosFiltrados = alojamientosFiltrados.GetAllAlojamientos(int.Parse(estrellas));
            //    if (alojamientosFiltrados == null) return null;
            //}

            //if (personas != "todas")
            //{
            //    alojamientosFiltrados = alojamientosFiltrados.GetAlojamientosPorCantidadDePersonas(int.Parse(personas));
            //    if (alojamientosFiltrados == null) return null;
            //}
            return alojamientosFiltrados;
        }
        public List<Reserva> GetAllReservasForUsuario(int dni)
        {
            return this.Reservas.FindAll(reserva => reserva.GetUsuario().GetDni() == dni);
        }
        #endregion

        /* GETTERS */
        public Agencia GetAgencia(){ return this.agencia; }
        public Usuario GetUsuarioLogeado() { return this.usuarioLogeado; }
    }
}
