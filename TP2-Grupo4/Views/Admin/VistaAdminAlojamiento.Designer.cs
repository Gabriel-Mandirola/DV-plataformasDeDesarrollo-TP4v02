
namespace TP2_Grupo4.Views
{
    partial class VistaAdminAlojamiento
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvAlojamiento = new System.Windows.Forms.DataGridView();
            this.comboBoxTipoAloj = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblAlojamiento = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlojamiento)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvAlojamiento
            // 
            this.dgvAlojamiento.AllowUserToAddRows = false;
            this.dgvAlojamiento.AllowUserToResizeColumns = false;
            this.dgvAlojamiento.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAlojamiento.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAlojamiento.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAlojamiento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAlojamiento.Cursor = System.Windows.Forms.Cursors.Default;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAlojamiento.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAlojamiento.Location = new System.Drawing.Point(12, 109);
            this.dgvAlojamiento.Name = "dgvAlojamiento";
            this.dgvAlojamiento.RowTemplate.Height = 25;
            this.dgvAlojamiento.Size = new System.Drawing.Size(976, 441);
            this.dgvAlojamiento.TabIndex = 0;
            // 
            // comboBoxTipoAloj
            // 
            this.comboBoxTipoAloj.AllowDrop = true;
            this.comboBoxTipoAloj.BackColor = System.Drawing.Color.White;
            this.comboBoxTipoAloj.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoAloj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxTipoAloj.FormattingEnabled = true;
            this.comboBoxTipoAloj.Items.AddRange(new object[] {
            "Todos",
            "Hotel",
            "Cabaña"});
            this.comboBoxTipoAloj.Location = new System.Drawing.Point(55, 70);
            this.comboBoxTipoAloj.Name = "comboBoxTipoAloj";
            this.comboBoxTipoAloj.Size = new System.Drawing.Size(97, 23);
            this.comboBoxTipoAloj.TabIndex = 0;
            this.comboBoxTipoAloj.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoAloj_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo: ";
            // 
            // lblAlojamiento
            // 
            this.lblAlojamiento.AutoSize = true;
            this.lblAlojamiento.Font = new System.Drawing.Font("Arial", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblAlojamiento.ForeColor = System.Drawing.Color.Black;
            this.lblAlojamiento.Location = new System.Drawing.Point(368, 7);
            this.lblAlojamiento.Name = "lblAlojamiento";
            this.lblAlojamiento.Size = new System.Drawing.Size(260, 45);
            this.lblAlojamiento.TabIndex = 0;
            this.lblAlojamiento.Text = "Alojamientos";
            // 
            // VistaAdminAlojamiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ClientSize = new System.Drawing.Size(1000, 562);
            this.Controls.Add(this.lblAlojamiento);
            this.Controls.Add(this.dgvAlojamiento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTipoAloj);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "VistaAdminAlojamiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormAlojamiento";
            this.Load += new System.EventHandler(this.FormAlojamiento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlojamiento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAlojamiento;
        private System.Windows.Forms.ComboBox comboBoxTipoAloj;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblAlojamiento;
    }
}