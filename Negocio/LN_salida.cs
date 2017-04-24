using System;
using System.Collections.Generic;
using Entidad;
using Datos;
namespace Negocio
{
    public class LN_salida
    {

        public EN_salida.proc_salida_mnt_busca_retorno proc_salida_mnt_busca(EN_salida.proc_salida_mnt_busca parametros)
        {

            var retorno = new EN_salida.proc_salida_mnt_busca_retorno();
            var datos = new DAO_salida();

            retorno = datos.proc_salida_mnt_busca(parametros);

            return retorno;
        }

        public EN_salida.proc_salida_mnt_combo proc_salida_mnt_combo()
        {
            var retorno = new EN_salida.proc_salida_mnt_combo();
            var datos = new DAO_salida();

            retorno = datos.proc_salida_mnt_combo();

            return retorno;
        }

        public EN_salida.proc_salida_mnt_tipo_unidad_almacen proc_salida_mnt_tipo_unidad_almacen(EN_salida.proc_salida_mnt_tipo_unidad_almacen_parametros parametros)
        {
            var retorno = new EN_salida.proc_salida_mnt_tipo_unidad_almacen();
            var datos = new DAO_salida();

            retorno = datos.proc_salida_mnt_tipo_unidad_almacen(parametros);

            return retorno;
        }



        public EN_salida.proc_salida_mnt_retorno proc_salida_mnt(EN_salida.proc_salida_mnt parametros)
        {
            var retorno = new EN_salida.proc_salida_mnt_retorno();
            var datos = new DAO_salida();

            retorno = datos.proc_salida_mnt(parametros);

            return retorno;
        }

    }
}
