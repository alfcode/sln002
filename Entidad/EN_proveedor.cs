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

            [Display(Description = "id_proveedor")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_proveedor { get; set; }

            [Display(Description = "nombre")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(100)]
            public string nombre { get; set; }

            [Display(Description = "ruc")]
            [Column(Order = 0)]
            [MaxLength(11)]
            public string ruc { get; set; }

            [Display(Description = "id_gironegocio")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_gironegocio { get; set; }

            [Display(Description = "id_formapago")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_formapago { get; set; }

            [Display(Description = "contacto")]
            [Column(Order = 0)]
            [MaxLength(100)]
            public string contacto { get; set; }

            [Display(Description = "direccion")]
            [Column(Order = 0)]
            [MaxLength(200)]
            public string direccion { get; set; }

            [Display(Description = "telefono1")]
            [Column(Order = 0)]
            [MaxLength(12)]
            public string telefono1 { get; set; }

            [Display(Description = "telefono2")]
            [Column(Order = 0)]
            [MaxLength(12)]
            public string telefono2 { get; set; }

            [Display(Description = "email")]
            [Column(Order = 0)]
            [MaxLength(100)]
            public string email { get; set; }

            [Display(Description = "web")]
            [Column(Order = 0)]
            [MaxLength(200)]
            public string web { get; set; }

            [Display(Description = "comentario")]
            [Column(Order = 0)]
            [MaxLength(8000)]
            public string comentario { get; set; }

            [Display(Description = "linea_credito")]
            [Column(Order = 0)]
            public decimal linea_credito { get; set; }

            [Display(Description = "dias_atencion")]
            [Column(Order = 0)]
            [MaxLength(100)]
            public string dias_atencion { get; set; }

            [Display(Description = "id_pais")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_pais { get; set; }

            [Display(Description = "id_departamento")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_departamento { get; set; }

            [Display(Description = "id_provincia")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_provincia { get; set; }

            [Display(Description = "id_distrito")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_distrito { get; set; }

            [Display(Description = "id_zona")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_zona { get; set; }

            [Display(Description = "id_postal")]
            [Column(Order = 0)]
            [MaxLength(10)]
            public string id_postal { get; set; }

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


        public class proc_proveedor_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> gironegocio { get; set; }
            public List<EN_zero.datacombo> formapago { get; set; }
            public List<EN_zero.datacombo> pais { get; set; }
            public List<EN_zero.datacombo> departamento { get; set; }
            public List<EN_zero.datacombo> zona{ get; set; }
            public List<EN_zero.datacombo> postal{ get; set; }

            
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
}
