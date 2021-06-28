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
    public partial class VistaAdminCabanias : Form
    {
        private AgenciaManager agencia;

        public VistaAdminCabanias(string idioma)
        {
            InitializeComponent();
            this.agencia = new AgenciaManager();
            if (idioma == "Español")
            {
                lblCabanias.Text = "Cabañas";
                label10.Text = "Código:";
                label7.Text = "Ciudad:";
                label4.Text = "Barrio:";
                label2.Text = "Cantidad de Personas";
                label5.Text = "Estrellas";
                checkBoxTV.Text = "¿Tiene Tv?";
                label3.Text = "Precio x Dia";
                label1.Text = "Habitaciones";
                label6.Text = "Baños";
                btnTopModificar.Text = "Modificar";
                btnTopAgregar.Text = "Agregar";
            }
            else if (idioma == "English")
            {
                lblCabanias.Text = "Cottage";
                label10.Text = "Code:";
                label7.Text = "Town:";
                label4.Text = "Neighborhood:";
                label2.Text = "Amount of people";
                label5.Text = "Stars";
                checkBoxTV.Text = "Have a TV?";
                label3.Text = "Price x Day";
                label1.Text = "Bedrooms";
                label6.Text = "Toilets";
                btnTopModificar.Text = "Modify";
                btnTopAgregar.Text = "Add";
            }
        }

        private void FormCabanias_Load(object sender, EventArgs e)
        {
            // Boton borrar
            var btnBorrar = new DataGridViewButtonColumn
            {
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
                Text = "MODIFICAR",
                UseColumnTextForButtonValue = true,
                Name = "MODIFICAR",
                DataPropertyName = "MODIFICAR",
                FlatStyle = FlatStyle.Flat,
            };
            btnModificar.DefaultCellStyle.BackColor = Color.LightYellow;

            var checkTV = new DataGridViewCheckBoxColumn
            {
                HeaderText = "TV",
                Name = "TV"
            };

            // Tabla
            dgvCabanias.Columns.Add("CODIGO", "Codigo");
            dgvCabanias.Columns.Add("CIUDAD", "Ciudad");
            dgvCabanias.Columns.Add("BARRIO", "Barrio");
            dgvCabanias.Columns.Add("ESTRELLAS", "Estrellas");
            dgvCabanias.Columns.Add("CANT_PERSONAS", "Cant. Personas");
            dgvCabanias.Columns.Add(checkTV);
            dgvCabanias.Columns.Add("PRECIO_X_DIA", "Precio X Dia");
            dgvCabanias.Columns.Add("HABITACIONES", "Habitaciones");
            dgvCabanias.Columns.Add("BANIOS", "Baños");
            dgvCabanias.Columns.Add("PRECIO_TOTAL", "Total");

            dgvCabanias.Columns.Add(btnModificar);
            dgvCabanias.Columns.Add(btnBorrar);

            dgvCabanias.ReadOnly = true;
            btnTopModificar.Visible = false;

            clearAllControls();
            getCabaniasFromTextFile();
        }

        private void getCabaniasFromTextFile()
        {
            // Limpiamos el GridView
            dgvCabanias.Rows.Clear();
            var alojamientos = this.agencia.GetAgencia().GetAlojamientos();

            // Limpiamos el GridView
            dgvCabanias.Rows.Clear();

            foreach (Alojamiento alojamiento in alojamientos)
                if (alojamiento.Tipo == "cabaña")
                {
                    this.dgvCabanias.Rows.Add(
                    alojamiento.Codigo,
                    alojamiento.Ciudad,
                    alojamiento.Barrio,
                    alojamiento.Estrellas,
                    alojamiento.CantidadDePersonas,
                    alojamiento.Tv,
                    alojamiento.PrecioPorDia,
                    alojamiento.Habitaciones,
                    alojamiento.Banios,
                    alojamiento.PrecioPorDia * alojamiento.CantidadDePersonas // chequear calculo => Total = PrecioXDia * CantDepersonas ???
                    ); ;

                }

            // Update y Regresheo de Grid
            dgvCabanias.Update();
            dgvCabanias.Refresh();
        }

        #region Helpers
        private void rellenarDatos()
        {
            txtCodigo.Text = dgvCabanias.CurrentRow.Cells[0].Value.ToString();
            txtCodigo.Enabled = false;
            txtCiudad.Text = dgvCabanias.CurrentRow.Cells[1].Value.ToString();
            txtBarrio.Text = dgvCabanias.CurrentRow.Cells[2].Value.ToString();
            comboBoxEstrellas.Text = dgvCabanias.CurrentRow.Cells[3].Value.ToString();
            comboBoxCantPersonas.Text = dgvCabanias.CurrentRow.Cells[4].Value.ToString();
            checkBoxTV.Checked = bool.Parse(dgvCabanias.CurrentRow.Cells[5].Value.ToString());
            txtPrecioDia.Text = dgvCabanias.CurrentRow.Cells[6].Value.ToString();
            comboBoxHabitaciones.Text = dgvCabanias.CurrentRow.Cells[7].Value.ToString();
            comboBoxBanios.Text = dgvCabanias.CurrentRow.Cells[8].Value.ToString();
        }

        private void clearAllControls()
        {
            foreach (Control control in groupBoxCabanias.Controls)
            {
                if (control is TextBox)
                {
                    TextBox textBox = (TextBox)control;
                    textBox.Text = null;

                }
                if (control is ComboBox)
                {
                    ComboBox comboBox = (ComboBox)control;

                    comboBox.SelectedIndex = 0;
                }

                if (control is CheckBox)
                {
                    CheckBox checkBox = (CheckBox)control;
                    checkBox.Checked = false;
                }
            }
        }
        #endregion


        #region On Click
        // BORRAR CABANIA
        private void dgvCabanias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            // Si hacemos click en Button BORRAR
            if (dgvCabanias.Columns[e.ColumnIndex].Name == "BORRAR")
            {
                if (MessageBox.Show("Estas seguro que quieres borrar este hotel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvCabanias.CurrentCell.RowIndex;
                    // Codigo del Hotel
                    int codigo = Int32.Parse(dgvCabanias.Rows[rowIndex].Cells["CODIGO"].Value.ToString());

                    // Borrado
                    dgvCabanias.Rows.RemoveAt(rowIndex);
                    if (this.agencia.GetAgencia().EliminarAlojamiento(codigo))
                    {
                        MessageBox.Show("Cabaña elimina junto con todas sus reservas");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar la Cabaña. Intente nuevamente");
                    }

                    // Actualizar GridView
                    getCabaniasFromTextFile();
                }
            }

            if (dgvCabanias.Columns[e.ColumnIndex].Name == "MODIFICAR")
            {
                if (MessageBox.Show("Estas seguro que quieres modificar este hotel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnTopAgregar.Visible = false;
                    btnTopModificar.Visible = true;

                    rellenarDatos();
                }
            }
        }

        private void btnTopAgregar_Click(object sender, EventArgs e)
        {
            double precioPorDia = 0;
            int codigo = 0;
            bool huboError = false;
            try
            {
                codigo = Int32.Parse(txtCodigo.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("ingresaste un valor alfabetico en el codigo de alojamiento, ingresa un valor numérico");
                huboError = true;
            }
            string ciudad = txtCiudad.Text;
            string barrio = txtBarrio.Text;
            int estrellas = Int32.Parse(comboBoxEstrellas.Text);
            int cantPersonas = Int32.Parse(comboBoxCantPersonas.Text);
            bool tv = checkBoxTV.Checked;
            try
            {
                precioPorDia = double.Parse(txtPrecioDia.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresaste un valor alfabetico en el precio, ingresa un valor numérico");
                huboError = true;
            }

            int habitaciones = Int32.Parse(comboBoxHabitaciones.Text);
            int banios = Int32.Parse(comboBoxBanios.Text);
            if (!this.agencia.ExisteAlojamiento(codigo))
            {
                // REVISAR
                var newAlojamiento = new Alojamiento
                {
                    Codigo = codigo.ToString(),
                    Ciudad = ciudad,
                    Barrio = barrio,
                    Estrellas = estrellas,
                    CantidadDePersonas = cantPersonas,
                    Tipo = "cabaña",
                    Tv = tv,
                    PrecioPorPersona = 0,
                    PrecioPorDia = precioPorDia,
                    Habitaciones = habitaciones,
                    Banios = banios
                };
                if (this.agencia.GetAgencia().AgregarAlojamiento(newAlojamiento))
                {
                    MessageBox.Show("Cabaña agregada correctamente");
                }
                else
                {
                    MessageBox.Show("No se pudo agregar la cabaña, vuelva a intentarlo");
                }
            }
            else if (!huboError)
            {
                MessageBox.Show("Ya existe el código de alojamiento, ingresa un código inexistente");
            }

            clearAllControls();
            getCabaniasFromTextFile();
        }

        private void btnTopModificar_Click(object sender, EventArgs e)
        {
            btnTopAgregar.Visible = true;
            btnTopModificar.Visible = false;

            double precioDia = 0;
            int codigo = 0;
            try
            {
                codigo = Int32.Parse(txtCodigo.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("ingresaste un valor alfabetico en el codigo de alojamiento, ingresa un valor numérico");
            }
            string ciudad = txtCiudad.Text;
            string barrio = txtBarrio.Text;
            int estrellas = Int32.Parse(comboBoxEstrellas.Text);
            int cantPersonas = Int32.Parse(comboBoxCantPersonas.Text);
            bool tv = checkBoxTV.Checked;
            try
            {
                precioDia = double.Parse(txtPrecioDia.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresaste un valor alfabetico en el precio, ingresa un valor numérico");
            }
            int habitaciones = Int32.Parse(comboBoxHabitaciones.Text);
            int banios = Int32.Parse(comboBoxBanios.Text);

            var asd = new Alojamiento { Codigo = codigo.ToString(), Ciudad = ciudad, Barrio = barrio, Estrellas = estrellas, CantidadDePersonas = cantPersonas, Tv = tv, PrecioPorPersona = 0, PrecioPorDia = precioDia, Habitaciones = habitaciones, Banios = banios };
            if (this.agencia.GetAgencia().ModificarAlojamiento(asd))
            {
                MessageBox.Show("Cabaña modificada correctamente");
            }
            else
            {
                MessageBox.Show("No se pudo modificar la cabaña, vuelva a intentarlo");
            }

            clearAllControls();
            getCabaniasFromTextFile();
            txtCodigo.Enabled = true;
        }
        #endregion

        #region Key Pressed
        private void txtPrecioDia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        #endregion
    }
}
