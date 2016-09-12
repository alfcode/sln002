﻿using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Data;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors;

namespace Presentacion
{
   public class Cls_Grid_DevExpress_Mnt_1
    {


        public void Load_Grid(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, DataTable dt_param1 )
        {
            gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);

          
            ImageList imageList1 = new ImageList();

            imageList1.Images.Add(Properties.Resources.prevtop_64);
            imageList1.Images.Add(Properties.Resources.prev_64);
            imageList1.Images.Add(Properties.Resources.Next_64);
            imageList1.Images.Add(Properties.Resources.nextbutton_64);
            imageList1.Images.Add(Properties.Resources.nuevo64);
            imageList1.Images.Add(Properties.Resources.delete64);
            imageList1.Images.Add(Properties.Resources.grabar64);
            imageList1.Images.Add(Properties.Resources.folder64);
            imageList1.Images.Add(Properties.Resources.salir64);
            imageList1.Images.Add(Properties.Resources.limpiar64);



            imageList1.ImageSize = new Size(25, 25);

            gridControl1.UseEmbeddedNavigator = true;
            DevExpress.XtraEditors.ControlNavigatorButtons buttons = gridControl1.EmbeddedNavigator.Buttons;
            buttons.ImageList = imageList1;

            buttons.First.ImageIndex = 0;
            buttons.PrevPage.ImageIndex = 1;
            buttons.NextPage.ImageIndex = 2;
            buttons.Last.ImageIndex = 3;

            buttons.Append.ImageIndex =4;
            buttons.Remove.ImageIndex = 5;
            buttons.Remove.Hint = "Marcar registro para eliminar";
            buttons.EndEdit.ImageIndex = 6;
            buttons.EndEdit.Hint = "Grabar registros";

            buttons.CancelEdit.Visible = false;
            buttons.Edit.Visible = false;

           
           
            //  buttons.Prev.Visible = false;
            // buttons.Next.Visible = false;

            //Añadiendo nuevos botones,
            DevExpress.XtraEditors.NavigatorCustomButton button_separador1;
            button_separador1 = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add();
            button_separador1.Hint = "";
            button_separador1.Enabled = false;
            //Añadiendo nuevos botones,
            DevExpress.XtraEditors.NavigatorCustomButton button_limpiar;
            button_limpiar = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add();
            button_limpiar.Tag = "Limpiar";
            button_limpiar.Hint = "Limpiar";
            button_limpiar.ImageIndex = 9;
            //Añadiendo nuevos botones,
            DevExpress.XtraEditors.NavigatorCustomButton button_folder;
            button_folder = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add();
            button_folder.Tag = "Folder";
            button_folder.Hint = "Ver todos los registros";
            button_folder.ImageIndex = 7;
            //Añadiendo nuevos botones,
            DevExpress.XtraEditors.NavigatorCustomButton button_separador3;
            button_separador3 = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add();
            button_separador3.Hint = "";
            button_separador3.Enabled = false;
            //Añadiendo nuevos botones,
            DevExpress.XtraEditors.NavigatorCustomButton button_separador4;
            button_separador4 = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add();
            button_separador4.Hint = "";
            button_separador4.Enabled = false;
            //Añadiendo nuevos botones,
            DevExpress.XtraEditors.NavigatorCustomButton button_salir;
            button_salir = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add();
            button_salir.Tag = "Salir";
            button_salir.Hint = "Salir";
            button_salir.ImageIndex = 8;

            new GridNewRowHelper(gridView1); /// inserta nueva linea grid
            Visible_Columns(gridView1,dt_param1);
        }



