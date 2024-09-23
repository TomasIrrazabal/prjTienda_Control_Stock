namespace prjTienda_Control_Stock
{
    partial class FrmBusqueda
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBusqueda));
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.btnBuscarProd = new System.Windows.Forms.Button();
            this.radID = new System.Windows.Forms.RadioButton();
            this.radNombre = new System.Windows.Forms.RadioButton();
            this.radCategoria = new System.Windows.Forms.RadioButton();
            this.gbBusqueda = new System.Windows.Forms.GroupBox();
            this.gbModificar = new System.Windows.Forms.GroupBox();
            this.numCantProd = new System.Windows.Forms.NumericUpDown();
            this.txtProdModificar = new System.Windows.Forms.TextBox();
            this.btnModificar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.gbBusqueda.SuspendLayout();
            this.gbModificar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantProd)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Enabled = false;
            this.dgvProductos.Location = new System.Drawing.Point(13, 91);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(775, 347);
            this.dgvProductos.TabIndex = 9;
            this.dgvProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProductos_CellClick);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Enabled = false;
            this.txtBusqueda.Location = new System.Drawing.Point(7, 41);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(206, 20);
            this.txtBusqueda.TabIndex = 2;
            // 
            // btnBuscarProd
            // 
            this.btnBuscarProd.Location = new System.Drawing.Point(219, 41);
            this.btnBuscarProd.Name = "btnBuscarProd";
            this.btnBuscarProd.Size = new System.Drawing.Size(100, 20);
            this.btnBuscarProd.TabIndex = 8;
            this.btnBuscarProd.Text = "BUSCAR";
            this.btnBuscarProd.UseVisualStyleBackColor = true;
            this.btnBuscarProd.Click += new System.EventHandler(this.btnBuscarProd_Click);
            // 
            // radID
            // 
            this.radID.AutoSize = true;
            this.radID.Location = new System.Drawing.Point(7, 19);
            this.radID.Name = "radID";
            this.radID.Size = new System.Drawing.Size(39, 17);
            this.radID.TabIndex = 9;
            this.radID.TabStop = true;
            this.radID.Text = "ID:";
            this.radID.UseVisualStyleBackColor = true;
            this.radID.CheckedChanged += new System.EventHandler(this.radID_CheckedChanged);
            // 
            // radNombre
            // 
            this.radNombre.AutoSize = true;
            this.radNombre.Location = new System.Drawing.Point(113, 18);
            this.radNombre.Name = "radNombre";
            this.radNombre.Size = new System.Drawing.Size(65, 17);
            this.radNombre.TabIndex = 10;
            this.radNombre.TabStop = true;
            this.radNombre.Text = "Nombre:";
            this.radNombre.UseVisualStyleBackColor = true;
            this.radNombre.CheckedChanged += new System.EventHandler(this.radNombre_CheckedChanged);
            // 
            // radCategoria
            // 
            this.radCategoria.AutoSize = true;
            this.radCategoria.Location = new System.Drawing.Point(219, 18);
            this.radCategoria.Name = "radCategoria";
            this.radCategoria.Size = new System.Drawing.Size(73, 17);
            this.radCategoria.TabIndex = 11;
            this.radCategoria.TabStop = true;
            this.radCategoria.Text = "Categoria:";
            this.radCategoria.UseVisualStyleBackColor = true;
            this.radCategoria.CheckedChanged += new System.EventHandler(this.radCategoria_CheckedChanged);
            // 
            // gbBusqueda
            // 
            this.gbBusqueda.Controls.Add(this.radCategoria);
            this.gbBusqueda.Controls.Add(this.radNombre);
            this.gbBusqueda.Controls.Add(this.radID);
            this.gbBusqueda.Controls.Add(this.btnBuscarProd);
            this.gbBusqueda.Controls.Add(this.txtBusqueda);
            this.gbBusqueda.Location = new System.Drawing.Point(12, 12);
            this.gbBusqueda.Name = "gbBusqueda";
            this.gbBusqueda.Size = new System.Drawing.Size(335, 73);
            this.gbBusqueda.TabIndex = 8;
            this.gbBusqueda.TabStop = false;
            this.gbBusqueda.Text = "Busqueda de producto";
            // 
            // gbModificar
            // 
            this.gbModificar.Controls.Add(this.numCantProd);
            this.gbModificar.Controls.Add(this.txtProdModificar);
            this.gbModificar.Controls.Add(this.btnModificar);
            this.gbModificar.Location = new System.Drawing.Point(353, 12);
            this.gbModificar.Name = "gbModificar";
            this.gbModificar.Size = new System.Drawing.Size(435, 73);
            this.gbModificar.TabIndex = 12;
            this.gbModificar.TabStop = false;
            this.gbModificar.Text = "Modificar Stock del Producto";
            // 
            // numCantProd
            // 
            this.numCantProd.Location = new System.Drawing.Point(7, 45);
            this.numCantProd.Name = "numCantProd";
            this.numCantProd.Size = new System.Drawing.Size(120, 20);
            this.numCantProd.TabIndex = 2;
            // 
            // txtProdModificar
            // 
            this.txtProdModificar.Enabled = false;
            this.txtProdModificar.Location = new System.Drawing.Point(7, 18);
            this.txtProdModificar.Name = "txtProdModificar";
            this.txtProdModificar.Size = new System.Drawing.Size(187, 20);
            this.txtProdModificar.TabIndex = 1;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(327, 44);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(102, 23);
            this.btnModificar.TabIndex = 0;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // FrmBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbModificar);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.gbBusqueda);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmBusqueda";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Busqueda y Modificación";
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.gbBusqueda.ResumeLayout(false);
            this.gbBusqueda.PerformLayout();
            this.gbModificar.ResumeLayout(false);
            this.gbModificar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numCantProd)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.Button btnBuscarProd;
        private System.Windows.Forms.RadioButton radID;
        private System.Windows.Forms.RadioButton radNombre;
        private System.Windows.Forms.RadioButton radCategoria;
        private System.Windows.Forms.GroupBox gbBusqueda;
        private System.Windows.Forms.GroupBox gbModificar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.NumericUpDown numCantProd;
        private System.Windows.Forms.TextBox txtProdModificar;
    }
}

