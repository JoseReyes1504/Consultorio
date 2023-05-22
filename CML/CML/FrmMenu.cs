using System;
using System.Windows.Forms;

namespace CML
{
    public partial class FrmMenu : Form
    {
        string Usuario;
        public FrmMenu()
        {
            InitializeComponent();
        }

        public FrmMenu(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;
        }

        private void btnExpediente_Click(object sender, EventArgs e)
        {
            FrmExpediente frmExpediente = new FrmExpediente(Usuario);
            frmExpediente.ShowDialog();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            FrmConsulta frmConsulta = new FrmConsulta();
            frmConsulta.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            frmUsuariosAdmin frmUsuarios = new frmUsuariosAdmin(Usuario);
            frmUsuarios.ShowDialog();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            frmLogin.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            FrmVerConsultas ver = new FrmVerConsultas();
            ver.ShowDialog();
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FrmInventario frmInventario = new FrmInventario(Usuario);
            frmInventario.Show();
        }

        private void btnEntregaMeds_Click(object sender, EventArgs e)
        {
            FrmEntregaMedicina frmEntregaMedicina = new FrmEntregaMedicina(Usuario);
            frmEntregaMedicina.Show();
        }

        private void btnIncapacidad_Click(object sender, EventArgs e)
        {
            FrmIncapacidad frmIncapacidad = new FrmIncapacidad(Usuario);
            frmIncapacidad.Show();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            FrmBitacora frmBitacora = new FrmBitacora();
            frmBitacora.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnControlDiario_Click(object sender, EventArgs e)
        {
            ControlEnf control = new ControlEnf();
            control.ShowDialog();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {            
        }

        private void Tiempo_Tick(object sender, EventArgs e)
        {
            lblHora.Text = DateTime.Now.ToLongTimeString();
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }

        private void FrmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("¿Realmente desea salir del programa?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.No)
                {
                    e.Cancel = true; // Cancela el cierre de la ventana
                }
                else
                {
                    Application.Exit();
                }
            }

        }
    }
}
