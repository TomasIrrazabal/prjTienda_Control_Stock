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
            mostrarArticuloPorIndice(0);
            ControlarBoton();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            int id = 0;
            frmBuscarId frm = new frmBuscarId();
            frm.ShowDialog();
            id = frm.valorDevuelto;
            MostrarArticuloPorID(id);
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
                listar();
                if (indiceActual > 0)
                {
                    indiceActual--;
                }
                if (id > 1)
                {
                    mostrarArticuloPorIndice(indiceActual);
                }
                else
                {
                    mostrarArticuloPorIndice(1);
                }
            }
            else
            {
                MostrarMensaje("Se cancelo el procedimiento");
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo aux = listaArticulos[indiceActual];
            frmCargarNuevoArticulo frm = new frmCargarNuevoArticulo(aux);
            frm.ShowDialog();
            ConexionDB db = new ConexionDB();
            string mensaje = db.modificarArticulo(frm.art);
            MostrarMensaje(mensaje);
            listar();
            Articulo articuloAux = frm.art;
            if (listaArticulos.Contains(articuloAux))
            {
                int id = Convert.ToInt32(articuloAux.id);
                MostrarArticuloPorID(id);
            }
            else
            {
                mostrarArticuloPorIndice(indiceActual+1);
            }

            
        }
        private void btnArticuloSiguiente_Click(object sender, EventArgs e)
        {
            if(indiceActual < indiceMaximo)
            {
                indiceActual++;
                mostrarArticuloPorIndice(indiceActual);
                
            }
            ControlarBoton();
        }

        private void btnArticuloAnterior_Click(object sender, EventArgs e)
        {
            if (indiceActual > 0)
            {
                indiceActual--;
                mostrarArticuloPorIndice(indiceActual);
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
            indiceMaximo = listaArticulos.Count -1;

        }
        public void MostrarArticuloPorID(int i) 
        {
            int indice = listaArticulos.FindIndex(a => a.id == i);
            if (indice >= 0)
            {
                indiceActual = indice;
                txtNombre.Text = listaArticulos[indice].nombre.ToString();
                txtCodigo.Text = listaArticulos[indice].id.ToString();
                txtCategoria.Text = listaArticulos[indice].categoria.ToString();
                txtCantidad.Text = listaArticulos[indice].cantidad.ToString();
                txtPrecio.Text = "$" + listaArticulos[indice].precio.ToString();
                rtbDescripcion.Text = listaArticulos[indice].descripcion.ToString();
            }
            else 
            {
                MostrarMensaje($"No se encontro articulo registrado. ");
            }
        }       
        public void mostrarArticuloPorIndice(int i) 
        {
            if (i >= 0 && i <= listaArticulos.Count()-1)
            {
                txtNombre.Text = listaArticulos[i].nombre.ToString();
                txtCodigo.Text = listaArticulos[i].id.ToString();
                txtCategoria.Text = listaArticulos[i].categoria.ToString();
                txtCantidad.Text = listaArticulos[i].cantidad.ToString();
                txtPrecio.Text = "$" + listaArticulos[i].precio.ToString();
                rtbDescripcion.Text = listaArticulos[i].descripcion.ToString();
            }
            else 
            {
                bool res = false;
                foreach(Articulo articulo in listaArticulos)
                {
                    if(articulo == null)
                    {
                        res = true;
                    }
                }
                if(res)
                {
                    MostrarMensaje($"No se encontro articulo registrado. ");
                }
            }
        }

        public void MostrarMensaje(string msj)
        {
            MessageBox.Show(msj,string.Empty,MessageBoxButtons.OK);
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
            if (indiceActual > 0)
            {
                btnArticuloAnterior.Enabled = true;
            }
            else
            {
                btnArticuloAnterior.Enabled = false;
            }
        }
    }
}
