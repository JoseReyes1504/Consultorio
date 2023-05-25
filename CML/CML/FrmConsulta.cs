using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CML
{
    public partial class FrmConsulta : Form
    {
        //Se carga la clase de BD
        ConexionBD bd = new ConexionBD();
        clsValidaciones val = new clsValidaciones();

        //Variables
        int AreaTrabajo;
        DateTime hoy = DateTime.Today;
        int Id_Identificacion;
        int Id_Empleado;
        int Id_Signos;
        string Incapacidad = "No";
        bool DatosCargados = false;
        int IDConsulta = 0;
        int Id_Consultorio = 0;
        string Usuario = "";
        SqlCommand cmd;
        SqlDataReader dr;


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


        public void Limpiar()
        {
            txtIdentidad.Clear();
            txtNombre.Clear();
            txtCodigo.Clear();
            txtNumeroRef.Clear();
            txtEdad.Clear();
            cmbArea.SelectedIndex = 0;
            cmbArea.Text = "Seleccionar";
            txtAntececentes.Text = "N/D";
        }

        public void LimpiarTodo()
        {
            Limpiar();
            txtSO2.Clear();
            txtT.Clear();
            txtPA.Clear();
            txtFR.Clear();
            txtFC.Clear();
            txtMotivo.Clear();
            txtConducta.Clear();
            txtHistoria.Clear();
            txtExamen.Clear();
            txtTratamiento.Clear();
            txtImpresion.Clear();
            Incapacidad = "No";
            btnNo.Checked = true;
        }

        public FrmConsulta()
        {
            InitializeComponent();
        }
        public FrmConsulta(int ID, string usuario = "")
        {
            InitializeComponent();
            Usuario = usuario;
            IDConsulta = ID;

        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu = new FrmMenu();
            this.Hide();
            frmMenu.Show();
        }

        public void CrearIdentidad()
        {
            DialogResult r = new DialogResult();
            //Si existe el Numero de identidad no se creara una nueva identificacion            
            if (ValidarEmpleado() == true)
            {
                MessageBox.Show("Este Numero de identidad ya esta en uso", "Empleado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                DatosCargados = false;
            }
            else
            {
                //Primero Se Agragan los datos a la tabla identificación
                cmd = new SqlCommand("insert into Identificacion (Codigo_Empleado, Nombre_Completo, No_Identidad, Telefono, Id_Puesto, Edad)  values ('" + txtCodigo.Text + "', '" + txtNombre.Text + "', '" + txtIdentidad.Text + "', '" + txtNumeroRef.Text + "', '" + AreaTrabajo + "', '" + txtEdad.Text + "')", bd.sc);
                cmd.ExecuteNonQuery();

                //Este es para llenar los tipos de enfermedades de las que el padece            
                cmd = new SqlCommand("insert into Enfermedad_Heredo_Familiar values (" + diabetes + ", '" + null + "', " + Hepa + ", '" + null + "', " + Asma + ", '" + null + "',"
                    + Endoctrina + ", '" + null + "', " + interrogados + ", '" + null + "'," + Hipertension + ", '" + null + "'," + Nefropatia + ", '" + null + "'," + Cancer + ", '" + null + "', " +
                    "" + CardioPatia + ", '" + null + "'," + Mental + ", '" + null + "'," + Alergicas + ", '" + null + "'," + otros + ", '" + null + "')", bd.sc);
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("insert into Enfermedad_Personales_Patologicos values (" + Actuales + ", '" + null + "'," + Quirurgicas + ", '" + null + "', " + Transfusionales + ", '" + null + "'," + Alergias + ", " +
                    "'" + null + "'," + Traumaticos + ", '" + null + "'," + Hospitalizaciones + ", '" + null + "'," + Adcciones + ", '" + null + "', " + otros2 + ", '" + null + "')", bd.sc);
                cmd.ExecuteNonQuery();

                Id_Enfermedades = bd.ObtenerId("Enfermedad_Personales_Patologicos", "Id_Enfermedad_Personales_Patologicos");
                Id_Identificacion = bd.ObtenerIdentificacion(txtIdentidad);


                cmd = new SqlCommand("insert into Antecedentes values (" + Id_Enfermedades + "," + Id_Enfermedades + ")", bd.sc);
                cmd.ExecuteNonQuery();

                //Despues a la tabla empleados ya que esta es dependiente de una llave foranea
                cmd = new SqlCommand("insert into Empleado values ('" + hoy.ToString("yyyy/MM/dd") + "', " + Id_Identificacion + ", " + Id_Enfermedades + ")", bd.sc);
                cmd.ExecuteNonQuery();
                DatosCargados = true;

                r = MessageBox.Show("Se creo el expediente de " + txtNombre.Text + "\nQuiere crear la consulta?", "Información", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (r == DialogResult.Yes)
                {
                    Consulta();
                }
                else
                {
                    MessageBox.Show("Se creo el expediente pero no la consulta", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        public void Consulta()
        {
            DateTime fechaSeleccionada = dtpFecha.Value.Date;
            DateTime horaActual = DateTime.Now;
            DateTime fechaYHora = fechaSeleccionada.Date + horaActual.TimeOfDay;

            DialogResult C = new DialogResult();

            Id_Identificacion = bd.ObtenerIdentificacion(txtIdentidad);

            //Hacemos la busqueda del Empleado creado mediante la identidad

            Id_Empleado = bd.ObtenerId("Empleado", "Id_Empleado");

            //Creamos los Signos Vitales
            cmd = new SqlCommand("insert into Signos_Vitales_Consultorio values ('" + txtPA.Text + "','" + txtT.Text + "','" + txtFC.Text + "','" + txtFR.Text + "','" + txtSO2.Text + "')", bd.sc);
            cmd.ExecuteNonQuery();

            //Obtenemos el ID del ultimo signo vital creado
            Id_Signos = bd.ObtenerId("Signos_Vitales_Consultorio", "Id_Signos_Vitales_Consultorio");

            //Al final creamos la consulta
            cmd = new SqlCommand("insert into Consultorio values('" + Id_Empleado + "','" + txtAntececentes.Text + "','" + Id_Signos + "','" + txtHistoria.Text + "','" + txtExamen.Text + "','" + txtImpresion.Text + "','" + txtTratamiento.Text + "','" + txtConducta.Text + "','" + Incapacidad + "', '" + fechaYHora.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + txtMotivo.Text + "')", bd.sc);
            cmd.ExecuteNonQuery();

            C = MessageBox.Show("Se Creo la consulta, \nDesea imprimir la consulta?", "Consulta", MessageBoxButtons.YesNo, MessageBoxIcon.Information);


            if (C == DialogResult.Yes)
            {
                Reportes re = new Reportes();
                re.Nun_Consulta1 = bd.ObtenerId("Consultorio", "Id_Consultorio");
                re.ShowDialog();
            }

            LimpiarTodo();
        }

        public bool ValidarEmpleado()
        {
            string ID_Empleado = "";
            //Validamos si el empleado ya existe
            try
            {
                cmd = new SqlCommand("select* from Identificacion where No_Identidad = '" + txtIdentidad.Text + "'", bd.sc);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ID_Empleado = dr["No_Identidad"].ToString();
                }
                dr.Close();

                if (txtIdentidad.Text == ID_Empleado)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error con el empleado" + ex.ToString(), "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bd.CerrarConexion();
            }
            return false;
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                bd.AbrirConexion();

                if (DatosCargados == false)
                {
                    CrearIdentidad();
                }
                else
                {
                    Consulta();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se han podido agregar los datos de la consulta:  " + ex);
                bd.CerrarConexion();
            }
            bd.CerrarConexion();
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {
            bd.cbAreaTrabajo(cmbArea);
            cmbArea.SelectedIndex = 0;
            string codigo = "";

            if (IDConsulta != 0)
            {
                try
                {
                    bd.AbrirConexion();

                    cmd = new SqlCommand("select a.Id_Consultorio, c.No_Identidad, c.Nombre_Completo, c.Codigo_Empleado, c.Telefono, c.Edad, c.Id_Puesto, a.Motivo_Consulta, a.Conducta, a.Examen_Fisico, a.Historia_Enfermedad_Actual, a.Fecha_Consulta, a.Antecedentes_Personales, a.Impresion_Diagnostico, a.Tratamiento, a.Incapacidad, d.Id_Signos_Vitales_Consultorio,  d.Presion_Arterial, d.Frecuencia_Cardiaca,d.Frecuencia_Respiratoria, d.Saturacion_Oxigeno, d.Temperatura from Consultorio a inner join Empleado b  on a.Id_Empleado = b.Id_Empleado inner join Identificacion c on b.Id_Identificacion = c.Id_Identificacion inner join Signos_Vitales_Consultorio d on a.Id_Signos_Vitales_Consultorio = d.Id_Signos_Vitales_Consultorio where a.Id_Consultorio = " + IDConsulta + "", bd.sc);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        txtMotivo.Text = dr["Motivo_Consulta"].ToString();
                        txtExamen.Text = dr["Examen_Fisico"].ToString();
                        txtConducta.Text = dr["Conducta"].ToString();
                        txtTratamiento.Text = dr["Tratamiento"].ToString();
                        txtHistoria.Text = dr["Historia_Enfermedad_Actual"].ToString();
                        txtImpresion.Text = dr["Impresion_Diagnostico"].ToString();
                        dtpFecha.Value = DateTime.Parse(dr["Fecha_Consulta"].ToString());
                        txtPA.Text = dr["Presion_Arterial"].ToString();
                        txtT.Text = dr["Temperatura"].ToString();
                        txtSO2.Text = dr["Saturacion_Oxigeno"].ToString();
                        txtFC.Text = dr["Frecuencia_Cardiaca"].ToString();
                        txtFR.Text = dr["Frecuencia_Respiratoria"].ToString();
                        codigo = dr["Codigo_Empleado"].ToString();
                        Id_Signos = Convert.ToInt32(dr["Id_Signos_Vitales_Consultorio"].ToString());
                        Id_Consultorio = Convert.ToInt32(dr["Id_Consultorio"].ToString());

                        if (dr["Incapacidad"].ToString() == "Si")
                        {
                            btnSi.Checked = true;
                        }
                        else
                        {
                            btnNo.Checked = true;

                        }

                    }
                    dr.Close();
                    bd.CerrarConexion();
                    txtCodigo.Text = codigo;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.ToString(), "error");
                    bd.CerrarConexion();
                }
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaTrabajo = cmbArea.SelectedIndex;
        }

        private void txtIdentidad_TextChanged(object sender, EventArgs e)
        {

        }


        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            int codigo = 0;
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
                        txtNumeroRef.Text = dr["Telefono"].ToString();
                        txtEdad.Text = dr["Edad"].ToString();
                        codigo = Convert.ToInt32(dr["Id_Puesto"].ToString());
                        cmbArea.SelectedIndex = codigo;
                        txtIdentidad.Text = dr["No_Identidad"].ToString();
                        DatosCargados = true;
                    }

                    dr.Close();

                    Id_Identificacion = bd.ObtenerIdentificacion(txtIdentidad);

                    cmd = new SqlCommand("select * from Empleado a inner join Antecedentes b On a.Id_Antecedentes = b.Id_Antecendentes inner join Enfermedad_Heredo_Familiar c on b.Id_Enfermedad_H = c.Id_Enfermedad_Heredo_Familiar inner join Enfermedad_Personales_Patologicos d on b.Id_Enfermedad_P = d.Id_Enfermedad_Personales_Patologicos where a.Id_Identificacion = '" + Id_Identificacion + "' ", bd.sc);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtAntececentes.Clear();
                        diabetes = Convert.ToInt32(dr["Diabetes"].ToString());
                        Hepa = Convert.ToInt32(dr["Hepatopatia"].ToString());
                        Asma = Convert.ToInt32(dr["Asma"].ToString());
                        Endoctrina = Convert.ToInt32(dr["Enfermedad_Endoctrina"].ToString());
                        interrogados = Convert.ToInt32(dr["Interrogados_y_Negados"].ToString());
                        Hipertension = Convert.ToInt32(dr["Hipertension"].ToString());
                        Nefropatia = Convert.ToInt32(dr["Nefropatia"].ToString());
                        Cancer = Convert.ToInt32(dr["Cancer"].ToString());
                        CardioPatia = Convert.ToInt32(dr["Cardiopatia"].ToString());
                        Mental = Convert.ToInt32(dr["Enfermedad_Mental"].ToString());
                        Alergicas = Convert.ToInt32(dr["Enfermedad_Alergicas"].ToString());
                        otros = Convert.ToInt32(dr["Otros"].ToString());

                        Actuales = Convert.ToInt32(dr["Enfermedades_Actuales"].ToString());
                        Quirurgicas = Convert.ToInt32(dr["Quirurgicos"].ToString());
                        Transfusionales = Convert.ToInt32(dr["Transfusionales"].ToString());
                        Alergias = Convert.ToInt32(dr["Alergias"].ToString());
                        Traumaticos = Convert.ToInt32(dr["Traumaticos"].ToString());
                        Hospitalizaciones = Convert.ToInt32(dr["Hospitalizaciones_Previas"].ToString());
                        Adcciones = Convert.ToInt32(dr["Adicciones"].ToString());
                        otros2 = Convert.ToInt32(dr["Otros"].ToString());

                        Concatenar(diabetes, "Diabetes", " Por: " + dr["Desc_Diabetes"].ToString());
                        Concatenar(Hepa, "Hepatopatia", " Por: " + dr["Desc_Hepatopatia"].ToString());
                        Concatenar(Asma, "Asma", " Por: " + dr["Desc_Asma"].ToString());
                        Concatenar(Endoctrina, "Enfermedad Endoctrina", " Por: " + dr["Desc_Endoctrina"].ToString());
                        Concatenar(interrogados, "Interrogados y negados", " Por: " + dr["Desc_Interrogados"].ToString());
                        Concatenar(Hipertension, "Hipertension", " Por: " + dr["Desc_Hipertension"].ToString());
                        Concatenar(Nefropatia, "Nefropatia", " Por: " + dr["Desc_Nefropatia"].ToString());
                        Concatenar(Cancer, "Cancer", " Por: " + dr["Desc_Cancer"].ToString());
                        Concatenar(CardioPatia, "Cardiopatia", " Por: " + dr["Desc_Cardiopatia"].ToString());
                        Concatenar(Mental, "Enfermedad Mental", " Por: " + dr["Desc_Mental"].ToString());
                        Concatenar(Alergicas, "Alergicas", " Por: " + dr["Desc_Alergicas"].ToString());
                        Concatenar(otros, "Otros", " Por: " + dr["Desc_Otros"].ToString());

                        Concatenar(Actuales, "Enfermedades Actuales", ": " + dr["Desc_Actuales"].ToString());
                        Concatenar(Quirurgicas, "Quirurgicos", ": " + dr["Desc_Quirurgicas"].ToString());
                        Concatenar(Transfusionales, "Transfusionales", ": " + dr["Desc_Transfusionales"].ToString());
                        Concatenar(Alergias, "Alergias", ": " + dr["Desc_Alergias"].ToString());
                        Concatenar(Traumaticos, "Traumaticos", ": " + dr["Desc_Traumaticos"].ToString());
                        Concatenar(Hospitalizaciones, "Hospitalizaciones Previas", ": " + dr["Desc_Hospitalizaciones"].ToString());
                        Concatenar(Adcciones, "Adicciones", ": " + dr["Desc_Adicciones"].ToString());
                        Concatenar(otros2, "Otros2", ": " + dr["Desc_Otros2"].ToString());
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
            else if (txtCodigo.TextLength == 0)
            {
                DatosCargados = false;
                txtNombre.Clear();
                txtNumeroRef.Clear();
                txtEdad.Clear();
                cmbArea.Text = "Seleccione";
                txtIdentidad.Clear();
                txtAntececentes.Clear();
            }
        }

        public void Concatenar(int Enfermedad, string Nombre, string Porquien)
        {
            if (Enfermedad == 1)
            {
                txtAntececentes.Text += Nombre + Porquien + "\n";
            }
        }

        private void btnSi_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSi.Checked == true)
            {
                Incapacidad = "Si";
            }
        }

        private void btnNo_CheckedChanged(object sender, EventArgs e)
        {
            if (btnNo.Checked == true)
            {
                Incapacidad = "No";
            }
        }

        private void txtNumeroRef_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void txtIdentidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.LetrasNumeros(e, txtCodigo);
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Letras(e, txtNombre);
        }
        private void txtPA_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void txtFC_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void txtFR_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void txtT_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
        }

        private void txtSO2_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            FrmVerConsultas consultas = new FrmVerConsultas();
            consultas.Show();
            this.Hide();
        }

        private void FrmConsulta_Leave(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFecha.Value.Date;
            DateTime horaActual = DateTime.Now;
            DateTime fechaYHora = fechaSeleccionada.Date + horaActual.TimeOfDay;

            DateTime fechaActual = DateTime.Now;

            try
            {

                bd.AbrirConexion();

                Id_Identificacion = bd.ObtenerIdentificacion(txtIdentidad);
                //Hacemos la busqueda del Empleado creado mediante la identidad                

                //Creamos los Signos Vitales
                cmd = new SqlCommand("update Signos_Vitales_Consultorio set Presion_Arterial ='" + txtPA.Text + "', Temperatura ='" + txtT.Text + "', Frecuencia_Cardiaca='" + txtFC.Text + "', Frecuencia_Respiratoria='" + txtFR.Text + "', Saturacion_Oxigeno='" + txtSO2.Text + "' where Id_Signos_Vitales_Consultorio = " + Id_Signos + "", bd.sc);
                cmd.ExecuteNonQuery();

                //Al final creamos la consulta

                cmd = new SqlCommand("update Consultorio set Antecedentes_Personales ='" + txtAntececentes.Text + "', Historia_Enfermedad_Actual ='" + txtHistoria.Text + "', Examen_Fisico='" + txtExamen.Text + "', Impresion_Diagnostico='" + txtImpresion.Text + "', Tratamiento='" + txtTratamiento.Text + "', Conducta ='" + txtConducta.Text + "', Incapacidad ='" + Incapacidad + "', Fecha_Consulta='" + fechaYHora.ToString("yyyy-MM-dd HH:mm:ss") + "', Motivo_Consulta='" + txtMotivo.Text + "'where Id_Consultorio=" + Id_Consultorio + "", bd.sc);
                cmd.ExecuteNonQuery();                

                cmd = new SqlCommand("Insert into Bitacora values('" + "CONSULTA" + "', '" + Usuario + "', '" + "Actualizo la consulta de: " + txtNombre.Text + "', '" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "')", bd.sc);
                cmd.ExecuteNonQuery();


                MessageBox.Show("Se actualizo correctamente la consulta", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bd.CerrarConexion();
                LimpiarTodo();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar la consulta: " + ex.ToString(), "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bd.CerrarConexion();
            }

        }
    }
}
