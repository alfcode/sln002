using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_empresa
    {
        public class t_empresa
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_empresa")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_empresa { get; set; }

            [Display(Description = "nombre")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(200)]
            public string nombre { get; set; }

            [Display(Description = "direccion")]
            [Column(Order = 0)]
            [MaxLength(200)]
            public string direccion { get; set; }

            [Display(Description = "ruc")]
            [Column(Order = 0)]
            [MaxLength(30)]
            public string ruc { get; set; }

            [Display(Description = "representante")]
            [Column(Order = 0)]
            [MaxLength(200)]
            public string representante { get; set; }

            [Display(Description = "telefono")]
            [Column(Order = 0)]
            [MaxLength(30)]
            public string telefono { get; set; }

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


        public class proc_empresa_mnt
        {
            public string id_usuario { get; set; }
            public List<t_empresa> t_empresa { get; set; }
        }

        public class proc_empresa_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_empresa> t_empresa { get; set; }
        }


    }
}
