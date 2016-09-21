using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_usuario
    {
        public class t_usuario
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_usuario { get; set; }

            [Display(Description = "Nombres")]
            [Column(Order = 150)]
            [Required]
            [MaxLength(200)]
            public string nombre { get; set; }

            [Display(Description = "Ape. Paterno")]
            [Column(Order = 110)]
            [Required]
            [MaxLength(20)]
            public string apepat { get; set; }

            [Display(Description = "Ape. Materno")]
            [Column(Order = 110)]
            [Required]
            [MaxLength(20)]
            public string apemat { get; set; }

            [Display(Description = "Sexo")]
            [Column(Order = 40)]
            [Required]
            [MaxLength(1)]
            public string sexo { get; set; }

            [Display(Description = "Fecha Nac.")]
            [Column(Order = 70)]
            public DateTime fechanac { get; set; }

            [Display(Description = "Tipo Documento")]
            [Column(Order = 90)]
            [MaxLength(10)]
            public string id_tipodocu_personal { get; set; }

            [Display(Description = "numero")]
            [Column(Order = 60)]
            [MaxLength(20)]
            public string num_tdocu { get; set; }

            [Display(Description = "Departamento")]
            [Column(Order = 80)]
            [MaxLength(10)]
            public string id_departamento { get; set; }

            [Display(Description = "Provincia")]
            [Column(Order = 80)]
            [MaxLength(10)]
            public string id_provincia { get; set; }

            [Display(Description = "Distrito")]
            [Column(Order = 145)]
            [MaxLength(10)]
            public string id_distrito { get; set; }

            [Display(Description = "Dirección")]
            [Column(Order = 280)]
            [MaxLength(500)]
            public string direccion { get; set; }

            [Display(Description = "Teléfono 1")]
            [Column(Order = 75)]
            [MaxLength(50)]
            public string telefono1 { get; set; }

            [Display(Description = "Teléfono 2")]
            [Column(Order = 75)]
            [MaxLength(50)]
            public string telefono2 { get; set; }

            [Display(Description = "Email")]
            [Column(Order = 150)]
            [MaxLength(50)]
            public string email { get; set; }

            [Display(Description = "Area")]
            [Column(Order = 150)]
            [MaxLength(10)]
            public string id_area { get; set; }

            [Display(Description = "Cargo")]
            [Column(Order = 150)]
            [MaxLength(10)]
            public string id_cargo { get; set; }

            [Display(Description = "Fecha de Ingreso")]
            [Column(Order = 90)]
            public DateTime fecha_ingreso { get; set; }

            [Display(Description = "")]
            [Column(Order = 0)]
            [MaxLength(200)]
            public string foto { get; set; }

            [Display(Description = "Acceso Sistema", Prompt = "0")]
            [Column(Order = 82)]
            [Required]
            public bool acceso_sistema { get; set; }


            [Display(Description = "Activo", Prompt = "1")]
            [Column(Order = 50)]
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

        public class proc_usuario_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> tipodocu_personal { get; set; }
            public List<EN_zero.datacombo> area { get; set; }
            public List<EN_zero.datacombo> cargo { get; set; }
            public List<EN_zero.datacombo> departamento { get; set; }
        }


        public class proc_usuario_mnt
        {
            public string id_usuario { get; set; }
            public List<t_usuario> t_usuario { get; set; }
        }

        public class proc_usuario_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_usuario> t_usuario { get; set; }
        }


    }
}
