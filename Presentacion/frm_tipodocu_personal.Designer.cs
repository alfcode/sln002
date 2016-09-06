namespace Presentacion
{
    partial class frm_tipodocu_personal
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
            this.txt_nombre = new DevExpress.XtraEditors.TextEdit();
            this.txt_numero = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.chk_id_estado = new DevExpress.XtraEditors.CheckEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.txt_id = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.btn_buscar = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btn_salir = new DevExpress.XtraEditors.SimpleButton();
            this.btn_grabar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_editar = new DevExpress.XtraEditors.SimpleButton();
            this.btn_nuevo = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txt_nombre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_numero.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_id_estado.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_id.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_nombre
            // 
            this.txt_nombre.Location = new System.Drawing.Point(51, 13);
            this.txt_nombre.Name = "txt_nombre";
            this.txt_nombre.Size = new System.Drawing.Size(236, 20);
            this.txt_nombre.TabIndex = 0;
            // 
            // txt_numero
            // 
            this.txt_numero.EditValue = "";
            this.txt_numero.Location = new System.Drawing.Point(51, 48);
            this.txt_numero.Name = "txt_numero";
            this.txt_numero.Size = new System.Drawing.Size(100, 20);
            this.txt_numero.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 19);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Nombre";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Numero";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 82);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(30, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Activo";
            // 
            // chk_id_estado
            // 
            this.chk_id_estado.Location = new System.Drawing.Point(51, 81);
            this.chk_id_estado.Name = "chk_id_estado";
            this.chk_id_estado.Properties.Caption = "checkEdit1";
            this.chk_id_estado.Size = new System.Drawing.Size(64, 19);
            this.chk_id_estado.TabIndex = 5;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.txt_id);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.txt_numero);
            this.panelControl1.Controls.Add(this.chk_id_estado);
            this.panelControl1.Controls.Add(this.txt_nombre);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(457, 140);
            this.panelControl1.TabIndex = 6;
            // 
            // txt_id
            // 
            this.txt_id.Location = new System.Drawing.Point(77, 115);
            this.txt_id.Name = "txt_id";
            this.txt_id.Size = new System.Drawing.Size(100, 20);
            this.txt_id.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(38, 119);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(33, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Codigo";
            // 
            // btn_buscar
            // 
            this.btn_buscar.Location = new System.Drawing.Point(254, 10);
            this.btn_buscar.Name = "btn_buscar";
            this.btn_buscar.Size = new System.Drawing.Size(77, 32);
            this.btn_buscar.TabIndex = 6;
            this.btn_buscar.Text = "Buscar";
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.btn_salir);
            this.panelControl2.Controls.Add(this.btn_grabar);
            this.panelControl2.Controls.Add(this.btn_buscar);
            this.panelControl2.Controls.Add(this.btn_editar);
            this.panelControl2.Controls.Add(this.btn_nuevo);
            this.panelControl2.Location = new System.Drawing.Point(12, 168);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(457, 47);
            this.panelControl2.TabIndex = 7;
            // 
            // btn_salir
            // 
            this.btn_salir.Location = new System.Drawing.Point(375, 10);
            this.btn_salir.Name = "btn_salir";
            this.btn_salir.Size = new System.Drawing.Size(77, 32);
            this.btn_salir.TabIndex = 3;
            this.btn_salir.Text = "Salir";
            // 
            // btn_grabar
            // 
            this.btn_grabar.Location = new System.Drawing.Point(171, 10);
            this.btn_grabar.Name = "btn_grabar";
            this.btn_grabar.Size = new System.Drawing.Size(77, 32);
            this.btn_grabar.TabIndex = 2;
            this.btn_grabar.Text = "Grabar";
            // 
            // btn_editar
            // 
            this.btn_editar.Location = new System.Drawing.Point(88, 10);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(77, 32);
            this.btn_editar.TabIndex = 1;
            this.btn_editar.Text = "Modificar";
            // 
            // btn_nuevo
            // 
            this.btn_nuevo.Location = new System.Drawing.Point(5, 10);
            this.btn_nuevo.Name = "btn_nuevo";
            this.btn_nuevo.Size = new System.Drawing.Size(77, 32);
            this.btn_nuevo.TabIndex = 0;
            this.btn_nuevo.Text = "Nuevo";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(296, 10);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(35, 24);
            this.simpleButton1.TabIndex = 9;
            this.simpleButton1.Text = "-- >";
            // 
            // frm_tipodocu_personal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 222);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Name = "frm_tipodocu_personal";
            this.Text = "frm_tipodocu_personal";
            ((System.ComponentModel.ISupportInitialize)(this.txt_nombre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_numero.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chk_id_estado.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_id.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txt_nombre;
        private DevExpress.XtraEditors.TextEdit txt_numero;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.CheckEdit chk_id_estado;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_buscar;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.SimpleButton btn_salir;
        private DevExpress.XtraEditors.SimpleButton btn_grabar;
        private DevExpress.XtraEditors.SimpleButton btn_editar;
        private DevExpress.XtraEditors.SimpleButton btn_nuevo;
        private DevExpress.XtraEditors.TextEdit txt_id;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}