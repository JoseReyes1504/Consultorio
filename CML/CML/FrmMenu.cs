using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CML
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        private void btnExpediente_Click(object sender, EventArgs e)
        {
            FrmExpediente frmExpediente = new FrmExpediente();
            this.Hide();
            frmExpediente.ShowDialog();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            FrmConsulta frmConsulta = new FrmConsulta();
            this.Hide();
            frmConsulta.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();
            this.Hide();
            frmUsuarios.ShowDialog();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmLogin frmLogin = new FrmLogin();
            this.Hide();
            frmLogin.Show();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FrmInventario frmInventario= new FrmInventario();
            this.Hide();
            frmInventario.Show();
        }

        private void btnEntregaMeds_Click(object sender, EventArgs e)
        {
            FrmEntregaMedicina frmEntregaMedicina = new FrmEntregaMedicina();
            this.Hide();
            frmEntregaMedicina.Show();
        }

        private void btnIncapacidad_Click(object sender, EventArgs e)
        {
            FrmIncapacidad frmIncapacidad = new FrmIncapacidad();
            this.Hide();
            frmIncapacidad.Show();
        }

        private void btnBitacora_Click(object sender, EventArgs e)
        {
            FrmBitacora frmBitacora = new FrmBitacora();
            this.Hide();
            frmBitacora.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
