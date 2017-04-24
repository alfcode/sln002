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

namespace Presentacion
{
    public partial class frm_almacen_articulo : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;

        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();
        List<EN_almacen_articulo.t_almacen_articulo> t_almacen_articulo = new List<EN_almacen_articulo.t_almacen_articulo>();
        DataTable dt_t_almacen_articulo_grid = new DataTable();
        DataTable dt_t_almacen_articulo_final = new DataTable();



        //List<EN_zero.datacombo> lista_almacen = new List<EN_zero.datacombo>();
        //List<EN_zero.datacombo> lista_articulo = new List<EN_zero.datacombo>();

        List<EN_almacen_articulo.lista_almacen> lista_almacen = new List<EN_almacen_articulo.lista_almacen>();
        List<EN_almacen_articulo.lista_tipo_unidad_almacen> lista_tipo_unidad_almacen = new List<EN_almacen_articulo.lista_tipo_unidad_almacen>();

        string id_cbo_almacen = "";
        decimal id_tipo_unidad_almacen_base=0;
        bool almacen_venta=false;


        public frm_almacen_articulo()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_almacen_articulo_Load);
            this.cbo_almacen.EditValueChanged += new System.EventHandler(this.cbo_almacen_EditValueChanged);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);


            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;
            labelControl1.Text = "Almacen Articulo";

            this.Width = 1000;
            this.Height = 500;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 5);
            gridControl1.Width = this.Width - 1;
            gridControl1.Height = this.Height - panel1.Height - 28;
        }

        private void frm_almacen_articulo_Load(object sender, EventArgs e)
        {

            inicio();
        }

        private void inicio()
        {
            dt_t_almacen_articulo_grid = Cls_Grid.ListToTable(t_almacen_articulo);
            dt_t_almacen_articulo_final = Cls_Grid.ListToTable(t_almacen_articulo);

            gridControl1.DataSource = dt_t_almacen_articulo_grid;

            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_almacen_articulo_grid);
            cargar_combo();
        }



        private void cargar_combo()
        {
            var negocio = new LN_almacen_articulo();
            var retorno = new EN_almacen_articulo.proc_almacen_articulo_mnt_combo();

            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_almacen_articulo_mnt_combo();
            if (Cls_Grid.ExisteError(retorno.informe))
            {
                Cursor.Current = Cursors.Default;
                this.Close();
                return;
            }

            Cls_Grid.Load_Combo_GridLookUpEdit(cbo_almacen, retorno.lista_almacen, false, cbo_almacen.Width, 300);
            lista_almacen = retorno.lista_almacen;

            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Simple(gridView1, retorno.unidad, "id_unidad_inventario", 80, 200);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Simple(gridView1, retorno.unidad, "id_unidad_ingreso", 80, 200);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Simple(gridView1, retorno.unidad, "id_unidad_salida", 80, 200);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Simple(gridView1, retorno.articulo, "id_articulo", 330, 200);
           


            lista_tipo_unidad_almacen = retorno.lista_tipo_unidad_almacen;

            Application.DoEvents();
            Cursor.Current = Cursors.Default;
        }


        private void mnt_datos(string id_usuario)
        {

            try
            {

                t_almacen_articulo = dt_t_almacen_articulo_final.DataTableToList<EN_almacen_articulo.t_almacen_articulo>().ToList();
                var negocio = new LN_almacen_articulo();
                var parametro = new EN_almacen_articulo.proc_almacen_articulo_mnt();
                var retorno = new EN_almacen_articulo.proc_almacen_articulo_mnt_retorno();

                parametro.id_usuario = id_usuario;
                parametro.id_almacen = id_cbo_almacen;
                parametro.t_almacen_articulo = t_almacen_articulo;


                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_almacen_articulo_mnt(parametro);
                Cursor.Current = Cursors.Default;

                if (Cls_Grid.ExisteError(retorno.informe))
                {
                    return;
                }

                if (id_usuario != "")
                {
                    dt_t_almacen_articulo_grid.Clear();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_exito, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    retorno.t_almacen_articulo.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });
                    dt_t_almacen_articulo_grid = Cls_Grid.ListToTable(retorno.t_almacen_articulo);

                    dt_t_almacen_articulo_grid.Columns["venta"].DefaultValue = almacen_venta;// valor por defecto cuando es nuevo

                    gridControl1.DataSource = dt_t_almacen_articulo_grid;
                   
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

            if ("Editar".Equals(e.Button.Tag))
            {
                Cls_Grid.editable_grid(gridControl1, gridView1, true);
                e.Handled = true;
            }
            if ("Limpiar".Equals(e.Button.Tag))
            {
                dt_t_almacen_articulo_grid.Clear();
                gridControl1.DataSource = dt_t_almacen_articulo_grid;
                Cls_Grid.editable_grid(gridControl1, gridView1, true);
                e.Handled = true;

            }

            if ("Salir".Equals(e.Button.Tag))
            {
                e.Handled = true;
                Hide();
            }

            if ("Folder".Equals(e.Button.Tag))
            {
                if (Cls_Global.mostrar_ancho_xgrid)
                    this.Text = Cls_Grid.info_columnas(this, gridView1);


                if (valida_combo() == true) return;


                DialogResult dialogResult = DialogResult.Yes;
                if (Cls_Global.mostrar_msg_demora)
                {
                    dialogResult = DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_todos, Cls_Mensajes.titulo_ventana, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }

                if (dialogResult == DialogResult.Yes)
                    id_cbo_almacen = cbo_almacen.EditValue.ToString();
                mnt_datos("");

                dt_t_almacen_articulo_grid.Columns["id_almacen"].DefaultValue = id_cbo_almacen;

                Cls_Grid.editable_grid(gridControl1, gridView1, false);
                e.Handled = true;

            }



            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                e.Handled = true;

                if (valida_combo() == true) return;

                dt_t_almacen_articulo_grid.Columns["id_almacen"].DefaultValue = cbo_almacen.EditValue.ToString();

                e.Handled = false;

                gridView1.FocusedColumn = gridView1.VisibleColumns[0];

            }

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_almacen_articulo_grid);
            }


            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {

                dt_t_almacen_articulo_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_almacen_articulo_grid);

                int count = dt_t_almacen_articulo_final.Rows.Count;
                if (count == 0)
                {
                    return;
                }


                DialogResult dialogResult = DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_previo, Cls_Mensajes.titulo_ventana, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (dialogResult == DialogResult.Yes)
                {
                    mnt_datos(id_usuario);
                }

            }

        }


        private void cbo_almacen_EditValueChanged(object sender, EventArgs e)
        {
            dt_t_almacen_articulo_grid.Clear();

            var filtro= (from Lista in lista_almacen.Where(w => w.id ==  cbo_almacen.EditValue.ToString() ) select Lista).ToList();
            foreach (var p in filtro)
            {
                id_tipo_unidad_almacen_base = p.id_tipo_unidad;
                almacen_venta = p.venta;
                dt_t_almacen_articulo_grid.Columns["venta"].DefaultValue = almacen_venta;// valor por defecto cuando es nuevo
            }

        }


        private bool valida_combo()
        {

            if (cbo_almacen.EditValue == null || cbo_almacen.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor almacen", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }


            return false;
        }

        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            GridView gv = sender as GridView;
            string name = gv.FocusedColumn.FieldName;
            string id_articulo;
            if (name == "id_unidad_inventario" )
            {
                ///|| name == "id_unidad_ingreso" || name == "id_unidad_salida"
                id_articulo = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_articulo"]).ToString();
                var filtro = (from Lista in lista_tipo_unidad_almacen.Where(w => w.id_articulo == id_articulo) select Lista).ToList();
                e.RepositoryItem = Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Filter_Doble(filtro, 300, 100);




            }


            if (name == "id_unidad_ingreso")
            {
                id_articulo = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_articulo"]).ToString();
                var filtro = (from Lista in lista_tipo_unidad_almacen.Where(w => w.id_articulo == id_articulo) select Lista).ToList();
                e.RepositoryItem = Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Filter_Doble(filtro, 300, 100);
            }

            if (name == "id_unidad_salida")
            {
                id_articulo = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_articulo"]).ToString();
                var filtro = (from Lista in lista_tipo_unidad_almacen.Where(w => w.id_articulo == id_articulo) select Lista).ToList();
                e.RepositoryItem = Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Filter_Doble(filtro, 300, 100);
            }

        }


        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;
            string name = gv.FocusedColumn.FieldName;

            string id_unidad;
            string id_articulo;


            if (name == "id_articulo")
            {
                id_articulo = e.Value.ToString();
               //// var filtro = (from Lista in lista_unidad_almacen.Where(w => (w.id_articulo == id_articulo) && (w.id_tipo_unidad == id_tipo_unidad_almacen_A || w.id_tipo_unidad == id_tipo_unidad_almacen_B)) select Lista).ToList();
                var filtro = (from Lista in lista_tipo_unidad_almacen.Where(w => (w.id_articulo == id_articulo)) select Lista).ToList();
               // Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Filter_Doble(filtro, 300, 100);

                var filtro_unidad = (from Lista in filtro.Where(w => w.id_tipo_unidad == id_tipo_unidad_almacen_base) select Lista).ToList();
                foreach (var p in filtro_unidad)
                {
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_unidad_inventario", p.id);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_unidad_ingreso", p.id);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_unidad_salida", p.id);

                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_tipo_unidad_inventario", p.id_tipo_unidad);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_tipo_unidad_ingreso", p.id_tipo_unidad);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_tipo_unidad_salida", p.id_tipo_unidad);         

                }

              
            }

            if (name == "id_unidad_inventario")
            {
                id_articulo = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_articulo"]).ToString();
                id_unidad = e.Value.ToString();
                var filtro = (from Lista in lista_tipo_unidad_almacen.Where(w => w.id_articulo == id_articulo && w.id == id_unidad) select Lista).ToList();
                foreach (var p in filtro)
                {
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_tipo_unidad_inventario", p.id_tipo_unidad);
                   
                }
            }


            if (name == "id_unidad_ingreso")
            {
                id_articulo = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_articulo"]).ToString();
                id_unidad = e.Value.ToString();
                var filtro = (from Lista in lista_tipo_unidad_almacen.Where(w => w.id_articulo == id_articulo && w.id == id_unidad) select Lista).ToList();
                foreach (var p in filtro)
                {
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_tipo_unidad_ingreso", p.id_tipo_unidad);

                }
            }

            if (name == "id_unidad_salida")
            {
                id_articulo = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_articulo"]).ToString();
                id_unidad = e.Value.ToString();
                var filtro = (from Lista in lista_tipo_unidad_almacen.Where(w => w.id_articulo == id_articulo && w.id == id_unidad) select Lista).ToList();
                foreach (var p in filtro)
                {
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_tipo_unidad_salida", p.id_tipo_unidad);

                }
            }


        }




    }
}
