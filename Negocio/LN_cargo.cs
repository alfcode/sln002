using Entidad;
using Datos;
namespace Negocio
{
    public class LN_cargo
    {

        public EN_cargo.proc_cargo_mnt_combo proc_cargo_mnt_combo()
        {
            var retorno = new EN_cargo.proc_cargo_mnt_combo();
            var datos = new DAO_cargo();

            retorno = datos.proc_cargo_mnt_combo();

            return retorno;
        }



        public EN_cargo.proc_cargo_mnt_retorno proc_cargo_mnt(EN_cargo.proc_cargo_mnt parametros)
        {
            var retorno = new EN_cargo.proc_cargo_mnt_retorno();
            var datos = new DAO_cargo();

            retorno = datos.proc_cargo_mnt(parametros);

            return retorno;
        }

    }
}
