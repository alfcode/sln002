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

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_almacen { get; set; }

            [Display(Description = "Almacen")]
            [Column(Order = 220)]
            [Required]
            [MaxLength(100)]
            public string nombre { get; set; }

            [Display(Description = "Nivel Tipo Unidad")]
            [Column(Order = 100)]
            [Required]
            public decimal id_tipo_unidad { get; set; }

            [Display(Description = "Ventas?", Prompt = "0")]
            [Column(Order = 50)]
            [Required]
            public bool venta { get; set; }

            [Display(Description = "Representante")]
            [Column(Order = 200)]
            [MaxLength(200)]
            public string representante { get; set; }

            [Display(Description = "Direccion")]
            [Column(Order = 230)]
            [MaxLength(200)]
            public string direccion { get; set; }

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_empresa { get; set; }


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


        public class proc_almacen_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> empresa { get; set; }
            public List<EN_zero.datacombo> tipo_unidad { get; set; }
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
