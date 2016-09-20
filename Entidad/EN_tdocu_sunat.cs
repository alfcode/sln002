using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_tdocu_sunat
    {
        public class t_tdocu_sunat
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_tdocu_sunat { get; set; }

            [Display(Description = "Documento Sunat")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(50)]
            public string nombre { get; set; }

            [Display(Description = "Abreviatura")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string abreviatura { get; set; }

            [Display(Description = "Codigo Sunat")]
            [Column(Order = 0)]
            [MaxLength(50)]
            public string cod_sunat { get; set; }

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


        public class proc_tdocu_sunat_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> unidad { get; set; }
            public List<EN_zero.datacombo> grupo1 { get; set; }
            public List<EN_zero.datacombo> grupo2 { get; set; }
            public List<EN_zero.datacombo> grupo3 { get; set; }
        }

        public class proc_tdocu_sunat_mnt
        {
            public string id_usuario { get; set; }
            public List<t_tdocu_sunat> t_tdocu_sunat { get; set; }
        }

        public class proc_tdocu_sunat_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_tdocu_sunat> t_tdocu_sunat { get; set; }
        }


    }
}
