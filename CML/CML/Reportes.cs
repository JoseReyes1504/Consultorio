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
    public partial class Reportes : Form
    {
        int Nun_Consulta = 0;
        public Reportes()
        {
            InitializeComponent();
        }
        public int Nun_Consulta1 { get => Nun_Consulta; set => Nun_Consulta = value; }

        private void Reportes_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'CMLDataSet.Consulta' Puede moverla o quitarla según sea necesario.
            this.ConsultorioTableAdapter.Fill(this.CMLDataSet.Consultorio, Nun_Consulta1);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
