
namespace TP2_Grupo4.Views
{
    partial class VistaAlojamientosCliente
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
            this.dgvAlojamiento = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.inputPrecioMax = new System.Windows.Forms.TextBox();
            this.lblPrecioMax = new System.Windows.Forms.Label();
            this.selectBarrio = new System.Windows.Forms.ComboBox();
            this.selectCiudad = new System.Windows.Forms.ComboBox();
            this.inputPrecioMin = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPrecioMin = new System.Windows.Forms.Label();
            this.selectCantPersonas = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.selectEstrellas = new System.Windows.Forms.ComboBox();
            this.selectTipoAlojamiento = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.selectOrdenamiento = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalDeDias = new System.Windows.Forms.Label();
            this.lblDiasDeReservas = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.inputDateFechaVuelta = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.inputDateFechaIda = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlojamiento)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAlojamiento
            // 
            this.dgvAlojamiento.AllowUserToAddRows = false;
            this.dgvAlojamiento.AllowUserToResizeColumns = false;
            this.dgvAlojamiento.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAlojamiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlojamiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAlojamiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlojamiento.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAlojamiento.Location = new System.Drawing.Point(58, 230);
            this.dgvAlojamiento.Name = "dgvAlojamiento";
            this.dgvAlojamiento.RowHeadersVisible = false;
            this.dgvAlojamiento.RowTemplate.Height = 25;
            this.dgvAlojamiento.Size = new System.Drawing.Size(901, 320);
            this.dgvAlojamiento.TabIndex = 0;
            this.dgvAlojamiento.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlojamiento_CellContentClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.inputPrecioMax);
            this.groupBox1.Controls.Add(this.lblPrecioMax);
            this.groupBox1.Controls.Add(this.selectBarrio);
            this.groupBox1.Controls.Add(this.selectCiudad);
            this.groupBox1.Controls.Add(this.inputPrecioMin);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblPrecioMin);
            this.groupBox1.Controls.Add(this.selectCantPersonas);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnFiltrar);
            this.groupBox1.Controls.Add(this.selectEstrellas);
            this.groupBox1.Controls.Add(this.selectTipoAlojamiento);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(59, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(900, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtrar por:";
            // 
            // inputPrecioMax
            // 
            this.inputPrecioMax.Location = new System.Drawing.Point(329, 61);
            this.inputPrecioMax.MaxLength = 30000;
            this.inputPrecioMax.Name = "inputPrecioMax";
            this.inputPrecioMax.Size = new System.Drawing.Size(60, 23);
            this.inputPrecioMax.TabIndex = 5;
            this.inputPrecioMax.Text = "0";
            this.inputPrecioMax.TextChanged += new System.EventHandler(this.inputPrecioMax_TextChanged);
            // 
            // lblPrecioMax
            // 
            this.lblPrecioMax.AutoSize = true;
            this.lblPrecioMax.Location = new System.Drawing.Point(254, 64);
            this.lblPrecioMax.Name = "lblPrecioMax";
            this.lblPrecioMax.Size = new System.Drawing.Size(69, 15);
            this.lblPrecioMax.TabIndex = 0;
            this.lblPrecioMax.Text = "Precio Max:";
            // 
            // selectBarrio
            // 
            this.selectBarrio.FormattingEnabled = true;
            this.selectBarrio.Location = new System.Drawing.Point(540, 22);
            this.selectBarrio.Name = "selectBarrio";
            this.selectBarrio.Size = new System.Drawing.Size(100, 23);
            this.selectBarrio.TabIndex = 3;
            // 
            // selectCiudad
            // 
            this.selectCiudad.FormattingEnabled = true;
            this.selectCiudad.Location = new System.Drawing.Point(329, 22);
            this.selectCiudad.Name = "selectCiudad";
            this.selectCiudad.Size = new System.Drawing.Size(124, 23);
            this.selectCiudad.TabIndex = 2;
            // 
            // inputPrecioMin
            // 
            this.inputPrecioMin.Location = new System.Drawing.Point(155, 61);
            this.inputPrecioMin.MaxLength = 30000;
            this.inputPrecioMin.Name = "inputPrecioMin";
            this.inputPrecioMin.Size = new System.Drawing.Size(75, 23);
            this.inputPrecioMin.TabIndex = 4;
            this.inputPrecioMin.Text = "0";
            this.inputPrecioMin.TextChanged += new System.EventHandler(this.inputPrecioMin_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(493, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Barrio:";
            // 
            // lblPrecioMin
            // 
            this.lblPrecioMin.AutoSize = true;
            this.lblPrecioMin.Location = new System.Drawing.Point(82, 64);
            this.lblPrecioMin.Name = "lblPrecioMin";
            this.lblPrecioMin.Size = new System.Drawing.Size(67, 15);
            this.lblPrecioMin.TabIndex = 0;
            this.lblPrecioMin.Text = "Precio Min:";
            // 
            // selectCantPersonas
            // 
            this.selectCantPersonas.FormattingEnabled = true;
            this.selectCantPersonas.Location = new System.Drawing.Point(589, 61);
            this.selectCantPersonas.Name = "selectCantPersonas";
            this.selectCantPersonas.Size = new System.Drawing.Size(51, 23);
            this.selectCantPersonas.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(526, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Personas:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(406, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Estrella:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(275, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Ciudad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo:";
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.White;
            this.btnFiltrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFiltrar.ForeColor = System.Drawing.Color.Black;
            this.btnFiltrar.Location = new System.Drawing.Point(701, 18);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(146, 68);
            this.btnFiltrar.TabIndex = 8;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // selectEstrellas
            // 
            this.selectEstrellas.FormattingEnabled = true;
            this.selectEstrellas.Location = new System.Drawing.Point(459, 61);
            this.selectEstrellas.Name = "selectEstrellas";
            this.selectEstrellas.Size = new System.Drawing.Size(55, 23);
            this.selectEstrellas.TabIndex = 6;
            // 
            // selectTipoAlojamiento
            // 
            this.selectTipoAlojamiento.FormattingEnabled = true;
            this.selectTipoAlojamiento.Location = new System.Drawing.Point(155, 22);
            this.selectTipoAlojamiento.Name = "selectTipoAlojamiento";
            this.selectTipoAlojamiento.Size = new System.Drawing.Size(95, 23);
            this.selectTipoAlojamiento.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.selectOrdenamiento);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(634, 116);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ordenar por:";
            // 
            // selectOrdenamiento
            // 
            this.selectOrdenamiento.FormattingEnabled = true;
            this.selectOrdenamiento.Location = new System.Drawing.Point(126, 40);
            this.selectOrdenamiento.Name = "selectOrdenamiento";
            this.selectOrdenamiento.Size = new System.Drawing.Size(150, 23);
            this.selectOrdenamiento.TabIndex = 11;
            this.selectOrdenamiento.SelectedIndexChanged += new System.EventHandler(this.selectOrdenamiento_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 43);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Ordenar por:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblTotalDeDias);
            this.groupBox3.Controls.Add(this.lblDiasDeReservas);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.inputDateFechaVuelta);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.inputDateFechaIda);
            this.groupBox3.Location = new System.Drawing.Point(59, 116);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(560, 100);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Fechas:";
            // 
            // lblTotalDeDias
            // 
            this.lblTotalDeDias.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalDeDias.Location = new System.Drawing.Point(479, 38);
            this.lblTotalDeDias.Name = "lblTotalDeDias";
            this.lblTotalDeDias.Size = new System.Drawing.Size(38, 37);
            this.lblTotalDeDias.TabIndex = 0;
            this.lblTotalDeDias.Text = "1";
            this.lblTotalDeDias.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblDiasDeReservas
            // 
            this.lblDiasDeReservas.AutoSize = true;
            this.lblDiasDeReservas.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDiasDeReservas.Location = new System.Drawing.Point(412, 40);
            this.lblDiasDeReservas.Name = "lblDiasDeReservas";
            this.lblDiasDeReservas.Size = new System.Drawing.Size(66, 32);
            this.lblDiasDeReservas.TabIndex = 0;
            this.lblDiasDeReservas.Text = "Dias:";
            this.lblDiasDeReservas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(56, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Fecha de vuelta:";
            // 
            // inputDateFechaVuelta
            // 
            this.inputDateFechaVuelta.Location = new System.Drawing.Point(156, 64);
            this.inputDateFechaVuelta.MaxDate = new System.DateTime(2022, 3, 1, 0, 0, 0, 0);
            this.inputDateFechaVuelta.MinDate = new System.DateTime(2021, 5, 15, 0, 0, 0, 0);
            this.inputDateFechaVuelta.Name = "inputDateFechaVuelta";
            this.inputDateFechaVuelta.Size = new System.Drawing.Size(214, 23);
            this.inputDateFechaVuelta.TabIndex = 10;
            this.inputDateFechaVuelta.Value = new System.DateTime(2021, 5, 15, 0, 0, 0, 0);
            this.inputDateFechaVuelta.ValueChanged += new System.EventHandler(this.inputDateFechaVuelta_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Fecha de ida:";
            // 
            // inputDateFechaIda
            // 
            this.inputDateFechaIda.Location = new System.Drawing.Point(156, 22);
            this.inputDateFechaIda.MaxDate = new System.DateTime(2022, 12, 30, 0, 0, 0, 0);
            this.inputDateFechaIda.MinDate = new System.DateTime(2021, 5, 14, 0, 0, 0, 0);
            this.inputDateFechaIda.Name = "inputDateFechaIda";
            this.inputDateFechaIda.Size = new System.Drawing.Size(214, 23);
            this.inputDateFechaIda.TabIndex = 9;
            this.inputDateFechaIda.Value = new System.DateTime(2021, 5, 14, 0, 0, 0, 0);
            this.inputDateFechaIda.ValueChanged += new System.EventHandler(this.inputDateFechaIda_ValueChanged);
            // 
            // VistaAlojamientosCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvAlojamiento);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VistaAlojamientosCliente";
            this.Text = "VistaAlojamientosCliente";
            this.Load += new System.EventHandler(this.VistaAlojamientosCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlojamiento)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAlojamiento;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox selectCantPersonas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.ComboBox selectEstrellas;
        private System.Windows.Forms.ComboBox selectTipoAlojamiento;
        private System.Windows.Forms.TextBox inputPrecioMin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblPrecioMin;
        private System.Windows.Forms.ComboBox selectCiudad;
        private System.Windows.Forms.TextBox inputPrecioMax;
        private System.Windows.Forms.Label lblPrecioMax;
        private System.Windows.Forms.ComboBox selectBarrio;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker inputDateFechaIda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker inputDateFechaVuelta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox selectOrdenamiento;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblDiasDeReservas;
        private System.Windows.Forms.Label lblTotalDeDias;
    }
}