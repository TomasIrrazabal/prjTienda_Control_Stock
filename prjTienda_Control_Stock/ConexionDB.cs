using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace prjTienda_Control_Stock
{
    internal class ConexionDB
    {
        OleDbCommand comando;
        OleDbConnection conexion;
        OleDbDataAdapter adaptador;


        string CadenaConexion;

        public ConexionDB()
        {
            //CadenaConexion = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=./Stock.accdb";
            CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=./Stock.accdb";
        }
        public void test()
        {
            try
            {
                // Intentar abrir la conexión
                conexion = new OleDbConnection(CadenaConexion);
                conexion.Open();
                // Si la conexión es exitosa, mostrar mensaje
                MessageBox.Show("Conexión exitosa");
            }
            catch (Exception ex)
            {
                // Si hay un error, mostrar el mensaje de error
                Console.WriteLine("Error de conexión: " + ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        public void buscarProd(string prod, DataGridView dgv)
        {
            
            try
            {
                if(prod != string.Empty)
                {
                    conexion = new OleDbConnection(CadenaConexion);
                    comando = new OleDbCommand();

                    comando.Connection = conexion;
                    comando.CommandType = CommandType.Text;
                    

                    comando.CommandText = $"SELECT * FROM Productos WHERE id='{prod}' OR categoria = '{prod}' OR nombre = '{prod}';";

                    DataTable dt = new DataTable();

                    adaptador = new OleDbDataAdapter(comando);
                    adaptador.Fill(dt);
                    dgv.DataSource = dt;
                    
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
