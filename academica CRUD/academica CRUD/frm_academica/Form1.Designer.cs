
namespace Formulario_Academica
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
            this.grbDatos = new System.Windows.Forms.GroupBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.grbNavegación = new System.Windows.Forms.GroupBox();
            this.lblCantidadResgis = new System.Windows.Forms.Label();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnPrimer = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.grbBusqueda = new System.Windows.Forms.GroupBox();
            this.grdEstudiante = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telefono = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.grbDatos.SuspendLayout();
            this.grbNavegación.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grbBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstudiante)).BeginInit();
            this.SuspendLayout();
            // 
            // grbDatos
            // 
            this.grbDatos.Controls.Add(this.lblID);
            this.grbDatos.Controls.Add(this.txtTelefono);
            this.grbDatos.Controls.Add(this.lblTelefono);
            this.grbDatos.Controls.Add(this.txtDireccion);
            this.grbDatos.Controls.Add(this.lblDireccion);
            this.grbDatos.Controls.Add(this.txtNombre);
            this.grbDatos.Controls.Add(this.lblNombre);
            this.grbDatos.Controls.Add(this.txtCodigo);
            this.grbDatos.Controls.Add(this.lblCodigo);
            this.grbDatos.Enabled = false;
            this.grbDatos.Location = new System.Drawing.Point(42, 26);
            this.grbDatos.Name = "grbDatos";
            this.grbDatos.Size = new System.Drawing.Size(449, 305);
            this.grbDatos.TabIndex = 0;
            this.grbDatos.TabStop = false;
            this.grbDatos.Text = "Datos";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(6, 35);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(25, 20);
            this.lblID.TabIndex = 8;
            this.lblID.Text = "id:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(87, 246);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(178, 26);
            this.txtTelefono.TabIndex = 6;
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Location = new System.Drawing.Point(11, 246);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(71, 20);
            this.lblTelefono.TabIndex = 7;
            this.lblTelefono.Text = "Teléfono";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(87, 192);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(228, 26);
            this.txtDireccion.TabIndex = 4;
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Location = new System.Drawing.Point(6, 192);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(75, 20);
            this.lblDireccion.TabIndex = 5;
            this.lblDireccion.Text = "Direccion";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(77, 138);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(253, 26);
            this.txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(6, 138);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(65, 20);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(63, 83);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(216, 26);
            this.txtCodigo.TabIndex = 1;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(6, 83);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(56, 20);
            this.lblCodigo.TabIndex = 1;
            this.lblCodigo.Text = "codigo";
            // 
            // grbNavegación
            // 
            this.grbNavegación.Controls.Add(this.lblCantidadResgis);
            this.grbNavegación.Controls.Add(this.btnUltimo);
            this.grbNavegación.Controls.Add(this.btnSiguiente);
            this.grbNavegación.Controls.Add(this.btnAnterior);
            this.grbNavegación.Controls.Add(this.btnPrimer);
            this.grbNavegación.Location = new System.Drawing.Point(42, 367);
            this.grbNavegación.Name = "grbNavegación";
            this.grbNavegación.Size = new System.Drawing.Size(430, 100);
            this.grbNavegación.TabIndex = 1;
            this.grbNavegación.TabStop = false;
            this.grbNavegación.Text = "Navegación";
            // 
            // lblCantidadResgis
            // 
            this.lblCantidadResgis.AutoSize = true;
            this.lblCantidadResgis.Location = new System.Drawing.Point(167, 48);
            this.lblCantidadResgis.Name = "lblCantidadResgis";
            this.lblCantidadResgis.Size = new System.Drawing.Size(51, 20);
            this.lblCantidadResgis.TabIndex = 3;
            this.lblCantidadResgis.Text = "x de n";
            // 
            // btnUltimo
            // 
            this.btnUltimo.Location = new System.Drawing.Point(316, 31);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(55, 55);
            this.btnUltimo.TabIndex = 5;
            this.btnUltimo.Text = ">|";
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(246, 31);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(55, 55);
            this.btnSiguiente.TabIndex = 4;
            this.btnSiguiente.Text = ">";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Location = new System.Drawing.Point(87, 31);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(55, 55);
            this.btnAnterior.TabIndex = 3;
            this.btnAnterior.Text = "<";
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnPrimer
            // 
            this.btnPrimer.Location = new System.Drawing.Point(16, 31);
            this.btnPrimer.Name = "btnPrimer";
            this.btnPrimer.Size = new System.Drawing.Size(55, 55);
            this.btnPrimer.TabIndex = 2;
            this.btnPrimer.Text = "|<";
            this.btnPrimer.UseVisualStyleBackColor = true;
            this.btnPrimer.Click += new System.EventHandler(this.btnPrimer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEliminar);
            this.groupBox1.Controls.Add(this.btnModificar);
            this.groupBox1.Controls.Add(this.btnNuevo);
            this.groupBox1.Location = new System.Drawing.Point(516, 367);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(502, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Navegación";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(338, 31);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(126, 55);
            this.btnEliminar.TabIndex = 5;
            this.btnEliminar.Text = "Elimi.";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(181, 31);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(126, 55);
            this.btnModificar.TabIndex = 4;
            this.btnModificar.Text = "Modif.";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(19, 31);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(126, 55);
            this.btnNuevo.TabIndex = 3;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // grbBusqueda
            // 
            this.grbBusqueda.Controls.Add(this.grdEstudiante);
            this.grbBusqueda.Controls.Add(this.txtBuscar);
            this.grbBusqueda.Location = new System.Drawing.Point(516, 41);
            this.grbBusqueda.Name = "grbBusqueda";
            this.grbBusqueda.Size = new System.Drawing.Size(678, 290);
            this.grbBusqueda.TabIndex = 3;
            this.grbBusqueda.TabStop = false;
            this.grbBusqueda.Text = "Busqueda";
            // 
            // grdEstudiante
            // 
            this.grdEstudiante.AllowUserToAddRows = false;
            this.grdEstudiante.AllowUserToDeleteRows = false;
            this.grdEstudiante.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEstudiante.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Codigo,
            this.Nombre,
            this.Direccion,
            this.Telefono});
            this.grdEstudiante.Location = new System.Drawing.Point(36, 92);
            this.grdEstudiante.Name = "grdEstudiante";
            this.grdEstudiante.ReadOnly = true;
            this.grdEstudiante.RowHeadersWidth = 62;
            this.grdEstudiante.RowTemplate.Height = 28;
            this.grdEstudiante.Size = new System.Drawing.Size(635, 176);
            this.grdEstudiante.TabIndex = 1;
            this.grdEstudiante.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdEstudiante_CellClick);
            // 
            // ID
            // 
            this.ID.DataPropertyName = "Idestudiante";
            this.ID.HeaderText = "Id";
            this.ID.MinimumWidth = 8;
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            this.ID.Width = 120;
            // 
            // Codigo
            // 
            this.Codigo.DataPropertyName = "código";
            this.Codigo.HeaderText = "código";
            this.Codigo.MinimumWidth = 8;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 120;
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "nombre";
            this.Nombre.HeaderText = "nombre";
            this.Nombre.MinimumWidth = 8;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 120;
            // 
            // Direccion
            // 
            this.Direccion.DataPropertyName = "dirección";
            this.Direccion.HeaderText = "dirección";
            this.Direccion.MinimumWidth = 8;
            this.Direccion.Name = "Direccion";
            this.Direccion.ReadOnly = true;
            this.Direccion.Width = 120;
            // 
            // Telefono
            // 
            this.Telefono.DataPropertyName = "teléfono";
            this.Telefono.HeaderText = "Tel.";
            this.Telefono.MinimumWidth = 8;
            this.Telefono.Name = "Telefono";
            this.Telefono.ReadOnly = true;
            this.Telefono.Width = 120;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(19, 35);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(652, 26);
            this.txtBuscar.TabIndex = 0;
            this.txtBuscar.TextChanged += new System.EventHandler(this.txtBuscar_TextChanged);
            this.txtBuscar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBuscar_KeyUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1256, 574);
            this.Controls.Add(this.grbBusqueda);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbNavegación);
            this.Controls.Add(this.grbDatos);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grbDatos.ResumeLayout(false);
            this.grbDatos.PerformLayout();
            this.grbNavegación.ResumeLayout(false);
            this.grbNavegación.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grbBusqueda.ResumeLayout(false);
            this.grbBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEstudiante)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbDatos;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.GroupBox grbNavegación;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnPrimer;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Label lblCantidadResgis;
        private System.Windows.Forms.GroupBox grbBusqueda;
        private System.Windows.Forms.DataGridView grdEstudiante;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telefono;
    }
}

