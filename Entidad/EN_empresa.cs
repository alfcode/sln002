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

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_empresa { get; set; }

            [Display(Description = "Empresa")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(200)]
            public string nombre { get; set; }

            [Display(Description = "Dirección")]
            [Column(Order = 0)]
            [MaxLength(200)]
            public string direccion { get; set; }

            [Display(Description = "RUC")]
            [Column(Order = 0)]
            [MaxLength(30)]
            public string ruc { get; set; }

            [Display(Description = "Representante")]
            [Column(Order = 0)]
            [MaxLength(200)]
            public string representante { get; set; }

            [Display(Description = "Telefono")]
            [Column(Order = 0)]
            [MaxLength(30)]
            public string telefono { get; set; }

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
