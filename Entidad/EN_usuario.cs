using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_usuario
    {
        public class t_usuario
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_usuario")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_usuario { get; set; }

            [Display(Description = "nombre")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(200)]
            public string nombre { get; set; }

            [Display(Description = "apepat")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(20)]
            public string apepat { get; set; }

            [Display(Description = "apemat")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(20)]
            public string apemat { get; set; }

            [Display(Description = "sexo")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(1)]
            public string sexo { get; set; }

            [Display(Description = "fechanac")]
            [Column(Order = 0)]
            public DateTime fechanac { get; set; }

            [Display(Description = "id_tipodocu_personal")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_tipodocu_personal { get; set; }

            [Display(Description = "num_tdocu")]
            [Column(Order = 0)]
            [MaxLength(20)]
            public string num_tdocu { get; set; }

            [Display(Description = "id_departamento")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_departamento { get; set; }

            [Display(Description = "id_provincia")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_provincia { get; set; }

            [Display(Description = "id_distrito")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_distrito { get; set; }

            [Display(Description = "direccion")]
            [Column(Order = 0)]
            [MaxLength(500)]
            public string direccion { get; set; }

            [Display(Description = "telefono1")]
            [Column(Order = 0)]
            [MaxLength(50)]
            public string telefono1 { get; set; }

            [Display(Description = "telefono2")]
            [Column(Order = 0)]
            [MaxLength(50)]
            public string telefono2 { get; set; }

            [Display(Description = "email")]
            [Column(Order = 0)]
            [MaxLength(50)]
            public string email { get; set; }

            [Display(Description = "id_area")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_area { get; set; }

            [Display(Description = "id_cargo")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_cargo { get; set; }

            [Display(Description = "fecha_ingreso")]
            [Column(Order = 0)]
            public DateTime fecha_ingreso { get; set; }

            [Display(Description = "foto")]
            [Column(Order = 0)]
            [MaxLength(200)]
            public string foto { get; set; }

            [Display(Description = "activo")]
            [Column(Order = 0)]
            [Required]
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

        public class proc_usuario_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> tipodocu_personal { get; set; }
            public List<EN_zero.datacombo> area { get; set; }
            public List<EN_zero.datacombo> cargo { get; set; }
            public List<EN_zero.datacombo> departamento { get; set; }
        }


        public class proc_usuario_mnt
        {
            public string id_usuario { get; set; }
            public List<t_usuario> t_usuario { get; set; }
        }

        public class proc_usuario_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_usuario> t_usuario { get; set; }
        }


    }
}
