using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_proveedor
    {
        public class t_proveedor
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_proveedor { get; set; }

            [Display(Description = "Razón Social")]
            [Column(Order = 230)]
            [Required]
            [MaxLength(100)]
            public string nombre { get; set; }

            [Key]
            [Display(Description = "Ruc")]
            [Column(Order = 80)]
            [Required]
            [MaxLength(11)]
            public string ruc { get; set; }

            [Display(Description = "Contacto")]
            [Column(Order = 165)]
            [MaxLength(100)]
            public string contacto { get; set; }

            [Display(Description = "Linea de crédito")]
            [Column(Order = 85)]
            public decimal linea_credito { get; set; }

            [Display(Description = "Forma de pago")]
            [Column(Order = 85)]
            [MaxLength(10)]
            public string id_formapago { get; set; }

         

            [Display(Description = "País")]
            [Column(Order = 96)]
            [MaxLength(10)]
            public string id_pais { get; set; }

            [Display(Description = "Departamento")]
            [Column(Order = 102)]
            [MaxLength(10)]
            public string id_departamento { get; set; }

            [Display(Description = "Provincia")]
            [Column(Order = 97)]
            [MaxLength(10)]
            public string id_provincia { get; set; }

            [Display(Description = "Distrito")]
            [Column(Order = 127)]
            [MaxLength(10)]
            public string id_distrito { get; set; }



            [Display(Description = "Dirección")]
            [Column(Order = 193)]
            [MaxLength(200)]
            public string direccion { get; set; }

            [Display(Description = "Teléfono 1")]
            [Column(Order = 75)]
            [MaxLength(12)]
            public string telefono1 { get; set; }

            [Display(Description = "Teléfono 2")]
            [Column(Order = 75)]
            [MaxLength(12)]
            public string telefono2 { get; set; }

            [Display(Description = "Email")]
            [Column(Order = 136)]
            [MaxLength(100)]
            public string email { get; set; }

            [Display(Description = "Web")]
            [Column(Order = 156)]
            [MaxLength(200)]
            public string web { get; set; }

            [Display(Description = "Comentario")]
            [Column(Order = 164)]
            [MaxLength(8000)]
            public string comentario { get; set; }
            

            [Display(Description = "Giro de Negocio")]
            [Column(Order = 120)]
            [MaxLength(10)]
            public string id_gironegocio { get; set; }


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


        public class proc_proveedor_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> gironegocio { get; set; }
            public List<EN_zero.datacombo> formapago { get; set; }
            public List<EN_zero.datacombo> pais { get; set; }
            public List<EN_zero.datacombo> departamento { get; set; }
            public List<EN_zero.datacombo> provincia { get; set; }
            public List<EN_zero.datacombo> distrito { get; set; }

            
        }
        

        public class proc_proveedor_mnt
        {
            public string id_usuario { get; set; }
            public List<t_proveedor> t_proveedor { get; set; }
        }

        public class proc_proveedor_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_proveedor> t_proveedor { get; set; }
        }


    }
}
