using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using TP2_Grupo4.Models;

namespace TP2_Grupo4.Views
{
    public partial class VistaAdminHoteles : Form
    {
        private AgenciaManager agencia;

        public VistaAdminHoteles(string idioma)
        {
            InitializeComponent();
            this.agencia = new AgenciaManager();

            if (idioma == "Español")
            {
                lblHoteles.Text = "Hoteles";
                label10.Text = "Código:";
                label7.Text = "Ciudad:";
                label4.Text = "Barrio:";
                label2.Text = "Cantidad de Personas";
                label5.Text = "Estrellas";
                checkBoxTv.Text = "¿Tiene Tv?";
                label3.Text = "Precio";
                btnTopModificar.Text = "Modificar";
                btnTopAgregar.Text = "Agregar";
            }
            else if (idioma == "English")
            {
                lblHoteles.Text = "Hotels";
                label10.Text = "Code:";
                label7.Text = "Town:";
                label4.Text = "Neighborhood:";
                label2.Text = "Amount of people";
                label5.Text = "Stars";
                checkBoxTv.Text = "Have a TV?";
                label3.Text = "Price";
                btnTopModificar.Text = "Modify";
                btnTopAgregar.Text = "Add";
            }
        }

        private void FormHoteles_Load(object sender, EventArgs e)
        {
            // Boton borrar
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

            // Checkbox
            var checkTV = new DataGridViewCheckBoxColumn
            {
                HeaderText = "TV",
                Name = "TV"
            };


            // Tabla
            dgvHoteles.Columns.Add("CODIGO", "Codigo");
            dgvHoteles.Columns.Add("CIUDAD", "Ciudad");
            dgvHoteles.Columns.Add("BARRIO", "Barrio");
            dgvHoteles.Columns.Add("ESTRELLAS", "Estrellas");
            dgvHoteles.Columns.Add("CANT_PERSONAS", "Personas");
            dgvHoteles.Columns.Add(checkTV);
            dgvHoteles.Columns.Add("PRECIO_X_PERSONA", "Precio x Persona");
            dgvHoteles.Columns.Add("PRECIO", "Precio Total");
            dgvHoteles.Columns.Add(btnModificar);
            dgvHoteles.Columns.Add(btnBorrar);

            dgvHoteles.ReadOnly = true;
            btnTopModificar.Visible = false;
           // comboBoxCantPersonas.SelectedIndex = 0;
           // comboBoxEstrellas.SelectedIndex = 0;

            // Get hoteles de alojamientos.txt
            clearAllControls();
            getHotelesFromTextFile();
        }

        private void getHotelesFromTextFile()
        {
            // Limpiamos el GridView
            dgvHoteles.Rows.Clear();

            foreach (List<String> alojamiento in this.agencia.GetAgencia().DatosDeAlojamientosParaLasVistasAdmin())
                this.dgvHoteles.Rows.Add(alojamiento.ToArray());

            // Update y Regresheo de Grid
            dgvHoteles.Update();
            dgvHoteles.Refresh();
        }

        #region Helper
        private void rellenarDatos()
        {
            txtCodigo.Text = dgvHoteles.CurrentRow.Cells[0].Value.ToString();
            txtCodigo.Enabled = false;
            txtCiudad.Text = dgvHoteles.CurrentRow.Cells[1].Value.ToString();
            txtBarrio.Text = dgvHoteles.CurrentRow.Cells[2].Value.ToString();
            comboBoxEstrellas.Text = dgvHoteles.CurrentRow.Cells[3].Value.ToString();
            comboBoxCantPersonas.Text = dgvHoteles.CurrentRow.Cells[4].Value.ToString();
            checkBoxTv.Checked = bool.Parse(dgvHoteles.CurrentRow.Cells[5].Value.ToString());
            txtPrecio.Text = dgvHoteles.CurrentRow.Cells[6].Value.ToString();
        }

