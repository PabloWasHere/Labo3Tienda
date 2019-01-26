namespace Labo3Tienda.Productos
{
    partial class CatalogoForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tbFiltroMisProductosNombre = new MaterialSkin.Controls.MaterialTabControl();
            this.tpCatalogo = new System.Windows.Forms.TabPage();
            this.materialDivider1 = new MaterialSkin.Controls.MaterialDivider();
            this.cbFiltroCategoria2 = new System.Windows.Forms.ComboBox();
            this.cbFiltroCategoria = new System.Windows.Forms.ComboBox();
            this.materialLabel3 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.tbFiltroNombre = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.tpMisCompras = new System.Windows.Forms.TabPage();
            this.dgvComprasDetalle = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.producto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemCodigoEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.materialLabel4 = new MaterialSkin.Controls.MaterialLabel();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.materialDivider2 = new MaterialSkin.Controls.MaterialDivider();
            this.cbMPEstado = new System.Windows.Forms.ComboBox();
            this.materialLabel5 = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel6 = new MaterialSkin.Controls.MaterialLabel();
            this.dgvCompras = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.codigoEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.items = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tsCatalogo = new MaterialSkin.Controls.MaterialTabSelector();
            this.tbFiltroMisProductosNombre.SuspendLayout();
            this.tpCatalogo.SuspendLayout();
            this.tpMisCompras.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 129);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1337, 439);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tbFiltroMisProductosNombre
            // 
            this.tbFiltroMisProductosNombre.Controls.Add(this.tpCatalogo);
            this.tbFiltroMisProductosNombre.Controls.Add(this.tpMisCompras);
            this.tbFiltroMisProductosNombre.Depth = 0;
            this.tbFiltroMisProductosNombre.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tbFiltroMisProductosNombre.Location = new System.Drawing.Point(0, 89);
            this.tbFiltroMisProductosNombre.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbFiltroMisProductosNombre.Name = "tbFiltroMisProductosNombre";
            this.tbFiltroMisProductosNombre.SelectedIndex = 0;
            this.tbFiltroMisProductosNombre.Size = new System.Drawing.Size(1351, 600);
            this.tbFiltroMisProductosNombre.TabIndex = 1;
            // 
            // tpCatalogo
            // 
            this.tpCatalogo.BackColor = System.Drawing.Color.White;
            this.tpCatalogo.Controls.Add(this.materialDivider1);
            this.tpCatalogo.Controls.Add(this.cbFiltroCategoria2);
            this.tpCatalogo.Controls.Add(this.cbFiltroCategoria);
            this.tpCatalogo.Controls.Add(this.materialLabel3);
            this.tpCatalogo.Controls.Add(this.materialLabel2);
            this.tpCatalogo.Controls.Add(this.tbFiltroNombre);
            this.tpCatalogo.Controls.Add(this.materialLabel1);
            this.tpCatalogo.Controls.Add(this.flowLayoutPanel1);
            this.tpCatalogo.Location = new System.Drawing.Point(4, 25);
            this.tpCatalogo.Name = "tpCatalogo";
            this.tpCatalogo.Padding = new System.Windows.Forms.Padding(3);
            this.tpCatalogo.Size = new System.Drawing.Size(1343, 571);
            this.tpCatalogo.TabIndex = 0;
            this.tpCatalogo.Text = "Catalogo de productos";
            // 
            // materialDivider1
            // 
            this.materialDivider1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider1.Depth = 0;
            this.materialDivider1.Location = new System.Drawing.Point(0, 46);
            this.materialDivider1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider1.Name = "materialDivider1";
            this.materialDivider1.Size = new System.Drawing.Size(1372, 23);
            this.materialDivider1.TabIndex = 7;
            this.materialDivider1.Text = "materialDivider1";
            // 
            // cbFiltroCategoria2
            // 
            this.cbFiltroCategoria2.FormattingEnabled = true;
            this.cbFiltroCategoria2.Location = new System.Drawing.Point(1069, 10);
            this.cbFiltroCategoria2.Name = "cbFiltroCategoria2";
            this.cbFiltroCategoria2.Size = new System.Drawing.Size(231, 24);
            this.cbFiltroCategoria2.TabIndex = 6;
            this.cbFiltroCategoria2.Text = "Seleccionar...";
            this.cbFiltroCategoria2.SelectedIndexChanged += new System.EventHandler(this.cbFiltroCategoria2_SelectedIndexChanged);
            // 
            // cbFiltroCategoria
            // 
            this.cbFiltroCategoria.FormattingEnabled = true;
            this.cbFiltroCategoria.Location = new System.Drawing.Point(619, 10);
            this.cbFiltroCategoria.Name = "cbFiltroCategoria";
            this.cbFiltroCategoria.Size = new System.Drawing.Size(231, 24);
            this.cbFiltroCategoria.TabIndex = 5;
            this.cbFiltroCategoria.Text = "Seleccionar...";
            this.cbFiltroCategoria.SelectedIndexChanged += new System.EventHandler(this.cbFiltroCategoria_SelectedIndexChanged);
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(867, 10);
            this.materialLabel3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(188, 24);
            this.materialLabel3.TabIndex = 4;
            this.materialLabel3.Text = "Categoria secundaria";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(517, 10);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(91, 24);
            this.materialLabel2.TabIndex = 3;
            this.materialLabel2.Text = "Categoria";
            // 
            // tbFiltroNombre
            // 
            this.tbFiltroNombre.Depth = 0;
            this.tbFiltroNombre.Hint = "";
            this.tbFiltroNombre.Location = new System.Drawing.Point(100, 6);
            this.tbFiltroNombre.MouseState = MaterialSkin.MouseState.HOVER;
            this.tbFiltroNombre.Name = "tbFiltroNombre";
            this.tbFiltroNombre.PasswordChar = '\0';
            this.tbFiltroNombre.SelectedText = "";
            this.tbFiltroNombre.SelectionLength = 0;
            this.tbFiltroNombre.SelectionStart = 0;
            this.tbFiltroNombre.Size = new System.Drawing.Size(391, 28);
            this.tbFiltroNombre.TabIndex = 2;
            this.tbFiltroNombre.UseSystemPasswordChar = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(6, 10);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(79, 24);
            this.materialLabel1.TabIndex = 1;
            this.materialLabel1.Text = "Nombre";
            // 
            // tpMisCompras
            // 
            this.tpMisCompras.BackColor = System.Drawing.Color.White;
            this.tpMisCompras.Controls.Add(this.dgvComprasDetalle);
            this.tpMisCompras.Controls.Add(this.dtpHasta);
            this.tpMisCompras.Controls.Add(this.materialLabel4);
            this.tpMisCompras.Controls.Add(this.dtpDesde);
            this.tpMisCompras.Controls.Add(this.materialDivider2);
            this.tpMisCompras.Controls.Add(this.cbMPEstado);
            this.tpMisCompras.Controls.Add(this.materialLabel5);
            this.tpMisCompras.Controls.Add(this.materialLabel6);
            this.tpMisCompras.Controls.Add(this.dgvCompras);
            this.tpMisCompras.Location = new System.Drawing.Point(4, 25);
            this.tpMisCompras.Name = "tpMisCompras";
            this.tpMisCompras.Padding = new System.Windows.Forms.Padding(3);
            this.tpMisCompras.Size = new System.Drawing.Size(1343, 571);
            this.tpMisCompras.TabIndex = 1;
            this.tpMisCompras.Text = "Mis compras";
            // 
            // dgvComprasDetalle
            // 
            this.dgvComprasDetalle.AllowUserToAddRows = false;
            this.dgvComprasDetalle.AllowUserToDeleteRows = false;
            this.dgvComprasDetalle.AllowUserToOrderColumns = true;
            this.dgvComprasDetalle.AllowUserToResizeColumns = false;
            this.dgvComprasDetalle.AllowUserToResizeRows = false;
            this.dgvComprasDetalle.BackgroundColor = System.Drawing.Color.White;
            this.dgvComprasDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvComprasDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.producto,
            this.cantidad,
            this.precio,
            this.itemCodigoEstado});
            this.dgvComprasDetalle.Location = new System.Drawing.Point(367, 142);
            this.dgvComprasDetalle.MultiSelect = false;
            this.dgvComprasDetalle.Name = "dgvComprasDetalle";
            this.dgvComprasDetalle.ReadOnly = true;
            this.dgvComprasDetalle.RowTemplate.Height = 24;
            this.dgvComprasDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvComprasDetalle.Size = new System.Drawing.Size(968, 421);
            this.dgvComprasDetalle.TabIndex = 18;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // producto
            // 
            this.producto.HeaderText = "Producto";
            this.producto.Name = "producto";
            this.producto.ReadOnly = true;
            // 
            // cantidad
            // 
            this.cantidad.HeaderText = "Cantidad";
            this.cantidad.Name = "cantidad";
            this.cantidad.ReadOnly = true;
            // 
            // precio
            // 
            this.precio.HeaderText = "Precio";
            this.precio.Name = "precio";
            this.precio.ReadOnly = true;
            // 
            // itemCodigoEstado
            // 
            this.itemCodigoEstado.HeaderText = "Estado";
            this.itemCodigoEstado.Name = "itemCodigoEstado";
            this.itemCodigoEstado.ReadOnly = true;
            // 
            // dtpHasta
            // 
            this.dtpHasta.Location = new System.Drawing.Point(498, 11);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.ShowCheckBox = true;
            this.dtpHasta.Size = new System.Drawing.Size(285, 22);
            this.dtpHasta.TabIndex = 17;
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(410, 9);
            this.materialLabel4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(56, 24);
            this.materialLabel4.TabIndex = 16;
            this.materialLabel4.Text = "hasta";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Location = new System.Drawing.Point(90, 11);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.ShowCheckBox = true;
            this.dtpDesde.Size = new System.Drawing.Size(285, 22);
            this.dtpDesde.TabIndex = 15;
            // 
            // materialDivider2
            // 
            this.materialDivider2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialDivider2.Depth = 0;
            this.materialDivider2.Location = new System.Drawing.Point(2, 46);
            this.materialDivider2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialDivider2.Name = "materialDivider2";
            this.materialDivider2.Size = new System.Drawing.Size(1372, 23);
            this.materialDivider2.TabIndex = 14;
            this.materialDivider2.Text = "materialDivider2";
            // 
            // cbMPEstado
            // 
            this.cbMPEstado.FormattingEnabled = true;
            this.cbMPEstado.Location = new System.Drawing.Point(979, 9);
            this.cbMPEstado.Name = "cbMPEstado";
            this.cbMPEstado.Size = new System.Drawing.Size(168, 24);
            this.cbMPEstado.TabIndex = 12;
            this.cbMPEstado.Text = "Seleccionar...";
            // 
            // materialLabel5
            // 
            this.materialLabel5.AutoSize = true;
            this.materialLabel5.Depth = 0;
            this.materialLabel5.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel5.Location = new System.Drawing.Point(849, 9);
            this.materialLabel5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel5.Name = "materialLabel5";
            this.materialLabel5.Size = new System.Drawing.Size(69, 24);
            this.materialLabel5.TabIndex = 10;
            this.materialLabel5.Text = "Estado";
            // 
            // materialLabel6
            // 
            this.materialLabel6.AutoSize = true;
            this.materialLabel6.Depth = 0;
            this.materialLabel6.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel6.Location = new System.Drawing.Point(8, 9);
            this.materialLabel6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel6.Name = "materialLabel6";
            this.materialLabel6.Size = new System.Drawing.Size(61, 24);
            this.materialLabel6.TabIndex = 8;
            this.materialLabel6.Text = "Fecha";
            // 
            // dgvCompras
            // 
            this.dgvCompras.AllowUserToAddRows = false;
            this.dgvCompras.AllowUserToDeleteRows = false;
            this.dgvCompras.AllowUserToOrderColumns = true;
            this.dgvCompras.AllowUserToResizeColumns = false;
            this.dgvCompras.AllowUserToResizeRows = false;
            this.dgvCompras.BackgroundColor = System.Drawing.Color.White;
            this.dgvCompras.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompras.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fechaPedido,
            this.codigoEstado,
            this.items});
            this.dgvCompras.Location = new System.Drawing.Point(8, 142);
            this.dgvCompras.MultiSelect = false;
            this.dgvCompras.Name = "dgvCompras";
            this.dgvCompras.ReadOnly = true;
            this.dgvCompras.RowTemplate.Height = 24;
            this.dgvCompras.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCompras.Size = new System.Drawing.Size(353, 421);
            this.dgvCompras.TabIndex = 0;
            // 
            // id
            // 
            this.id.HeaderText = "Id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // fechaPedido
            // 
            this.fechaPedido.HeaderText = "Fecha";
            this.fechaPedido.Name = "fechaPedido";
            this.fechaPedido.ReadOnly = true;
            // 
            // codigoEstado
            // 
            this.codigoEstado.HeaderText = "Estado";
            this.codigoEstado.Name = "codigoEstado";
            this.codigoEstado.ReadOnly = true;
            // 
            // items
            // 
            this.items.HeaderText = "Productos";
            this.items.Name = "items";
            this.items.ReadOnly = true;
            // 
            // tsCatalogo
            // 
            this.tsCatalogo.BaseTabControl = this.tbFiltroMisProductosNombre;
            this.tsCatalogo.Depth = 0;
            this.tsCatalogo.Location = new System.Drawing.Point(-1, 28);
            this.tsCatalogo.MouseState = MaterialSkin.MouseState.HOVER;
            this.tsCatalogo.Name = "tsCatalogo";
            this.tsCatalogo.Size = new System.Drawing.Size(1354, 55);
            this.tsCatalogo.TabIndex = 2;
            this.tsCatalogo.Text = "materialTabSelector1";
            // 
            // CatalogoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1351, 689);
            this.Controls.Add(this.tsCatalogo);
            this.Controls.Add(this.tbFiltroMisProductosNombre);
            this.Name = "CatalogoForm";
            this.tbFiltroMisProductosNombre.ResumeLayout(false);
            this.tpCatalogo.ResumeLayout(false);
            this.tpCatalogo.PerformLayout();
            this.tpMisCompras.ResumeLayout(false);
            this.tpMisCompras.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvComprasDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompras)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private MaterialSkin.Controls.MaterialTabControl tbFiltroMisProductosNombre;
        private System.Windows.Forms.TabPage tpCatalogo;
        private System.Windows.Forms.TabPage tpMisCompras;
        private MaterialSkin.Controls.MaterialTabSelector tsCatalogo;
        private MaterialSkin.Controls.MaterialDivider materialDivider1;
        private System.Windows.Forms.ComboBox cbFiltroCategoria2;
        private System.Windows.Forms.ComboBox cbFiltroCategoria;
        private MaterialSkin.Controls.MaterialLabel materialLabel3;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialSingleLineTextField tbFiltroNombre;
        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialDivider materialDivider2;
        private System.Windows.Forms.ComboBox cbMPEstado;
        private MaterialSkin.Controls.MaterialLabel materialLabel5;
        private MaterialSkin.Controls.MaterialLabel materialLabel6;
        private System.Windows.Forms.DataGridView dgvCompras;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn codigoEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn items;
        private System.Windows.Forms.DataGridView dgvComprasDetalle;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn producto;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemCodigoEstado;
    }
}