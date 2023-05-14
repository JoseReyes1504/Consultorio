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
            frmExpediente.ShowDialog();
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            FrmConsulta frmConsulta = new FrmConsulta();            
            frmConsulta.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frmUsuarios = new FrmUsuarios();            
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
            FrmInventario frmInventario= new FrmInventario();            
            frmInventario.Show();
        }

        private void btnEntregaMeds_Click(object sender, EventArgs e)
        {
            FrmEntregaMedicina frmEntregaMedicina = new FrmEntregaMedicina();            
            frmEntregaMedicina.Show();
        }

        private void btnIncapacidad_Click(object sender, EventArgs e)
        {
            FrmIncapacidad frmIncapacidad = new FrmIncapacidad();            
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
    }
}
