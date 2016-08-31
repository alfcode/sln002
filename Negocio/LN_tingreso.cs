using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
namespace Negocio
{
    public class LN_tingreso
    {

        public List<EN_zero.informe> prc_tingreso(EN_tingreso.param_tingreso parametros)
        {
            var retorno = new List<EN_zero.informe>();
            var datos = new DAO_tingreso();

            retorno = datos.prc_tingreso(parametros);

            return retorno;
        }


    }
}
