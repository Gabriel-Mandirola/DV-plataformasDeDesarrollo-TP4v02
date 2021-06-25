using System;

using TP2_Grupo4.Helpers;

namespace TP2_Grupo4.Models
{
    public class Cabania : Alojamiento
    {
        public const int CANTIDAD_DE_ATRIBUTOS = 9;

        public double precioPorDia { get; set; }
        public int habitaciones { get; set; }
        public int banios { get; set; }

        public Cabania(int codigo, string ciudad, string barrio, int estrellas, int cantidadDePersonas, bool tv, double precioPorDia, int habitaciones, int banios) : 
            base(codigo, ciudad, barrio, estrellas, cantidadDePersonas, tv)
        {
            this.SetPrecioPorDia(precioPorDia);
            this.SetHabitaciones(habitaciones);
            this.SetBanios(banios);
        }

        public override double PrecioTotalDelAlojamiento(){ return this.GetPrecioPorDia(); }
        
        /* METODOS ESTATICOS*/
        public static Cabania Deserializar(String cabaniaSerializada)
        {
            String[] CabaniaArray = Utils.StringToArray(cabaniaSerializada);

            return new Cabania(
                int.Parse(CabaniaArray[0]),
                CabaniaArray[1],
                CabaniaArray[2],
                int.Parse(CabaniaArray[3]),
                int.Parse(CabaniaArray[4]),
                bool.Parse(CabaniaArray[5]),
                double.Parse(CabaniaArray[6]),
                int.Parse(CabaniaArray[7]),
                int.Parse(CabaniaArray[8])
                );
        }

        /* ToString*/
        public override string ToString()
        {
            String objetoSerializado = base.ToString() + ",";
            objetoSerializado += this.GetPrecioPorDia().ToString() + ",";
            objetoSerializado += this.GetHabitaciones().ToString() + ",";
            objetoSerializado += this.GetBanios().ToString();
            return objetoSerializado;
        }

        #region GETTERS Y SETTERS
        public double GetPrecioPorDia()
        {
            return this.precioPorDia;
        }
        public int GetHabitaciones()
        {
            return this.habitaciones;
        }
        public int GetBanios()
        {
            return this.banios;
        }
        
        public void SetPrecioPorDia(double precioPorDia) { this.precioPorDia = precioPorDia; }
        public void SetHabitaciones(int habitaciones) { this.habitaciones = habitaciones; }
        public void SetBanios(int banios) { this.banios = banios; }
        #endregion
    }
}
