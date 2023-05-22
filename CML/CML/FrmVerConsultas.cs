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
    public partial class FrmVerConsultas : Form
    {
        ConexionBD bd = new ConexionBD();
        int Id = 0;
        Reportes re = new Reportes();
        public FrmVerConsultas()
        {
            InitializeComponent();
        }

        private void FrmVerExpediente_Load(object sender, EventArgs e)
        {
            bd.CualquierTabla(dgv, "select a.Id_Consultorio[ID], c.Nombre_Completo[Paciente], a.Motivo_Consulta[Motivo Consulta], a.Incapacidad, a.Fecha_Consulta[Fecha] from Consultorio a inner join Empleado b on a.Id_Empleado = b.Id_Empleado inner join Identificacion c On b.Id_Identificacion = c.Id_Identificacion order by a.Id_Consultorio DESC");
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            
            re.ShowDialog();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            Id = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            re.Nun_Consulta1 = Id;
            btnImprimir.Enabled = true;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if(txtCodigo.Text != "")
            {
                bd.CualquierTabla(dgv, "select a.Id_Consultorio[ID], c.Nombre_Completo[Paciente], a.Motivo_Consulta[Motivo Consulta], a.Incapacidad, a.Fecha_Consulta[Fecha] from Consultorio a inner join Empleado b on a.Id_Empleado = b.Id_Empleado inner join Identificacion c On b.Id_Identificacion = c.Id_Identificacion where c.Nombre_Completo like '%" + txtCodigo.Text + "%' order by a.Id_Consultorio DESC ");
            }
            else if(txtCodigo.Text == "")
            {
                bd.CualquierTabla(dgv, "select a.Id_Consultorio[ID], c.Nombre_Completo[Paciente], a.Motivo_Consulta[Motivo Consulta], a.Incapacidad, a.Fecha_Consulta[Fecha] from Consultorio a inner join Empleado b on a.Id_Empleado = b.Id_Empleado inner join Identificacion c On b.Id_Identificacion = c.Id_Identificacion order by a.Id_Consultorio DESC");
            }
            
        }
    }
}
