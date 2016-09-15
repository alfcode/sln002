using Entidad;
using Datos;
namespace Negocio
{
    public class LN_almacen
    {
        public EN_almacen.proc_almacen_mnt_combo proc_almacen_mnt_combo()
        {
            var retorno = new EN_almacen.proc_almacen_mnt_combo();
            var datos = new DAO_almacen();

            retorno = datos.proc_almacen_mnt_combo();

            return retorno;
        }

        public EN_almacen.proc_almacen_mnt_retorno proc_almacen_mnt(EN_almacen.proc_almacen_mnt parametros)
        {
            var retorno = new EN_almacen.proc_almacen_mnt_retorno();
            var datos = new DAO_almacen();

            retorno = datos.proc_almacen_mnt(parametros);

            return retorno;
        }

    }
}
