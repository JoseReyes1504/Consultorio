using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CML
{
    public partial class FrmLogin : Form
    {
        ClsEmpleado empleado = new ClsEmpleado();
        ConexionBD conex = new ConexionBD();
        FrmMenu menu = new FrmMenu();


        public FrmLogin()
        {
            InitializeComponent();
            txtUsuario.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        void Ingresar()
        {
            clsValidaciones validacion = new clsValidaciones();

            if (txtUsuario.Text == "" && txtContrasena.Text == "")
            {
                MessageBox.Show("Campo usuario/contraseña vacio");
            }
            else
            {
                //--------------------sql-----------------------------------
                //se usa la funcion verificacion de usuario y contraseña para pasar a la siguiente ventana

                empleado.Nombre_Usuario = txtUsuario.Text;
                empleado.Codigo_Usuario = validacion.encriptar(txtContrasena.Text);

                if (empleado.autentificacion() == true)
                {
                    txtUsuario.Clear();
                    txtContrasena.Clear();
                    txtUsuario.Focus();
                    this.Hide();
                }
                else
                {
                    txtContrasena.Clear();
                    txtUsuario.Focus();
                }
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           Ingresar();
        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Ingresar();
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            
        }
    }
}
