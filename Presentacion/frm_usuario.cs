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
    public partial class frm_usuario : Form
    {
        public frm_usuario()
        {
            InitializeComponent();
        }


        private void registrar(string tarea)
        {
            var negocio = new LN_usuario();
            var parametros = new EN_usuario.prc_usuario_mnt();
            var retorno = new List<EN_zero.informe>();


            var op = new EN_usuario.t_usuario_tarea();
            op.tarea = tarea;

            var a = new EN_usuario.t_usuario();
            a.id_usuario = "T_U0000002"; // txt_id_usuario.text ;
            a.nombre = "ALF" ; // txt_nombre.text ;
            a.direccion ="lima"  ; // txt_direccion.text ;
            a.telefono = "205" ; // txt_telefono.text ;
            a.login = "ok" ; // txt_login.text ;
            a.contrasena ="123"  ; // txt_contrasena.text ;
            a.id_nivel = "1" ; // txt_id_nivel.text ;
            a.activo =true  ; // txt_activo.text ;
            a.fechaingreso = Convert.ToDateTime ("12/12/2016") ; // txt_fechaingreso.text ;
            a.fechaactualizacion = Convert.ToDateTime("12/12/2016")  ; // txt_fechaactualizacion.text ;
            a.id_estado = "01" ; // txt_id_estado.text ;

            parametros.t_usuario_tarea = op;
            parametros.t_usuario = a;

            retorno = negocio.prc_usuario_mnt(parametros);

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

        private void button1_Click(object sender, EventArgs e)
        {
            registrar("1");
        }
    }

}
