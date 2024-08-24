namespace prjTienda_Control_Stock
{
    partial class Form1
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
            this.btnTest = new System.Windows.Forms.Button();
            this.txtIDBusqueda = new System.Windows.Forms.TextBox();
            this.txtCatBusqueda = new System.Windows.Forms.TextBox();
            this.txtNombreBusqueda = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnBuscarProd = new System.Windows.Forms.Button();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.radID = new System.Windows.Forms.RadioButton();
            this.radNombre = new System.Windows.Forms.RadioButton();
            this.radCategoria = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(713, 415);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "DBTest";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtIDBusqueda
            // 
            this.txtIDBusqueda.Enabled = false;
            this.txtIDBusqueda.Location = new System.Drawing.Point(7, 41);
            this.txtIDBusqueda.Name = "txtIDBusqueda";
            this.txtIDBusqueda.Size = new System.Drawing.Size(100, 20);
            this.txtIDBusqueda.TabIndex = 2;
            // 
            // txtCatBusqueda
            // 
            this.txtCatBusqueda.Enabled = false;
            this.txtCatBusqueda.Location = new System.Drawing.Point(219, 41);
            this.txtCatBusqueda.Name = "txtCatBusqueda";
            this.txtCatBusqueda.Size = new System.Drawing.Size(100, 20);
            this.txtCatBusqueda.TabIndex = 3;
            // 
            // txtNombreBusqueda
            // 
            this.txtNombreBusqueda.Enabled = false;
            this.txtNombreBusqueda.Location = new System.Drawing.Point(113, 41);
            this.txtNombreBusqueda.Name = "txtNombreBusqueda";
            this.txtNombreBusqueda.Size = new System.Drawing.Size(100, 20);
            this.txtNombreBusqueda.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radCategoria);
            this.groupBox1.Controls.Add(this.radNombre);
            this.groupBox1.Controls.Add(this.radID);
            this.groupBox1.Controls.Add(this.btnBuscarProd);
            this.groupBox1.Controls.Add(this.txtCatBusqueda);
            this.groupBox1.Controls.Add(this.txtIDBusqueda);
            this.groupBox1.Controls.Add(this.txtNombreBusqueda);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(335, 112);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Busqueda de producto";
            // 
            // btnBuscarProd
            // 
            this.btnBuscarProd.Location = new System.Drawing.Point(219, 67);
            this.btnBuscarProd.Name = "btnBuscarProd";
            this.btnBuscarProd.Size = new System.Drawing.Size(100, 23);
            this.btnBuscarProd.TabIndex = 8;
            this.btnBuscarProd.Text = "BUSCAR";
            this.btnBuscarProd.UseVisualStyleBackColor = true;
            this.btnBuscarProd.Click += new System.EventHandler(this.btnBuscarProd_Click);
            // 
            // dgvProductos
            // 
            this.dgvProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProductos.Location = new System.Drawing.Point(13, 242);
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.Size = new System.Drawing.Size(746, 150);
            this.dgvProductos.TabIndex = 9;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvProductos);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtIDBusqueda;
        private System.Windows.Forms.TextBox txtCatBusqueda;
        private System.Windows.Forms.TextBox txtNombreBusqueda;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscarProd;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.RadioButton radCategoria;
        private System.Windows.Forms.RadioButton radNombre;
        private System.Windows.Forms.RadioButton radID;
    }
}

