using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
   public class EN_usuario
    {

       
            public class t_usuario
            {
                public string id_usuario { get; set; }
                public string nombre { get; set; }
                public string direccion { get; set; }
                public string telefono { get; set; }
                public string login { get; set; }
                public string contrasena { get; set; }
                public string id_nivel { get; set; }
                public bool activo { get; set; }
                public DateTime fechaingreso { get; set; }
                public DateTime fechaactualizacion { get; set; }
                public string id_estado { get; set; }
            }

            public class t_usuario_tarea
            {
              public string tarea { get; set;}
            }


           public class prc_usuario_mnt
            {
            public t_usuario t_usuario { get; set; }
            public t_usuario_tarea t_usuario_tarea { get; set; }
            }

    }
}
