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
    public partial class frm_distrito : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;

        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();
        List<EN_distrito.t_distrito> t_distrito = new List<EN_distrito.t_distrito>();
        DataTable dt_t_distrito_grid = new DataTable();
        DataTable dt_t_distrito_final = new DataTable();

        List<EN_zero.datacombo> lista_provincia = new List<EN_zero.datacombo>();

        string id_provincia = "";

        public frm_distrito()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_distrito_Load);
            this.cbo_departamento.EditValueChanged += new System.EventHandler(this.cbo_departamento_EditValueChanged);
            this.cbo_provincia.EditValueChanged += new System.EventHandler(this.cbo_provincia_EditValueChanged);
            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;

            labelControl1.Text = "Distritos";

            this.Width = 500;
            this.Height = 400;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 5);

            gridControl1.Width = this.Width - 4;
            gridControl1.Height = this.Height - panel1.Height - 30;
            gridControl1.Left = 1;

        }

        private void frm_distrito_Load(object sender, EventArgs e)
        {
            inicio();
        }

        private void inicio()
        {
            dt_t_distrito_grid = Cls_Grid.ListToTable(t_distrito);
            dt_t_distrito_final = Cls_Grid.ListToTable(t_distrito);
            gridControl1.DataSource = dt_t_distrito_grid;
            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_distrito_grid);
            cargar_combo();
        }



        private void cargar_combo()
        {
            var negocio = new LN_distrito();
            var retorno = new EN_distrito.proc_distrito_mnt_combo();
            var parametros = new EN_distrito.proc_distrito_mnt_combo();

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_distrito_mnt_combo();
            if (Cls_Grid.ExisteError(retorno.informe))
            {
                Cursor.Current = Cursors.Default;
                this.Close();
                return;
            }
            Cls_Grid.Load_Combo_GridLookUpEdit(cbo_departamento, retorno.departamento, false, cbo_departamento.Width, 100);
            lista_provincia = retorno.provincia;
            Application.DoEvents();
            Cursor.Current = Cursors.Default;

        }


        private void mnt_datos(string id_usuario)
        {

            try
            {

                t_distrito = dt_t_distrito_final.DataTableToList<EN_distrito.t_distrito>().ToList();
                var negocio = new LN_distrito();
                var parametro = new EN_distrito.proc_distrito_mnt();
                var retorno = new EN_distrito.proc_distrito_mnt_retorno();

                parametro.id_usuario = id_usuario;
                parametro.id_provincia = id_provincia;
                parametro.t_distrito = t_distrito;

                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_distrito_mnt(parametro);
                Cursor.Current = Cursors.Default;

                if (Cls_Grid.ExisteError(retorno.informe))
                {
                    return;
                }

                if (id_usuario != "")
                {
                    dt_t_distrito_grid.Clear();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_exito, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    retorno.t_distrito.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });
                    dt_t_distrito_grid = Cls_Grid.ListToTable(retorno.t_distrito);

                    gridControl1.DataSource = dt_t_distrito_grid;
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
                dt_t_distrito_grid.Clear();
                gridControl1.DataSource = dt_t_distrito_grid;
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
                    id_provincia= cbo_provincia.EditValue.ToString();
                    mnt_datos("");
                    dt_t_distrito_grid.Columns["id_provincia"].DefaultValue = id_provincia;


                Cls_Grid.editable_grid(gridControl1, gridView1, false);
                e.Handled = true;

            }



            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {
                e.Handled = true;

                if (valida_combo() == true) return; 

                dt_t_distrito_grid.Columns["id_provincia"].DefaultValue = cbo_provincia.EditValue.ToString();

                e.Handled = false;

                gridView1.FocusedColumn = gridView1.VisibleColumns[0];

            }

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_distrito_grid);
            }


            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {

                dt_t_distrito_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_distrito_grid);

                int count = dt_t_distrito_final.Rows.Count;
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
            dt_t_distrito_grid.Clear();
           
            string id2 = cbo_departamento.EditValue.ToString();
            var filtro_provincia = (from Lista in lista_provincia.Where(w => w.id2 == id2) select Lista).ToList();
            Cls_Grid.Load_Combo_GridLookUpEdit(cbo_provincia, filtro_provincia, false, cbo_provincia.Width,100);
           
        }

        private void cbo_provincia_EditValueChanged(object sender, EventArgs e)
        {
            dt_t_distrito_grid.Clear();
        }


        private bool valida_combo()
        {
            if (cbo_departamento.EditValue == null || cbo_departamento.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor Departamento", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }

            if (cbo_provincia.EditValue == null || cbo_provincia.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Seleccion el valor Provincia", Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                return true;
            }


            return false;
        }

       
    }
}
