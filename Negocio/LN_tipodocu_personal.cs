using Entidad;
using Datos;
namespace Negocio
{
    public class LN_tipodocu_personal
    {
       

        public EN_tipodocu_personal.proc_tipodocu_personal_mnt_retorno proc_tipodocu_personal_mnt(EN_tipodocu_personal.proc_tipodocu_personal_mnt parametros)
        {
            var retorno = new EN_tipodocu_personal.proc_tipodocu_personal_mnt_retorno();
            var datos = new DAO_tipodocu_personal();

            retorno = datos.proc_tipodocu_personal_mnt(parametros);

            return retorno;
        }

    }
}
