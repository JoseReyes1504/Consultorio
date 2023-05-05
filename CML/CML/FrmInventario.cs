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
    public partial class FrmInventario : Form
    {
        //Se carga la clase de BD
        ConexionBD bd = new ConexionBD();
        clsValidaciones val = new clsValidaciones();

        //Variables
        string ID;
        SqlCommand cmd;
        SqlDataReader dr;

        public FrmInventario()
        {
            InitializeComponent();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            FrmMenu frmMenu= new FrmMenu();
            this.Hide();
            frmMenu.Show();
        }


        public void Limpiar()
        {
            txtProducto.Clear();
            txtCantidad.Clear();
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            bd.CualquierTabla(dgv, "Select * from Producto");
        }

        private void txtProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.LetrasNumeros(e, txtProducto);
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                bd.AbrirConexion();
                cmd = new SqlCommand("insert into Producto values ('" +txtProducto.Text + "', '" +Convert.ToDouble(txtCantidad.Text)+"')", bd.sc);
                cmd.ExecuteNonQuery();
                bd.CualquierTabla(dgv, "Select Id_Producto as ID, Nombre, Cantidad from Producto");
                Limpiar();
            }
            catch(Exception ex)
            {
                MessageBox.Show("No se han podido agregar los datos del producto" + ex);
                bd.CerrarConexion();
            }
            bd.CerrarConexion();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString();
            MessageBox.Show(ID);
        }
    }
}
