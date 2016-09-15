using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_almacen
    {
        public class t_almacen
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_almacen")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_almacen { get; set; }

            [Display(Description = "nombre")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(100)]
            public string nombre { get; set; }

            [Display(Description = "representante")]
            [Column(Order = 0)]
            [MaxLength(200)]
            public string representante { get; set; }

            [Display(Description = "direccion")]
            [Column(Order = 0)]
            [MaxLength(200)]
            public string direccion { get; set; }

            [Display(Description = "id_empresa")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_empresa { get; set; }

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


        public class proc_almacen_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> empresa { get; set; }
        }

        public class proc_almacen_mnt
        {
            public string id_usuario { get; set; }
            public List<t_almacen> t_almacen { get; set; }
        }

        public class proc_almacen_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_almacen> t_almacen { get; set; }
        }


    }
}
