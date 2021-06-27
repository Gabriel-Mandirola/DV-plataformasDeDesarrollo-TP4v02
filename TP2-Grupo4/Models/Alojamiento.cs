using System;

namespace TP2_Grupo4.Models
{
    public class Alojamiento
    {

        public int Id { get; set; }
        public String Codigo { get; set; }
        public String Ciudad { get; set; }
        public String Barrio { get; set; }
        public int Estrellas { get; set; }
        public int CantidadDePersonas { get; set; }
        public bool Tv { get; set; }
        public String Tipo { get; set; }
        /* HOTEL */
        public double PrecioPorPersona { get; set; }
        /* CABAÑA */
        public double PrecioPorDia { get; set; }
        public int Habitaciones { get; set; }
        public int Banios { get; set; }

        /*public Alojamiento(String codigo, String ciudad, String barrio, int estrellas, int cantPersonas, bool tv, double PrecioPorPersona, double precioPorDia, int habitaciones, int banios)
        {
            this.Codigo = codigo;
            this.Ciudad = ciudad;
            this.Barrio = barrio;
            this.Estrellas = estrellas;
            this.CantidadDePersonas = cantPersonas;
            this.Tv = tv;
            this.PrecioPorPersona = PrecioPorPersona;
            this.PrecioPorDia = precioPorDia;
            this.Habitaciones = habitaciones;
            this.Banios = banios;
        }*/

        //public double PrecioTotalDelAlojamiento()
        //{
        //    if (cantidadDePersonas > 0)
        //    {
        //        return this.GetPrecioPorPersona() * this.GetCantidadDePersonas();
        //    }
        //    else
        //    {
        //        return this.GetPrecioPorDia();
        //    }
        //}

    }
}