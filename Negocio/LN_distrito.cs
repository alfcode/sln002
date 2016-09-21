using Entidad;
using Datos;
namespace Negocio
{
    public class LN_distrito
    {
        public EN_distrito.proc_distrito_mnt_combo proc_distrito_mnt_combo()
        {
            var retorno = new EN_distrito.proc_distrito_mnt_combo();
            var datos = new DAO_distrito();

            retorno = datos.proc_distrito_mnt_combo();

            return retorno;
        }

        public EN_distrito.proc_distrito_mnt_retorno proc_distrito_mnt(EN_distrito.proc_distrito_mnt parametros)
        {
            var retorno = new EN_distrito.proc_distrito_mnt_retorno();
            var datos = new DAO_distrito();

            retorno = datos.proc_distrito_mnt(parametros);

            return retorno;
        }

    }
}
