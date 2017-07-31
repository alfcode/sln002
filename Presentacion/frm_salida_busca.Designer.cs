namespace Presentacion
{
    partial class frm_salida_busca
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
            this.label2 = new System.Windows.Forms.Label();
            this.cbo_almacen = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.label14 = new System.Windows.Forms.Label();
            this.btn_salir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_numero = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_moneda = new System.Windows.Forms.Label();
            this.lbl_total_orden = new System.Windows.Forms.Label();
            this.txt_comentario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_datos = new System.Windows.Forms.Button();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_emision_fin = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dtp_emision_ini = new System.Windows.Forms.DateTimePicker();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.cbo_almacen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightGray;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label2.Location = new System.Drawing.Point(2, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(336, 18);
            this.label2.TabIndex = 62;
            this.label2.Text = "Almacen";
            // 
            // cbo_almacen
            // 
            this.cbo_almacen.Location = new System.Drawing.Point(2, 24);
            this.cbo_almacen.Name = "cbo_almacen";
            this.cbo_almacen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbo_almacen.Properties.View = this.gridView3;
            this.cbo_almacen.Size = new System.Drawing.Size(337, 20);
            this.cbo_almacen.TabIndex = 75;
            // 
            // gridView3
            // 
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.LightGray;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label14.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label14.Location = new System.Drawing.Point(687, 574);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(66, 18);
            this.label14.TabIndex = 74;
            this.label14.Text = "Total";
            this.label14.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btn_salir
            // 
            this.btn_salir.BackColor = System.Drawing.Color.White;
            this.btn_salir.Image = global::Presentacion.Properties.Resources.salir64_formulario;
            this.btn_salir.Location = new System.Drawing.Point(580, 53);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(47, 49);
            this.btn_salir.TabIndex = 73;
            this.btn_salir.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_numero);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(348, 49);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(142, 53);
            this.panel2.TabIndex = 72;
            // 
            // txt_numero
            // 
            this.txt_numero.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_numero.Location = new System.Drawing.Point(72, 28);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(65, 23);
            this.txt_numero.TabIndex = 30;
            this.txt_numero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightGray;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label3.Location = new System.Drawing.Point(3, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 18);
            this.label3.TabIndex = 29;
            this.label3.Text = "S -";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightGray;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label4.Location = new System.Drawing.Point(3, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 18);
            this.label4.TabIndex = 27;
            this.label4.Text = "Por Nro Salida";
            // 
            // lbl_moneda
            // 
            this.lbl_moneda.BackColor = System.Drawing.Color.LightGray;
            this.lbl_moneda.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_moneda.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lbl_moneda.Location = new System.Drawing.Point(687, 597);
            this.lbl_moneda.Name = "lbl_moneda";
            this.lbl_moneda.Size = new System.Drawing.Size(185, 18);
            this.lbl_moneda.TabIndex = 71;
            this.lbl_moneda.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl_total_orden
            // 
            this.lbl_total_orden.BackColor = System.Drawing.Color.LightGray;
            this.lbl_total_orden.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_total_orden.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.lbl_total_orden.Location = new System.Drawing.Point(759, 574);
            this.lbl_total_orden.Name = "lbl_total_orden";
            this.lbl_total_orden.Size = new System.Drawing.Size(113, 18);
            this.lbl_total_orden.TabIndex = 70;
            this.lbl_total_orden.Text = "0";
            this.lbl_total_orden.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt_comentario
            // 
            this.txt_comentario.BackColor = System.Drawing.Color.LemonChiffon;
            this.txt_comentario.Location = new System.Drawing.Point(49, 572);
            this.txt_comentario.Multiline = true;
            this.txt_comentario.Name = "txt_comentario";
            this.txt_comentario.Size = new System.Drawing.Size(632, 46);
            this.txt_comentario.TabIndex = 68;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightGray;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label8.Location = new System.Drawing.Point(2, 587);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 18);
            this.label8.TabIndex = 69;
            this.label8.Text = "Glosa";
            // 
            // btn_datos
            // 
            this.btn_datos.Location = new System.Drawing.Point(497, 53);
            this.btn_datos.Name = "btn_datos";
            this.btn_datos.Size = new System.Drawing.Size(74, 49);
            this.btn_datos.TabIndex = 67;
            this.btn_datos.Text = "Mostrar Datos";
            this.btn_datos.UseVisualStyleBackColor = true;
            // 
            // gridControl2
            // 
            this.gridControl2.Location = new System.Drawing.Point(2, 314);
            this.gridControl2.MainView = this.gridView2;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(874, 254);
            this.gridControl2.TabIndex = 66;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridControl2;
            this.gridView2.Name = "gridView2";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16.25F);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(750, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 27);
            this.labelControl1.TabIndex = 65;
            this.labelControl1.Text = "Titulo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dtp_emision_fin);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.dtp_emision_ini);
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 53);
            this.panel1.TabIndex = 64;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightGray;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label1.Location = new System.Drawing.Point(174, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 30;
            this.label1.Text = "Hasta :";
            // 
            // dtp_emision_fin
            // 
            this.dtp_emision_fin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_emision_fin.Location = new System.Drawing.Point(231, 29);
            this.dtp_emision_fin.Name = "dtp_emision_fin";
            this.dtp_emision_fin.Size = new System.Drawing.Size(108, 21);
            this.dtp_emision_fin.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightGray;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label9.Location = new System.Drawing.Point(3, 31);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 18);
            this.label9.TabIndex = 29;
            this.label9.Text = "Desde :";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightGray;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.25F);
            this.label7.Location = new System.Drawing.Point(3, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(336, 18);
            this.label7.TabIndex = 27;
            this.label7.Text = "Por Fecha Salida";
            // 
            // dtp_emision_ini
            // 
            this.dtp_emision_ini.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_emision_ini.Location = new System.Drawing.Point(60, 29);
            this.dtp_emision_ini.Name = "dtp_emision_ini";
            this.dtp_emision_ini.Size = new System.Drawing.Size(108, 21);
            this.dtp_emision_ini.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(1, 109);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(875, 200);
            this.gridControl1.TabIndex = 63;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // frm_salida_busca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 620);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbo_almacen);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.btn_salir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbl_moneda);
            this.Controls.Add(this.lbl_total_orden);
            this.Controls.Add(this.txt_comentario);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_datos);
            this.Controls.Add(this.gridControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gridControl1);
            this.Name = "frm_salida_busca";
            this.Text = "frm_salida_busca";
            ((System.ComponentModel.ISupportInitialize)(this.cbo_almacen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GridLookUpEdit cbo_almacen;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btn_salir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txt_numero;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_moneda;
        private System.Windows.Forms.Label lbl_total_orden;
        private System.Windows.Forms.TextBox txt_comentario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_datos;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_emision_fin;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dtp_emision_ini;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}