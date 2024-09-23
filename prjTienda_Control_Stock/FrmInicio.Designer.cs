namespace prjTienda_Control_Stock
{
    partial class FrmInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmInicio));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnFrmStock = new System.Windows.Forms.Button();
            this.btnFrmArticulos = new System.Windows.Forms.Button();
            this.btnFrmBusqueda = new System.Windows.Forms.Button();
            this.gbAvisoStock = new System.Windows.Forms.GroupBox();
            this.dgvAvisoStock = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            this.gbAvisoStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvisoStock)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnTest);
            this.panel1.Controls.Add(this.btnFrmStock);
            this.panel1.Controls.Add(this.btnFrmArticulos);
            this.panel1.Controls.Add(this.btnFrmBusqueda);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 30);
            this.panel1.TabIndex = 0;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(663, 2);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(130, 23);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test Base de Datos";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnFrmStock
            // 
            this.btnFrmStock.Location = new System.Drawing.Point(165, 2);
            this.btnFrmStock.Name = "btnFrmStock";
            this.btnFrmStock.Size = new System.Drawing.Size(75, 23);
            this.btnFrmStock.TabIndex = 2;
            this.btnFrmStock.Text = "Stock";
            this.btnFrmStock.UseVisualStyleBackColor = true;
            this.btnFrmStock.Click += new System.EventHandler(this.btnFrmStock_Click);
            // 
            // btnFrmArticulos
            // 
            this.btnFrmArticulos.Location = new System.Drawing.Point(84, 2);
            this.btnFrmArticulos.Name = "btnFrmArticulos";
            this.btnFrmArticulos.Size = new System.Drawing.Size(75, 23);
            this.btnFrmArticulos.TabIndex = 1;
            this.btnFrmArticulos.Text = "Articulos";
            this.btnFrmArticulos.UseVisualStyleBackColor = true;
            this.btnFrmArticulos.Click += new System.EventHandler(this.btnFrmModificaciones_Click);
            // 
            // btnFrmBusqueda
            // 
            this.btnFrmBusqueda.Location = new System.Drawing.Point(3, 2);
            this.btnFrmBusqueda.Name = "btnFrmBusqueda";
            this.btnFrmBusqueda.Size = new System.Drawing.Size(75, 23);
            this.btnFrmBusqueda.TabIndex = 0;
            this.btnFrmBusqueda.Text = "Busqueda";
            this.btnFrmBusqueda.UseVisualStyleBackColor = true;
            this.btnFrmBusqueda.Click += new System.EventHandler(this.btnBusqueda_Click);
            // 
            // gbAvisoStock
            // 
            this.gbAvisoStock.Controls.Add(this.dgvAvisoStock);
            this.gbAvisoStock.Location = new System.Drawing.Point(0, 256);
            this.gbAvisoStock.Name = "gbAvisoStock";
            this.gbAvisoStock.Size = new System.Drawing.Size(800, 193);
            this.gbAvisoStock.TabIndex = 1;
            this.gbAvisoStock.TabStop = false;
            this.gbAvisoStock.Text = "Falta de stock";
            // 
            // dgvAvisoStock
            // 
            this.dgvAvisoStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAvisoStock.Location = new System.Drawing.Point(7, 20);
            this.dgvAvisoStock.Name = "dgvAvisoStock";
            this.dgvAvisoStock.Size = new System.Drawing.Size(787, 162);
            this.dgvAvisoStock.TabIndex = 0;
            // 
            // FrmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gbAvisoStock);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "inicio";
            this.panel1.ResumeLayout(false);
            this.gbAvisoStock.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvisoStock)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFrmStock;
        private System.Windows.Forms.Button btnFrmArticulos;
        private System.Windows.Forms.Button btnFrmBusqueda;
        private System.Windows.Forms.GroupBox gbAvisoStock;
        private System.Windows.Forms.DataGridView dgvAvisoStock;
        private System.Windows.Forms.Button btnTest;
    }
}