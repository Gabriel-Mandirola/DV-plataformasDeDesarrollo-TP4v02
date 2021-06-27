using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TP2_Grupo4.Views.Cliente
{
    public partial class VistaBuscadorCliente : Form
    {

        private AgenciaManager agencia;

        private DateTime fechaDesde;
        private DateTime fechaHasta;

        public VistaBuscadorCliente(AgenciaManager agenciaManager, string idioma)
        {
            InitializeComponent();
            this.agencia = agenciaManager;

            this.agregarBtnAlDataGridView();
            this.resetInputsDeFechas();
            this.configuracionDeLosInputsDeFechas();

            if (idioma == "Español")
            {
                lblBuscador.Text = "Buscar por ciudad";
                lblDateTimeDesde.Text = "Fecha de ida";
                lblDateTimeHasta.Text = "Fecha de vuelta";
                btnBuscar.Text = "Buscar";
            }
            else if (idioma == "English")
            {
                lblBuscador.Text = "Search by city";
                lblDateTimeDesde.Text = "Departure date";
                lblDateTimeHasta.Text = "Return date";
                btnBuscar.Text = "Search";
            }
        }

        #region On Click
        // BOTTON BUSCAR
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String inputCiudad = this.inputBuscador.Text.Trim();
            int diferenciaDeDias = (this.fechaHasta - this.fechaDesde).Days;

            if(diferenciaDeDias <= 0)
            {
                MessageBox.Show("Fechas incorrectas. Revise sus fechas de ida y vuelta");
                return;
            }
            else if (inputCiudad == "")
            {
                MessageBox.Show("No puede dejar vacio el campo del buscador");
                return;
            }

            // Muestro los datos
            this.llenarDataGridView(this.agencia.BuscarDeAlojamientosPorCiudadYFechas(inputCiudad, this.fechaDesde, this.fechaHasta));
        }

        // RESERVAR ALOJAMIENTO
        private void dataGridViewAlojamientos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Row Index
            int rowIndex = this.dataGridViewAlojamientos.CurrentCell.RowIndex;
            // Cantidad de dias
            int cantidadDeDias = (this.fechaHasta - this.fechaDesde).Days;
            // Precio del alojamiento
            double precioDelAlojamiento = Double.Parse(dataGridViewAlojamientos.Rows[rowIndex].Cells["precio"].Value.ToString());
            // Cantidad de personas
            int cantidadDePersonas = int.Parse(this.dataGridViewAlojamientos.Rows[rowIndex].Cells["cantidadDePersonas"].Value.ToString());
            // Tipo de alojamiento
            String tipoAlojamiento = this.dataGridViewAlojamientos.Rows[rowIndex].Cells["tipo"].Value.ToString();
            // Codigo del Alojamiento
            int codigoDelAlojamiento = int.Parse(this.dataGridViewAlojamientos.Rows[rowIndex].Cells["codigo"].Value.ToString());
            // DNI usuario
            int dni = this.agencia.GetUsuarioLogeado().GetDni();
            // Precio total del alojamiento
            double precioDeLaReserva = tipoAlojamiento == "hotel" ? cantidadDeDias * cantidadDePersonas * precioDelAlojamiento : cantidadDeDias * precioDelAlojamiento;

            // Mensaje
            String message = $"\n\tTipo del alojamiento: {tipoAlojamiento}\n\tTotal de dias: {cantidadDeDias}\n\tPrecio Total: ${precioDeLaReserva}";
            message += "\n\t¿ Desea realizar la reserva ?";

            // Pedir confirmacion al usuario
            if (MessageBox.Show(message, "Confirmacion de la reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(this.agencia.AgregarReserva(this.fechaDesde, this.fechaHasta, codigoDelAlojamiento, dni, precioDeLaReserva))
                    MessageBox.Show("Su reserva fue realizada con exito");
                else
                    MessageBox.Show("No se pudo realizar la reserva, vuelva a intentarlo mas tarde");

                this.resetFormularioDeBusqueda();
                this.limpiarDataGridView();
            }
        }
        #endregion

        #region HELPERS

        // DataGridView
        private void limpiarDataGridView()
        {
            this.dataGridViewAlojamientos.Rows.Clear();
        }
        private void llenarDataGridView(List<List<String>> alojamientos)
        {
            this.limpiarDataGridView();

            foreach (List<String> alojamiento in alojamientos)
            {
                this.dataGridViewAlojamientos.Rows.Add(alojamiento.ToArray());
            }
        }
        private void agregarBtnAlDataGridView()
        {
            // Creo el boton
            var btnReservar = new DataGridViewButtonColumn
            {
                Text = "RESERVAR",
                UseColumnTextForButtonValue = true,
                Name = "RESERVAR",
                DataPropertyName = "RESERVAR",
                FlatStyle = FlatStyle.Flat,
            };
            btnReservar.DefaultCellStyle.BackColor = Color.Green;
            btnReservar.ReadOnly = false;

            // Agrego el boton al dataGridView
            this.dataGridViewAlojamientos.Columns.Add(btnReservar);
        }
        
        // Formulario
        private void resetFormularioDeBusqueda()
        {
            // Inputs del formulario
            this.inputBuscador.Text = "";
            this.resetInputsDeFechas();
        }
        private void configuracionDeLosInputsDeFechas()
        {
            // Fecha actual
            DateTime fechaActual = DateTime.Now;
            // Input DateTime Desde
            this.dateTimeDesde.MinDate = fechaActual.AddMilliseconds(-1);
            this.dateTimeDesde.MaxDate = fechaActual.AddMonths(3).AddMilliseconds(-1);
            // Input DateTime Hasta
            this.dateTimeHasta.MinDate = fechaActual.AddDays(1);
            this.dateTimeHasta.MaxDate = fechaActual.AddMonths(3);
        }
        private void resetInputsDeFechas()
        {
            // Fecha actual
            DateTime fechaActual = DateTime.Now;

            // Input fecha desde
            this.fechaDesde = fechaActual;
            this.dateTimeDesde.Value = fechaActual;

            // Input fecha hasta
            this.fechaHasta = fechaActual.AddDays(1);
            this.dateTimeHasta.Value = fechaActual.AddDays(1);

            //System.Diagnostics.Debug.WriteLine($"Desde: {this.fechaDesde.ToString()}\nHasta: {this.fechaHasta.ToString()}");
        }
        private void dateTimeDesde_ValueChanged(object sender, EventArgs e)
        {
            this.fechaDesde = new DateTime(this.dateTimeDesde.Value.Year, this.dateTimeDesde.Value.Month, this.dateTimeDesde.Value.Day); ;
        }
        private void dateTimeHasta_ValueChanged(object sender, EventArgs e)
        {
            this.fechaHasta = new DateTime(this.dateTimeHasta.Value.Year, this.dateTimeHasta.Value.Month, this.dateTimeHasta.Value.Day);
        }

        #endregion
    }
}
