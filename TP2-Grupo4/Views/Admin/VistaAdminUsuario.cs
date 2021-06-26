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
        public VistaAdminUsuario()
        {
            InitializeComponent();
        }

        // TODO: No mostrar Password
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

            // Get hoteles de usuarios.txt
            getUsuariosFromTextFile();
        }

        private void getUsuariosFromTextFile()
        {
            // Limpiamos el GridView
            dgvUsuarios.Rows.Clear();

            List<Usuario> usuarios = this.agencia.GetUsuarios();

            foreach (Usuario usuario in usuarios)
            {
                this.dgvUsuarios.Rows.Add(
                    usuario.GetDni(),
                    usuario.GetNombre(),
                    usuario.GetEmail(),
                    usuario.GetIsAdmin(),
                    usuario.GetBloqueado()
                );
            }

            // Update y Regresheo de Grid
            dgvUsuarios.Update();
            dgvUsuarios.Refresh();
        }

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

                    /*if (this.agencia.EliminarUsuario(dni) && this.agencia.GuardarCambiosDeLosUsuarios() && this.agencia.GuardarCambiosDeLasReservas())
                    {
                        MessageBox.Show("Se ha eliminado el usuario y todas las reservas del mismo");
                    }*/

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
            }
            
            string nombre = txtNombre.Text;
            string email = txtEmail.Text;
            bool bloqueado = checkBoxBloqueado.Checked;


            this.agencia.ModificarUsuario(dni, nombre, email,"");

            if (!bloqueado)
            {
                this.agencia.DesbloquearUsuario(dni);
            }
            else
            {
                this.agencia.BloquearUsuario(dni);
            }


            //this.agencia.GuardarCambiosDeLosUsuarios();

            clearAllControls();
            groupBoxHoteles.Enabled = false;
            getUsuariosFromTextFile();
        }

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
