using Entidad;
using Datos;
namespace Negocio
{
    public class LN_formapago
    {
       
        public EN_formapago.proc_formapago_mnt_retorno proc_formapago_mnt(EN_formapago.proc_formapago_mnt parametros)
        {
            var retorno = new EN_formapago.proc_formapago_mnt_retorno();
            var datos = new DAO_formapago();

            retorno = datos.proc_formapago_mnt(parametros);

            return retorno;
        }

    }
}
