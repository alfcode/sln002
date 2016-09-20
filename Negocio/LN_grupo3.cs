using Entidad;
using Datos;
namespace Negocio
{
    public class LN_grupo3
    {

        public EN_grupo3.proc_grupo3_mnt_retorno proc_grupo3_mnt(EN_grupo3.proc_grupo3_mnt parametros)
        {
            var retorno = new EN_grupo3.proc_grupo3_mnt_retorno();
            var datos = new DAO_grupo3();

            retorno = datos.proc_grupo3_mnt(parametros);

            return retorno;
        }

    }
}
