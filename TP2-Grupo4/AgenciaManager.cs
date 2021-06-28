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
        public DbSet<Alojamiento> Alojamientos { get; set; }

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
                this.Usuarios = contexto.Usuarios;

                contexto.Reservas.Load();
                this.Reservas = contexto.Reservas;

                contexto.Alojamientos.Load();
                this.Alojamientos = contexto.Alojamientos;
            }
            catch (Exception)
            {
            }
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
            }
            catch
            {
                return false;
            }
        }
        public bool AgregarUsuario(int dni, String nombre, String email, String password, bool isAdmin, bool bloqueado)
        {
            try
            {
                Usuario nuevo = new Usuario
                {
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


        public void CerrarSession()
        {
            this.usuarioLogeado = null;
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

        public List<List<String>> BuscarDeAlojamientosPorCiudadYFechas(String ciudad, DateTime fechaDesde, DateTime fechaHasta)
        {
            List<List<String>> alojamientos = new List<List<string>>();
            List<Alojamiento> alojamientosFiltrados = new List<Alojamiento>();

            foreach (var alojamiento in this.GetAgencia().Alojamientos.ToList().FindAll(al => al.Ciudad.Contains(ciudad)))
            {
                if (this.ElAlojamientoEstaDisponible(alojamiento.Codigo, fechaDesde, fechaHasta))
                    alojamientosFiltrados.Add(alojamiento);
            }

            foreach (Alojamiento alojamiento in alojamientosFiltrados)
            {
                alojamientos.Add(new List<string>()
                {
                    alojamiento.Codigo.ToString(),
                    alojamiento.Tipo is "Hotel" ? "hotel" : "cabaña",
                    alojamiento.Ciudad,
                    alojamiento.Barrio,
                    alojamiento.Estrellas.ToString(),
                    alojamiento.CantidadDePersonas.ToString(),
                    alojamiento.Tv.ToString(),
                    alojamiento.Tipo is "Hotel" ? (alojamiento).PrecioPorPersona.ToString() : (alojamiento).PrecioPorDia.ToString()
                });
            }

            return alojamientos;
        }
        #endregion

        #region FILTRAR
        public List<List<String>> FiltrarAlojamientos(String tipoAlojamiento, String ciudad, String barrio, double precioMin, double precioMax, String estrellas, String personas)
        {
            List<List<String>> alojamientosFiltrados = new List<List<string>>();

            var alojamientos = from alojamiento in this.contexto.Alojamientos
                               select alojamiento;

            if (tipoAlojamiento != "todos")
                alojamientos = alojamientos.Where(a => a.Tipo == tipoAlojamiento);
            /*alojamientos = from alojamiento in this.contexto.Alojamientos 
                           where alojamiento.Tipo == tipoAlojamiento 
                           select alojamiento;*/

            if (ciudad != "todas")
                alojamientos = alojamientos.Where(a => a.Ciudad == ciudad);
            /*alojamientos = from alojamiento in this.contexto.Alojamientos
                       where alojamiento.Ciudad == ciudad
                           select alojamiento;*/

            if (barrio != "todos")
                alojamientos = alojamientos.Where(a => a.Barrio == barrio);
            /*alojamientos = from alojamiento in this.contexto.Alojamientos
                           where alojamiento.Barrio == barrio
                           select alojamiento;*/

            if (estrellas != "todas")
                alojamientos = alojamientos.Where(a => a.Estrellas == int.Parse(estrellas));
            /*alojamientos = from alojamiento in this.contexto.Alojamientos
                           where alojamiento.Estrellas == int.Parse(estrellas)
                           select alojamiento;*/

            if (personas != "todas")
                alojamientos = alojamientos.Where(a => a.CantidadDePersonas == int.Parse(personas));
            /*alojamientos = from alojamiento in this.contexto.Alojamientos
                           where alojamiento.CantidadDePersonas == int.Parse(personas)
                           select alojamiento;*/

            if (precioMin - precioMax != 0)
                alojamientos = alojamientos.Where(a => (a.Banios == 0 && precioMin < a.PrecioPorPersona && precioMax > a.PrecioPorPersona) ||
                (a.Banios != 0 && precioMin < a.PrecioPorDia && precioMax > a.PrecioPorDia));
            /*alojamientos = from alojamiento in this.contexto.Alojamientos
                            where 
                            // HOTEL
                            (alojamiento.Banios == 0 && precioMin < alojamiento.PrecioPorPersona && precioMax > alojamiento.PrecioPorPersona) ||
                            // CABAÑA
                            (alojamiento.Banios != 0 && precioMin < alojamiento.PrecioPorDia && precioMax > alojamiento.PrecioPorDia)
                            select alojamiento;*/

            foreach (var al in alojamientos)
            {
                alojamientosFiltrados.Add(new List<string>()
                {
                    al.Codigo,
                    al.Tipo,
                    al.Ciudad,
                    al.Barrio,
                    al.Estrellas.ToString(),
                    al.CantidadDePersonas.ToString(),
                    al.Tv ? "si" : "no",
                    al.Tipo == "hotel" ? al.PrecioPorPersona.ToString() : al.PrecioPorDia.ToString()
                });
            }

            return alojamientosFiltrados;
        }
        #endregion



        #region Reservas
        public bool AgregarReserva(DateTime fechaDesde, DateTime fechaHasta, String codigoAlojamiento, int dniUsuario, double precio)
        {
            var alojamiento = this.contexto.Alojamientos.Where(a => a.Codigo.Equals(codigoAlojamiento)).FirstOrDefault();
            var usuario = this.Usuarios.Where(u => u.Dni == dniUsuario).FirstOrDefault();
            try
            {
                var reservas = new Reserva
                {
                    FechaDesde = fechaDesde,
                    FechaHasta = fechaHasta,
                    Alojamiento = alojamiento,
                    Usuario = usuario,
                    Precio = precio
                };

                this.Reservas.Add(reservas);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ModificarReserva(String id, DateTime fechaDesde, DateTime fechaHasta, int precio, Alojamiento alojamiento_id, Usuario usuario_id)
        {
            try
            {
                bool salida = false;
                foreach (Reserva r in contexto.Reservas)
                    if (r.Id == int.Parse(id))
                    {
                        r.FechaDesde = fechaDesde;
                        r.FechaHasta = fechaHasta;
                        r.Precio = precio;
                        r.Alojamiento = alojamiento_id;
                        r.Usuario = usuario_id;
                        salida = true;
                    }
                if (salida)
                    contexto.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarReserva(String id)
        {
            try
            {
                bool salida = false;
                foreach (Reserva r in contexto.Reservas)
                    if (r.Id == int.Parse(id))
                    {
                        contexto.Reservas.Remove(r);
                        salida = true;
                    }
                if (salida)
                    contexto.SaveChanges();
                return salida;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EliminarReserva(int id)
        {
            try
            {
                var reserva = this.Reservas.FirstOrDefault(r => r.Id == id);
                contexto.Reservas.Remove(reserva);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Reserva> GetAllReservasForUsuario(int dni)
        {
            return this.Reservas.ToList().FindAll(reserva => reserva.Usuario.Dni == dni);
        }
        private List<Reserva> getAllReservasForAlojamiento(int codigo)
        {
            return this.Reservas.Where(reserva => reserva.Alojamiento.Codigo == codigo.ToString()).ToList();
        }
        public bool ElAlojamientoEstaDisponible(int codigoDeAlojamiento, DateTime fechaDesde, DateTime fechaHasta)
        {
            bool alojamientoDisponible = true;
            foreach (Reserva reserva in this.getAllReservasForAlojamiento(codigoDeAlojamiento))
            {
                bool validarFechaDesde = DateTime.Compare(reserva.FechaDesde, fechaDesde) == 1 && DateTime.Compare(reserva.FechaDesde, fechaHasta) == 1;
                bool validarFechaHasta = DateTime.Compare(reserva.FechaHasta, fechaDesde) == -1 && DateTime.Compare(reserva.FechaHasta, fechaDesde) == -1;
                if (!validarFechaDesde && !validarFechaHasta)
                    alojamientoDisponible = false;
            }
            return alojamientoDisponible;
        }

        public List<List<String>> DatosDeReservasParaLasVistas(String tipoDeUsuario)
        {
            List<List<String>> reservas = new List<List<String>>();

            if (tipoDeUsuario == "admin")
            {
                foreach (Reserva reserva in this.Reservas)
                {
                    reservas.Add(new List<String>(){
                        reserva.Id.ToString(),
                        reserva.FechaDesde.ToString(),
                        reserva.FechaHasta.ToString(),
                        reserva.Alojamiento.Codigo.ToString(),
                        reserva.Usuario.Dni.ToString(),
                        reserva.Precio.ToString(),
                    });
                }
            }
            else if (tipoDeUsuario == "user")
            {
                // Reservas del usuario
                List<Reserva> reservasDelUsuario = this.GetAllReservasForUsuario(this.usuarioLogeado.Dni);

                foreach (Reserva reserva in reservasDelUsuario)
                {
                    reservas.Add(new List<String>(){
                        reserva.Alojamiento.Tipo is "hotel" ? "hotel" : "cabaña",
                        reserva.FechaDesde.ToString(),
                        reserva.FechaHasta.ToString(),
                        reserva.Precio.ToString(),
                    });
                }
            }
            return reservas;
        }

        public bool ElAlojamientoEstaDisponible(String codigoDeAlojamiento, DateTime fechaDesde, DateTime fechaHasta)
        {
            bool alojamientoDisponible = true;
            foreach (Reserva reserva in this.getAllReservasForAlojamiento(codigoDeAlojamiento))
            {
                bool validarFechaDesde = DateTime.Compare(reserva.FechaDesde, fechaDesde) == 1 && DateTime.Compare(reserva.FechaDesde, fechaHasta) == 1;
                bool validarFechaHasta = DateTime.Compare(reserva.FechaHasta, fechaDesde) == -1 && DateTime.Compare(reserva.FechaHasta, fechaDesde) == -1;
                if (!validarFechaDesde && !validarFechaHasta)
                    alojamientoDisponible = false;
            }
            return alojamientoDisponible;
        }
        #endregion

        #region metodos para los alojamientos
        private List<Reserva> getAllReservasForAlojamiento(String codigo)
        {
            return this.Reservas.ToList().FindAll(reserva => reserva.Alojamiento.Codigo == codigo);
        }
        public bool ExisteAlojamiento(int codigo)
        {
            return this.agencia.FindAlojamientoForCodigo(codigo) != null ? true : false;
        }
        #endregion

        /* GETTERS */
        public Agencia GetAgencia() { return this.agencia; }
        public Usuario GetUsuarioLogeado() { return this.usuarioLogeado; }
        public List<Usuario> GetUsuarios() { return this.Usuarios.ToList(); }
    }
}
