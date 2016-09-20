using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Cls_Global.mostrar_ancho_xgrid = true;
            Cls_Global.mostrar_msg_demora = false;
            Cls_Global.id_usuario = "USU0000001";
            Cls_Global.skinName = "McSkin";
            Cls_Global.empresa = " :: Capsule Corporation ::";
           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frm_articulo());
        }
    }
}
