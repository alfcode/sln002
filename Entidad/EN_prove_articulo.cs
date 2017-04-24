using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_prove_articulo
    {
        public class t_prove_articulo
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_proveedor")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_proveedor { get; set; }

            [Key]
            [Display(Description = "Articulo")]
            [Column(Order = 336)]
            [Required]
            [MaxLength(10)]
            public string id_articulo { get; set; }

            [Display(Description = "Moneda",Prompt ="MON0000001")]
            [Column(Order = 100)]
            [Required]
            [MaxLength(10)]
            public string id_moneda { get; set; }

            [Display(Description = "Costo")]
            [Column(Order = 70)]
            [Required]
            public decimal costo { get; set; }

            [Display(Description = "Cant.Limite")]
            [Column(Order = 65)]
            [Required]
            public decimal cantidad_limite { get; set; }

            [Display(Description = "activa_limite",Prompt ="1")]
            [Column(Order = 0)]
            [Required]
            public bool activa_limite { get; set; }

            [Display(Description = "Igv", Prompt = "1")]
            [Column(Order = 40)]
            [Required]
            public bool igv { get; set; }

            [Display(Description = "Isc",Prompt = "0")]
            [Column(Order = 40)]
            [Required]
            public bool isc { get; set; }


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



        public class proc_prove_articulo_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> proveedor { get; set; }
            public List<EN_zero.datacombo> articulo{ get; set; }
            public List<EN_zero.datacombo> moneda { get; set; }
        }

        public class proc_prove_articulo_mnt
        {
            public string id_usuario { get; set; }
            public string id_proveedor { get; set; }
            public List<t_prove_articulo> t_prove_articulo { get; set; }
        }

        public class proc_prove_articulo_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_prove_articulo> t_prove_articulo { get; set; }
        }


    }
}
