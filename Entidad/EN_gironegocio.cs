using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_gironegocio
    {
        public class t_gironegocio
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_gironegocio { get; set; }

            [Display(Description = "Giro de Negocio")]
            [Column(Order = 300)]
            [Required]
            [MaxLength(100)]
            public string nombre { get; set; }

            [Display(Description = "Codigo Sunat")]
            [Column(Order = 98)]
            [MaxLength(10)]
            public string codigo { get; set; }

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

        public class proc_gironegocio_mnt
        {
            public string id_usuario { get; set; }
            public List<t_gironegocio> t_gironegocio { get; set; }
        }

        public class proc_gironegocio_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_gironegocio> t_gironegocio { get; set; }
        }


    }
}
