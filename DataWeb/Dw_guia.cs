using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;

using System.Net.Http;
using System.Net.Http.Headers;

namespace DataWeb
{
    public class Dw_guia
    {
        public EN_guia.retorno_guia_mnt proc_guia_mnt(EN_guia.proc_guia_mnt parametros)
        {
            var retorno = new EN_guia.retorno_guia_mnt();
            var retorno_error = new Dw_zero();
            try
            {

                using (var client = new HttpClient())
                {
                    // HTTP POST
                    EN_zero.base_url api = new EN_zero.base_url();
                    client.BaseAddress = new Uri(api.principal);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync("guia/proc_guia_mnt", parametros).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        retorno = response.Content.ReadAsAsync<EN_guia.retorno_guia_mnt>().Result;
                    }
                    else
                    {
                      
                        retorno.informe= retorno_error.MsgInformeCapaDatos("proc_guia_mnt", response.StatusCode.ToString(), response.ReasonPhrase);
                       
                    }
                }

                return retorno;

            }
            catch (Exception ex)
            {
                retorno.informe= retorno_error.MsgInformeCapaDatos(retorno_error.MsgErrorCapaDatos(ex));
                return retorno;
            }

        }


        public EN_guia.datos_consulta_guia proc_consulta_guia(EN_guia.proc_consulta_guia parametros)
        {

            try
            {

                var datos = new EN_guia.datos_consulta_guia();

                using (var client = new HttpClient())
                {
                    // HTTP POST
                    EN_zero.base_url api = new EN_zero.base_url();
                    client.BaseAddress = new Uri(api.principal);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.PostAsJsonAsync("guia/proc_consulta_guia", parametros).Result;
                    if (response.IsSuccessStatusCode)
                    {

                        datos = response.Content.ReadAsAsync<EN_guia.datos_consulta_guia>().Result;

                    }
                    else
                    {
                        var ayuda = new Dw_zero();
                        var error = new EN_guia.datos_consulta_guia();
                        error.informe= ayuda.MsgInformeCapaDatos("proc_consulta_guia", response.StatusCode.ToString(), response.ReasonPhrase);

                    }

                }

                return datos;

            }
            catch (Exception ex)
            {
                var ayuda = new Dw_zero();
                var datos = new EN_guia.datos_consulta_guia();
                datos.informe = ayuda.MsgInformeCapaDatos(ayuda.MsgErrorCapaDatos(ex));
                return datos;

            }


        }


    }
}
