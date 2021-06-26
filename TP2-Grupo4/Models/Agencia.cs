using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

using TP2_Grupo4.Helpers;

namespace TP2_Grupo4.Models
{
    public class Agencia
    {
        private Context contexto;
        public const int MAXIMA_CANTIDAD_DE_PERSONAS_POR_ALOJAMIENTO = 10;
        public const int MINIMA_CANTIDAD_DE_ESTRELLAS = 1;
        public const int MAXIMA_CANTIDAD_DE_ESTRELLAS = 5;

        private List<Alojamiento> alojamientos;
        private int cantidadDeAlojamientos;

        public Agencia()
        {
            this.alojamientos = new List<Alojamiento>();
            this.cantidadDeAlojamientos = 0;
            inicializarAtributos();
        }
        private void inicializarAtributos()
        {
            try
            {
                //creo un contexto
                contexto = new Context();

                //cargo los alojamientos
                contexto.Alojamientos.Load();
            }
            catch (Exception)
            {
            }
        }

        #region ABM de Alojamientos
        public bool AgregarAlojamiento(Alojamiento alojamiento)
        {
            try
            {
                contexto.Alojamientos.Add(alojamiento);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ModificarAlojamiento(Alojamiento alojamiento)
        {
            try
            {
                bool salida = false;
                foreach (Alojamiento a in contexto.Alojamientos)
                    if (a.codigo == alojamiento.codigo)
                    {
                        a.ciudad = alojamiento.ciudad;
                        a.barrio = alojamiento.barrio;
                        a.estrellas = alojamiento.estrellas;
                        a.cantidadDePersonas = alojamiento.cantidadDePersonas;
                        a.tv = alojamiento.tv;
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

        public bool EliminarAlojamiento(int codigoDelAlojamiento)
        {
            try
            {
                bool salida = false;
                foreach (Alojamiento a in contexto.Alojamientos)
                    if (a.codigo == codigoDelAlojamiento)
                    {
                        contexto.Alojamientos.Remove(a);
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
        #endregion

        #region METODOS PARA FILTRAR ALOJAMIENTOS
        /*public Agencia GetHoteles()
        {
            List<Alojamiento> alojamientos = this.alojamientos.FindAll(alojamiento => alojamiento is Hotel);
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetCabanias()
        {
            List<Alojamiento> alojamientos = this.alojamientos.FindAll( alojamiento => alojamiento is Cabania);
            return this.alojamientosToAgencia(alojamientos);
        }*/
        public Agencia GetAlojamientosPorCantidadDePersonas(int cantidadDePersonas)
        {
            List<Alojamiento> alojamientos = this.alojamientos.FindAll( al => al.GetCantidadDePersonas() == cantidadDePersonas);
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetAlojamientosPorCiudad(String ciudad)
        {
            return this.alojamientosToAgencia(this.alojamientos.FindAll(al => al.GetCiudad() == ciudad));
        }
        public Agencia GetAlojamientosPorBarrio(String barrio)
        {
            return this.alojamientosToAgencia(this.alojamientos.FindAll(al => al.GetBarrio() == barrio));
        }
        public Agencia GetAllAlojamientos()
        {
            return this.alojamientosToAgencia(this.GetAlojamientos());
        }
        public Agencia GetAllAlojamientos(int minimoEstrellas)
        {
            List<Alojamiento> alojamientos = this.alojamientos.FindAll(alojamiento => alojamiento.GetEstrellas() >= minimoEstrellas);
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetAllAlojamientos(double precioMinimo, double precioMaximo)
        {
            List<Alojamiento> alojamientos = this.alojamientos.FindAll(al => al.PrecioTotalDelAlojamiento() >= precioMinimo && al.PrecioTotalDelAlojamiento() <= precioMaximo);
            return this.alojamientosToAgencia(alojamientos);
        }
        #endregion

        #region METODOS DE ORDENAMIENTO
        public Agencia GetAlojamientoPorEstrellas()
        {
            List<Alojamiento> alojamientos = this.alojamientos.OrderBy(alojamiento => alojamiento.GetEstrellas()).ToList();
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetAlojamientoPorPersonas()
        {
            List<Alojamiento> alojamientos = this.alojamientos.OrderBy(alojamiento => alojamiento.GetCantidadDePersonas()).ToList();
            return this.alojamientosToAgencia(alojamientos);
        }
        public Agencia GetAlojamientoPorCodigo()
        {
            List<Alojamiento> alojamientos = this.alojamientos.OrderBy(alojamiento => alojamiento.GetCodigo()).ToList();
            return this.alojamientosToAgencia(alojamientos);
        }
        #endregion


        #region METODOS COMPLEMENTARIOS
        public List<List<String>> DatosDeAlojamientosParaLasVistas(String tipoDeUsuario = "admin")
        {
            List<List<String>> alojamientos = new List<List<string>>();
            
            if (tipoDeUsuario == "admin")
            {
                foreach (Alojamiento alojamiento in this.alojamientos)
                    alojamientos.Add(new List<String>(){
                        alojamiento.GetCodigo().ToString(),
                        alojamiento.GetCiudad(),
                        alojamiento.GetBarrio(),
                        alojamiento.GetEstrellas().ToString(),
                        alojamiento.GetCantidadDePersonas().ToString(),
                        alojamiento.GetTv() ? "si" : "no",
                        alojamiento.PrecioTotalDelAlojamiento().ToString(),
                    });

            }
            else if(tipoDeUsuario == "user")
            {
                foreach (Alojamiento alojamiento in this.alojamientos)
                {
                    alojamientos.Add(new List<String>(){
                        //alojamiento is Hotel ? "hotel" : "cabaña", // Tipo de alojamiento
                        alojamiento.GetCiudad(),
                        alojamiento.GetBarrio(),
                        alojamiento.GetEstrellas().ToString(),
                        alojamiento.GetCantidadDePersonas().ToString(),
                        alojamiento.GetTv() ? "si" : "no",
                        alojamiento.PrecioTotalDelAlojamiento().ToString(),
                    });
                }
            }

            
            return alojamientos;
        }
        /*public List<List<String>> DatosDeHotelesParaLasVistas()
        {
            List<List<String>> alojamientos = new List<List<string>>();
            //List<Alojamiento> hoteles = this.GetHoteles().GetAlojamientos();
            if (hoteles.Count == 0) return alojamientos;

            foreach (Alojamiento alojamiento in hoteles)
                alojamientos.Add(Utils.StringToArray(alojamiento.ToString()).ToList());

            return alojamientos;
        }
        public List<List<String>> DatosDeCabaniasParaLasVistas()
        {
            List<List<String>> alojamientos = new List<List<string>>();
            List<Alojamiento> cabanias = this.GetCabanias().GetAlojamientos();
            if (cabanias.Count == 0) return alojamientos;

            foreach (Alojamiento alojamiento in cabanias)
                alojamientos.Add(Utils.StringToArray(alojamiento.ToString()).ToList());

            return alojamientos;
        }*/
        private Agencia alojamientosToAgencia(List<Alojamiento> alojamientos)
        {
            if (alojamientos.Count == 0) return null;

            Agencia alojamientosFiltrados = new Agencia();
            foreach (Alojamiento al in alojamientos)
            {
                alojamientosFiltrados.AgregarAlojamiento(al);
            }
            return alojamientosFiltrados;
        }
        public Alojamiento FindAlojamientoForCodigo(int codigoAlojamiento)
        {
            return this.alojamientos.Find( al => al.GetCodigo() == codigoAlojamiento );
        }
        public bool ExisteAlojamiento(Alojamiento alojamiento)
        {
            return this.alojamientos.Exists(al => al.IgualCodigo(alojamiento));
        }
        public void CargarDatosDeLosAlojamientos()
        {
            List<string> contenidoDelArchivo = Utils.GetDataFile(Config.PATH_FILE_ALOJAMIENTOS);
            if (contenidoDelArchivo.Count == 0) return;

            foreach (String alojamiento in contenidoDelArchivo)
            {
                int cantidadDeAtributosDelAlojamiento = Utils.StringToArray(alojamiento).Length;
                /*if (cantidadDeAtributosDelAlojamiento == Hotel.CANTIDAD_DE_ATRIBUTOS)
                {
                    this.AgregarAlojamiento(Hotel.Deserializar(alojamiento));
                }
                else if(cantidadDeAtributosDelAlojamiento == Cabania.CANTIDAD_DE_ATRIBUTOS)
                {
                    this.AgregarAlojamiento(Cabania.Deserializar(alojamiento));
                }*/
            }
        }
        public bool GuardarCambiosEnElArchivo()
        {
            List<String> alojamientosInLista = new List<string>();
            foreach( Alojamiento al in this.alojamientos)
            {
                alojamientosInLista.Add(al.ToString());
            }
            return Utils.WriteInFile(Config.PATH_FILE_ALOJAMIENTOS, alojamientosInLista);
        }
        #endregion


        /* GETTER */
        public int GetCantidadDeAlojamientos() { return this.cantidadDeAlojamientos; }
        public List<Alojamiento> GetAlojamientos() { return this.alojamientos; }
    }
}
