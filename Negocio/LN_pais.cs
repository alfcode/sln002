using Entidad;
using Datos;
namespace Negocio
{
    public class LN_pais
    {
       
        public EN_pais.proc_pais_mnt_retorno proc_pais_mnt(EN_pais.proc_pais_mnt parametros)
        {
            var retorno = new EN_pais.proc_pais_mnt_retorno();
            var datos = new DAO_pais();

            retorno = datos.proc_pais_mnt(parametros);

            return retorno;
        }

    }
}
