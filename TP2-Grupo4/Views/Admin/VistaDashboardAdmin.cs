using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using FontAwesome.Sharp;
using TP2_Grupo4.Views;
using TP2_Grupo4;

namespace TP2_Grupo4.Views
{
    public partial class VistaDashboardAdmin : Form
    {
        // Atributos
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        private AgenciaManager agencia;
        public static string idioma;
        private int num;

        public VistaDashboardAdmin(AgenciaManager userLogged)
        {
            InitializeComponent();
            this.leftBorderBtn = new Panel();
            this.leftBorderBtn.Size = new Size(7, 60);
            this.agencia = userLogged;
            panelMenu.Controls.Add(leftBorderBtn);

            panelAlojamientoSubmenu.Visible = false;
            lblRoleUser.Text = userLogged.GetUsuarioLogeado().Nombre;

            //FORM
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            OpenChildForm(new VistaHome());
            hideSubMenu();
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


        #region onClick Buttons
        private void btnAlojamiento_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, RGBColors.secondary);
            OpenChildForm(new VistaAdminAlojamiento(idioma));
            showSubMenu(panelAlojamientoSubmenu);
            num = 1;
        }

        private void btnHoteles_Click(object sender, EventArgs e)
        {
            OpenChildForm(new VistaAdminHoteles(idioma));
            num = 2;
        }

        private void btnCabanias_Click(object sender, EventArgs e)
        {
            OpenChildForm(new VistaAdminCabanias(idioma));
            num = 3;
        }

        // TODO: Mostrar Reservas
        private void btnReservas_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.secondary);
            OpenChildForm(new VistaAdminReservas(idioma));
            num = 4;
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            ActivateButton(sender, RGBColors.secondary);
            OpenChildForm(new VistaAdminUsuario(idioma));
            num = 5;
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
                this.currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                this.currentBtn.IconColor = color;
                //this.currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                this.currentBtn.ImageAlign = ContentAlignment.MiddleRight;

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

        // Menu Helpers
        private void hideSubMenu()
        {
            if (panelAlojamientoSubmenu.Visible == true)
                panelAlojamientoSubmenu.Visible = false;
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
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

        private void cambiarIdioma_Click(object sender, EventArgs e)
        {
            if (cambiarIdioma.Text == "English")
            {
                cambiarIdioma.Text = "Español";
                btnAlojamiento.Text = "Lodgings";
                btnHoteles.Text = "Hotels";
                btnCabanias.Text = "Cottage";
                btnReservas.Text = "Bookings";
                btnUsuarios.Text = "Users";
                btnCerrarSesion.Text = "Sign Off";
                idioma = "English";
                if (num == 1)
                {
                    OpenChildForm(new VistaAdminAlojamiento(idioma));
                }
                if (num == 2)
                {
                    OpenChildForm(new VistaAdminHoteles(idioma));
                }
                if (num == 3)
                {
                    OpenChildForm(new VistaAdminCabanias(idioma));
                }
                if (num == 4)
                {
                    OpenChildForm(new VistaAdminReservas(idioma));
                }
                if(num == 5)
                {
                    OpenChildForm(new VistaAdminUsuario(idioma));
                }
            }
            else if (cambiarIdioma.Text == "Español")
            {
                cambiarIdioma.Text = "English";
                btnAlojamiento.Text = "Alojamientos";
                btnHoteles.Text = "Hoteles";
                btnCabanias.Text = "Cabañas";
                btnReservas.Text = "Reservas";
                btnUsuarios.Text = "Usuarios";
                btnCerrarSesion.Text = "Cerrar Sesión";
                idioma = "Español";
                if (num == 1)
                {
                    OpenChildForm(new VistaAdminAlojamiento(idioma));
                }
                if (num == 2)
                {
                    OpenChildForm(new VistaAdminHoteles(idioma));
                }
                if (num == 3)
                {
                    OpenChildForm(new VistaAdminCabanias(idioma));
                }
                if (num == 4)
                {
                    OpenChildForm(new VistaAdminReservas(idioma));
                }
                if (num == 5)
                {
                    OpenChildForm(new VistaAdminUsuario(idioma));
                }
            }
        }
    }
}
