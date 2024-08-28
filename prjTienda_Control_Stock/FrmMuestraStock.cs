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
    public partial class FrmMuestraStock : Form
    {
        public FrmMuestraStock()
        {
            InitializeComponent();
            dgvStock.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            ConexionDB db = new ConexionDB();
            db.mostrarStock(dgvStock);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ConexionDB db = new ConexionDB();
            db.mostrarStock(dgvStock);
        }
    }
}
