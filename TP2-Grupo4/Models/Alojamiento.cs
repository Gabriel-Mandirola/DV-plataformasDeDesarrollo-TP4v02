using System;

namespace TP2_Grupo4.Models
{
    public class Alojamiento
    {
        public const int MAXIMO_NUMERO_DE_ESTRELLAS = 5;
        public const int MINIMO_NUMERO_DE_ESTRELLAS = 1;

        public int codigo { get; set; }
        public String ciudad { get; set; }
        public String barrio { get; set; }
        public int estrellas { get; set; }
        public int cantidadDePersonas { get; set; }
        public bool tv { get; set; }
        public double precioPorPersona { get; set; }
        public double precioPorDia { get; set; }
        public int habitaciones { get; set; }
        public int banios { get; set; }

        public Alojamiento(int codigo, String ciudad, String barrio, int estrellas, int cantidadDePersonas, bool tv, double precioPorPersona, double precioPorDia, int habitaciones, int banios)
        {
            this.setCodigo(codigo);
            this.SetCiudad(ciudad);
            this.SetBarrio(barrio);
            this.SetEstrellas(estrellas);
            this.SetCantidadDePersonas(cantidadDePersonas);
            this.SetTv(tv);
            this.SetPrecioPorPersona(precioPorPersona);
            this.SetPrecioPorDia(precioPorDia);
            this.SetHabitaciones(habitaciones);
            this.SetBanios(banios);
        }
        
        public bool IgualCodigo(Alojamiento alojamiento)
        {
            return alojamiento.GetCodigo() == this.GetCodigo();
        }

        /* METODOS ESTATICOS Y ABSTRACTOS */
        public static bool ValidarEstrellas(int estrellas)
        {
            return Alojamiento.MINIMO_NUMERO_DE_ESTRELLAS >= estrellas && estrellas <= Alojamiento.MAXIMO_NUMERO_DE_ESTRELLAS;
        }
        //public abstract double PrecioTotalDelAlojamiento();
        public double PrecioTotalDelAlojamiento()
        {
            //return this.GetPrecioPorPersona() * this.GetCantidadDePersonas();
            return this.GetPrecioPorDia(); 
        }


        /* ToString */
        public override string ToString()
        {
            String objetoSerializado = "";
            objetoSerializado += this.GetCodigo().ToString() + ",";
            objetoSerializado += this.GetCiudad().ToString() + ",";
            objetoSerializado += this.GetBarrio() + ",";
            objetoSerializado += this.GetEstrellas().ToString() + ",";
            objetoSerializado += this.GetCantidadDePersonas().ToString() + ",";
            objetoSerializado += this.GetTv().ToString();
            return objetoSerializado;
        }

        #region GETTERS Y SETTERS 
        public int GetCodigo(){ return this.codigo; }
        public String GetCiudad(){ return this.ciudad; }
        public String GetBarrio(){ return this.barrio; }
        public int GetEstrellas(){ return this.estrellas; }
        public int GetCantidadDePersonas(){ return this.cantidadDePersonas; }
        public bool GetTv(){ return this.tv; }
        public double GetPrecioPorPersona() { return this.precioPorPersona; }
        public double GetPrecioPorDia() { return this.precioPorDia; }
        public int GetHabitaciones() { return this.habitaciones; }
        public int GetBanios() { return this.banios; }

        private void setCodigo(int codigo){ this.codigo = codigo; }
        public void SetCiudad(String ciudad){ this.ciudad = ciudad; }
        public void SetBarrio(String barrio){ this.barrio = barrio; }
        public void SetEstrellas(int estrellas){ this.estrellas = estrellas; }
        public void SetCantidadDePersonas(int cantidadDePersonas) { this.cantidadDePersonas = cantidadDePersonas; }
        public void SetTv(bool tieneTv) { this.tv = tieneTv; }
        public void SetPrecioPorPersona(double precioPorPersona) { this.precioPorPersona = precioPorPersona; }
        public void SetPrecioPorDia(double precioPorDia) { this.precioPorDia = precioPorDia; }
        public void SetHabitaciones(int habitaciones) { this.habitaciones = habitaciones; }
        public void SetBanios(int banios) { this.banios = banios; }
        #endregion
    }
}
