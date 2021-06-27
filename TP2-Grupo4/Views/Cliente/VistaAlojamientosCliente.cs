using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TP2_Grupo4.Models;
using TP2_Grupo4;

namespace TP2_Grupo4.Views
{
    public partial class VistaAlojamientosCliente : Form
    {
        private AgenciaManager agencia = new AgenciaManager();


        public VistaAlojamientosCliente(AgenciaManager agenciaManager, string idioma)
        {
            InitializeComponent();
            this.agencia = agenciaManager;

            this.llenarSelects();

            if (idioma == "Español")
            {
                groupBox1.Text = "Filtrar por:";
                label1.Text = "Tipo:";
                label4.Text = "Ciudad:";
                label6.Text = "Barrio:";
                lblPrecioMin.Text = "Precio Min:";
                lblPrecioMax.Text = "Precio Max:";
                label5.Text = "Estrella:";
                label2.Text = "Personas:";
                btnFiltrar.Text = "Filtrar";

                groupBox3.Text = "Fechas:";
                label3.Text = "Fecha de ida:";
                label7.Text = "Fecha de vuelta:";
                lblDiasDeReservas.Text = "Dias:";

                groupBox2.Text = "Ordenar por:";
                label8.Text = "Ordenar por:";
            }
            else if (idioma == "English")
            {
                groupBox1.Text = "Filter by:";
                label1.Text = "Type:";
                label4.Text = "City:";
                label6.Text = "Neighborhood:";
                lblPrecioMin.Text = "Min Price:";
                lblPrecioMax.Text = "Max Price:";
                label5.Text = "Stars:";
                label2.Text = "People:";
                btnFiltrar.Text = "Filter";

                groupBox3.Text = "Dates:";
                label3.Text = "Departure date:";
                label7.Text = "Return date:";
                lblDiasDeReservas.Text = "Days:";

                groupBox2.Text = "Sort by:";
                label8.Text = "Sort by:";
            }
        }


        #region METODOS COMPLEMENTARIOS
        private void indicarSelectPorDefecto()
        {
            this.selectTipoAlojamiento.SelectedIndex = 0;
            this.selectCiudad.SelectedIndex = 0;
            this.selectBarrio.SelectedIndex = 0;
            this.selectEstrellas.SelectedIndex = 0;
            this.selectCantPersonas.SelectedIndex = 0;
            //this.selectOrdenamiento.SelectedIndex = 0;
        }
        private void llenarSelects()
        {
            // Deshabilitar escritura en los select
            this.selectTipoAlojamiento.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selectCiudad.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selectBarrio.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selectEstrellas.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selectCantPersonas.DropDownStyle = ComboBoxStyle.DropDownList;
            this.selectOrdenamiento.DropDownStyle = ComboBoxStyle.DropDownList;

            //Tipos de alojamientos
            foreach (String item in this.agencia.OpcionesDelSelectDeTiposDeAlojamientos())
                this.selectTipoAlojamiento.Items.Add(item);

            // Ciudades
            foreach (String item in this.agencia.OpcionesDelSelectDeCiudades())
                this.selectCiudad.Items.Add(item);

            // Barrios
            foreach (String item in this.agencia.OpcionesDelSelectDeBarrios())
                this.selectBarrio.Items.Add(item);

            // Estrellas
            foreach (String item in this.agencia.OpcionesDelSelectDeEstrellas())
                this.selectEstrellas.Items.Add(item);

            // Personas
            foreach (String item in this.agencia.OpcionesDelSelectDePersonas())
                this.selectCantPersonas.Items.Add(item);

            // Opciones de ordenamiento
            foreach (String opcion in this.agencia.OpcionesDelSelectParaElOrdenamiento())
                this.selectOrdenamiento.Items.Add(opcion);

            // Item por defectos de los select
            this.indicarSelectPorDefecto();
        }
        private void limpiarDataGridView()
        {
            this.dgvAlojamiento.Rows.Clear();
        }
        private void llenarDataGridView(List<List<String>> alojamientos)
        {
            foreach (List<String> alojamiento in alojamientos)
                this.dgvAlojamiento.Rows.Add(alojamiento.ToArray());
        }
        private void bloquearBotonFiltrar(bool flag)
        {
            this.btnFiltrar.Enabled = !flag;
        }
        private void ordenarAlojamientos()
        {
            this.limpiarDataGridView();

            switch (this.selectOrdenamiento.Text)
            {
                case "fecha de creacion":
                    this.llenarDataGridView(this.agencia.GetAgencia().GetAlojamientoPorCodigo());
                    break;
                case "estrellas":
                    this.llenarDataGridView(this.agencia.GetAgencia().GetAlojamientoPorEstrellas());
                    break;
                case "personas":
                    this.llenarDataGridView(this.agencia.GetAgencia().GetAlojamientoPorPersonas());
                    break;
                default:
                    this.llenarDataGridView(this.agencia.GetAgencia().AlojamientosToLista());
                    break;
            }
        }
        #endregion


