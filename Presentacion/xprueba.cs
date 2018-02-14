using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;

namespace Presentacion
{
    public partial class xprueba : DevExpress.XtraEditors.XtraForm
    {
        public xprueba()
        {
            InitializeComponent();
        }

        private void lookUpEdit1_ProcessNewValue(object sender, DevExpress.XtraEditors.Controls.ProcessNewValueEventArgs e)
        {
        //    if ((string)e.DisplayValue != String.Empty &&
        //MessageBox.Show(this, "Add the '" + e.DisplayValue.ToString() + "' entry to the list?",
        //"Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //    {
        //        ((sender as LookUpEdit).Properties.DataSource as ContactList).Add(
        //          new Contact(e.DisplayValue.ToString()));
        //        e.Handled = true;
        //    }
        }

        private void xprueba_Load(object sender, EventArgs e)
        {
            ContactList cList = new ContactList();
            cList.Add(new Contact("John Doe"));
            cList.Add(new Contact("Sam Hill"));
            cList.Add(new Contact("Karen Holmes"));
            cList.Add(new Contact("Bobbie Valentine"));
            cList.Add(new Contact("Frank Frankson"));

            //bind the lookup editor to the list
            lookUpEdit1.Properties.DataSource = cList;
            lookUpEdit1.Properties.DisplayMember = "Name";
            lookUpEdit1.Properties.ValueMember = "ID";
            // Add columns.
            // The ID column is populated 
            // via the GetNotInListValue event (not listed in the example).
            lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("ID", "ID", 20));
            lookUpEdit1.Properties.Columns.Add(new LookUpColumnInfo("Name", "Name", 80));
            //enable text editing
            lookUpEdit1.Properties.TextEditStyle = TextEditStyles.Standard;
        }


        public class ContactList : System.Collections.CollectionBase
        {
            public Contact this[int index]
            {
                get { return (Contact)(List[index]); }
                set { List[index] = value; }
            }

            public int Add(Contact value)
            {
                return List.Add(value);
            }
            //...
        }


        public class Contact
        {
            private string name;
            public Contact(string _name)
            {
                name = _name;
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Id
            {
                get { return Id; }
                set { name = value; }
            }
        }
    }

}