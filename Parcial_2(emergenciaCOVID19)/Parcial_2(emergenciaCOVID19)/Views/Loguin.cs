using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial_2_emergenciaCOVID19_.Views;

namespace Parcial_2_emergenciaCOVID19_.Views
{
    public partial class Loguin : Form
    {
        public Loguin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(txtUsuario.Text.Equals("") || txtContra.Text.Equals(""))
            {
                MessageBox.Show("¡Todos los campos son requeridos!", "Completar", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtUsuario.Text.Equals("master") && txtContra.Text.Equals("1234"))
                {
                    Registros reg = new Registros();
                    reg.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("¡El usuario no existe!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
