using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class EN_articulo
    {

        public class t_articulo
        {
            public string id_articulo { get; set; }
            public string nombre { get; set; }
            public string observacion { get; set; }
            public string id_unidad1 { get; set; }
            public string id_unidad2 { get; set; }
            public decimal factor { get; set; }
            public string id_grupo1 { get; set; }
            public string id_grupo2 { get; set; }
            public string id_grupo3 { get; set; }
            public string id_grupo4 { get; set; }
            public string id_grupo5 { get; set; }
            public string imagen { get; set; }
            public string id_usuario_inicia { get; set; }
            public string id_usuario_ultimo { get; set; }
            public DateTime fecha_inicia { get; set; }
            public DateTime fecha_ultimo { get; set; }
            public string id_estado { get; set; }
        }




    }
}
