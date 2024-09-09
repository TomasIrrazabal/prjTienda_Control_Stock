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
            CadenaConexion = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=./../../../Stock.accdb";
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

        public void buscarProd(string tipoBusqueda, string prod, DataGridView dgv)
        {
            
            try
            {
                if(prod != string.Empty)
                {
                    if (controlDeArticulo(tipoBusqueda,prod))
                    {
                        conexion = new OleDbConnection(CadenaConexion);
                        comando = new OleDbCommand();

                        comando.Connection = conexion;
                        comando.CommandType = CommandType.Text;

                        comando.CommandText = $"SELECT * FROM Productos WHERE {tipoBusqueda} = {prod}";

                        DataTable dt = new DataTable();

                        adaptador = new OleDbDataAdapter(comando);
                        adaptador.Fill(dt);
                        dgv.DataSource = dt;
                    }
                }
                else
                {
                    MessageBox.Show("El articulo no se encuentra \n " +
                        "en la base de datos","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message );
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();

                }
            }
        }
        private bool controlDeArticulo(string tipoBusqueda,string prod)
        {
            bool res = false;
            try
            {
                conexion = new OleDbConnection(CadenaConexion);
                
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                comando = new OleDbCommand($"SELECT COUNT(*) FROM Productos WHERE {tipoBusqueda} = {prod}",conexion);
                int conteo = (int)comando?.ExecuteScalar();
                if ( conteo > 0 )
                {
                    res = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
            return res;
        }
        public bool controlStock(DataGridView dgv)
        {
            bool res = false;
            try
            {
                conexion = new OleDbConnection(CadenaConexion);
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;

                comando.CommandText = $"SELECT * FROM Productos WHERE stock < 10";

                DataTable dt = new DataTable();

                adaptador = new OleDbDataAdapter(comando);
                adaptador.Fill(dt);
                dgv.DataSource = dt;
                if (dt.Rows.Count > 0) 
                {
                    res = true;
                }                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return res;
        }

        public void mostrarStock(DataGridView dgv)
        {
            try
            {
                conexion = new OleDbConnection(CadenaConexion);
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                comando = new OleDbCommand();

                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;

                comando.CommandText = $"SELECT * FROM Productos";

                DataTable dt = new DataTable();

                adaptador = new OleDbDataAdapter(comando);
                adaptador.Fill(dt);
                dgv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
        }
        public string modificarStock(string nombreProd, int cantProd)
        {
            string mensaje = string.Empty;
            try
            {
                using (conexion = new OleDbConnection(CadenaConexion))
                {
                    if(conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }
                    string query = $"UPDATE Productos SET stock = {cantProd} WHERE nombre = '{nombreProd}';";
                    using(comando = new OleDbCommand(query, conexion))
                    {
                        int filasAfectadas = comando.ExecuteNonQuery();
                        if(filasAfectadas > 0)
                        {
                            mensaje = "Se actualizó el registro correctamente.";
                        }
                        else
                        {
                            mensaje = "No se encontró ningún registro para actualizar.";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(conexion.State == ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            return mensaje;
        }
    }
}
