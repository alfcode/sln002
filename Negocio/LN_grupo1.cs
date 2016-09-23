using Entidad;
using Datos;
namespace Negocio
{
    public class LN_grupo1
    {

        public EN_grupo3.proc_grupo3_mnt_combo proc_grupo3_mnt_combo()
        {
            var retorno = new EN_grupo3.proc_grupo3_mnt_combo();
            var datos = new DAO_grupo3();

            retorno = datos.proc_grupo3_mnt_combo();

            return retorno;
        }

        public EN_grupo1.proc_grupo1_mnt_retorno proc_grupo1_mnt(EN_grupo1.proc_grupo1_mnt parametros)
        {
            var retorno = new EN_grupo1.proc_grupo1_mnt_retorno();
            var datos = new DAO_grupo1();

            retorno = datos.proc_grupo1_mnt(parametros);

            return retorno;
        }

    }
}
