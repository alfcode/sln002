using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
   public  class EN_guia
    {
        public class t_guia_tarea
        {
            public string tarea { get; set; }
        }

        public class t_guia_cab
        {
            public int id_guia { get; set; }
            public string numero_guia { get; set; }
            public string id_proveedor { get; set; }
            public string nom_proveedor { get; set; }
            public string direccion { get; set; }
        }

       

        public class t_guia_det
        {
            public int id_guia { get; set; }
            public int item { get; set; }
            public string producto { get; set; }
            public decimal cantidad { get; set; }
            public decimal precio { get; set; }
        }

        public class proc_guia_mnt
        {
            public t_guia_tarea t_guia_tarea { get; set; }
            public t_guia_cab t_guia_cab { get; set; }
            public List<t_guia_det> t_guia_det { get; set; }
        }


        public class proc_consulta_guia
        {
            public int id_guia { get; set; }
        }

        public class t_guia_id_guia
        {
            public int id_guia { get; set; }
        }


        public class datos_consulta_guia
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_guia_cab> t_guia_cab { get; set; }
            public List<t_guia_det> t_guia_det { get; set; }
        }

        public class retorno_guia_mnt
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_guia_id_guia> t_guia_id_guia { get; set; }
        }


    }
}
