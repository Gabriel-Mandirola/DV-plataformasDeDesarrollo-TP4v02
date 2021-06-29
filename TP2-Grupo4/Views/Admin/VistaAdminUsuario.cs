using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TP2_Grupo4.Views;
using TP2_Grupo4.Models;

namespace TP2_Grupo4.Views
{
    public partial class VistaAdminUsuario : Form
    {
        AgenciaManager agencia = new AgenciaManager();
        public VistaAdminUsuario(string idioma)
        {
            InitializeComponent();
            if (idioma == "Español")
            {
                lblUsuarios.Text = "Usuarios";
                lblDni.Text = "DNI";
                lblNombre.Text = "Nombre";
                lblBarrio.Text = "Email";
                checkBoxAdmin.Text = "Admin";
                checkBoxBloqueado.Text = "Bloqueado";
                btnTopModificar.Text = "Modificar";
            }
            else if (idioma == "English")
            {
                lblUsuarios.Text = "User";
                lblDni.Text = "DNI";
                lblNombre.Text = "Name";
                lblBarrio.Text = "Email";
                checkBoxAdmin.Text = "Admin";
                checkBoxBloqueado.Text = "Blocked";
                btnTopModificar.Text = "Modify";
            }
        }

        private void VistaUsuario_Load(object sender, EventArgs e)
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

            // Checkbox isAdmin
            var checkIsAdmin = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Admin",
                Name = "Admin"
            };

            // Checkbox bloqueado
            var checkBloqueado = new DataGridViewCheckBoxColumn
            {
                HeaderText = "Bloqueado",
                Name = "Bloqueado"
            };

            // Tabla
            dgvUsuarios.Columns.Add("DNI", "DNI");
            dgvUsuarios.Columns.Add("Nombre", "Nombre");
            dgvUsuarios.Columns.Add("Email", "Email");
            dgvUsuarios.Columns.Add(checkIsAdmin);
            dgvUsuarios.Columns.Add(checkBloqueado);
            dgvUsuarios.Columns.Add(btnModificar);
            dgvUsuarios.Columns.Add(btnBorrar);

            dgvUsuarios.ReadOnly = true;
            groupBoxHoteles.Enabled = false;

            getUsuariosFromTextFile();
        }

        private void getUsuariosFromTextFile()
        {
            // Limpiamos el GridView
            this.dgvUsuarios.Rows.Clear();

            foreach (var usuario in this.agencia.GetUsuarios())
                this.dgvUsuarios.Rows.Add(usuario.ToArray());

            // Update y Regresheo de Grid
            this.dgvUsuarios.Update();
            this.dgvUsuarios.Refresh();
        }

        #region On Click
        // BOTON DE BORRAR USUARIO
        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Si hacemos click en Button BORRAR
            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "BORRAR")
            {
                if (MessageBox.Show("Estas seguro que quieres borrar este usuario?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Index del Row
                    int rowIndex = dgvUsuarios.CurrentCell.RowIndex;
                    // Codigo del Hotel
                    int dni = Int32.Parse(dgvUsuarios.Rows[rowIndex].Cells["DNI"].Value.ToString());

                    // Borrado
                    dgvUsuarios.Rows.RemoveAt(rowIndex);

                    if (this.agencia.EliminarUsuario(dni))
                    {
                        MessageBox.Show("Se ha eliminado el usuario y todas las reservas del mismo");
                    } else
                    {
                        MessageBox.Show("No se pudo eliminar el Usuario. Intente nuevamente");
                    }

                    // Actualizar GridView
                    getUsuariosFromTextFile();
                }
            }

            if (dgvUsuarios.Columns[e.ColumnIndex].Name == "MODIFICAR")
            {
                if (MessageBox.Show("Estas seguro que quieres modificar este usuario?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    btnTopModificar.Visible = true;
                    groupBoxHoteles.Enabled = true;
                    txtDni.Enabled = false;
                    checkBoxAdmin.Enabled = false;
                    rellenarDatos();
                }
            }
        }
        // MODIFICAR USUARIO
        private void btnTopModificar_Click(object sender, EventArgs e)
        {
            btnTopModificar.Visible = false;
            int dni = 0;
            try
            {
              dni = Int32.Parse(txtDni.Text);
            } catch (FormatException)
            {
                labelError.Text = "Ingresaste un valor alfabetico en el DNI";
                return;
            }
            
            string nombre = txtNombre.Text;
            string email = txtEmail.Text;
            bool bloqueado = checkBoxBloqueado.Checked;

            if (this.agencia.ModificarUsuario(dni, nombre, email,bloqueado))
                MessageBox.Show("El usuario a sido modificado");

            clearAllControls();
            groupBoxHoteles.Enabled = false;
            getUsuariosFromTextFile();
        }
        #endregion

        #region Helper
        private void rellenarDatos()
        {
            txtDni.Text = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dgvUsuarios.CurrentRow.Cells[1].Value.ToString();
            txtEmail.Text = dgvUsuarios.CurrentRow.Cells[2].Value.ToString();
            checkBoxAdmin.Checked = bool.Parse(dgvUsuarios.CurrentRow.Cells[3].Value.ToString());
            checkBoxBloqueado.Checked = bool.Parse(dgvUsuarios.CurrentRow.Cells[4].Value.ToString());
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
