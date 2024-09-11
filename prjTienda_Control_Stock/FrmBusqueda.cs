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

        string tipoBusqueda = string.Empty;
        string nombreProd = string.Empty;
        int cantProd = 0;

        private void btnBuscarProd_Click(object sender, EventArgs e)
        {
            string prod = (txtBusqueda.Text);
            prod = prod.Trim();
            if (radNombre.Checked || radCategoria.Checked)
            {
                prod = ("'"+prod+"'"); 
            }
            ConexionDB db = new ConexionDB();
            db.buscarProd(tipoBusqueda,prod, dgvProductos);
            valorDefectoDGV();
        }


        private void radID_CheckedChanged(object sender, EventArgs e)
        {
            if(radID.Checked)
            {
                tipoBusqueda = "id";
                limpiarTxt();
            }
        }

        private void radNombre_CheckedChanged(object sender, EventArgs e)
        {
            if(radNombre.Checked)
            {
                tipoBusqueda = "nombre";
                limpiarTxt();
            }
        }

        private void radCategoria_CheckedChanged(object sender, EventArgs e)
        {
            if (radCategoria.Checked)
            {
                tipoBusqueda = "categoria";
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
            dgvProductos.Enabled = true;
            dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 &&  e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dgvProductos.Rows[e.RowIndex];
                nombreProd = row.Cells[1].Value.ToString();
                cantProd = Convert.ToInt16( row.Cells[4].Value.ToString());
                //Test de la funcion
                //MessageBox.Show("El valor de la celda seleccionada es: " + nombreProd+ "\n La cantidad de la celda seleccionada es: "+cantProd);
                txtProdModificar.Text = nombreProd;
                numCantProd.Value = cantProd;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea aplicar los cambios?", "Aviso", MessageBoxButtons.OKCancel);
            if(res == DialogResult.OK)
            {
                ConexionDB db = new ConexionDB();
                nombreProd = "'"+ nombreProd+ "'";
                MessageBox.Show(db.modificarStock(nombreProd, cantProd));
                
            }
            else
            {
                MessageBox.Show("Se devolvieron los valores originales del producto seleccionado", "Aviso", MessageBoxButtons.OK);
                txtProdModificar.Text = nombreProd;
                numCantProd.Value = cantProd;
            }
        }
    }
}
