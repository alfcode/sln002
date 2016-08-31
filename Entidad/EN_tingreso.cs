using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_tingreso
    {
        public class t_tingreso
        {
            public string id_tingreso { get; set; }
            public string nombre { get; set; }
            public string abreviatura { get; set; }
            public string id_usuario_inicia { get; set; }
            public string id_usuario_ultimo { get; set; }
            public DateTime fecha_inicia { get; set; }
            public DateTime fecha_ultimo { get; set; }
            public string id_estado { get; set; }
        }


        public class param_tingreso
        {
            public t_tingreso t_ingreso { get; set; }
            public EN_zero.accion accion { get; set; }

        }    
    }
}