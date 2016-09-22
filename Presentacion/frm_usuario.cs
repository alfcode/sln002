﻿using System;
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
    public partial class frm_usuario : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;

        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();
        List<EN_usuario.t_usuario> t_usuario = new List<EN_usuario.t_usuario>();
        DataTable dt_t_usuario_grid = new DataTable();
        DataTable dt_t_usuario_final = new DataTable();

        List<EN_zero.datacombo> lista_cargo = new List<EN_zero.datacombo>();
        List<EN_zero.datacombo> lista_provincia = new List<EN_zero.datacombo>();
        List<EN_zero.datacombo> lista_distrito = new List<EN_zero.datacombo>();


        public frm_usuario()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_usuario_Load);
            this.gridView1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.gridView1_ShowingEditor);

            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;

            labelControl1.Text = "Usuarios";

            this.Width = 1000;
            this.Height = 400;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 5);



        }

        private void frm_usuario_Load(object sender, EventArgs e)
        {

            inicio();
        }

        private void inicio()
        {
            dt_t_usuario_grid = Cls_Grid.ListToTable(t_usuario);
            dt_t_usuario_final = Cls_Grid.ListToTable(t_usuario);

            gridControl1.DataSource = dt_t_usuario_grid;
            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_usuario_grid);
            cargar_combo();

        }



        private void cargar_combo()
        {
            var negocio = new LN_usuario();
            var retorno = new EN_usuario.proc_usuario_mnt_combo();

            Application.DoEvents();
            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_usuario_mnt_combo();
            Cursor.Current = Cursors.Default;
            if (Cls_Grid.ExisteError(retorno.informe)) return;

            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.area, "id_area", false,300,150);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.departamento, "id_departamento", false, 300, 150);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, retorno.tipodocu_personal, "id_tipodocu_personal", false, 300, 150);
            lista_cargo = retorno.cargo;
            lista_provincia = retorno.provincia;
            lista_distrito = retorno.distrito;
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, lista_cargo, "id_cargo", false, 300, 150);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, lista_provincia, "id_provincia", false, 300, 150);
            Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, lista_distrito, "id_distrito", false, 300, 150);


          

        }


        private void mnt_datos(string id_usuario)
        {

            try
            {

                t_usuario = dt_t_usuario_final.DataTableToList<EN_usuario.t_usuario>().ToList();
                var negocio = new LN_usuario();
                var parametro = new EN_usuario.proc_usuario_mnt();
                var retorno = new EN_usuario.proc_usuario_mnt_retorno();

                parametro.id_usuario = id_usuario;
                parametro.t_usuario = t_usuario;

                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_usuario_mnt(parametro);
                Cursor.Current = Cursors.Default;

                if (Cls_Grid.ExisteError(retorno.informe))
                {
                    return;
                }

                if (id_usuario != "")
                {
                    dt_t_usuario_grid.Clear();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_exito, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    retorno.t_usuario.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });
                    dt_t_usuario_grid = Cls_Grid.ListToTable(retorno.t_usuario);

                    gridControl1.DataSource = dt_t_usuario_grid;
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
                dt_t_usuario_grid.Clear();
                gridControl1.DataSource = dt_t_usuario_grid;
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

                // dt_t_usuario_grid.Clear();
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];

            }

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_usuario_grid);
            }


            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {

                dt_t_usuario_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_usuario_grid);

                int count = dt_t_usuario_final.Rows.Count;
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

        private void gridView1_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
        {

            GridView gv = sender as GridView;
            
               
            if (gv.FocusedColumn.FieldName == "id_provincia")
            {
                string id2 = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_departamento"]).ToString();
                var filtro_provincia = (from Lista in lista_provincia.Where(w => w.id2 == id2) select Lista).ToList();
                Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, filtro_provincia, "id_provincia", false, 300, 150);


            }

            if (gv.FocusedColumn.FieldName == "id_distrito")
            {
                string id2 = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_provincia"]).ToString();
                var filtro_distrito = (from Lista in lista_distrito.Where(w => w.id2 == id2) select Lista).ToList();
                Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, filtro_distrito, "id_distrito", false, 300, 150);
            }


            if (gv.FocusedColumn.FieldName == "id_cargo")
            {
                string id2 = gv.GetRowCellValue(gv.FocusedRowHandle, gv.Columns["id_area"]).ToString();
                var filtro_cargo = (from Lista in lista_cargo.Where(w => w.id2 == id2) select Lista).ToList();
                Cls_Grid.Load_Combo_GridLookUpEdit_In_Grid(gridView1, filtro_cargo, "id_cargo", false, 300, 150);
            }

        }
    }
}
