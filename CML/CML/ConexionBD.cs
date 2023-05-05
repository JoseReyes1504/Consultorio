using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CML
{
    internal class ConexionBD
    {

        public SqlConnection sc = new SqlConnection();

        SqlDataAdapter da;
        DataTable dt;
        SqlDataReader dr;

        protected string sql;
        protected SqlCommand cmd;
        
        //--------------------sql-----------------------------------
        //Conexion con la base de datos ; en el dato sorce se pone un ."punto" para que funcione en cualquier computadora la conexion
        string conexion = "Data Source = .; Initial Catalog = CML; Integrated Security = True";

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
    }
}
