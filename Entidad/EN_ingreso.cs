using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_ingreso
    {
        public class t_ingreso
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "id_ingreso")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_ingreso { get; set; }

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

            [Display(Description = "id_tingreso")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_tingreso { get; set; }

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

            [Display(Description = "id_salida")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_salida { get; set; }

            [Display(Description = "id_almacen2")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_almacen2 { get; set; }

            [Display(Description = "id_ingreso2")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_ingreso2 { get; set; }

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

            [Display(Description = "")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string fila_modo { get; set; }

            [Display(Description = "")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string fila_maestro { get; set; }



        }


        public class t_ingreso_det
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_ingreso { get; set; }

 
            [Display(Description = "item",Prompt ="0")]
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


            [Display(Description = "id_tipo_unidad_movi")]
            [Column(Order = 0)]
            [Required]
            public decimal id_tipo_unidad_movi { get; set; }

            [Display(Description = "factor_movi")]
            [Column(Order = 0)]
            [Required]
            public decimal factor_movi { get; set; }


            [Display(Description = "Unidad")]
            [Column(Order = 80)]
            [Required]
            [MaxLength(10)]
            public string id_unidad { get; set; }

            [Display(Description = "Cantidad  Documento",Prompt ="0")]
            [Column(Order = 70)]
            [Required]
            public decimal cantidad_nota { get; set; }

            [Display(Description = "Cantidad Real",Prompt ="0")]
            [Column(Order = 70)]
            [Required]
            public decimal cantidad_real { get; set; }

            [Display(Description = "Precio",Prompt ="0")]
            [Column(Order = 60)]
            [Required]
            public decimal costo { get; set; }

            [Display(Description = "Importe",Prompt ="0")]
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

            [Display(Description = "")]
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

            [Display(Description = "", Prompt = "nuevo")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string fila_modo { get; set; }

            [Display(Description = "")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string fila_maestro { get; set; }


        }

        public class proc_ingreso_mnt
        {
            public string modo { get; set; }
            public string id_usuario { get; set; }
            public string id_ingreso { get; set; }
            public string id_salida { get; set; }
            public bool transferencia { get; set; }
            public List<t_ingreso> t_ingreso { get; set; }
            public List<t_ingreso_det> t_ingreso_det { get; set; }
        }

        public class proc_ingreso_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_ingreso> t_ingreso { get; set; }
            public List<t_ingreso_det> t_ingreso_det { get; set; }

        }



        public class t_ingreso_busca_cab
        {

            [Display(Description = "Ingreso")]
            [Column(Order = 65)]
            [Required]
            [MaxLength(10)]
            public string ingreso { get; set; }

            [Display(Description = "Tipo de Ingreso")]
            [Column(Order = 175)]
            [MaxLength(50)]
            public string tipo_ingreso { get; set; }

            [Display(Description = "Almacen Ingreso")]
            [Column(Order = 120)]
            [Required]
            [MaxLength(100)]
            public string almacen_ingreso { get; set; }

            [Display(Description = "Almacen Transferencia")]
            [Column(Order = 120)]
            [Required]
            [MaxLength(100)]
            public string almacen_transferencia { get; set; }

            [Display(Description = "Salida")]
            [Column(Order = 75)]
            [MaxLength(10)]
            public string salida { get; set; }

            [Display(Description = "Transferencia")]
            [Column(Order = 75)]
            [MaxLength(10)]
            public string transferencia { get; set; }

            [Display(Description = "Empresa")]
            [Column(Order = 160)]
            [Required]
            [MaxLength(200)]
            public string empresa { get; set; }

            [Display(Description = "Centro Costo")]
            [Column(Order = 140)]
            [Required]
            [MaxLength(100)]
            public string centro_costo { get; set; }

            [Display(Description = "Proveedor")]
            [Column(Order = 170)]
            [Required]
            [MaxLength(100)]
            public string proveedor { get; set; }

            [Display(Description = "Moneda")]
            [Column(Order = 85)]
            [Required]
            [MaxLength(60)]
            public string moneda { get; set; }

            [Display(Description = "Documento")]
            [Column(Order = 85)]
            [Required]
            [MaxLength(50)]
            public string documento { get; set; }

            [Display(Description = "Nro Documento")]
            [Column(Order = 100)]
            [Required]
            [MaxLength(15)]
            public string nro_documento { get; set; }

            [Display(Description = "Fecha Documento")]
            [Column(Order = 100)]
            [Required]
            public DateTime fecha_documento { get; set; }

            [Display(Description = "Fecha Registro")]
            [Column(Order = 90)]
            [Required]
            public DateTime fecha_registro { get; set; }

            [Display(Description = "Tipo Cambio")]
            [Column(Order = 55)]
            [Required]
            public decimal tcambio { get; set; }

            [Display(Description = "Comentario")]
            [Column(Order = 450)]
            [Required]
            [MaxLength(1000)]
            public string comentario { get; set; }

            [Display(Description = "Estado")]
            [Column(Order = 95)]
            [Required]
            [MaxLength(50)]
            public string estado { get; set; }

        }

        public class t_ingreso_busca_det
        {

            [Display(Description = "Ingreso")]
            [Column(Order = 70)]
            [Required]
            [MaxLength(10)]
            public string ingreso { get; set; }

            [Display(Description = "Item")]
            [Column(Order = 30)]
            public long item { get; set; }

            [Display(Description = "Articulo")]
            [Column(Order = 380)]
            [Required]
            [MaxLength(200)]
            public string articulo { get; set; }

            [Display(Description = "Unidad")]
            [Column(Order = 92)]
            [Required]
            [MaxLength(50)]
            public string unidad { get; set; }

            [Display(Description = "Costo")]
            [Column(Order = 45)]
            [Required]
            public decimal costo { get; set; }

            [Display(Description = "Cantidad Nota")]
            [Column(Order = 80)]
            [Required]
            public decimal cantidad_nota { get; set; }

            [Display(Description = "Cantidad Real")]
            [Column(Order = 80)]
            [Required]
            public decimal cantidad_real { get; set; }

            [Display(Description = "Importe")]
            [Column(Order = 80)]
            public decimal importe { get; set; }

        }

        public class proc_ingreso_mnt_busca
        {
            public string id_almacen { get; set; }
            public string numero { get; set; }
            public string fecha_ini { get; set; }
            public string fecha_fin { get; set; }

        }

        public class proc_ingreso_mnt_busca_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_ingreso_busca_cab> t_ingreso_busca_cab { get; set; }
            public List<t_ingreso_busca_det> t_ingreso_busca_det { get; set; }
            public List<lista_almacen> almacen { get; set; }
        }




        public class proc_ingreso_mnt_tipo_unidad_almacen_parametros
        {
            public string id_almacen{ get; set; }
            public string id_almacen2 { get; set; }
        }

        public class proc_ingreso_mnt_tipo_unidad_almacen
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<lista_tipo_unidad_almacen> lista_tipo_unidad_almacen { get; set; }
            public List<lista_articulo> lista_articulo { get; set; }
        }

        public class proc_ingreso_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo_simple> empresa { get; set; }
            public List<lista_almacen> almacen { get; set; }
            public List<EN_zero.datacombo_simple> centro_costo { get; set; }
            public List<EN_zero.datacombo_simple> proveedor { get; set; }
            public List<lista_tipo_ingreso> tingreso { get; set; }
            public List<EN_zero.datacombo_simple> tdocu_sunat { get; set; }
            public List<EN_zero.datacombo_simple> moneda { get; set; }
            public List<EN_zero.datacombo_simple> unidad { get; set; }
            public List<lista_articulo> lista_articulo { get; set; }

        }


        public class proc_ingreso_mnt_filtra_proveedor
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo_simple> proveedor { get; set; }
        }

        public class proc_filtra_proveedor
        {
            public string proveedor { get; set; }
        }

        public class t_proveedor_filter
        {
             [Display(Description = "")]
            [Column(Order = 0)]
            [MaxLength(50)]
            
            public string id{ get; set; }
            [Display(Description = "")]
            [Column(Order = 0)]
            [MaxLength(100)]
          
            public string nombre1 { get; set; }
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
            public decimal id_tipo_unidad_ingreso1 { get; set; }
            public decimal id_tipo_unidad_ingreso2 { get; set; }
            public decimal id_tipo_unidad_salida1 { get; set; }
            public decimal id_tipo_unidad_salida2 { get; set; }

        }

        public class lista_tipo_unidad_almacen
        {
            public string id { get; set; }
            public string nombre1 { get; set; }
            public string nombre2 { get; set; }
            public decimal id_tipo_unidad_movi { get; set; }
            public string id_articulo { get; set; }
            public decimal id_tipo_unidad_inventario { get; set; }
            public decimal factor { get; set; }

        }

        public class lista_tipo_ingreso
        {
            public string id { get; set; }
            public string nombre1 { get; set; }
            public bool flatvalorizar { get; set; }
            public bool flateditmto { get; set; }
            public bool flatupdckdxsunat { get; set; }
            public bool flatiinicial { get; set; }
            public bool flatmodcompra { get; set; }
            public bool flatmodajuste { get; set; }
            public bool flatmodtransfx { get; set; }
            public bool flatmodprod { get; set; }
            public bool flatmodmerma { get; set; }
            public bool flatmodtransf { get; set; }
            public bool flatmodpedalmc { get; set; }
            public bool flatmodproyec { get; set; }
            public bool flatmodproyecadic { get; set; }
            public bool flatmodproyecdev { get; set; }
            public bool flatinterno { get; set; }
            public bool flatpventa { get; set; }
            public int prioridad { get; set; }
            public string id_tingresosunat { get; set; }
        }



    }
}
