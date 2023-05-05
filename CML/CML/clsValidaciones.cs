using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace CML
{
    class clsValidaciones
    {
        int Contador;
        //Metodo de validacion

        public void Numeros(KeyPressEventArgs e)
        {            
            
            //Solo permite numeros se utiliza codigo ASCI para las comprobaciones
            if (e.KeyChar >= 32 && e.KeyChar <= 45 || e.KeyChar >= 58 && e.KeyChar <= 255 || e.KeyChar == 47)
            {
                Contador++;
                e.Handled = true;

                if (Contador > 1)
                {
                    MessageBox.Show("Error, Solo puede ingresar numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Contador = 0;
                    return;
                }
                
            }
        }

        //Solo permite letras 
        public void Letras(KeyPressEventArgs e, TextBox txt)
        {        
            //Esta parte sirve para que no se puedan agregar espacios en los textbox al inicio de la escritura
            if (e.KeyChar == 32 && txt.Text == "")
            {                
                txt.Text = txt.Text.Trim();
                e.Handled = true;
                return;
            }
            if (e.KeyChar >= 33 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                Contador++;
                e.Handled = true;

                if (Contador > 1)
                {
                    MessageBox.Show("Error, Solo puede ingresar Letras", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Contador = 0;
                    return;
                }
                
            }
        }
        //Solo permite letras y numeros
        public void LetrasNumeros(KeyPressEventArgs e, TextBox txt)
        {
            //Esta parte sirve para que no se puedan agregar espacios en los textbox al inicio de la escritura
            if (e.KeyChar == 32 && txt.Text == "")
            { 
                txt.Text = txt.Text.Trim();
                e.Handled = true;
                return;
            }
            if (e.KeyChar >= 33 && e.KeyChar <= 34 || e.KeyChar >= 36 && e.KeyChar <= 39 || e.KeyChar >= 42 && e.KeyChar <= 44 || e.KeyChar >= 58 && e.KeyChar <= 64 || e.KeyChar >= 91 && e.KeyChar <= 96 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                Contador++;
                e.Handled = true;

                if (Contador > 1)
                {
                    MessageBox.Show("Error, Solo puede ingresar Letras y Numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Contador = 0;
                    return;
                }
            }
        }
        public void Usuario(KeyPressEventArgs e, TextBox txt)
        {
            //Esta parte sirve para que no se puedan agregar espacios en los textbox al inicio de la escritura
            if (e.KeyChar == 32 && txt.Text == "")
            {
                txt.Text = txt.Text.Trim();
                e.Handled = true;
                return;
            }
            //y esta para que no se puedan agregar espacios en el correo despues de tener texto
            else if (e.KeyChar == 32)
            {
                Contador++;
                e.Handled = true;

                if (Contador > 1)
                {
                    MessageBox.Show("No puede utilizar espacios en el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Contador = 0;
                    return;
                }
            }

            if (e.KeyChar >= 33 && e.KeyChar <= 44 || e.KeyChar >= 58 && e.KeyChar <= 64 || e.KeyChar >= 128 && e.KeyChar <= 255)
            {
                Contador++;
                e.Handled = true;

                if (Contador > 1)
                {
                    MessageBox.Show("Error, Solo se permiten algunos caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Contador = 0;
                    return;
                }
            }
        }
        public void arroba(KeyPressEventArgs e, TextBox txt)
        {
            //Esta parte sirve para que no se puedan agregar espacios en el textbox al inicio de la escritura
            if (e.KeyChar == 32 && txt.Text == "")
            {
                txt.Text = txt.Text.Trim();
                e.Handled = true;
                return;
            }
            //y esta para que no se puedan agregar espacios en el correo despues de tener texto
            else if (e.KeyChar == 32)
            {
                MessageBox.Show("No puede utilizar espacios en el correo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }

            if (e.KeyChar >= 33 && e.KeyChar <= 45 || e.KeyChar >= 58 && e.KeyChar <= 64 || e.KeyChar >= 90 && e.KeyChar <= 94 || e.KeyChar == 96 || e.KeyChar >= 123 && e.KeyChar <= 255)
            {
                Contador++;
                e.Handled = true;

                if (Contador > 1)
                {
                    MessageBox.Show("Error, Solo puede ingresar Letras Numeros y algunos caracteres especiales", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Contador = 0;
                    return;
                }
            }
        }
        //se prohibe utilizar cualquier tecla
        public void NoModificar(KeyPressEventArgs e)
        {            
            if (e.KeyChar >= 32 && e.KeyChar <= 255)
            {
                Contador++;
                e.Handled = true;

                if (Contador > 1)
                {
                    MessageBox.Show("Error, No Se Puede Modificar El Texto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Contador = 0;
                    return;
                }
            }
        }
        //Se utilizar en la calculadora
        public void NumerosAritmetica(KeyPressEventArgs e)
        {
            if (e.KeyChar >= 32 && e.KeyChar <= 41 || e.KeyChar == 44 && e.KeyChar == 46 || e.KeyChar >= 58 && e.KeyChar <= 255)
            {
                MessageBox.Show("Error, Solo puede ingresar numeros", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Handled = true;
                return;
            }
        }

    }
}
