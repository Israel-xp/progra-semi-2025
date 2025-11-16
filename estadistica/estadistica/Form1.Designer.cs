
namespace estadistica
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
            this.lblSerie = new System.Windows.Forms.Label();
            this.lblMedia = new System.Windows.Forms.Label();
            this.lblTipica = new System.Windows.Forms.Label();
            this.lblArmonica = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtSerie = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSerie
            // 
            this.lblSerie.AutoSize = true;
            this.lblSerie.Location = new System.Drawing.Point(79, 47);
            this.lblSerie.Name = "lblSerie";
            this.lblSerie.Size = new System.Drawing.Size(32, 13);
            this.lblSerie.TabIndex = 0;
            this.lblSerie.Text = "serie:";
            // 
            // lblMedia
            // 
            this.lblMedia.AutoSize = true;
            this.lblMedia.Location = new System.Drawing.Point(79, 82);
            this.lblMedia.Name = "lblMedia";
            this.lblMedia.Size = new System.Drawing.Size(41, 13);
            this.lblMedia.TabIndex = 1;
            this.lblMedia.Text = "media :";
            // 
            // lblTipica
            // 
            this.lblTipica.AutoSize = true;
            this.lblTipica.Location = new System.Drawing.Point(79, 122);
            this.lblTipica.Name = "lblTipica";
            this.lblTipica.Size = new System.Drawing.Size(41, 13);
            this.lblTipica.TabIndex = 2;
            this.lblTipica.Text = "tipica : ";
            // 
            // lblArmonica
            // 
            this.lblArmonica.AutoSize = true;
            this.lblArmonica.Location = new System.Drawing.Point(79, 159);
            this.lblArmonica.Name = "lblArmonica";
            this.lblArmonica.Size = new System.Drawing.Size(59, 13);
            this.lblArmonica.TabIndex = 3;
            this.lblArmonica.Text = "armonica : ";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(186, 202);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(75, 52);
            this.btnCalcular.TabIndex = 4;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtSerie
            // 
            this.txtSerie.Location = new System.Drawing.Point(132, 47);
            this.txtSerie.Name = "txtSerie";
            this.txtSerie.Size = new System.Drawing.Size(184, 20);
            this.txtSerie.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 317);
            this.Controls.Add(this.txtSerie);
            this.Controls.Add(this.btnCalcular);
            this.Controls.Add(this.lblArmonica);
            this.Controls.Add(this.lblTipica);
            this.Controls.Add(this.lblMedia);
            this.Controls.Add(this.lblSerie);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSerie;
        private System.Windows.Forms.Label lblMedia;
        private System.Windows.Forms.Label lblTipica;
        private System.Windows.Forms.Label lblArmonica;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.TextBox txtSerie;
    }
}

