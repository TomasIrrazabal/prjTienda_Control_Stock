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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            ConexionDB db = new ConexionDB();
            db.test();
        }

        private void btnBuscarProd_Click(object sender, EventArgs e)
        {
            string prod = (txtIDBusqueda.Text + txtNombreBusqueda.Text + txtCatBusqueda.Text);
            prod = prod.Trim();
            ConexionDB db = new ConexionDB();
            db.buscarProd(prod, dgvProductos);
        }

        private void radID_CheckedChanged(object sender, EventArgs e)
        {
            if (radID.Checked)
            {
                txtIDBusqueda.Enabled = true;
                radCategoria.Checked = false;
                radNombre.Checked = false;
            }
            else
            {
                txtIDBusqueda.Enabled=false;

            }
            limpiarTxt();
        }

        private void radNombre_CheckedChanged(object sender, EventArgs e)
        {
            if (radNombre.Checked)
            {
                txtNombreBusqueda.Enabled = true;
                radID.Checked = false;
                radCategoria.Checked = false;
            }
            else
            {
                txtNombreBusqueda.Enabled = false;
            }
            limpiarTxt();
        }

        private void radCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if(radCategoria.Checked)
            {
                txtCatBusqueda.Enabled = true;
                radID.Checked = false;
                radNombre.Checked = false;
            }
            else
            {
                txtCatBusqueda.Enabled = false;
            }
            limpiarTxt();
        }
        private void limpiarTxt()
        {
            txtCatBusqueda.Text = string.Empty; 
            txtIDBusqueda.Text= string.Empty;
            txtNombreBusqueda.Text= string.Empty;
        }
    }
}
