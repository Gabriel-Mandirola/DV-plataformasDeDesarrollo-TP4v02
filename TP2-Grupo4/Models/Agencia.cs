using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace TP2_Grupo4.Models
{
    public class Agencia
    {
        public const int MAXIMA_CANTIDAD_DE_PERSONAS_POR_ALOJAMIENTO = 10;
        public const int MINIMA_CANTIDAD_DE_ESTRELLAS = 1;
        public const int MAXIMA_CANTIDAD_DE_ESTRELLAS = 5;

        private Context contexto;
        public DbSet<Alojamiento> Alojamientos { get; set; }

        public Agencia()
        {
            try
            {
                // Creo Contexto
                contexto = new Context();

                // Cargo los alojamientos
                contexto.Alojamientos.Load();
                this.Alojamientos = contexto.Alojamientos;
            }
            catch (Exception)
            {
            }
        }

        #region ABM
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
                var alojamientoEncontrado = this.Alojamientos.ToList().Find(a => a.Codigo == alojamiento.Codigo);
                alojamientoEncontrado.Ciudad = alojamiento.Ciudad;
                alojamientoEncontrado.Barrio = alojamiento.Barrio;
                alojamientoEncontrado.Estrellas = alojamiento.Estrellas;
                alojamientoEncontrado.CantidadDePersonas = alojamiento.CantidadDePersonas;
                alojamientoEncontrado.Tv = alojamiento.Tv;
                alojamientoEncontrado.PrecioPorPersona = alojamiento.PrecioPorPersona;
                alojamientoEncontrado.PrecioPorDia = alojamiento.PrecioPorDia;
                alojamientoEncontrado.Habitaciones = alojamiento.Habitaciones;
                alojamientoEncontrado.Banios = alojamiento.Banios;
                contexto.SaveChanges();
                return true;
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
                var alojamiento = this.Alojamientos.ToList().Find(a => a.Codigo == codigoDelAlojamiento.ToString());
                this.Alojamientos.Remove(alojamiento);
                contexto.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
        public Alojamiento FindAlojamientoForCodigo(int codigoAlojamiento)
        {
            return this.Alojamientos.ToList().Find(al => al.Codigo == codigoAlojamiento.ToString());
        }


        #region METODOS COMPLEMENTARIOS
        public List<List<String>> DatosDeAlojamientosParaLasVistasCliente()
        {
            List<List<String>> alojamientos = new List<List<string>>();
            foreach (Alojamiento alojamiento in this.Alojamientos)
            {
                double precio = alojamiento.Tipo == "hotel" ? alojamiento.PrecioPorPersona : alojamiento.PrecioPorDia;
                alojamientos.Add(new List<String>(){
                        //alojamiento is Hotel ? "hotel" : "cabaña", // Tipo de alojamiento
                        alojamiento.Ciudad,
                        alojamiento.Barrio,
                        alojamiento.Estrellas.ToString(),
                        alojamiento.CantidadDePersonas.ToString(),
                        alojamiento.Tv ? "si" : "no",
                        precio.ToString()
                    });
            }
            return alojamientos;
        }
        public List<List<String>> DatosDeAlojamientosParaLasVistasAdmin(String tipoAloj)
        {
            List<List<String>> alojamientos = new List<List<string>>();
            foreach (Alojamiento alojamiento in this.Alojamientos)
            {
                if (tipoAloj == "todo")
                {
                    double precio = alojamiento.Tipo == "hotel" ? alojamiento.PrecioPorPersona : alojamiento.PrecioPorDia;
                    alojamientos.Add(new List<String>(){
                    alojamiento.Codigo.ToString(),
                    alojamiento.Ciudad,
                    alojamiento.Barrio,
                    alojamiento.Estrellas.ToString(),
                    alojamiento.CantidadDePersonas.ToString(),
                    alojamiento.Tv ? "si" : "no",
                    precio.ToString(),
                    });
                }
                else if (alojamiento.Tipo == tipoAloj)
                {
                    double precio = alojamiento.Tipo == "hotel" ? alojamiento.PrecioPorPersona : alojamiento.PrecioPorDia;
                    alojamientos.Add(new List<String>(){
                    alojamiento.Codigo.ToString(),
                    alojamiento.Ciudad,
                    alojamiento.Barrio,
                    alojamiento.Estrellas.ToString(),
                    alojamiento.CantidadDePersonas.ToString(),
                    alojamiento.Tv ? "si" : "no",
                    precio.ToString(),
                });
                }
            }
            return alojamientos;
        }

        public List<List<String>> GetAlojamientoPorCodigo()
        {
            List<Alojamiento> alojamientos = this.Alojamientos.OrderBy(alojamiento => alojamiento.Codigo).ToList();
            return this.AlojamientosToLista(alojamientos);
        }
        public List<List<String>> GetAlojamientoPorEstrellas()
        {
            List<Alojamiento> alojamientos = this.Alojamientos.OrderBy(alojamiento => alojamiento.Estrellas).ToList();
            return this.AlojamientosToLista(alojamientos);
        }
        public List<List<String>> GetAlojamientoPorPersonas()
        {
            List<Alojamiento> alojamientos = this.Alojamientos.OrderBy(alojamiento => alojamiento.CantidadDePersonas).ToList();
            return this.AlojamientosToLista(alojamientos);
        }
        public List<List<String>> AlojamientosToLista(List<Alojamiento> alojamientos = null)
        {
            List<List<String>> listaDeAlojamientos = new List<List<string>>();

            var alojamientosAIterar = alojamientos == null ? this.Alojamientos.ToList() : alojamientos;

            foreach (Alojamiento al in alojamientosAIterar)
            {
                listaDeAlojamientos.Add(
                    new List<string>()
                    {
                        al.Codigo,
                        al.Tipo,
                        al.Ciudad,
                        al.Barrio,
                        al.Estrellas.ToString(),
                        al.CantidadDePersonas.ToString(),
                        al.Tv ? "si" : "no",
                        al.Tipo == "hotel" ? al.PrecioPorPersona.ToString() : al.PrecioPorDia.ToString()
                    }
                    );
            }
            return listaDeAlojamientos;
        }

        public List<Alojamiento> GetAlojamientos()
        {
            return this.Alojamientos.ToList();

        }

        #endregion
    }
}
