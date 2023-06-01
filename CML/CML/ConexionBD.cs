using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;
using System.Collections;

namespace CML
{
    public class ConexionBD
    {

        public SqlConnection sc = new SqlConnection();

        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;

        protected string sql;
        protected SqlCommand cmd;
        
        //--------------------sql-----------------------------------
        //Conexion con la base de datos ; en el dato sorce se pone un ."punto" para que funcione en cualquier computadora la conexion
        string conexion = "Data Source = localhost; Initial Catalog = CML; Integrated Security = True";

        //--------------------sql-----------------------------------
        //funcion para poder abrir la conexion con la base datos con el string de CONEXION
        public ConexionBD()
        {
            sc.ConnectionString = conexion;
        }

        //--------------------sql-----------------------------------
        // funcion que se usara en cada parte del codigo para abrir una conexion con la Base de datos
        public void AbrirConexion()
        {
            try
            {
                sc.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR en la conexion" + ex, "Error de Conexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        //--------------------sql-----------------------------------
        // funcion que se usara en cada parte del codigo para cerrar una conexion con la Base de datos
        public void CerrarConexion()
        {
            sc.Close();
        }

        //funcion para cargar al datagridview del parametro para cualquier tabla de la base de datos 
        public void CualquierTabla(DataGridView dgv, string Query)
        {
            try
            {
                da = new SqlDataAdapter(Query, sc);
                dt = new DataTable();
                da.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no ha sido posible establecer conexion" + ex.ToString()); ;
            }
        }


        public void cbAreaTrabajo(ComboBox cb)
        {
            cb.Items.Clear();                          
            try
            {
                //en este combobox solo se van a agregar las areas de trabajo
                AbrirConexion();
                cmd = new SqlCommand("Select Area_Trabajo from Puesto", sc);
                dr = cmd.ExecuteReader();

                cb.Items.Add("Seleccione");
                while (dr.Read())
                {
                    cb.Items.Add(dr["Area_Trabajo"].ToString());
                }
                dr.Close();
                CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error no se puede llenar el combo box" + ex.ToString());
            }
        }


        public int ObtenerId(string tabla, string Id)
        {
            int ID_Dato = 0;
            //Obtenemos el ID del ultimo dato creado
            cmd = new SqlCommand("select TOP 1 * from  " + tabla + " order by " + Id+ " DESC", sc);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                 ID_Dato = Convert.ToInt32(dr[Id].ToString());
            }
            dr.Close();

            return ID_Dato;
        }

        public int ObtenerIdPorNombre(string txt)
        {
            int ID_Dato = 0;
            //Obtenemos el ID del ultimo dato creado
            cmd = new SqlCommand("select * from Producto where Nombre like '%" + txt + "%'", sc);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                ID_Dato = Convert.ToInt32(dr["Id_Producto"].ToString());
            }
            dr.Close();

            return ID_Dato;
        }


        public int ObtenerEnfermedades(TextBox txt)
        {
            int Id = 0;
            cmd = new SqlCommand("select a.Id_Antecedentes from Empleado a inner join Identificacion b on a.Id_Identificacion = b.Id_Identificacion where b.No_Identidad = '" + txt.Text+ "'", sc);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = Convert.ToInt32(dr["Id_Antecedentes"].ToString());
            }
            dr.Close();

            return Id;
        }

        public int ObtenerIdentificacion(TextBox txt)
        {
            int Id = 0;
            cmd = new SqlCommand("select Id_Identificacion from Identificacion where No_Identidad = '" + txt.Text + "' ", sc);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Id = Convert.ToInt32(dr["Id_Identificacion"].ToString());
            }
            dr.Close();

            return Id;
        }

        public void BusquedaLbx(TextBox txt, ListBox lbBusqueda, string Operacion)
        {
            try
            {                
                cmd = new SqlCommand("Select Distinct Nombre from Producto where " + Operacion + " like '%" + txt.Text + "%'", sc);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    lbBusqueda.Items.Add(dr["Nombre"]);
                }
                dr.Close();                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se ha Producido un error " + ex.ToString());
                CerrarConexion();
            }
        }

        public void GraficoInventario(Chart Char, string Query)
        {
            ArrayList Descripcion = new ArrayList();
            ArrayList Cant = new ArrayList();

            Descripcion.Clear();
            Cant.Clear();
            try
            {
                AbrirConexion();
                cmd = new SqlCommand(Query, sc);
                cmd.ExecuteNonQuery();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    Descripcion.Add(dr.GetString(0));
                    Cant.Add(dr.GetInt32(1));
                }
                Char.Series[0].Points.DataBindXY(Descripcion, Cant);
                dr.Close();
                CerrarConexion();
            }
            catch (Exception ex)
            {
                dr.Close();
                MessageBox.Show("Se ha producido un error" + ex.ToString());
            }
        }
    }
}
