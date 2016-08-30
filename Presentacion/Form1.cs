using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Entidad;
using Negocio;

namespace Presentacion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void mtn_guia_registra()
        {

            var negocio = new LN_guia();
            var parametros = new EN_guia.proc_guia_mnt();
            var retorno = new EN_guia.retorno_guia_mnt();

            EN_guia.t_guia_tarea ptarea = new EN_guia.t_guia_tarea();
            ptarea.tarea = "1";

            EN_guia.t_guia_cab cab = new EN_guia.t_guia_cab();
            cab.id_proveedor = "2";
            cab.nom_proveedor = "demo";
            cab.numero_guia = "212";

            List<EN_guia.t_guia_det> det = new List<EN_guia.t_guia_det>();
            for (int i = 0; i < 5; i++)
            {
                var items = new EN_guia.t_guia_det();
                items.item = i + 1;
                items.producto = "folder";
                items.precio = i * 5;
                items.cantidad = i + 1;

                det.Add(items);
            }

            parametros.t_guia_tarea = ptarea;
            parametros.t_guia_cab = cab;
            parametros.t_guia_det = det;

            retorno = negocio.proc_guia_mnt(parametros);

            string resuelve = EN_zero.ExisteError(retorno.informe);
            if (resuelve != "")
            {
                MessageBox.Show(resuelve, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return; // sale del metodo
            }

            foreach (var id in retorno.t_guia_id_guia)
            {
                var id_guia = id.id_guia;
                txt_guia.Text = id_guia.ToString();
            }


            MessageBox.Show("exito",
                                 "Aviso",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information,
                                 MessageBoxDefaultButton.Button1);


        }


        private void mtn_guia_edita()
        {

            var negocio = new LN_guia();
            var parametros = new EN_guia.proc_guia_mnt();
            var retorno = new EN_guia.retorno_guia_mnt();

            EN_guia.t_guia_tarea ptarea = new EN_guia.t_guia_tarea();
            ptarea.tarea = "2";

            EN_guia.t_guia_cab cab = new EN_guia.t_guia_cab();
            cab.id_guia = Convert.ToInt32(txt_guia.Text);
            cab.id_proveedor = "2";
            cab.nom_proveedor="proveMOD";
            cab.numero_guia = "212";

            List<EN_guia.t_guia_det> det = new List<EN_guia.t_guia_det>();
            for (int i=0;i < 5; i++)
            {
                var items = new EN_guia.t_guia_det();
                items.item = i+1;
                items.producto = "cuadeMOD";
                items.precio = i * 5;
                items.cantidad = i + 1;

                det.Add(items);
            }

            parametros.t_guia_tarea = ptarea;
            parametros.t_guia_cab = cab;
            parametros.t_guia_det = det;

            retorno = negocio.proc_guia_mnt(parametros);

            string resuelve = EN_zero.ExisteError(retorno.informe);
            if (resuelve != "")
            {
                MessageBox.Show(resuelve, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;// sale del metodo
            }


            MessageBox.Show("editado, puede consultar",
                                 "Aviso",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information,
                                 MessageBoxDefaultButton.Button1);


        }

        private void mtn_guia_elimina()
        {

            var negocio = new LN_guia();
            var parametros = new EN_guia.proc_guia_mnt();
            var retorno = new EN_guia.retorno_guia_mnt();

            EN_guia.t_guia_tarea ptarea = new EN_guia.t_guia_tarea();
            ptarea.tarea = "3";

            EN_guia.t_guia_cab cab = new EN_guia.t_guia_cab();
            cab.id_guia =Convert.ToInt32(txt_guia.Text);

            List<EN_guia.t_guia_det> det = new List<EN_guia.t_guia_det>();

            parametros.t_guia_tarea = ptarea;
            parametros.t_guia_cab = cab;
            parametros.t_guia_det = det;

            retorno = negocio.proc_guia_mnt(parametros);

            string resuelve = EN_zero.ExisteError(retorno.informe);
            if (resuelve != "")
            {
                MessageBox.Show(resuelve, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return; // sale del metodo
            }


            MessageBox.Show("guia eliminada",
                                 "Aviso",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information,
                                 MessageBoxDefaultButton.Button1);

        }

        private void mtn_guia_consulta()
        {



          
            var negocio = new LN_guia();
            var parametro = new EN_guia.proc_consulta_guia();
            var retorno = new EN_guia.datos_consulta_guia();

            parametro.id_guia = Convert.ToInt32(txt_guia.Text);

            retorno = negocio.proc_consulta_guia(parametro);

            string resuelve = EN_zero.ExisteError(retorno.informe);
            if (resuelve != "")
            {
                MessageBox.Show(resuelve, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return; // sale del metodo
            }

            foreach (var a in retorno.t_guia_cab)
            {
                var eco = a.id_guia;
            }
            foreach (var b in retorno.t_guia_det)
            {
                var eco = b.item;
            }

            dgv_cab.DataSource = retorno.t_guia_cab;

            dgv_det.DataSource = retorno.t_guia_det;

            MessageBox.Show("exito",
                                 "Aviso",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information,
                                 MessageBoxDefaultButton.Button1);
        }

        private void btn_registrar_Click(object sender, EventArgs e)
        {
            mtn_guia_registra();
        }

        private void btn_editar_Click(object sender, EventArgs e)
        {
            mtn_guia_edita();
        }

        private void btn_eliminar_Click(object sender, EventArgs e)
        {
            mtn_guia_elimina();
        }

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            mtn_guia_consulta();
        }
    }
}
