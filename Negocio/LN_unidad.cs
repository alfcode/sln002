using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
namespace Negocio
{
   public class LN_unidad
    {

           public EN_unidad.proc_unidad_mnt_retorno proc_unidad_mnt(EN_unidad.proc_unidad_mnt parametros)
        {
            var retorno = new EN_unidad.proc_unidad_mnt_retorno();
            var datos = new DAO_unidad();

            retorno = datos.proc_unidad_mnt(parametros);
    
            return retorno;
        }

    }
}
