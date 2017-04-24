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

            [Display(Description = "Linea")]
            [Column(Order = 180)]
            [Required]
            [MaxLength(10)]
            public string id_grupo1 { get; set; }

            [Display(Description = "Familia")]
            [Column(Order = 150)]
            [Required]
            [MaxLength(10)]
            public string id_grupo2 { get; set; }

            [Display(Description = "Categoria")]
            [Column(Order = 150)]
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

            [Display(Description = "imagen")]
            [Column(Order = 0)]
            [MaxLength(300)]
            public string imagen { get; set; }



            /// /// inicio maximo 4 unidades de medida

            [Display(Description = "id_tipo_unidad1", Prompt ="1")]
            [Column(Order = 0)]
            public decimal id_tipo_unidad1 { get; set; }
            [Display(Description = "Unidad Medida 1")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_unidad1 { get; set; }
            [Display(Description = "F.UM.1", Prompt = "1")]
            [Column(Order = 0)]
            public decimal factor1 { get; set; }

            [Display(Description = "id_tipo_unidad2", Prompt = "2")]
            [Column(Order = 0)]
            public decimal id_tipo_unidad2 { get; set; }
            [Display(Description = "Unidad Medida 2")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_unidad2 { get; set; }
            [Display(Description = "F.UM.2", Prompt = "1")]
            [Column(Order = 0)]
            public decimal factor2 { get; set; }

            [Display(Description = "id_tipo_unidad3", Prompt = "3")]
            [Column(Order = 0)]
            public decimal id_tipo_unidad3 { get; set; }
            [Display(Description = "Unidad Medida 3")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_unidad3 { get; set; }
            [Display(Description = "F.UM.3", Prompt = "1")]
            [Column(Order = 0)]
            public decimal factor3 { get; set; }

            [Display(Description = "id_tipo_unidad4", Prompt = "4")]
            [Column(Order = 0)]
            public decimal id_tipo_unidad4 { get; set; }
            [Display(Description = "Unidad Medida 4")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_unidad4 { get; set; }
            [Display(Description = "F.UM.4", Prompt = "1")]
            [Column(Order = 0)]
            public decimal factor4 { get; set; }

          /// /// maximo 4 unidades de medida


            [Display(Description = "IGV",Prompt ="1")]
            [Column(Order = 40)]
            public bool igv { get; set; }

            [Display(Description = "ISC")]
            [Column(Order = 40)]
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


        //public class t_tipo_unidad_articulo
        //{
        //    public decimal id_tipo_unidad { get; set; }
        //    public string id_articulo { get; set; }
        //    public string id_unidad { get; set; }
        //    public decimal factor { get; set; }
        //    public string id_usuario_ultimo { get; set; }
        //}


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
          ///  public List<t_tipo_unidad_articulo> t_tipo_unidad_articulo { get; set; }

        }


    }
}
