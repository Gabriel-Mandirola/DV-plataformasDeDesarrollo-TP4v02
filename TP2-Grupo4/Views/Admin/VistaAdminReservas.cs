using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TP2_Grupo4.Models;

namespace TP2_Grupo4.Views
{
    public partial class VistaAdminReservas : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        public VistaAdminReservas(string idioma)
        {
            InitializeComponent();
            dateTimeHasta.MinDate = DateTime.Now;
            dateTimeDesde.MinDate = DateTime.Now;

            if (idioma == "Español")
            {
                lblReservas.Text = "Reservas";
                label1.Text = "ID Alojamiento:";
                Localidad.Text = "DNI:";
                TBDesde.Text = "Desde:";
                Estrellas.Text = "Hasta:";
                Precio.Text = "Precio:";
                ID.Text = "ID Reserva:";
                Modificar.Text = "Modificar";
                groupBox1.Text = "Ordenamiento";
            }
            else if (idioma == "English")
            {
                lblReservas.Text = "Reservations";
                label1.Text = "Accommodation ID:";
                Localidad.Text = "DNI:";
                TBDesde.Text = "Since:";
                Estrellas.Text = "Until:";
                Precio.Text = "Price:";
                ID.Text = "Reservation ID:";
                Modificar.Text = "Modify";
                groupBox1.Text = "Ordering";
            }
        }

        private void VistaAdminReservas_Load(object sender, EventArgs e)
        {
            var btnBorrar = new DataGridViewButtonColumn
            {
                HeaderText = "Borrar",
                Text = "BORRAR",
                UseColumnTextForButtonValue = true,
                Name = "BORRAR",
                DataPropertyName = "BORRAR",
                FlatStyle = FlatStyle.Flat,
            };
            btnBorrar.DefaultCellStyle.BackColor = Color.IndianRed;

            // Boton modificar
            var btnModificar = new DataGridViewButtonColumn
            {
                HeaderText = "Modificar",
                Text = "MODIFICAR",
                UseColumnTextForButtonValue = true,
                Name = "MODIFICAR",
                FlatStyle = FlatStyle.Flat,

            };
            btnModificar.DefaultCellStyle.BackColor = Color.LightYellow;

            dgvReservas.Columns.Add("ID", "idReserva");
            dgvReservas.Columns.Add("DESDE", "Desde");
            dgvReservas.Columns.Add("HASTA", "Hasta");
            dgvReservas.Columns.Add("IDALOJAMIENTO", "Id Alojamiento");
            dgvReservas.Columns.Add("USUARIO", "Usuario");
            dgvReservas.Columns.Add("PRECIO", "Precio Total");
            dgvReservas.Columns.Add(btnModificar);
            dgvReservas.Columns.Add(btnBorrar);
            dgvReservas.ReadOnly = true;
            llenarDataGridView();
        }

        private void llenarDataGridView()
        {

            dgvReservas.Rows.Clear();
            List<List<String>> reservas = this.agencia.DatosDeReservasParaLasVistas("admin");
            foreach (List<String> reserva in reservas)
                this.dgvReservas.Rows.Add(reserva.ToArray());

            dgvReservas.Update();
            dgvReservas.Refresh();
        }

        #region On Click
        private void Modificar_Click(object sender, EventArgs e)
        {
           
            Modificar.Enabled = false;
            String id = textBoxID.Text;
            DateTime desde = DateTime.Parse(dateTimeDesde.Text);
            DateTime hasta = DateTime.Parse(dateTimeHasta.Text);
            int precio = Int32.Parse(textBoxPrecio.Text);
            int idAloja = Int32.Parse(textBoxAloja.Text);
            int dni = Int32.Parse(textBoxUsuario.Text);
            agencia.ModificarReserva(id, desde, hasta, precio, agencia.GetAgencia().FindAlojamientoForCodigo(idAloja), agencia.FindUserForDNI(dni));
            dateTimeDesde.MinDate = DateTime.Now;
            dateTimeHasta.MinDate = DateTime.Now;

            clearAllControls();
            llenarDataGridView();

        }
        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si hacemos click en Button BORRAR
            if (dgvReservas.Columns[e.ColumnIndex].Name == "BORRAR")
            {
                if (MessageBox.Show("Estas seguro que quieres borrar esta reserva?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvReservas.CurrentCell.RowIndex;
                    // Codigo del Hotel
                    String codigo = dgvReservas.Rows[rowIndex].Cells["ID"].Value.ToString();

                    // Borrado
                    dgvReservas.Rows.RemoveAt(rowIndex);


                    if (this.agencia.EliminarReserva(codigo))
                    {
                        MessageBox.Show("Reserva eliminada con exito");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la Reserva. Intente nuevamente");
                    }
                }
            }

            if (dgvReservas.Columns[e.ColumnIndex].Name == "MODIFICAR")
            {
                if (MessageBox.Show("Estas seguro que quieres modificar esta reserva?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Modificar.Enabled = true;

                    dateTimeDesde.MinDate = Convert.ToDateTime(dgvReservas.CurrentRow.Cells[1].Value);
                    dateTimeHasta.MinDate = Convert.ToDateTime(dgvReservas.CurrentRow.Cells[2].Value);
                    rellenarDatos();
                }
            }

        }
        #endregion

        #region Helpers
        private void rellenarDatos()
        {
            textBoxID.Text = dgvReservas.CurrentRow.Cells[0].Value.ToString();
            dateTimeDesde.Text = dgvReservas.CurrentRow.Cells[1].Value.ToString();
            dateTimeHasta.Text = dgvReservas.CurrentRow.Cells[2].Value.ToString();
            textBoxAloja.Text = dgvReservas.CurrentRow.Cells[3].Value.ToString();
            textBoxUsuario.Text = dgvReservas.CurrentRow.Cells[4].Value.ToString();
            textBoxPrecio.Text = dgvReservas.CurrentRow.Cells[5].Value.ToString();

        }
        private void clearAllControls()
        {
            foreach (Control control in groupBox1.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;

                }
                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;

                    comboBox.Text = "";
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }
            }
        }
        #endregion
    }

}
