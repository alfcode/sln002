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
    public partial class frm_articulo : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;
      

        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();
        List<EN_articulo.t_articulo> t_articulo = new List<EN_articulo.t_articulo>();
        //List<EN_articulo.t_tipo_unidad_articulo> t_tipo_unidad_articulo = new List<EN_articulo.t_tipo_unidad_articulo>();

        DataTable dt_t_articulo_grid = new DataTable();
        DataTable dt_t_articulo_final = new DataTable();

        List<EN_zero.datacombo> lista_grupo2 = new List<EN_zero.datacombo>();
        List<EN_zero.datacombo> lista_grupo3 = new List<EN_zero.datacombo>();

        public frm_articulo()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_articulo_Load);
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);

            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;
            labelControl1.Text = " Articulos";

            this.Width = 950;
            this.Height = 400;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 5);

        }

        private void frm_articulo_Load(object sender, EventArgs e)
        {
            
            inicio();
        }

        private void inicio()
        {
            dt_t_articulo_grid = Cls_Grid.ListToTable(t_articulo);
            dt_t_articulo_final = Cls_Grid.ListToTable(t_articulo);

            int uni = Cls_Global.tipo_unidad_articulo;

            switch (uni)
            {
                case 1:
                    dt_t_articulo_grid.Columns["id_unidad1"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["id_unidad1"].Namespace = "60";// ancho de columna
                    dt_t_articulo_grid.Columns["factor1"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["factor1"].Namespace = "0";// ancho de columna
                    dt_t_articulo_grid.Columns["factor1"].DefaultValue = "1";// valor por defecto cuando es nuevo

                    break;
                case 2:
                    dt_t_articulo_grid.Columns["id_unidad1"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["id_unidad1"].Namespace = "60";// ancho de columna
                    dt_t_articulo_grid.Columns["factor1"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["factor1"].Namespace = "0";// ancho de columna
                    dt_t_articulo_grid.Columns["factor1"].DefaultValue = "1";// valor por defecto cuando es nuevo

                    dt_t_articulo_grid.Columns["id_unidad2"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["id_unidad2"].Namespace = "60";// ancho de columna
                    dt_t_articulo_grid.Columns["factor2"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["factor2"].Namespace = "30";// ancho de columna
                    dt_t_articulo_grid.Columns["factor2"].DefaultValue = "1";// valor por defecto cuando es nuevo

                    break;
                case 3:

                    dt_t_articulo_grid.Columns["id_unidad1"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["id_unidad1"].Namespace = "60";// ancho de columna
                    dt_t_articulo_grid.Columns["factor1"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["factor1"].Namespace = "0";// ancho de columna
                    dt_t_articulo_grid.Columns["factor1"].DefaultValue = "1";// valor por defecto cuando es nuevo

                    dt_t_articulo_grid.Columns["id_unidad2"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["id_unidad2"].Namespace = "60";// ancho de columna
                    dt_t_articulo_grid.Columns["factor2"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["factor2"].Namespace = "30";// ancho de columna
                    dt_t_articulo_grid.Columns["factor2"].DefaultValue = "1";// valor por defecto cuando es nuevo

                    dt_t_articulo_grid.Columns["id_unidad3"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["id_unidad3"].Namespace = "60";// ancho de columna
                    dt_t_articulo_grid.Columns["factor3"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["factor3"].Namespace = "30";// ancho de columna
                    dt_t_articulo_grid.Columns["factor3"].DefaultValue = "1";// valor por defecto cuando es nuevo


                    break;
                case 4:
                    dt_t_articulo_grid.Columns["id_unidad1"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["id_unidad1"].Namespace = "60";// ancho de columna
                    dt_t_articulo_grid.Columns["factor1"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["factor1"].Namespace = "0";// ancho de columna
                    dt_t_articulo_grid.Columns["factor1"].DefaultValue = "1";// valor por defecto cuando es nuevo

                    dt_t_articulo_grid.Columns["id_unidad2"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["id_unidad2"].Namespace = "60";// ancho de columna
                    dt_t_articulo_grid.Columns["factor2"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["factor2"].Namespace = "30";// ancho de columna
                    dt_t_articulo_grid.Columns["factor2"].DefaultValue = "1";// valor por defecto cuando es nuevo

                    dt_t_articulo_grid.Columns["id_unidad3"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["id_unidad3"].Namespace = "60";// ancho de columna
                    dt_t_articulo_grid.Columns["factor3"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["factor3"].Namespace = "30";// ancho de columna
                    dt_t_articulo_grid.Columns["factor3"].DefaultValue = "1";// valor por defecto cuando es nuevo

                    dt_t_articulo_grid.Columns["id_unidad4"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["id_unidad4"].Namespace = "60";// ancho de columna
                    dt_t_articulo_grid.Columns["factor4"].AllowDBNull = false; // obligatorio
                    dt_t_articulo_grid.Columns["factor4"].Namespace = "30";// ancho de columna
                    dt_t_articulo_grid.Columns["factor4"].DefaultValue = "1";// valor por defecto cuando es nuevo

                    break;
            }

            gridControl1.DataSource = dt_t_articulo_grid;
           
            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_articulo_grid);
            cargar_combo();
        }



        private void cargar_combo()
        {
            var negocio = new LN_articulo();
            var retorno = new EN_articulo.proc_articulo_mnt_combo();

            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_articulo_mnt_combo();
            if (Cls_Grid.ExisteError(retorno.informe))
            {
                Cursor.Current = Cursors.Default;
                this.Close();
                return;
            }

            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.unidad, "id_unidad1", false, 300, 200);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.unidad, "id_unidad2", false, 300, 200);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.unidad, "id_unidad3", false, 300, 200);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.unidad, "id_unidad4", false, 300, 200);


            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.grupo1, "id_grupo1", false, 300, 200);
            lista_grupo2 = retorno.grupo2;
            lista_grupo3 = retorno.grupo3;
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.grupo2, "id_grupo2", false, 300, 200);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.grupo3, "id_grupo3", false, 300, 200);
            Application.DoEvents();
            Cursor.Current = Cursors.Default;
        }


        private void mnt_datos(string id_usuario)
        {

            try
            {

            t_articulo = dt_t_articulo_final.DataTableToList<EN_articulo.t_articulo>().ToList();
            var negocio = new LN_articulo();
            var parametro = new EN_articulo.proc_articulo_mnt();
            var retorno = new EN_articulo.proc_articulo_mnt_retorno();


                //int id_tipo_unidad_articulo=0;
                //int uni = Cls_Global.tipo_unidad_articulo;

                //var filtro = (from Lista in t_articulo.Where(w => w.id_usuario_ultimo =="nuevo" || w.id_usuario_ultimo == "modificar" || w.id_usuario_ultimo == "eliminar") select Lista).ToList();


                //foreach (var p in filtro)
                //{


                //    id_tipo_unidad_articulo = 1;
                //    var uni1 = new EN_articulo.t_tipo_unidad_articulo();
                //    uni1.id_tipo_unidad = id_tipo_unidad_articulo;
                //    uni1.id_articulo = p.id_articulo;
                //    uni1.id_unidad = p.id_unidad1;
                //    uni1.factor = p.factor1;
                //    uni1.id_usuario_ultimo = p.id_usuario_ultimo;// estado de trabajo
                //    t_tipo_unidad_articulo.Add(uni1);
                //    if (id_tipo_unidad_articulo == uni) break;


                //    id_tipo_unidad_articulo = 2;
                //    var uni2 = new EN_articulo.t_tipo_unidad_articulo();
                //    uni2.id_tipo_unidad = id_tipo_unidad_articulo;
                //    uni2.id_articulo = p.id_articulo;
                //    uni2.id_unidad = p.id_unidad2;
                //    uni2.factor = p.factor2;
                //    uni2.id_usuario_ultimo = p.id_usuario_ultimo;// estado de trabajo
                //    t_tipo_unidad_articulo.Add(uni2);
                //    if (id_tipo_unidad_articulo == uni) break;

                //    id_tipo_unidad_articulo = 3;
                //    var uni3 = new EN_articulo.t_tipo_unidad_articulo();
                //    uni3.id_tipo_unidad = id_tipo_unidad_articulo;
                //    uni3.id_articulo = p.id_articulo;
                //    uni3.id_unidad = p.id_unidad3;
                //    uni3.factor = p.factor3;
                //    uni3.id_usuario_ultimo = p.id_usuario_ultimo;// estado de trabajo
                //    t_tipo_unidad_articulo.Add(uni3);
                //    if (id_tipo_unidad_articulo == uni) break;

                //    id_tipo_unidad_articulo = 4;
                //    var uni4 = new EN_articulo.t_tipo_unidad_articulo();
                //    uni4.id_tipo_unidad = id_tipo_unidad_articulo;
                //    uni4.id_articulo = p.id_articulo;
                //    uni4.id_unidad = p.id_unidad4;
                //    uni4.factor = p.factor4;
                //    uni4.id_usuario_ultimo = p.id_usuario_ultimo;// estado de trabajo
                //    t_tipo_unidad_articulo.Add(uni4);
                    
                //} 
               



                parametro.id_usuario = id_usuario;
                parametro.t_articulo = t_articulo;

                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_articulo_mnt(parametro);
               

            if (Cls_Grid.ExisteError(retorno.informe))
            {
                return;
            }

            if (id_usuario != "")
            {
                    dt_t_articulo_grid.Clear();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_exito, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    Cursor.Current = Cursors.Default;
           }
            else
            {
                retorno.t_articulo.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });

                 //   int uni = Cls_Global.tipo_unidad_medida;
                 //   foreach (var c in retorno.t_articulo)
                 //{
                 //      // var filtro = (from Lista in retorno.t_tipo_unidad_articulo.Where(w => w.id_articulo == c.id_articulo) select Lista).ToList();
                 //       foreach (var d in retorno.t_tipo_unidad_articulo)
                 //       {

                 //           if (d.id_articulo == c.id_articulo) { 

                 //           if (d.id_tipo_unidad == 1) {c.id_unidad1 = d.id_unidad;c.factor1 = d.factor; };
                 //           if (d.id_tipo_unidad == 2) {c.id_unidad2 = d.id_unidad; c.factor2 = d.factor; };
                 //           if (d.id_tipo_unidad == 3) { c.id_unidad3 = d.id_unidad; c.factor3 = d.factor; };
                 //           if (d.id_tipo_unidad == 4) { c.id_unidad4 = d.id_unidad; c.factor4 = d.factor; };

                 //           if(d.id_tipo_unidad==uni)  break;

                 //           }
                 //       }
                 //}

                    Cursor.Current = Cursors.Default;
                dt_t_articulo_grid = Cls_Grid.ListToTable(retorno.t_articulo);
                gridControl1.DataSource = dt_t_articulo_grid;
                ((GridView)gridControl1.MainView).MoveLast();
            }

            }
            catch(Exception ex)
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
                dt_t_articulo_grid.Clear();
                gridControl1.DataSource = dt_t_articulo_grid;
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

                DialogResult dialogResult = DialogResult.Yes;
                if (Cls_Global.mostrar_msg_demora)
                {
                    dialogResult = DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_todos, Cls_Mensajes.titulo_ventana, MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }

                if (dialogResult == DialogResult.Yes) mnt_datos("");

                Cls_Grid.editable_grid(gridControl1, gridView1, false);
                e.Handled = true;
               
            }



            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {

               // dt_t_articulo_grid.Clear();
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];

            }

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_articulo_grid);
            }


            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {

                dt_t_articulo_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_articulo_grid);

                int count = dt_t_articulo_final.Rows.Count;
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




        private void gridView1_CustomRowCellEditForEditing(object sender, CustomRowCellEditEventArgs e)
        {
            GridView gv = sender as GridView;
            bool ingreso = false;
            string id2;
            List<EN_zero.datacombo> filtro = new List<EN_zero.datacombo>();
            string name = gv.FocusedColumn.FieldName;

            if (name == "id_grupo2")
            {
                id2 = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_grupo1"]).ToString();
                filtro = (from Lista in lista_grupo2.Where(w => w.id2 == id2) select Lista).ToList();
                ingreso = true;
            }

            if (name == "id_grupo3")
            {
                id2 = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_grupo2"]).ToString();
                filtro = (from Lista in lista_grupo3.Where(w => w.id2 == id2) select Lista).ToList();
                ingreso = true;
            }

            if (ingreso == true) e.RepositoryItem = Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Filter(filtro, false, 300, 200);

        }



        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView gv = sender as GridView;
            if (gv.FocusedColumn.FieldName == "id_grupo1")
            {
                gv.SetRowCellValue(gv.FocusedRowHandle, "id_grupo2", "");
                gv.SetRowCellValue(gv.FocusedRowHandle, "id_grupo3", "");
            }
            if (gv.FocusedColumn.FieldName == "id_grupo2") gv.SetRowCellValue(gv.FocusedRowHandle, "id_grupo3", "");
  

        }


    }
}
