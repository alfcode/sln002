namespace Presentacion
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
            this.btn_registrar = new System.Windows.Forms.Button();
            this.btn_editar = new System.Windows.Forms.Button();
            this.btn_eliminar = new System.Windows.Forms.Button();
            this.btn_consultar = new System.Windows.Forms.Button();
            this.dgv_cab = new System.Windows.Forms.DataGridView();
            this.dgv_det = new System.Windows.Forms.DataGridView();
            this.txt_guia = new System.Windows.Forms.TextBox();
            this.lbl_t1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_det)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_registrar
            // 
            this.btn_registrar.Location = new System.Drawing.Point(43, 12);
            this.btn_registrar.Name = "btn_registrar";
            this.btn_registrar.Size = new System.Drawing.Size(85, 31);
            this.btn_registrar.TabIndex = 0;
            this.btn_registrar.Text = "Registrar";
            this.btn_registrar.UseVisualStyleBackColor = true;
            this.btn_registrar.Click += new System.EventHandler(this.btn_registrar_Click);
            // 
            // btn_editar
            // 
            this.btn_editar.Location = new System.Drawing.Point(219, 75);
            this.btn_editar.Name = "btn_editar";
            this.btn_editar.Size = new System.Drawing.Size(85, 31);
            this.btn_editar.TabIndex = 1;
            this.btn_editar.Text = "Editar";
            this.btn_editar.UseVisualStyleBackColor = true;
            this.btn_editar.Click += new System.EventHandler(this.btn_editar_Click);
            // 
            // btn_eliminar
            // 
            this.btn_eliminar.Location = new System.Drawing.Point(310, 75);
            this.btn_eliminar.Name = "btn_eliminar";
            this.btn_eliminar.Size = new System.Drawing.Size(85, 31);
            this.btn_eliminar.TabIndex = 2;
            this.btn_eliminar.Text = "Eliminar";
            this.btn_eliminar.UseVisualStyleBackColor = true;
            this.btn_eliminar.Click += new System.EventHandler(this.btn_eliminar_Click);
            // 
            // btn_consultar
            // 
            this.btn_consultar.Location = new System.Drawing.Point(128, 75);
            this.btn_consultar.Name = "btn_consultar";
            this.btn_consultar.Size = new System.Drawing.Size(85, 31);
            this.btn_consultar.TabIndex = 3;
            this.btn_consultar.Text = "Consultar";
            this.btn_consultar.UseVisualStyleBackColor = true;
            this.btn_consultar.Click += new System.EventHandler(this.btn_consultar_Click);
            // 
            // dgv_cab
            // 
            this.dgv_cab.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_cab.Location = new System.Drawing.Point(30, 129);
            this.dgv_cab.Name = "dgv_cab";
            this.dgv_cab.Size = new System.Drawing.Size(610, 87);
            this.dgv_cab.TabIndex = 4;
            // 
            // dgv_det
            // 
            this.dgv_det.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_det.Location = new System.Drawing.Point(30, 222);
            this.dgv_det.Name = "dgv_det";
            this.dgv_det.Size = new System.Drawing.Size(710, 87);
            this.dgv_det.TabIndex = 5;
            // 
            // txt_guia
            // 
            this.txt_guia.Location = new System.Drawing.Point(43, 86);
            this.txt_guia.Name = "txt_guia";
            this.txt_guia.Size = new System.Drawing.Size(79, 20);
            this.txt_guia.TabIndex = 6;
            // 
            // lbl_t1
            // 
            this.lbl_t1.AutoSize = true;
            this.lbl_t1.Location = new System.Drawing.Point(40, 70);
            this.lbl_t1.Name = "lbl_t1";
            this.lbl_t1.Size = new System.Drawing.Size(82, 13);
            this.lbl_t1.TabIndex = 7;
            this.lbl_t1.Text = "Numero de guia";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(752, 326);
            this.Controls.Add(this.lbl_t1);
            this.Controls.Add(this.txt_guia);
            this.Controls.Add(this.dgv_det);
            this.Controls.Add(this.dgv_cab);
            this.Controls.Add(this.btn_consultar);
            this.Controls.Add(this.btn_eliminar);
            this.Controls.Add(this.btn_editar);
            this.Controls.Add(this.btn_registrar);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_cab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_det)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_registrar;
        private System.Windows.Forms.Button btn_editar;
        private System.Windows.Forms.Button btn_eliminar;
        private System.Windows.Forms.Button btn_consultar;
        private System.Windows.Forms.DataGridView dgv_cab;
        private System.Windows.Forms.DataGridView dgv_det;
        private System.Windows.Forms.TextBox txt_guia;
        private System.Windows.Forms.Label lbl_t1;
    }
}

