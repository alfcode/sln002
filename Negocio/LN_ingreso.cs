using System;
using System.Collections.Generic;
using Entidad;
using Datos;
namespace Negocio
{
    public class LN_ingreso
    {

        public EN_ingreso.proc_ingreso_mnt_busca_retorno proc_ingreso_mnt_busca (EN_ingreso.proc_ingreso_mnt_busca parametros)
        {

            var retorno = new EN_ingreso.proc_ingreso_mnt_busca_retorno();
            var datos = new DAO_ingreso();

            retorno = datos.proc_ingreso_mnt_busca(parametros);

            return retorno;
        }

        public EN_ingreso.proc_ingreso_mnt_combo proc_ingreso_mnt_combo()
        {
            var retorno = new EN_ingreso.proc_ingreso_mnt_combo();
            var datos = new DAO_ingreso();

            retorno = datos.proc_ingreso_mnt_combo();

            return retorno;
        }

        public EN_ingreso.proc_ingreso_mnt_tipo_unidad_almacen proc_ingreso_mnt_tipo_unidad_almacen(EN_ingreso.proc_ingreso_mnt_tipo_unidad_almacen_parametros parametros)
        {
            var retorno = new EN_ingreso.proc_ingreso_mnt_tipo_unidad_almacen();
            var datos = new DAO_ingreso();

            retorno = datos.proc_ingreso_mnt_tipo_unidad_almacen(parametros);

            return retorno;
        }



        public EN_ingreso.proc_ingreso_mnt_retorno proc_ingreso_mnt(EN_ingreso.proc_ingreso_mnt parametros)
        {
            var retorno = new EN_ingreso.proc_ingreso_mnt_retorno();
            var datos = new DAO_ingreso();

            retorno = datos.proc_ingreso_mnt(parametros);

            return retorno;
        }

    }
}
