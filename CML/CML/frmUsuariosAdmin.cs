using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CML
{
    public partial class frmUsuariosAdmin : Form
    {
        string Usuario = "";
        public frmUsuariosAdmin()
        {
            InitializeComponent();
        }

        public frmUsuariosAdmin(string usuario)
        {
            InitializeComponent();
            Usuario = usuario;
        }

        public void Ingresar()
        {
            if(txtContrasena.Text == "")
            {
                MessageBox.Show("Contraseña vacia", "Ingresar a Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (txtContrasena.Text == "668246Litoral")
                {
                    FrmUsuarios user = new FrmUsuarios(Usuario);
                    user.ShowDialog();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Contraseña Incorrecta", "Ingresar a Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }            
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void txtContrasena_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtContrasena_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Ingresar();
            }
        }
    }
}
