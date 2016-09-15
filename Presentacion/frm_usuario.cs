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

        public frm_usuario()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_usuario_Load);
            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;
            labelControl1.Text = "Mantenimiento de usuarios";



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
            cargar_combo();
            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_usuario_grid);

        }



        private void cargar_combo()
        {
            var negocio = new LN_usuario();
            var retorno = new EN_usuario.proc_usuario_mnt_combo();

            Cursor.Current = Cursors.WaitCursor;
            retorno = negocio.proc_usuario_mnt_combo();
            Cursor.Current = Cursors.Default;
            if (Cls_Grid.ExisteError(retorno.informe)) return;

            Cls_Grid.Load_Combo(gridView1, retorno.area, "id_area", false);
            Cls_Grid.Load_Combo(gridView1, retorno.cargo, "id_cargo", false);
            Cls_Grid.Load_Combo(gridView1, retorno.departamento, "id_departamento", false);
            Cls_Grid.Load_Combo(gridView1, retorno.tipodocu_personal, "id_tipodocu_personal", false);
           
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





    }
}