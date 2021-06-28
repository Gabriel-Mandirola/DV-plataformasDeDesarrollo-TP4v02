
namespace TP2_Grupo4.Views
{
    partial class VistaDashboardAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnUsuarios = new FontAwesome.Sharp.IconButton();
            this.btnReservas = new FontAwesome.Sharp.IconButton();
            this.panelAlojamientoSubmenu = new System.Windows.Forms.Panel();
            this.btnCabanias = new FontAwesome.Sharp.IconButton();
            this.btnHoteles = new FontAwesome.Sharp.IconButton();
            this.btnAlojamiento = new FontAwesome.Sharp.IconButton();
            this.btnCerrarSesion = new FontAwesome.Sharp.IconButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelRole = new System.Windows.Forms.Panel();
            this.lblRoleUser = new System.Windows.Forms.Label();
            this.pbUserRole = new FontAwesome.Sharp.IconPictureBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.cambiarIdioma = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelAlojamientoSubmenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelRole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserRole)).BeginInit();
            this.panelTop.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.AutoScroll = true;
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.btnUsuarios);
            this.panelMenu.Controls.Add(this.btnReservas);
            this.panelMenu.Controls.Add(this.panelAlojamientoSubmenu);
            this.panelMenu.Controls.Add(this.btnAlojamiento);
            this.panelMenu.Controls.Add(this.btnCerrarSesion);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(220, 641);
            this.panelMenu.TabIndex = 0;
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.AutoSize = true;
            this.btnUsuarios.BackColor = System.Drawing.Color.White;
            this.btnUsuarios.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUsuarios.FlatAppearance.BorderSize = 0;
            this.btnUsuarios.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsuarios.ForeColor = System.Drawing.Color.Black;
            this.btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.Users;
            this.btnUsuarios.IconColor = System.Drawing.Color.Black;
            this.btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnUsuarios.IconSize = 32;
            this.btnUsuarios.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsuarios.Location = new System.Drawing.Point(0, 388);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnUsuarios.Size = new System.Drawing.Size(220, 60);
            this.btnUsuarios.TabIndex = 5;
            this.btnUsuarios.Text = "Usuarios";
            this.btnUsuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUsuarios.UseVisualStyleBackColor = false;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // btnReservas
            // 
            this.btnReservas.AutoSize = true;
            this.btnReservas.BackColor = System.Drawing.Color.White;
            this.btnReservas.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReservas.FlatAppearance.BorderSize = 0;
            this.btnReservas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReservas.ForeColor = System.Drawing.Color.Black;
            this.btnReservas.IconChar = FontAwesome.Sharp.IconChar.Bookmark;
            this.btnReservas.IconColor = System.Drawing.Color.Black;
            this.btnReservas.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnReservas.IconSize = 32;
            this.btnReservas.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReservas.Location = new System.Drawing.Point(0, 328);
            this.btnReservas.Name = "btnReservas";
            this.btnReservas.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnReservas.Size = new System.Drawing.Size(220, 60);
            this.btnReservas.TabIndex = 4;
            this.btnReservas.Text = "Reservas";
            this.btnReservas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReservas.UseVisualStyleBackColor = false;
            this.btnReservas.Click += new System.EventHandler(this.btnReservas_Click);
            // 
            // panelAlojamientoSubmenu
            // 
            this.panelAlojamientoSubmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.panelAlojamientoSubmenu.Controls.Add(this.btnCabanias);
            this.panelAlojamientoSubmenu.Controls.Add(this.btnHoteles);
            this.panelAlojamientoSubmenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelAlojamientoSubmenu.Location = new System.Drawing.Point(0, 248);
            this.panelAlojamientoSubmenu.Name = "panelAlojamientoSubmenu";
            this.panelAlojamientoSubmenu.Size = new System.Drawing.Size(220, 80);
            this.panelAlojamientoSubmenu.TabIndex = 8;
            // 
            // btnCabanias
            // 
            this.btnCabanias.AutoSize = true;
            this.btnCabanias.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnCabanias.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCabanias.FlatAppearance.BorderSize = 0;
            this.btnCabanias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCabanias.ForeColor = System.Drawing.Color.Black;
            this.btnCabanias.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnCabanias.IconColor = System.Drawing.Color.Gainsboro;
            this.btnCabanias.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnCabanias.IconSize = 32;
            this.btnCabanias.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCabanias.Location = new System.Drawing.Point(0, 40);
            this.btnCabanias.Name = "btnCabanias";
            this.btnCabanias.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnCabanias.Size = new System.Drawing.Size(220, 40);
            this.btnCabanias.TabIndex = 3;
            this.btnCabanias.Text = "Cabañas";
            this.btnCabanias.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCabanias.UseVisualStyleBackColor = false;
            this.btnCabanias.Click += new System.EventHandler(this.btnCabanias_Click);
            // 
            // btnHoteles
            // 
            this.btnHoteles.AutoSize = true;
            this.btnHoteles.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.btnHoteles.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHoteles.FlatAppearance.BorderSize = 0;
            this.btnHoteles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoteles.ForeColor = System.Drawing.Color.Black;
            this.btnHoteles.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnHoteles.IconColor = System.Drawing.Color.Gainsboro;
            this.btnHoteles.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnHoteles.IconSize = 32;
            this.btnHoteles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoteles.Location = new System.Drawing.Point(0, 0);
            this.btnHoteles.Name = "btnHoteles";
            this.btnHoteles.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnHoteles.Size = new System.Drawing.Size(220, 40);
            this.btnHoteles.TabIndex = 2;
            this.btnHoteles.Text = "Hoteles";
            this.btnHoteles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHoteles.UseVisualStyleBackColor = false;
            this.btnHoteles.Click += new System.EventHandler(this.btnHoteles_Click);
            // 
            // btnAlojamiento
            // 
            this.btnAlojamiento.AutoSize = true;
            this.btnAlojamiento.BackColor = System.Drawing.Color.White;
            this.btnAlojamiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAlojamiento.FlatAppearance.BorderSize = 0;
            this.btnAlojamiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlojamiento.ForeColor = System.Drawing.Color.Black;
            this.btnAlojamiento.IconChar = FontAwesome.Sharp.IconChar.Hotel;
            this.btnAlojamiento.IconColor = System.Drawing.Color.Black;
            this.btnAlojamiento.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnAlojamiento.IconSize = 32;
            this.btnAlojamiento.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlojamiento.Location = new System.Drawing.Point(0, 188);
            this.btnAlojamiento.Name = "btnAlojamiento";
            this.btnAlojamiento.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnAlojamiento.Size = new System.Drawing.Size(220, 60);
            this.btnAlojamiento.TabIndex = 1;
            this.btnAlojamiento.Text = "Alojamientos";
            this.btnAlojamiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAlojamiento.UseVisualStyleBackColor = false;
            this.btnAlojamiento.Click += new System.EventHandler(this.btnAlojamiento_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.AutoSize = true;
            this.btnCerrarSesion.BackColor = System.Drawing.Color.White;
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            this.btnCerrarSesion.IconColor = System.Drawing.Color.Black;
            this.btnCerrarSesion.IconFont = FontAwesome.Sharp.IconFont.Solid;
            this.btnCerrarSesion.IconSize = 32;
            this.btnCerrarSesion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 581);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.btnCerrarSesion.Size = new System.Drawing.Size(220, 60);
            this.btnCerrarSesion.TabIndex = 6;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.White;
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Controls.Add(this.panelDesktop);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(220, 188);
            this.panelLogo.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Image = global::TP2_Grupo4.Properties.Resources.alojamientos;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 188);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelDesktop
            // 
            this.panelDesktop.BackColor = System.Drawing.Color.LightGray;
            this.panelDesktop.Location = new System.Drawing.Point(220, 76);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(613, 377);
            this.panelDesktop.TabIndex = 0;
            // 
            // panelRole
            // 
            this.panelRole.BackColor = System.Drawing.Color.Black;
            this.panelRole.Controls.Add(this.lblRoleUser);
            this.panelRole.Controls.Add(this.pbUserRole);
            this.panelRole.Controls.Add(this.lblRole);
            this.panelRole.Location = new System.Drawing.Point(0, 0);
            this.panelRole.Name = "panelRole";
            this.panelRole.Size = new System.Drawing.Size(218, 79);
            this.panelRole.TabIndex = 0;
            // 
            // lblRoleUser
            // 
            this.lblRoleUser.AutoSize = true;
            this.lblRoleUser.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblRoleUser.Location = new System.Drawing.Point(92, 26);
            this.lblRoleUser.Name = "lblRoleUser";
            this.lblRoleUser.Size = new System.Drawing.Size(50, 15);
            this.lblRoleUser.TabIndex = 0;
            this.lblRoleUser.Text = "roleUser";
            // 
            // pbUserRole
            // 
            this.pbUserRole.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.pbUserRole.IconColor = System.Drawing.Color.White;
            this.pbUserRole.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.pbUserRole.Location = new System.Drawing.Point(18, 20);
            this.pbUserRole.Name = "pbUserRole";
            this.pbUserRole.Size = new System.Drawing.Size(32, 32);
            this.pbUserRole.TabIndex = 1;
            this.pbUserRole.TabStop = false;
            // 
            // lblRole
            // 
            this.lblRole.AutoSize = true;
            this.lblRole.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblRole.Location = new System.Drawing.Point(53, 26);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(33, 15);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "role: ";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.Black;
            this.panelTop.Controls.Add(this.cambiarIdioma);
            this.panelTop.Controls.Add(this.panelRole);
            this.panelTop.Controls.Add(this.flowLayoutPanel1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(220, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1000, 70);
            this.panelTop.TabIndex = 0;
            this.panelTop.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTop_MouseDown);
            // 
            // cambiarIdioma
            // 
            this.cambiarIdioma.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.cambiarIdioma.FlatAppearance.BorderSize = 0;
            this.cambiarIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cambiarIdioma.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cambiarIdioma.ForeColor = System.Drawing.SystemColors.Info;
            this.cambiarIdioma.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cambiarIdioma.Location = new System.Drawing.Point(583, 16);
            this.cambiarIdioma.Name = "cambiarIdioma";
            this.cambiarIdioma.Size = new System.Drawing.Size(111, 41);
            this.cambiarIdioma.TabIndex = 0;
            this.cambiarIdioma.Text = "English";
            this.cambiarIdioma.UseVisualStyleBackColor = false;
            this.cambiarIdioma.Click += new System.EventHandler(this.cambiarIdioma_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnExit);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(958, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(42, 70);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnExit
            // 
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExit.IconSize = 20;
            this.btnExit.Location = new System.Drawing.Point(3, 3);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(39, 23);
            this.btnExit.TabIndex = 0;
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.panelMain.Cursor = System.Windows.Forms.Cursors.Default;
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(220, 70);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1000, 571);
            this.panelMain.TabIndex = 0;
            // 
            // VistaDashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 641);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panelMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VistaDashboardAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.panelAlojamientoSubmenu.ResumeLayout(false);
            this.panelAlojamientoSubmenu.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelRole.ResumeLayout(false);
            this.panelRole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbUserRole)).EndInit();
            this.panelTop.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel panelMain;
        private FontAwesome.Sharp.IconButton btnCerrarSesion;
        private FontAwesome.Sharp.IconButton btnAlojamiento;
        private System.Windows.Forms.Panel panelRole;
        private System.Windows.Forms.Label lblRole;
        private FontAwesome.Sharp.IconPictureBox pbUserRole;
        private System.Windows.Forms.Label lblRoleUser;
        private FontAwesome.Sharp.IconButton btnUsuarios;
        private FontAwesome.Sharp.IconButton btnReservas;
        private System.Windows.Forms.Panel panelAlojamientoSubmenu;
        private FontAwesome.Sharp.IconButton btnCabanias;
        private FontAwesome.Sharp.IconButton btnHoteles;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.Button cambiarIdioma;
    }
}