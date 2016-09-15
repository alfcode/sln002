using Entidad;
using Datos;
namespace Negocio
{
    public class LN_empresa
    {
       
        public EN_empresa.proc_empresa_mnt_retorno proc_empresa_mnt(EN_empresa.proc_empresa_mnt parametros)
        {
            var retorno = new EN_empresa.proc_empresa_mnt_retorno();
            var datos = new DAO_empresa();

            retorno = datos.proc_empresa_mnt(parametros);

            return retorno;
        }

    }
}
