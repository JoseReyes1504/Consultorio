using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CML
{
    public partial class FrmInventario : Form
    {
        //Se carga la clase de BD
        ConexionBD bd = new ConexionBD();
        clsValidaciones val = new clsValidaciones();

        //Variables        
        SqlCommand cmd;
        SqlDataReader dr;

        int Id_Producto = 0;
        bool ProductoCargado = false;

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
            FrmMenu frmMenu = new FrmMenu();
            this.Hide();
            frmMenu.Show();
        }


        public void Limpiar()
        {
            txtProducto.Clear();
            txtCantidad.Text = "0";
            txtIngreso.Text = "0";
            txtCantidad.ReadOnly = false;
            ProductoCargado = false;
        }

        public void ActualizarDgv()
        {
            bd.CualquierTabla(dgv, "Select a.Id_Inventario [Inventario], b.Nombre, b.Cantidad [Existencia Actual], a.Fecha_Ingreso, a.Fecha_Egreso, a.Fecha_Vencimiento, a.Ingreso, a.Egreso, a.Existencia from Inventario a inner join Producto b on a.Id_Producto = b.Id_Producto");
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            ActualizarDgv();
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
            int suma = Convert.ToInt32(txtCantidad.Text) + Convert.ToInt32(txtIngreso.Text);
            try
            {
                bd.AbrirConexion();
                if(ProductoCargado == false)
                {
                    cmd = new SqlCommand("insert into Producto values ('" + txtProducto.Text + "', '" + Convert.ToDouble(txtIngreso.Text) + "')", bd.sc);
                    cmd.ExecuteNonQuery();
                }
                
                Id_Producto = bd.ObtenerId("Producto", "Id_Producto");

                cmd = new SqlCommand("insert into Inventario values ('" + Id_Producto + "', " + 1 + ", '" + dtpFechaIngreso.Value.ToString("yyyy/MM/dd") + "', '" + null + "', '" + dtpFechaVencimiento.Value.ToString("yyyy/MM/dd") + "', '" + Convert.ToDouble(txtIngreso.Text) + "', " + 0 + ", " + suma + ")", bd.sc);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update Producto set Cantidad = " + suma + " where Id_producto = " + Id_Producto + "", bd.sc);
                cmd.ExecuteNonQuery();

                bd.CerrarConexion();
                ActualizarDgv();
                Limpiar();

                      
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se han podido agregar los datos del producto" + ex);
                bd.CerrarConexion();
            }
            
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
            //ID = dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString();
           // MessageBox.Show(ID);
        }

        private void dtpFechaVencimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtProducto_TextChanged(object sender, EventArgs e)
        {
            bd.AbrirConexion();
            try
            {                
                if (txtProducto.Text == "")
                {
                    lbxBusqueda.Items.Clear();
                }
                else
                {
                    lbxBusqueda.Items.Clear();
                    bd.BusquedaLbx(txtProducto, lbxBusqueda, "Nombre");                    
                }
                bd.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha Producido un error " + ex.ToString());
                bd.CerrarConexion();
            }
            
        }

        private void lbxBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if (lbxBusqueda.Text != "")
            {                
                try
                {
                    bd.AbrirConexion();
                    cmd = new SqlCommand("Select a.Id_Inventario [Inventario], b.Id_Producto, b.Nombre, b.Cantidad [Existencia], a.Fecha_Ingreso, a.Fecha_Vencimiento from Inventario a inner join Producto b on a.Id_Producto = b.Id_Producto where Nombre  = '" + lbxBusqueda.SelectedItem.ToString() + "'", bd.sc);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {                        
                        txtCantidad.Text = dr["Existencia"].ToString();
                        dtpFechaIngreso.Value = DateTime.Parse(dr["Fecha_Ingreso"].ToString());
                        dtpFechaVencimiento.Value = DateTime.Parse(dr["Fecha_Vencimiento"].ToString());
                        Id_Producto = Convert.ToInt32(dr["Id_Producto"].ToString());                        
                        txtCantidad.ReadOnly = true;
                        ProductoCargado = true;
                    }
                    else
                    {
                        MessageBox.Show("No existe ningun Registo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }                    
                    dr.Close();
                    bd.CerrarConexion();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo llenar los campos" + ex.ToString());
                    bd.CerrarConexion();
                }                               
            }
            else
            {
                lbxBusqueda.Items.Clear();
                ProductoCargado = false;
            }
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
