namespace Presentacion
{
    partial class frm_orden_compra
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_estado = new System.Windows.Forms.Label();
            this.cbo_proveedor = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label18 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lbl_id_orden_compra = new System.Windows.Forms.Label();
            this.cbo_moneda = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.dtp_entrega = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_emision = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbo_almacen = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label5 = new System.Windows.Forms.Label();
            this.cbo_centro_costo = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_empresa = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label1 = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_comentario = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lbl_total_orden = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_proveedor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_moneda.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_almacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_centro_costo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_empresa.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbl_estado);
            this.panel1.Controls.Add(this.cbo_proveedor);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Controls.Add(this.lbl_id_orden_compra);
            this.panel1.Controls.Add(this.cbo_moneda);
            this.panel1.Controls.Add(this.dtp_entrega);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dtp_emision);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbo_almacen);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cbo_centro_costo);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbo_empresa);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(632, 133);
            this.panel1.TabIndex = 21;
            // 
            // lbl_estado
            // 
            this.lbl_estado.BackColor = System.Drawing.Color.LightGray;
            this.lbl_estado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_estado.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lbl_estado.Location = new System.Drawing.Point(519, 111);
            this.lbl_estado.Name = "lbl_estado";
            this.lbl_estado.Size = new System.Drawing.Size(108, 18);
            this.lbl_estado.TabIndex = 43;
            // 
            // cbo_proveedor
            // 
            this.cbo_proveedor.Location = new System.Drawing.Point(79, 110);
            this.cbo_proveedor.Name = "cbo_proveedor";
            this.cbo_proveedor.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_proveedor.Properties.View = this.gridView4;
            this.cbo_proveedor.Size = new System.Drawing.Size(327, 20);
            this.cbo_proveedor.TabIndex = 4;
            // 
            // gridView4
            // 
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.LightGray;
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label18.Location = new System.Drawing.Point(421, 111);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(92, 18);
            this.label18.TabIndex = 42;
            this.label18.Text = "Estado           ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label3.Location = new System.Drawing.Point(5, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 18);
            this.label3.TabIndex = 21;
            this.label3.Text = "Proveedor ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightGray;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label6.Location = new System.Drawing.Point(421, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 18);
            this.label6.TabIndex = 26;
            this.label6.Text = "Moneda         ";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16.25F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(519, -6);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 27);
            this.labelControl1.TabIndex = 32;
            this.labelControl1.Text = "Titulo";
            // 
            // lbl_id_orden_compra
            // 
            this.lbl_id_orden_compra.BackColor = System.Drawing.Color.LightGray;
            this.lbl_id_orden_compra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_id_orden_compra.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lbl_id_orden_compra.Location = new System.Drawing.Point(80, 6);
            this.lbl_id_orden_compra.Name = "lbl_id_orden_compra";
            this.lbl_id_orden_compra.Size = new System.Drawing.Size(87, 18);
            this.lbl_id_orden_compra.TabIndex = 33;
            // 
            // cbo_moneda
            // 
            this.cbo_moneda.Location = new System.Drawing.Point(519, 83);
            this.cbo_moneda.Name = "cbo_moneda";
            this.cbo_moneda.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_moneda.Properties.View = this.gridView5;
            this.cbo_moneda.Size = new System.Drawing.Size(108, 20);
            this.cbo_moneda.TabIndex = 7;
            // 
            // gridView5
            // 
            this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView5.Name = "gridView5";
            this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView5.OptionsView.ShowGroupPanel = false;
            // 
            // dtp_entrega
            // 
            this.dtp_entrega.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_entrega.Location = new System.Drawing.Point(519, 57);
            this.dtp_entrega.Name = "dtp_entrega";
            this.dtp_entrega.Size = new System.Drawing.Size(108, 21);
            this.dtp_entrega.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightGray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label9.Location = new System.Drawing.Point(421, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 18);
            this.label9.TabIndex = 29;
            this.label9.Text = "Fecha Entrega";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label7.Location = new System.Drawing.Point(421, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 18);
            this.label7.TabIndex = 27;
            this.label7.Text = "Fecha Emisión";
            // 
            // dtp_emision
            // 
            this.dtp_emision.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_emision.Location = new System.Drawing.Point(519, 30);
            this.dtp_emision.Name = "dtp_emision";
            this.dtp_emision.Size = new System.Drawing.Size(108, 21);
            this.dtp_emision.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label4.Location = new System.Drawing.Point(5, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 22;
            this.label4.Text = "Almacen   ";
            // 
            // cbo_almacen
            // 
            this.cbo_almacen.Location = new System.Drawing.Point(79, 81);
            this.cbo_almacen.Name = "cbo_almacen";
            this.cbo_almacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_almacen.Properties.View = this.gridView3;
            this.cbo_almacen.Size = new System.Drawing.Size(327, 20);
            this.cbo_almacen.TabIndex = 3;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LightGray;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label5.Location = new System.Drawing.Point(5, 6);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 18);
            this.label5.TabIndex = 25;
            this.label5.Text = "Orden: ";
            // 
            // cbo_centro_costo
            // 
            this.cbo_centro_costo.Location = new System.Drawing.Point(79, 54);
            this.cbo_centro_costo.Name = "cbo_centro_costo";
            this.cbo_centro_costo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_centro_costo.Properties.View = this.gridView2;
            this.cbo_centro_costo.Size = new System.Drawing.Size(327, 20);
            this.cbo_centro_costo.TabIndex = 2;
            // 
            // gridView2
            // 
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label2.Location = new System.Drawing.Point(5, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "C. Costo   ";
            // 
            // cbo_empresa
            // 
            this.cbo_empresa.Location = new System.Drawing.Point(79, 29);
            this.cbo_empresa.Name = "cbo_empresa";
            this.cbo_empresa.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_empresa.Properties.View = this.gridLookUpEdit1View;
            this.cbo_empresa.Size = new System.Drawing.Size(189, 20);
            this.cbo_empresa.TabIndex = 1;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Empresa   ";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(1, 137);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(632, 375);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label8.Location = new System.Drawing.Point(1, 522);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 18);
            this.label8.TabIndex = 28;
            this.label8.Text = "Comentario    ";
            // 
            // txt_comentario
            // 
            this.txt_comentario.BackColor = System.Drawing.Color.LemonChiffon;
            this.txt_comentario.Location = new System.Drawing.Point(81, 521);
            this.txt_comentario.Multiline = true;
            this.txt_comentario.Name = "txt_comentario";
            this.txt_comentario.Size = new System.Drawing.Size(374, 44);
            this.txt_comentario.TabIndex = 9;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.LightGray;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label14.Location = new System.Drawing.Point(461, 522);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 18);
            this.label14.TabIndex = 37;
            this.label14.Text = "Total";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_total_orden
            // 
            this.lbl_total_orden.BackColor = System.Drawing.Color.LightGray;
            this.lbl_total_orden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_total_orden.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lbl_total_orden.Location = new System.Drawing.Point(533, 521);
            this.lbl_total_orden.Name = "lbl_total_orden";
            this.lbl_total_orden.Size = new System.Drawing.Size(88, 18);
            this.lbl_total_orden.TabIndex = 41;
            this.lbl_total_orden.Text = "0";
            this.lbl_total_orden.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frm_orden_compra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 570);
            this.Controls.Add(this.lbl_total_orden);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_comentario);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.label8);
            this.Name = "frm_orden_compra";
            this.Text = "frm_orden_compra";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_proveedor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_moneda.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_almacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_centro_costo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_empresa.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.GridLookUpEdit cbo_moneda;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private System.Windows.Forms.DateTimePicker dtp_entrega;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_emision;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.GridLookUpEdit cbo_proveedor;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.GridLookUpEdit cbo_almacen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.GridLookUpEdit cbo_centro_costo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GridLookUpEdit cbo_empresa;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_comentario;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbl_total_orden;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label lbl_id_orden_compra;
        private System.Windows.Forms.Label lbl_estado;
        private System.Windows.Forms.Label label18;
    }
}