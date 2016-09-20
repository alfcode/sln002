using Entidad;
using Datos;
namespace Negocio
{
    public class LN_grupo4
    {

        public EN_grupo4.proc_grupo4_mnt_retorno proc_grupo4_mnt(EN_grupo4.proc_grupo4_mnt parametros)
        {
            var retorno = new EN_grupo4.proc_grupo4_mnt_retorno();
            var datos = new DAO_grupo4();

            retorno = datos.proc_grupo4_mnt(parametros);

            return retorno;
        }

    }
}
