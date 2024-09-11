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
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
            dgvAvisoStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            gbAvisoStock.Visible = false;
            controlStock();

        }

        private void btnBusqueda_Click(object sender, EventArgs e)
        {            
            FrmBusqueda nuevoFrm = new FrmBusqueda();
            nuevoFrm.ShowDialog();
            controlStock();
        }

        private void btnFrmModificaciones_Click(object sender, EventArgs e)
        {
            frmArticulos nuevoFrm = new frmArticulos();
            nuevoFrm.ShowDialog();
            controlStock();
        }

        private void btnFrmStock_Click(object sender, EventArgs e)
        {
            FrmMuestraStock frmMuestraStock = new FrmMuestraStock();
            frmMuestraStock.ShowDialog();
            controlStock();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            ConexionDB db = new ConexionDB();
            db.test();
        }

        private void controlStock()
        {
            ConexionDB conexion = new ConexionDB();
            if (conexion.controlStock(dgvAvisoStock))
            {
                gbAvisoStock.Visible = true;
            }
            
        }


    }
}
