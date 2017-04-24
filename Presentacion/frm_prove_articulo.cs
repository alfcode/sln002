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
    public partial class frm_prove_articulo : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;

        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();
        List<EN_prove_articulo.t_prove_articulo> t_prove_articulo = new List<EN_prove_articulo.t_prove_articulo>();
        DataTable dt_t_prove_articulo_grid = new DataTable();
        DataTable dt_t_prove_articulo_final = new DataTable();

        List<EN_zero.datacombo> lista_proveedor = new List<EN_zero.datacombo>();
        List<EN_zero.datacombo> lista_articulo = new List<EN_zero.datacombo>();

        string id_cbo_proveedor = "";
        public frm_prove_articulo()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_prove_articulo_Load);
            this.cbo_proveedor.EditValueChanged += new System.EventHandler(this.cbo_proveedor_EditValueChanged);
            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;
            labelControl1.Text = "Proveedor Articulo Costo";

            this.Width = 740;
            this.Height = 400;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 5);
            gridControl1.Width = this.Width-1;
            gridControl1.Height = this.Height-panel1.Height-28;
        }

        private void frm_prove_articulo_Load(object sender, EventArgs e)
        {

            inicio();
        }

        private void inicio()
        {
            dt_t_prove_articulo_grid = Cls_Grid.ListToTable(t_prove_articulo);
            dt_t_prove_articulo_final = Cls_Grid.ListToTable(t_prove_articulo);

            gridControl1.DataSource = dt_t_prove_articulo_grid;

            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_prove_articulo_grid);
            cargar_combo();
        }



        private void cargar_combo()
        {
            var negocio = new LN_prove_articulo();
            var retorno = new EN_prove_articulo.proc_prove_articulo_mnt_combo();

            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_prove_articulo_mnt_combo();
            if (Cls_Grid.ExisteError(retorno.informe))
            {
                Cursor.Current = Cursors.Default;
                this.Close();
                return;
            }

            Cls_Grid.Load_Combo_GridLookUpEdit(cbo_proveedor, retorno.proveedor, false, cbo_proveedor.Width, 300);

            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.moneda, "id_moneda", true, 80, 200);

            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.articulo, "id_articulo", true, 330, 200);
 
                       Application.DoEvents();
            Cursor.Current = Cursors.Default;
        }


        private void mnt_datos(string id_usuario)
        {

            try
            {

                t_prove_articulo = dt_t_prove_articulo_final.DataTableToList<EN_prove_articulo.t_prove_articulo>().ToList();
                var negocio = new LN_prove_articulo();
                var parametro = new EN_prove_articulo.proc_prove_articulo_mnt();
                var retorno = new EN_prove_articulo.proc_prove_articulo_mnt_retorno();

                parametro.id_usuario = id_usuario;
                parametro.id_proveedor = id_cbo_proveedor;
                parametro.t_prove_articulo = t_prove_articulo;


                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_prove_articulo_mnt(parametro);
                Cursor.Current = Cursors.Default;

                if (Cls_Grid.ExisteError(retorno.informe))
                {
                    return;
                }

                if (id_usuario != "")
                {
                    dt_t_prove_articulo_grid.Clear();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_exito, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    retorno.t_prove_articulo.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });
                    dt_t_prove_articulo_grid = Cls_Grid.ListToTable(retorno.t_prove_articulo);

                    gridControl1.DataSource = dt_t_prove_articulo_grid;
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
                dt_t_prove_articulo_grid.Clear();
                gridControl1.DataSource = dt_t_prove_articulo_grid;
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
                   id_cbo_proveedor = cbo_proveedor.EditValue.ToString();
                mnt_datos("");

                dt_t_prove_articulo_grid.Columns["id_proveedor"].DefaultValue = id_cbo_proveedor;

                Cls_Grid.editable_grid(gridControl1, gridView1, false);
                e.Handled = true;

            }



            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                e.Handled = true;

                if (valida_combo() == true) return;

                dt_t_prove_articulo_grid.Columns["id_proveedor"].DefaultValue = cbo_proveedor.EditValue.ToString();

                e.Handled = false;

                gridView1.FocusedColumn = gridView1.VisibleColumns[0];

            }

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_prove_articulo_grid);
            }


            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {

                dt_t_prove_articulo_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_prove_articulo_grid);

                int count = dt_t_prove_articulo_final.Rows.Count;
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


        private void cbo_proveedor_EditValueChanged(object sender, EventArgs e)
        {
            dt_t_prove_articulo_grid.Clear();
        }


        private bool valida_combo()
        {
         
            if (cbo_proveedor.EditValue == null || cbo_proveedor.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor Proveedor", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }


            return false;
        }


    }
}
