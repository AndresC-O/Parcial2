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
using Parcial_2_emergenciaCOVID19_.Model;

namespace Parcial_2_emergenciaCOVID19_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Loguin log = new Loguin();
            log.Show();
            this.Hide();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            using(emergCovid19Entities bd = new emergCovid19Entities())
            {
                var listaDUI = from user in bd.usuarios
                               where user.DUI == txtDUI.Text

                               select new
                               {
                                   nombre = user.nombre
                               };

                if (listaDUI.Count() > 0)
                {
                    foreach (var iterar in listaDUI)
                    {
                        lblNoeresBen.Visible = false;
                        lblNombrePersona.Visible = true;
                        lblEresBenef.Visible = true;
                        lblNombrePersona.Text = iterar.nombre;
                    }
                }
                else
                {
                    lblNombrePersona.Visible = false;
                    lblEresBenef.Visible = false;
                    lblNoeresBen.Visible = true;
                }
            }
        }

        private void lblNoeresBen_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro que deseas salir?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (result == DialogResult.OK)
            {
                Application.Exit();
            }
        }
    }
}
