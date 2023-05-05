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

            cmd = new SqlCommand("select Id_Identificacion from Identificacion where No_Identidad = '" + txtIdentidad.Text + "' ", bd.sc);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id_Identificacion = Convert.ToInt32(dr["Id_Identificacion"].ToString());
            }
            dr.Close();

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
                    cmd = new SqlCommand("select Id_Empleado from Empleado where Id_Identificacion = '" + Id_Identificacion + "' ", bd.sc);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Id_Empleado = Convert.ToInt32(dr["Id_Empleado"].ToString());
                    }
                    dr.Close();

                    //Creamos los Signos Vitales
                    cmd = new SqlCommand("insert into Signos_Vitales_Consultorio values ('" + txtPA.Text + "','" + txtT.Text + "','" + txtFC.Text + "','" + txtFR.Text + "','" + txtSO2.Text + "')", bd.sc);
                    cmd.ExecuteNonQuery();

                    //Obtenemos el ID del ultimo signo vital creado
                    Id_Signos = bd.ObtenerId("Signos_Vitales_Consultorio", "Id_Signos_Vitales_Consultorio");

                    //Al final creamos la consulta
                    cmd = new SqlCommand("insert into Consultorio values('" + Id_Empleado + "','" + txtAntececentes.Text + "','" + Id_Signos + "','" + txtHistoria.Text + "','" + txtExamen.Text + "','" + txtImpresion.Text + "','" + txtTratamiento.Text + "','" + txtConducta.Text + "','" + Incapacidad + "', '" + dtpFecha.Value.ToString("yyyy/MM/dd") + "')", bd.sc);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Se Creo la consulta");
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
            /*if (txtIdentidad.TextLength == 13)
            {
                try
                {
                    bd.AbrirConexion();
                    cmd = new SqlCommand("select* from Identificacion where No_Identidad = '" + txtIdentidad.Text + "'", bd.sc);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtNombre.Text = dr["Nombre_Completo"].ToString();                        
                        txtNumeroRef.Text = dr["Telefono"].ToString();
                        txtEdad.Text = dr["Edad"].ToString();
                        cmbArea.SelectedIndex = Convert.ToInt32(dr["Id_Puesto"].ToString());
                        txtCodigo.Text = dr["Codigo_Empleado"].ToString();
                        DatosCargados = true;
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
                DatosCargados = false;
            }*/
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
                DatosCargados = false;
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
