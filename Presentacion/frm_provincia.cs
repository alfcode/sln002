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
    public partial class frm_provincia : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;

        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();
        List<EN_provincia.t_provincia> t_provincia = new List<EN_provincia.t_provincia>();
        DataTable dt_t_provincia_grid = new DataTable();
        DataTable dt_t_provincia_final = new DataTable();
        string id_departamento = "";

        public frm_provincia()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_provincia_Load);
            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;
            labelControl1.Text = "Mantenimiento de provincias";



        }

        private void frm_provincia_Load(object sender, EventArgs e)
        {

            inicio();
        }

        private void inicio()
        {
            dt_t_provincia_grid = Cls_Grid.ListToTable(t_provincia);
            dt_t_provincia_final = Cls_Grid.ListToTable(t_provincia);

            gridControl1.DataSource = dt_t_provincia_grid;
            cargar_combo();
            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_provincia_grid);

        }



        private void cargar_combo()
        {
            var negocio = new LN_provincia();
            var retorno = new EN_provincia.proc_provincia_mnt_combo();
            var parametros = new EN_provincia.proc_provincia_mnt_combo_parametro();
            Cursor.Current = Cursors.WaitCursor;

            parametros.id_departamento = id_departamento;

            retorno = negocio.proc_provincia_mnt_combo(parametros);
            Cursor.Current = Cursors.Default;
            if (Cls_Grid.ExisteError(retorno.informe)) return;

            Cls_Grid.Load_Combo(gridView1, retorno.provincia, "id_provincia", true);
        }


        private void mnt_datos(string id_usuario)
        {

            try
            {

                t_provincia = dt_t_provincia_final.DataTableToList<EN_provincia.t_provincia>().ToList();
                var negocio = new LN_provincia();
                var parametro = new EN_provincia.proc_provincia_mnt();
                var retorno = new EN_provincia.proc_provincia_mnt_retorno();

                parametro.id_usuario = id_usuario;
                parametro.t_provincia = t_provincia;

                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_provincia_mnt(parametro);
                Cursor.Current = Cursors.Default;

                if (Cls_Grid.ExisteError(retorno.informe))
                {
                    return;
                }

                if (id_usuario != "")
                {
                    dt_t_provincia_grid.Clear();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_exito, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    retorno.t_provincia.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });
                    dt_t_provincia_grid = Cls_Grid.ListToTable(retorno.t_provincia);

                    gridControl1.DataSource = dt_t_provincia_grid;
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
                dt_t_provincia_grid.Clear();
                gridControl1.DataSource = dt_t_provincia_grid;
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

                // dt_t_provincia_grid.Clear();
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];

            }

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_provincia_grid);
            }


            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {

                dt_t_provincia_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_provincia_grid);

                int count = dt_t_provincia_final.Rows.Count;
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
