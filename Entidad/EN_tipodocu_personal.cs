using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_tipodocu_personal
    {

        public class t_tipodocu_personal
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_tipodocu_personal")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_tipodocu_personal { get; set; }

            [Display(Description = "nombre")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(50)]
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
            public DateTime fecha_inicia { get; set; }

            [Display(Description = "fecha_ultimo")]
            [Column(Order = 0)]
            [Required]
            public DateTime fecha_ultimo { get; set; }

        }


        public class proc_tipodocu_personal_mnt
        {
            public string id_usuario { get; set; }
            public List<t_tipodocu_personal> t_tipodocu_personal { get; set; }
        }

        public class proc_tipodocu_personal_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_tipodocu_personal> t_tipodocu_personal { get; set; }
        }


    }
}