        // Resetear campos
        private void clearAllControls()
        {
            foreach (Control control in groupBoxHoteles.Controls)
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
        // Click en Contenido de la Celda
        private void dgvHoteles_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si hacemos click en Button BORRAR
            if (dgvHoteles.Columns[e.ColumnIndex].Name == "BORRAR")
            {
                if (MessageBox.Show("Estas seguro que quieres borrar este hotel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvHoteles.CurrentCell.RowIndex;
                    // Codigo del Hotel
                    int codigo = Int32.Parse(dgvHoteles.Rows[rowIndex].Cells["CODIGO"].Value.ToString());

                    // Borrado
                    dgvHoteles.Rows.RemoveAt(rowIndex);
                    if (this.agencia.GetAgencia().EliminarAlojamiento(codigo))
                    {
                        MessageBox.Show("Hotel eliminado junto con todas sus reservas");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo eliminar el Hotel. Intente nuevamente");
                    }
                    // Actualizar GridView
                    getHotelesFromTextFile();
                }
            }

            if (dgvHoteles.Columns[e.ColumnIndex].Name == "MODIFICAR")
            {
                if (MessageBox.Show("Estas seguro que quieres modificar este hotel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnTopAgregar.Visible = false;
                    btnTopModificar.Visible = true;

                    rellenarDatos();
                }
            }

        }

        // onClick Boton Modificar
        private void btnTopModificar_Click(object sender, EventArgs e)
        {
            btnTopAgregar.Visible = true;
            btnTopModificar.Visible = false;
            double precioPersonas = 0;
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
            bool tv = checkBoxTv.Checked;
            try
            {
                precioPersonas = double.Parse(txtPrecio.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Ingresaste un valor alfabetico en el precio, ingresa un valor numérico");
            }

            //REVISAR
            var asd = new Alojamiento(codigo.ToString(), ciudad, barrio, estrellas, cantPersonas, tv, precioPersonas, 0, 0, 0);
            if (this.agencia.GetAgencia().ModificarAlojamiento(asd))
            {
                MessageBox.Show("Hotel modificado correctamente");
            }
            else
            {
                MessageBox.Show("No se pudo modificar el hotel, vuelva a intentarlo");
            }

            clearAllControls();
            getHotelesFromTextFile();
            txtCodigo.Enabled = true;
        }

        // onClick Boton Agregar
        private void btnTopAgregar_Click(object sender, EventArgs e)
        {
            int codigo = 0;
            double precioPersonas = 0;
            bool huboError = false;
            try
            {
                codigo = Int32.Parse(txtCodigo.Text);
            } catch (FormatException)
            {
                MessageBox.Show("ingresaste un valor alfabetico en el codigo de alojamiento, ingresa un valor numérico");
                huboError = true;
            }
            
            string ciudad = txtCiudad.Text;
            string barrio = txtBarrio.Text;
            int estrellas = Int32.Parse(comboBoxEstrellas.Text);
            int cantPersonas = Int32.Parse(comboBoxCantPersonas.Text);
            bool tv = checkBoxTv.Checked;

            try
            {
                precioPersonas = double.Parse(txtPrecio.Text);
            } catch (FormatException)
            {
                MessageBox.Show("Ingresaste un valor alfabetico en el precio, ingresa un valor numérico");
                huboError = true;
            }

            //REVISAR
            var asd = new Alojamiento(codigo.ToString(), ciudad, barrio, estrellas, cantPersonas, tv, precioPersonas, 0, 0, 0);
            if ( !this.agencia.ExisteAlojamiento(codigo) && this.agencia.GetAgencia().AgregarAlojamiento(asd) )
            {
                MessageBox.Show("El Hotel fue agregado correctamente.");
            }
            else if (!huboError)
            {
                MessageBox.Show("Ya existe el código de alojamiento, ingresa un código inexistente");
            }

            clearAllControls();
            getHotelesFromTextFile();
        }

        #endregion

        #region Key Pressed
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
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
