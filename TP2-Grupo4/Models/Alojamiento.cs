using System;

namespace TP2_Grupo4.Models
{
    public class Alojamiento
    {

        public int id { get; set; }
        public String codigo { get; set; }
        public String ciudad { get; set; }
        public String barrio { get; set; }
        public int estrellas { get; set; }
        public int cantidadDePersonas { get; set; }
        public bool tv { get; set; }
        public String tipo { get; set; }
        public double precioPorPersona { get; set; }
        public double precioPorDia { get; set; }
        public int habitaciones { get; set; }
        public int banios { get; set; }
    }
}