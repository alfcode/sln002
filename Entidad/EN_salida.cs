using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_salida
    {
        public class t_salida
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_salida")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_salida { get; set; }

            [Display(Description = "id_empresa")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_empresa { get; set; }

            [Display(Description = "id_centro_costo")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_centro_costo { get; set; }

            [Display(Description = "id_tsalida")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_tsalida { get; set; }

            [Display(Description = "id_almacen")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_almacen { get; set; }

            [Display(Description = "id_tdocu_sunat")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_tdocu_sunat { get; set; }

            [Display(Description = "nro_tdocu")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(15)]
            public string nro_tdocu { get; set; }

            [Display(Description = "id_proveedor")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_proveedor { get; set; }

            [Display(Description = "id_orden_compra")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_orden_compra { get; set; }

            [Display(Description = "fecha_movimiento")]
            [Column(Order = 0)]
            [Required]
            public DateTime fecha_movimiento { get; set; }

            [Display(Description = "id_moneda")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_moneda { get; set; }

            [Display(Description = "tipo_cambio")]
            [Column(Order = 0)]
            [Required]
            public decimal tipo_cambio { get; set; }

            [Display(Description = "comentario")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(1000)]
            public string comentario { get; set; }

            [Display(Description = "id_estado_cab")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_estado_cab { get; set; }

            [Display(Description = "tranferencia")]
            [Column(Order = 0)]
            [Required]
            public bool tranferencia { get; set; }

            [Display(Description = "id_ingreso")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_ingreso { get; set; }

            [Display(Description = "id_almacen2")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_almacen2 { get; set; }

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


        public class t_salida_det
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_salida { get; set; }


            [Display(Description = "item", Prompt = "0")]
            [Column(Order = 0)]

            public decimal item { get; set; }

            [Display(Description = "Articulo")]
            [Column(Order = 250)]
            [Required]
            [MaxLength(10)]
            public string id_articulo { get; set; }

            [Display(Description = "id_tipo_unidad_inventario")]
            [Column(Order = 0)]
            [Required]
            public decimal id_tipo_unidad_inventario { get; set; }


            [Display(Description = "id_tipo_unidad_registro")]
            [Column(Order = 0)]
            [Required]
            public decimal id_tipo_unidad_registro { get; set; }

            [Display(Description = "factor")]
            [Column(Order = 0)]
            [Required]
            public decimal factor { get; set; }


            [Display(Description = "Unidad")]
            [Column(Order = 80)]
            [Required]
            [MaxLength(10)]
            public string id_unidad { get; set; }

            [Display(Description = "Cantidad  Documento", Prompt = "0")]
            [Column(Order = 70)]
            [Required]
            public decimal cantidad_nota { get; set; }

            [Display(Description = "Cantidad Real", Prompt = "0")]
            [Column(Order = 70)]
            [Required]
            public decimal cantidad_real { get; set; }

            [Display(Description = "Precio", Prompt = "0")]
            [Column(Order = 60)]
            [Required]
            public decimal costo { get; set; }

            [Display(Description = "Importe", Prompt = "0")]
            [Column(Order = 60)]
            [Required]
            public decimal importe { get; set; }



            [Display(Description = "igv")]
            [Column(Order = 0)]
            public decimal igv { get; set; }

            [Display(Description = "isc")]
            [Column(Order = 0)]
            public decimal isc { get; set; }

            [Display(Description = "comentario")]
            [Column(Order = 0)]
            [MaxLength(1000)]
            public string comentario { get; set; }

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

        public class proc_salida_mnt
        {
            public string id_usuario { get; set; }
            public string id_salida { get; set; }
            public string id_ingreso { get; set; }
            public bool transferencia { get; set; }
            public List<t_salida> t_salida { get; set; }
            public List<t_salida_det> t_salida_det { get; set; }
        }

        public class proc_salida_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_salida> t_salida { get; set; }
            public List<t_salida_det> t_salida_det { get; set; }

        }



        public class t_salida_busca_cab
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

        public class t_salida_busca_det
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

        public class proc_salida_mnt_busca
        {
            public string numero { get; set; }
            public string fecha_ini { get; set; }
            public string fecha_fin { get; set; }

        }

        public class proc_salida_mnt_busca_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_salida_busca_cab> t_salida_busca_cab { get; set; }
            public List<t_salida_busca_det> t_salida_busca_det { get; set; }
        }




        public class proc_salida_mnt_tipo_unidad_almacen_parametros
        {
            public string id_almacen { get; set; }
        }

        public class proc_salida_mnt_tipo_unidad_almacen
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<lista_tipo_unidad_almacen> lista_tipo_unidad_almacen { get; set; }
            public List<lista_articulo> lista_articulo { get; set; }
        }

        public class proc_salida_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo_simple> empresa { get; set; }
            public List<lista_almacen> almacen { get; set; }
            public List<EN_zero.datacombo_simple> centro_costo { get; set; }
            public List<EN_zero.datacombo_simple> proveedor { get; set; }
            public List<lista_tipo_salida> tsalida { get; set; }
            public List<EN_zero.datacombo_simple> tdocu_sunat { get; set; }
            public List<EN_zero.datacombo_simple> moneda { get; set; }
            public List<EN_zero.datacombo_simple> unidad { get; set; }
            public List<lista_articulo> lista_articulo { get; set; }

        }


        public class lista_articulo
        {
            public string id { get; set; }
            public string nombre1 { get; set; }
            public decimal igv { get; set; }
            public decimal isc { get; set; }
        }

        public class lista_almacen
        {

            public string id { get; set; }
            public string nombre1 { get; set; }
            public decimal id_tipo_unidad_salida1 { get; set; }
            public decimal id_tipo_unidad_salida2 { get; set; }
            public decimal id_tipo_unidad_ingreso1 { get; set; }
            public decimal id_tipo_unidad_ingreso2 { get; set; }

        }

        public class lista_tipo_unidad_almacen
        {
            public string id { get; set; }
            public string nombre1 { get; set; }
            public string nombre2 { get; set; }
            public decimal id_tipo_unidad_registro { get; set; }
            public string id_articulo { get; set; }
            public decimal id_tipo_unidad_inventario { get; set; }
            public decimal factor { get; set; }

        }

        public class lista_tipo_salida
        {
            public string id { get; set; }
            public string nombre1 { get; set; }
            public bool flatinterno { get; set; }
            public bool activo { get; set; }
            public bool flatvalorizar { get; set; }
            public bool flateditmto { get; set; }
            public bool flatupdckdxsunat { get; set; }
            public bool flatmodajuste { get; set; }
            public bool flatmodtransfx { get; set; }
            public bool flatmodprod { get; set; }
            public bool flatmodmerma { get; set; }
            public bool flatmodtransf { get; set; }
            public bool flatmodproyec { get; set; }
            public bool flatmodproyecadic { get; set; }
            public bool flatmodproyecdev { get; set; }
            public bool flatgeningreso { get; set; }
            public string id_tingreso { get; set; }
            public int prioridad { get; set; }
            public string id_tingresosunat { get; set; }
        }



    }
}
