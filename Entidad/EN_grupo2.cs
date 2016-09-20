using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_grupo2
    {
        public class t_grupo2
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_grupo2 { get; set; }

            [Display(Description = "Familia")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(50)]
            public string nombre { get; set; }

            [Display(Description = "CC")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string cc { get; set; }

            [Display(Description = "Activo", Prompt = "1")]
            [Column(Order = 40)]
            [Required]
            public bool activo { get; set; }

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_usuario_inicia { get; set; }

            [Display(Description = "", Prompt = "nuevo")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_usuario_ultimo { get; set; }

            [Display(Description = "", Prompt = "01/01/2016")]
            [Column(Order = 0)]
            [Required]
            public DateTime fecha_inicia { get; set; }

            [Display(Description = "", Prompt = "01/01/2016")]
            [Column(Order = 0)]
            [Required]
            public DateTime fecha_ultimo { get; set; }

        }

        public class proc_grupo2_mnt
        {
            public string id_usuario { get; set; }
            public List<t_grupo2> t_grupo2 { get; set; }
        }

        public class proc_grupo2_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_grupo2> t_grupo2 { get; set; }
        }


    }
}
