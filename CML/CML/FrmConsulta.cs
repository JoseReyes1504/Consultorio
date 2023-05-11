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
        int Incapacidad = 0;
        bool DatosCargados = false;        

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
            Incapacidad = 0;
            btnNo.Checked = true;
        }

        public FrmConsulta()
        {
            InitializeComponent();
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
            MessageBox.Show("Se creo un nuevo expediente de " + txtNombre.Text, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //Primero Se Agragan los datos a la tabla identificación
            cmd = new SqlCommand("insert into Identificacion (Codigo_Empleado, Nombre_Completo, No_Identidad, Telefono, Id_Puesto, Edad)  values ('" + txtCodigo.Text + "', '" + txtNombre.Text + "', '" + txtIdentidad.Text + "', '" + txtNumeroRef.Text + "', '" + AreaTrabajo + "', '" + txtEdad.Text + "')", bd.sc);
            cmd.ExecuteNonQuery();            

            Id_Identificacion = bd.ObtenerIdentificacion(txtIdentidad);

            //Despues a la tabla empleados ya que esta es dependiente de una llave foranea
            cmd = new SqlCommand("insert into Empleado values ('" + hoy.ToString("yyyy/MM/dd") + "', '" + Id_Identificacion + "', '" + 0 + "')", bd.sc);
            cmd.ExecuteNonQuery();
            DatosCargados = true;
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
                bd.CerrarConexion();

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
                //Si existe el Numero de identidad no se creara una nueva identificacion aqui valido esta parte
                if (DatosCargados == false)
                {
                    CrearIdentidad();
                }
                else
                {
                    Id_Identificacion = bd.ObtenerIdentificacion(txtIdentidad);

                    //Hacemos la busqueda del Empleado creado mediante la identidad

                    Id_Empleado = bd.ObtenerId("Empleado","Id_Empleado");                    

                    //Creamos los Signos Vitales
                    cmd = new SqlCommand("insert into Signos_Vitales_Consultorio values ('" + txtPA.Text + "','" + txtT.Text + "','" + txtFC.Text + "','" + txtFR.Text + "','" + txtSO2.Text + "')", bd.sc);
                    cmd.ExecuteNonQuery();

                    //Obtenemos el ID del ultimo signo vital creado
                    Id_Signos = bd.ObtenerId("Signos_Vitales_Consultorio", "Id_Signos_Vitales_Consultorio");

                    //Al final creamos la consulta
                    cmd = new SqlCommand("insert into Consultorio values('" + Id_Empleado + "','" + txtAntececentes.Text + "','" + Id_Signos + "','" + txtHistoria.Text + "','" + txtExamen.Text + "','" + txtImpresion.Text + "','" + txtTratamiento.Text + "','" + txtConducta.Text + "','" + Incapacidad + "', '" + dtpFecha.Value.ToString("yyyy/MM/dd") + "', '" + txtMotivo.Text + "')", bd.sc);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se Creo la consulta", "Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            cmbArea.SelectedIndex = 0;
            bd.cbAreaTrabajo(cmbArea);
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaTrabajo = (cmbArea.SelectedIndex + 1);
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
                        cmbArea.SelectedIndex = codigo - 1;
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

                        Concatenar(diabetes, "Diabetes", dr["Desc_Diabetes"].ToString());
                        Concatenar(Hepa, "Hepatopatia", dr["Desc_Hepatopatia"].ToString());
                        Concatenar(Asma, "Asma", dr["Desc_Asma"].ToString());
                        Concatenar(Endoctrina, "Enfermedad Endoctrina", dr["Desc_Endoctrina"].ToString());
                        Concatenar(interrogados, "Interrogados y negados", dr["Desc_Interrogados"].ToString());
                        Concatenar(Hipertension, "Hipertension", dr["Desc_Hipertension"].ToString());
                        Concatenar(Nefropatia, "Nefropatia", dr["Desc_Nefropatia"].ToString());
                        Concatenar(Cancer, "Cancer", dr["Desc_Cancer"].ToString());
                        Concatenar(CardioPatia, "Cardiopatia", dr["Desc_Cardiopatia"].ToString());
                        Concatenar(Mental, "Enfermedad Mental", dr["Desc_Mental"].ToString());
                        Concatenar(Alergicas, "Alergicas", dr["Desc_Alergicas"].ToString());
                        Concatenar(otros, "Otros", dr["Desc_Otros"].ToString());

                        Concatenar(Actuales, "Enfermedades Actuales", dr["Desc_Otros"].ToString());
                        Concatenar(Quirurgicas, "Quirurgicos", dr["Desc_Quirurgicas"].ToString());
                        Concatenar(Transfusionales, "Transfusionales", dr["Desc_Transfusionales"].ToString());
                        Concatenar(Alergias, "Alergias", dr["Desc_Alergias"].ToString());
                        Concatenar(Traumaticos, "Traumaticos", dr["Desc_Traumaticos"].ToString());
                        Concatenar(Hospitalizaciones, "Hospitalizaciones Previas", dr["Desc_Hospitalizaciones"].ToString());
                        Concatenar(Adcciones, "Adicciones", dr["Desc_Adicciones"].ToString());
                        Concatenar(otros2, "Otros", dr["Desc_Otros2"].ToString());
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
            else
            {
                DatosCargados = false;
            }
        }

        public void Concatenar(int Enfermedad, string Nombre, string Porquien)
        {            
            if(Enfermedad == 1)
            {
                txtAntececentes.Text += Nombre + " Por: " + Porquien + "\n";
            }
        }

        private void btnSi_CheckedChanged(object sender, EventArgs e)
        {
            if (btnSi.Checked == true)
            {
                Incapacidad = 1;
            }
        }

        private void btnNo_CheckedChanged(object sender, EventArgs e)
        {
            if (btnNo.Checked == true)
            {
                Incapacidad = 0;
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
    }
}
