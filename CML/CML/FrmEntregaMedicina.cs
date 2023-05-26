using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CML
{
    public partial class FrmEntregaMedicina : Form
    {

        //Se carga la clase de BD
        ConexionBD bd = new ConexionBD();
        clsValidaciones val = new clsValidaciones();

        SqlCommand cmd;
        SqlDataReader dr;


        DateTime fechaActual = DateTime.Now;

        //Variables                       
        int Id_Producto = 0;
        int AreaTrabajo = 0;
        int Id_Identificacion = 0;
        int ID = 0;

        string Usuario= "";

        public FrmEntregaMedicina()
        {
            InitializeComponent();
        }

        public FrmEntregaMedicina(string usuario)
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

        void ActualizarDGV()
        {
            bd.CualquierTabla(dgv, " select a.Id_Entrega[ID], b.Nombre_Completo [Empleado], d.Area_Trabajo [Area De Trabajo], c.Cantidad[Existencia], a.Cantidad, c.Nombre [Medicamento], a.Fecha_Entrega [Fecha Entrega] from Entrega_Medicinas a inner join Identificacion b On a.Id_Identificacion = b.Id_Identificacion inner join Producto c on a.Id_Producto = c.Id_Producto inner join Puesto d on b.Id_Puesto = d.Id_Puesto order by a.Id_Entrega DESC");
        }

        void Limpiar()
        {
            Id_Producto = 0;
            AreaTrabajo = 0;
            Id_Identificacion = 0;
            txtCantidad.Text = "0";
            txtEgreso.Text = "0";
            txtCodigo.Clear();
            txtEmpleado.Clear();
            txtProducto.Clear();
            cmbArea.SelectedIndex = 0;            
            btnEliminar.Enabled = false;
            btnAgregar.Enabled = true;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            if (txtCodigo.TextLength >= 4)
            {
                try
                {
                    bd.AbrirConexion();
                    cmd = new SqlCommand("select* from Identificacion where Codigo_Empleado = '" + txtCodigo.Text + "'", bd.sc);
                    dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        txtEmpleado.Text = dr["Nombre_Completo"].ToString();
                        Id_Identificacion = Convert.ToInt32(dr["Id_Identificacion"].ToString());
                        AreaTrabajo = Convert.ToInt32(dr["Id_Puesto"].ToString());

                        cmbArea.SelectedIndex = AreaTrabajo;

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

        private void FrmEntregaMedicina_Load(object sender, EventArgs e)
        {
            cmbArea.SelectedIndex = 0;
            bd.cbAreaTrabajo(cmbArea);
            ActualizarDGV();
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
                        Id_Producto = Convert.ToInt32(dr["Id_Producto"].ToString());
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
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int Resta = Convert.ToInt32(txtCantidad.Text) - Convert.ToInt32(txtEgreso.Text);            


            if (txtCodigo.Text != "" || txtCantidad.Text == "" || txtEgreso.Text == "")
            {
                try
                {                   
                    if (Convert.ToInt32(txtEgreso.Text) > Convert.ToInt32(txtCantidad.Text))
                    {
                        MessageBox.Show("No hay esa cantidad de producto en el inventario ", "Inventario", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        bd.AbrirConexion();

                        cmd = new SqlCommand("Insert into Entrega_Medicinas values (" + Id_Producto + ", " + Id_Identificacion + ", " + Convert.ToInt32(txtEgreso.Text) + ", CONVERT(DATE,'" + dtpFecha.Value.ToString("yyyy/MM/dd") + "'), " + AreaTrabajo + ")", bd.sc);
                        cmd.ExecuteNonQuery();
                        
                        cmd = new SqlCommand("insert into Inventario values ('" + Id_Producto + "', " + 1 + ", '" + "--/--/--" + "', '" + dtpFecha.Value.ToString("yyyy/MM/dd") + "', '" + "--/--/--" + "', '" + 0 + "', " + Convert.ToDouble(txtEgreso.Text) + ", " + Convert.ToInt32(txtCantidad.Text) + ")", bd.sc);
                        cmd.ExecuteNonQuery();

                        cmd = new SqlCommand("update Producto set Cantidad = " + Resta + " where Id_producto = " + Id_Producto + "", bd.sc);
                        cmd.ExecuteNonQuery();

                        txtCantidad.Text = (Convert.ToInt32(txtCantidad.Text) - Convert.ToInt32(txtEgreso.Text)).ToString();
                        ActualizarDGV();
                        bd.CerrarConexion();
                        Limpiar();
                    }                                                         
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ërror al agregar los productos de entrega: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    bd.CerrarConexion();
                }
            }
            else
            {
                MessageBox.Show("Campos vacios, revise las cajas de texto", "Valores", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int Suma = Convert.ToInt32(txtCantidad.Text) + Convert.ToInt32(txtEgreso.Text);
            //int UlitmoID = 0;
            try
            {
                bd.AbrirConexion();

                cmd = new SqlCommand("delete from Entrega_Medicinas where Id_Entrega = " + ID + "", bd.sc);
                cmd.ExecuteNonQuery();

                /*
                UlitmoID = bd.ObtenerId("Inventario", "Id_Inventario");

                cmd = new SqlCommand("delete from Inventario where Id_Inventario = " + UlitmoID +  "",  bd.sc);
                cmd.ExecuteNonQuery();
                */

                cmd = new SqlCommand("update Producto set Cantidad = " + Suma + " where Id_producto = " + Id_Producto + "", bd.sc);
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("Insert into Bitacora values('" + "ENTREGA MEDICINAS" + "', '" + Usuario + "', '" + "Elimino la entrega de: " + txtEmpleado.Text + " del medicamento: " + txtProducto.Text + " con la cantidad de: " + txtEgreso.Text + "', GETDATE())", bd.sc);
                cmd.ExecuteNonQuery();


                ActualizarDGV();                
                bd.CerrarConexion();
                Limpiar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ërror al Eliminar los productos de entrega: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                bd.CerrarConexion();
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ID = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["ID"].Value.ToString());
            txtProducto.Text = dgv.Rows[e.RowIndex].Cells["Medicamento"].Value.ToString();
            txtEgreso.Text = dgv.Rows[e.RowIndex].Cells["Cantidad"].Value.ToString();
            txtEmpleado.Text = dgv.Rows[e.RowIndex].Cells["Empleado"].Value.ToString();
            txtCantidad.Text = dgv.Rows[e.RowIndex].Cells["Existencia"].Value.ToString();            
            btnEliminar.Enabled = true;
            btnAgregar.Enabled = false;
            bd.AbrirConexion();
            Id_Producto = bd.ObtenerIdPorNombre(dgv.Rows[e.RowIndex].Cells["Medicamento"].Value.ToString());
            bd.CerrarConexion();
        }

        private void txtNombreFiltro_TextChanged(object sender, EventArgs e)
        {
            if(txtNombreFiltro.Text != "")
            {
                bd.CualquierTabla(dgv, " select a.Id_Entrega[ID], b.Nombre_Completo [Empleado], d.Area_Trabajo [Area De Trabajo], c.Cantidad[Existencia], a.Cantidad, c.Nombre [Medicamento], a.Fecha_Entrega [Fecha Entrega] from Entrega_Medicinas a inner join Identificacion b On a.Id_Identificacion = b.Id_Identificacion inner join Producto c on a.Id_Producto = c.Id_Producto inner join Puesto d on b.Id_Puesto = d.Id_Puesto where b.Nombre_Completo like '%" + txtNombreFiltro.Text+"%'");
            }
            else
            {
                ActualizarDGV();
            }
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            FrmInventario Inv = new FrmInventario(Usuario);
            Inv.Show();
        }
    }
}
