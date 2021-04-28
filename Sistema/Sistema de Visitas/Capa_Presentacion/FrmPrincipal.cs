using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Capap_Negocios;
using Capa_Entidades;


namespace Capa_Presentacion
{
    public partial class FormPrincipal : Form
    {
       // private Panel btnBordeIzq;
        private Form OpenContenedor;
        FrmLogin obj = new FrmLogin();
        public FormPrincipal()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
      
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
            panelContenedor.Controls.Add(OpenFrm);
            panelContenedor.Tag = OpenFrm;
            OpenFrm.BringToFront();
            OpenFrm.Show();

        }
        private void btnRVisitas_Click(object sender, EventArgs e)
        {
            OpenPanelConten(new FrmVisitantes());
        }

        private void btnRUser_Click(object sender, EventArgs e)
        {
            OpenPanelConten(new FrmUsuarios());
        }
        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenPanelConten(new FrmBusqueda());

        }
        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que quiere volver al login ", "Advertencia",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                this.Close();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            labelHora.Text = DateTime.Now.ToLongTimeString();
            labelFecha.Text = DateTime.Now.ToShortDateString();
        }
       
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que quiere salir", "Advertencia",
               MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            DatosUser_P();
            Permisos();

        }
        public void Permisos()
        {
            if (E_Login.Cargo1 == E_Cargos.General)
            {
                  btnRUser.Enabled = false;
            }
        }
        private void DatosUser_P()
        {
            labelNombre.Text = ($" {E_Login.Nombre1} {E_Login.Apellido1}");
            labelCargo.Text = ($" {E_Login.Cargo1}:");
        }

      

      
    }
}
