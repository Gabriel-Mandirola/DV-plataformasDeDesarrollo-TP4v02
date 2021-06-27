
namespace TP2_Grupo4.Views.Cliente
{
    partial class VistaBuscadorCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewAlojamientos = new System.Windows.Forms.DataGridView();
            this.codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ciudad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barrio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estrellas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDePersonas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tv = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblBuscador = new System.Windows.Forms.Label();
            this.groupBoxBuscador = new System.Windows.Forms.GroupBox();
            this.lblDateTimeHasta = new System.Windows.Forms.Label();
            this.lblDateTimeDesde = new System.Windows.Forms.Label();
            this.dateTimeHasta = new System.Windows.Forms.DateTimePicker();
            this.dateTimeDesde = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.inputBuscador = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlojamientos)).BeginInit();
            this.groupBoxBuscador.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewAlojamientos
            // 
            this.dataGridViewAlojamientos.AllowUserToAddRows = false;
            this.dataGridViewAlojamientos.AllowUserToDeleteRows = false;
            this.dataGridViewAlojamientos.AllowUserToResizeColumns = false;
            this.dataGridViewAlojamientos.AllowUserToResizeRows = false;
            this.dataGridViewAlojamientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAlojamientos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewAlojamientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAlojamientos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codigo,
            this.tipo,
            this.ciudad,
            this.barrio,
            this.estrellas,
            this.cantidadDePersonas,
            this.tv,
            this.precio});
            this.dataGridViewAlojamientos.Location = new System.Drawing.Point(50, 140);
            this.dataGridViewAlojamientos.Name = "dataGridViewAlojamientos";
            this.dataGridViewAlojamientos.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewAlojamientos.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewAlojamientos.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewAlojamientos.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewAlojamientos.RowTemplate.Height = 25;
            this.dataGridViewAlojamientos.Size = new System.Drawing.Size(900, 380);
            this.dataGridViewAlojamientos.TabIndex = 0;
            this.dataGridViewAlojamientos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAlojamientos_CellContentClick);
            // 
            // codigo
            // 
            this.codigo.HeaderText = "codigo";
            this.codigo.Name = "codigo";
            this.codigo.ReadOnly = true;
            this.codigo.Visible = false;
            // 
            // tipo
            // 
            this.tipo.HeaderText = "Tipo";
            this.tipo.Name = "tipo";
            this.tipo.ReadOnly = true;
            // 
            // ciudad
            // 
            this.ciudad.HeaderText = "Ciudad";
            this.ciudad.Name = "ciudad";
            this.ciudad.ReadOnly = true;
            // 
            // barrio
            // 
            this.barrio.HeaderText = "Barrio";
            this.barrio.Name = "barrio";
            this.barrio.ReadOnly = true;
            // 
            // estrellas
            // 
            this.estrellas.HeaderText = "Estrellas";
            this.estrellas.Name = "estrellas";
            this.estrellas.ReadOnly = true;
            // 
            // cantidadDePersonas
            // 
            this.cantidadDePersonas.HeaderText = "Cantidad de personas";
            this.cantidadDePersonas.Name = "cantidadDePersonas";
            this.cantidadDePersonas.ReadOnly = true;
            // 
            // tv
            // 
            this.tv.HeaderText = "TV";
            this.tv.Name = "tv";
            this.tv.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            this.precio.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.precio.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // lblBuscador
            // 
            this.lblBuscador.AutoSize = true;
            this.lblBuscador.Location = new System.Drawing.Point(24, 38);
            this.lblBuscador.Name = "lblBuscador";
            this.lblBuscador.Size = new System.Drawing.Size(102, 15);
            this.lblBuscador.TabIndex = 0;
            this.lblBuscador.Text = "Buscar por ciudad";
            // 
            // groupBoxBuscador
            // 
            this.groupBoxBuscador.Controls.Add(this.lblDateTimeHasta);
            this.groupBoxBuscador.Controls.Add(this.lblDateTimeDesde);
            this.groupBoxBuscador.Controls.Add(this.dateTimeHasta);
            this.groupBoxBuscador.Controls.Add(this.dateTimeDesde);
            this.groupBoxBuscador.Controls.Add(this.btnBuscar);
            this.groupBoxBuscador.Controls.Add(this.inputBuscador);
            this.groupBoxBuscador.Controls.Add(this.lblBuscador);
            this.groupBoxBuscador.Location = new System.Drawing.Point(50, 12);
            this.groupBoxBuscador.Name = "groupBoxBuscador";
            this.groupBoxBuscador.Size = new System.Drawing.Size(900, 103);
            this.groupBoxBuscador.TabIndex = 0;
            this.groupBoxBuscador.TabStop = false;
            // 
            // lblDateTimeHasta
            // 
            this.lblDateTimeHasta.AutoSize = true;
            this.lblDateTimeHasta.Location = new System.Drawing.Point(497, 38);
            this.lblDateTimeHasta.Name = "lblDateTimeHasta";
            this.lblDateTimeHasta.Size = new System.Drawing.Size(89, 15);
            this.lblDateTimeHasta.TabIndex = 0;
            this.lblDateTimeHasta.Text = "Fecha de vuelta";
            // 
            // lblDateTimeDesde
            // 
            this.lblDateTimeDesde.AutoSize = true;
            this.lblDateTimeDesde.Location = new System.Drawing.Point(223, 38);
            this.lblDateTimeDesde.Name = "lblDateTimeDesde";
            this.lblDateTimeDesde.Size = new System.Drawing.Size(73, 15);
            this.lblDateTimeDesde.TabIndex = 0;
            this.lblDateTimeDesde.Text = "Fecha de ida";
            // 
            // dateTimeHasta
            // 
            this.dateTimeHasta.Location = new System.Drawing.Point(497, 56);
            this.dateTimeHasta.Name = "dateTimeHasta";
            this.dateTimeHasta.Size = new System.Drawing.Size(210, 23);
            this.dateTimeHasta.TabIndex = 3;
            this.dateTimeHasta.ValueChanged += new System.EventHandler(this.dateTimeHasta_ValueChanged);
            // 
            // dateTimeDesde
            // 
            this.dateTimeDesde.CustomFormat = "";
            this.dateTimeDesde.Location = new System.Drawing.Point(223, 56);
            this.dateTimeDesde.MinDate = new System.DateTime(2021, 6, 5, 0, 0, 0, 0);
            this.dateTimeDesde.Name = "dateTimeDesde";
            this.dateTimeDesde.Size = new System.Drawing.Size(210, 23);
            this.dateTimeDesde.TabIndex = 2;
            this.dateTimeDesde.ValueChanged += new System.EventHandler(this.dateTimeDesde_ValueChanged);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBuscar.Location = new System.Drawing.Point(742, 31);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(131, 49);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // inputBuscador
            // 
            this.inputBuscador.Location = new System.Drawing.Point(24, 56);
            this.inputBuscador.Name = "inputBuscador";
            this.inputBuscador.Size = new System.Drawing.Size(132, 23);
            this.inputBuscador.TabIndex = 1;
            // 
            // VistaBuscadorCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.groupBoxBuscador);
            this.Controls.Add(this.dataGridViewAlojamientos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VistaBuscadorCliente";
            this.Text = "VistaFormNueva";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAlojamientos)).EndInit();
            this.groupBoxBuscador.ResumeLayout(false);
            this.groupBoxBuscador.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAlojamientos;
        private System.Windows.Forms.Label lblBuscador;
        private System.Windows.Forms.GroupBox groupBoxBuscador;
        private System.Windows.Forms.DateTimePicker dateTimeHasta;
        private System.Windows.Forms.DateTimePicker dateTimeDesde;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox inputBuscador;
        private System.Windows.Forms.Label lblDateTimeHasta;
        private System.Windows.Forms.Label lblDateTimeDesde;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ciudad;
        private System.Windows.Forms.DataGridViewTextBoxColumn barrio;
        private System.Windows.Forms.DataGridViewTextBoxColumn estrellas;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDePersonas;
        private System.Windows.Forms.DataGridViewCheckBoxColumn tv;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
    }
}