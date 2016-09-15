using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_zona
    {
        public class t_zona
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_zona")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_zona { get; set; }

            [Display(Description = "nombre")]
            [Column(Order = 0)]
            [MaxLength(80)]
            public string nombre { get; set; }

            [Display(Description = "activo")]
            [Column(Order = 0)]
            public bool activo { get; set; }

            [Display(Description = "id_usuario_inicia")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_usuario_inicia { get; set; }

            [Display(Description = "id_usuario_ultimo")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_usuario_ultimo { get; set; }

            [Display(Description = "fecha_inicia")]
            [Column(Order = 0)]
            public DateTime fecha_inicia { get; set; }

            [Display(Description = "fecha_ultimo")]
            [Column(Order = 0)]
            public DateTime fecha_ultimo { get; set; }

        }


        public class proc_zona_mnt
        {
            public string id_usuario { get; set; }
            public List<t_zona> t_zona { get; set; }
        }

        public class proc_zona_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_zona> t_zona { get; set; }
        }


    }
}
