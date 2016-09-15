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
        public EN_estado.proc_estado_mnt_retorno proc_estado_mnt(EN_estado.proc_estado_mnt parametros)
        {
            var retorno = new EN_estado.proc_estado_mnt_retorno();
            var datos = new DAO_estado();

            retorno = datos.proc_estado_mnt(parametros);

            return retorno;
        }

    }
}
