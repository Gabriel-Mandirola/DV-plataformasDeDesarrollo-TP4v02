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
    public partial class VistaAdminAlojamiento : Form
    {
        private AgenciaManager agencia;

        public VistaAdminAlojamiento(string idioma)
        {
            InitializeComponent();
            this.agencia = new AgenciaManager();
            if (idioma == "Español")
            {
                lblAlojamiento.Text = "Alojamientos";
                label1.Text = "Tipo:";
            }
            else if (idioma == "English")
            {
                lblAlojamiento.Text = "Lodgings";
                label1.Text = "Type:";
            }
        }

        private void FormAlojamiento_Load(object sender, EventArgs e)
        {
            dgvAlojamiento.Columns.Add("CODIGO", "Codigo");
            dgvAlojamiento.Columns.Add("CIUADAD", "Ciudad");
            dgvAlojamiento.Columns.Add("BARRIO", "Barrio");
            dgvAlojamiento.Columns.Add("ESTRELLAS", "Estrellas");
            dgvAlojamiento.Columns.Add("CANTPERSONAS", "Cant. Personas");
            dgvAlojamiento.Columns.Add("TV", "TV");
            dgvAlojamiento.Columns.Add("PRECIO", "Precio");

            dgvAlojamiento.ReadOnly = true;
            comboBoxTipoAloj.SelectedIndex = 0;
        }

        private void getTextAlojamientos()
        {
            foreach (List<String> alojamiento in this.agencia.GetAgencia().DatosDeAlojamientosParaLasVistasAdmin())
                this.dgvAlojamiento.Rows.Add(alojamiento.ToArray());
        }

        private void getTextHoteles()
        {
            foreach (List<String> alojamiento in this.agencia.GetAgencia().DatosDeAlojamientosParaLasVistasAdmin())
                this.dgvAlojamiento.Rows.Add(alojamiento.ToArray());
        }

        private void getTextCabanias()
        {
            foreach (List<String> alojamiento in this.agencia.GetAgencia().DatosDeAlojamientosParaLasVistasAdmin())
                this.dgvAlojamiento.Rows.Add(alojamiento.ToArray());
        }

        private void comboBoxTipoAloj_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dgvAlojamiento.Rows.Clear();
            if ((comboBoxTipoAloj.SelectedItem).ToString() == "Hotel")
            {
                getTextHoteles();
            }
            else if ((comboBoxTipoAloj.SelectedItem).ToString() == "Cabaña")
            {
                getTextCabanias();
            }
            else
            {
                getTextAlojamientos();
            }
        }
    }
}
