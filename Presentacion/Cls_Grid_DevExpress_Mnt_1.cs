using DevExpress.XtraEditors.Controls;
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
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms;
using System.Drawing;
using DevExpress.XtraEditors ;
using DevExpress.Utils;

namespace Presentacion
{
   public class Cls_Grid_DevExpress_Mnt_1
    {



        public string info_columnas(Form forma, GridView gridView1)
        {

            int conta = gridView1.Columns.Count - 1;
            string tamano = "";

            for (int i=0;i <= conta;i++)
            {

                if(gridView1.Columns[i].Visible==true)
                {
                     tamano = tamano + " ---" + gridView1.Columns[i].Width.ToString();
                }
               
            }

            tamano = "Form(W * H " + forma.Width.ToString() + " x " + forma.Height.ToString() + " )  Grid = " + tamano;

            return tamano;
        }


        public void Load_Grid(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1, DataTable dt_param1 )
        {
            gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
            gridView1.OptionsView.ColumnAutoWidth = false;

            SetGridFont(gridView1, new System.Drawing.Font("Tahoma", 8));

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
            imageList1.Images.Add(Properties.Resources.bloqueo);


            imageList1.ImageSize = new Size(25, 24);

            gridControl1.UseEmbeddedNavigator = true;
            DevExpress.XtraEditors.ControlNavigatorButtons buttons = gridControl1.EmbeddedNavigator.Buttons;
            buttons.ImageList = imageList1;

            buttons.First.ImageIndex = 0;
            buttons.PrevPage.ImageIndex = 1;
            buttons.NextPage.ImageIndex = 2;
            buttons.Last.ImageIndex = 3;

            buttons.Append.ImageIndex =4;
            buttons.Remove.ImageIndex = 5;
            buttons.Remove.Hint = "Marcar el registro para eliminar";
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
            DevExpress.XtraEditors.NavigatorCustomButton button_separador4;
            button_separador4 = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add();
            button_separador4.Hint = "";
            button_separador4.Enabled = false;
            //Añadiendo nuevos botones,
            DevExpress.XtraEditors.NavigatorCustomButton button_bloqueo;
            button_bloqueo = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add();
            button_bloqueo.Tag = "Bloqueo";
            button_bloqueo.Hint = "Editar";
            button_bloqueo.ImageIndex = 10;
          //  button_bloqueo.Enabled = true;

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
            DevExpress.XtraEditors.NavigatorCustomButton button_salir;
            button_salir = gridControl1.EmbeddedNavigator.Buttons.CustomButtons.Add();
            button_salir.Tag = "Salir";
            button_salir.Hint = "Salir";
            button_salir.ImageIndex = 8;

            new GridNewRowHelper(gridView1); /// inserta nueva linea grid
            Visible_Columns(gridView1,dt_param1);

            string id_nivel = Cls_Global.id_nivel;
 
            if (id_nivel.Equals("1"))
            {
                gridControl1.EmbeddedNavigator.Buttons.Append.Enabled = true;
                gridControl1.EmbeddedNavigator.Buttons.Remove.Enabled = true;
                gridControl1.EmbeddedNavigator.Buttons.EndEdit.Enabled = true;
                button_bloqueo.Enabled = true;
                button_limpiar.Enabled = true;
                gridView1.OptionsBehavior.ReadOnly = false;

            }

            if (id_nivel.Equals("2"))
            {
                gridControl1.EmbeddedNavigator.Buttons.Append.Enabled = false;
                gridControl1.EmbeddedNavigator.Buttons.Remove.Enabled = false;
                gridControl1.EmbeddedNavigator.Buttons.EndEdit.Enabled = false;
                button_bloqueo.Enabled = false;
                button_limpiar.Enabled = false;
                gridView1.OptionsBehavior.ReadOnly = true;

            }



        }


        private void SetGridFont( GridView view , Font font )
        {
           foreach (AppearanceObject ap in view.Appearance)
            {
                ap.Font = font;
            }
        }



        public void editable_grid(DevExpress.XtraGrid.GridControl gridControl1, GridView gridView1,bool habilita)
        {

            string id_nivel = Cls_Global.id_nivel;

            if (id_nivel.Equals("1"))
            {
                 gridControl1.EmbeddedNavigator.Buttons.Append.Enabled = habilita;
                gridControl1.EmbeddedNavigator.Buttons.Remove.Enabled = habilita;
                gridControl1.EmbeddedNavigator.Buttons.EndEdit.Enabled = habilita;
                gridView1.OptionsBehavior.ReadOnly =!habilita;
            }
               
        }


