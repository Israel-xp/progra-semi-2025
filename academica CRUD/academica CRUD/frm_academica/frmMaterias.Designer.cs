namespace Formulario_Academica
{
    partial class frmMaterias
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
            this.grbBusquedaMateria = new System.Windows.Forms.GroupBox();
            this.cboBuscarMateria = new System.Windows.Forms.ComboBox();
            this.grdMateria = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscarMateria = new System.Windows.Forms.TextBox();
            this.grbEdicionMateria = new System.Windows.Forms.GroupBox();
            this.btnEliminarMateria = new System.Windows.Forms.Button();
            this.btnModificarMateria = new System.Windows.Forms.Button();
            this.btnNuevoMateria = new System.Windows.Forms.Button();
            this.grbNavegacionMateria = new System.Windows.Forms.GroupBox();
            this.lblCantidadResgisMateria = new System.Windows.Forms.Label();
            this.btnUltimoMateria = new System.Windows.Forms.Button();
            this.btnSiguienteMateria = new System.Windows.Forms.Button();
            this.btnAnteriorMateria = new System.Windows.Forms.Button();
            this.btnPrimerMateria = new System.Windows.Forms.Button();
            this.grbDatosMateria = new System.Windows.Forms.GroupBox();
            this.lblIDMateria = new System.Windows.Forms.Label();
            this.txtUvMateria = new System.Windows.Forms.TextBox();
            this.lblUvMateria = new System.Windows.Forms.Label();
            this.txtNombreMateria = new System.Windows.Forms.TextBox();
            this.lblNombreMateria = new System.Windows.Forms.Label();
            this.txtCodigoMateria = new System.Windows.Forms.TextBox();
            this.lblCodigoMateria = new System.Windows.Forms.Label();
            this.grbBusquedaMateria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMateria)).BeginInit();
            this.grbEdicionMateria.SuspendLayout();
            this.grbNavegacionMateria.SuspendLayout();
            this.grbDatosMateria.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbBusquedaMateria
            // 
            this.grbBusquedaMateria.Controls.Add(this.cboBuscarMateria);
            this.grbBusquedaMateria.Controls.Add(this.grdMateria);
            this.grbBusquedaMateria.Controls.Add(this.txtBuscarMateria);
            this.grbBusquedaMateria.Location = new System.Drawing.Point(496, 34);
            this.grbBusquedaMateria.Name = "grbBusquedaMateria";
            this.grbBusquedaMateria.Size = new System.Drawing.Size(678, 290);
            this.grbBusquedaMateria.TabIndex = 7;
            this.grbBusquedaMateria.TabStop = false;
            this.grbBusquedaMateria.Text = "Busqueda de materias";
            // 
            // cboBuscarMateria
            // 
            this.cboBuscarMateria.FormattingEnabled = true;
            this.cboBuscarMateria.Items.AddRange(new object[] {
            "Código",
            "Materia"});
            this.cboBuscarMateria.Location = new System.Drawing.Point(6, 35);
            this.cboBuscarMateria.Name = "cboBuscarMateria";
            this.cboBuscarMateria.Size = new System.Drawing.Size(166, 28);
            this.cboBuscarMateria.TabIndex = 2;
            // 
            // grdMateria
            // 
            this.grdMateria.AllowUserToAddRows = false;
            this.grdMateria.AllowUserToDeleteRows = false;
            this.grdMateria.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdMateria.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Codigo,
            this.Nombre,
            this.UV});
            this.grdMateria.Location = new System.Drawing.Point(36, 82);
            this.grdMateria.Name = "grdMateria";
            this.grdMateria.ReadOnly = true;
            this.grdMateria.RowHeadersWidth = 62;
            this.grdMateria.RowTemplate.Height = 28;
            this.grdMateria.Size = new System.Drawing.Size(635, 176);
            this.grdMateria.TabIndex = 1;
            this.grdMateria.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdMateria_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Idateria";
            this.ID.HeaderText = "Id";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 150;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "código";
            this.Codigo.MinimumWidth = 8;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 150;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "nombre";
            this.Nombre.MinimumWidth = 8;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 150;
            // 
            // UV
            // 
            this.UV.DataPropertyName = "uv";
            this.UV.HeaderText = "uv";
            this.UV.MinimumWidth = 8;
            this.UV.Name = "UV";
            this.UV.ReadOnly = true;
            this.UV.Width = 150;
            // 
            // txtBuscarMateria
            // 
            this.txtBuscarMateria.Location = new System.Drawing.Point(195, 35);
            this.txtBuscarMateria.Name = "txtBuscarMateria";
            this.txtBuscarMateria.Size = new System.Drawing.Size(476, 26);
            this.txtBuscarMateria.TabIndex = 0;
            this.txtBuscarMateria.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarMateria_KeyUp);
            // 
            // grbEdicionMateria
            // 
            this.grbEdicionMateria.Controls.Add(this.btnEliminarMateria);
            this.grbEdicionMateria.Controls.Add(this.btnModificarMateria);
            this.grbEdicionMateria.Controls.Add(this.btnNuevoMateria);
            this.grbEdicionMateria.Location = new System.Drawing.Point(496, 360);
            this.grbEdicionMateria.Name = "grbEdicionMateria";
            this.grbEdicionMateria.Size = new System.Drawing.Size(502, 100);
            this.grbEdicionMateria.TabIndex = 6;
            this.grbEdicionMateria.TabStop = false;
            this.grbEdicionMateria.Text = "Navegación";
            // 
            // btnEliminarMateria
            // 
            this.btnEliminarMateria.Location = new System.Drawing.Point(307, 37);
            this.btnEliminarMateria.Name = "btnEliminarMateria";
            this.btnEliminarMateria.Size = new System.Drawing.Size(126, 43);
            this.btnEliminarMateria.TabIndex = 5;
            this.btnEliminarMateria.Text = "Eliminar";
            this.btnEliminarMateria.UseVisualStyleBackColor = true;
            this.btnEliminarMateria.Click += new System.EventHandler(this.btnEliminarMateria_Click);
            // 
            // btnModificarMateria
            // 
            this.btnModificarMateria.Location = new System.Drawing.Point(164, 37);
            this.btnModificarMateria.Name = "btnModificarMateria";
            this.btnModificarMateria.Size = new System.Drawing.Size(126, 43);
            this.btnModificarMateria.TabIndex = 4;
            this.btnModificarMateria.Text = "Modificar";
            this.btnModificarMateria.UseVisualStyleBackColor = true;
            this.btnModificarMateria.Click += new System.EventHandler(this.btnModificarMateria_Click);
            // 
            // btnNuevoMateria
            // 
            this.btnNuevoMateria.Location = new System.Drawing.Point(19, 37);
            this.btnNuevoMateria.Name = "btnNuevoMateria";
            this.btnNuevoMateria.Size = new System.Drawing.Size(126, 43);
            this.btnNuevoMateria.TabIndex = 3;
            this.btnNuevoMateria.Text = "Nuevo";
            this.btnNuevoMateria.UseVisualStyleBackColor = true;
            this.btnNuevoMateria.Click += new System.EventHandler(this.btnNuevoMateria_Click);
            // 
            // grbNavegacionMateria
            // 
            this.grbNavegacionMateria.Controls.Add(this.lblCantidadResgisMateria);
            this.grbNavegacionMateria.Controls.Add(this.btnUltimoMateria);
            this.grbNavegacionMateria.Controls.Add(this.btnSiguienteMateria);
            this.grbNavegacionMateria.Controls.Add(this.btnAnteriorMateria);
            this.grbNavegacionMateria.Controls.Add(this.btnPrimerMateria);
            this.grbNavegacionMateria.Location = new System.Drawing.Point(22, 360);
            this.grbNavegacionMateria.Name = "grbNavegacionMateria";
            this.grbNavegacionMateria.Size = new System.Drawing.Size(430, 100);
            this.grbNavegacionMateria.TabIndex = 5;
            this.grbNavegacionMateria.TabStop = false;
            this.grbNavegacionMateria.Text = "Navegación";
            // 
            // lblCantidadResgisMateria
            // 
            this.lblCantidadResgisMateria.AutoSize = true;
            this.lblCantidadResgisMateria.Location = new System.Drawing.Point(167, 48);
            this.lblCantidadResgisMateria.Name = "lblCantidadResgisMateria";
            this.lblCantidadResgisMateria.Size = new System.Drawing.Size(51, 20);
            this.lblCantidadResgisMateria.TabIndex = 3;
            this.lblCantidadResgisMateria.Text = "x de n";
            // 
            // btnUltimoMateria
            // 
            this.btnUltimoMateria.Location = new System.Drawing.Point(285, 37);
            this.btnUltimoMateria.Name = "btnUltimoMateria";
            this.btnUltimoMateria.Size = new System.Drawing.Size(55, 43);
            this.btnUltimoMateria.TabIndex = 5;
            this.btnUltimoMateria.Text = ">|";
            this.btnUltimoMateria.UseVisualStyleBackColor = true;
            this.btnUltimoMateria.Click += new System.EventHandler(this.btnUltimoMateria_Click);
            // 
            // btnSiguienteMateria
            // 
            this.btnSiguienteMateria.Location = new System.Drawing.Point(224, 37);
            this.btnSiguienteMateria.Name = "btnSiguienteMateria";
            this.btnSiguienteMateria.Size = new System.Drawing.Size(55, 43);
            this.btnSiguienteMateria.TabIndex = 4;
            this.btnSiguienteMateria.Text = ">";
            this.btnSiguienteMateria.UseVisualStyleBackColor = true;
            this.btnSiguienteMateria.Click += new System.EventHandler(this.btnSiguienteMateria_Click);
            // 
            // btnAnteriorMateria
            // 
            this.btnAnteriorMateria.Location = new System.Drawing.Point(87, 37);
            this.btnAnteriorMateria.Name = "btnAnteriorMateria";
            this.btnAnteriorMateria.Size = new System.Drawing.Size(55, 43);
            this.btnAnteriorMateria.TabIndex = 3;
            this.btnAnteriorMateria.Text = "<";
            this.btnAnteriorMateria.UseVisualStyleBackColor = true;
            this.btnAnteriorMateria.Click += new System.EventHandler(this.btnAnteriorMateria_Click);
            // 
            // btnPrimerMateria
            // 
            this.btnPrimerMateria.Location = new System.Drawing.Point(26, 37);
            this.btnPrimerMateria.Name = "btnPrimerMateria";
            this.btnPrimerMateria.Size = new System.Drawing.Size(55, 43);
            this.btnPrimerMateria.TabIndex = 2;
            this.btnPrimerMateria.Text = "|<";
            this.btnPrimerMateria.UseVisualStyleBackColor = true;
            this.btnPrimerMateria.Click += new System.EventHandler(this.btnPrimerMateria_Click);
            // 
            // grbDatosMateria
            // 
            this.grbDatosMateria.Controls.Add(this.lblIDMateria);
            this.grbDatosMateria.Controls.Add(this.txtUvMateria);
            this.grbDatosMateria.Controls.Add(this.lblUvMateria);
            this.grbDatosMateria.Controls.Add(this.txtNombreMateria);
            this.grbDatosMateria.Controls.Add(this.lblNombreMateria);
            this.grbDatosMateria.Controls.Add(this.txtCodigoMateria);
            this.grbDatosMateria.Controls.Add(this.lblCodigoMateria);
            this.grbDatosMateria.Enabled = false;
            this.grbDatosMateria.Location = new System.Drawing.Point(22, 19);
            this.grbDatosMateria.Name = "grbDatosMateria";
            this.grbDatosMateria.Size = new System.Drawing.Size(449, 305);
            this.grbDatosMateria.TabIndex = 4;
            this.grbDatosMateria.TabStop = false;
            this.grbDatosMateria.Text = "Datos";
            // 
            // lblIDMateria
            // 
            this.lblIDMateria.AutoSize = true;
            this.lblIDMateria.Location = new System.Drawing.Point(6, 35);
            this.lblIDMateria.Name = "lblIDMateria";
            this.lblIDMateria.Size = new System.Drawing.Size(25, 20);
            this.lblIDMateria.TabIndex = 8;
            this.lblIDMateria.Text = "id:";
            // 
            // txtUvMateria
            // 
            this.txtUvMateria.Location = new System.Drawing.Point(87, 192);
            this.txtUvMateria.Name = "txtUvMateria";
            this.txtUvMateria.Size = new System.Drawing.Size(252, 26);
            this.txtUvMateria.TabIndex = 4;
            // 
            // lblUvMateria
            // 
            this.lblUvMateria.AutoSize = true;
            this.lblUvMateria.Location = new System.Drawing.Point(6, 192);
            this.lblUvMateria.Name = "lblUvMateria";
            this.lblUvMateria.Size = new System.Drawing.Size(25, 20);
            this.lblUvMateria.TabIndex = 5;
            this.lblUvMateria.Text = "uv";
            // 
            // txtNombreMateria
            // 
            this.txtNombreMateria.Location = new System.Drawing.Point(77, 138);
            this.txtNombreMateria.Name = "txtNombreMateria";
            this.txtNombreMateria.Size = new System.Drawing.Size(252, 26);
            this.txtNombreMateria.TabIndex = 2;
            // 
            // lblNombreMateria
            // 
            this.lblNombreMateria.AutoSize = true;
            this.lblNombreMateria.Location = new System.Drawing.Point(6, 138);
            this.lblNombreMateria.Name = "lblNombreMateria";
            this.lblNombreMateria.Size = new System.Drawing.Size(62, 20);
            this.lblNombreMateria.TabIndex = 3;
            this.lblNombreMateria.Text = "Materia";
            // 
            // txtCodigoMateria
            // 
            this.txtCodigoMateria.Location = new System.Drawing.Point(63, 83);
            this.txtCodigoMateria.Name = "txtCodigoMateria";
            this.txtCodigoMateria.Size = new System.Drawing.Size(252, 26);
            this.txtCodigoMateria.TabIndex = 1;
            // 
            // lblCodigoMateria
            // 
            this.lblCodigoMateria.AutoSize = true;
            this.lblCodigoMateria.Location = new System.Drawing.Point(6, 83);
            this.lblCodigoMateria.Name = "lblCodigoMateria";
            this.lblCodigoMateria.Size = new System.Drawing.Size(56, 20);
            this.lblCodigoMateria.TabIndex = 1;
            this.lblCodigoMateria.Text = "codigo";
            // 
            // frmMaterias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 572);
            this.Controls.Add(this.grbBusquedaMateria);
            this.Controls.Add(this.grbEdicionMateria);
            this.Controls.Add(this.grbNavegacionMateria);
            this.Controls.Add(this.grbDatosMateria);
            this.Name = "frmMaterias";
            this.Text = "frmMaterias";
            this.Load += new System.EventHandler(this.frmMaterias_Load);
            this.grbBusquedaMateria.ResumeLayout(false);
            this.grbBusquedaMateria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMateria)).EndInit();
            this.grbEdicionMateria.ResumeLayout(false);
            this.grbNavegacionMateria.ResumeLayout(false);
            this.grbNavegacionMateria.PerformLayout();
            this.grbDatosMateria.ResumeLayout(false);
            this.grbDatosMateria.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbBusquedaMateria;
        private System.Windows.Forms.DataGridView grdMateria;
        private System.Windows.Forms.TextBox txtBuscarMateria;
        private System.Windows.Forms.GroupBox grbEdicionMateria;
        private System.Windows.Forms.Button btnEliminarMateria;
        private System.Windows.Forms.Button btnModificarMateria;
        private System.Windows.Forms.Button btnNuevoMateria;
        private System.Windows.Forms.GroupBox grbNavegacionMateria;
        private System.Windows.Forms.Label lblCantidadResgisMateria;
        private System.Windows.Forms.Button btnUltimoMateria;
        private System.Windows.Forms.Button btnSiguienteMateria;
        private System.Windows.Forms.Button btnAnteriorMateria;
        private System.Windows.Forms.Button btnPrimerMateria;
        private System.Windows.Forms.GroupBox grbDatosMateria;
        private System.Windows.Forms.Label lblIDMateria;
        private System.Windows.Forms.TextBox txtUvMateria;
        private System.Windows.Forms.Label lblUvMateria;
        private System.Windows.Forms.TextBox txtNombreMateria;
        private System.Windows.Forms.Label lblNombreMateria;
        private System.Windows.Forms.TextBox txtCodigoMateria;
        private System.Windows.Forms.Label lblCodigoMateria;
        private System.Windows.Forms.ComboBox cboBuscarMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn UV;
    }
}