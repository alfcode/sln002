using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_distrito
    {
        public class t_distrito
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_distrito")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_distrito { get; set; }

            [Display(Description = "nombre")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(100)]
            public string nombre { get; set; }

            [Display(Description = "id_provincia")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_provincia { get; set; }

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


        public class proc_distrito_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> distrito{ get; set; }
        }

        public class proc_distrito_mnt_combo_parametro
        {
            public string id_provincia { get; set; }
        }

        public class proc_distrito_mnt
        {
            public string id_usuario { get; set; }
            public List<t_distrito> t_distrito { get; set; }
        }

        public class proc_distrito_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_distrito> t_distrito { get; set; }
        }


    }
}
