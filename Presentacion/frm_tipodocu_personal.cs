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
    public partial class frm_tipodocu_personal : DevExpress.XtraEditors.XtraForm
    {
        string id_usuario = Cls_Global.id_usuario;

        Cls_Grid_DevExpress_Mnt_1 Cls_Grid = new Cls_Grid_DevExpress_Mnt_1();
        List<EN_tipodocu_personal.t_tipodocu_personal> t_tipodocu_personal = new List<EN_tipodocu_personal.t_tipodocu_personal>();
        DataTable dt_t_tipodocu_personal_grid = new DataTable();
        DataTable dt_t_tipodocu_personal_final = new DataTable();

        public frm_tipodocu_personal()
        {
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            InitializeComponent();
            gridControl1.EmbeddedNavigator.ButtonClick += new DevExpress.XtraEditors.NavigatorButtonClickEventHandler(this.gridControl1_EmbeddedNavigator_ButtonClick);
            this.Load += new System.EventHandler(this.frm_tipodocu_personal_Load);
            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;

            labelControl1.Text = "Tipo Documento Usuario";

            this.Width = 500;
            this.Height = 400;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            int positionfinal = this.Width - this.labelControl1.Size.Width - 15;
            this.labelControl1.Location = new System.Drawing.Point(positionfinal, 5);


        }

        private void frm_tipodocu_personal_Load(object sender, EventArgs e)
        {

            inicio();
        }

        private void inicio()
        {
            dt_t_tipodocu_personal_grid = Cls_Grid.ListToTable(t_tipodocu_personal);
            dt_t_tipodocu_personal_final = Cls_Grid.ListToTable(t_tipodocu_personal);

            gridControl1.DataSource = dt_t_tipodocu_personal_grid;
        
            Cls_Grid.Load_Grid(gridControl1, gridView1, dt_t_tipodocu_personal_grid);

        }


        private void mnt_datos(string id_usuario)
        {

            try
            {

                t_tipodocu_personal = dt_t_tipodocu_personal_final.DataTableToList<EN_tipodocu_personal.t_tipodocu_personal>().ToList();
                var negocio = new LN_tipodocu_personal();
                var parametro = new EN_tipodocu_personal.proc_tipodocu_personal_mnt();
                var retorno = new EN_tipodocu_personal.proc_tipodocu_personal_mnt_retorno();

                parametro.id_usuario = id_usuario;
                parametro.t_tipodocu_personal = t_tipodocu_personal;

                Cursor.Current = Cursors.WaitCursor;
                retorno = negocio.proc_tipodocu_personal_mnt(parametro);
                Cursor.Current = Cursors.Default;

                if (Cls_Grid.ExisteError(retorno.informe))
                {
                    return;
                }

                if (id_usuario != "")
                {
                    dt_t_tipodocu_personal_grid.Clear();
                    DevExpress.XtraEditors.XtraMessageBox.Show(Cls_Mensajes.titulo_exito, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                else
                {
                    retorno.t_tipodocu_personal.ToList().ForEach(c => { c.id_usuario_inicia = ""; c.id_usuario_ultimo = "grabado"; });
                    dt_t_tipodocu_personal_grid = Cls_Grid.ListToTable(retorno.t_tipodocu_personal);

                    gridControl1.DataSource = dt_t_tipodocu_personal_grid;
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
                dt_t_tipodocu_personal_grid.Clear();
                gridControl1.DataSource = dt_t_tipodocu_personal_grid;
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

                // dt_t_tipodocu_personal_grid.Clear();
                gridView1.FocusedColumn = gridView1.VisibleColumns[0];

            }

            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {
                Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_tipodocu_personal_grid);
            }


            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {

                dt_t_tipodocu_personal_final = Cls_Grid.EmbeddedNavigator(gridView1, e, dt_t_tipodocu_personal_grid);

                int count = dt_t_tipodocu_personal_final.Rows.Count;
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
