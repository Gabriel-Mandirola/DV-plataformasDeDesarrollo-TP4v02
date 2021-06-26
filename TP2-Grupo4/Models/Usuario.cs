using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;
using TP2_Grupo4.Helpers;

namespace TP2_Grupo4.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public int Dni { get; set; }
        public String Nombre { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public bool IsAdmin { get; set; }
        public bool Bloqueado { get; set; }

        public Usuario(int dni, String nombre, String email, String password, bool isAdmin, bool bloqueado)
        {
            this.setDni(dni);
            this.SetNombre(nombre);
            this.SetEmail(email);
            this.SetPassword(password);
            this.setIsAdmin(isAdmin);
            this.SetBloqueado(bloqueado);
        }

        /* METODOS ESTATICOS */
        public static Usuario Deserializar(String UsuarioSerializado)
        {
            String[] usuarioArray = Utils.StringToArray(UsuarioSerializado);
            return new Usuario(
                int.Parse(usuarioArray[0]),
                usuarioArray[1].ToString(),
                usuarioArray[2].ToString(),
                usuarioArray[3].ToString(),
                bool.Parse(usuarioArray[4]),
                bool.Parse(usuarioArray[5])
                );
        }
        /*public static bool GuardarCambiosEnElArchivo(List<Usuario> usuarios)
        {
            List<String> usuariosEnListaDeString = new List<string>();
            foreach (Usuario usuario in usuarios)
            {
                usuariosEnListaDeString.Add(usuario.ToString());
            }
            return Utils.WriteInFile(Config.PATH_FILE_USUARIOS, usuariosEnListaDeString);
        }*/

        /* ToString */
        public override string ToString()
        {
            String objetoSerializado = "";
            objetoSerializado += this.GetDni().ToString() + ",";
            objetoSerializado += this.GetNombre() + ",";
            objetoSerializado += this.GetEmail() + ",";
            objetoSerializado += this.GetPassword() + ",";
            objetoSerializado += this.GetIsAdmin().ToString() + ",";
            objetoSerializado += this.GetBloqueado().ToString();
            return objetoSerializado;
        }

        #region GETTERS Y SETTERS
        public int GetDni(){ return this.Dni; }
        public String GetNombre() { return this.Nombre; }
        public String GetEmail() { return this.Email; }
        public String GetPassword() { return this.Password; }
        public bool GetIsAdmin() { return this.IsAdmin; }
        public bool GetBloqueado() { return this.Bloqueado; }

        private void setDni(int dni) { this.Dni = dni; }
        public void SetNombre(String nombre) { this.Nombre = nombre; }
        public void SetEmail(String email) { this.Email = email; }
        public void SetPassword(String password) { this.Password = password; }
        private void setIsAdmin(bool isAdmin) { this.IsAdmin = isAdmin; }
        public void SetBloqueado(bool bloqueado) { this.Bloqueado = bloqueado; }
        #endregion
    
    }
}
