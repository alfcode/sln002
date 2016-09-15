using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_rol
    {
        public class t_rol
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_rol")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_rol { get; set; }

            [Display(Description = "nombre")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(255)]
            public string nombre { get; set; }

            [Display(Description = "activo")]
            [Column(Order = 0)]
            [Required]
            public bool activo { get; set; }

            [Display(Description = "id_usuario_inicia")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_usuario_inicia { get; set; }

            [Display(Description = "id_usuario_ultimo")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_usuario_ultimo { get; set; }

            [Display(Description = "fecha_inicia")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string fecha_inicia { get; set; }

            [Display(Description = "fecha_ultimo")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string fecha_ultimo { get; set; }

        }


        public class proc_rol_mnt
        {
            public string id_usuario { get; set; }
            public List<t_rol> t_rol { get; set; }
        }

        public class proc_rol_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_rol> t_rol { get; set; }
        }


    }
}
