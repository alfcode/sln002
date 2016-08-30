using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_zero
    {

        public class base_url
        {
            private string _base_url;
            public string principal
            {
                get
                {
                    _base_url = "http://zipcode-001-site1.etempurl.com/produccion/api/";
                  //  _base_url = "http://192.168.1.199/produccion/api/";
                    //logic here 
                    return _base_url;
                }
                set
                {
                    //logic here
                    _base_url = value;
                }
            }
        }
        


       
        public class accion
        {
            public string tarea { get; set; }
        }

        public class informe
        {
            public string Id { get; set; }
            public int Error { get; set; }
            public string Procedure { get; set; }
            public int Linea { get; set; }
            public string Mensaje { get; set; }

        }



        public static string ExisteError(List<EN_zero.informe> datos)
        {
            //string idx = (from Lista in informe
            //             select Lista.Id).First().ToString();

            string _id = "";
            string _error = "";
            string _procedure = "";
            string _linea = "";
            string _mensaje = "";

            foreach (var lista in datos)
            {
                _id = lista.Id.ToString();
                _error = lista.Error.ToString();
                _procedure = lista.Procedure.ToString();
                _linea = lista.Linea.ToString();
                _mensaje = lista.Mensaje.ToString();
            }

            if (_id == "1")
            {
              
                var mensaje = "Nro Error: " + _error + "Procedure: " + _procedure + "Linea: " + _linea + "Aviso: " + _mensaje;
                return mensaje;

            }

            return "";
        }




    }
}
