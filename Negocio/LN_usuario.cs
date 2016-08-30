using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
namespace Negocio
{
    public class LN_usuario
    {

        public List<EN_zero.informe> prc_usuario_mnt(EN_usuario.prc_usuario_mnt parametros)
        {
            var retorno = new List<EN_zero.informe>();

            var datos = new DAO_usuario();
            retorno=datos.prc_usuario_mnt(parametros);

            return retorno;
        }


    }
}
