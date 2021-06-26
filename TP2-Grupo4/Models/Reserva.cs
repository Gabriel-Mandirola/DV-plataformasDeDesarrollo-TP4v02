using System;

namespace TP2_Grupo4.Models
{
    public class Reserva
    {
        public int id { get; set; }
        public DateTime fechaDesde { get; set; }
        public DateTime fechaHasta { get; set; }
        public Alojamiento alojamiento { get; set; }  
        public Usuario usuario { get; set; }
        public double precio { get; set; }


    }
}