using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;
using capaDatos;
using capaEntidad;

namespace capaNegocio
{
    public class CNCustomer
    {
        CDCustomer cDCustomer = new CDCustomer();
        public bool ValidarDatos(CECustomer cliente)
        {
            bool resultado = true;
            if (cliente.Name == string.Empty)
            {
                resultado = false;
                MessageBox.Show("El nombre es obligatorio");
            }
            if (cliente.LastName == string.Empty)
            {
                resultado |= false;
                MessageBox.Show("El apellido es obligatorio");
            }
            if (cliente.Photo == null)
            {
                resultado = false;
                MessageBox.Show("La foto es obligatoria");
            }
            return resultado;
        }

        public void PruebaConexion()
        {
            cDCustomer.PruebaMySQL();
        }

        public void CrearClient(CECustomer cE)
        {
            cDCustomer.Crear(cE);
        }
        public DataSet ObtenerDatos()
        {
            return cDCustomer.Listar();
        }

        public void EditarClient(CECustomer cE)
        {
            cDCustomer.Editar(cE);
        }

        public void DeleteCustomer(CECustomer cE)
        {
            cDCustomer.Delete(cE);
        }
    }
}
