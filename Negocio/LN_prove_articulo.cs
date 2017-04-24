using Entidad;
using Datos;
namespace Negocio
{
    public class LN_prove_articulo
    {
        public EN_prove_articulo.proc_prove_articulo_mnt_combo proc_prove_articulo_mnt_combo()
        {
            var retorno = new EN_prove_articulo.proc_prove_articulo_mnt_combo();
            var datos = new DAO_prove_articulo();

            retorno = datos.proc_prove_articulo_mnt_combo();

            return retorno;
        }

        public EN_prove_articulo.proc_prove_articulo_mnt_retorno proc_prove_articulo_mnt(EN_prove_articulo.proc_prove_articulo_mnt parametros)
        {
            var retorno = new EN_prove_articulo.proc_prove_articulo_mnt_retorno();
            var datos = new DAO_prove_articulo();

            retorno = datos.proc_prove_articulo_mnt(parametros);

            return retorno;
        }

    }
}
