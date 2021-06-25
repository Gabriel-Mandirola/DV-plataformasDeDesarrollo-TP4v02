using System;

namespace TP2_Grupo4.Models
{
    abstract public class Alojamiento
    {
        public const int MAXIMO_NUMERO_DE_ESTRELLAS = 5;
        public const int MINIMO_NUMERO_DE_ESTRELLAS = 1;

        public int codigo { get; set; }
        public String ciudad { get; set; }
        public String barrio { get; set; }
        public int estrellas { get; set; }
        public int cantidadDePersonas { get; set; }
        public bool tv { get; set; }

        public Alojamiento(int codigo, String ciudad, String barrio, int estrellas, int cantidadDePersonas, bool tv )
        {
            this.setCodigo(codigo);
            this.SetCiudad(ciudad);
            this.SetBarrio(barrio);
            this.SetEstrellas(estrellas);
            this.SetCantidadDePersonas(cantidadDePersonas);
            this.SetTv(tv);
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
        public abstract double PrecioTotalDelAlojamiento();
        

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
        
        private void setCodigo(int codigo){ this.codigo = codigo; }
        public void SetCiudad(String ciudad){ this.ciudad = ciudad; }
        public void SetBarrio(String barrio){ this.barrio = barrio; }
        public void SetEstrellas(int estrellas){ this.estrellas = estrellas; }
        public void SetCantidadDePersonas(int cantidadDePersonas) { this.cantidadDePersonas = cantidadDePersonas; }
        public void SetTv(bool tieneTv) { this.tv = tieneTv; }
        #endregion
    }
}
