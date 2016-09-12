using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
namespace Negocio
{
    public class LN_articulo
    {
        public EN_articulo.proc_articulo_mnt_combo proc_articulo_mnt_combo()
        {
            var retorno = new EN_articulo.proc_articulo_mnt_combo();
            var datos = new DAO_articulo();

            retorno = datos.proc_articulo_mnt_combo();

            return retorno;
        }

        public EN_articulo.proc_articulo_mnt_retorno proc_articulo_mnt(EN_articulo.proc_articulo_mnt parametros)
        {
            var retorno = new EN_articulo.proc_articulo_mnt_retorno();
            var datos = new DAO_articulo();

            retorno = datos.proc_articulo_mnt(parametros);
    
            return retorno;
        }

    }
}