        public void Load_Combo(GridView gridView1, List<EN_zero.datacombo> lista,string ValueMember,bool registra_nombre2 )
        {
            RepositoryItemLookUpEdit riLookup = new RepositoryItemLookUpEdit();
            riLookup.DataSource = lista;
            riLookup.ValueMember = "id";

            riLookup.DisplayMember = "nombre1";
            //  riLookup.Columns.Add(new LookUpColumnInfo("id_grupo1", "Còdigo"));
            riLookup.Columns.Add(new LookUpColumnInfo("nombre1", "Nombre"));

            if (registra_nombre2 == true)
            {
                riLookup.Columns.Add(new LookUpColumnInfo("nombre2", "Descripción"));
            }
           
            riLookup.NullText = "-seleccione-";

            riLookup.ImmediatePopup = true;
            riLookup.TextEditStyle = TextEditStyles.Standard;
            riLookup.BestFitMode = BestFitMode.BestFitResizePopup;
            riLookup.DropDownRows = lista.Count;
            riLookup.SearchMode = SearchMode.AutoFilter;
            riLookup.AutoSearchColumnIndex = 0;
            gridView1.Columns[ValueMember].ColumnEdit = riLookup;
            gridView1.BestFitColumns();

        }


        private void Visible_Columns(GridView gridView1,DataTable dt_param1 )
        {
            int myCount;
            try { myCount = gridView1.Columns.Count; }
            catch { myCount = 0; }

            for (int j = 0; j < myCount; j++)
            {


                if (dt_param1.Columns[j].Caption == "")
                {
                    gridView1.Columns[j].Visible = false;

                }
                else
                {
                    gridView1.Columns[j].Width = Convert.ToInt32(dt_param1.Columns[j].AutoIncrementStep); // AutoIncrementStep--- contiene el valor ancho de celda desde funcion  listto_data
                }

            }

            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
           
        }


