using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices.ComTypes;

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
                    comando = new OleDbCommand();
                    string query = $"UPDATE Productos SET stock = {cantProd} WHERE nombre = {nombreProd}";
                    

                    comando.Connection = conexion;
                    comando.CommandText = query;

                    adaptador = new OleDbDataAdapter(comando);
                    
                    
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        mensaje = "Se actualizó el registro correctamente.";
                    }
                    else
                    {
                        mensaje = "No se encontró ningún registro para actualizar.";
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

        public Articulo cargarArticulo (int codigo)
        {
            Articulo articulo = new Articulo();
            try
            {
                int registros = cantidadDeRegistros();
                if(codigo>0 && codigo <= registros)
                {
                    using (conexion = new OleDbConnection(CadenaConexion))
                    {
                        if (conexion.State != ConnectionState.Open)
                        {
                            conexion.Open();
                        }
                        string query = $"SELECT * FROM Productos WHERE id = {codigo}";
                        using(comando = new OleDbCommand(query, conexion))
                        {
                            using (OleDbDataReader lector = comando.ExecuteReader())
                            {

                                if (lector.Read())
                                {
                                    articulo.id = !lector.IsDBNull(0) ? lector.GetInt32(0) : 0; // Asumiendo que id es un entero.
                                    articulo.nombre = !lector.IsDBNull(1) ? lector.GetString(1) : string.Empty;
                                    articulo.descripcion = !lector.IsDBNull(2) ? lector.GetString(2) : string.Empty;
                                    articulo.precio = !lector.IsDBNull(3) ? lector.GetDouble(3) : 0.0; // Asegúrate de que precio sea un tipo numérico.
                                    articulo.cantidad = !lector.IsDBNull(4) ? lector.GetInt32(4) : 0;
                                    articulo.categoria = !lector.IsDBNull(5) ? lector.GetString(5) : string.Empty;
                                }
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return articulo;
        }
        public int cantidadDeRegistros()
        {
            int conteo = 0;
            using (conexion = new OleDbConnection(CadenaConexion))
            {
                if (conexion.State != ConnectionState.Open)
                {
                    conexion.Open();
                }
                string query = $"SELECT COUNT(*) FROM Productos";
                using (comando = new OleDbCommand(query, conexion))
                {
                    object resultado = comando.ExecuteScalar();
                    if(resultado != DBNull.Value)
                    {
                        conteo = Convert.ToInt16(resultado);
                    }
                }
            }
            return conteo;
        }

        public void agregarArticulo(Articulo articulo)
        {
            try
            {
                using (conexion = new OleDbConnection(CadenaConexion))
                {
                    if(conexion.State != ConnectionState.Open)
                    {
                        conexion.Open();
                    }
                    
                    string query = "INSERT INTO Productos (nombre, descripcion, precio, stock, categoria) VALUES (@nombre, @descripcion, @precio, @stock, @categoria)";
                    using (comando = new OleDbCommand(query, conexion))
                    {

                        comando.Parameters.AddWithValue("@nombre", "'"+articulo.nombre+"'");
                        comando.Parameters.AddWithValue("@descripcion", articulo.descripcion);
                        comando.Parameters.AddWithValue("@precio", articulo.precio);
                        comando.Parameters.AddWithValue("@stock",articulo.cantidad);
                        comando.Parameters.AddWithValue("@categoria", articulo.categoria);

                        int filasAfectadas = comando.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("Registro insertado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("No se pudo insertar el registro.");
                        }
                    }
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
