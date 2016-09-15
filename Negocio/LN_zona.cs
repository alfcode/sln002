using Entidad;
using Datos;
namespace Negocio
{
    public class LN_zona
    {
       
        public EN_zona.proc_zona_mnt_retorno proc_zona_mnt(EN_zona.proc_zona_mnt parametros)
        {
            var retorno = new EN_zona.proc_zona_mnt_retorno();
            var datos = new DAO_zona();

            retorno = datos.proc_zona_mnt(parametros);

            return retorno;
        }

    }
}
