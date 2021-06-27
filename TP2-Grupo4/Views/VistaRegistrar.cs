using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace TP2_Grupo4.Views
{
    public partial class VistaRegistrar : Form
    {
        private AgenciaManager agencia;

        public VistaRegistrar()
        {
            InitializeComponent();
            this.agencia = new AgenciaManager();
            if (VistaLogin.idioma == "English")
            {
                cambiarIdioma.Text = "Español";
                button1.Text = "Login";
                btnRegistrar.Text = "Register";
                txtUsuario.Text = "DNI";
                txtContrasena.Text = "PASSWORD";
                txtNombre.Text = "NAME";
                txtMail.Text = "EMAIL";
                checkAdmin.Text = "Is Admin?";
                button2.Text = "Register";
                label2.Text = "Register";
            }
            else if (VistaLogin.idioma == "Español")
            {
                cambiarIdioma.Text = "English";
                button1.Text = "Ingresar";
                btnRegistrar.Text = "Registrar";
                txtUsuario.Text = "DNI";
                txtContrasena.Text = "CONTRASEÑA";
                txtNombre.Text = "NOMBRE";
                txtMail.Text = "MAIL";
                checkAdmin.Text = "¿Es Admin?";
                button2.Text = "Registrarse";
                label2.Text = "Registrarse";
            }
        }

        #region Key Pressed
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
            if (txtContrasena.Text == "CONTRASEÑA" || txtContrasena.Text == "PASSWORD")
            {
                txtContrasena.Text = "";
                txtContrasena.ForeColor = Color.LightGray;
            }
        }

        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "" && cambiarIdioma.Text == "English")
            {
                txtContrasena.Text = "CONTRASEÑA";
                txtContrasena.ForeColor = Color.DimGray;
            }
            else if (txtContrasena.Text == "" && cambiarIdioma.Text == "Español")
            {
                txtContrasena.Text = "PASSWORD";
                txtContrasena.ForeColor = Color.DimGray;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (txtNombre.Text == "NOMBRE" || txtNombre.Text == "NAME")
            {
                txtNombre.Text = "";
                txtNombre.ForeColor = Color.LightGray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" && cambiarIdioma.Text == "English")
            {
                txtNombre.Text = "NOMBRE";
                txtNombre.ForeColor = Color.DimGray;
            }
            else if (txtNombre.Text == "" && cambiarIdioma.Text == "Español")
            {
                txtNombre.Text = "NAME";
                txtNombre.ForeColor = Color.DimGray;
            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (txtMail.Text == "EMAIL" || txtMail.Text == "MAIL")
            {
                txtMail.Text = "";
                txtMail.ForeColor = Color.LightGray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (txtMail.Text == "" && cambiarIdioma.Text == "English")
            {
                txtMail.Text = "MAIL";
                txtMail.ForeColor = Color.DimGray;
            }
            else if (txtMail.Text == "" && cambiarIdioma.Text == "Español")
            {
                txtMail.Text = "EMAIL";
                txtMail.ForeColor = Color.DimGray;
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
        #endregion

        #region Helpers
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion

        #region On Click
        private void button1_Click(object sender, EventArgs e)
        {
            VistaLogin cambiarFormulario = new VistaLogin();
            cambiarFormulario.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.agencia.FindUserForDNI(int.Parse(txtUsuario.Text)) == null)
                {
                    if (!this.agencia.ExisteEmail(txtMail.Text))
                    {
                        agencia.AgregarUsuario(int.Parse(txtUsuario.Text), txtNombre.Text, txtMail.Text, txtContrasena.Text, checkAdmin.Checked, false);
                        txtUsuario.Text = "DNI";
                        txtUsuario.ForeColor = Color.DimGray;
                        txtNombre.Text = "NOMBRE";
                        txtNombre.ForeColor = Color.DimGray;
                        txtMail.Text = "EMAIL";
                        txtMail.ForeColor = Color.DimGray;
                        txtContrasena.Text = "CONTRASEÑA";
                        txtContrasena.ForeColor = Color.DimGray;
                        checkAdmin.Checked = false;
                        MessageBox.Show("Se ha registrado de manera exitosa.");
                    }
                    else
                    {
                        MessageBox.Show("El email ya esta registrado");
                    }
                }
                else
                {
                    MessageBox.Show("El dni ya está registrado.");
                }
            }
            catch
            {
                MessageBox.Show("Error en el registro, por favor intentelo nuevamente.");
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

        private void cambiarIdioma_Click(object sender, EventArgs e)
        {
            if (VistaLogin.idioma == "Español")
            {
                cambiarIdioma.Text = "English";
                button1.Text = "Login";
                btnRegistrar.Text = "Register";
                txtUsuario.Text = "DNI";
                txtContrasena.Text = "PASSWORD";
                txtNombre.Text = "NAME";
                txtMail.Text = "EMAIL";
                checkAdmin.Text = "Is Admin?";
                button2.Text = "Register";
                label2.Text = "Register";
                VistaLogin.idioma = "English";
            }
            else if (VistaLogin.idioma == "English")
            {
                cambiarIdioma.Text = "Español";
                button1.Text = "Ingresar";
                btnRegistrar.Text = "Registrar";
                txtUsuario.Text = "DNI";
                txtContrasena.Text = "CONTRASEÑA";
                txtNombre.Text = "NOMBRE";
                txtMail.Text = "MAIL";
                checkAdmin.Text = "¿Es Admin?";
                button2.Text = "Registrarse";
                label2.Text = "Registrarse";
                VistaLogin.idioma = "Español";
            }
        }
        #endregion
    }
}
