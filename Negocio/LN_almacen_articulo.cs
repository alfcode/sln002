using Entidad;
using Datos;
namespace Negocio
{
    public class LN_almacen_articulo
    {
        public EN_almacen_articulo.proc_almacen_articulo_mnt_combo proc_almacen_articulo_mnt_combo()
        {
            var retorno = new EN_almacen_articulo.proc_almacen_articulo_mnt_combo();
            var datos = new DAO_almacen_articulo();

            retorno = datos.proc_almacen_articulo_mnt_combo();

            return retorno;
        }

        public EN_almacen_articulo.proc_almacen_articulo_mnt_retorno proc_almacen_articulo_mnt(EN_almacen_articulo.proc_almacen_articulo_mnt parametros)
        {
            var retorno = new EN_almacen_articulo.proc_almacen_articulo_mnt_retorno();
            var datos = new DAO_almacen_articulo();

            retorno = datos.proc_almacen_articulo_mnt(parametros);

            return retorno;
        }

    }
}
