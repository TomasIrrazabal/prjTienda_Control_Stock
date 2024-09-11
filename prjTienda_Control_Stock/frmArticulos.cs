using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjTienda_Control_Stock
{
    public partial class frmArticulos : Form
    {
        int articuloActual = 1;
        int maxRegistro;
        Articulo articulo;
        public frmArticulos()
        {
            InitializeComponent();
            ValoresPorDefecto();
            mostrarArticulo(articuloActual);
            actualizarMaxRegistros();
            txtCodigo.TextChanged += new EventHandler(txtCodigo_TextChaged);
            txtCodigo.KeyPress += new KeyPressEventHandler(txtCodigo_KeyPress);

        }

        public void ValoresPorDefecto()
        {
            txtCodigo.Text = string.Empty;
            txtCodigo.Enabled = true; //el unico en true para poder acceder a la busqueda
            txtCategoria.Text = string.Empty;
            txtCategoria.Enabled = false;
            txtNombre.Text = string.Empty;
            txtNombre.Enabled = false;
            txtPrecio.Text = string.Empty;
            txtPrecio.Enabled = false;
            txtCantidad.Text = string.Empty;
            txtCantidad.Enabled = false;

            btnBuscar.Enabled = false;

            rtbDescripcion.Text = string.Empty;
        }
        public void mostrarArticulo(int codigo)
        {
            ConexionDB db = new ConexionDB();
            articulo = db.cargarArticulo(codigo);
            if(articulo != null)
            {
                txtNombre.Text = articulo.nombre.ToString();
                txtCodigo.Text = articulo.id.ToString();
                txtCategoria.Text = articulo.categoria.ToString();
                txtCantidad.Text = articulo.cantidad.ToString();
                txtPrecio.Text = "$" + articulo.precio.ToString();
                rtbDescripcion.Text = articulo.descripcion.ToString();
                articuloActual = Convert.ToInt32(articulo.id);
                controlCodigo();

            }
            else
            {
                MessageBox.Show("Articulo no encontrado.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {                       
            mostrarArticulo(Convert.ToInt32(txtCodigo.Text));            
        }
        private void btnArticuloAnterior_Click(object sender, EventArgs e)
        {
            int siguiente = articuloActual - 1;
            mostrarArticulo(siguiente);
            controlCodigo();
        }

        private void btnArticuloSiguiente_Click(object sender, EventArgs e)
        {
            int anterior = articuloActual + 1;
            mostrarArticulo(anterior);
            controlCodigo();
        }
        private void controlCodigo()
        {
            if (articuloActual == 1)
            {
                btnArticuloAnterior.Enabled = false;
            }
            else
            {
                btnArticuloAnterior.Enabled = true;
            }
            if(articuloActual == maxRegistro)
            {
                btnArticuloSiguiente.Enabled = false;
            }
            else
            {
                btnArticuloSiguiente.Enabled= true;
            }
        }
        public void actualizarMaxRegistros()
        {
            ConexionDB db = new ConexionDB();
            maxRegistro = db.cantidadDeRegistros();
        }
        private void txtCodigo_TextChaged(object sender, EventArgs e)
        {
            int min = 1;
            int max = maxRegistro;
            int valorIngresado;
            if (string.IsNullOrWhiteSpace(txtCodigo.Text))
            {
                
                btnBuscar.Enabled = false; 
                return;
            }

            if (int.TryParse(txtCodigo.Text, out valorIngresado))
            {
                if(valorIngresado >= min && valorIngresado <= max)
                {
                    btnBuscar.Enabled = true;
                }
                else
                {
                    btnBuscar.Enabled = false;
                    MessageBox.Show($"El código ingresado no esta registrado\nBuscar en el rango:\nMínimo: {min}\nMáximo: {max}",
                        "Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
                    mostrarArticulo(max);
                    controlCodigo();
                }
            }
            else
            {
                btnBuscar.Enabled = false;
                MessageBox.Show("Por favor, ingrese solamente numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }
        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {            
            // Permitir solo números, tecla de retroceso, y la tecla de borrar (Delete)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;  // Si no es un número o control, se rechaza la tecla
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCargarNuevoArticulo frm = new frmCargarNuevoArticulo();
            frm.ShowDialog();
            actualizarMaxRegistros();
        }
    }
}
