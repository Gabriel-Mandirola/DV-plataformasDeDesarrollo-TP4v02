
namespace TP2_Grupo4.Views
{
    partial class VistaAdminHoteles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvHoteles = new System.Windows.Forms.DataGridView();
            this.panelHoteles = new System.Windows.Forms.Panel();
            this.laberHerrorHoteles = new System.Windows.Forms.Label();
            this.lblHoteles = new System.Windows.Forms.Label();
            this.groupBoxHoteles = new System.Windows.Forms.GroupBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnTopModificar = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBoxTv = new System.Windows.Forms.CheckBox();
            this.txtCiudad = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBarrio = new System.Windows.Forms.TextBox();
            this.comboBoxCantPersonas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnTopAgregar = new System.Windows.Forms.Button();
            this.comboBoxEstrellas = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoteles)).BeginInit();
            this.panelHoteles.SuspendLayout();
            this.groupBoxHoteles.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvHoteles
            // 
            this.dgvHoteles.AllowUserToAddRows = false;
            this.dgvHoteles.AllowUserToResizeColumns = false;
            this.dgvHoteles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHoteles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvHoteles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvHoteles.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvHoteles.Location = new System.Drawing.Point(12, 263);
            this.dgvHoteles.Name = "dgvHoteles";
            this.dgvHoteles.RowTemplate.Height = 25;
            this.dgvHoteles.Size = new System.Drawing.Size(976, 287);
            this.dgvHoteles.TabIndex = 0;
            this.dgvHoteles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHoteles_CellContentClick);
            // 
            // panelHoteles
            // 
            this.panelHoteles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.panelHoteles.Controls.Add(this.laberHerrorHoteles);
            this.panelHoteles.Controls.Add(this.lblHoteles);
            this.panelHoteles.Controls.Add(this.groupBoxHoteles);
            this.panelHoteles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelHoteles.Location = new System.Drawing.Point(0, 0);
            this.panelHoteles.Name = "panelHoteles";
            this.panelHoteles.Size = new System.Drawing.Size(1000, 562);
            this.panelHoteles.TabIndex = 4;
            // 
            // laberHerrorHoteles
            // 
            this.laberHerrorHoteles.AutoSize = true;
            this.laberHerrorHoteles.Location = new System.Drawing.Point(187, 242);
            this.laberHerrorHoteles.Name = "laberHerrorHoteles";
            this.laberHerrorHoteles.Size = new System.Drawing.Size(19, 15);
            this.laberHerrorHoteles.TabIndex = 14;
            this.laberHerrorHoteles.Text = "    ";
            // 
            // lblHoteles
            // 
            this.lblHoteles.AutoSize = true;
            this.lblHoteles.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblHoteles.ForeColor = System.Drawing.Color.Black;
            this.lblHoteles.Location = new System.Drawing.Point(422, 7);
            this.lblHoteles.Name = "lblHoteles";
            this.lblHoteles.Size = new System.Drawing.Size(157, 45);
            this.lblHoteles.TabIndex = 13;
            this.lblHoteles.Text = "Hoteles";
            // 
            // groupBoxHoteles
            // 
            this.groupBoxHoteles.Controls.Add(this.txtCodigo);
            this.groupBoxHoteles.Controls.Add(this.btnTopModificar);
            this.groupBoxHoteles.Controls.Add(this.label10);
            this.groupBoxHoteles.Controls.Add(this.checkBoxTv);
            this.groupBoxHoteles.Controls.Add(this.txtCiudad);
            this.groupBoxHoteles.Controls.Add(this.label7);
            this.groupBoxHoteles.Controls.Add(this.txtPrecio);
            this.groupBoxHoteles.Controls.Add(this.label3);
            this.groupBoxHoteles.Controls.Add(this.txtBarrio);
            this.groupBoxHoteles.Controls.Add(this.comboBoxCantPersonas);
            this.groupBoxHoteles.Controls.Add(this.label2);
            this.groupBoxHoteles.Controls.Add(this.label5);
            this.groupBoxHoteles.Controls.Add(this.label4);
            this.groupBoxHoteles.Controls.Add(this.btnTopAgregar);
            this.groupBoxHoteles.Controls.Add(this.comboBoxEstrellas);
            this.groupBoxHoteles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxHoteles.ForeColor = System.Drawing.Color.Black;
            this.groupBoxHoteles.Location = new System.Drawing.Point(73, 108);
            this.groupBoxHoteles.Name = "groupBoxHoteles";
            this.groupBoxHoteles.Size = new System.Drawing.Size(842, 117);
            this.groupBoxHoteles.TabIndex = 0;
            this.groupBoxHoteles.TabStop = false;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(114, 19);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(121, 23);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodigo_KeyPress);
            // 
            // btnTopModificar
            // 
            this.btnTopModificar.BackColor = System.Drawing.Color.White;
            this.btnTopModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopModificar.ForeColor = System.Drawing.Color.Black;
            this.btnTopModificar.Location = new System.Drawing.Point(700, 32);
            this.btnTopModificar.Name = "btnTopModificar";
            this.btnTopModificar.Size = new System.Drawing.Size(106, 63);
            this.btnTopModificar.TabIndex = 8;
            this.btnTopModificar.Text = "Modificar";
            this.btnTopModificar.UseVisualStyleBackColor = false;
            this.btnTopModificar.Click += new System.EventHandler(this.btnTopModificar_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(60, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(49, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Código:";
            // 
            // checkBoxTv
            // 
            this.checkBoxTv.AutoSize = true;
            this.checkBoxTv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxTv.Location = new System.Drawing.Point(316, 86);
            this.checkBoxTv.Name = "checkBoxTv";
            this.checkBoxTv.Size = new System.Drawing.Size(78, 19);
            this.checkBoxTv.TabIndex = 6;
            this.checkBoxTv.Text = "¿Tiene Tv?";
            this.checkBoxTv.UseVisualStyleBackColor = true;
            // 
            // txtCiudad
            // 
            this.txtCiudad.Location = new System.Drawing.Point(114, 53);
            this.txtCiudad.Name = "txtCiudad";
            this.txtCiudad.Size = new System.Drawing.Size(121, 23);
            this.txtCiudad.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(60, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Ciudad:";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(531, 19);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(100, 23);
            this.txtPrecio.TabIndex = 7;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(485, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Precio";
            // 
            // txtBarrio
            // 
            this.txtBarrio.Location = new System.Drawing.Point(114, 84);
            this.txtBarrio.Name = "txtBarrio";
            this.txtBarrio.Size = new System.Drawing.Size(121, 23);
            this.txtBarrio.TabIndex = 3;
            // 
            // comboBoxCantPersonas
            // 
            this.comboBoxCantPersonas.BackColor = System.Drawing.Color.White;
            this.comboBoxCantPersonas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCantPersonas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxCantPersonas.FormattingEnabled = true;
            this.comboBoxCantPersonas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.comboBoxCantPersonas.Location = new System.Drawing.Point(380, 19);
            this.comboBoxCantPersonas.Name = "comboBoxCantPersonas";
            this.comboBoxCantPersonas.Size = new System.Drawing.Size(65, 23);
            this.comboBoxCantPersonas.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(253, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Cantidad de Personas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(325, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Estrellas";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Barrio:";
            // 
            // btnTopAgregar
            // 
            this.btnTopAgregar.BackColor = System.Drawing.Color.White;
            this.btnTopAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTopAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnTopAgregar.Location = new System.Drawing.Point(700, 32);
            this.btnTopAgregar.Name = "btnTopAgregar";
            this.btnTopAgregar.Size = new System.Drawing.Size(106, 63);
            this.btnTopAgregar.TabIndex = 10;
            this.btnTopAgregar.Text = "Agregar";
            this.btnTopAgregar.UseVisualStyleBackColor = false;
            this.btnTopAgregar.Click += new System.EventHandler(this.btnTopAgregar_Click);
            // 
            // comboBoxEstrellas
            // 
            this.comboBoxEstrellas.BackColor = System.Drawing.Color.White;
            this.comboBoxEstrellas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEstrellas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxEstrellas.FormattingEnabled = true;
            this.comboBoxEstrellas.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxEstrellas.Location = new System.Drawing.Point(380, 53);
            this.comboBoxEstrellas.Name = "comboBoxEstrellas";
            this.comboBoxEstrellas.Size = new System.Drawing.Size(53, 23);
            this.comboBoxEstrellas.TabIndex = 5;
            // 
            // VistaAdminHoteles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(4)))), ((int)(((byte)(80)))));
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.dgvHoteles);
            this.Controls.Add(this.panelHoteles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VistaAdminHoteles";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormHoteles";
            this.Load += new System.EventHandler(this.FormHoteles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHoteles)).EndInit();
            this.panelHoteles.ResumeLayout(false);
            this.panelHoteles.PerformLayout();
            this.groupBoxHoteles.ResumeLayout(false);
            this.groupBoxHoteles.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvHoteles;
        private System.Windows.Forms.Panel panelHoteles;
        private System.Windows.Forms.Label lblHoteles;
        private System.Windows.Forms.GroupBox groupBoxHoteles;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnTopModificar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox checkBoxTv;
        private System.Windows.Forms.TextBox txtCiudad;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtBarrio;
        private System.Windows.Forms.ComboBox comboBoxCantPersonas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnTopAgregar;
        private System.Windows.Forms.ComboBox comboBoxEstrellas;
        private System.Windows.Forms.Label laberHerrorHoteles;
    }
}