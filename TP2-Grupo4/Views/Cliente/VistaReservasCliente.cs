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
    public partial class VistaReservasCliente : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        List<Reserva> reservasDelUsuario;

        public VistaReservasCliente(AgenciaManager agenciaManager, string idioma)
        {
            InitializeComponent();
            this.agencia = agenciaManager;
            this.reservasDelUsuario = agenciaManager.GetAllReservasForUsuario(agenciaManager.GetUsuarioLogeado().GetDni());

            if (idioma == "Español")
            {
                label1.Text = "Reservaciones";
            }
            else if (idioma == "English")
            {
                label1.Text = "Reservations";
            }
        }

        // CREACION DEL CONTENIDO DEL DATAGRIDVIEW
        private void VistaReservasCliente_Load(object sender, EventArgs e)
        {
            // Boton reservar
            var btnCancelar = new DataGridViewButtonColumn
            {
                Text = "CANCELAR",
                UseColumnTextForButtonValue = true,
                Name = "CANCELAR",
                DataPropertyName = "CANCELAR",
                FlatStyle = FlatStyle.Flat,
            };
            btnCancelar.DefaultCellStyle.BackColor = Color.IndianRed;

            dgvReservaciones.Columns.Add("TipoAlojamiento", "Tipo de alojamiento");
            dgvReservaciones.Columns.Add("Fecha Inicio", "Fecha de ida");
            dgvReservaciones.Columns.Add("Fecha Fin", "Fecha de vuelta");
            dgvReservaciones.Columns.Add("Precio", "Precio");

            dgvReservaciones.Columns.Add(btnCancelar);
            dgvReservaciones.ReadOnly = false;
            dgvReservaciones.Rows.Clear();
            llenarDataGridView();
        }
        private void llenarDataGridView()
        {       
            List<List<String>> reservas = this.agencia.DatosDeReservasParaLasVistas("user");
            foreach (List<String> reserva in reservas)
                dgvReservaciones.Rows.Add(reserva.ToArray());
        }

        #region On Click
        // BOTON CANCELAR DEL DATAGRIDVIEW
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReservaciones.CurrentCell.RowIndex > (this.reservasDelUsuario.Count - 1))
            {
                MessageBox.Show("Celda incorrecta");
                return;
            }

            if (dgvReservaciones.Columns[e.ColumnIndex].Name == "CANCELAR")
            {
                if (MessageBox.Show("Estas seguro que quieres cancelar este alojamiento?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvReservaciones.CurrentCell.RowIndex;

                    // Codigo de la reserva
                    String codigoDeReserva = this.reservasDelUsuario[rowIndex].GetId();

                    // Eliminar reserva
                    this.agencia.EliminarReserva(codigoDeReserva);

                    // Actualizar GridView
                    this.dgvReservaciones.Rows.Clear();
                    llenarDataGridView();
                }
            }
        }
        #endregion
    }
}
