﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TP2_Grupo4
{
    public partial class Login : Form
    {
        int intentos = 3;
        string contraseña;
        VistaClienteFiltrar ingresoCliente = new VistaClienteFiltrar();
        VistaAdminUsuarios ingresoAdmin = new VistaAdminUsuarios();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //validar si el usuario está correcto

            //si es válido y es cliente moverse a la VistaCliente
            string user = textBox1.Text;
            string password = textBox2.Text;
            string tempurl = "D:\\usuario\\xampp\\htdocs\\TP2-Grupo4\\usuarios\\" + user + ".txt"; ;
            if (File.Exists(tempurl))
            {
                contraseña = File.ReadAllText(tempurl);
                if (password.Equals(contraseña))
                {
                    MessageBox.Show("Bienvenido usuario.");
                    ingresoCliente.Show();
                    this.Hide();
                }
                else
                {
                    intentos--;
                    if (intentos == 0)
                    {
                        //acá hay que bloquear al usuario
                        MessageBox.Show("Usuario bloqueado, contacte con un administrador para desbloquear el usuario.");
                    }
                    else
                    {
                        MessageBox.Show("La contraseña es incorrecta, le quedan " + intentos + " intentos.");
                    }
                }
            }
            else
            {
                MessageBox.Show("El usuario no está registrado, por favor vuelva a intentarlo.");
            }
            //newMDIChild2.Show();

            //si es válido y es admin moverse a la VistaAdmin
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string user = textBox1.Text;
            string password = textBox2.Text;
            string tempurl = "D:\\usuario\\xampp\\htdocs\\TP2-Grupo4\\usuarios\\" + user + ".txt";
            if (File.Exists(tempurl))
            {
                MessageBox.Show("Usuario ya registrado.");
            }
            else
            {
                File.WriteAllText(tempurl, password);
                MessageBox.Show("Se ha registrado exitosamente.");
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }
    }
}
