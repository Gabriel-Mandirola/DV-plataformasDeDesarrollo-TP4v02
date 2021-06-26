using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using TP2_Grupo4.Models;
using TP2_Grupo4.Views;
using TP2_Grupo4;
using System.Runtime.InteropServices;

namespace TP2_Grupo4.Views
{
    public partial class VistaLogin : Form
    {
        private const int MAXIMA_CANTIDAD_DE_INTENTOS_PARA_LOGEARSE = 3;

        private int contadorDeIntentos;
        private int dniIngresado;

        private AgenciaManager agencia;

        public VistaLogin()
        {
            this.agencia = new AgenciaManager();
            this.contadorDeIntentos = 0;
            this.dniIngresado = 0;

            InitializeComponent();
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
        // TODO: Password *********
        private void txtContrasena_Enter(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "CONTRASEÑA")
            {
                txtContrasena.Text = "";
            }
        }
        private void txtContrasena_Leave(object sender, EventArgs e)
        {
            if (txtContrasena.Text == "")
            {
                txtContrasena.Text = "CONTRASEÑA";
            }
        }

        private void InputDNI_KeyUp(object sender, KeyEventArgs e)
        {
            String input = this.txtUsuario.Text;

            if (input == "") return;

            try
            {
                int dni = int.Parse(input);

                if (this.agencia.IsUsuarioBloqueado(dni))
                {
                    MessageBox.Show("Su usuario esta bloqueado. Contacte con un administrador");
                    this.btnLogin.Enabled = false;
                }
                else
                {
                    this.btnLogin.Enabled = true;
                    //System.Diagnostics.Debug.WriteLine("Usuario correcto y no esta bloqueado");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Solo puede ingresar numeros!");
                this.btnLogin.Enabled = false;
            }
        }
        private bool bloquearUsuarioPorIntentos(int dni)
        {
            if (this.dniIngresado != dni)
            {
                this.dniIngresado = dni;
                this.contadorDeIntentos = 1;
            }
            else if (this.dniIngresado == dni)
            {
                this.contadorDeIntentos++;
            }
            
            if (this.contadorDeIntentos >= VistaLogin.MAXIMA_CANTIDAD_DE_INTENTOS_PARA_LOGEARSE)
            {
                /*if (this.agencia.BloquearUsuario(dni) && this.agencia.GuardarCambiosDeLosUsuarios())
                {
                    MessageBox.Show("Has exedido el maximo de intentos. Tu usuario a sido bloqueado, contacte con un administrador");
                    this.txtUsuario.Text = "";
                    this.txtContrasena.Text = "";
                    return true;
                }*/
            }
            return false;
        }

        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
        /* ~~~~~~~~~~~~~~~~~~~~~~~~ BOTONES ~~~~~~~~~~~~~~~~~~~~~~~~ */
        /* ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~ */
        // TODO: Chequear intentos
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // admin
            // dni: 40393222
            // pass: admin1234
            int dni = int.Parse(txtUsuario.Text); // Validado con el metodo InputDNI
            String password = txtContrasena.Text;
            
            if (this.agencia.FindUserForDNI(dni) == null)
            {
                MessageBox.Show("No existe ese usuario");
                return;
            }
            
            // Al bloquear al usuario salgo del metodo con el return
            if (this.bloquearUsuarioPorIntentos(dni)) return;

            if(this.agencia.autenticarUsuario(dni, password))
            {
                Console.WriteLine("Es admin");
                if (this.agencia.GetUsuarioLogeado().IsAdmin)
                {
                    // ADMIN
                    
                    //VistaDashboardAdmin admin = new VistaDashboardAdmin(this.agencia);
                    //admin.Show();
                    //this.Hide();
                }
                else
                {
                    // USUARIO CLIENTE
                    //VistaDashboardCliente cliente = new VistaDashboardCliente(this.agencia);
                    //cliente.Show();
                    //this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Contraseña incorrecta");
            }
        }

        // TODO: Mostrar VistaRegistrar
        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            VistaRegistrar registrar = new VistaRegistrar();
            registrar.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        
        #region Helpers
        // Nos permite utilizar librerias del sistema operativo, para poder mover la ventana
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


        private void lblRecuperar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //VistaRecuperar recuperar = new VistaRecuperar();
            //recuperar.Show();
            //this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = false;
            pictureBox4.Visible = true;
            txtContrasena.UseSystemPasswordChar = false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox5.Visible = true;
            pictureBox4.Visible = false;
            txtContrasena.UseSystemPasswordChar = true;
        }
    }
}
