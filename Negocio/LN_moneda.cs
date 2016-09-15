using Entidad;
using Datos;
namespace Negocio
{
    public class LN_moneda
    {
       

        public EN_moneda.proc_moneda_mnt_retorno proc_moneda_mnt(EN_moneda.proc_moneda_mnt parametros)
        {
            var retorno = new EN_moneda.proc_moneda_mnt_retorno();
            var datos = new DAO_moneda();

            retorno = datos.proc_moneda_mnt(parametros);

            return retorno;
        }

    }
}