        public  DataTable ListToTable<T>(IList<T> list)
        {

            DataTable dt = new DataTable();
            PropertyInfo[] propiedades = typeof(T).GetProperties();
            var i = 0;
            foreach (PropertyInfo p in propiedades)
            {
                dt.Columns.Add(p.Name, p.PropertyType);

                var pInfo = typeof(T).GetProperty(p.Name)
                            .GetCustomAttributes(typeof(DisplayAttribute), false)
                            .Cast<DisplayAttribute>().FirstOrDefault();

                if (pInfo != null)
                {

                    dt.Columns[i].Caption = pInfo.Description;

                    if (dt.Columns[i].Caption != "")
                    {
                        dt.Columns[i].AutoIncrementStep = pInfo.Order;
                    }
                   

                    if (pInfo.Prompt != null) dt.Columns[i].DefaultValue = pInfo.Prompt;
                }
                else
                {
                    dt.Columns[i].Caption = "";
                }

                i++;
            }
            foreach (T item in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo p in propiedades)
                {
                    row[p.Name] = p.GetValue(item, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }


        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            var gridView1 = sender as GridView;
            string id = gridView1.GetFocusedRowCellValue("id_usuario_ultimo").ToString();

            if (id != "nuevo")
            {
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                row["id_usuario_ultimo"] = "modificar";
                row["id_usuario_inicia"] = "modificar";
            }
        }

        private void gridView1_RowStyle(object sender, RowStyleEventArgs e)
        {
            var gridView1 = sender as GridView;

            if (e.RowHandle >= 0)
            {
                string estado_color = gridView1.GetRowCellDisplayText(e.RowHandle, gridView1.Columns["id_usuario_ultimo"]);
                if (estado_color == "eliminar")
                {
                    e.Appearance.BackColor = Color.Salmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                }

                if (estado_color == "modificar")
                {
                    e.Appearance.BackColor = Color.DeepSkyBlue;
                    e.Appearance.BackColor2 = Color.LightCyan;
                }

                if (estado_color == "grabado")
                {
                    e.Appearance.BackColor = Color.Silver;
                }

                if (estado_color == "nuevo")
                {
                    e.Appearance.BackColor = Color.PaleGoldenrod;
                    e.Appearance.BackColor2 = Color.White;
                }


            }
        }



        public DataTable EmbeddedNavigator(GridView gridView1 , NavigatorButtonClickEventArgs e, DataTable dt_param1)
        {
            var dt = new DataTable("vacio");

            if (e.Button.ButtonType == NavigatorButtonType.EndEdit)
            {
                IEnumerable<DataRow> query = from myRow in dt_param1.AsEnumerable()
                                             where myRow.Field<string>("id_usuario_ultimo").Equals("nuevo")
                                             select myRow;

                int id = 0;
                foreach (DataRow i in query)
                {
                    i["id_usuario_inicia"] = id.ToString();
                    id++;

                }



                IEnumerable<DataRow> query2 = from myRow in dt_param1.AsEnumerable()
                                              where myRow.Field<string>("id_usuario_ultimo") != ("grabado")
                                              select myRow;


                if (query2.Any())
                {
                    dt = query2.CopyToDataTable();



                }

            }


            if (e.Button.ButtonType == NavigatorButtonType.Remove)
            {

                e.Handled = true;

                string id = gridView1.GetFocusedRowCellValue("id_usuario_ultimo").ToString();
                //DataRow rowid = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                //string id = rowid["id_usuario_ultimo"].ToString();

                if (id != "nuevo")
                {

                    string id2 = gridView1.GetFocusedRowCellValue("id_usuario_ultimo").ToString();
                    if (id2 == "eliminar")
                    {

                        string id3 = gridView1.GetFocusedRowCellValue("id_usuario_inicia").ToString();

                        if (id3 == "modificar")
                        {
                            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                            row["id_usuario_ultimo"] = "modificar";
                        }
                        else
                        {
                            DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                            row["id_usuario_ultimo"] = "grabado";
                        }

                    }
                    else
                    {
                        DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                        row["id_usuario_ultimo"] = "eliminar";
                    }



                }
                else
                {
                    e.Handled = false;
                }

            }


            return dt;

        }



        public bool ExisteError(List<EN_zero.informe> datos)
        {
            //string idx = (from Lista in informe
            //             select Lista.Id).First().ToString();

            string _id = "";
            string _error = "";
            string _procedure = "";
            string _linea = "";
            string _mensaje = "";

            foreach (var lista in datos)
            {
                _id = lista.Id.ToString();
                _error = lista.Error.ToString();
                _procedure = lista.Procedure.ToString();
                _linea = lista.Linea.ToString();
                _mensaje = lista.Mensaje.ToString();
            }

            if (_id == "1")
            {

                var mensaje = "Nro Error: " + _error + "Procedure: " + _procedure + "Linea: " + _linea + "Aviso: " + _mensaje;
                MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return true;
            }

            return false;
        }









    }

    public class GridNewRowHelper
    {

        private readonly GridView _View;
        public GridNewRowHelper(GridView view)
        {
            _View = view;
            _View.HiddenEditor += _View_HiddenEditor;
            view.GridControl.EditorKeyDown += GridControl_EditorKeyDown;
            view.GridControl.KeyDown += new KeyEventHandler(GridControl_KeyDown);
        }

        void _View_HiddenEditor(object sender, EventArgs e)
        {
        }

        void GridControl_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = OnKeyDown(e.KeyCode, e.Modifiers);
        }

        void GridControl_EditorKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = OnKeyDown(e.KeyCode, e.Modifiers);
        }
        private bool OnKeyDown(Keys keyCode, Keys modifiers)
        {
            if (modifiers == Keys.None & (keyCode == Keys.Enter || keyCode == Keys.Tab))
            {
                return CheckAddNewRow();
            }
            return false;
        }

        private bool CheckAddNewRow()
        {
            if (_View.FocusedColumn.VisibleIndex == _View.VisibleColumns.Count - 1)
            {
                if (_View.IsNewItemRow(_View.FocusedRowHandle))
                {
                    _View.PostEditor();
                    _View.UpdateCurrentRow();
                }
                if (_View.IsLastRow)
                    return AddNewRow();
            }
            return false;
        }

        private bool AddNewRow()
        {
            _View.AddNewRow();
            _View.FocusedColumn = _View.VisibleColumns[0];
            return true;
        }
    }

}
