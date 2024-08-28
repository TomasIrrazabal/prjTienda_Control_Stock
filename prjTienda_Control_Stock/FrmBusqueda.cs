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
    public partial class FrmBusqueda : Form
    {
        public FrmBusqueda()
        {
            InitializeComponent();
            valoresPorDefecto();
        }

        string tipoProducto = string.Empty;



        private void btnBuscarProd_Click(object sender, EventArgs e)
        {
            string prod = (txtBusqueda.Text);
            prod = prod.Trim();
            if (radNombre.Checked)
            {
                prod = ("'"+prod+"'");
            }
            ConexionDB db = new ConexionDB();
            db.buscarProd(tipoProducto,prod, dgvProductos);
        }




        private void radID_CheckedChanged(object sender, EventArgs e)
        {
            if(radID.Checked)
            {
                tipoProducto = "id";
                limpiarTxt();
            }
        }

        private void radNombre_CheckedChanged(object sender, EventArgs e)
        {
            if(radNombre.Checked)
            {
                tipoProducto = "nombre";
                limpiarTxt();
            }
        }

        private void radCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (radCategoria.Checked)
            {
                tipoProducto = "categoria";
                limpiarTxt();
            }
        }
        private void limpiarTxt()
        {
            txtBusqueda.Text = string.Empty;
        }
        private void valoresPorDefecto()
        {
            valoresPorDefectoBusqueda();
            valorDefectoDGV();
        }

        private void valoresPorDefectoBusqueda()
        {
            radID.Checked = true;
            radNombre.Checked = false;
            radCategoria.Checked = false;
            txtBusqueda.Text = string.Empty;
            txtBusqueda.Enabled = true;

        }
        private void valorDefectoDGV()
        {
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
    }
}
