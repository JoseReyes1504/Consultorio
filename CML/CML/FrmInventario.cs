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
        DateTime fechaActual = DateTime.Now;
        string NombreP = "";
        int ID = 0;
        int Id_Producto = 0;
        bool ProductoCargado = false;
        int ExistenciaAnterior = 0;
        string Usuario = "";

        public FrmInventario()
        {
            InitializeComponent();
        }

        public FrmInventario(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;
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
            btnAgregar.Enabled = true;
            btnActualizar.Enabled = false;
            btnEliminar.Enabled = false;
            ID = 0;
            Id_Producto = 0;
            NombreP = "";
        }

        void ActulizarGraficosYDatos()
        {
            bd.CualquierTabla(dgv, "Select a.Id_Inventario [Inventario], b.Nombre, b.Cantidad [Existencia Actual], a.Fecha_Ingreso, a.Fecha_Egreso, a.Fecha_Vencimiento, a.Ingreso, a.Egreso, a.Existencia from Inventario a inner join Producto b on a.Id_Producto = b.Id_Producto order by a.Id_Inventario DESC");
            bd.GraficoInventario(cpAgotado, "Select Distinct b.Nombre, b.Cantidad from Inventario a inner join Producto b on a.Id_Producto = b.Id_Producto where b.Cantidad <= 10");
        }

        private void FrmInventario_Load(object sender, EventArgs e)
        {
            ActulizarGraficosYDatos();
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
                if (ProductoCargado == false)
                {
                    if (txtProducto.Text != "" && txtIngreso.Text != "")
                    {
                        cmd = new SqlCommand("insert into Producto values ('" + txtProducto.Text + "', '" + Convert.ToDouble(txtIngreso.Text) + "')", bd.sc);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        MessageBox.Show("Datos vacios", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

                Id_Producto = bd.ObtenerIdPorNombre(NombreP);

                cmd = new SqlCommand("insert into Inventario values ('" + Id_Producto + "', " + 1 + ", '" + dtpFechaIngreso.Value.ToString("yyyy/MM/dd") + "', '" + "--/--/--" + "', '" + dtpFechaVencimiento.Value.ToString("yyyy/MM/dd") + "', '" + Convert.ToDouble(txtIngreso.Text) + "', " + 0 + ", " + suma + ")", bd.sc);
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("Insert into Bitacora values('" + "INVENTARIO" + "', '" + Usuario + "', '" + "Registro el producto de: " + txtProducto.Text + " con el ingreso de `" + txtIngreso.Text + "` ', '" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "')", bd.sc);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update Producto set Cantidad = " + suma + " where Id_producto = " + Id_Producto + "", bd.sc);
                cmd.ExecuteNonQuery();

                bd.CerrarConexion();
                ActulizarGraficosYDatos();
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
            int suma = Convert.ToInt32(txtCantidad.Text) - Convert.ToInt32(txtIngreso.Text);

            if (ID == 0)
            {
                MessageBox.Show("No a seleccionado ningun ID del inventario", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                try
                {
                    bd.AbrirConexion();

                    cmd = new SqlCommand("Delete from Inventario where Id_Inventario= " + ID + "", bd.sc);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("update Producto set Cantidad = " + suma + " where Id_producto = " + Id_Producto + "", bd.sc);
                    cmd.ExecuteNonQuery();

                    cmd = new SqlCommand("Insert into Bitacora values('" + "INVENTARIO" + "', '" + Usuario + "', '" + "Elimino el producto de: " + NombreP + " que contenia `" + txtCantidad.Text + "` en inventario en ese momento', '" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "')", bd.sc);
                    cmd.ExecuteNonQuery();

                    bd.CerrarConexion();
                    ActulizarGraficosYDatos();
                    Limpiar();
                    btnAgregar.Enabled = true;
                    btnEliminar.Enabled = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error: " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bd.CerrarConexion();
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Inventario"].Value.ToString());
            txtProducto.Text = dgv.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            NombreP = dgv.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();

            ExistenciaAnterior = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Ingreso"].Value.ToString());

            txtCantidad.Text = dgv.Rows[e.RowIndex].Cells["Existencia Actual"].Value.ToString();
            txtIngreso.Text = dgv.Rows[e.RowIndex].Cells["Ingreso"].Value.ToString();

            if (dgv.Rows[e.RowIndex].Cells["Fecha_Ingreso"].Value.ToString() != "--/--/--")
            {
                dtpFechaIngreso.Value = DateTime.Parse(dgv.Rows[e.RowIndex].Cells["Fecha_Ingreso"].Value.ToString());
                dtpFechaVencimiento.Value = DateTime.Parse(dgv.Rows[e.RowIndex].Cells["Fecha_Vencimiento"].Value.ToString());
            }

            btnAgregar.Enabled = false;
            btnActualizar.Enabled = true;
            btnEliminar.Enabled = true;
            bd.AbrirConexion();
            Id_Producto = bd.ObtenerIdPorNombre(NombreP);
            bd.CerrarConexion();
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
                    cmd = new SqlCommand("select * from Producto where Nombre  = '" + lbxBusqueda.SelectedItem.ToString() + "'", bd.sc);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        txtCantidad.Text = dr["Cantidad"].ToString();
                        NombreP = dr["Nombre"].ToString();
                        txtCantidad.ReadOnly = true;
                        ProductoCargado = true;
                        btnAgregar.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("No existe ningun Registo", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    dr.Close();
                    Id_Producto = bd.ObtenerIdPorNombre(lbxBusqueda.SelectedItem.ToString());
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

        private void txtIngreso_KeyPress(object sender, KeyPressEventArgs e)
        {
            val.Numeros(e);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (ID == 0)
            {
                MessageBox.Show("No a seleccionado ningun ID del inventario", "Producto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                int suma = ExistenciaAnterior + Convert.ToInt32(txtIngreso.Text);
                try
                {
                    bd.AbrirConexion();
                    Id_Producto = bd.ObtenerIdPorNombre(NombreP);

                    if (ProductoCargado == false)
                    {
                        if (txtProducto.Text != "" && txtIngreso.Text != "")
                        {
                            cmd = new SqlCommand("update Producto set Nombre='" + txtProducto.Text + "', Cantidad ='" + Convert.ToDouble(txtIngreso.Text) + "'where Id_Producto = " + Id_Producto + "", bd.sc);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Datos vacios", "Información", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    cmd = new SqlCommand("update Inventario set Id_Producto ='" + Id_Producto + "', Fecha_Ingreso= '" + dtpFechaIngreso.Value.ToString("yyyy/MM/dd") + "', Fecha_Vencimiento='" + dtpFechaVencimiento.Value.ToString("yyyy/MM/dd") + "', Ingreso='" + Convert.ToDouble(txtIngreso.Text) + "', Existencia=" + suma + "where Id_Inventario=" + ID + "", bd.sc);
                    cmd.ExecuteNonQuery();


                    cmd = new SqlCommand("Insert into Bitacora values('" + "INVENTARIO" + "', '" + Usuario + "', '" + "Actualizo el producto de: " + txtProducto.Text + " con el ingreso de `" + txtIngreso.Text + "` ', '" + fechaActual.ToString("yyyy-MM-dd HH:mm:ss") + "')", bd.sc);
                    cmd.ExecuteNonQuery();

                    bd.CerrarConexion();
                    ActulizarGraficosYDatos();
                    Limpiar();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo actualizar: " + ex.ToString());
                    bd.CerrarConexion();
                }
            }
        }
    }
}
