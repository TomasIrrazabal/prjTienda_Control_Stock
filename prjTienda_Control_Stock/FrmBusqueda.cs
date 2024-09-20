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
        Articulo artAux = new Articulo();
        
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
            presetearTipoBusqueda(tipoBusqueda);
        }

        private void radNombre_CheckedChanged(object sender, EventArgs e)
        {
            presetearTipoBusqueda(tipoBusqueda);
        }

        private void radCategoria_CheckedChanged(object sender, EventArgs e)
        {
            presetearTipoBusqueda(tipoBusqueda);
        }
        public string presetearTipoBusqueda(string busqueda)
        {
            if (radID.Checked)
            {
                tipoBusqueda = "id";
                limpiarTxt();
            }
            if (radCategoria.Checked)
            {
                tipoBusqueda = "categoria";
                limpiarTxt();
            }
            if (radNombre.Checked)
            {
                tipoBusqueda = "nombre";
                limpiarTxt();
            }
            return busqueda;
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
                artAux.id = Convert.ToInt16(row.Cells[0].Value.ToString());
                artAux.nombre = row.Cells[1].Value.ToString();
                artAux.nombre = "'" + artAux.nombre + "'";
                artAux.descripcion = row.Cells[2].Value.ToString();
                artAux.precio = double.Parse(row.Cells[3].Value.ToString());
                artAux.cantidad = Convert.ToInt16(row.Cells[4].Value.ToString());
                artAux.categoria = row.Cells[1].Value.ToString();
                
                numCantProd.Value =artAux.cantidad;
                txtProdModificar.Text = artAux.nombre;
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Desea aplicar los cambios?", "Aviso", MessageBoxButtons.OKCancel);
            if(res == DialogResult.OK)
            {
                ConexionDB db = new ConexionDB();
                MessageBox.Show(db.modificarStock(artAux.nombre, int.Parse(numCantProd.Value.ToString())));
                db.buscarProd(tipoBusqueda, artAux.id.ToString(), dgvProductos);
            }
            else
            {
                MessageBox.Show("Se devolvieron los valores originales del producto seleccionado", "Aviso", MessageBoxButtons.OK);
                txtProdModificar.Text = artAux.nombre;
                numCantProd.Value = artAux.cantidad;
            }
        }
    }
}
