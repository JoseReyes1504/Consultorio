using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CML
{
    public partial class FrmUsuarios : Form
    {
        ConexionBD bd = new ConexionBD();
        string ID = "0";
        string Usuario = "";
        string UsuarioAnt = "";

        DateTime fechaActual = DateTime.Now;

        clsValidaciones val = new clsValidaciones();
                               

        public FrmUsuarios()
        {
            InitializeComponent();
        }

        public FrmUsuarios(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;
        }

        public void Limpiar()
        {
            txtUsuario.Clear();
            ID = "0";
            txtContrasena.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

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

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            bd.CualquierTabla(dgv, "select Id_Usuario[ID], Usuario, Contrasena[Contraseña] from Usuario order by Id_Usuario DESC");            
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "" || txtContrasena.Text == "")
            {
                MessageBox.Show("Datos Vacios", "Data vacia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bd.AbrirConexion();
                SqlCommand cmd = new SqlCommand("insert into Usuario values('" + txtUsuario.Text + "', '" +  val.encriptar(txtContrasena.Text) + "')", bd.sc);
                cmd.ExecuteNonQuery();
                bd.CualquierTabla(dgv, "select Id_Usuario[ID], Usuario, Contrasena[Contraseña] from Usuario");
                Limpiar();
                bd.CerrarConexion();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {            
            if (txtUsuario.Text == "" || txtContrasena.Text == "")
            {
                MessageBox.Show("Datos Vacios", "Data vacia", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                bd.AbrirConexion();
                
                SqlCommand cmd = new SqlCommand("update Usuario set Usuario = '" + txtUsuario.Text + "', Contrasena = '" + val.encriptar(txtContrasena.Text) + "' where Id_Usuario =  " + ID + "", bd.sc);
                cmd.ExecuteNonQuery();
                
                bd.CualquierTabla(dgv, "select Id_Usuario[ID], Usuario, Contrasena[Contraseña] from Usuario");
                
                cmd = new SqlCommand("Insert into Bitacora values('" + "USUARIOS" + "', '" + Usuario + "', '" + "Actualizo la información de: " + UsuarioAnt + "', '" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "')", bd.sc);
                cmd.ExecuteNonQuery();

                Limpiar();
                btnAgregar.Enabled = true;
                bd.CerrarConexion();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            UsuarioAnt = dgv.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
            txtUsuario.Text = dgv.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();            
            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {            

            bd.AbrirConexion();
            SqlCommand cmd = new SqlCommand("Delete from Usuario where Id_Usuario = " + Convert.ToInt32(ID) + "", bd.sc);
            cmd.ExecuteNonQuery();
            bd.CualquierTabla(dgv, "select Id_Usuario[ID], Usuario, Contrasena[Contraseña] from Usuario");

            cmd = new SqlCommand("Insert into Bitacora values('" + "USUARIOS" + "', '" + Usuario + "', '" + "Elimino la información de: " + txtUsuario.Text + "', '" + fechaActual + "')", bd.sc);
            cmd.ExecuteNonQuery();


            Limpiar();
            btnAgregar.Enabled = true;
            bd.CerrarConexion();
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {
            if(txtContrasena.Text == "")
            {
                btnAgregar.Enabled = false;
            }
            else
            {
                btnAgregar.Enabled = true;
            }
        }
    }
}
