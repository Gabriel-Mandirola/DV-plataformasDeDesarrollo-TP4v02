using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using TP2_Grupo4.Models;

namespace TP2_Grupo4.Views
{
    public partial class VistaRecuperar : Form
    {
        private AgenciaManager agencia;
        public VistaRecuperar()
        {
            InitializeComponent();
            this.agencia = new AgenciaManager();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            VistaLogin cambiarFormulario = new VistaLogin();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            VistaRegistrar cambiarFormulario = new VistaRegistrar();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "DNI")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.LightGray;
            }
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "DNI";
                txtUsuario.ForeColor = Color.DimGray;
            }
        }
        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "CONTRASEÑA NUEVA")
            {
                txtContrasena.Text = "";
            }
        }
        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "CONTRASEÑA NUEVA";
            }
        }

        private void txtContrasenaNueva_Enter(object sender, EventArgs e)
        {
            if (txtRepetirContrasena.Text == "REPETIR CONTRASEÑA")
            {
                txtRepetirContrasena.Text = "";
            }
        }

        private void txtContrasenaNueva_Leave(object sender, EventArgs e)
        {
            if (txtRepetirContrasena.Text == "")
            {
                txtRepetirContrasena.Text = "REPETIR CONTRASEÑA";
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                int dni = Int32.Parse(txtUsuario.Text);
                string contrasena = txtContrasena.Text;
                string repetirContrasena = txtRepetirContrasena.Text;
                Usuario usuario = this.agencia.FindUserForDNI(dni);

                if (usuario == null)
                {
                    MessageBox.Show("El usuario invalido, por favor intentelo nuevamente.");
                }
                else
                {
                    if (contrasena == repetirContrasena)
                    {
                        string nombre = usuario.GetNombre();
                        string email = usuario.GetEmail();
                        this.agencia.ModificarUsuario(dni, nombre, email, contrasena);
                        //this.agencia.GuardarCambiosDeLosUsuarios();
                        MessageBox.Show("Se ha modificado el usuario de manera exitosa.");
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrecto, por favor intentelo nuevamente.");

                    }

                    txtUsuario.Text = "DNI";
                    txtUsuario.ForeColor = Color.DimGray;
                    txtContrasena.Text = "CONTRASEÑA NUEVA";
                    txtRepetirContrasena.Text = "REPETIR CONTRASEÑA";
                }
            }
            catch
            {
                MessageBox.Show("El usuario no existe, por favor intentelo nuevamente.");
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox3.Visible = true;
            txtContrasena.UseSystemPasswordChar = false;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox3.Visible = false;
            txtContrasena.UseSystemPasswordChar = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox4.Visible = true;
            txtRepetirContrasena.UseSystemPasswordChar = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            pictureBox4.Visible = false;
            txtRepetirContrasena.UseSystemPasswordChar = true;
        }
    }
}
