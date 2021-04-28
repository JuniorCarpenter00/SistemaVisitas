using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capap_Negocios;
using Capa_Entidades;

namespace Capa_Presentacion
{
    public partial class FrmBusqueda : Form
    {
        N_Visitas objNegocio = new N_Visitas();

        public FrmBusqueda()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                E_Visitas.Id1 = int.Parse(txtCode.Text);
                E_Visitas.Nombre1 = txtNombre.Text;

                dataGridViewVisitas.DataSource = objNegocio.Buscando_N();
            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }
        }

        private void Limpiar()
        {
            foreach (Control tool in Controls)
            {
                if (tool is TextBox)
                {
                    tool.Text = "";
                }
            }
        }
        private void FrmBusqueda_Load(object sender, EventArgs e)
        {
            dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Limpiar();
            dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();
        }
    }
}
