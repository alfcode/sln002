using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entidad
{
    public class EN_rol_usuario
    {
        public class t_rol_usuario
        {
            /// [Key]   para columnas cuyo valor es unico en la grilla
            /// [Display(Prompt = "GRU0000001")]   valor por defecto

            [Display(Description = "Rol")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_rol { get; set; }

            [Display(Description = "Usuario")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(10)]
            public string id_usuario { get; set; }

            [Display(Description = "Login")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(20)]
            public string login { get; set; }

            [Display(Description = "Password")]
            [Column(Order = 0)]
            [Required]
            [MaxLength(20)]
            public string password { get; set; }

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

        public class proc_rol_usuario_mnt
        {
            public string id_usuario { get; set; }
            public List<t_rol_usuario> t_rol_usuario { get; set; }
        }

        public class proc_rol_usuario_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_rol_usuario> t_rol_usuario { get; set; }
        }

    }
}