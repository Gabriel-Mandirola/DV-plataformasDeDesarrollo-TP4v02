using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using FontAwesome.Sharp;
using TP2_Grupo4.Views.Cliente;

namespace TP2_Grupo4.Views
{
    public partial class VistaDashboardCliente : Form
    {
        // Atributos
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;

        private AgenciaManager agencia;
        public static string idioma;
        private int num;

        public VistaDashboardCliente(AgenciaManager agenciaManager)
        {
            InitializeComponent();
            this.leftBorderBtn = new Panel();
            this.leftBorderBtn.Size = new Size(7, 60);
            this.agencia = agenciaManager;
            panelMenu.Controls.Add(leftBorderBtn);

            // HEADER 
            this.lblDNIUser.Text = agenciaManager.GetUsuarioLogeado().GetDni().ToString();
            this.lblNameUser.Text = agenciaManager.GetUsuarioLogeado().GetNombre();

            //FORM
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            this.OpenChildForm(new VistaHome());
        }

        private void OpenChildForm(Form childForm)
        {

            if (this.currentChildForm != null)
            {
                this.currentChildForm.Close();
            }

            this.currentChildForm = childForm;
            this.currentChildForm.TopLevel = false;
            this.currentChildForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(this.currentChildForm);
            panelMain.Tag = currentChildForm;
            this.currentChildForm.Show();
        }

        #region On Click
        // BUSCADOR
        private void btnBuscador_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.secondary);
            OpenChildForm(new VistaBuscadorCliente(this.agencia, idioma));
            num = 1;
        }
        // VER ALOJAMIENTOS
        private void btnAlojamiento_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.secondary);
            OpenChildForm(new VistaAlojamientosCliente(this.agencia, idioma));
            num = 2;
        }

        // MIS RESERVAS
        private void btnReservas_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.secondary);
            OpenChildForm(new VistaReservasCliente(this.agencia, idioma));
            num = 3;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            VistaLogin vistaLogin = new VistaLogin();
            this.agencia.CerrarSession();
            vistaLogin.Show();
            this.Hide();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cambiarIdioma_Click(object sender, EventArgs e)
        {
            if (cambiarIdioma.Text == "English")
            {
                cambiarIdioma.Text = "Español";
                label2.Text = "Name:";
                Form.Text = "Searcher";
                btnAlojamiento.Text = "View Lodgings";
                btnReservas.Text = "My Reservations";
                btnCerrarSesion.Text = "Sign Off";
                idioma = "English";
                if (num == 1)
                {
                    OpenChildForm(new VistaBuscadorCliente(this.agencia, idioma));
                }
                if (num == 2)
                {
                    OpenChildForm(new VistaAlojamientosCliente(this.agencia, idioma));
                }
                if (num == 3)
                {
                    OpenChildForm(new VistaReservasCliente(this.agencia, idioma));
                }
            }
            else if (cambiarIdioma.Text == "Español")
            {
                cambiarIdioma.Text = "English";
                label2.Text = "Nombre:";
                Form.Text = "Buscador";
                btnAlojamiento.Text = "Ver Alojamientos";
                btnReservas.Text = "Mis Reservas";
                btnCerrarSesion.Text = "Cerrar Sesión";
                idioma = "Español";
                if (num == 1)
                {
                    OpenChildForm(new VistaBuscadorCliente(this.agencia, idioma));
                }
                if (num == 2)
                {
                    OpenChildForm(new VistaAlojamientosCliente(this.agencia, idioma));
                }
                if (num == 3)
                {
                    OpenChildForm(new VistaReservasCliente(this.agencia, idioma));
                }
            }
        }
        #endregion

        #region Helpers
        private void ActivateButton(object sender, Color color)
        {
            if (sender != null)
            {
                DisableButton();
                this.currentBtn = (IconButton)sender;
                this.currentBtn.BackColor = Color.FromArgb(20, 33, 61);
                this.currentBtn.ForeColor = color;
                this.currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                this.currentBtn.IconColor = color;
                //this.currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                //this.currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, this.currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();
            }
        }
        private void DisableButton()
        {
            if (this.currentBtn != null)
            {
                this.currentBtn.BackColor = Color.White;
                this.currentBtn.ForeColor = Color.Black;
                this.currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                this.currentBtn.IconColor = Color.Black;
                //this.currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                this.currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        // Variables de colores
        private struct RGBColors
        {
            public static Color primary = Color.White;
            public static Color secondary = Color.FromArgb(163, 221, 203);
        }

        // Nos permite utilizar librerias del sistema operativo, para poder mover la ventana
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
    }
}
