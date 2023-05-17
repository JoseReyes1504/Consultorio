using System.Data.SqlClient;
using System.Windows.Forms;

namespace CML
{
    public class ClsEmpleado : ConexionBD
    {
        private static int id_Usuario;
        private static int id_Ingreso;
        private static string nombre_Usuario;
        private static string apellido_Usuario;
        private static string codigo_Usuario;
        private static string id_TipoUsuario;
        private bool Empleado;
        private string PantallaLabel;



        public int Id_Usuario { get => id_Usuario; set => id_Usuario = value; }
        public int Id_Ingreso { get => id_Ingreso; set => id_Ingreso = value; }
        public string Nombre_Usuario { get => nombre_Usuario; set => nombre_Usuario = value; }
        public string Apellido_Usuario { get => apellido_Usuario; set => apellido_Usuario = value; }
        public string Codigo_Usuario { get => codigo_Usuario; set => codigo_Usuario = value; }
        public string Id_TipoUsuario { get => id_TipoUsuario; set => id_TipoUsuario = value; }
        public bool Empleado1 { get => Empleado; set => Empleado = value; }
        public string PantallaLabel1 { get => PantallaLabel; set => PantallaLabel = value; }

        ConexionBD con = new ConexionBD();

        //--------------------sql-----------------------------------
        //se utiliza para verificar el usuario y contraseña con la Base de datos
        public bool autentificacion()
        {
            bool result = false;
            //frmLogin log = new frmLogin();
            //--------------------sql-----------------------------------
            //string que se usa para verificar el usuario 
            sql = string.Format("Select * from Usuario where Usuario='{0}'and Contrasena='{1}'", nombre_Usuario, codigo_Usuario);

            cmd = new SqlCommand(sql, sc);
            sc.Open();            

            SqlDataReader lector = cmd.ExecuteReader();

            if (lector.Read())
            {
                nombre_Usuario = lector["Usuario"].ToString();
                codigo_Usuario = lector["Contrasena"].ToString();                                

                result = true;

                Empleado1 = true;
                FrmMenu admin = new FrmMenu(Nombre_Usuario.ToString());
                admin.Show();

            }
            else
            {
                MessageBox.Show("Usuario/Contraseña incorrectos", "Login CML", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            sc.Close();
            return result;
        }
    }
}
