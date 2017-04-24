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
    public partial class frm_orden_compra : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;
        string id_orden_compra = "";
        string modo="nuevo";
        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();

        List<EN_orden_compra.t_orden_compra_det> t_orden_compra_det = new List<EN_orden_compra.t_orden_compra_det>();
        DataTable dt_t_orden_compra_det_grid = new DataTable();
        DataTable dt_t_orden_compra_det_final = new DataTable();
        
        List<EN_orden_compra.lista_articulo> lista_articulo = new List<EN_orden_compra.lista_articulo>();

    
        public frm_orden_compra()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_orden_compra_Load);
            this.gridView1.CustomRowCellEditForEditing += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridView1_CustomRowCellEditForEditing);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            this.cbo_moneda.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbo_moneda_KeyDown);
            this.gridControl1.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gridControl1_ProcessGridKey);

            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;
            labelControl1.Text = "Orden de Compra";

            this.Width = 640;
            this.Height = 600;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 2);

            gridControl1.Width = this.Width - 4;
          //  gridControl1.Height = this.Height - panel1.Height - 30;
            gridControl1.Left = 1;

        }

        private void frm_orden_compra_Load(object sender, EventArgs e)
        {

            inicio();
        }

        private void inicio()
        {
            dt_t_orden_compra_det_grid = Cls_Grid.ListToTable(t_orden_compra_det);
            dt_t_orden_compra_det_final = Cls_Grid.ListToTable(t_orden_compra_det);

            gridControl1.DataSource = dt_t_orden_compra_det_grid;
     
            DevExpress.XtraGrid.Columns.GridColumn col_costo = gridView1.Columns["costo"];
            col_costo.OptionsColumn.AllowEdit = false;
            col_costo.OptionsColumn.AllowFocus = false;
            DevExpress.XtraGrid.Columns.GridColumn col_unidad = gridView1.Columns["unidad"];
            col_unidad.OptionsColumn.AllowEdit = false;
            col_unidad.OptionsColumn.AllowFocus = false;


            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_orden_compra_det_grid);
            cargar_combo();
           
            modo = "cancelar";
            habilitar();
        }



        private void cargar_combo()
        {
            var negocio = new LN_orden_compra();
            var retorno = new EN_orden_compra.proc_orden_compra_mnt_combo();

            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_orden_compra_mnt_combo();
            if (Cls_Grid.ExisteError(retorno.informe))
            {
                Cursor.Current = Cursors.Default;
                this.Close();
                return;
            }


            Cls_Grid.Load_Combo_GridLookUpEdit(cbo_empresa, retorno.empresa, false, cbo_empresa.Width, 300);
            Cls_Grid.Load_Combo_GridLookUpEdit(cbo_centro_costo, retorno.centro_costo, false, cbo_centro_costo.Width, 300);
            Cls_Grid.Load_Combo_GridLookUpEdit(cbo_almacen, retorno.almacen, false, cbo_almacen.Width, 300);
            Cls_Grid.Load_Combo_GridLookUpEdit(cbo_proveedor, retorno.proveedor, false, cbo_proveedor.Width, 300);
            Cls_Grid.Load_Combo_GridLookUpEdit(cbo_moneda, retorno.moneda, false, cbo_moneda.Width, 300);
            
            lista_articulo = retorno.articulo;
            Application.DoEvents();
            Cursor.Current = Cursors.Default;
        }


        private void mnt_datos(string id_usuario)
        {

            try
            {   

                t_orden_compra_det =dt_t_orden_compra_det_final.Tabla_a_Lista<EN_orden_compra.t_orden_compra_det>().ToList();

                var negocio = new LN_orden_compra();
                var parametro = new EN_orden_compra.proc_orden_compra_mnt();
                var retorno = new EN_orden_compra.proc_orden_compra_mnt_retorno();
                var t_orden_compra = new List<EN_orden_compra.t_orden_compra>();


                if (id_usuario !="") { 

                    var cab = new EN_orden_compra.t_orden_compra();
                    string estado = "EST0000001";
                    int count = dt_t_orden_compra_det_final.AsEnumerable()
                                   .Count(row => row.Field<string>("id_usuario_ultimo").Equals("nuevo")
                                              || row.Field<string>("id_usuario_ultimo").Equals("grabado")
                                              || row.Field<string>("id_usuario_ultimo").Equals("modificar"));



                    if (count == 0) estado = "EST0000002";
                
                    cab.id_orden_compra= id_orden_compra;
                    cab.id_empresa=cbo_empresa.EditValue.ToString();
                    cab.numero="0001";
                    cab.id_centro_costo=cbo_centro_costo.EditValue.ToString();
                    cab.id_almacen=cbo_almacen.EditValue.ToString();
                    cab.id_proveedor=cbo_proveedor.EditValue.ToString();
                    cab.fecha_emision = dtp_emision.Value;
                    cab.fecha_entrega=dtp_entrega.Value;
                    cab.id_moneda=cbo_moneda.EditValue.ToString();
                    cab.tipo_cambio=Convert.ToDecimal(3.3);
                    cab.comentario = "";
                    cab.fecha_pago=Convert.ToDateTime("01/01/2016");
                    cab.id_estado_cab=estado;
                    cab.id_usuario_inicia=id_usuario;
                    cab.id_usuario_ultimo= modo;
                    cab.fecha_inicia = Convert.ToDateTime("01/01/2016"); 
                    cab.fecha_ultimo = Convert.ToDateTime("01/01/2016");
                    cab.comentario = txt_comentario.Text;
              
                    t_orden_compra.Add(cab);

                   }
                ///----parametros a enviar.
                parametro.id_usuario = id_usuario;
                parametro.id_orden_compra = id_orden_compra;
                parametro.t_orden_compra = t_orden_compra;
                parametro.t_orden_compra_det = t_orden_compra_det;

                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_orden_compra_mnt(parametro);
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
                   
                    foreach (var p in retorno.t_orden_compra )
                       {
                        id_orden_compra=p.id_orden_compra ;
                        cbo_empresa.EditValue=p.id_empresa;
                        lbl_id_orden_compra.Text= p.id_orden_compra;
                        cbo_centro_costo.EditValue= p.id_centro_costo ;
                        cbo_almacen.EditValue=p.id_almacen ;
                        cbo_proveedor.EditValue=p.id_proveedor;
                        dtp_emision.Value= p.fecha_emision ;
                        dtp_entrega.Value= p.fecha_entrega  ;
                        cbo_moneda.EditValue=p.id_moneda ;
                        txt_comentario.Text= p.comentario;
                        lbl_estado.Text = p.estado_cab;
                       
                      }
                    retorno.t_orden_compra_det.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });
                    dt_t_orden_compra_det_grid = Cls_Grid.ListToTable(retorno.t_orden_compra_det);
                    gridControl1.DataSource = dt_t_orden_compra_det_grid;

                    DevExpress.Utils.FormatInfo fi = new DevExpress.Utils.FormatInfo();
                    fi.FormatType = DevExpress.Utils.FormatType.Numeric;
                    fi.FormatString = "n3";
                    gridView1.Columns["canti_pedida"].DisplayFormat.Assign(fi);
                    fi.FormatString = "n2";
                    gridView1.Columns["costo"].DisplayFormat.Assign(fi);

                    ((GridView)gridControl1.MainView).MoveLast();
          
                    calculo_total();
                    modo = "consultar";
                    habilitar();
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


                frm_orden_compra_busca frm = new frm_orden_compra_busca();
                frm.ShowDialog();

                id_orden_compra = frm.id_orden_compra;
                if (id_orden_compra == "") return;


                if (dialogResult == DialogResult.Yes) mnt_datos("");

                  filtra_articulo();
                 
                Cls_Grid.editable_grid(gridControl1, gridView1, false);
                Cls_Grid.Visible_Columns(gridView1, dt_t_orden_compra_det_grid);
            }

            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {

                e.Handled = true;
 
                if (cbo_empresa.Enabled==true)
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
                
                Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_orden_compra_det_grid);
                calculo_total();
               
            }


            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {

               dt_t_orden_compra_det_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_orden_compra_det_grid);

                
                if (modo == "nuevo")
                {
                    id_orden_compra = "";
                    int count = dt_t_orden_compra_det_final.Rows.Count;
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
            //GridView gv = sender as GridView;
            //string id = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_articulo"]).ToString();

            //filtrar_datos(sender, id);
           
        }



        private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            string id = e.Value.ToString();
            filtrar_datos (sender,id);
            calculo_total();
        }

        private void filtrar_datos(object sender, string valor)
        {
            GridView gv = sender as GridView;
            if (gv.FocusedColumn.FieldName == "id_articulo")
              {
                string id2;
                List<EN_orden_compra.lista_articulo> filtro = new List<EN_orden_compra.lista_articulo>();
                id2 = valor;
                filtro = (from Lista in lista_articulo.Where(w => w.id == id2) select Lista).ToList();

                foreach (var p in filtro)
                {
                    gv.SetRowCellValue(gv.FocusedRowHandle, "costo", p.costo);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "unidad", p.unidad);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "igv", p.igv);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "isc", p.isc);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "activa_limite", p.activa_limite);
                    gv.SetRowCellValue(gv.FocusedRowHandle, "cantidad_limite", p.cantidad_limite);
                
                }
               
                calculo_total();
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
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor Proveedor", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }

            if (cbo_proveedor .EditValue == null || cbo_proveedor.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor Proveedor", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }


            filtra_articulo();
            return false;
        }


        private void filtra_articulo()
        {

         string id2 = cbo_proveedor.EditValue.ToString();
         string id3 = cbo_moneda.EditValue.ToString();

            var filtro_articulo = (from Lista in lista_articulo.Where(w => w.id_proveedor == id2 && w.id_moneda==id3) select Lista).ToList();
 
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, filtro_articulo, "id_articulo", false, 300, 200);




        }

        private void gridControl1_ProcessGridKey(object sender, KeyEventArgs e)
        {

            GridControl grid = sender as GridControl;

            GridView view = grid.FocusedView as GridView;

            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
              {
                if (view.FocusedColumn.FieldName == "canti_pedida")
                {
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
                cbo_almacen.Enabled = true;
                cbo_centro_costo.Enabled = true;
                cbo_empresa.Enabled = true;
                cbo_moneda.Enabled = true;
                cbo_proveedor.Enabled = true;
                dtp_emision.Enabled = true;
                dtp_entrega.Enabled = true;
                txt_comentario.Enabled = true;
                cbo_empresa.Focus();
                dt_t_orden_compra_det_grid.Clear();
                lbl_estado.Text = "";
                lbl_id_orden_compra.Text = "";
            }

            if (modo == "cancelar")
            {
                dt_t_orden_compra_det_grid.Clear();
                dt_t_orden_compra_det_final.Clear();
                cbo_almacen.Enabled = false;
                cbo_centro_costo.Enabled = false;
                cbo_empresa.Enabled = false;
                cbo_moneda.Enabled = false;
                cbo_proveedor.Enabled = false;
                dtp_emision.Enabled = false;
                dtp_entrega.Enabled = false;
                txt_comentario.Enabled = false;
                txt_comentario.Text = "";
                cbo_empresa.Text = null;
                cbo_centro_costo.Text = null;
                cbo_centro_costo.Text = null;
                cbo_proveedor.Text = null;
                cbo_almacen.Text = null;
                lbl_estado.Text = "";
                lbl_id_orden_compra.Text = "";
                calculo_total();
               
            }


            if (modo == "modificar")
            {
                cbo_almacen.Enabled = true;
                cbo_centro_costo.Enabled = true;
                cbo_empresa.Enabled = true;
                cbo_moneda.Enabled = false;
                cbo_proveedor.Enabled = false;
                dtp_emision.Enabled = true;
                dtp_entrega.Enabled = true;
                txt_comentario.Enabled = true;
            }

            if (modo=="consultar")
            {

                cbo_almacen.Enabled = false;
                cbo_centro_costo.Enabled = false;
                cbo_empresa.Enabled = false;
                cbo_moneda.Enabled = false;
                cbo_proveedor.Enabled = false;
                dtp_emision.Enabled = false;
                dtp_entrega.Enabled = false;
                txt_comentario.Enabled = false;
            }


        }

        public  async void calculo_total()
        {

            await Task.Run(new Action(LongTask));
            decimal t = 0;
            foreach (DataRow row in dt_t_orden_compra_det_grid.Rows)
            {
                t = t + (Convert.ToDecimal(row["canti_pedida"]) * Convert.ToDecimal(row["costo"]));

            }
            lbl_total_orden.Text = t.ToString("N");
        }
        public  void LongTask()
        {

            Thread.Sleep(50);
        }

 

        private void cbo_moneda_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Tab || e.KeyCode == Keys.Enter)
            {
                if (cbo_moneda.EditValue != null)
                {
                    if (valida_combo() == true) return;

                    gridView1.Focus();
                    gridView1.AddNewRow();
                    gridView1.FocusedColumn = gridView1.VisibleColumns[0];

                }
            }

        }
    }
}
