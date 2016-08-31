using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidad;
using Negocio;
namespace Presentacion
{
    public partial class frm_tingreso : Form
    {
        public frm_tingreso()
        {
            InitializeComponent();
        }

        private void registro(string tarea)
        {
            var param = new EN_tingreso.param_tingreso();
            var negocio = new LN_tingreso();
            var retorno = new List<EN_zero.informe>();

            var accion = new EN_zero.accion();
            accion.tarea = tarea;
            var tingreso = new EN_tingreso.t_tingreso();

            tingreso.id_tingreso = "";
            tingreso.nombre = "ingreso por compra ii";// txt_nombre.text;
            tingreso.abreviatura = "inct";//txt_abreviatura.text;
            tingreso.id_usuario_inicia = "001";// txt_id_usuario_inicia.text;
            tingreso.id_usuario_ultimo = "";// txt_id_usuario_ultimo.text;
            tingreso.fecha_inicia = DateTime.Today;
            tingreso.fecha_ultimo = DateTime.Today;
            tingreso.id_estado = "01";// txt_id_estado.text;

            param.accion = accion;
            param.t_ingreso = tingreso;

            retorno = negocio.prc_tingreso(param);


            string resuelve = EN_zero.ExisteError(retorno);
            if (resuelve != "")
            {
                MessageBox.Show(resuelve, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return; // sale del metodo
            }

            MessageBox.Show("exito",
                                 "Aviso",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Information,
                                 MessageBoxDefaultButton.Button1);

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            registro("2");        }
    }

    


}
