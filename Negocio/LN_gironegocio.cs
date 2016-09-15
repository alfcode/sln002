using Entidad;
using Datos;
namespace Negocio
{
    public class LN_gironegocio
    {
       

        public EN_gironegocio.proc_gironegocio_mnt_retorno proc_gironegocio_mnt(EN_gironegocio.proc_gironegocio_mnt parametros)
        {
            var retorno = new EN_gironegocio.proc_gironegocio_mnt_retorno();
            var datos = new DAO_gironegocio();

            retorno = datos.proc_gironegocio_mnt(parametros);

            return retorno;
        }

    }
}
