using Entidad;
using Datos;
namespace Negocio
{
    public class LN_distrito
    {
        public EN_distrito.proc_distrito_mnt_combo proc_distrito_mnt_combo(EN_distrito.proc_distrito_mnt_combo_parametro parametros)
        {
            var retorno = new EN_distrito.proc_distrito_mnt_combo();
            var datos = new DAO_distrito();

            retorno = datos.proc_distrito_mnt_combo(parametros);

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
