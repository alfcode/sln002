using Entidad;
using Datos;
namespace Negocio
{
    public class LN_grupo2
    {

        public EN_grupo2.proc_grupo2_mnt_combo proc_grupo2_mnt_combo()
        {
            var retorno = new EN_grupo2.proc_grupo2_mnt_combo();
            var datos = new DAO_grupo2();

            retorno = datos.proc_grupo2_mnt_combo();

            return retorno;
        }


        public EN_grupo2.proc_grupo2_mnt_retorno proc_grupo2_mnt(EN_grupo2.proc_grupo2_mnt parametros)
        {
            var retorno = new EN_grupo2.proc_grupo2_mnt_retorno();
            var datos = new DAO_grupo2();

            retorno = datos.proc_grupo2_mnt(parametros);

            return retorno;
        }

    }
}
