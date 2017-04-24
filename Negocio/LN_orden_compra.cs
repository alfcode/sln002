using Entidad;
using Datos;
namespace Negocio
{
    public class LN_orden_compra
    {
        public EN_orden_compra.proc_orden_compra_mnt_busca_retorno proc_orden_compra_mnt_busca(EN_orden_compra.proc_orden_compra_mnt_busca parametros)
        {

            var retorno = new EN_orden_compra.proc_orden_compra_mnt_busca_retorno();
            var datos = new DAO_orden_compra();

            retorno = datos.proc_orden_compra_mnt_busca(parametros);

            return retorno;
        }

        public EN_orden_compra.proc_orden_compra_mnt_combo proc_orden_compra_mnt_combo()
        {
            var retorno = new EN_orden_compra.proc_orden_compra_mnt_combo();
            var datos = new DAO_orden_compra();

            retorno = datos.proc_orden_compra_mnt_combo();

            return retorno;
        }

        public EN_orden_compra.proc_orden_compra_mnt_retorno proc_orden_compra_mnt(EN_orden_compra.proc_orden_compra_mnt parametros)
        {
            var retorno = new EN_orden_compra.proc_orden_compra_mnt_retorno();
            var datos = new DAO_orden_compra();

            retorno = datos.proc_orden_compra_mnt(parametros);

            return retorno;
        }

    }
}
