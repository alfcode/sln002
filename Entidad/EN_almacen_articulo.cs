using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_almacen_articulo
    {
        public class t_almacen_articulo
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_almacen")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_almacen { get; set; }

            [Key]
            [Display(Description = "Articulo")]
            [Column(Order = 300)]
            [Required]
            [MaxLength(10)]
            public string id_articulo { get; set; }

                    [Display(Description = "Unidad Inventario")]
                    [Column(Order = 30)]
                    [Required]
                    [MaxLength(10)]
                    public string id_unidad_inventario { get; set; }

                    [Display(Description = "Unidad Ingreso")]
                    [Column(Order = 30)]
                    [Required]
                    [MaxLength(10)]
                    public string id_unidad_ingreso { get; set; }

                    [Display(Description = "Unidad Salida")]
                    [Column(Order = 30)]
                    [Required]
                    [MaxLength(10)]
                    public string id_unidad_salida { get; set; }

            [Display(Description = "tipo Inventario")]
            [Column(Order = 0)]
            [Required]
            public decimal id_tipo_unidad_inventario { get; set; }

            [Display(Description = "tipo Ingreso")]
            [Column(Order = 0)]
            [Required]
            public decimal id_tipo_unidad_ingreso { get; set; }

            [Display(Description = "tipo Salida")]
            [Column(Order = 0)]
            [Required]
            public decimal id_tipo_unidad_salida { get; set; }

            [Display(Description = "Stock Mínimo",Prompt ="0")]
            [Column(Order = 30)]
            public decimal stock_minimo { get; set; }

            [Display(Description = "Stock Máximo",Prompt ="0")]
            [Column(Order = 30)]
            [Required]
            public decimal stock_maximo { get; set; }

            [Display(Description = "Stock Repedido",Prompt ="0")]
            [Column(Order = 30)]
            [Required]
            public decimal stock_repedido { get; set; }

            [Display(Description = "Stock Alerta",Prompt ="0")]
            [Column(Order = 30)]
            [Required]
            public decimal stock_alerta { get; set; }

            [Display(Description = "Costofinal",Prompt ="0")]
            [Column(Order = 0)]
            public decimal costo_final { get; set; }

            [Display(Description = "Stock final",Prompt ="0")]
            [Column(Order = 0)]
            public decimal stock_final { get; set; }

            [Display(Description = "costo_promedio",Prompt ="0")]
            [Column(Order = 0)]
            public decimal costo_promedio { get; set; }

            [Display(Description = "Es venta?",Prompt ="0")]
            [Column(Order = 30)]
            public bool venta { get; set; }

            [Display(Description = "Toma Inventario",Prompt ="1")]
            [Column(Order = 30)]
            public bool inventario { get; set; }

            [Display(Description = "Activo", Prompt = "1")]
            [Column(Order = 30)]
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



       
        public class proc_almacen_articulo_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<lista_almacen> lista_almacen { get; set; }
            public List<EN_zero.datacombo> articulo { get; set; }
            public List<EN_zero.datacombo> unidad { get; set; }
            public List<lista_tipo_unidad_almacen> lista_tipo_unidad_almacen { get; set; }
        }

        public class proc_almacen_articulo_mnt
        {
            public string id_usuario { get; set; }
            public string id_almacen { get; set; }
            public List<t_almacen_articulo> t_almacen_articulo { get; set; }
        }

        public class proc_almacen_articulo_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_almacen_articulo> t_almacen_articulo { get; set; }
        }

        public class lista_tipo_unidad_almacen
        {
            public string id { get; set; }
            public string nombre1 { get; set; }
            public string nombre2 { get; set; }
            public decimal id_tipo_unidad { get; set; }
            public string id_articulo { get; set; }
            
        }

        public class lista_almacen
        {
            public string id { get; set; }
            public string nombre1 { get; set; }
            public string nombre2 { get; set; }
            public decimal id_tipo_unidad { get; set; }
            public bool venta { get; set; }

        }
        

    }
}
