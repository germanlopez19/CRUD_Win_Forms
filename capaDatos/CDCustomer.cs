using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using capaEntidad;
using MySql.Data.MySqlClient;
using capaDatos;
using System.Data;

namespace capaDatos
{
    
    public class CDCustomer
    {
        string CadenaConexion = "Server=localhost;User=root;Password=toor;Port=3306;database=curso_cs";
        public void PruebaConexion()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);

            try
            {
                mySqlConnection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectarse" + ex.Message);
                return;
            }
            MessageBox.Show("Conectado...");
        }

        public void Crear(CECustomer cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "INSERT INTO `customers` (`name`, `lastName`, `photo`) VALUES ('"+ cE.Name+ "', '" + cE.LastName + "', '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Photo) + "');";
            MySqlCommand cmd = new MySqlCommand(Query,mySqlConnection);
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro Creado...");
        }

        public DataSet Listar()
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "SELECT * FROM `customers` LIMIT 1000;";
            MySqlDataAdapter Adaptador;
            DataSet dataSet = new DataSet();
            Adaptador = new MySqlDataAdapter(Query,mySqlConnection);
            Adaptador.Fill(dataSet,"tbl");

            return dataSet;
        }

        public void Editar(CECustomer cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "UPDATE `customers` SET `name` = '" + cE.Name + "', `lastName` = '" + cE.LastName + "', `photo` = '" + MySql.Data.MySqlClient.MySqlHelper.EscapeString(cE.Photo) + "' WHERE  `id`='" + cE.Id + "';";
            MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro actualizado...");
        }

        public void Delete(CECustomer cE)
        {
            MySqlConnection mySqlConnection = new MySqlConnection(CadenaConexion);
            mySqlConnection.Open();
            string Query = "DELETE FROM `customers` " + "WHERE  `id`='" + cE.Id + "';";
            MySqlCommand cmd = new MySqlCommand(Query, mySqlConnection);
            cmd.ExecuteNonQuery();
            mySqlConnection.Close();
            MessageBox.Show("Registro eliminado...");
        }

        public void PruebaMySQL()
        {
            PruebaConexion();
        }
    }
}