        /* DATOS POR DEFECTO DEL DATAGRIDVIEW */
        private void VistaAlojamientosCliente_Load(object sender, EventArgs e)
        {
            // Boton reservar
            var btnReservar = new DataGridViewButtonColumn
            {
                Text = "RESERVAR",
                UseColumnTextForButtonValue = true,
                Name = "RESERVAR",
                DataPropertyName = "RESERVAR",
                FlatStyle = FlatStyle.Flat,
            };
            btnReservar.DefaultCellStyle.BackColor = Color.Green;

            dgvAlojamiento.Columns.Add("Tipo", "Tipo");
            dgvAlojamiento.Columns.Add("Ciudad", "Ciudad");
            dgvAlojamiento.Columns.Add("Barrio", "Barrio");
            dgvAlojamiento.Columns.Add("Estrellas", "Estrellas");
            dgvAlojamiento.Columns.Add("CantidadDePersonas", "Cantidad de Personas");
            dgvAlojamiento.Columns.Add("Tv", "TV");
            dgvAlojamiento.Columns.Add("Precio", "Precio");

            dgvAlojamiento.Columns.Add(btnReservar);
            dgvAlojamiento.ReadOnly = false;

            // Cargar DataGridView
            var agencia = this.agencia.GetAgencia();
            this.llenarDataGridView(agencia.AlojamientosToLista());
        }

        #region On Click
        /* BOTON FILTRAR */
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            String inputTipoAlojamiento = this.selectTipoAlojamiento.SelectedItem.ToString();
            String inputCiudad = this.selectCiudad.SelectedItem.ToString();
            String inputBarrio = this.selectBarrio.SelectedItem.ToString();
            double inputPrecioMin = double.Parse(this.inputPrecioMin.Text);
            double inputPrecioMax = double.Parse(this.inputPrecioMax.Text);
            String inputEstrellas = this.selectEstrellas.SelectedItem.ToString();
            String inputPersonas = this.selectCantPersonas.SelectedItem.ToString();

            if (inputPrecioMax < inputPrecioMin)
            {
                MessageBox.Show("El precio maximo no puede ser menor que el precio minimo!");
                return;
            }

            List<List<String>> alojamientosFiltrados = this.agencia.FiltrarAlojamientos(inputTipoAlojamiento, inputCiudad, inputBarrio, inputPrecioMin, inputPrecioMax, inputEstrellas, inputPersonas);
            if (alojamientosFiltrados.Count == 0)
            {
                MessageBox.Show("No hay alojamientos disponibles para esa busqueda");
                return;
            }

            this.inputPrecioMin.Text = "0";
            this.inputPrecioMax.Text = "0";
            this.indicarSelectPorDefecto();
            this.limpiarDataGridView();
            this.llenarDataGridView(alojamientosFiltrados);
            this.ordenarAlojamientos();
        }

