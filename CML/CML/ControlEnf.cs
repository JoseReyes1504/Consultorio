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
    }
}
