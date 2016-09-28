using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraEditors;
using Negocio;
using Entidad;
using _ExtensionMethods;
using DevExpress.XtraEditors.Repository;

namespace Presentacion
{
    public partial class frm_proveedor : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;

        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();
        List<EN_proveedor.t_proveedor> t_proveedor = new List<EN_proveedor.t_proveedor>();
        DataTable dt_t_proveedor_grid = new DataTable();
        DataTable dt_t_proveedor_final = new DataTable();

        List<EN_zero.datacombo> lista_cargo = new List<EN_zero.datacombo>();
        List<EN_zero.datacombo> lista_provincia = new List<EN_zero.datacombo>();
        List<EN_zero.datacombo> lista_distrito = new List<EN_zero.datacombo>();


        public frm_proveedor()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_proveedor_Load);
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);


            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;

            labelControl1.Text = "Proveedores";

            this.Width = 1000;
            this.Height = 400;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 5);



        }

        private void frm_proveedor_Load(object sender, EventArgs e)
        {

            inicio();
        }

        private void inicio()
        {
            dt_t_proveedor_grid = Cls_Grid.ListToTable(t_proveedor);
            dt_t_proveedor_final = Cls_Grid.ListToTable(t_proveedor);

            gridControl1.DataSource = dt_t_proveedor_grid;
            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_proveedor_grid);
            cargar_combo();
        }



        private void cargar_combo()
        {
            var negocio = new LN_proveedor();
            var retorno = new EN_proveedor.proc_proveedor_mnt_combo();

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_proveedor_mnt_combo();
            if (Cls_Grid.ExisteError(retorno.informe))
            {
                Cursor.Current = Cursors.Default;
                this.Close();
                return;
            }
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.gironegocio, "id_gironegocio", false, 300, 150);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.formapago, "id_formapago", false, 300, 150);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.pais, "id_pais", false, 300, 150);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.departamento, "id_departamento", false, 300, 150);

            lista_provincia = retorno.provincia;
            lista_distrito = retorno.distrito;
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, lista_provincia, "id_provincia", false, 300, 150);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, lista_distrito, "id_distrito", false, 300, 150);
            Application.DoEvents();
            Cursor.Current = Cursors.Default;

        }


        private void mnt_datos(string id_usuario)
        {
            try
            {
                t_proveedor = dt_t_proveedor_final.DataTableToList<EN_proveedor.t_proveedor>().ToList();
                var negocio = new LN_proveedor();
                var parametro = new EN_proveedor.proc_proveedor_mnt();
                var retorno = new EN_proveedor.proc_proveedor_mnt_retorno();

                parametro.id_usuario = id_usuario;
                parametro.t_proveedor = t_proveedor;

                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_proveedor_mnt(parametro);
                Cursor.Current = Cursors.Default;

                if (Cls_Grid.ExisteError(retorno.informe))
                {
                    return;
                }

                if (id_usuario != "")
                {
                    dt_t_proveedor_grid.Clear();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_exito, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    retorno.t_proveedor.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });
                    dt_t_proveedor_grid = Cls_Grid.ListToTable(retorno.t_proveedor);

                    gridControl1.DataSource = dt_t_proveedor_grid;
                    ((GridView)gridControl1.MainView).MoveLast();
                }

            }
            catch (Exception ex)
            {
                string error = ex.TargetSite.Name + ", " + ex.Message + " - " + Cls_Mensajes.error_sistema;
                DevExpress.XtraEditors.XtraMessageBox.Show(error, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
        }


        private void gridControl1_EmbeddedNavigator_ButtonClick(object sender, NavigatorButtonClickEventArgs e)
        {
            if ("Bloqueo".Equals(e.Button.Tag))
            {
                Cls_Grid.editable_grid(gridControl1, gridView1, true);
                e.Handled = true;
            }

            if ("Limpiar".Equals(e.Button.Tag))
            {
                dt_t_proveedor_grid.Clear();
                gridControl1.DataSource = dt_t_proveedor_grid;
                e.Handled = true;
            }

            if ("Salir".Equals(e.Button.Tag))
            {
                e.Handled = true;
                Hide();
            }

            if ("Folder".Equals(e.Button.Tag))
            {
                if (Cls_Global.mostrar_ancho_xgrid) this.Text = Cls_Grid.info_columnas(this, gridView1);

                DialogResult dialogResult = DialogResult.Yes;
                if (Cls_Global.mostrar_msg_demora) dialogResult = DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_todos, Cls_Mensajes.titulo_ventana, MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (dialogResult == DialogResult.Yes) mnt_datos("");

                Cls_Grid.editable_grid(gridControl1, gridView1, false);
                e.Handled = true;

            }

            if (e.Button.ButtonType == NavigatorButtonType.Append) gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            if (e.Button.ButtonType == NavigatorButtonType.Remove) Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_proveedor_grid);

            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {
                dt_t_proveedor_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_proveedor_grid);

                int count = dt_t_proveedor_final.Rows.Count;
                if (count == 0) return;

                DialogResult dialogResult = DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_previo, Cls_Mensajes.titulo_ventana, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes) mnt_datos(id_usuario);

            }
        }


        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            GridView gv = sender as GridView;
            bool ingreso = false;
            string id2;
            List<EN_zero.datacombo> filtro = new List<EN_zero.datacombo>();
            string name = gv.FocusedColumn.FieldName;

            if (name == "id_provincia")
            {
                id2 = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_departamento"]).ToString();
                filtro = (from Lista in lista_provincia.Where(w => w.id2 == id2) select Lista).ToList();
                ingreso = true;
            }

            if (name == "id_distrito")
            {
                id2 = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_provincia"]).ToString();
                filtro = (from Lista in lista_distrito.Where(w => w.id2 == id2) select Lista).ToList();
                ingreso = true;
            }

            if (name == "id_cargo")
            {
                id2 = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_area"]).ToString();
                filtro = (from Lista in lista_cargo.Where(w => w.id2 == id2) select Lista).ToList();
                ingreso = true;
            }

            if (ingreso == true) e.RepositoryItem = Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Filter(filtro, false, 300, 100);

        }



        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;
            if (gv.FocusedColumn.FieldName == "id_departamento")
            {
                gv.SetRowCellValue(gv.FocusedRowHandle, "id_provincia", "");
                gv.SetRowCellValue(gv.FocusedRowHandle, "id_distrito", "");
            }
            if (gv.FocusedColumn.FieldName == "id_provincia") gv.SetRowCellValue(gv.FocusedRowHandle, "id_distrito", "");
           

        }
    }
}
