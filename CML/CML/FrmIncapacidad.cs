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
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

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
        DateTime fechaActual = DateTime.Now;
        int Id_Incapacidad = 0;
        string Usuario = "";
        string Refrendado = "No";

        public FrmIncapacidad()
        {
            InitializeComponent();
        }

        public FrmIncapacidad(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;
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
            txtCentroMedico.Clear();
            txtNombreFiltro.Clear();
            txtEnfermedad.Clear();
            Refrendado = "No";
            cbxRefrendadoNo.Checked = true;
            AreaTrabajo = 0;
            Id_Incapacidad = 0;
            Id_Identificacion = 0;
            cmbArea.Text = "Seleccione";

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu= new FrmMenu();
            this.Hide();
            frmMenu.Show();
        }

        public void ActualizarDGV()
        {
            bd.CualquierTabla(dgv, "select a.Id_Incapacidad[ID], a.Fecha_Incapacidad[Fecha Ingreso], b.Nombre_Completo[Empleado], a.Fecha_Inicio[Fecha Inicio], a.Fecha_Final[Fecha Final], a.Dias, c.Area_Trabajo[Area Trabajo], a.Motivo, a.Centro_Medico[Centro Medico], a.Tipo_Enfermedad [Enfermedad], a.Refrendado from Incapacidad a inner join Identificacion b  on a.Id_Identificacion = b.Id_Identificacion inner join Puesto c On b.Id_Puesto = c.Id_Puesto order by a.Id_Incapacidad DESC");
        }

        private void FrmIncapacidad_Load(object sender, EventArgs e)
        {
            txtCodigo.Focus();
            bd.cbAreaTrabajo(cmbArea);
            ActualizarDGV();
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
            if (txtCodigo.TextLength >= 4)
            {
                try
                {
                    bd.AbrirConexion();
                    SqlCommand cmd = new SqlCommand("insert into Incapacidad values('" + fechaActual.ToString("yyyy/MM/dd") + "', '" + dtpInicio.Value.ToString("yyyy/MM/dd") + "', '" + dtpFinal.Value.ToString("yyyy/MM/dd") + "', " + Id_Identificacion + ", " + AreaTrabajo + ", '" + txtMotivo.Text + "',  '" + txtCentroMedico.Text + "', '" + txtEnfermedad.Text + "', '" + Refrendado + "', " + Convert.ToInt32(txtDias.Text) + ")", bd.sc);
                    cmd.ExecuteNonQuery();
                    ActualizarDGV();
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

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas de los DatePickers
            DateTime fecha1 = dtpInicio.Value.Date;
            DateTime fecha2 = dtpFinal.Value.Date;

            // Calcular la diferencia en días
            TimeSpan diferencia = fecha2 - fecha1;
            int dias = diferencia.Days;

            // Mostrar el resultado            
            txtDias.Text = dias.ToString();
        }

        private void dtpFinal_ValueChanged(object sender, EventArgs e)
        {
            // Obtener las fechas seleccionadas de los DatePickers
            DateTime fecha1 = dtpInicio.Value.Date;
            DateTime fecha2 = dtpFinal.Value.Date;
            
            TimeSpan diferencia = fecha2 - fecha1;
            int dias = diferencia.Days;
            
            txtDias.Text = dias.ToString();
        }

        private void CbxRefrendadoSi_CheckedChanged(object sender, EventArgs e)
        {
            if(CbxRefrendadoSi.Checked == true)
            {
                Refrendado = "Si";
            }
            else
            {
                Refrendado = "No";
            }
        }

        private void cbxRefrendadoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxRefrendadoNo.Checked == true)
            {
                Refrendado = "No";
            }
            else
            {
                Refrendado = "Si";
            }
        }

        private void txtNombreFiltro_TextChanged(object sender, EventArgs e)
        {
            if(txtNombreFiltro.Text != "")
            {
                bd.CualquierTabla(dgv, "select a.Id_Incapacidad[ID], a.Fecha_Incapacidad[Fecha Ingreso], b.Nombre_Completo[Empleado], a.Fecha_Inicio[Fecha Inicio], a.Fecha_Final[Fecha Final], a.Dias, c.Area_Trabajo[Area Trabajo], a.Motivo, a.Centro_Medico[Centro Medico], a.Tipo_Enfermedad [Enfermedad], a.Refrendado from Incapacidad a inner join Identificacion b  on a.Id_Identificacion = b.Id_Identificacion inner join Puesto c On b.Id_Puesto = c.Id_Puesto Where b.Nombre_Completo like '%" + txtNombreFiltro.Text + "%'");                
            }
            else
            {
                ActualizarDGV();
            }
        }

        private void dtpFiltrado_ValueChanged(object sender, EventArgs e)
        {
            if (txtNombreFiltro.Text != "")
            {
                bd.CualquierTabla(dgv, "select a.Id_Incapacidad[ID], a.Fecha_Incapacidad[Fecha Ingreso], b.Nombre_Completo[Empleado], a.Fecha_Inicio[Fecha Inicio], a.Fecha_Final[Fecha Final], a.Dias, c.Area_Trabajo[Area Trabajo], a.Motivo, a.Centro_Medico[Centro Medico], a.Tipo_Enfermedad [Enfermedad], a.Refrendado from Incapacidad a inner join Identificacion b  on a.Id_Identificacion = b.Id_Identificacion inner join Puesto c On b.Id_Puesto = c.Id_Puesto Where b.Nombre_Completo like '%" + txtNombreFiltro.Text + "%' and a.Fecha_Incapacidad = '" + dtpFiltrado.Value.ToString("yyyy/MM/dd") + "'");
            }
            else
            {
                bd.CualquierTabla(dgv, "select a.Id_Incapacidad[ID], a.Fecha_Incapacidad[Fecha Ingreso], b.Nombre_Completo[Empleado], a.Fecha_Inicio[Fecha Inicio], a.Fecha_Final[Fecha Final], a.Dias, c.Area_Trabajo[Area Trabajo], a.Motivo, a.Centro_Medico[Centro Medico], a.Tipo_Enfermedad [Enfermedad], a.Refrendado from Incapacidad a inner join Identificacion b  on a.Id_Identificacion = b.Id_Identificacion inner join Puesto c On b.Id_Puesto = c.Id_Puesto Where a.Fecha_Incapacidad = '" + dtpFiltrado.Value.ToString("yyyy/MM/dd") + "'");
            }            
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                bd.AbrirConexion();
                cmd = new SqlCommand("delete from Incapacidad where Id_Incapacidad = " + Id_Incapacidad + "", bd.sc);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Insert into Bitacora values('" + "INCAPACIDAD" + "', '" + Usuario + "', '" + "Elimino la Incapacidad de: " + txtNombre.Text + "', '" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "')", bd.sc);
                cmd.ExecuteNonQuery();

                ActualizarDGV();
                bd.CerrarConexion();
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la incapacidad: " + ex.ToString(), "Error" ,MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Id_Incapacidad =  Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            txtMotivo.Text = dgv.Rows[e.RowIndex].Cells["Motivo"].Value.ToString();
            txtEnfermedad.Text = dgv.Rows[e.RowIndex].Cells["Enfermedad"].Value.ToString();
            txtNombre.Text = dgv.Rows[e.RowIndex].Cells["Empleado"].Value.ToString();
            txtCentroMedico.Text = dgv.Rows[e.RowIndex].Cells["Centro Medico"].Value.ToString();
            dtpInicio.Value = DateTime.Parse(dgv.Rows[e.RowIndex].Cells["Fecha Inicio"].Value.ToString());
            dtpFinal.Value = DateTime.Parse(dgv.Rows[e.RowIndex].Cells["Fecha Final"].Value.ToString());
            cmbArea.Text = dgv.Rows[e.RowIndex].Cells["Area Trabajo"].Value.ToString();
            Refrendado = dgv.Rows[e.RowIndex].Cells["Refrendado"].Value.ToString();
            txtDias.Text = dgv.Rows[e.RowIndex].Cells["Dias"].Value.ToString();

            if (Refrendado == "Si")
            {
                CbxRefrendadoSi.Checked = true;
            }
            else
            {
                cbxRefrendadoNo.Checked = true;
            }

            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DateTime fechaActual = DateTime.Now;
            try
            {
                bd.AbrirConexion();
                SqlCommand cmd = new SqlCommand("update Incapacidad set Fecha_Inicio='" + dtpInicio.Value.ToString("yyyy/MM/dd") + "', Fecha_Final= '" + dtpFinal.Value.ToString("yyyy/MM/dd") + "', Motivo ='" + txtMotivo.Text + "',  Centro_Medico='" + txtCentroMedico.Text + "', Tipo_Enfermedad='" + txtEnfermedad.Text + "', Refrendado='" + Refrendado + "', Dias=" + Convert.ToInt32(txtDias.Text) + " where Id_Incapacidad = " + Id_Incapacidad+ "",  bd.sc);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("Insert into Bitacora values('" + "INCAPACIDAD" + "', '" + Usuario + "', '" + "Actualizo la Incapacidad de: " + txtNombre.Text  + "', '" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "')", bd.sc);
                cmd.ExecuteNonQuery();

                ActualizarDGV();

                Limpiar();
                bd.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bd.CerrarConexion();
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Guardar archivo";
            saveFileDialog.Filter = "Archivos de Excel (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {

                string rutaArchivo = saveFileDialog.FileName;


                IWorkbook libro = new XSSFWorkbook();
                ISheet hojaTrabajo = libro.CreateSheet("Hoja1");



                ICellStyle estiloEncabezado = libro.CreateCellStyle();
                estiloEncabezado.FillForegroundColor = IndexedColors.Gold.Index;
                estiloEncabezado.FillPattern = FillPattern.SolidForeground;
                IFont fuenteEncabezado = libro.CreateFont();
                fuenteEncabezado.Boldweight = (short)FontBoldWeight.Bold;
                estiloEncabezado.SetFont(fuenteEncabezado);


                IRow filaEncabezado = hojaTrabajo.CreateRow(0);
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ICell celdaEncabezado = filaEncabezado.CreateCell(i);
                    celdaEncabezado.SetCellValue(dgv.Columns[i].HeaderText);
                    celdaEncabezado.CellStyle = estiloEncabezado;
                }

                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    IRow fila = hojaTrabajo.CreateRow(i + 1);
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        fila.CreateCell(j).SetCellValue(dgv.Rows[i].Cells[j].Value.ToString());



                    }
                }

                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    hojaTrabajo.AutoSizeColumn(i);
                }

                // Guardar el libro de Excel en la ruta especificada por el usuario
                using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
                {
                    libro.Write(archivo);
                }

                MessageBox.Show("Archivo guardado exitosamente.", "Archivo Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
