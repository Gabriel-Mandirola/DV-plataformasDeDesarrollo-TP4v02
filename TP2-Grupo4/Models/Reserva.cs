using System;
using System.Collections.Generic;

using TP2_Grupo4.Helpers;

namespace TP2_Grupo4.Models
{
    public class Reserva
    {
        public String id { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public Hotel hotel { get; set; }
        public Alojamiento alojamiento { get; set; }
        public Cabania cabania { get; set; }
        public Usuario usuario { get; set; }
        public double precio { get; set; }

        public Reserva(String id, DateTime fechaDesde, DateTime fechaHasta, Hotel hotel, Usuario usuario, double precio)
        {
            this.setId(id);
            this.SetFechaDesde(fechaDesde);
            this.SetFechaHasta(fechaHasta);
            this.SetHotel(hotel);
            this.SetUsuario(usuario);
            this.SetPrecio(precio);
        }
        public Reserva(String id, DateTime fechaDesde, DateTime fechaHasta, Cabania cabania, Usuario usuario, double precio)
        {
            this.setId(id);
            this.SetFechaDesde(fechaDesde);
            this.SetFechaHasta(fechaHasta);
            this.SetCabania(cabania);
            this.SetUsuario(usuario);
            this.SetPrecio(precio);
        }


        /* METODOS ESTATICOS */
        /*public static bool GuardarCambiosEnElArchivo(List<Reserva> reservas)
        {
            List<String> reservasSerializadas = new List<string>(){};
            foreach(Reserva reserva in reservas)
            {
                reservasSerializadas.Add(reserva.ToString());
            }
            return Utils.WriteInFile(Config.PATH_FILE_RESERVAS, reservasSerializadas);
        }*/

        /* ToString */
        public override string ToString()
        {
            String objetoSerializado = "";
            objetoSerializado += this.GetId().ToString() + ",";
            objetoSerializado += this.GetFechaDesde().ToString() + ",";
            objetoSerializado += this.GetFechaHasta().ToString() + ",";
            objetoSerializado += this.GetAlojamiento().GetCodigo().ToString() + ",";
            objetoSerializado += this.GetUsuario().GetDni().ToString() + ",";
            objetoSerializado += this.GetPrecio().ToString();
            return objetoSerializado;
        }

        #region GETTERS Y SETTERS
        public String GetId() { return this.id; }
        public DateTime GetFechaDesde() { return this.fechaDesde; }
        public DateTime GetFechaHasta() { return this.fechaHasta; }
        public Alojamiento GetAlojamiento() { return this.alojamiento; }
        public Hotel GetHotel() { return this.hotel; }
        public Cabania GetCabania() { return this.cabania; }
        public Usuario GetUsuario() { return this.usuario; }
        public double GetPrecio() { return this.precio; }
        private void setId(String id) { this.id = id; }
        public void SetFechaDesde(DateTime fechaDesde) { this.fechaDesde = fechaDesde; }
        public void SetFechaHasta(DateTime fechaHasta) { this.fechaHasta = fechaHasta; }
        public void SetAlojamiento(Alojamiento alojamiento) { this.alojamiento = alojamiento; }
        public void SetHotel(Hotel hotel) { this.hotel = hotel; }
        public void SetCabania(Cabania cabania) { this.cabania = cabania; }
        public void SetUsuario(Usuario usuario) { this.usuario = usuario; }
        public void SetPrecio(double precio) { this.precio = precio; }
        #endregion

    }
}
