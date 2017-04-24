using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_orden_compra
    {
        public class t_orden_compra
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_orden_compra")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_orden_compra { get; set; }

            [Display(Description = "id_empresa")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_empresa { get; set; }

            [Display(Description = "numero")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(20)]
            public string numero { get; set; }

            [Display(Description = "id_centro_costo")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_centro_costo { get; set; }

            [Display(Description = "id_almacen")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_almacen { get; set; }

            [Display(Description = "id_proveedor")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_proveedor { get; set; }

            [Display(Description = "fecha_emision")]
            [Column(Order = 0)]
            [Required]
            public DateTime fecha_emision { get; set; }

            [Display(Description = "fecha_entrega")]
            [Column(Order = 0)]
            [Required]
            public DateTime fecha_entrega { get; set; }

            [Display(Description = "fecha_pago")]
            [Column(Order = 0)]
            [Required]
            public DateTime fecha_pago { get; set; }

            [Display(Description = "id_moneda")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_moneda { get; set; }

            [Display(Description = "tipo_cambio")]
            [Column(Order = 0)]
            [Required]
            public decimal tipo_cambio { get; set; }

            [Display(Description = "",Prompt ="")]
            [Column(Order = 0)]
            [MaxLength(2000)]
            public string comentario { get; set; }

            [Display(Description = "id_estado_cab")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_estado_cab { get; set; }

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

            [Display(Description = "")]
            [Column(Order = 0)]
            [MaxLength(100)]
            public string estado_cab { get; set; }

            

        }
        public class t_orden_compra_det
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_orden_compra { get; set; }

           
            [Display(Description = "",Prompt ="0")]
            [Column(Order = 0)]
            [Required]
            public decimal item { get; set; }


            [Key]
            [Display(Description = "Articulo")]
            [Column(Order = 385)]
            [Required]
            [MaxLength(10)]
            public string id_articulo { get; set; }

            [Display(Description = "Precio")]
            [Column(Order = 52)]
            [Required]
            public decimal costo { get; set; }

            [Display(Description = "Unidad")]
            [Column(Order = 105)]
            [MaxLength(50)]
            public string  unidad{ get; set; } /// campo de ayuda

            [Display(Description = "Cantidad")]
            [Column(Order = 52)]
            [Required]
            public decimal canti_pedida { get; set; }

            [Display(Description = "",Prompt ="0")]
            [Column(Order = 0)]
            [Required]
            public decimal canti_guia { get; set; }

            [Display(Description = "",Prompt ="0")]
            [Column(Order = 0)]
            [Required]
            public decimal canti_real { get; set; }

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            public decimal igv { get; set; }

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            public decimal isc { get; set; }

            [Display(Description = "",Prompt ="0")]
            [Column(Order = 0)]
            [Required]
            public bool pendiente { get; set; }

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(20)]
            public string guia_ingreso { get; set; }

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

            /// /// campos de ayuda
            [Display(Description = "")]
            [Column(Order = 0)]
            public bool activa_limite { get; set; } /// campo de ayuda

            [Display(Description = "")]
            [Column(Order = 0)]
            public decimal cantidad_limite { get; set; } /// campo de ayuda


        }



        public class proc_orden_compra_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> empresa { get; set; }
            public List<EN_zero.datacombo> almacen { get; set; }
            public List<EN_zero.datacombo> centro_costo { get; set; }
            public List<EN_zero.datacombo> proveedor { get; set; }
            public List<EN_zero.datacombo> moneda { get; set; }
            public List<lista_articulo> articulo { get; set; }


        }


        public class proc_orden_compra_mnt
        {
            public string id_usuario { get; set; }
            public string id_orden_compra { get; set; }
            public List<t_orden_compra> t_orden_compra { get; set; }
            public List<t_orden_compra_det> t_orden_compra_det { get; set; }
        }

        public class proc_orden_compra_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_orden_compra> t_orden_compra { get; set; }
            public List<t_orden_compra_det> t_orden_compra_det { get; set; }

        }

        public class lista_articulo
        {
            public string id { get; set; }
            public string nombre1 { get; set; }
            public string nombre2 { get; set; }
            public string unidad { get; set; }
            public string id_proveedor { get; set; }
            public string id_moneda { get; set; }
            public bool activa_limite { get; set; }
            public decimal cantidad_limite { get; set; }
            public decimal igv { get; set; }
            public decimal isc { get; set; }
            public decimal costo { get; set; }
        }


        public class t_orden_compra_busca_cab
        {
            [Display(Description = "O.Compra")]
            [Column(Order = 75)]
            public string orden { get; set; }

            [Display(Description = "")]
            [Column(Order = 0)]
            public string numero { get; set; }

            [Display(Description = "Empresa")]
            [Column(Order = 180)]
            public string empresa { get; set; }

            [Display(Description = "Centro de Costo")]
            [Column(Order = 150)]
            public string centro_costo { get; set; }

            [Display(Description = "Almacen")]
            [Column(Order = 120)]
            public string almacen { get; set; }

            [Display(Description = "Proveedor")]
            [Column(Order = 200)]
            public string proveedor { get; set; }

            [Display(Description = "Fec.Emision")]
            [Column(Order = 70)]
            public DateTime fecha_emision { get; set; }

            [Display(Description = "Fec.Entrega")]
            [Column(Order = 70)]
            public DateTime fecha_entrega { get; set; }

            [Display(Description = "Fec. Pago")]
            [Column(Order = 70)]
            public DateTime fecha_pago { get; set; }

            [Display(Description = "Moneda")]
            [Column(Order = 000)]
            public string moneda { get; set; }

            [Display(Description = "T.C")]
            [Column(Order = 50)]
            public decimal tcambio { get; set; }

            [Display(Description = "Comentario")]
            [Column(Order = 0)]
            public string comentario { get; set; }

            [Display(Description = "Estado")]
            [Column(Order = 80)]
            public string estado { get; set; }

        }

        public class t_orden_compra_busca_det
        {
            [Display(Description = "")]
            [Column(Order = 0)]
            public string orden { get; set; }

            [Display(Description = "Item")]
            [Column(Order = 30)]
            public decimal item { get; set; }

            [Display(Description = "Articulo")]
            [Column(Order = 530)]
            public string articulo { get; set; }

            [Display(Description = "Unidad")]
            [Column(Order = 137)]
            public string unidad { get; set; }


            [Display(Description = "Costo")]
            [Column(Order = 80)]
            public decimal costo { get; set; }

            [Display(Description = "Cantidad")]
            [Column(Order = 80)]
            public decimal cantidad { get; set; }

        }

        public class proc_orden_compra_mnt_busca
        {
            public string numero { get; set; }
            public string fecha_ini { get; set; }
            public string fecha_fin { get; set; }

        }

        public class proc_orden_compra_mnt_busca_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_orden_compra_busca_cab> t_orden_compra_busca_cab { get; set; }
            public List<t_orden_compra_busca_det> t_orden_compra_busca_det { get; set; }

        }


    }
}
