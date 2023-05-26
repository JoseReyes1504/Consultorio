using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace CML
{
    public partial class FrmVerConsultas : Form
    {
        ConexionBD bd = new ConexionBD();
        int Id = 0;
        Reportes re = new Reportes();
        string Usuario;
        SqlCommand cmd;
        SqlDataReader dr;
        string Nombre;
        int Id_Signos = 0;

        public FrmVerConsultas()
        {
            InitializeComponent();
        }


        public FrmVerConsultas(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;
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
            Nombre = dgv.Rows[e.RowIndex].Cells["Paciente"].Value.ToString();
            re.Nun_Consulta1 = Id;
            btnImprimir.Enabled = true;
            btnEditar.Enabled = true;
            btnEliminar.Enabled = true;
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

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FrmConsulta consulta = new FrmConsulta(Id, Usuario);
            consulta.ShowDialog();
            this.Close();
        }

        private void FrmVerConsultas_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            DateTime fechaActual = DateTime.Now;

            try
            {
                bd.AbrirConexion();
                cmd = new SqlCommand("Delete from Consultorio where Id_Consultorio =" + Id + "", bd.sc);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("select * from Consultorio where Id_Consultorio =" + Id + "", bd.sc);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Id_Signos = Convert.ToInt32(dr["Id_Signos_Vitales_Consultorio"].ToString());
                }
                dr.Close();

                cmd = new SqlCommand("Delete from Signos_Vitales_Consultorio where Id_Signos_Vitales_Consultorio =" + Id_Signos + "", bd.sc);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Insert into Bitacora values('" + "CONSULTAS" + "', '" + Usuario + "', '" + "Elimino la consulta de: " + Nombre + "', GETDATE())", bd.sc);
                cmd.ExecuteNonQuery();
                                
                bd.CualquierTabla(dgv, "select a.Id_Consultorio[ID], c.Nombre_Completo[Paciente], a.Motivo_Consulta[Motivo Consulta], a.Incapacidad, a.Fecha_Consulta[Fecha] from Consultorio a inner join Empleado b on a.Id_Empleado = b.Id_Empleado inner join Identificacion c On b.Id_Identificacion = c.Id_Identificacion order by a.Id_Consultorio DESC");
                
                MessageBox.Show("Se eliminno la consulta" , "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);

                enableButton();                
                bd.CerrarConexion();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bd.CerrarConexion();
            }
        }

        public void enableButton()
        {
            btnEliminar.Enabled = false;
            btnImprimir.Enabled = false;
            btnEditar.Enabled = false;
        }
    }
}
