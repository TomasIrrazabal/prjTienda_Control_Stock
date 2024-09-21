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
    public partial class frmArticulosLista : Form
    {
        List<Articulo> listaArticulos;
        public frmArticulosLista()
        {
            InitializeComponent();
            //txtCodigo.TextChanged += new EventHandler(txtCodigo_TextChaged);
            //txtCodigo.KeyPress += new KeyPressEventHandler(txtCodigo_KeyPress);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

        }

        public void listar()
        {
            ConexionDB db = new ConexionDB();
            listaArticulos = db.listarArticulos();
        }
        public void mostrarArticulo(int id)
        {
            foreach(Articulo art in listaArticulos)
            {
                if(id == art.id)
                {
                    txtNombre.Text = art.nombre.ToString();
                    txtCodigo.Text = art.id.ToString();
                    txtCategoria.Text = art.categoria.ToString();
                    txtCantidad.Text = art.cantidad.ToString();
                    txtPrecio.Text = "$" + art.precio.ToString();
                    rtbDescripcion.Text = art.descripcion.ToString();
                }
            }
        }

        private void btnArticuloSiguiente_Click(object sender, EventArgs e)
        {
            foreach(Articulo art in listaArticulos)
            {

            }
        }

        private void btnArticuloAnterior_Click(object sender, EventArgs e)
        {

        }
    }
}
