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
    public partial class frm_pais : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;

        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();
        List<EN_pais.t_pais> t_pais = new List<EN_pais.t_pais>();
        DataTable dt_t_pais_grid = new DataTable();
        DataTable dt_t_pais_final = new DataTable();

        public frm_pais()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_pais_Load);
            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;

            labelControl1.Text = " paiss";

            this.Width = 735;
            this.Height = 400;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 5);


        }

        private void frm_pais_Load(object sender, EventArgs e)
        {

            inicio();
        }

        private void inicio()
        {
            dt_t_pais_grid = Cls_Grid.ListToTable(t_pais);
            dt_t_pais_final = Cls_Grid.ListToTable(t_pais);

            gridControl1.DataSource = dt_t_pais_grid;
        
            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_pais_grid);

        }




        private void mnt_datos(string id_usuario)
        {

            try
            {

                t_pais = dt_t_pais_final.DataTableToList<EN_pais.t_pais>().ToList();
                var negocio = new LN_pais();
                var parametro = new EN_pais.proc_pais_mnt();
                var retorno = new EN_pais.proc_pais_mnt_retorno();

                parametro.id_usuario = id_usuario;
                parametro.t_pais = t_pais;

                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_pais_mnt(parametro);
                Cursor.Current = Cursors.Default;

                if (Cls_Grid.ExisteError(retorno.informe))
                {
                    return;
                }

                if (id_usuario != "")
                {
                    dt_t_pais_grid.Clear();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_exito, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    retorno.t_pais.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });
                    dt_t_pais_grid = Cls_Grid.ListToTable(retorno.t_pais);

                    gridControl1.DataSource = dt_t_pais_grid;
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


            if ("Limpiar".Equals(e.Button.Tag))
            {
                dt_t_pais_grid.Clear();
                gridControl1.DataSource = dt_t_pais_grid;
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

                if (dialogResult == DialogResult.Yes)
                    mnt_datos("");
                e.Handled = true;

            }



            if (e.Button.ButtonType == NavigatorButtonType.Append)
            {

                // dt_t_pais_grid.Clear();
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];

            }

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_pais_grid);
            }


            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {

                dt_t_pais_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_pais_grid);

                int count = dt_t_pais_final.Rows.Count;
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





    }
}
