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
    public partial class FrmIncapacidad : Form
    {
        ConexionBD bd = new ConexionBD();
        SqlCommand cmd;
        clsValidaciones val = new clsValidaciones();
        SqlDataReader dr;
        int AreaTrabajo = 0;
        int Id_Identificacion = 0;

        public FrmIncapacidad()
        {
            InitializeComponent();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState= FormWindowState.Minimized;
        }

        public void Limpiar()
        {
            txtCodigo.Clear();
            txtDias.Clear();
            txtMotivo.Clear();
            txtNombre.Clear();
            AreaTrabajo = 0;
            Id_Identificacion = 0;
            cmbArea.Text = "Seleccione";

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu= new FrmMenu();
            this.Hide();
            frmMenu.Show();
        }

        private void FrmIncapacidad_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            bd.cbAreaTrabajo(cmbArea);
            bd.CualquierTabla(dgv, "select a.Fecha_Incapacidad[Fecha], b.Nombre_Completo[Empleado], c.Area_Trabajo[Area Trabajo], a.Dias, a.Motivo  from Incapacidad a inner join Identificacion b on a.Id_Identificacion = b.Id_Identificacion inner join Puesto c On b.Id_Puesto = c.Id_Puesto");
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.TextLength >= 4)
            {
                try
                {
                    bd.AbrirConexion();
                    cmd = new SqlCommand("select* from Identificacion where Codigo_Empleado = '" + txtCodigo.Text + "'", bd.sc);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtNombre.Text = dr["Nombre_Completo"].ToString();
                        Id_Identificacion = Convert.ToInt32(dr["Id_Identificacion"].ToString());
                        AreaTrabajo = Convert.ToInt32(dr["Id_Puesto"].ToString());

                        cmbArea.SelectedIndex = AreaTrabajo - 1;

                    }
                    bd.CerrarConexion();
                    dr.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error con el empleado" + ex.ToString(), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    bd.CerrarConexion();
                }
            }
            else
            {
                txtNombre.Clear();
                cmbArea.Text = "Seleccione";
                
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtCodigo.TextLength >= 4)
            {
                try
                {
                    bd.AbrirConexion();
                    SqlCommand cmd = new SqlCommand("insert into Incapacidad values('" + dtpFecha.Value.ToString("yyyy/MM/dd") + "', " + Id_Identificacion + ", " + AreaTrabajo + ", '" + txtMotivo.Text + "', " + Convert.ToInt32(txtDias.Text) + ")", bd.sc);
                    cmd.ExecuteNonQuery();
                    bd.CualquierTabla(dgv, "select a.Fecha_Incapacidad[Fecha], b.Nombre_Completo[Empleado], c.Area_Trabajo[Area Trabajo], a.Dias, a.Motivo  from Incapacidad a inner join Identificacion b on a.Id_Identificacion = b.Id_Identificacion inner join Puesto c On b.Id_Puesto = c.Id_Puesto");
                    Limpiar();
                    bd.CerrarConexion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bd.CerrarConexion();
                }
            }
            else
            {
                MessageBox.Show("Datos Vacios", "Datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
            
        }

        private void txtDias_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
