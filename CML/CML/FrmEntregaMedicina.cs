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
    public partial class FrmEntregaMedicina : Form
    {

        //Se carga la clase de BD
        ConexionBD bd = new ConexionBD();
        clsValidaciones val = new clsValidaciones();

        SqlCommand cmd;
        SqlDataReader dr;

        //Variables                       
        int Id_Producto = 0;
        int AreaTrabajo = 0;
        int Id_Identificacion = 0;

        public FrmEntregaMedicina()
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
            this.WindowState= FormWindowState.Minimized;
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
                        
                        cmbArea.SelectedIndex = AreaTrabajo - 1;

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
            bd.CualquierTabla(dgv, "select b.Nombre_Completo [Empleado], d.Area_Trabajo [Area De Trabajo], a.Cantidad, a.Fecha_Entrega [Fecha Entrega], c.Nombre [Producto] from Entrega_Medicinas a inner join Identificacion b On a.Id_Identificacion = b.Id_Identificacion inner join Producto c on a.Id_Producto = c.Id_Producto inner join Puesto d on b.Id_Puesto = d.Id_Puesto");
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
            try
            {
                bd.AbrirConexion();
                
                cmd = new SqlCommand("Insert into Entrega_Medicinas values (" + Id_Producto + ", " + Id_Identificacion + ", " + Convert.ToInt32(txtEgreso.Text) + ", '" + dtpFecha.Value.ToString("yyyy/MM/dd") + "', " + AreaTrabajo + ")", bd.sc);
                cmd.ExecuteNonQuery();


                cmd = new SqlCommand("insert into Inventario values ('" + Id_Producto + "', " + 1 + ", '" + null + "', '" + dtpFecha.Value.ToString("yyyy/MM/dd") + "', '" + null + "', '" + 0 + "', " + Convert.ToDouble(txtEgreso.Text) + ", " + Convert.ToInt32(txtCantidad.Text)+ ")", bd.sc);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("update Producto set Cantidad = " + Resta + " where Id_producto = " + Id_Producto + "", bd.sc);
                cmd.ExecuteNonQuery();


                bd.CualquierTabla(dgv, "select b.Nombre_Completo [Empleado], d.Area_Trabajo [Area De Trabajo], a.Cantidad, a.Fecha_Entrega [Fecha Entrega], c.Nombre [Producto] from Entrega_Medicinas a inner join Identificacion b On a.Id_Identificacion = b.Id_Identificacion inner join Producto c on a.Id_Producto = c.Id_Producto inner join Puesto d on b.Id_Puesto = d.Id_Puesto");

                bd.CerrarConexion();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ërror al agregar los productos de entrega: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            FrmInventario inv = new FrmInventario();
            inv.Show();
        }
    }
}
