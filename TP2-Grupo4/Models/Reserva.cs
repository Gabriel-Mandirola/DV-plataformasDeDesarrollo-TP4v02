using System;

namespace TP2_Grupo4.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public Alojamiento Alojamiento { get; set; }  
        public Usuario Usuario { get; set; }
        public double Precio { get; set; }

        /*public Reserva(DateTime FechaDesde, DateTime FechaHasta, Alojamiento Alojamiento, Usuario Usuario, double Precio)
        {
            this.FechaDesde = FechaDesde;
            this.FechaHasta = FechaHasta;
            this.Alojamiento = Alojamiento;
            this.Usuario = Usuario;
            this.Precio = Precio;
        }*/
    }
}