        public void Load_Combo_GridLookUpEdit_In_Grid<T>(GridView gridView1, IList<T>  lista, string ValueMember, bool ver_descripcion_2, int Width, int Height)
        {
            RepositoryItemGridLookUpEdit riLookup = new RepositoryItemGridLookUpEdit();

            /// 
            riLookup.DataSource = lista;
            int count = riLookup.View.Columns.Count;
            if (count == 0)
            {
                riLookup.ValueMember = "id";
                riLookup.DisplayMember = "nombre1";
                PropertyInfo[] propiedades = typeof(T).GetProperties();
                int i = 0;
                foreach (PropertyInfo p in propiedades)
                {
                    DevExpress.XtraGrid.Columns.GridColumn col11 = riLookup.View.Columns.AddField(p.Name);
                    col11.VisibleIndex = i;
                    if (i == 0) col11.Visible = false;
                    if (i == 1) col11.Visible = true; //nombre1
                    if (i == 2) col11.Visible = false; //nombre2

                    //id_ocultos
                    if (i == 3) col11.Visible = false;
                    if (i == 4) col11.Visible = false;
                    if (i == 5) col11.Visible = false;
                    if (i == 6) col11.Visible = false;

                    if (i == 1)
                    {
                        col11.Caption = "Descripción";
                    }



                    if (ver_descripcion_2 == true)
                    {
                        col11.Visible = true;
                        col11.Caption = "Mas datos";
                    }

                    i++;
                }
                riLookup.NullText = "-seleccione-";

                riLookup.ImmediatePopup = true;
                riLookup.TextEditStyle = TextEditStyles.Standard;
       
               // riLookup.BestFitMode = BestFitMode.BestFitResizePopup;
                riLookup.PopupFilterMode = PopupFilterMode.Contains;

             //   riLookup.View.BestFitColumns();
                riLookup.PopupFormSize = new Size(Width, Height);
            }

           
            gridView1.Columns[ValueMember].ColumnEdit = riLookup;
            gridView1.BestFitColumns();

        }


        public RepositoryItemGridLookUpEdit Load_Combo_GridLookUpEdit_In_Grid_Filter<T>(IList<T> lista, bool ver_descripcion_2, int Width, int Height)
        {
            RepositoryItemGridLookUpEdit riLookup = new RepositoryItemGridLookUpEdit();

          
            /// 
            riLookup.DataSource = lista;
            int count = riLookup.View.Columns.Count;
            if (count == 0)
            {
                riLookup.ValueMember = "id";
                riLookup.DisplayMember = "nombre1";
                PropertyInfo[] propiedades = typeof(T).GetProperties();
                int i = 0;
                foreach (PropertyInfo p in propiedades)
                {
                    DevExpress.XtraGrid.Columns.GridColumn col11 = riLookup.View.Columns.AddField(p.Name);
                    col11.VisibleIndex = i;
                    if (i == 0) col11.Visible = false;
                    if (i == 1) col11.Visible = true; //nombre1
                    if (i == 2) col11.Visible = false; //nombre2

                    //id_ocultos
                    if (i == 3) col11.Visible = false;
                    if (i == 1)
                    {
                        col11.Caption = "Descripción";
                    }

                    if (ver_descripcion_2 == true)
                    {
                        col11.Visible = true;
                        col11.Caption = "Mas datos";
                    }

                    i++;
                }
                riLookup.NullText = "-seleccione-";

                riLookup.ImmediatePopup = true;
                riLookup.TextEditStyle = TextEditStyles.Standard;
                riLookup.PopupFilterMode = PopupFilterMode.Contains;
                riLookup.PopupFormSize = new Size(Width, Height);
            }

            return riLookup;

        }



        public void Load_Combo(GridView gridView1, List<EN_zero.datacombo> lista,string ValueMember,bool registra_nombre2 )
        {
            RepositoryItemLookUpEdit riLookup = new RepositoryItemLookUpEdit();

           /// RepositoryItemGridLookUpEdit

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
        
        public void Load_Combo_LookUpEdit(DevExpress.XtraEditors.LookUpEdit riLookup,  List<EN_zero.datacombo> lista, string ValueMember, bool registra_nombre2)
        {
            riLookup.Properties.DataSource = lista;
            riLookup.Properties.ValueMember = "id";

            riLookup.Properties.DisplayMember = "nombre1";
            //  riLookup.Columns.Add(new LookUpColumnInfo("id_grupo1", "Còdigo"));
            riLookup.Properties.Columns.Add(new LookUpColumnInfo("nombre1", "Nombre"));

            if (registra_nombre2 == true)
            {
                riLookup.Properties.Columns.Add(new LookUpColumnInfo("nombre2", "Descripción"));
            }

            riLookup.Properties.NullText = "-seleccione-";

            riLookup.Properties.ImmediatePopup = true;
            riLookup.Properties.TextEditStyle = TextEditStyles.Standard;
            riLookup.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
            riLookup.Properties.DropDownRows = lista.Count;
            riLookup.Properties.SearchMode = SearchMode.AutoFilter;
            riLookup.Properties.AutoSearchColumnIndex = 0;


           // riLookup.Properties.ShowHeader = false;
            //riLookup.Properties.ShowFooter = false;
           /// riLookup.Properties.NullText = string.Empty;


        }

 
        public void Load_Combo_GridLookUpEdit<T>(DevExpress.XtraEditors.GridLookUpEdit riLookup, IList<T> lista, bool registra_nombre2,int Width,int Height)
        {
            riLookup.Properties.DataSource = lista;
            int count = riLookup.Properties.View.Columns.Count;
            if (count == 0)
            {
                    riLookup.Properties.ValueMember = "id";
                    riLookup.Properties.DisplayMember = "nombre1";
                    PropertyInfo[] propiedades = typeof(T).GetProperties();
                    int i = 0;
                    foreach (PropertyInfo p in propiedades)
                    {
                        DevExpress.XtraGrid.Columns.GridColumn col11 = riLookup.Properties.View.Columns.AddField(p.Name);
                        col11.VisibleIndex = i;
                        if (i == 0) col11.Visible = false;
                        if (i == 1) col11.Visible = true; //nombre1
                        if (i == 2) col11.Visible = false; //nombre2

                        //id_ocultos
                        if (i == 3) col11.Visible = false;
                        if (i == 4) col11.Visible = false;
                        if (i == 5) col11.Visible = false;
                        if (i == 6) col11.Visible = false;

                        if (i == 1) {
                            col11.Caption = "Descripción";
                        }

                   
               
                        if (registra_nombre2 == true)
                        {
                                col11.Visible = true;
                                col11.Caption = "Mas datos";
                        }
                   
                        i++;
                    }
                riLookup.Properties.NullText = "-seleccione-";

                riLookup.Properties.ImmediatePopup = true;
                riLookup.Properties.TextEditStyle = TextEditStyles.Standard;
                riLookup.Properties.BestFitMode = BestFitMode.BestFitResizePopup;
                riLookup.Properties.PopupFilterMode = PopupFilterMode.Contains;

                riLookup.Properties.View.BestFitColumns();
                // Specify the total dropdown width.
                riLookup.Properties.PopupFormMinSize = new Size(Width, Height);
                // riLookup.Properties.PopupFormSize = new Size(Width, Height);
            }
            
             
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
                    gridView1.Columns[j].Width = Convert.ToInt32(dt_param1.Columns[j].Namespace); // AutoIncrementStep--- contiene el valor ancho de celda desde funcion  listto_data
                }

            }

            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            gridView1.OptionsSelection.EnableAppearanceHideSelection = false;
           
        }


      

