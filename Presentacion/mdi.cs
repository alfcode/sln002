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

namespace Presentacion
{
    public partial class mdi : DevExpress.XtraEditors.XtraForm
    {
        public mdi()
        {
            InitializeComponent();
            DevExpress.UserSkins.BonusSkins.Register();
            DevExpress.Skins.SkinManager.EnableFormSkins();
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Cls_Global.skinName;

            this.Icon = Properties.Resources.empresa;
            this.Text = Cls_Global.empresa;
            this.MaximizeBox = false;


            TaskbarVista.Hide();
        }

        private void mdi_FormClosing(object sender, FormClosingEventArgs e)
        {
            TaskbarVista.Show();
        }

        private void conta_tdocu_sunat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_tdocu_sunat();
            form.Show();


        }

        private void rrhh_usuario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_usuario();
            form.Show();
        }

        private void rrhh_area_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_area();
            form.Show();
        }

        private void rrhh_cargo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_cargo();
            form.Show();
        }

        private void rrhh_rol_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_rol();
            form.Show();
        }

        private void rrhh_rol_usuario_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_rol_usuario();
            form.Show();
        }

        private void rrhh_zona_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_zona();
            form.Show();
        }

        private void rrhh_postal_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("falta");        }

        private void rrhh_departamento_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_departamento();
            form.Show();
        }

        private void rrhh_provincia_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_provincia();
            form.Show();
        }

        private void rrhh_distrito_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_distrito();
            form.Show();
        }

        private void conta_empresa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_empresa();
            form.Show();
        }

        private void conta_moneda_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_moneda();
            form.Show();
        }

        private void conta_tipo_cambio_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("falta");
        }

        private void conta_estado_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_estado();
            form.Show();
        }

        private void inve_articulo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_articulo();
            form.Show();
        }

        private void inve_unidad_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new  frm_unidad();
            form.Show();
        }

        private void inve_grupo1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new  frm_grupo1();
            form.Show();
        }

        private void inve_grupo2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_grupo2();
            form.Show();
        }

        private void inve_grupo3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_grupo3();
            form.Show();
        }

        private void inve_grupo4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_grupo4();
            form.Show();
        }

        private void inve_grupo5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_grupo5();
            form.Show();
        }

        private void inve_proveedor_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_proveedor();
            form.Show();
        }

        private void inve_almacen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_almacen();
            form.Show();
        }

        private void inve_formapago_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Form form = new frm_formapago();
            form.Show();
        }

     

        private void inve_almacen_articulo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("falta");
        }

        private void inve_proveedor_articulo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("falta");
        }

        private void inve_tipoingreso_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("tipo ingreso");
        }

        private void inve_tiposalida_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("tipo salida");
        }

       
    }
}