using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Entidad;
using Negocio;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;

namespace Presentacion
{
    public partial class frm_salida_busca : DevExpress.XtraEditors.XtraForm
    {
        public string id_salida = "";
        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();

        List<EN_salida.t_salida_busca_det> t_salida_busca_det = new List<EN_salida.t_salida_busca_det>();

        DataTable dt_t_salida_busca_cab = new DataTable();
        DataTable dt_t_salida_busca_det = new DataTable();

        public frm_salida_busca()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            this.Load += new System.EventHandler(this.frm_salida_busca_Load);
            this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            this.gridView2.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView2_RowStyle);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            this.btn_datos.Click += new System.EventHandler(this.btn_datos_Click);
            this.btn_salir.Click += new System.EventHandler(this.btn_salir_Click);



            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;
            labelControl1.Text = "Buscar por salidas";

            this.Width = 900;
            this.Height = 660;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 2);

            gridControl1.Width = this.Width - 4;
            gridControl1.Left = 1;
            gridControl2.Width = this.Width - 4;
            gridControl2.Left = 1;
        }

        private void frm_salida_busca_Load(object sender, EventArgs e)
        {

            inicio();
        }

        private void inicio()
        {
            var fechatemp = DateTime.Today;
            var fecha1 = new DateTime(fechatemp.Year, fechatemp.Month, 1);
            DateTime fecha2;

            if (fechatemp.Month + 1 < 13)
            { fecha2 = new DateTime(fechatemp.Year, fechatemp.Month + 1, 1).AddDays(-1); }
            else
            { fecha2 = new DateTime(fechatemp.Year + 1, 1, 1).AddDays(-1); }

            dtp_emision_ini.Value = fecha1;
            dtp_emision_fin.Value = fecha2;
            txt_comentario.Enabled = false;
            txt_numero.MaxLength = 8;


            var negocio = new LN_salida();
            var retorno = new EN_salida.proc_salida_mnt_busca_retorno();
            var parametro = new EN_salida.proc_salida_mnt_busca();

            parametro.id_almacen = "";
            parametro.numero = "inicio";
            parametro.fecha_ini = "";
            parametro.fecha_fin = "";

            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_salida_mnt_busca(parametro);
            if (Cls_Grid.ExisteError(retorno.informe))
            {
                Cursor.Current = Cursors.Default;
                this.Close();
                return;
            }

            Cls_Grid.Load_Combo_GridLookUpEdit_Simple(cbo_almacen, retorno.almacen, cbo_almacen.Width, 300);
            cbo_almacen.EditValue = "ALM0000003";

        }

        private void btn_datos_Click(object sender, EventArgs e)
        {
            datos();
        }

        private void datos()
        {
            try
            {

                var negocio = new LN_salida();
                var parametro = new EN_salida.proc_salida_mnt_busca();
                var retorno = new EN_salida.proc_salida_mnt_busca_retorno();

                parametro.id_almacen = cbo_almacen.EditValue.ToString();
                parametro.fecha_ini = dtp_emision_ini.Value.ToString("yyyy-MM-dd");
                parametro.fecha_fin = dtp_emision_fin.Value.ToString("yyyy-MM-dd 23:59:59");


                if (txt_numero.TextLength != 0)
                {
                    decimal texto;
                    var Result = decimal.TryParse(txt_numero.Text, out texto);
                    if (Result == false) return;

                    string numero = texto.ToString("000000000");
                    parametro.numero = "S" + numero;
                }
                else
                {
                    parametro.numero = "";
                }

                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_salida_mnt_busca(parametro);
                Cursor.Current = Cursors.Default;
                if (Cls_Grid.ExisteError(retorno.informe)) return;

                gridView1.Columns.Clear();
                dt_t_salida_busca_cab = Cls_Grid.ListToTable(retorno.t_salida_busca_cab);
                t_salida_busca_det = retorno.t_salida_busca_det;
                
    
                gridControl1.DataSource = dt_t_salida_busca_cab;
                gridView1.OptionsView.ColumnAutoWidth = false;
                Cls_Grid.Visible_Columns(gridView1, dt_t_salida_busca_cab);
                Cls_Grid.editable_grid(gridControl1, gridView1, false);

                gridView1.Appearance.FocusedRow.BackColor = Color.CadetBlue;

                // gridView1.OptionsSelection.MultiSelect = false;
                //gridView1.Appearance.SelectedRow.BackColor = Color.Aquamarine;
                //gridView1.Appearance.TopNewRow.BackColor = Color.Black;

                ((GridView)gridControl1.MainView).MoveLast();

                if (Cls_Global.mostrar_ancho_xgrid)
                    this.Text = Cls_Grid.info_columnas(this, gridView1);

                RepositoryItemButtonEdit buttonEdit = new RepositoryItemButtonEdit();
                buttonEdit.Buttons[0].Kind = ButtonPredefines.Search;
                buttonEdit.TextEditStyle = TextEditStyles.HideTextEditor;
                buttonEdit.ButtonClick += new ButtonPressedEventHandler(button_modificar);


                GridColumn unbColumn = gridView1.Columns.AddField("[ ---> ]");
                unbColumn.UnboundType = DevExpress.Data.UnboundColumnType.String;
                unbColumn.VisibleIndex = 0;
                unbColumn.ColumnEdit = buttonEdit;
                unbColumn.Width = 48;
                unbColumn.Fixed = FixedStyle.Left;

                gridView1.Columns["salida"].Fixed = FixedStyle.Left;

                gridView1.Columns["estado"].Fixed = FixedStyle.Right;

            }
            catch (Exception ex)
            {
                string error = ex.TargetSite.Name + ", " + ex.Message + " - " + Cls_Mensajes.error_sistema;
                DevExpress.XtraEditors.XtraMessageBox.Show(error, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                Cursor.Current = Cursors.Default;
            }
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (((e.State & DevExpress.XtraGrid.Views.Base.GridRowCellState.Focused) != 0) && ((e.State & DevExpress.XtraGrid.Views.Base.GridRowCellState.GridFocused) != 0))
                e.Appearance.Assign(view.PaintAppearance.FocusedRow);
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView view = sender as GridView;
            if (((e.State & DevExpress.XtraGrid.Views.Base.GridRowCellState.Focused) != 0) && ((e.State & DevExpress.XtraGrid.Views.Base.GridRowCellState.GridFocused) != 0))
                e.Appearance.Assign(view.PaintAppearance.FocusedRow);
        }


        private void gridView1_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {

            try
            {



                GridView gv = sender as GridView;
                string salida = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["salida"]).ToString();

                txt_comentario.Text = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["comentario"]).ToString();
                lbl_moneda.Text = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["moneda"]).ToString();
                var lista = (from Lista in t_salida_busca_det.Where(w => w.salida == salida) select Lista).ToList();

                dt_t_salida_busca_det = Cls_Grid.ListToTable(lista);
                gridControl2.DataSource = dt_t_salida_busca_det;
                gridControl2.Refresh();

                gridView2.Appearance.FocusedRow.BackColor = Color.CadetBlue;

                DevExpress.Utils.FormatInfo fi = new DevExpress.Utils.FormatInfo();
                fi.FormatType = DevExpress.Utils.FormatType.Numeric;
                fi.FormatString = "n3";
                gridView2.Columns["cantidad_nota"].DisplayFormat.Assign(fi);
                gridView2.Columns["cantidad_real"].DisplayFormat.Assign(fi);
                fi.FormatString = "n2";
                gridView2.Columns["costo"].DisplayFormat.Assign(fi);
                gridView2.Columns["importe"].DisplayFormat.Assign(fi);

                gridView2.OptionsView.ColumnAutoWidth = false;
                Cls_Grid.Visible_Columns(gridView2, dt_t_salida_busca_det);
                Cls_Grid.editable_grid(gridControl2, gridView2, false);

                ((GridView)gridControl2.MainView).MoveLast();

                if (Cls_Global.mostrar_ancho_xgrid)
                    this.Text = Cls_Grid.info_columnas(this, gridView2);

                calculo_total();
            }
            catch
            {

            }
        }

        private void calculo_total()
        {
            decimal t = 0;
            foreach (DataRow row in dt_t_salida_busca_det.Rows)
            {
                t = t + (Convert.ToDecimal(row["cantidad_nota"]) * Convert.ToDecimal(row["costo"]));

            }

            lbl_total_orden.Text = t.ToString("N");
        }

        private void button_modificar(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit ed = gridView1.ActiveEditor as ButtonEdit;
            if (ed == null) return;
            if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Search)
            {
                string salida = (gridView1.GetRowCellValue(gridView1.FocusedRowHandle, gridView1.Columns["salida"]).ToString());
                //gridView1.DeleteRow(gridView1.FocusedRowHandle);
                id_salida = salida;
                this.Hide();
            }

        }

        private void btn_salir_Click(object sender, EventArgs e)
        {
            id_salida = "";

            //this.Text = Cls_Grid.info_columnas(this, gridView2);
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}