using Entidad;
using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataWeb;
using System.Configuration;

namespace Negocio
{
    public class LN_guia
    {
        bool WebService = Convert.ToBoolean(ConfigurationManager.AppSettings["WebService"]);
          
        public EN_guia.retorno_guia_mnt proc_guia_mnt(EN_guia.proc_guia_mnt parametros)
        {

            EN_guia.retorno_guia_mnt retorno = new EN_guia.retorno_guia_mnt();

            
            if (WebService == false)
            {
                DAO_guia datos = new DAO_guia();
                retorno = datos.proc_guia_mnt(parametros);
            }

            if (WebService == true)
            {
                Dw_guia datosw = new Dw_guia();
                retorno = datosw.proc_guia_mnt(parametros);
            }
            return retorno;

        }


        public EN_guia.datos_consulta_guia proc_consulta_guia(EN_guia.proc_consulta_guia parametros)
        {

            EN_guia.datos_consulta_guia retorno = new EN_guia.datos_consulta_guia();

            if (WebService == true)
            {
                Dw_guia datosw = new Dw_guia();
                retorno = datosw.proc_consulta_guia(parametros);
            }

            if (WebService == false)
            {
                DAO_guia datos = new DAO_guia();
                retorno = datos.proc_consulta_guia(parametros);
            }

            return retorno;
            
        }

    }
}
