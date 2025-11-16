namespace Formulario_Academica
{
    partial class frmPeriodos
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label idPeriodoLabel;
            System.Windows.Forms.Label periodoLabel;
            System.Windows.Forms.Label fechaLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPeriodos));
            this.dB_academicaDataSet = new Formulario_Academica.DB_academicaDataSet();
            this.periodosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.periodosTableAdapter = new Formulario_Academica.DB_academicaDataSetTableAdapters.periodosTableAdapter();
            this.tableAdapterManager = new Formulario_Academica.DB_academicaDataSetTableAdapters.TableAdapterManager();
            this.periodosBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.periodosBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
            this.idPeriodoLabel1 = new System.Windows.Forms.Label();
            this.periodoTextBox = new System.Windows.Forms.TextBox();
            this.fechaDateTimePicker = new System.Windows.Forms.DateTimePicker();
            idPeriodoLabel = new System.Windows.Forms.Label();
            periodoLabel = new System.Windows.Forms.Label();
            fechaLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dB_academicaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodosBindingNavigator)).BeginInit();
            this.periodosBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // idPeriodoLabel
            // 
            idPeriodoLabel.AutoSize = true;
            idPeriodoLabel.Location = new System.Drawing.Point(61, 96);
            idPeriodoLabel.Name = "idPeriodoLabel";
            idPeriodoLabel.Size = new System.Drawing.Size(85, 20);
            idPeriodoLabel.TabIndex = 1;
            idPeriodoLabel.Text = "Id Periodo:";
            // 
            // periodoLabel
            // 
            periodoLabel.AutoSize = true;
            periodoLabel.Location = new System.Drawing.Point(61, 125);
            periodoLabel.Name = "periodoLabel";
            periodoLabel.Size = new System.Drawing.Size(66, 20);
            periodoLabel.TabIndex = 3;
            periodoLabel.Text = "periodo:";
            // 
            // fechaLabel
            // 
            fechaLabel.AutoSize = true;
            fechaLabel.Location = new System.Drawing.Point(61, 158);
            fechaLabel.Name = "fechaLabel";
            fechaLabel.Size = new System.Drawing.Size(53, 20);
            fechaLabel.TabIndex = 5;
            fechaLabel.Text = "fecha:";
            // 
            // dB_academicaDataSet
            // 
            this.dB_academicaDataSet.DataSetName = "DB_academicaDataSet";
            this.dB_academicaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // periodosBindingSource
            // 
            this.periodosBindingSource.DataMember = "periodos";
            this.periodosBindingSource.DataSource = this.dB_academicaDataSet;
            // 
            // periodosTableAdapter
            // 
            this.periodosTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.estudianteTableAdapter = null;
            this.tableAdapterManager.materiasTableAdapter = null;
            this.tableAdapterManager.periodosTableAdapter = this.periodosTableAdapter;
            this.tableAdapterManager.UpdateOrder = Formulario_Academica.DB_academicaDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // periodosBindingNavigator
            // 
            this.periodosBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
            this.periodosBindingNavigator.BindingSource = this.periodosBindingSource;
            this.periodosBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.periodosBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
            this.periodosBindingNavigator.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.periodosBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.periodosBindingNavigatorSaveItem});
            this.periodosBindingNavigator.Location = new System.Drawing.Point(0, 0);
            this.periodosBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.periodosBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.periodosBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.periodosBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.periodosBindingNavigator.Name = "periodosBindingNavigator";
            this.periodosBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.periodosBindingNavigator.Size = new System.Drawing.Size(503, 38);
            this.periodosBindingNavigator.TabIndex = 0;
            this.periodosBindingNavigator.Text = "bindingNavigator1";
            // 
            // bindingNavigatorAddNewItem
            // 
            this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
            this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorAddNewItem.Text = "Agregar nuevo";
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(57, 33);
            this.bindingNavigatorCountItem.Text = "de {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Número total de elementos";
            // 
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorDeleteItem.Text = "Eliminar";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveFirstItem.Text = "Mover primero";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMovePreviousItem.Text = "Mover anterior";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Posición";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 31);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Posición actual";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveNextItem.Text = "Mover siguiente";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(34, 33);
            this.bindingNavigatorMoveLastItem.Text = "Mover último";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 38);
            // 
            // periodosBindingNavigatorSaveItem
            // 
            this.periodosBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.periodosBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("periodosBindingNavigatorSaveItem.Image")));
            this.periodosBindingNavigatorSaveItem.Name = "periodosBindingNavigatorSaveItem";
            this.periodosBindingNavigatorSaveItem.Size = new System.Drawing.Size(34, 33);
            this.periodosBindingNavigatorSaveItem.Text = "Guardar datos";
            this.periodosBindingNavigatorSaveItem.Click += new System.EventHandler(this.periodosBindingNavigatorSaveItem_Click);
            // 
            // idPeriodoLabel1
            // 
            this.idPeriodoLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.periodosBindingSource, "IdPeriodo", true));
            this.idPeriodoLabel1.Location = new System.Drawing.Point(152, 96);
            this.idPeriodoLabel1.Name = "idPeriodoLabel1";
            this.idPeriodoLabel1.Size = new System.Drawing.Size(203, 23);
            this.idPeriodoLabel1.TabIndex = 2;
            this.idPeriodoLabel1.Text = "label1";
            // 
            // periodoTextBox
            // 
            this.periodoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.periodosBindingSource, "periodo", true));
            this.periodoTextBox.Location = new System.Drawing.Point(152, 122);
            this.periodoTextBox.Name = "periodoTextBox";
            this.periodoTextBox.Size = new System.Drawing.Size(203, 26);
            this.periodoTextBox.TabIndex = 4;
            // 
            // fechaDateTimePicker
            // 
            this.fechaDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.periodosBindingSource, "fecha", true));
            this.fechaDateTimePicker.Location = new System.Drawing.Point(152, 154);
            this.fechaDateTimePicker.Name = "fechaDateTimePicker";
            this.fechaDateTimePicker.Size = new System.Drawing.Size(203, 26);
            this.fechaDateTimePicker.TabIndex = 6;
            // 
            // frmPeriodos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(503, 347);
            this.Controls.Add(idPeriodoLabel);
            this.Controls.Add(this.idPeriodoLabel1);
            this.Controls.Add(periodoLabel);
            this.Controls.Add(this.periodoTextBox);
            this.Controls.Add(fechaLabel);
            this.Controls.Add(this.fechaDateTimePicker);
            this.Controls.Add(this.periodosBindingNavigator);
            this.Name = "frmPeriodos";
            this.Text = "frmPeriodos";
            this.Load += new System.EventHandler(this.frmPeriodos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dB_academicaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.periodosBindingNavigator)).EndInit();
            this.periodosBindingNavigator.ResumeLayout(false);
            this.periodosBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DB_academicaDataSet dB_academicaDataSet;
        private System.Windows.Forms.BindingSource periodosBindingSource;
        private DB_academicaDataSetTableAdapters.periodosTableAdapter periodosTableAdapter;
        private DB_academicaDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator periodosBindingNavigator;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton periodosBindingNavigatorSaveItem;
        private System.Windows.Forms.Label idPeriodoLabel1;
        private System.Windows.Forms.TextBox periodoTextBox;
        private System.Windows.Forms.DateTimePicker fechaDateTimePicker;
    }
}