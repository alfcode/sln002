using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_formapago
    {
        public class t_formapago
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_formapago")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_formapago { get; set; }

            [Display(Description = "nombre")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(100)]
            public string nombre { get; set; }

            [Display(Description = "plazo")]
            [Column(Order = 0)]
            public decimal plazo { get; set; }

            [Display(Description = "fecha_vcto")]
            [Column(Order = 0)]
            public DateTime fecha_vcto { get; set; }

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


        public class proc_formapago_mnt
        {
            public string id_usuario { get; set; }
            public List<t_formapago> t_formapago { get; set; }
        }

        public class proc_formapago_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_formapago> t_formapago { get; set; }
        }


    }
}
