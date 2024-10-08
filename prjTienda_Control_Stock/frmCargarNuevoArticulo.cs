﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace prjTienda_Control_Stock
{
    public partial class frmCargarNuevoArticulo : Form
    {
        public Articulo art { get; private set; }
        public frmCargarNuevoArticulo(Articulo articulo)
        {
            InitializeComponent();
            ValoresPorDefecto();
            art = articulo;
            MostrarArticuloRecibido(art);
            txtPrecio.KeyPress += new KeyPressEventHandler(txtPrecio_KeyPress);
            txtCantidad.KeyPress += new KeyPressEventHandler(txtCantidad_KeyPress);
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            if (validacionDeCampos())
            {
                DialogResult res = MessageBox.Show("¿Desea aplicar los cambios?", "Aviso", MessageBoxButtons.OKCancel);
                if (res == DialogResult.OK)
                {
                    Articulo nuevoArticulo = new Articulo()
                    {
                        nombre = txtNombre.Text,
                        descripcion = txtDescripcion.Text,
                        categoria = txtCategoria.Text,
                        precio = Convert.ToDouble(txtPrecio.Text),
                        cantidad = Convert.ToInt32(txtCantidad.Text)
                    };
                    ConexionDB db = new ConexionDB();
                    db.agregarArticulo(nuevoArticulo);
                    this.Close();
                }
                else
                {
                    DialogResult res2 = MessageBox.Show("¿Desea salir del formulario?", "Aviso", MessageBoxButtons.OKCancel);
                    if(res2 == DialogResult.OK)
                    {
                        this.Close();
                    }
                }

            }
            else
            {
                MessageBox.Show("Debe rellenar bien todos los campos","Error",MessageBoxButtons.OK,MessageBoxIcon.Information); 
            }
        }

        private void ValoresPorDefecto()
        {
            txtNombre.Text = string.Empty;
            txtNombre.Enabled = true;
            txtDescripcion.Text = string.Empty;
            txtDescripcion.Enabled = true;
            txtCategoria.Text = string.Empty;
            txtCategoria.Enabled = true;
            txtPrecio.Text = string.Empty;
            txtPrecio.Enabled = true;
            txtCantidad.Text = string.Empty;    
            txtCantidad.Enabled = true;    
            
        }
        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                if (string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese solamente numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
                if (string.IsNullOrWhiteSpace(txtPrecio.Text))
                {
                    return;
                }
                else
                {
                    MessageBox.Show("Por favor, ingrese solamente numeros", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ValoresPorDefecto();
        }
        private bool validacionDeCampos()
        {
            bool res = false;
            if(txtNombre.Text!= string.Empty && txtDescripcion.Text != string.Empty && txtCategoria.Text != string.Empty &&
                txtPrecio.Text != string.Empty && txtCantidad.Text != string.Empty)
            {
                res = true; 
            }
            return res;
        }
        private void MostrarArticuloRecibido(Articulo art)
        {
            if(art != null)
            {
                btnModificar.Enabled = true;
                btnModificar.Visible = true;
                btnModificar.BringToFront();
                txtNombre.Text = art.nombre;
                txtDescripcion.Text = art.descripcion;
                txtCategoria.Text = art.categoria;
                txtPrecio.Text = art.precio.ToString();
                txtCantidad.Text = art.cantidad.ToString();
            }
            else
            {
                btnCargar.Enabled = true;
                btnCargar.Visible = true;
                btnCargar.BringToFront();
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea aplicar los cambios?","Aviso",MessageBoxButtons.OKCancel);
            if(res == DialogResult.OK)
            {
                art.nombre = txtNombre.Text;
                art.descripcion = txtDescripcion.Text;
                art.categoria = txtCategoria.Text;
                art.precio = double.Parse(txtPrecio.Text);
                art.cantidad = int.Parse(txtCantidad.Text);
                this.Close();
            }
            else
            {
                DialogResult res2 = MessageBox.Show("¿Quiere mantener la información?", "Aviso", MessageBoxButtons.OKCancel);
                if(DialogResult.Cancel == res2)
                {
                    ValoresPorDefecto();
                }
            }
        }
    }
}
