using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
namespace Negocio
{
   public class LN_estado
    {

        public List<EN_zero.informe> proc_estado_mnt(EN_estado.param_estado parametros)
        {
            var retorno = new List<EN_zero.informe>();
            var datos = new DAO_estado();
            retorno = datos.proc_estado_mnt(parametros);

            return retorno;
        }

    }
}
