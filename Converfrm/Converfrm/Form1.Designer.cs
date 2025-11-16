namespace Converfrm
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
            this.lblTipo = new System.Windows.Forms.Label();
            this.lblDe = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.lblRespuesta = new System.Windows.Forms.Label();
            this.cboTipo = new System.Windows.Forms.ComboBox();
            this.cboA = new System.Windows.Forms.ComboBox();
            this.cboDe = new System.Windows.Forms.ComboBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.btnConvertir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTipo
            // 
            this.lblTipo.AutoSize = true;
            this.lblTipo.Location = new System.Drawing.Point(78, 49);
            this.lblTipo.Name = "lblTipo";
            this.lblTipo.Size = new System.Drawing.Size(43, 20);
            this.lblTipo.TabIndex = 0;
            this.lblTipo.Text = "Tipo:";
            // 
            // lblDe
            // 
            this.lblDe.AutoSize = true;
            this.lblDe.Location = new System.Drawing.Point(78, 111);
            this.lblDe.Name = "lblDe";
            this.lblDe.Size = new System.Drawing.Size(31, 20);
            this.lblDe.TabIndex = 1;
            this.lblDe.Text = "de:";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(78, 194);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(22, 20);
            this.lblA.TabIndex = 2;
            this.lblA.Text = "a:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(78, 275);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(74, 20);
            this.lblCantidad.TabIndex = 3;
            this.lblCantidad.Text = "cantidad:";
            // 
            // lblRespuesta
            // 
            this.lblRespuesta.AutoSize = true;
            this.lblRespuesta.Location = new System.Drawing.Point(78, 350);
            this.lblRespuesta.Name = "lblRespuesta";
            this.lblRespuesta.Size = new System.Drawing.Size(80, 20);
            this.lblRespuesta.TabIndex = 4;
            this.lblRespuesta.Text = "respuesta";
            // 
            // cboTipo
            // 
            this.cboTipo.FormattingEnabled = true;
            this.cboTipo.Items.AddRange(new object[] {
            "Monedas",
            "Longitud",
            "Masa",
            "Volumen",
            "Almacenamiento",
            "Tiempo",
            "Area"});
            this.cboTipo.Location = new System.Drawing.Point(175, 49);
            this.cboTipo.Name = "cboTipo";
            this.cboTipo.Size = new System.Drawing.Size(167, 28);
            this.cboTipo.TabIndex = 5;
            this.cboTipo.SelectedIndexChanged += new System.EventHandler(this.cboTipo_SelectedIndexChanged);
            // 
            // cboA
            // 
            this.cboA.FormattingEnabled = true;
            this.cboA.Location = new System.Drawing.Point(155, 186);
            this.cboA.Name = "cboA";
            this.cboA.Size = new System.Drawing.Size(167, 28);
            this.cboA.TabIndex = 6;
            // 
            // cboDe
            // 
            this.cboDe.FormattingEnabled = true;
            this.cboDe.Location = new System.Drawing.Point(155, 111);
            this.cboDe.Name = "cboDe";
            this.cboDe.Size = new System.Drawing.Size(167, 28);
            this.cboDe.TabIndex = 7;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(155, 275);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(138, 26);
            this.txtCantidad.TabIndex = 8;
            // 
            // btnConvertir
            // 
            this.btnConvertir.Location = new System.Drawing.Point(248, 350);
            this.btnConvertir.Name = "btnConvertir";
            this.btnConvertir.Size = new System.Drawing.Size(154, 54);
            this.btnConvertir.TabIndex = 9;
            this.btnConvertir.Text = "Convertir";
            this.btnConvertir.UseVisualStyleBackColor = true;
            this.btnConvertir.Click += new System.EventHandler(this.btnConvertir_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 486);
            this.Controls.Add(this.btnConvertir);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.cboDe);
            this.Controls.Add(this.cboA);
            this.Controls.Add(this.cboTipo);
            this.Controls.Add(this.lblRespuesta);
            this.Controls.Add(this.lblCantidad);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.lblDe);
            this.Controls.Add(this.lblTipo);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTipo;
        private System.Windows.Forms.Label lblDe;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.Label lblRespuesta;
        private System.Windows.Forms.ComboBox cboTipo;
        private System.Windows.Forms.ComboBox cboA;
        private System.Windows.Forms.ComboBox cboDe;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnConvertir;
    }
}

