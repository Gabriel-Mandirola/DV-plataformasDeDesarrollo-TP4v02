using System;
using System.Collections.Generic;

using TP2_Grupo4.Models;
using TP2_Grupo4.Helpers;
using System.Linq;

namespace TP2_Grupo4
{
    public class AgenciaManager
    {
        private Context contexto;
        private Agencia agencia;
        private List<Usuario> usuarios;
        private List<Reserva> reservas;

        private Usuario usuarioLogeado;

        public AgenciaManager()
        {
            this.setAgencia(new Agencia());
            this.usuarios = new List<Usuario>();
            this.reservas = new List<Reserva>();
            this.usuarioLogeado = null;

            //this.cargarDatosDeLosUsuarios();
            this.cargarDatosDeLasReservas();

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
            }
            catch (Exception)
            {
            }
        }

        #region METODOS PARA LOS ALOJAMIENTOS
        public bool AgregarHotel(int codigo, String ciudad, String barrio, int estrellas, int cantPersonas, bool tv, double precioPersonas)
        {
            return this.agencia.AgregarAlojamiento(new Hotel(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioPersonas));
        }
        public bool AgregarCabania(int codigo, String ciudad, String barrio, int estrellas, int cantPersonas, bool tv, double precioPorDia, int habitaciones, int banios)
        {
            return this.agencia.AgregarAlojamiento(new Cabania(codigo, ciudad, barrio, estrellas, cantPersonas, tv, precioPorDia, habitaciones, banios));
        }
        public bool GuardarCambiosDeLosAlojamientos()
        {
            return this.agencia.GuardarCambiosEnElArchivo();
        }
        public bool EliminarAlojamiento(int codigo)
        {
            this.agencia.EliminarAlojamiento(codigo);

            List<Reserva> reservas = this.GetAllReservasForAlojamiento(codigo);
            foreach (Reserva reserva in reservas)
                this.EliminarReserva(reserva.GetId());

            return true;
        }
        #endregion

        #region METODOS PARA LAS RESERVAS
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

        public Reserva FindReservaForId(String id)
        {
            return this.GetReservas().Find(reserva => reserva.GetId() == id);
        }
        private List<Reserva> GetAllReservasForAlojamiento(int codigo)
        {
            return this.reservas.FindAll(reserva => reserva.GetAlojamiento().GetCodigo() == codigo);
        }
        public List<Reserva> GetAllReservasForUsuario(int dni)
        {
            return this.reservas.FindAll(reserva => reserva.GetUsuario().GetDni() == dni);
        }
        private int findIndexReservaPorId(String id)
        {
            return this.reservas.FindIndex(reserva => reserva.GetId() == id);
        }
        private void cargarDatosDeLasReservas()
        {
            List<String> reservasEnLista = Utils.GetDataFile(Config.PATH_FILE_RESERVAS);
            foreach(String reservaSerializada in reservasEnLista)
            {
                String[] reservaArray = Utils.StringToArray(reservaSerializada);
                Alojamiento alojamiento = this.GetAgencia().FindAlojamientoForCodigo(int.Parse(reservaArray[3]));
                Usuario usuario = this.FindUserForDNI(int.Parse(reservaArray[4]));
                
                if (alojamiento == null || usuario == null) 
                    continue;

                /*this.reservas.Add(
                    new Reserva(
                        reservaArray[0],
                        DateTime.Parse(reservaArray[1]),
                        DateTime.Parse(reservaArray[2]),
                        alojamiento,
                        usuario,
                        double.Parse(reservaArray[5])
                        )
                );*/
            }
        }
        public bool GuardarCambiosDeLasReservas()
        {
            List<String> reservas = new List<string>();
            foreach (Reserva reserva in this.GetReservas())
                reservas.Add(reserva.ToString());
            return Utils.WriteInFile(Config.PATH_FILE_RESERVAS, reservas);
        }
        public List<List<String>> DatosDeReservasParaLasVistas(String tipoDeUsuario = "admin")
        {
            List<List<String>> reservas = new List<List<string>>();

            if (tipoDeUsuario == "admin")
            {
                foreach (Reserva reserva in this.reservas)
                {
                    reservas.Add(new List<String>(){
                        reserva.GetId().ToString(),
                        reserva.GetFechaDesde().ToString(),
                        reserva.GetFechaHasta().ToString(),
                        reserva.GetPrecio().ToString(),
                    });
                }
            }
            else if (tipoDeUsuario == "user")
            {
                // Reservas del usuario
                List<Reserva> reservasDelUsuario = this.GetAllReservasForUsuario(this.usuarioLogeado.GetDni());
                
                foreach (Reserva reserva in reservasDelUsuario)
                {
                    reservas.Add(new List<String>(){
                        reserva.GetAlojamiento() is Hotel ? "hotel" : "cabaña",
                        reserva.GetFechaDesde().ToString(),
                        reserva.GetFechaHasta().ToString(),
                        reserva.GetPrecio().ToString(),
                    });
                }
            }
            return reservas;
        }
        #endregion

