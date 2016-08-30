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
    public partial class frm_estado : MetroFramework.Forms.MetroForm
    {
        public frm_estado()
        {
            InitializeComponent();
        }


        private void proc_estado_mtto(string tarea)
        {

            var param_estado = new EN_estado.param_estado();

            var accion = new EN_zero.accion();
            accion.tarea = tarea;

            var datos = new EN_estado.t_estado();
            datos.id_estado = "";
            datos.nombre = "OCULTO";

            param_estado.accion = accion;
            param_estado.t_estado = datos;

            var negocio = new LN_estado();
            var retorno = new List<EN_zero.informe>();

            retorno = negocio.proc_estado_mnt(param_estado);

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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void frm_estado_Load(object sender, EventArgs e)
        {

        }

        private void btn_mas_Click(object sender, EventArgs e)
        {

        }
    }
}
