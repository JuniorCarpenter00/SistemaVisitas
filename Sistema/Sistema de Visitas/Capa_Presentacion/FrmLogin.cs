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
using Capa_Entidades;
using Capap_Negocios;

namespace Capa_Presentacion
{
    public partial class FrmLogin : Form
    {
        N_Login objNegocio = new N_Login();

        public FrmLogin()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {
            
            try
            {
                DataTable dt = new DataTable();
                E_Login.User = txtUser.Text;
                E_Login.Pass = txtPass.Text;

                dt = objNegocio.Login_N();

                if (dt.Rows.Count > 0)
                {
                    E_Login.ID1 = int.Parse( dt.Rows[0][0].ToString());
                    E_Login.Code = dt.Rows[0][1].ToString();
                    E_Login.User = dt.Rows[0][2].ToString();
                    E_Login.Pass = dt.Rows[0][3].ToString();
                    E_Login.Nombre1 = dt.Rows[0][4].ToString();
                    E_Login.Apellido1 = dt.Rows[0][5].ToString();
                    E_Login.Cargo1 = dt.Rows[0][6].ToString();
                    E_Login.Fecha1 = Convert.ToDateTime( dt.Rows[0][7].ToString());

                    MessageBox.Show($"BIENVENIDO: \n\n {E_Login.Nombre1}  {E_Login.Apellido1}.");

                    FormPrincipal frmPrincipal = new FormPrincipal();
                    frmPrincipal.Show();
                    frmPrincipal.FormClosed += Logout;
                    this.Hide();


                }
                else
                {
                    MessageBox.Show($"DATOS INCORRECTOS, VERIFIQUE SU USUARIO O SU CONTACEÑA... ");
                    txtUser.Clear();
                    txtPass.Clear();
                }
            }
            catch (Exception Error)
            {

                MessageBox.Show($"{Error.Message}");
                txtUser.Clear();
                txtPass.Clear();
            }
            


        }
     
        private void Logout(object sender, FormClosedEventArgs e)
        {
            txtUser.Clear();
          //  txtPass.UseSystemPasswordChar = true;
            txtPass.Clear();
            this.Show();
            txtUser.Focus();
        }
      
        private void FrmLogin_Load(object sender, EventArgs e)
        {
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
