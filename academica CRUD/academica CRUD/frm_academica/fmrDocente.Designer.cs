namespace WindowsFormsApp1
{
    partial class fmrDocente
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
            this.grbDatosDocente = new System.Windows.Forms.GroupBox();
            this.lblIdDocente = new System.Windows.Forms.Label();
            this.txtTelefonoDocente = new System.Windows.Forms.TextBox();
            this.lblTelefonoDocente = new System.Windows.Forms.Label();
            this.txtDireccionDocente = new System.Windows.Forms.TextBox();
            this.lblDireccionDocente = new System.Windows.Forms.Label();
            this.txtNombreDocente = new System.Windows.Forms.TextBox();
            this.lblNombreDocente = new System.Windows.Forms.Label();
            this.txtCodigoDocente = new System.Windows.Forms.TextBox();
            this.lblCodigoDocente = new System.Windows.Forms.Label();
            this.grbNavegación = new System.Windows.Forms.GroupBox();
            this.lblCantRegDocente = new System.Windows.Forms.Label();
            this.btnUltimoDocente = new System.Windows.Forms.Button();
            this.btnSiguienteDocente = new System.Windows.Forms.Button();
            this.btnAnteriorDocente = new System.Windows.Forms.Button();
            this.btnPrimerDocente = new System.Windows.Forms.Button();
            this.grbnavegacionDocente = new System.Windows.Forms.GroupBox();
            this.btnEliminarDocente = new System.Windows.Forms.Button();
            this.btnModificarDocente = new System.Windows.Forms.Button();
            this.btnNuevoDocente = new System.Windows.Forms.Button();
            this.grbBusquedaDocente = new System.Windows.Forms.GroupBox();
            this.grdDocente = new System.Windows.Forms.DataGridView();
            this.txtBuscarDocente = new System.Windows.Forms.TextBox();
            this.IdDocente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbDatosDocente.SuspendLayout();
            this.grbNavegación.SuspendLayout();
            this.grbnavegacionDocente.SuspendLayout();
            this.grbBusquedaDocente.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocente)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDatosDocente
            // 
            this.grbDatosDocente.Controls.Add(this.lblIdDocente);
            this.grbDatosDocente.Controls.Add(this.txtTelefonoDocente);
            this.grbDatosDocente.Controls.Add(this.lblTelefonoDocente);
            this.grbDatosDocente.Controls.Add(this.txtDireccionDocente);
            this.grbDatosDocente.Controls.Add(this.lblDireccionDocente);
            this.grbDatosDocente.Controls.Add(this.txtNombreDocente);
            this.grbDatosDocente.Controls.Add(this.lblNombreDocente);
            this.grbDatosDocente.Controls.Add(this.txtCodigoDocente);
            this.grbDatosDocente.Controls.Add(this.lblCodigoDocente);
            this.grbDatosDocente.Enabled = false;
            this.grbDatosDocente.Location = new System.Drawing.Point(27, 22);
            this.grbDatosDocente.Name = "grbDatosDocente";
            this.grbDatosDocente.Size = new System.Drawing.Size(437, 310);
            this.grbDatosDocente.TabIndex = 1;
            this.grbDatosDocente.TabStop = false;
            this.grbDatosDocente.Text = "Datos";
            // 
            // lblIdDocente
            // 
            this.lblIdDocente.AutoSize = true;
            this.lblIdDocente.Location = new System.Drawing.Point(6, 35);
            this.lblIdDocente.Name = "lblIdDocente";
            this.lblIdDocente.Size = new System.Drawing.Size(25, 20);
            this.lblIdDocente.TabIndex = 8;
            this.lblIdDocente.Text = "id:";
            // 
            // txtTelefonoDocente
            // 
            this.txtTelefonoDocente.Location = new System.Drawing.Point(87, 246);
            this.txtTelefonoDocente.Name = "txtTelefonoDocente";
            this.txtTelefonoDocente.Size = new System.Drawing.Size(178, 26);
            this.txtTelefonoDocente.TabIndex = 6;
            // 
            // lblTelefonoDocente
            // 
            this.lblTelefonoDocente.AutoSize = true;
            this.lblTelefonoDocente.Location = new System.Drawing.Point(11, 246);
            this.lblTelefonoDocente.Name = "lblTelefonoDocente";
            this.lblTelefonoDocente.Size = new System.Drawing.Size(71, 20);
            this.lblTelefonoDocente.TabIndex = 7;
            this.lblTelefonoDocente.Text = "Teléfono";
            // 
            // txtDireccionDocente
            // 
            this.txtDireccionDocente.Location = new System.Drawing.Point(87, 192);
            this.txtDireccionDocente.Name = "txtDireccionDocente";
            this.txtDireccionDocente.Size = new System.Drawing.Size(228, 26);
            this.txtDireccionDocente.TabIndex = 4;
            // 
            // lblDireccionDocente
            // 
            this.lblDireccionDocente.AutoSize = true;
            this.lblDireccionDocente.Location = new System.Drawing.Point(6, 192);
            this.lblDireccionDocente.Name = "lblDireccionDocente";
            this.lblDireccionDocente.Size = new System.Drawing.Size(75, 20);
            this.lblDireccionDocente.TabIndex = 5;
            this.lblDireccionDocente.Text = "Direccion";
            // 
            // txtNombreDocente
            // 
            this.txtNombreDocente.Location = new System.Drawing.Point(77, 138);
            this.txtNombreDocente.Name = "txtNombreDocente";
            this.txtNombreDocente.Size = new System.Drawing.Size(253, 26);
            this.txtNombreDocente.TabIndex = 2;
            // 
            // lblNombreDocente
            // 
            this.lblNombreDocente.AutoSize = true;
            this.lblNombreDocente.Location = new System.Drawing.Point(6, 138);
            this.lblNombreDocente.Name = "lblNombreDocente";
            this.lblNombreDocente.Size = new System.Drawing.Size(70, 20);
            this.lblNombreDocente.TabIndex = 3;
            this.lblNombreDocente.Text = "Docente";
            // 
            // txtCodigoDocente
            // 
            this.txtCodigoDocente.Location = new System.Drawing.Point(63, 83);
            this.txtCodigoDocente.Name = "txtCodigoDocente";
            this.txtCodigoDocente.Size = new System.Drawing.Size(216, 26);
            this.txtCodigoDocente.TabIndex = 1;
            // 
            // lblCodigoDocente
            // 
            this.lblCodigoDocente.AutoSize = true;
            this.lblCodigoDocente.Location = new System.Drawing.Point(6, 83);
            this.lblCodigoDocente.Name = "lblCodigoDocente";
            this.lblCodigoDocente.Size = new System.Drawing.Size(56, 20);
            this.lblCodigoDocente.TabIndex = 1;
            this.lblCodigoDocente.Text = "codigo";
            // 
            // grbNavegación
            // 
            this.grbNavegación.Controls.Add(this.lblCantRegDocente);
            this.grbNavegación.Controls.Add(this.btnUltimoDocente);
            this.grbNavegación.Controls.Add(this.btnSiguienteDocente);
            this.grbNavegación.Controls.Add(this.btnAnteriorDocente);
            this.grbNavegación.Controls.Add(this.btnPrimerDocente);
            this.grbNavegación.Location = new System.Drawing.Point(27, 374);
            this.grbNavegación.Name = "grbNavegación";
            this.grbNavegación.Size = new System.Drawing.Size(430, 100);
            this.grbNavegación.TabIndex = 9;
            this.grbNavegación.TabStop = false;
            this.grbNavegación.Text = "Navegación";
            // 
            // lblCantRegDocente
            // 
            this.lblCantRegDocente.AutoSize = true;
            this.lblCantRegDocente.Location = new System.Drawing.Point(167, 48);
            this.lblCantRegDocente.Name = "lblCantRegDocente";
            this.lblCantRegDocente.Size = new System.Drawing.Size(51, 20);
            this.lblCantRegDocente.TabIndex = 3;
            this.lblCantRegDocente.Text = "x de n";
            // 
            // btnUltimoDocente
            // 
            this.btnUltimoDocente.Location = new System.Drawing.Point(316, 31);
            this.btnUltimoDocente.Name = "btnUltimoDocente";
            this.btnUltimoDocente.Size = new System.Drawing.Size(55, 55);
            this.btnUltimoDocente.TabIndex = 5;
            this.btnUltimoDocente.Text = ">|";
            this.btnUltimoDocente.UseVisualStyleBackColor = true;
            this.btnUltimoDocente.Click += new System.EventHandler(this.btnUltimoDocente_Click);
            // 
            // btnSiguienteDocente
            // 
            this.btnSiguienteDocente.Location = new System.Drawing.Point(246, 31);
            this.btnSiguienteDocente.Name = "btnSiguienteDocente";
            this.btnSiguienteDocente.Size = new System.Drawing.Size(55, 55);
            this.btnSiguienteDocente.TabIndex = 4;
            this.btnSiguienteDocente.Text = ">";
            this.btnSiguienteDocente.UseVisualStyleBackColor = true;
            this.btnSiguienteDocente.Click += new System.EventHandler(this.btnSiguienteDocente_Click);
            // 
            // btnAnteriorDocente
            // 
            this.btnAnteriorDocente.Location = new System.Drawing.Point(87, 31);
            this.btnAnteriorDocente.Name = "btnAnteriorDocente";
            this.btnAnteriorDocente.Size = new System.Drawing.Size(55, 55);
            this.btnAnteriorDocente.TabIndex = 3;
            this.btnAnteriorDocente.Text = "<";
            this.btnAnteriorDocente.UseVisualStyleBackColor = true;
            this.btnAnteriorDocente.Click += new System.EventHandler(this.btnAnteriorDocente_Click);
            // 
            // btnPrimerDocente
            // 
            this.btnPrimerDocente.Location = new System.Drawing.Point(16, 31);
            this.btnPrimerDocente.Name = "btnPrimerDocente";
            this.btnPrimerDocente.Size = new System.Drawing.Size(55, 55);
            this.btnPrimerDocente.TabIndex = 2;
            this.btnPrimerDocente.Text = "|<";
            this.btnPrimerDocente.UseVisualStyleBackColor = true;
            this.btnPrimerDocente.Click += new System.EventHandler(this.btnPrimerDocente_Click);
            // 
            // grbnavegacionDocente
            // 
            this.grbnavegacionDocente.Controls.Add(this.btnEliminarDocente);
            this.grbnavegacionDocente.Controls.Add(this.btnModificarDocente);
            this.grbnavegacionDocente.Controls.Add(this.btnNuevoDocente);
            this.grbnavegacionDocente.Location = new System.Drawing.Point(499, 374);
            this.grbnavegacionDocente.Name = "grbnavegacionDocente";
            this.grbnavegacionDocente.Size = new System.Drawing.Size(502, 100);
            this.grbnavegacionDocente.TabIndex = 6;
            this.grbnavegacionDocente.TabStop = false;
            this.grbnavegacionDocente.Text = "Navegación";
            // 
            // btnEliminarDocente
            // 
            this.btnEliminarDocente.Location = new System.Drawing.Point(338, 31);
            this.btnEliminarDocente.Name = "btnEliminarDocente";
            this.btnEliminarDocente.Size = new System.Drawing.Size(126, 55);
            this.btnEliminarDocente.TabIndex = 5;
            this.btnEliminarDocente.Text = "Elimi.";
            this.btnEliminarDocente.UseVisualStyleBackColor = true;
            this.btnEliminarDocente.Click += new System.EventHandler(this.btnEliminarDocente_Click);
            // 
            // btnModificarDocente
            // 
            this.btnModificarDocente.Location = new System.Drawing.Point(181, 31);
            this.btnModificarDocente.Name = "btnModificarDocente";
            this.btnModificarDocente.Size = new System.Drawing.Size(126, 55);
            this.btnModificarDocente.TabIndex = 4;
            this.btnModificarDocente.Text = "Modif.";
            this.btnModificarDocente.UseVisualStyleBackColor = true;
            this.btnModificarDocente.Click += new System.EventHandler(this.btnModificarDocente_Click);
            // 
            // btnNuevoDocente
            // 
            this.btnNuevoDocente.Location = new System.Drawing.Point(19, 31);
            this.btnNuevoDocente.Name = "btnNuevoDocente";
            this.btnNuevoDocente.Size = new System.Drawing.Size(126, 55);
            this.btnNuevoDocente.TabIndex = 3;
            this.btnNuevoDocente.Text = "Nuevo";
            this.btnNuevoDocente.UseVisualStyleBackColor = true;
            this.btnNuevoDocente.Click += new System.EventHandler(this.btnNuevoDocente_Click);
            // 
            // grbBusquedaDocente
            // 
            this.grbBusquedaDocente.Controls.Add(this.grdDocente);
            this.grbBusquedaDocente.Controls.Add(this.txtBuscarDocente);
            this.grbBusquedaDocente.Location = new System.Drawing.Point(499, 42);
            this.grbBusquedaDocente.Name = "grbBusquedaDocente";
            this.grbBusquedaDocente.Size = new System.Drawing.Size(678, 290);
            this.grbBusquedaDocente.TabIndex = 10;
            this.grbBusquedaDocente.TabStop = false;
            this.grbBusquedaDocente.Text = "Busqueda";
            // 
            // grdDocente
            // 
            this.grdDocente.AllowUserToAddRows = false;
            this.grdDocente.AllowUserToDeleteRows = false;
            this.grdDocente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDocente.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdDocente,
            this.Codigo,
            this.Nombre,
            this.Direccion,
            this.Telefono});
            this.grdDocente.Location = new System.Drawing.Point(36, 92);
            this.grdDocente.Name = "grdDocente";
            this.grdDocente.ReadOnly = true;
            this.grdDocente.RowHeadersWidth = 62;
            this.grdDocente.RowTemplate.Height = 28;
            this.grdDocente.Size = new System.Drawing.Size(635, 176);
            this.grdDocente.TabIndex = 1;
            this.grdDocente.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdDocente_CellClick);
            // 
            // txtBuscarDocente
            // 
            this.txtBuscarDocente.Location = new System.Drawing.Point(19, 35);
            this.txtBuscarDocente.Name = "txtBuscarDocente";
            this.txtBuscarDocente.Size = new System.Drawing.Size(652, 26);
            this.txtBuscarDocente.TabIndex = 0;
            this.txtBuscarDocente.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscarDocente_KeyUp);
            // 
            // IdDocente
            // 
            this.IdDocente.DataPropertyName = "IdDocente";
            this.IdDocente.HeaderText = "Id";
            this.IdDocente.MinimumWidth = 8;
            this.IdDocente.Name = "IdDocente";
            this.IdDocente.ReadOnly = true;
            this.IdDocente.Visible = false;
            this.IdDocente.Width = 120;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "codigo";
            this.Codigo.HeaderText = "código";
            this.Codigo.MinimumWidth = 8;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 120;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "IdDocente";
            this.Nombre.HeaderText = "docente";
            this.Nombre.MinimumWidth = 8;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 120;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "direccion";
            this.Direccion.HeaderText = "dirección";
            this.Direccion.MinimumWidth = 8;
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 120;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "telefono";
            this.Telefono.HeaderText = "Tel.";
            this.Telefono.MinimumWidth = 8;
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 120;
            // 
            // fmrDocente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 588);
            this.Controls.Add(this.grbBusquedaDocente);
            this.Controls.Add(this.grbnavegacionDocente);
            this.Controls.Add(this.grbNavegación);
            this.Controls.Add(this.grbDatosDocente);
            this.Name = "fmrDocente";
            this.Text = "fmrDocente";
            this.Load += new System.EventHandler(this.fmrDocente_Load);
            this.grbDatosDocente.ResumeLayout(false);
            this.grbDatosDocente.PerformLayout();
            this.grbNavegación.ResumeLayout(false);
            this.grbNavegación.PerformLayout();
            this.grbnavegacionDocente.ResumeLayout(false);
            this.grbBusquedaDocente.ResumeLayout(false);
            this.grbBusquedaDocente.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDocente)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDatosDocente;
        private System.Windows.Forms.Label lblIdDocente;
        private System.Windows.Forms.TextBox txtTelefonoDocente;
        private System.Windows.Forms.Label lblTelefonoDocente;
        private System.Windows.Forms.TextBox txtDireccionDocente;
        private System.Windows.Forms.Label lblDireccionDocente;
        private System.Windows.Forms.TextBox txtNombreDocente;
        private System.Windows.Forms.Label lblNombreDocente;
        private System.Windows.Forms.TextBox txtCodigoDocente;
        private System.Windows.Forms.Label lblCodigoDocente;
        private System.Windows.Forms.GroupBox grbNavegación;
        private System.Windows.Forms.Label lblCantRegDocente;
        private System.Windows.Forms.Button btnUltimoDocente;
        private System.Windows.Forms.Button btnSiguienteDocente;
        private System.Windows.Forms.Button btnAnteriorDocente;
        private System.Windows.Forms.Button btnPrimerDocente;
        private System.Windows.Forms.GroupBox grbnavegacionDocente;
        private System.Windows.Forms.Button btnEliminarDocente;
        private System.Windows.Forms.Button btnModificarDocente;
        private System.Windows.Forms.Button btnNuevoDocente;
        private System.Windows.Forms.GroupBox grbBusquedaDocente;
        private System.Windows.Forms.DataGridView grdDocente;
        private System.Windows.Forms.TextBox txtBuscarDocente;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdDocente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
    }
}