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
    public partial class FrmBitacora : Form
    {
        ConexionBD bd = new ConexionBD();
        public FrmBitacora()
        {
            InitializeComponent();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {            
        }

        private void FrmBitacora_Load(object sender, EventArgs e)
        {
            bd.CualquierTabla(dgv,"select * from Bitacora order by Id Desc");
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            bd.CualquierTabla(dgv, "SELECT * FROM Bitacora WHERE Fecha BETWEEN  '" + dtpDesde.Value.ToString("yyyy-MM-dd")+ "'  AND  '" + dtpHasta.Value.ToString("yyyy-MM-dd") + "'");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            bd.CualquierTabla(dgv, "select * from Bitacora order by Id Desc");
        }
    }
}