        #region METODOS PARA LOS USUARIOS
        public bool AgregarUsuario(int dni, String nombre, String email, String password, bool isAdmin, bool bloqueado)
        {
            try
            {
                Usuario nuevo = new Usuario(dni, nombre, email, password, isAdmin, bloqueado);
                contexto.Usuarios.Add(nuevo);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /*public bool AgregarUsuario(int dni, String nombre, String email, String password, bool isAdmin, bool bloqueado)
        {
            this.usuarios.Add(new Usuario(dni,nombre,email,Utils.Encriptar(password), isAdmin,bloqueado));
            return true;
        }*/
        public bool ModificarUsuario(int dni, String nombre, String email, String password = "")
        {
            try
            {
                bool salida = false;
                foreach (Usuario u in contexto.Usuarios)
                    if (u.Dni == dni)
                    {
                        u.Nombre = nombre;
                        u.Email = email;
                        u.Password = password;
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
        /*public bool ModificarUsuario(int dni, String nombre, String email, String password = "")
        {
            int indexUser = this.findIndexUsuarioForDNIO(dni);
            if (indexUser == -1) return false; // Usuario no encontrado

            this.usuarios[indexUser].SetNombre(nombre);
            this.usuarios[indexUser].SetEmail(email);

            if (password == "") return true;
            this.usuarios[indexUser].SetPassword(Utils.Encriptar(password));
            
            return true;
        }*/
        public bool EliminarUsuario(int dni)
        {
            try
            {
                bool salida = false;
                foreach (Usuario u in contexto.Usuarios)
                    if (u.Dni == dni)
                    {
                        contexto.Usuarios.Remove(u);
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
        /*public bool EliminarUsuario(int dni)
        {
            int indexUser = this.findIndexUsuarioForDNIO(dni);
            if (indexUser == -1) return false;

            // Reservas del usuario a eliminar
            List<Reserva> reservasDelUsuario = this.GetAllReservasForUsuario(dni);

            foreach (Reserva reserva in reservasDelUsuario)
                this.EliminarReserva(reserva.GetId());

            this.usuarios.RemoveAt(indexUser);
            return true;
        }*/
        
        public bool autenticarUsuario(int dni, String password)
        {
            Usuario usuarioEncontrado = this.FindUserForDNI(dni);
            if (usuarioEncontrado == null) return false; // DNI no encontrado
            if (usuarioEncontrado.GetPassword() != Utils.Encriptar(password)) return false; // Contraseña incorrecta
            
            this.usuarioLogeado = usuarioEncontrado;
            return true;
        }
        public void CerrarSession()
        {
            this.usuarioLogeado = null;
        }
        public bool BloquearUsuario(int dni)
        {
            int indexUser = this.usuarios.FindIndex(user => user.GetDni() == dni);
            if (indexUser == -1) return false; // Usuario no encontrado
            this.usuarios[indexUser].SetBloqueado(true);
            return true;
        }
        public bool DesbloquearUsuario(int dni)
        {
            int indexUser = this.usuarios.FindIndex(user => user.GetDni() == dni);
            if (indexUser == -1) return false; // Usuario no encontrado
            this.usuarios[indexUser].SetBloqueado(false);
            return true;
        }
        public Usuario FindUserForDNI(int dni)
        {
            return this.GetUsuarios().Find(user => user.GetDni() == dni);
        }
        public bool ExisteEmail(string email)
        {
            return this.GetUsuarios().Exists(user => user.GetEmail() == email);
        }
        private int findIndexUsuarioForDNIO(int dni)
        {
            return this.usuarios.FindIndex(user => user.GetDni() == dni);
        }
        /*private void cargarDatosDeLosUsuarios()
        {
            List<String> usuariosSerializados = Utils.GetDataFile(Config.PATH_FILE_USUARIOS);
            foreach (String usuario in usuariosSerializados)
                this.usuarios.Add(Usuario.Deserializar(usuario));
        }*/
        /*public bool GuardarCambiosDeLosUsuarios()
        {
            return Usuario.GuardarCambiosEnElArchivo(this.GetUsuarios());
        }*/
        #endregion


        #region METODOS PARA LAS VISTAS
        public bool IsUsuarioBloqueado(int dni)
        {
            Usuario user = this.usuarios.Find(user => user.GetDni() == dni && user.GetBloqueado() == true);
            return user == null ? false : true;
        }
        public Agencia FiltrarAlojamientos(String tipoAlojamiento, String ciudad, String barrio, double precioMin, double precioMax, String estrellas, String personas)
        {
            Agencia alojamientosFiltrados = null;
            switch (tipoAlojamiento)
            {
                case "todos":
                    alojamientosFiltrados = this.agencia.GetAllAlojamientos();
                    break;
                case "hotel":
                    alojamientosFiltrados = this.agencia.GetHoteles();
                    break;
                case "cabaña":
                    alojamientosFiltrados = this.agencia.GetCabanias();
                    break;
            }
            if (alojamientosFiltrados == null) return null;

            if(ciudad != "todas")
            {
                alojamientosFiltrados = alojamientosFiltrados.GetAlojamientosPorCiudad(ciudad);
                if (alojamientosFiltrados == null) return null;
            }

            if (barrio != "todos")
            {
                alojamientosFiltrados = alojamientosFiltrados.GetAlojamientosPorBarrio(barrio);
                if (alojamientosFiltrados == null) return null;
            }

            if (precioMin - precioMax != 0)
            {
                alojamientosFiltrados = alojamientosFiltrados.GetAllAlojamientos(precioMin, precioMax);
                if (alojamientosFiltrados == null) return null;
            }

            if(estrellas != "todas")
            {
                alojamientosFiltrados = alojamientosFiltrados.GetAllAlojamientos(int.Parse(estrellas));
                if (alojamientosFiltrados == null) return null;
            }

            if(personas != "todas")
            {
                alojamientosFiltrados = alojamientosFiltrados.GetAlojamientosPorCantidadDePersonas(int.Parse(personas));
                if (alojamientosFiltrados == null) return null;
            }

            return alojamientosFiltrados;
        }

        /* OPCIONES DE LOS SELECTS EN LAS VISTAS */
        public List<String> OpcionesDelSelectDeTiposDeAlojamientos()
        {
            return new List<String>() { "todos", "hotel", "cabaña" };
        }
        public List<String> OpcionesDelSelectDePersonas()
        {
            List<String> opciones = new List<String>() {"todas" };
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
            List<String> tipos = new List<string>() { "todos"};
            foreach (Alojamiento al in this.agencia.GetAlojamientos())
                tipos.Add(al.GetBarrio());
            return tipos.Distinct().ToList();
        }
        public List<String> OpcionesDelSelectDeCiudades()
        {
            List<String> tipos = new List<string>() { "todas" };
            foreach (Alojamiento al in this.agencia.GetAlojamientos())
                tipos.Add(al.GetCiudad());
            return tipos.Distinct().ToList();
        }
        public List<String> OpcionesDelSelectParaElOrdenamiento()
        {
            return new List<String>() { "fecha de creacion","personas","estrellas" };
        }

        #endregion


        /* GETTERS Y SETTERS */
        public List<Usuario> GetUsuarios() { return this.usuarios; }
        public List<Reserva> GetReservas() { return this.reservas; }
        public Agencia GetAgencia() { return this.agencia; }
        public Usuario GetUsuarioLogeado() { return this.usuarioLogeado; }
        private void setAgencia(Agencia agencia) { 
            this.agencia = agencia;
            this.agencia.CargarDatosDeLosAlojamientos();
        }

    }
}
