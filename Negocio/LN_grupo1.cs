using Entidad;
using Datos;
namespace Negocio
{
    public class LN_grupo1
    {

        public EN_grupo1.proc_grupo1_mnt_retorno proc_grupo1_mnt(EN_grupo1.proc_grupo1_mnt parametros)
        {
            var retorno = new EN_grupo1.proc_grupo1_mnt_retorno();
            var datos = new DAO_grupo1();

            retorno = datos.proc_grupo1_mnt(parametros);

            return retorno;
        }

    }
}
