using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using capaEntidad;
using capaNegocio;

namespace capaPresentacion
{
    public partial class frmClientes : Form
    {
        CNCustomer cncustomer = new CNCustomer();
        public frmClientes()
        {
            InitializeComponent();
        }

        private void frmClientes_Load(object sender, EventArgs e)
        {
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgvCustomer.DataSource = cncustomer.ObtenerDatos().Tables["tbl"];
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            LimpiarForm();
        }

        private void LimpiarForm()
        {
            txtId.Value = 0;
            txtName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            picPhoto.Image = null;
        }
        private void lnkPhoto_LinkClicked(object sender, EventArgs e)
        {
            ofdPhoto.FileName = string.Empty;
            if (ofdPhoto.ShowDialog() == DialogResult.OK)
            {
                picPhoto.Load(ofdPhoto.FileName);
            }
            ofdPhoto.FileName = string.Empty;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool resultado;
            CECustomer cECustomer = new CECustomer();
            cECustomer.Id = (int)txtId.Value;
            cECustomer.Name = txtName.Text;
            cECustomer.LastName = txtLastName.Text;
            cECustomer.Photo = picPhoto.ImageLocation;

            resultado = cncustomer.ValidarDatos(cECustomer);

            if (resultado == false)
            {
                return;
            }

            if (cECustomer.Id == 0)
            {
                cncustomer.CrearClient(cECustomer);
            }
            else
            {
                cncustomer.EditarClient(cECustomer);
            }

            

            //MessageBox.Show("Todo Bien Vamos a Insertar");
            CargarDatos();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Value == 0)
                return;
            if(MessageBox.Show("¿Deseas eliminar el registro?", "Titulo",MessageBoxButtons.YesNo,MessageBoxIcon.Question)== DialogResult.Yes)
            {
                CECustomer cECustomer = new CECustomer();
                cECustomer.Id = (int)txtId.Value;
                cncustomer.DeleteCustomer(cECustomer);
            }
            CargarDatos();
            LimpiarForm();
            //cncustomer.PruebaConexion();
        }

        private void dgvCustomer_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Value = (int)dgvCustomer.CurrentRow.Cells["id"].Value;
            txtName.Text = dgvCustomer.CurrentRow.Cells ["name"].Value.ToString();
            txtLastName.Text = dgvCustomer.CurrentRow.Cells["lastName"].Value.ToString();
            picPhoto.Load(dgvCustomer.CurrentRow.Cells["photo"].Value.ToString());
        }
    }
}
