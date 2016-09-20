using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_articulo
    {
        public class t_articulo
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_articulo { get; set; }

            [Key]
            [Display(Description = "Articulo")]
            [Column(Order = 200)]
            [Required]
            [MaxLength(200)]
            public string nombre { get; set; }

            [Display(Description = "Observacion")]
            [Column(Order = 120)]
            [MaxLength(200)]
            public string observacion { get; set; }

            [Display(Description = "Unidad Base")]
            [Column(Order = 80)]
            [Required]
            [MaxLength(10)]
            public string id_unidad1 { get; set; }

            [Display(Description = "Unidad Factor")]
            [Column(Order = 80)]
            [Required]
            [MaxLength(10)]
            public string id_unidad2 { get; set; }

            [Display(Description = "F.UM",Prompt ="1")]
            [Column(Order = 70)]
            [Required]
            public decimal factor { get; set; }

            [Display(Description = "Linea")]
            [Column(Order = 120)]
            [Required]
            [MaxLength(10)]
            public string id_grupo1 { get; set; }

            [Display(Description = "Familia")]
            [Column(Order = 120)]
            [Required]
            [MaxLength(10)]
            public string id_grupo2 { get; set; }

            [Display(Description = "Categoria")]
            [Column(Order = 120)]
            [Required]
            [MaxLength(10)]
            public string id_grupo3 { get; set; }

            [Display(Description = "",Prompt = "GRU0000001")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_grupo4 { get; set; }

            [Display(Description = "",Prompt = "GRU0000001")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_grupo5 { get; set; }

            [Display(Description = "")]
            [Column(Order = 0)]
            [MaxLength(300)]
            public string imagen { get; set; }

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


        public class proc_articulo_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> unidad { get; set; }
            public List<EN_zero.datacombo> grupo1 { get; set; }
            public List<EN_zero.datacombo> grupo2 { get; set; }
            public List<EN_zero.datacombo> grupo3 { get; set; }
        }

        public class proc_articulo_mnt
        {
            public string id_usuario{ get; set; }
            public List<t_articulo> t_articulo { get; set; }
        }

        public class proc_articulo_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_articulo> t_articulo { get; set; }
        }


    }
}
