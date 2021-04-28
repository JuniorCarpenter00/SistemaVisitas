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
    public partial class FrmVisitantes : Form
    {
        private Form OpenContenedor;

        N_Visitas objNegocio = new N_Visitas();

        public FrmVisitantes()
        {
            InitializeComponent();
        }
        private void Limpiar()
        {
            foreach (Control tool in Controls)
            {
                if (tool is TextBox == tool is MaskedTextBox == tool is ComboBox)
                {
                    tool.Text = "";
                }              
            }
        }
      
        private void FrmVisitantes_Load(object sender, EventArgs e)
        {
            if (E_Login.Cargo1 == E_Cargos.General)
            {
                btnEliminar.Enabled = false;
                btnEditar.Enabled = false;
            }
            dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();
        }
        
        private void OpenPanelConten(Form OpenFrm)
        {
            if (OpenContenedor != null)
            {
                OpenContenedor.Close();
            }
            OpenContenedor = OpenFrm;
            OpenFrm.TopLevel = false;
            OpenFrm.FormBorderStyle = FormBorderStyle.None;
            OpenFrm.Dock = DockStyle.Fill;
            panel1.Controls.Add(OpenFrm);
            panel1.Tag = OpenFrm;
            OpenFrm.BringToFront();
            OpenFrm.Show();



        }
     
       

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
           
            Limpiar();
            dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();
        }

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {
            try
            {

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBoxFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

                E_Visitas.Nombre1 = txtNombre.Text.ToUpper();
                E_Visitas.Apellido1 = txtApellido.Text.ToUpper();
                E_Visitas.Edificio1 = comboBoxEdificio.Text;
                E_Visitas.Aula1 = comboBoxAula.Text;
                E_Visitas.Telefono1 = mskTxtTelefono.Text;
                E_Visitas.FechaEntrada1 = Convert.ToDateTime(dateTimePickerFE.Text);
                E_Visitas.FechaSalida1 = Convert.ToDateTime(dateTimePickerFS.Text);
                E_Visitas.Carrera1 = comboBoxCarrera.Text;
                E_Visitas.Correo1 = mskTxtCorreo.Text;
                E_Visitas.MotivoVisita1 = txtMotivo.Text;
                E_Visitas.Foto1 = ms.GetBuffer();
                E_Visitas.Matricula1 = mskTxtMatricula.Text;
           

                objNegocio.Guardando_N();

                MessageBox.Show("Vistante Guardado");

                dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();

            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
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

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            try
            {

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                pictureBoxFoto.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);

                E_Visitas.Id1 = int.Parse(txtCode.Text);
                E_Visitas.Nombre1 = txtNombre.Text.ToUpper();
                E_Visitas.Apellido1 = txtApellido.Text.ToUpper();
                E_Visitas.Edificio1 = comboBoxEdificio.Text;
                E_Visitas.Aula1 = comboBoxAula.Text;
                E_Visitas.Telefono1 = mskTxtTelefono.Text;
                E_Visitas.FechaEntrada1 = Convert.ToDateTime(dateTimePickerFE.Text);
                E_Visitas.FechaSalida1 = Convert.ToDateTime(dateTimePickerFS.Text);
                E_Visitas.Carrera1 = comboBoxCarrera.Text;
                E_Visitas.MotivoVisita1 = txtMotivo.Text;
                E_Visitas.Correo1 = mskTxtCorreo.Text;
                E_Visitas.Foto1 = ms.GetBuffer();
                E_Visitas.Matricula1 = mskTxtMatricula.Text;
               
                objNegocio.Editando_N();

                MessageBox.Show("Vistante Editar");

                dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();

            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }

        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            try
            {
                E_Visitas.Id1 = int.Parse(txtCode.Text);

                objNegocio.Borrando_N();

                MessageBox.Show("Vistante Eliminado");

                dataGridViewVisitas.DataSource = objNegocio.Mostrando_N();

            }
            catch (Exception error)
            {
                MessageBox.Show($"ERROR: {error.Message}");
            }
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ft = new OpenFileDialog();
            DialogResult rt = ft.ShowDialog();
            if (rt == DialogResult.OK)
            {
                pictureBoxFoto.Image = Image.FromFile(ft.FileName);
            }
        }

        private void dataGridViewVisitas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCode.Text = dataGridViewVisitas.CurrentRow.Cells[0].Value.ToString();
            txtNombre.Text = dataGridViewVisitas.CurrentRow.Cells[1].Value.ToString();
            txtApellido.Text = dataGridViewVisitas.CurrentRow.Cells[2].Value.ToString();
            comboBoxEdificio.Text = dataGridViewVisitas.CurrentRow.Cells[3].Value.ToString();
            comboBoxAula.Text = dataGridViewVisitas.CurrentRow.Cells[4].Value.ToString();
            mskTxtTelefono.Text = dataGridViewVisitas.CurrentRow.Cells[5].Value.ToString();
            dateTimePickerFE.Text = dataGridViewVisitas.CurrentRow.Cells[6].Value.ToString();
            dateTimePickerFS.Text = dataGridViewVisitas.CurrentRow.Cells[7].Value.ToString();
            comboBoxCarrera.Text = dataGridViewVisitas.CurrentRow.Cells[8].Value.ToString();
            mskTxtCorreo.Text = dataGridViewVisitas.CurrentRow.Cells[9].Value.ToString();
            mskTxtMatricula.Text = dataGridViewVisitas.CurrentRow.Cells[10].Value.ToString();
            txtMotivo.Text = dataGridViewVisitas.CurrentRow.Cells[11].Value.ToString();
          //  pictureBoxFoto.Text = dataGridViewVisitas.CurrentRow.Cells[12].Value.ToString();
        }
    }
}
