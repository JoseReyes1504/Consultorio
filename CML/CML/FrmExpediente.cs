using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CML
{
    public partial class FrmExpediente : Form
    {

        //Se carga la clase de BD
        ConexionBD bd = new ConexionBD();
        clsValidaciones val = new clsValidaciones();

        SqlCommand cmd;
        SqlDataReader dr;

        DateTime fechaActual = DateTime.Today;

        //Variables
        string Sexo = "Masculino";
        int AreaTrabajo;
        bool DatosCargardos;
        string Usuario = "";


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

        public FrmExpediente(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;
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

        public void Limpiar()
        {
            txtIdentidad.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtDomicilio.Clear();
            txtReside.Clear();
            txtOrigen.Clear();
            txtOcupacion.Clear();
            txtReligion.Clear();
            txtEscolaridad.Clear();
            txtEstado.Clear();
            txtEmail.Clear();
            txtHepatopatia.Clear();
            Sexo = "Masculino";
            rbM.Checked = true;
            btnActualizar.Enabled = false;
            cmbArea.SelectedIndex = 0;
            txtNumeroRef.Clear();
            txtEdad.Clear();
            txtCodigo.Clear();
            DatosCargardos = true;
            btnAgregar.Enabled = false;

            diabetes = 0;
            Hepa = 0;
            Asma = 0;
            Endoctrina = 0;
            interrogados = 0;
            Hipertension = 0;
            Nefropatia = 0;
            Cancer = 0;
            CardioPatia = 0;
            Mental = 0;
            Alergicas = 0;
            otros = 0;

            Actuales = 0;
            Quirurgicas = 0;
            Transfusionales = 0;
            Alergias = 0;
            Traumaticos = 0;
            Hospitalizaciones = 0;
            Adcciones = 0;
            otros2 = 0;

            Id_Enfermedades = 0;
            Id_Identificacion = 0;
            Id_antecedentes = 0;

            txtAdicciones.Clear();
            txtAlergias.Clear();
            txtAlergicas.Clear();
            txtAsma.Clear();
            txtCancer.Clear();
            txtCardiopatia.Clear();
            txtDiabetes.Clear();
            txtEnActuales.Clear();
            txtEndoctrina.Clear();
            txtHipertension.Clear();
            txtHospitalizaciones.Clear();
            txtInterrogados.Clear();
            txtMentales.Clear();
            txtNefropatia.Clear();
            txtOtrosH.Clear();
            txtQuirurgicos.Clear();
            txtOtrosP.Clear();
            txtTransfusionales.Clear();
            txtTraumaticos.Clear();

            cbxAdicciones.Checked = false;
            cbxAlergias.Checked = false;
            cbxHepatopatia.Checked = false;
            cbxAlergicas.Checked = false;
            cbxAsma.Checked = false;
            cbxCancer.Checked = false;
            cbxCardiopatia.Checked = false;
            cbxDiabetes.Checked = false;
            cbxEnActuales.Checked = false;
            cbxEndocrinas.Checked = false;
            cbxHipertension.Checked = false;
            cbxHospitalizaciones.Checked = false;
            cbxInterrogados.Checked = false;
            cbxMentales.Checked = false;
            cbxNefropatia.Checked = false;
            cbxOtrosH.Checked = false;
            cbxQuirurgicos.Checked = false;
            cbxOtrosP.Checked = false;
            cbxTransfusionales.Checked = false;
            cbxTraumaticos.Checked = false;
        }

        private void txtIdentidad_TextChanged(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;
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
                        Id_Identificacion = Convert.ToInt32(dr["Id_Identificacion"].ToString());
                        cmbArea.SelectedIndex = Convert.ToInt32(dr["Id_Puesto"].ToString());


                        if (dr["Fecha_Nacimiento"].ToString() != "")
                        {
                            dtpFNacimiento.Value = DateTime.Parse(dr["Fecha_Nacimiento"].ToString());
                        }

                        Sexo = dr["Sexo"].ToString();
                        if (Sexo == "Masculino")
                        {
                            rbM.Checked = true;
                        }
                        else
                        {
                            rbF.Checked = true;
                        }
                        txtNumeroRef.Text = dr["Numero_Referencia"].ToString();
                        txtEdad.Text = dr["Edad"].ToString();
                        txtCodigo.Text = dr["Codigo_Empleado"].ToString();
                        DatosCargardos = true;
                        btnAgregar.Enabled = false;
                        btnActualizar.Enabled = true;
                    }
                    dr.Close();

                    cmd = new SqlCommand("select * from Empleado a inner join Antecedentes b On a.Id_Antecedentes = b.Id_Antecendentes inner join Enfermedad_Heredo_Familiar c on b.Id_Enfermedad_H = c.Id_Enfermedad_Heredo_Familiar inner join Enfermedad_Personales_Patologicos d on b.Id_Enfermedad_P = d.Id_Enfermedad_Personales_Patologicos where a.Id_Identificacion = '" + Id_Identificacion + "' ", bd.sc);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        diabetes = Convert.ToInt32(dr["Diabetes"].ToString());
                        txtDiabetes.Text = dr["Desc_Diabetes"].ToString();
                        Hepa = Convert.ToInt32(dr["Hepatopatia"].ToString());
                        txtHepatopatia.Text = dr["Desc_Hepatopatia"].ToString();
                        Asma = Convert.ToInt32(dr["Asma"].ToString());
                        txtAsma.Text = dr["Desc_Asma"].ToString();
                        Endoctrina = Convert.ToInt32(dr["Enfermedad_Endoctrina"].ToString());
                        txtEndoctrina.Text = dr["Desc_Endoctrina"].ToString();
                        interrogados = Convert.ToInt32(dr["Interrogados_y_Negados"].ToString());
                        txtInterrogados.Text = dr["Desc_Interrogados"].ToString();
                        Hipertension = Convert.ToInt32(dr["Hipertension"].ToString());
                        txtHipertension.Text = dr["Desc_Hipertension"].ToString();
                        Nefropatia = Convert.ToInt32(dr["Nefropatia"].ToString());
                        txtNefropatia.Text = dr["Desc_Nefropatia"].ToString();
                        Cancer = Convert.ToInt32(dr["Cancer"].ToString());
                        txtCancer.Text = dr["Desc_Cancer"].ToString();
                        CardioPatia = Convert.ToInt32(dr["Cardiopatia"].ToString());
                        txtCardiopatia.Text = dr["Desc_Cardiopatia"].ToString();
                        Mental = Convert.ToInt32(dr["Enfermedad_Mental"].ToString());
                        txtMentales.Text = dr["Desc_Mental"].ToString();
                        Alergicas = Convert.ToInt32(dr["Enfermedad_Alergicas"].ToString());
                        txtAlergicas.Text = dr["Desc_Alergicas"].ToString();
                        otros = Convert.ToInt32(dr["Otros"].ToString());
                        txtOtrosH.Text = dr["Desc_Otros"].ToString();

                        Actuales = Convert.ToInt32(dr["Enfermedades_Actuales"].ToString());
                        txtEnActuales.Text = dr["Desc_Actuales"].ToString();
                        Quirurgicas = Convert.ToInt32(dr["Quirurgicos"].ToString());
                        txtQuirurgicos.Text = dr["Desc_Quirurgicas"].ToString();
                        Transfusionales = Convert.ToInt32(dr["Transfusionales"].ToString());
                        txtTransfusionales.Text = dr["Desc_Transfusionales"].ToString();
                        Alergias = Convert.ToInt32(dr["Alergias"].ToString());
                        txtAlergias.Text = dr["Desc_Alergias"].ToString();
                        Traumaticos = Convert.ToInt32(dr["Traumaticos"].ToString());
                        txtTraumaticos.Text = dr["Desc_Traumaticos"].ToString();
                        Hospitalizaciones = Convert.ToInt32(dr["Hospitalizaciones_Previas"].ToString());
                        txtHospitalizaciones.Text = dr["Desc_Hospitalizaciones"].ToString();
                        Adcciones = Convert.ToInt32(dr["Adicciones"].ToString());
                        txtAdicciones.Text = dr["Desc_Adicciones"].ToString();
                        otros2 = Convert.ToInt32(dr["Otros2"].ToString());
                        txtOtrosP.Text = dr["Desc_Otros2"].ToString();


                        CheckedInfo(Adcciones, cbxAdicciones);
                        CheckedInfo(Alergias, cbxAlergias);
                        CheckedInfo(Alergicas, cbxAlergicas);
                        CheckedInfo(Asma, cbxAsma);
                        CheckedInfo(Cancer, cbxCancer);
                        CheckedInfo(CardioPatia, cbxCardiopatia);
                        CheckedInfo(diabetes, cbxDiabetes);
                        CheckedInfo(Actuales, cbxEnActuales);
                        CheckedInfo(Endoctrina, cbxEndocrinas);
                        CheckedInfo(Hipertension, cbxHipertension);
                        CheckedInfo(Hospitalizaciones, cbxHospitalizaciones);
                        CheckedInfo(interrogados, cbxInterrogados);
                        CheckedInfo(Mental, cbxMentales);
                        CheckedInfo(Nefropatia, cbxNefropatia);
                        CheckedInfo(otros, cbxOtrosH);
                        CheckedInfo(Quirurgicas, cbxQuirurgicos);
                        CheckedInfo(Transfusionales, cbxTransfusionales);
                        CheckedInfo(otros2, cbxOtrosP);
                        CheckedInfo(Traumaticos, cbxTraumaticos);

                    }
                    dr.Close();
                    bd.CerrarConexion();

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
            if (cmbArea.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el area de trabajo", "Ingresar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbArea.DroppedDown = true;
            }
            else
            {
                try
                {
                    bd.AbrirConexion();
                    //Este codigo es para llenar la identificación del empleado
                    cmd = new SqlCommand("insert into Identificacion values ('" + txtCodigo.Text + "', '" + txtNombre.Text + "', '" + dtpFNacimiento.Value.ToString("yyyy/MM/dd") + "', '" + txtIdentidad.Text + "', '" + Sexo + "', '" + txtEstado.Text + "', '" + txtOcupacion.Text + "', '" + txtOrigen.Text + "', '" + txtReside.Text + "', '" + txtDomicilio.Text + "', '" + txtTelefono.Text + "', '" + txtReligion.Text + "', '" + txtEscolaridad.Text + "', '" + txtEmail.Text + "',  '" + txtNumeroRef.Text + "', '" + AreaTrabajo + "', '" + null + "', '" + "Activo" + "', '" + txtEdad.Text + "')", bd.sc);
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


                    cmd = new SqlCommand("insert into Antecedentes values (" + Id_Enfermedades + ", " + Id_Enfermedades + ")", bd.sc);
                    cmd.ExecuteNonQuery();

                    Id_antecedentes = bd.ObtenerId("Antecedentes", "Id_Antecendentes");

                    cmd = new SqlCommand("insert into Empleado values ('" + dtpFElaboracion.Value.ToString("yyyy/MM/dd") + "', " + Id_Identificacion + ", " + Id_antecedentes + ")", bd.sc);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Se creo con exito", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    bd.CerrarConexion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error: " + ex.ToString());
                    bd.CerrarConexion();
                }
            }
        }



        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (cmbArea.SelectedIndex == 0)
            {
                MessageBox.Show("Seleccione el area de trabajo", "Ingresar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbArea.DroppedDown = true;
            }
            else
            {
                try
                {
                    bd.AbrirConexion();

                    //Este codigo es para llenar la identificación del empleado
                    cmd = new SqlCommand("update Identificacion set Codigo_Empleado ='" + txtCodigo.Text + "', Nombre_Completo ='" + txtNombre.Text + "', Fecha_Nacimiento='" + dtpFNacimiento.Value.ToString("yyyy/MM/dd") + "', No_Identidad= '" + txtIdentidad.Text + "', Sexo='" + Sexo + "', Estado_Civil='" + txtEstado.Text + "', Ocupacion='" + txtOcupacion.Text + "',Origen= '" + txtOrigen.Text + "', Reside='" + txtReside.Text + "', Domicilio='" + txtDomicilio.Text + "', Telefono='" + txtTelefono.Text + "', Religion='" + txtReligion.Text + "', Escolaridad='" + txtEscolaridad.Text + "', Email='" + txtEmail.Text + "',  Numero_Referencia='" + txtNumeroRef.Text + "', Id_Puesto='" + AreaTrabajo + "', Imagen= '" + null + "',Estado= '" + "Activo" + "', Edad='" + txtEdad.Text + "'where No_Identidad= '" + txtIdentidad.Text + "'", bd.sc);
                    cmd.ExecuteNonQuery();

                    Id_Enfermedades = bd.ObtenerEnfermedades(txtIdentidad);
                    Id_Identificacion = bd.ObtenerIdentificacion(txtIdentidad);

                    //Este es para llenar los tipos de enfermedades de las que el padece
                    cmd = new SqlCommand("update Enfermedad_Heredo_Familiar set Diabetes= " + diabetes + ", Desc_Diabetes= '" + txtDiabetes.Text + "', Hepatopatia= " + Hepa + ", Desc_Hepatopatia= '" + txtHepatopatia.Text + "', Asma= " + Asma + ", Desc_Asma='" + txtAsma.Text + "', Enfermedad_Endoctrina="
                        + Endoctrina + ", Desc_Endoctrina='" + txtEndoctrina.Text + "', Interrogados_y_Negados= " + interrogados + ", Desc_Interrogados= '" + txtInterrogados.Text + "', Hipertension= " + Hipertension + ", Desc_Hipertension= '" + txtHipertension.Text + "', Nefropatia= " + Nefropatia + ", Desc_Nefropatia= '" + txtNefropatia.Text + "', Cancer=" + Cancer + ", Desc_Cancer='" + txtCancer.Text + "', Cardiopatia=" +
                        "" + CardioPatia + ", Desc_Cardiopatia='" + txtCardiopatia.Text + "', Enfermedad_Mental= " + Mental + ",  Desc_Mental= '" + txtMentales.Text + "', Enfermedad_Alergicas= " + Alergicas + ", Desc_Alergicas= '" + txtAlergicas.Text + "', Otros= " + otros + ", Desc_Otros= '" + txtOtrosH.Text + "' where Id_Enfermedad_Heredo_Familiar = " + Id_Enfermedades + "", bd.sc);
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("update Enfermedad_Personales_Patologicos set Enfermedades_Actuales=" + Actuales + ", Desc_Actuales='" + txtEnActuales.Text + "', Quirurgicos=" + Quirurgicas + ", Desc_Quirurgicas='" + txtQuirurgicos.Text + "', Transfusionales=" + Transfusionales + ", Desc_Transfusionales='" + txtTransfusionales.Text + "', Alergias=" + Alergias + ", Desc_Alergias=" +
                        "'" + txtAlergias.Text + "', Traumaticos=" + Traumaticos + ", Desc_Traumaticos='" + txtTraumaticos.Text + "', Hospitalizaciones_Previas=" + Hospitalizaciones + ", Desc_Hospitalizaciones='" + txtHospitalizaciones.Text + "', Adicciones=" + Adcciones + ", Desc_Adicciones='" + txtAdicciones.Text + "', Otros2=" + otros2 + ", Desc_Otros2='" + txtOtrosP.Text + "' where Id_Enfermedad_Personales_Patologicos= " + Id_Enfermedades + "", bd.sc);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Se Actualizo con exito", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    cmd = new SqlCommand("Insert into Bitacora values('" + "EXPEDIENTE" + "', '" + Usuario + "', '" + "Actualizo la información de: " + txtNombre.Text + "', '" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "')", bd.sc);
                    cmd.ExecuteNonQuery();

                    Limpiar();
                    bd.CerrarConexion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error: " + ex.ToString());
                    bd.CerrarConexion();
                }
            }
        }

        private void rbM_CheckedChanged(object sender, EventArgs e)
        {
            if (rbM.Checked == true)
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
            AreaTrabajo = cmbArea.SelectedIndex;
        }

        private void FrmExpediente_Load(object sender, EventArgs e)
        {
            bd.cbAreaTrabajo(cmbArea);
            cmbArea.SelectedIndex = 0;
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

        public void CheckedInfo(int Enfermedad, CheckBox cb)
        {
            if (Enfermedad == 1)
            {
                cb.Checked = true;
            }
            else
            {
                cb.Checked = false;
            }
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtIdentidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }
    }
}
