using Entidad;
using Datos;
namespace Negocio
{
    public class LN_rol
    {
       
        public EN_rol.proc_rol_mnt_retorno proc_rol_mnt(EN_rol.proc_rol_mnt parametros)
        {
            var retorno = new EN_rol.proc_rol_mnt_retorno();
            var datos = new DAO_rol();

            retorno = datos.proc_rol_mnt(parametros);

            return retorno;
        }

    }
}
