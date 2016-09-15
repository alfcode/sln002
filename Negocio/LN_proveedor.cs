using Entidad;
using Datos;
namespace Negocio
{
    public class LN_proveedor
    {
        public EN_proveedor.proc_proveedor_mnt_combo proc_proveedor_mnt_combo()
        {
            var retorno = new EN_proveedor.proc_proveedor_mnt_combo();
            var datos = new DAO_proveedor();

            retorno = datos.proc_proveedor_mnt_combo();

            return retorno;
        }

        public EN_proveedor.proc_proveedor_mnt_retorno proc_proveedor_mnt(EN_proveedor.proc_proveedor_mnt parametros)
        {
            var retorno = new EN_proveedor.proc_proveedor_mnt_retorno();
            var datos = new DAO_proveedor();

            retorno = datos.proc_proveedor_mnt(parametros);

            return retorno;
        }

    }
}
