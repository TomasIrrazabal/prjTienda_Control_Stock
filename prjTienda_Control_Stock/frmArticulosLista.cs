using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjTienda_Control_Stock
{
    public partial class frmArticulosLista : Form
    {
        List<Articulo> listaArticulos = new List<Articulo>();
        int indiceMaximo = 0;
        int indiceActual = 0;
        public frmArticulosLista()
        {
            InitializeComponent();

            listar();
            mostrarArticulo(1);
            ControlarBoton();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = 0;
            frmBuscarId frm = new frmBuscarId();
            frm.ShowDialog();
            id = frm.valorDevuelto;
            mostrarArticulo(id);
            ControlarBoton();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmCargarNuevoArticulo frm = new frmCargarNuevoArticulo(null);
            frm.ShowDialog();
            listar();
            ControlarBoton();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea aplicar los cambios?", "Aviso", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                ConexionDB db = new ConexionDB();
                int id = int.Parse(txtCodigo.Text);
                MostrarMensaje(db.BorrarArticulo(id.ToString()));
                listaArticulos.Clear();
                listaArticulos = db.listarArticulos();
                if(id > 1)
                {
                    mostrarArticulo(id-1);
                }
                else
                {
                    mostrarArticulo(1);
                }
            }
            else
            {
                MostrarMensaje("Se cancelo el procedimiento");
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo aux = new Articulo();
            foreach(Articulo articulo in listaArticulos)
            {
                if(articulo.id == int.Parse(txtCodigo.Text))
                {
                    aux = articulo;
                    break;
                }
            }
            frmCargarNuevoArticulo frm = new frmCargarNuevoArticulo(aux);
            frm.ShowDialog();
            ConexionDB db = new ConexionDB();
            string mensaje = db.modificarArticulo(frm.art);
            MostrarMensaje(mensaje);
            listar();
            
        }
        private void btnArticuloSiguiente_Click(object sender, EventArgs e)
        {
            if(indiceActual <= indiceMaximo && indiceActual >= 1)
            {
                mostrarArticulo(indiceActual + 1);
                indiceActual++;
            }
            ControlarBoton();
        }

        private void btnArticuloAnterior_Click(object sender, EventArgs e)
        {
            if (indiceActual <= indiceMaximo && indiceActual >= 1)
            {
                mostrarArticulo(indiceActual - 1);
                indiceActual--;
            }
            ControlarBoton();
        }

        public void listar()
        {
            if(listaArticulos.Count > 0)
            {
                listaArticulos.Clear();
            }
            ConexionDB db = new ConexionDB();
            listaArticulos = db.listarArticulos();
            indiceMaximo = listaArticulos.Count;
            buscarIndice();
        }
        public void mostrarArticulo(int id) //fixme
        {
            int indice = listaArticulos.FindIndex(a => a.id == id);
            if (indice >= 0)
            {
                txtNombre.Text = listaArticulos[indice].nombre.ToString();
                txtCodigo.Text = listaArticulos[indice].id.ToString();
                txtCategoria.Text = listaArticulos[indice].categoria.ToString();
                txtCantidad.Text = listaArticulos[indice].cantidad.ToString();
                txtPrecio.Text = "$" + listaArticulos[indice].precio.ToString();
                rtbDescripcion.Text = listaArticulos[indice].descripcion.ToString();
                indiceActual = indice;
            }
            else 
            {
                if (listaArticulos[indice + 1] != null)
                {
                    
                }
                else
                {
                    MostrarMensaje($"No se encontro el articulo registrado en \nID: {id} ");
                }
            }
        }

        public void MostrarMensaje(string msj)
        {
            MessageBox.Show(msj,string.Empty,MessageBoxButtons.OK);
        }
        public int buscarIndice()
        {
            int i = 0;
            foreach(Articulo art in listaArticulos)
            {
                if(i == art.id)
                {
                    break;
                }
                i++;
            }
            return i;
        }
        private void ControlarBoton()
        {
            if (indiceActual >= indiceMaximo)
            {
                btnArticuloSiguiente.Enabled = false;
            }
            else
            {
                btnArticuloSiguiente.Enabled = true; 
            }
            if (indiceActual <= 0)
            {
                btnArticuloAnterior.Enabled = false;
            }
            else
            {
                btnArticuloAnterior.Enabled = true;
            }
        }
    }
}
