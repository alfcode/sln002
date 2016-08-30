using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Entidad;
using Negocio;

namespace WebApp.Controllers
{
    public class guiaController : ApiController
    {

        [HttpPost]
        public EN_guia.retorno_guia_mnt proc_guia_mnt(EN_guia.proc_guia_mnt parametros)
        {
            var datos = new LN_guia();
            return datos.proc_guia_mnt(parametros);
        }

        [HttpPost]
        public EN_guia.datos_consulta_guia proc_consulta_guia(EN_guia.proc_consulta_guia parametros)
        {
            var datos = new LN_guia();
            return datos.proc_consulta_guia(parametros);
        }

    }
}
