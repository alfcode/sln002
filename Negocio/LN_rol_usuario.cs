using Entidad;
using Datos;
namespace Negocio
{
    public class LN_rol_usuario
    {

        public EN_rol_usuario.proc_rol_usuario_mnt_combo proc_rol_usuario_mnt_combo()
        {
            var retorno = new EN_rol_usuario.proc_rol_usuario_mnt_combo();
            var datos = new DAO_rol_usuario();

            retorno = datos.proc_rol_usuario_mnt_combo();

            return retorno;
        }


        public EN_rol_usuario.proc_rol_usuario_mnt_retorno proc_rol_usuario_mnt(EN_rol_usuario.proc_rol_usuario_mnt parametros)
        {
            var retorno = new EN_rol_usuario.proc_rol_usuario_mnt_retorno();
            var datos = new DAO_rol_usuario();

            retorno = datos.proc_rol_usuario_mnt(parametros);

            return retorno;
        }

    }
}
