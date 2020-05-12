using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.EntityClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Parcial_2_emergenciaCOVID19_.Model;

namespace Parcial_2_emergenciaCOVID19_.Views
{
    public partial class Registros : Form
    {
        public Registros()
        {
            InitializeComponent();
        }

        usuarios user = new usuarios();

        void CargarDatos()
        {
            using(emergCovid19Entities bd = new emergCovid19Entities())
            {
                var tbUsuarios = bd.usuarios;

                foreach(var iterar in tbUsuarios)
                {
                    dtvUsuarios.Rows.Add(iterar.id, iterar.nombre, iterar.DUI);
                }
            }

            btnAgregar.Enabled = true;
            btnEliminar.Enabled = false;
            btnActualizar.Enabled = false;
        }

        void LimpiarDatos()
        {
            txtNombres.Text = "";
            txtDUI.Text = "";
        }

        private void Registros_Load(object sender, EventArgs e)
        {
            LimpiarDatos();
            CargarDatos();


        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(txtNombres.Text.Equals("") || txtDUI.Text.Equals(""))
            {
                MessageBox.Show("Rellene todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                using(emergCovid19Entities bd = new emergCovid19Entities())
                {
                    user.nombre = txtNombres.Text;
                    user.DUI = txtDUI.Text;

                    bd.usuarios.Add(user);
                    bd.SaveChanges();
                }

                dtvUsuarios.Rows.Clear();
                CargarDatos();
                LimpiarDatos();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            using(emergCovid19Entities bd = new emergCovid19Entities())
            {
                String id = dtvUsuarios.CurrentRow.Cells[0].Value.ToString();

                int idC = int.Parse(id);

                user = bd.usuarios.Where(VerificarID => VerificarID.id == idC).First();
                user.nombre = txtNombres.Text;
                user.DUI = txtDUI.Text;

                bd.Entry(user).State = System.Data.Entity.EntityState.Modified;
                bd.SaveChanges();
            }

            dtvUsuarios.Rows.Clear();
            CargarDatos();
            LimpiarDatos();
        }

        private void dtvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String nombres = dtvUsuarios.CurrentRow.Cells[1].Value.ToString();
            String dui = dtvUsuarios.CurrentRow.Cells[2].Value.ToString();

            txtNombres.Text = nombres;
            txtDUI.Text = dui;

            btnAgregar.Enabled = false;
            btnEliminar.Enabled = true;
            btnActualizar.Enabled = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using (emergCovid19Entities bd = new emergCovid19Entities())
            {
                String id = dtvUsuarios.CurrentRow.Cells[0].Value.ToString();

                user = bd.usuarios.Find(int.Parse(id));
                bd.usuarios.Remove(user);
                bd.SaveChanges();
            }

            dtvUsuarios.Rows.Clear();
            CargarDatos();
            LimpiarDatos();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Estás seguro que deseas cerrar sesión?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if(result == DialogResult.OK)
            {
                Form1 logout = new Form1();
                logout.Show();
                this.Close();
            }

        }
    }
}
