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
    public partial class FrmExpediente : Form
    {

        //Se carga la clase de BD
        ConexionBD bd = new ConexionBD();
        clsValidaciones val = new clsValidaciones();

        SqlCommand cmd;
        SqlDataReader dr;

        //Variables
        string Sexo = "Masculino";
        int AreaTrabajo;
        bool DatosCargardos;



        //Variables enfermedad
        int diabetes = 0;
        int Hepa = 0;
        int Asma = 0;
        int Endoctrina = 0;
        int interrogados = 0;
        int Hipertension = 0;
        int Nefropatia = 0;
        int Cancer = 0;
        int CardioPatia = 0;
        int Mental = 0;
        int Alergicas = 0;
        int otros = 0;

        int Actuales = 0;
        int Quirurgicas = 0;
        int Transfusionales = 0;
        int Alergias = 0;
        int Traumaticos = 0;
        int Hospitalizaciones = 0;
        int Adcciones = 0;
        int otros2 = 0;

        int Id_Enfermedades = 0;
        int Id_Identificacion = 0;
        int Id_antecedentes = 0;
        public FrmExpediente()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            this.Hide();
            frmMenu.Show();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void gbAntecedentes_Enter(object sender, EventArgs e)
        {

        }

        private void txtIdentidad_TextChanged(object sender, EventArgs e)
        {
            int codigo = 0;
            string Sexo;
            if (txtIdentidad.TextLength == 13)
            {
                try
                {
                    bd.AbrirConexion();
                    cmd = new SqlCommand("select* from Identificacion where No_Identidad = '" + txtIdentidad.Text + "'", bd.sc);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtNombre.Text = dr["Nombre_Completo"].ToString();
                        txtTelefono.Text = dr["Telefono"].ToString();
                        txtDomicilio.Text = dr["Domicilio"].ToString();
                        txtReside.Text = dr["Reside"].ToString();
                        txtOrigen.Text = dr["Origen"].ToString();
                        txtOcupacion.Text = dr["Ocupacion"].ToString();
                        txtReligion.Text = dr["Religion"].ToString();
                        txtEscolaridad.Text = dr["Escolaridad"].ToString();
                        txtEstado.Text = dr["Estado_Civil"].ToString();
                        txtEmail.Text = dr["Email"].ToString();
                        dtpFNacimiento.Value = DateTime.Parse(dr["Fecha_Nacimiento"].ToString());
                        Sexo = dr["Sexo"].ToString();
                        if(Sexo == "Masculino")
                        {
                            rbM.Checked = true;
                        }
                        else
                        {
                            rbF.Checked = true;
                        }
                        txtNumeroRef.Text = dr["Numero_Referencia"].ToString();
                        txtEdad.Text = dr["Edad"].ToString();
                        codigo = Convert.ToInt32(dr["Id_Puesto"].ToString());
                        cmbArea.SelectedIndex = codigo - 1;
                        txtCodigo.Text = dr["Codigo_Empleado"].ToString();
                        DatosCargardos = true;
                        //btnAgregar.Enabled = false;
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
        }

        private void dtpFNacimiento_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFNacimiento.Value;

            // Calcular la edad actual en años
            int edad = DateTime.Today.Year - fechaSeleccionada.Year;

            // Restar un año si la fecha actual es anterior al día y mes de nacimiento
            if (DateTime.Today.Month < fechaSeleccionada.Month || (DateTime.Today.Month == fechaSeleccionada.Month && DateTime.Today.Day < fechaSeleccionada.Day))
            {
                edad--;
            }
            txtEdad.Text = edad.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            try
            {
                bd.AbrirConexion();
                //Este codigo es para llenar la identificación del empleado
                cmd = new SqlCommand("insert into Identificacion values ('" + txtCodigo.Text + "', '" + txtNombre.Text + "', '" + dtpFNacimiento.Value.ToString("yyyy/MM/dd") + "', '" + txtIdentidad.Text + "', '" + Sexo + "', '" + txtEstado.Text + "', '" + txtOcupacion.Text + "', '" + txtOrigen.Text + "', '" + txtReside.Text + "', '" + txtDomicilio.Text + "', '" + txtTelefono.Text + "', '" + txtReligion.Text + "', '" + txtEscolaridad.Text + "', '" + txtEmail.Text + "',  '" + txtNumeroRef.Text + "', '" + AreaTrabajo + "', '" +  null + "', '" + "Activo" + "', '" + txtEdad.Text + "')", bd.sc);
                cmd.ExecuteNonQuery();

                //Este es para llenar los tipos de enfermedades de las que el padece
                cmd = new SqlCommand("insert into Enfermedad_Heredo_Familiar values (" + diabetes + ", '" + txtDiabetes.Text + "', " + Hepa + ", '" + txtHepatopatia.Text + "', " + Asma + ", '" + txtAsma.Text + "'," 
                    + Endoctrina + ", '" + txtEndoctrina.Text + "', " + interrogados + ", '" + txtInterrogados.Text + "'," + Hipertension + ", '" + txtHipertension.Text + "'," + Nefropatia + ", '" + txtNefropatia.Text + "'," + Cancer + ", '" + txtCancer.Text + "', " +
                    "" + CardioPatia + ", '" + txtCardiopatia.Text + "'," + Mental + ", '" + txtMentales.Text + "'," + Alergicas + ", '" + txtAlergicas.Text + "'," + otros + ", '" + txtOtrosH.Text + "')", bd.sc);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("insert into Enfermedad_Personales_Patologicos values (" + Actuales + ", '" + txtEnActuales.Text + "'," + Quirurgicas + ", '" + txtQuirurgicos.Text + "', " + Transfusionales + ", '" + txtTransfusionales.Text + "'," + Alergias + ", " +
                    "'" + txtAlergias.Text + "'," + Traumaticos + ", '" + txtTraumaticos.Text + "'," + Hospitalizaciones + ", '" + txtHospitalizaciones.Text + "'," + Adcciones + ", '" + txtAdicciones.Text + "', " + otros2 + ", '" + txtOtrosP.Text + "')", bd.sc);
                cmd.ExecuteNonQuery();

                Id_Enfermedades = bd.ObtenerId("Enfermedad_Personales_Patologicos", "Id_Enfermedad_Personales_Patologicos");
                Id_Identificacion = bd.ObtenerIdentificacion(txtIdentidad); 
               



                cmd = new SqlCommand("insert into Antecedentes values (" + Id_Enfermedades + ", " + Id_Enfermedades+")", bd.sc);
                cmd.ExecuteNonQuery();
                
                Id_antecedentes = bd.ObtenerId("Antecedentes", "Id_Antecendentes");

                cmd = new SqlCommand("insert into Empleado values ('" + dtpFElaboracion.Value.ToString("yyyy/MM/dd")  + "', " + Id_Identificacion + ", " + Id_antecedentes + ")", bd.sc);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Se creo con exito", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                bd.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error: " + ex.ToString());
                bd.CerrarConexion();
            }            
        }

        private void rbM_CheckedChanged(object sender, EventArgs e)
        {
            if(rbM.Checked == true)
            {
                Sexo = "Masculino";
            }
        }

        private void rbF_CheckedChanged(object sender, EventArgs e)
        {
            if (rbF.Checked == true)
            {
                Sexo = "Femenino";
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaTrabajo = (cmbArea.SelectedIndex + 1);
        }

        private void FrmExpediente_Load(object sender, EventArgs e)
        {
            cmbArea.SelectedIndex = 0;
            bd.cbAreaTrabajo(cmbArea);
        }

        public int Checked(CheckBox cb, int enfermedad)
        {
            if (cb.Checked == true)
            {
                enfermedad = 1;                
            }
            else
            {
                enfermedad = 0;
            }
            return enfermedad;
        }

        private void cbxDiabetes_CheckedChanged(object sender, EventArgs e)
        {
            diabetes = Checked(cbxDiabetes, diabetes);
            
        }

        private void cbxHepatopatia_CheckedChanged(object sender, EventArgs e)
        {
            Hepa = Checked(cbxHepatopatia, Hepa);
        }

        private void cbxAsma_CheckedChanged(object sender, EventArgs e)
        {
            Asma = Checked(cbxAsma, Asma);
        }

        private void cbxEndocrinas_CheckedChanged(object sender, EventArgs e)
        {
            Endoctrina = Checked(cbxEndocrinas, Endoctrina);
        }

        private void cbxInterrogados_CheckedChanged(object sender, EventArgs e)
        {
            interrogados = Checked(cbxInterrogados, interrogados);
        }

        private void cbxHipertension_CheckedChanged(object sender, EventArgs e)
        {
            Hipertension = Checked(cbxHipertension, Hipertension);
        }

        private void cbxNefropatia_CheckedChanged(object sender, EventArgs e)
        {
            Nefropatia = Checked(cbxNefropatia, Nefropatia);
        }

        private void cbxCancer_CheckedChanged(object sender, EventArgs e)
        {
            Cancer = Checked(cbxCancer, Cancer);
        }

        private void cbxOtrosH_CheckedChanged(object sender, EventArgs e)
        {
            otros = Checked(cbxOtrosH, otros);
        }

        private void cbxCardiopatia_CheckedChanged(object sender, EventArgs e)
        {
            CardioPatia = Checked(cbxCardiopatia, CardioPatia);
        }

        private void cbxMentales_CheckedChanged(object sender, EventArgs e)
        {
            Mental = Checked(cbxMentales, Mental);
        }

        private void cbxAlergicas_CheckedChanged(object sender, EventArgs e)
        {
            Alergicas = Checked(cbxAlergicas, Alergicas);
        }

        private void cbxEnActuales_CheckedChanged(object sender, EventArgs e)
        {
            Actuales = Checked(cbxEnActuales, Actuales);
        }

        private void cbxQuirurgicos_CheckedChanged(object sender, EventArgs e)
        {
            Quirurgicas = Checked(cbxQuirurgicos, Quirurgicas);
        }

        private void cbxTransfusionales_CheckedChanged(object sender, EventArgs e)
        {
            Transfusionales = Checked(cbxTransfusionales, Transfusionales);
        }

        private void cbxAlergias_CheckedChanged(object sender, EventArgs e)
        {
            Alergias = Checked(cbxAlergias, Alergias);
        }

        private void cbxTraumaticos_CheckedChanged(object sender, EventArgs e)
        {
            Traumaticos = Checked(cbxTraumaticos, Traumaticos);
        }

        private void cbxHospitalizaciones_CheckedChanged(object sender, EventArgs e)
        {
            Hospitalizaciones = Checked(cbxHospitalizaciones, Hospitalizaciones);
        }

        private void cbxAdicciones_CheckedChanged(object sender, EventArgs e)
        {
            Adcciones = Checked(cbxAdicciones, Adcciones);
        }

        private void cbxOtrosP_CheckedChanged(object sender, EventArgs e)
        {
            otros2 = Checked(cbxOtrosP, otros2);
        }
    }
}
