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
using DevExpress.XtraGrid;
using DevExpress.XtraEditors.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Presentacion
{
    public partial class frm_ingreso : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;
        string id_ingreso = "";
        string id_salida = "";
        string modo = "nuevo";
        bool transferencia = false;
        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();

        List<EN_ingreso.t_ingreso_det> t_ingreso_det = new List<EN_ingreso.t_ingreso_det>();
        DataTable dt_t_ingreso_det_grid = new DataTable();
        DataTable dt_t_ingreso_det_final = new DataTable();

        List<EN_ingreso.lista_articulo> lista_articulo = new List<EN_ingreso.lista_articulo>();
        List<EN_ingreso.lista_tipo_unidad_almacen> lista_tipo_unidad_almacen = new List<EN_ingreso.lista_tipo_unidad_almacen>();
 
        List<EN_ingreso.lista_almacen> lista_almacen = new List<EN_ingreso.lista_almacen>();
        List<EN_ingreso.lista_tipo_ingreso> lista_tipo_ingreso = new List<EN_ingreso.lista_tipo_ingreso>();

        //decimal id_tipo_unidad_almacen_A = 0;
        //decimal id_tipo_unidad_almacen_B = 0;


        public frm_ingreso()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_ingreso_Load);
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.txt_numero_documento.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_numero_documento_KeyDown);
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);
            this.cbo_tipo_ingreso.EditValueChanged += new System.EventHandler(this.cbo_tipo_ingreso_EditValueChanged);
            this.cbo_almacen.EditValueChanged += new System.EventHandler(this.cbo_almacen_EditValueChanged);

            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;
            labelControl1.Text = "Ingresos";

            this.Width = 650;
            this.Height = 615;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 2);

            gridControl1.Width = this.Width - 4;
            //  gridControl1.Height = this.Height - panel1.Height - 30;
            gridControl1.Left = 1;

        }

        private void frm_ingreso_Load(object sender, EventArgs e)
        {

            inicio();
        }

        private void inicio()
        {
            dt_t_ingreso_det_grid = Cls_Grid.ListToTable(t_ingreso_det);
            dt_t_ingreso_det_final = Cls_Grid.ListToTable(t_ingreso_det);

            gridControl1.DataSource = dt_t_ingreso_det_grid;

            DevExpress.Utils.FormatInfo fi = new DevExpress.Utils.FormatInfo();
            fi.FormatType = DevExpress.Utils.FormatType.Numeric;
            fi.FormatString = "n3";
            gridView1.Columns["cantidad_nota"].DisplayFormat.Assign(fi);
            gridView1.Columns["cantidad_real"].DisplayFormat.Assign(fi);
            fi.FormatString = "n2";
            gridView1.Columns["costo"].DisplayFormat.Assign(fi);
            gridView1.Columns["importe"].DisplayFormat.Assign(fi);


            //DevExpress.XtraGrid.Columns.GridColumn col_costo = gridView1.Columns["costo"];
            //col_costo.OptionsColumn.AllowEdit = false;
            //col_costo.OptionsColumn.AllowFocus = false;
            //DevExpress.XtraGrid.Columns.GridColumn col_unidad = gridView1.Columns["unidad"];
            //col_unidad.OptionsColumn.AllowEdit = false;
            //col_unidad.OptionsColumn.AllowFocus = false;


            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_ingreso_det_grid);
            gridView1.OptionsView.ColumnAutoWidth = true;
            gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            //gridView1.ColumnPanelRowHeight = 75;


           cargar_combo();

            modo = "cancelar";
            habilitar();
        }



        private void cargar_combo()
        {
            var negocio = new LN_ingreso();
            var retorno = new EN_ingreso.proc_ingreso_mnt_combo();

            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_ingreso_mnt_combo();
            if (Cls_Grid.ExisteError(retorno.informe))
            {
                Cursor.Current = Cursors.Default;
                this.Close();
                return;
            }


            Cls_Grid.Load_Combo_GridLookUpEdit_Simple(cbo_empresa, retorno.empresa, cbo_empresa.Width, 300);
            Cls_Grid.Load_Combo_GridLookUpEdit_Simple(cbo_centro_costo, retorno.centro_costo, cbo_centro_costo.Width, 300);
            Cls_Grid.Load_Combo_GridLookUpEdit_Simple(cbo_tipo_ingreso, retorno.tingreso, cbo_tipo_ingreso.Width, 300);
            Cls_Grid.Load_Combo_GridLookUpEdit_Simple(cbo_almacen, retorno.almacen, cbo_almacen.Width, 300);
            Cls_Grid.Load_Combo_GridLookUpEdit_Simple(cbo_proveedor, retorno.proveedor, cbo_proveedor.Width, 300);
            Cls_Grid.Load_Combo_GridLookUpEdit_Simple(cbo_tipo_documento, retorno.tdocu_sunat, cbo_tipo_documento.Width, 300);
            Cls_Grid.Load_Combo_GridLookUpEdit_Simple(cbo_moneda, retorno.moneda, cbo_moneda.Width, 300);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Simple(gridView1, retorno.unidad, "id_unidad", 300, 200);

            lista_almacen = retorno.almacen;
            lista_tipo_ingreso = retorno.tingreso;

            Application.DoEvents();
            Cursor.Current = Cursors.Default;
        }

        private void cargar_unidad_almacen(string id_almacen)
        {
            var negocio = new LN_ingreso();
            var retorno = new EN_ingreso.proc_ingreso_mnt_tipo_unidad_almacen();
            var parametros = new EN_ingreso.proc_ingreso_mnt_tipo_unidad_almacen_parametros();

            //var filtro_provincia = (from Lista in lista_almacen.Where(w => w.id == id_almacen) select Lista).ToList();
            //foreach (var p in filtro_provincia)
            //{
            //    id_tipo_unidad_almacen_A = p.id_tipo_unidad_ingreso1;
            //    id_tipo_unidad_almacen_B = p.id_tipo_unidad_ingreso2;
            //}

            //parametros.id_tipo_unidad_almacen_A = id_tipo_unidad_almacen_A;
            //parametros.id_tipo_unidad_almacen_B = id_tipo_unidad_almacen_B;

            parametros.id_almacen = cbo_almacen.EditValue.ToString();
            parametros.id_almacen2 = cbo_almacen.EditValue.ToString();

            if (cbo_almacen2.Enabled==true) parametros.id_almacen2 = cbo_almacen2.EditValue.ToString();

            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_ingreso_mnt_tipo_unidad_almacen(parametros);
            if (Cls_Grid.ExisteError(retorno.informe))
            {
                Cursor.Current = Cursors.Default;
                
                return;
            }

            lista_tipo_unidad_almacen = retorno.lista_tipo_unidad_almacen;
            lista_articulo = retorno.lista_articulo;
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Simple(gridView1, lista_articulo, "id_articulo", 300, 200);

            Application.DoEvents();
            Cursor.Current = Cursors.Default;

            if (modo == "nuevo")
            {
                gridView1.Focus();
                gridView1.AddNewRow();
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];
            }
            

        }


        private void mnt_datos(string id_usuario)
        {

            try
            {

                t_ingreso_det = dt_t_ingreso_det_final.Tabla_a_Lista<EN_ingreso.t_ingreso_det>().ToList();

                var negocio = new LN_ingreso();
                var parametro = new EN_ingreso.proc_ingreso_mnt();
                var retorno = new EN_ingreso.proc_ingreso_mnt_retorno();
                var t_ingreso = new List<EN_ingreso.t_ingreso>();

               
                if (id_usuario != "")
                {
                    string estado = "EST0000001";

                    if (modo == "modificar"){
                        int count = dt_t_ingreso_det_grid.AsEnumerable()
                                                           .Count(row => row.Field<string>("id_usuario_ultimo").Equals("nuevo")
                                                                      || row.Field<string>("id_usuario_ultimo").Equals("grabado")
                                                                      || row.Field<string>("id_usuario_ultimo").Equals("modificar"));

                        if (count == 0) estado = "EST0000002";
                        if (count == 0) modo = "eliminar";

                    }



                    var cab = new EN_ingreso.t_ingreso();
                    cab.id_ingreso = id_ingreso;
                   
                    cab.id_orden_compra = txt_orden_compra.Text;

                    cab.id_empresa = cbo_empresa.EditValue.ToString();
                    cab.id_centro_costo = cbo_centro_costo.EditValue.ToString();

                    cab.id_tingreso = cbo_tipo_ingreso.EditValue.ToString();
                    cab.id_almacen = cbo_almacen.EditValue.ToString();
                    cab.id_proveedor = cbo_proveedor.EditValue.ToString();
                    cab.id_tdocu_sunat = cbo_tipo_documento.EditValue.ToString();
                    cab.fecha_movimiento = dtp_documento.Value;
                    cab.id_moneda = cbo_moneda.EditValue.ToString();
                    cab.nro_tdocu = txt_numero_documento.Text;
  
                    cab.tipo_cambio = 0;
                    cab.comentario = txt_comentario.Text;
                    cab.id_estado_cab = estado;

                    cab.id_salida = id_salida;
                    if (cbo_almacen2.EditValue != null)
                    {

                        cab.id_almacen2 = cbo_almacen2.EditValue.ToString();
                        cab.tranferencia = true;
                        transferencia = true;
                    }
                    else
                    {
                        cab.id_almacen2 = "";
                        cab.tranferencia = false;
                        transferencia = false;

                    }



                    

                    cab.id_usuario_inicia = id_usuario;
                    cab.id_usuario_ultimo = modo;
                    cab.fecha_inicia = Convert.ToDateTime("01/01/2016");
                    cab.fecha_ultimo = Convert.ToDateTime("01/01/2016");
                    
                    t_ingreso.Add(cab);
                }
                else
                {
                    modo = "consultar";
                }
                ///----parametros a enviar.
                parametro.modo = modo;
                parametro.id_usuario = id_usuario;
                parametro.id_ingreso = id_ingreso;
                parametro.id_salida = id_salida;
                parametro.transferencia = transferencia;
                ///tablas
                parametro.t_ingreso = t_ingreso;
                parametro.t_ingreso_det = t_ingreso_det;

                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_ingreso_mnt(parametro);
                Cursor.Current = Cursors.Default;

                if (Cls_Grid.ExisteError(retorno.informe)) return;

                if (id_usuario != "") //// cuando termino de grabar con dato de id usuario!=""
                {
                    modo = "cancelar";
                    habilitar();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_exito, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {

                    foreach (var p in retorno.t_ingreso)
                    {
                        id_ingreso= p.id_ingreso  ;
                        cbo_empresa.EditValue = p.id_empresa;
                        cbo_centro_costo.EditValue = p.id_centro_costo;

                        cbo_tipo_ingreso.EditValue = p.id_tingreso;
                        cbo_almacen.EditValue = p.id_almacen;
                        cbo_almacen2.EditValue = p.id_almacen2;
                        cbo_proveedor.EditValue = p.id_proveedor;
                        cbo_tipo_documento.EditValue = p.id_tdocu_sunat;

                        txt_numero_documento.Text = p.nro_tdocu;
                        txt_orden_compra.Text = p.id_orden_compra;
                        dtp_documento.Value = p.fecha_movimiento;
                        cbo_moneda.EditValue = p.id_moneda;

                        txt_comentario.Text = p.comentario;
                        lbl_estado.Text = p.estado_cab;

                        if (p.tranferencia == true)
                        {

                            id_salida = p.id_salida;
                            cbo_almacen2.Visible = true;
                            cbo_almacen2.EditValue = p.id_almacen2;

                        }



                    }


                    cargar_unidad_almacen(cbo_almacen.EditValue.ToString());

                    retorno.t_ingreso_det.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });
                    dt_t_ingreso_det_grid = Cls_Grid.ListToTable(retorno.t_ingreso_det);
                    gridControl1.DataSource = dt_t_ingreso_det_grid;
                   
                    //Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_ingreso_det_grid);
                    //gridView1.OptionsView.ColumnAutoWidth = true;
                    //gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;


                    ((GridView)gridControl1.MainView).MoveLast();

                    calculo_total();
                    modo = "consultar";
                    habilitar();
                    Application.DoEvents();
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
                if (modo == "consultar")
                {
                    Cls_Grid.editable_grid(gridControl1, gridView1, true);
                    modo = "modificar";
                    habilitar();
                    e.Handled = true;
                }


            }
            if ("Limpiar".Equals(e.Button.Tag))
            {
                modo = "cancelar";
                habilitar();
                Cls_Grid.editable_grid(gridControl1, gridView1, true);
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


                //frm_ingreso_busca frm = new frm_ingreso_busca();
                //frm.ShowDialog();

                //id_orden_compra = frm.id_orden_compra;
                //if (id_orden_compra == "") return;

                id_ingreso = "I000000004";

                if (dialogResult == DialogResult.Yes) mnt_datos("");

                //filtra_articulo();

                Cls_Grid.editable_grid(gridControl1, gridView1, false);
                Cls_Grid.Visible_Columns(gridView1, dt_t_ingreso_det_grid);
            }

            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {

                e.Handled = true;

                if (cbo_empresa.Enabled == true)
                {
                    if (modo == "nuevo")
                    {
                        if (valida_combo() == true) return;
                    }
                    else
                    {
                        gridView1.AddNewRow();
                        gridView1.FocusedColumn = gridView1.VisibleColumns[0];
                    }

                }
                else
                {
                    modo = "nuevo";
                    habilitar();
                }

            }

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {

                Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_ingreso_det_grid);
                calculo_total();

            }


            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {

                dt_t_ingreso_det_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_ingreso_det_grid);


                if (modo == "nuevo")
                {
                    id_ingreso = "";
                    int count = dt_t_ingreso_det_final.Rows.Count;
                    if (count == 0)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Ingrese detalle del documento.", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
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
            string name = gv.FocusedColumn.FieldName;
            string id_articulo;
            if (name == "id_unidad")
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
               /// var filtro = (from Lista in lista_unidad_almacen.Where(w => (w.id_articulo == id_articulo) && (w.id_tipo_unidad == id_tipo_unidad_almacen_A || w.id_tipo_unidad == id_tipo_unidad_almacen_B)) select Lista).ToList();
                var filtro = (from Lista in lista_tipo_unidad_almacen.Where(w => (w.id_articulo == id_articulo)  ) select Lista).ToList();
                 ///   Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid_Filter_Doble(filtro, 300, 100);

                var filtro_unidad = (from Lista in filtro.Where(w => w.id_tipo_unidad_movi == w.id_tipo_unidad_inventario) select Lista).ToList();
                foreach (var p in filtro_unidad)
                {
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_tipo_unidad_inventario", p.id_tipo_unidad_inventario);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_tipo_unidad_movi", p.id_tipo_unidad_movi);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "factor_movi", p.factor);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_unidad", p.id);//@id_unidad
                }

                var filtro_articulo = (from Lista in lista_articulo.Where(w => w.id == id_articulo) select Lista).ToList();
                foreach (var p in filtro_articulo)
                {
                  gv.SetRowCellValue(gv.FocusedRowHandle, "igv", p.igv);
                  gv.SetRowCellValue(gv.FocusedRowHandle, "isc", p.isc);

                    gv.SetRowCellValue(gv.FocusedRowHandle, "cantidad_nota", 0);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "cantidad_real", 0);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "costo", 0);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "importe", 0);
                }
            }

            if (name == "id_unidad")
            {
                id_articulo = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_articulo"]).ToString();
                id_unidad = e.Value.ToString();
                var filtro = (from Lista in lista_tipo_unidad_almacen.Where(w => w.id_articulo == id_articulo && w.id == id_unidad) select Lista).ToList();
                foreach (var p in filtro)
                {
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_tipo_unidad_inventario", p.id_tipo_unidad_inventario);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "id_tipo_unidad_movi", p.id_tipo_unidad_movi);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "factor", p.factor);

                    gv.SetRowCellValue(gv.FocusedRowHandle, "cantidad_nota", 0);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "cantidad_real", 0);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "costo", 0);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "importe", 0);
                }
              }

            if (name == "cantidad_nota")
            {
               var  cantidad= e.Value.ToString();
                gv.SetRowCellValue(gv.FocusedRowHandle, "cantidad_real", cantidad);
            }

        }

      
        private bool valida_combo()
        {

            if (cbo_empresa.EditValue == null || cbo_empresa.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor Empresa", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }

            if (cbo_centro_costo.EditValue == null || cbo_centro_costo.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor Centro_costo", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }

            if (cbo_almacen.EditValue == null || cbo_almacen.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor Almacen", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }

            if (cbo_moneda.EditValue == null || cbo_moneda.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor moneda", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }

            if (cbo_proveedor.EditValue == null || cbo_proveedor.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor Proveedor", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }

            if (cbo_tipo_ingreso.EditValue == null || cbo_tipo_ingreso.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor tipo de ingreso", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }
            if (cbo_tipo_documento.EditValue == null || cbo_tipo_documento.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor tipo documento", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }

            if (txt_numero_documento.TextLength == 0 || txt_numero_documento.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Ingrese el numero de documento", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }

            filtra_articulo();
            return false;
        }


        private void filtra_articulo()
        {

            //string id2 = cbo_proveedor.EditValue.ToString();
            //string id3 = cbo_moneda.EditValue.ToString();

            //var filtro_articulo = (from Lista in lista_articulo.Where(w => w.id_proveedor == id2 && w.id_moneda == id3) select Lista).ToList();

            //Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, filtro_articulo, "id_articulo", false, 300, 200);




        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {

            GridControl grid = sender as GridControl;

            GridView view = grid.FocusedView as GridView;

            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                if (view.FocusedColumn.FieldName == "importe")
                {
                    gridView1.CloseEditor();
                    gridView1.UpdateCurrentRow();
                    
                    decimal factor = Convert.ToDecimal(view.GetFocusedRowCellValue("factor_movi"));
                    decimal cantidad_nota = Convert.ToDecimal(view.GetFocusedRowCellValue("cantidad_nota"));
                    decimal importe = Convert.ToDecimal(view.GetFocusedRowCellValue("importe"));

                    decimal nuevo_costo = importe /(cantidad_nota / factor) ;
                    view.SetRowCellValue(view.FocusedRowHandle, "costo", nuevo_costo);

                   
                  
                    gridView1.CloseEditor();
                    gridView1.UpdateCurrentRow();
                    calculo_total();
                }

                


            }


        }


        private void habilitar()
        {

            if (modo == "nuevo")
            {
                dt_t_ingreso_det_grid.Clear();
                dt_t_ingreso_det_final.Clear();

                cbo_almacen.Enabled = true;
                cbo_centro_costo.Enabled = true;
                cbo_empresa.Enabled = true;
                cbo_moneda.Enabled = true;
                cbo_proveedor.Enabled = true;
                cbo_tipo_ingreso.Enabled = true;
                cbo_tipo_documento.Enabled = true;

               // cbo_almacen2.Enabled = true;

                dtp_documento.Enabled = true;
           
                txt_comentario.Enabled = true;
                txt_numero_documento.Enabled = true;
                txt_orden_compra.Enabled = true;
                
                txt_orden_compra.Text = "";
                txt_numero_documento.Text = "";

                lbl_estado.Text = "";

            }

            if (modo == "cancelar")
            {
                dt_t_ingreso_det_grid.Clear();
                dt_t_ingreso_det_final.Clear();

                cbo_almacen.Enabled = false;

                //cbo_almacen2.Enabled = false;

                cbo_centro_costo.Enabled = false;
                cbo_empresa.Enabled = false;
                cbo_moneda.Enabled = false;
                cbo_proveedor.Enabled = false;
                cbo_tipo_ingreso.Enabled = false;
                cbo_tipo_documento.Enabled = false;

                dtp_documento.Enabled = false;

                txt_comentario.Enabled = false;
                txt_numero_documento.Enabled = false;
                txt_orden_compra.Enabled = false;

                txt_orden_compra.Text = "";
                txt_numero_documento.Text = "";

                lbl_estado.Text = "";

                cbo_almacen.Text=null;
                cbo_almacen2.Text = null;

                cbo_centro_costo.Text = null;
                cbo_empresa.Text = null;
                cbo_moneda.Text = null;
                cbo_proveedor.Text = null;
                cbo_tipo_ingreso.Text = null;
                cbo_tipo_documento.Text = null;

                calculo_total();

            }


            if (modo == "modificar")
            {
                cbo_almacen.Enabled = true;
                //cbo_almacen2.Enabled = true;

                cbo_centro_costo.Enabled = true;
                cbo_empresa.Enabled = true;
                cbo_moneda.Enabled = true;
                cbo_proveedor.Enabled = true;
                cbo_tipo_ingreso.Enabled = true;
                cbo_tipo_documento.Enabled = true;

                dtp_documento.Enabled = true;

                txt_comentario.Enabled = true;
                txt_numero_documento.Enabled = true;
                txt_orden_compra.Enabled = true;

            }

            if (modo == "consultar")
            {
                cbo_almacen.Enabled = false;
                cbo_almacen2.Enabled = false;

                cbo_centro_costo.Enabled = false;
                cbo_empresa.Enabled = false;
                cbo_moneda.Enabled = false;
                cbo_proveedor.Enabled = false;
                cbo_tipo_ingreso.Enabled = false;
                cbo_tipo_documento.Enabled = false;

                dtp_documento.Enabled = false;

                txt_comentario.Enabled = false;
                txt_numero_documento.Enabled = false;
                txt_orden_compra.Enabled = false;
            }


        }

        public async void calculo_total()
        {

            await Task.Run(new Action(LongTask));
            decimal sub_total = 0;
            decimal igv = 0;
            decimal isc = 0;

            foreach (DataRow row in dt_t_ingreso_det_grid.Rows)
            {
                sub_total = sub_total + (Convert.ToDecimal(row["importe"]));
                      igv = igv + (Convert.ToDecimal(row["importe"])) * (Convert.ToDecimal(row["igv"]))/100;
                      isc = isc + (Convert.ToDecimal(row["importe"])) * (Convert.ToDecimal(row["isc"])) / 100;
            }
            lbl_subtotal.Text = sub_total.ToString("N");
            lbl_igv.Text = igv.ToString("N");
            lbl_isc.Text = isc.ToString("N");
            lbl_total.Text = (sub_total + igv + isc).ToString("N");
        }
        public void LongTask()
        {

            Thread.Sleep(50);
        }



        private void txt_numero_documento_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                if (txt_numero_documento.TextLength!=0 || txt_numero_documento.Text!="" )
                {
                    if (valida_combo() == true) return;

                   cargar_unidad_almacen(cbo_almacen.EditValue.ToString());


                }
            }

        }

        private void gridView1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
             {
                GridView gv = sender as GridView;
                string name = gv.FocusedColumn.FieldName;

                   if (name == "id_articulo" || name == "id_unidad")
                    {
                        var index = gv.Columns["cantidad_nota"].VisibleIndex;
                        gridView1.FocusedColumn = gridView1.VisibleColumns[index];
                    }

                if (name == "costo")
                {
                    gridView1.CloseEditor();
                    gridView1.UpdateCurrentRow();

                    decimal factor = Convert.ToDecimal(gv.GetFocusedRowCellValue("factor_movi"));
                    decimal cantidad_nota = Convert.ToDecimal(gv.GetFocusedRowCellValue("cantidad_nota"));
                    decimal costo = Convert.ToDecimal(gv.GetFocusedRowCellValue("costo"));
                    // var id_articulo = e.Value.ToString();

                    decimal nuevo_importe;

                    nuevo_importe = costo * (cantidad_nota / factor);

                    nuevo_importe = (costo /  factor)* cantidad_nota;

                    gv.SetRowCellValue(gv.FocusedRowHandle, "importe", nuevo_importe);

                    //gridView1.CloseEditor();
                    //gridView1.UpdateCurrentRow();
                    var index = gv.Columns["importe"].VisibleIndex;
                    gridView1.FocusedColumn = gridView1.VisibleColumns[index];
                    calculo_total();
                    // calculo_total();
                }


            }
        }

        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle)
            {
                var editor = (TextEdit)gridView1.ActiveEditor;
                editor.SelectionLength = 0;
                editor.SelectionStart = editor.Text.Length;
            }
        }

  
        private void cbo_almacen_EditValueChanged(object sender, EventArgs e)
        {

            if (cbo_almacen.Enabled == true)
            {
                string id2 = cbo_almacen.EditValue.ToString();
                var filtro_almacen2 = (from Lista in lista_almacen.Where(w => w.id != id2) select Lista).ToList();
                Cls_Grid.Load_Combo_GridLookUpEdit(cbo_almacen2, filtro_almacen2, false, cbo_almacen2.Width, 100);
            }



        }

        private void cbo_tipo_ingreso_EditValueChanged(object sender, EventArgs e)
        {
            if (cbo_tipo_ingreso.Enabled == true)
            {
                string id2 = cbo_tipo_ingreso.EditValue.ToString();
                bool transferencia = Convert.ToBoolean((from Lista in lista_tipo_ingreso.Where(w => w.id == id2) select Lista.flatmodtransf).First().ToString());
                cbo_almacen2.Enabled = transferencia;
              
                cbo_almacen2.EditValue = null;
            
            }
            else
            {
                cbo_almacen2.Enabled = false;
                cbo_almacen2.EditValue = null;
                cbo_almacen2.Text = "";
            }
            
            
        }
    }
}
