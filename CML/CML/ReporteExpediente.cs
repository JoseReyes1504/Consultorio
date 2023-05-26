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
    public partial class ReporteExpediente : Form
    {
        int Nun_Expediente = 0;

        public ReporteExpediente()
        {
            InitializeComponent();
        }

        public int Nun_Expediente1 { get => Nun_Expediente; set => Nun_Expediente = value; }

        private void ReporteExpediente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'CMLDataSet.Expediente' Puede moverla o quitarla según sea necesario.
            this.ExpedienteTableAdapter.Fill(this.CMLDataSet.Expediente, Nun_Expediente1);
            this.reportViewer1.RefreshReport();
        }
    }
}
