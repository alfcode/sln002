using Entidad;
using Datos;
namespace Negocio
{
    public class LN_area
    {
      
        public EN_area.proc_area_mnt_retorno proc_area_mnt(EN_area.proc_area_mnt parametros)
        {
            var retorno = new EN_area.proc_area_mnt_retorno();
            var datos = new DAO_area();

            retorno = datos.proc_area_mnt(parametros);

            return retorno;
        }

    }
}
