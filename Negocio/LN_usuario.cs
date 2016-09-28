using Entidad;
using Datos;
using System.Collections.Generic;

namespace Negocio
{
    public class LN_usuario
    {
        public EN_usuario.proc_usuario_mnt_combo proc_usuario_mnt_combo()
        {
            var retorno = new EN_usuario.proc_usuario_mnt_combo();
            var datos = new DAO_usuario();

            retorno = datos.proc_usuario_mnt_combo();

            return retorno;
        }

        public EN_usuario.proc_usuario_mnt_retorno proc_usuario_mnt(EN_usuario.proc_usuario_mnt parametros)
        {
            var retorno = new EN_usuario.proc_usuario_mnt_retorno();
            var datos = new DAO_usuario();

            retorno = datos.proc_usuario_mnt(parametros);

            return retorno;
        }

    }
}
