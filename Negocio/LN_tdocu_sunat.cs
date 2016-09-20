using Entidad;
using Datos;
namespace Negocio
{
    public class LN_tdocu_sunat
    {

        public EN_tdocu_sunat.proc_tdocu_sunat_mnt_retorno proc_tdocu_sunat_mnt(EN_tdocu_sunat.proc_tdocu_sunat_mnt parametros)
        {
            var retorno = new EN_tdocu_sunat.proc_tdocu_sunat_mnt_retorno();
            var datos = new DAO_tdocu_sunat();

            retorno = datos.proc_tdocu_sunat_mnt(parametros);

            return retorno;
        }

    }
}
