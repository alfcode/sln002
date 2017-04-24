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
    public partial class frm_grupo3 : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;

        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();
        List<EN_grupo3.t_grupo3> t_grupo3 = new List<EN_grupo3.t_grupo3>();
        DataTable dt_t_grupo3_grid = new DataTable();
        DataTable dt_t_grupo3_final = new DataTable();

        List<EN_zero.datacombo> lista_grupo2 = new List<EN_zero.datacombo>();

        string id_cbo_A = "";

        public frm_grupo3()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_grupo3_Load);
            this.cbo_1.EditValueChanged += new System.EventHandler(this.cbo_departamento_EditValueChanged);
            this.cbo_2.EditValueChanged += new System.EventHandler(this.cbo_provincia_EditValueChanged);
            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;

            labelControl1.Text = "Catálogo-Categoría";

            this.Width = 500;
            this.Height = 400;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 5);

            gridControl1.Width = this.Width - 4;
            gridControl1.Height = this.Height - panel1.Height - 30;
            gridControl1.Left = 1;

        }

        private void frm_grupo3_Load(object sender, EventArgs e)
        {
            inicio();
        }

        private void inicio()
        {
            dt_t_grupo3_grid = Cls_Grid.ListToTable(t_grupo3);
            dt_t_grupo3_final = Cls_Grid.ListToTable(t_grupo3);
            gridControl1.DataSource = dt_t_grupo3_grid;
            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_grupo3_grid);
            cargar_combo();
        }



        private void cargar_combo()
        {
            var negocio = new LN_grupo3();
            var retorno = new EN_grupo3.proc_grupo3_mnt_combo();
            var parametros = new EN_grupo3.proc_grupo3_mnt_combo();

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_grupo3_mnt_combo();
            if (Cls_Grid.ExisteError(retorno.informe))
            {
                Cursor.Current = Cursors.Default;
                this.Close();
                return;
            }
            Cls_Grid.Load_Combo_GridLookUpEdit(cbo_1, retorno.grupo1, false, cbo_1.Width, 300);
            lista_grupo2 = retorno.grupo2;
            Application.DoEvents();
            Cursor.Current = Cursors.Default;

        }


        private void mnt_datos(string id_usuario)
        {

            try
            {

                t_grupo3 = dt_t_grupo3_final.DataTableToList<EN_grupo3.t_grupo3>().ToList();
                var negocio = new LN_grupo3();
                var parametro = new EN_grupo3.proc_grupo3_mnt();
                var retorno = new EN_grupo3.proc_grupo3_mnt_retorno();

                parametro.id_usuario = id_usuario;
                parametro.id_grupo2 = id_cbo_A;
                parametro.t_grupo3 = t_grupo3;

                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_grupo3_mnt(parametro);
                Cursor.Current = Cursors.Default;

                if (Cls_Grid.ExisteError(retorno.informe))
                {
                    return;
                }

                if (id_usuario != "")
                {
                    dt_t_grupo3_grid.Clear();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_exito, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    retorno.t_grupo3.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });
                    dt_t_grupo3_grid = Cls_Grid.ListToTable(retorno.t_grupo3);

                    gridControl1.DataSource = dt_t_grupo3_grid;
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
                dt_t_grupo3_grid.Clear();
                gridControl1.DataSource = dt_t_grupo3_grid;
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
                    id_cbo_A = cbo_2.EditValue.ToString();
                mnt_datos("");
                dt_t_grupo3_grid.Columns["id_grupo2"].DefaultValue = id_cbo_A;

                Cls_Grid.editable_grid(gridControl1, gridView1, false);
                e.Handled = true;

            }



            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                e.Handled = true;

                if (valida_combo() == true) return;

                dt_t_grupo3_grid.Columns["id_grupo2"].DefaultValue = cbo_2.EditValue.ToString();

                e.Handled = false;

                gridView1.FocusedColumn = gridView1.VisibleColumns[0];

            }

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_grupo3_grid);
            }


            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {

                dt_t_grupo3_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_grupo3_grid);

                int count = dt_t_grupo3_final.Rows.Count;
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

        private void cbo_departamento_EditValueChanged(object sender, EventArgs e)
        {
            dt_t_grupo3_grid.Clear();

            string id2 = cbo_1.EditValue.ToString();
            var filtro = (from Lista in lista_grupo2.Where(w => w.id2 == id2) select Lista).ToList();
            Cls_Grid.Load_Combo_GridLookUpEdit(cbo_2, filtro, false, cbo_2.Width, 100);

        }

        private void cbo_provincia_EditValueChanged(object sender, EventArgs e)
        {
            dt_t_grupo3_grid.Clear();
        }


        private bool valida_combo()
        {
            if (cbo_1.EditValue == null || cbo_1.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor Linea", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }

            if (cbo_2.EditValue == null || cbo_2.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor Familia", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }


            return false;
        }


    }
}
