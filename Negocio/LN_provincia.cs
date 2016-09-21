using Entidad;
using Datos;
namespace Negocio
{
    public class LN_provincia
    {
        public EN_provincia.proc_provincia_mnt_combo proc_provincia_mnt_combo()
        {
            var retorno = new EN_provincia.proc_provincia_mnt_combo();
            var datos = new DAO_provincia();

            retorno = datos.proc_provincia_mnt_combo();

            return retorno;
        }

        public EN_provincia.proc_provincia_mnt_retorno proc_provincia_mnt(EN_provincia.proc_provincia_mnt parametros)
        {
            var retorno = new EN_provincia.proc_provincia_mnt_retorno();
            var datos = new DAO_provincia();

            retorno = datos.proc_provincia_mnt(parametros);

            return retorno;
        }

    }
}