        /* SELECT DE ORDENAMIENTO */
        private void selectOrdenamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ordenarAlojamientos();
        }

        /* BOTON PARA RESERVAR */
        private void dgvAlojamiento_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validacion de las fechas
            int diasTotalesDeLaReserva;
            try
            {
                diasTotalesDeLaReserva = int.Parse(this.lblTotalDeDias.Text);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show("Sus fechas de reservacion no son correctas. Por favor reviselas");
                return;
            }

            // Si hacemos click en Button RESERVAR
            if (dgvAlojamiento.Columns[e.ColumnIndex].Name == "RESERVAR")
            {
                // Index del Row
                int rowIndex = dgvAlojamiento.CurrentCell.RowIndex;
                // Codigo del Alojamiento
                int codigoDelAlojamiento = this.alojamientosDelDataGridView.GetAlojamientos()[rowIndex].GetCodigo();
                // Cantidad de personas
                int cantidadDePersonas = int.Parse(this.dgvAlojamiento.Rows[rowIndex].Cells["CantidadDePersonas"].Value.ToString());
                // Precio del alojamiento
                int precioDelAlojamiento = int.Parse(this.dgvAlojamiento.Rows[rowIndex].Cells["Precio"].Value.ToString());
                // Tipo de alojamiento
                String tipoAlojamiento = this.dgvAlojamiento.Rows[rowIndex].Cells["Tipo"].Value.ToString();
                // Calcular precio total
                double precioDeLaReserva = tipoAlojamiento == "hotel" ? diasTotalesDeLaReserva * cantidadDePersonas * precioDelAlojamiento : diasTotalesDeLaReserva * precioDelAlojamiento;

                // Validar que el alojamiento este disponible
                if(!this.agencia.ElAlojamientoEstaDisponible(codigoDelAlojamiento, this.inputDateFechaIda.Value, this.inputDateFechaVuelta.Value))
                {
                    MessageBox.Show("El alojamiento no esta disponible en esas fechas, intente con otras fechas");
                    return;
                }

                // Mensaje
                String textMessage = $"El precio de la reserva que vas a realizar es de ${precioDeLaReserva}";
                textMessage += "\nDesea realizar la reserva ?";

                // Confirmacion del usuario
                if (MessageBox.Show(textMessage , "Confirmacion de la reserva", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Agregar reserva
                    this.agencia.AgregarReserva(
                        this.inputDateFechaIda.Value,
                        this.inputDateFechaVuelta.Value,
                        codigoDelAlojamiento,
                        this.agencia.GetUsuarioLogeado().GetDni(),
                        precioDeLaReserva
                        );
                    MessageBox.Show("Reserva realizada correctamente");

                    // llenar DataGridView
                    this.limpiarDataGridView();
                    this.llenarDataGridView();
                }
            }
        }
        #endregion

        /* VALIDAR LOS INPUTS DE PRECIOS */
        private void inputPrecioMin_TextChanged(object sender, EventArgs e)
        {
            String inputPrecioMin = this.inputPrecioMin.Text;
            if (inputPrecioMin == "") return;
            try
            {
                double precio = double.Parse(inputPrecioMin);

                if (precio < 0)
                {
                    MessageBox.Show("No puede ingresar valores negativos");
                    this.bloquearBotonFiltrar(true);
                    return;
                }
                this.bloquearBotonFiltrar(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Solo se permiten numeros");
                System.Diagnostics.Debug.WriteLine("Tipo: " + ex.GetType().ToString());
                System.Diagnostics.Debug.WriteLine("Mensaje: " + ex.Message);
                this.bloquearBotonFiltrar(true);
            }
        }
        private void inputPrecioMax_TextChanged(object sender, EventArgs e)
        {
            String inputPrecioMax = this.inputPrecioMax.Text;
            if (inputPrecioMax == "") return;
            try
            {
                double precioMax = double.Parse(inputPrecioMax);

                if (precioMax < 0)
                {
                    MessageBox.Show("No puede ingresar valores negativos");
                    this.bloquearBotonFiltrar(true);
                    return;
                }
                this.bloquearBotonFiltrar(false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Solo se permiten numeros");
                System.Diagnostics.Debug.WriteLine("Tipo: " + ex.GetType().ToString());
                System.Diagnostics.Debug.WriteLine("Mensaje: " + ex.Message);
                this.bloquearBotonFiltrar(false);
            }
        }

        /* MOSTRAR EL TOTAL DE DIAS DE LA RESERVA */
        private void inputDateFechaVuelta_ValueChanged(object sender, EventArgs e)
        {
            this.mostrarDiferenciasDeFechas();
        }
        private void inputDateFechaIda_ValueChanged(object sender, EventArgs e)
        {
            this.mostrarDiferenciasDeFechas();
        }
        private void mostrarDiferenciasDeFechas()
        {
            DateTime inputFechaIda = this.inputDateFechaIda.Value;
            DateTime inputFechaVuelta = this.inputDateFechaVuelta.Value;

            int diasDeDiferencia = (inputFechaVuelta - inputFechaIda).Days;

            if (diasDeDiferencia <= 0)
            {
                this.lblTotalDeDias.Text = "-";
                return;
            }
            this.lblTotalDeDias.Text = diasDeDiferencia.ToString();

            //System.Diagnostics.Debug.WriteLine("Diferencia de dias: " + diasDeDiferencia);
        }
    }
}
