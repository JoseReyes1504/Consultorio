using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.IO;
using System.Windows.Forms;


namespace CML
{
    public partial class ControlEnf : Form
    {
        ConexionBD bd = new ConexionBD();
        public ControlEnf()
        {
            InitializeComponent();
        }

        private void ControlEnf_Load(object sender, EventArgs e)
        {
            bd.CualquierTabla(dgv, "select a.Id_Consultorio [Id], a.Fecha_Consulta [Fecha], c.Nombre_Completo[Nombre Del Empleado], d.Area_Trabajo[Departamento], a.Impresion_Diagnostico [Impresión Diagnostico], a.Tratamiento[Medicamento] from Consultorio a inner join Empleado b  On a.Id_Empleado = b.Id_Empleado inner join Identificacion c On b.Id_Identificacion = c.Id_Identificacion inner join Puesto d On c.Id_Puesto = d.Id_Puesto ");
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

                MessageBox.Show("Archivo guardado exitosamente.", "Archivo Excel",  MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void ExportarDataGridViewAExcel(DataGridView dataGridView, string nombreArchivo)
        {
            MessageBox.Show("Entro");
            // Crear un nuevo libro de Excel y una hoja de trabajo
            IWorkbook libro = new XSSFWorkbook();
            ISheet hojaTrabajo = libro.CreateSheet("Hoja1");

            // Crear la fila de encabezado
            IRow filaEncabezado = hojaTrabajo.CreateRow(0);
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                filaEncabezado.CreateCell(i).SetCellValue(dataGridView.Columns[i].HeaderText);
            }

            // Copiar los datos del DataGridView al archivo de Excel
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                IRow fila = hojaTrabajo.CreateRow(i + 1);
                for (int j = 0; j < dataGridView.Columns.Count; j++)
                {
                    fila.CreateCell(j).SetCellValue(dataGridView.Rows[i].Cells[j].Value.ToString());
                }
            }

            // Autoajustar el ancho de las columnas
            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                hojaTrabajo.AutoSizeColumn(i);
            }

            // Guardar el libro de Excel en un archivo
            using (FileStream archivo = new FileStream(nombreArchivo, FileMode.Create, FileAccess.Write))
            {
                libro.Write(archivo);
            }
        }

    }
}
