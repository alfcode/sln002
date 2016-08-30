using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_estado
    {
        public class t_estado
        {
            public string id_estado { get; set; }
            public string nombre { get; set; }
        }


        public class param_estado
        {
            public t_estado t_estado { get; set; }
            public EN_zero.accion accion { get; set; }
        }



    }
}
