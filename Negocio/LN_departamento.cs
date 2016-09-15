using Entidad;
using Datos;
namespace Negocio
{
    public class LN_departamento
    {

        public EN_departamento.proc_departamento_mnt_retorno proc_departamento_mnt(EN_departamento.proc_departamento_mnt parametros)
        {
            var retorno = new EN_departamento.proc_departamento_mnt_retorno();
            var datos = new DAO_departamento();

            retorno = datos.proc_departamento_mnt(parametros);

            return retorno;
        }

    }
}
