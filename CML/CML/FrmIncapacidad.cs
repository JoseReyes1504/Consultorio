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
    public partial class FrmIncapacidad : Form
    {
        public FrmIncapacidad()
        {
            InitializeComponent();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu= new FrmMenu();
            this.Hide();
            frmMenu.Show();
        }

        private void FrmIncapacidad_Load(object sender, EventArgs e)
        {

        }
    }
}
