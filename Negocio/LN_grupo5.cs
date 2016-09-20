using Entidad;
using Datos;
namespace Negocio
{
    public class LN_grupo5
    {

        public EN_grupo5.proc_grupo5_mnt_retorno proc_grupo5_mnt(EN_grupo5.proc_grupo5_mnt parametros)
        {
            var retorno = new EN_grupo5.proc_grupo5_mnt_retorno();
            var datos = new DAO_grupo5();

            retorno = datos.proc_grupo5_mnt(parametros);

            return retorno;
        }

    }
}