        private void gridView1_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {

            try
            {

            var gridView1 = sender as GridView;


                if (gridView1.GetFocusedRowCellValue("id_usuario_ultimo") == null) return;
               
                string id = gridView1.GetFocusedRowCellValue("id_usuario_ultimo").ToString();


                if (id != "nuevo")
            {
                DataRow row = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                row["id_usuario_ultimo"] = "modificar";
                row["id_usuario_inicia"] = "modificar";
                   
            }


            }
            catch (Exception ex)
            {
                string error = ex.TargetSite.Name + ", " + ex.Message + " - " + Cls_Mensajes.error_sistema;
                   DevExpress.XtraEditors.XtraMessageBox.Show(error, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

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
                    e.Appearance.BackColor = Color.Gainsboro;
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
                string nl = System.Environment.NewLine;
                var mensaje = "Nro Error: " + _error  + nl + "Procedure: " + _procedure + nl + "Linea: " + _linea + nl + "Aviso: " + nl + _mensaje;
               // MessageBox.Show(mensaje, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                DevExpress.XtraEditors.XtraMessageBox.Show(mensaje, Cls_Mensajes.titulo_ventana, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);


                return true;
            }

            return false;
        }


        public DataTable ListToTable<T>(IList<T> list)
        {

            DataTable dt = new DataTable();
            PropertyInfo[] propiedades = typeof(T).GetProperties();
            var i = 0;
            foreach (PropertyInfo p in propiedades)
            {
              
                var pKey = typeof(T).GetProperty(p.Name)
                       .GetCustomAttributes(typeof(KeyAttribute), false)
                        .Cast<KeyAttribute>().FirstOrDefault();

                var pRequired = typeof(T).GetProperty(p.Name)
                        .GetCustomAttributes(typeof(RequiredAttribute), false)
                        .Cast<RequiredAttribute>().FirstOrDefault();


                var pColumn = typeof(T).GetProperty(p.Name)
                        .GetCustomAttributes(typeof(ColumnAttribute), false)
                        .Cast<ColumnAttribute>().FirstOrDefault();

                var pMaxLength = typeof(T).GetProperty(p.Name)
                        .GetCustomAttributes(typeof(MaxLengthAttribute), false)
                        .Cast<MaxLengthAttribute>().FirstOrDefault();
                var pDisplay = typeof(T).GetProperty(p.Name)
                           .GetCustomAttributes(typeof(DisplayAttribute), false)
                           .Cast<DisplayAttribute>().FirstOrDefault();

                DataColumn dc = new DataColumn();
                dc.DataType = p.PropertyType;

                if (pKey != null) dc.Unique = true;

                if (pDisplay.Description != "")
                {
                    if (pRequired != null) dc.AllowDBNull = false;
                }
                
                
                dc.ColumnName = p.Name;
                dc.Namespace = pColumn.Order.ToString(); // ancho en la grilla
                dc.Caption = pDisplay.Description;

                if(pDisplay.Prompt!=null) dc.DefaultValue = pDisplay.Prompt;
                if (dc.DataType.FullName.Equals("System.String"))  dc.MaxLength = pMaxLength.Length;

                dt.Columns.Add(dc);
        
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
