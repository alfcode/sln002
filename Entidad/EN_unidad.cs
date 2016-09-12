using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class EN_unidad
    {

        public class t_unidad
    {
        public string id_unidad { get; set; }
        [Display(Description = "Unidad", Order = 200)]
        public string nombre { get; set; }
        [Display(Description = "Sunat_Unidad", Order = 200)]
        public string abreviatura { get; set; }

        public string id_usuario_inicia { get; set; }

        [Display(Description = "", Order = 0, Prompt = "nuevo")]
        public string id_usuario_ultimo { get; set; }
        [Display(Description = "", Order = 40, Prompt = "01/01/2016")]
        public DateTime fecha_inicia { get; set; }
        [Display(Description = "", Order = 40, Prompt = "01/01/2016")]
        public DateTime fecha_ultimo { get; set; }
        [Display(Description = "", Order = 25, Prompt = "EST0000001")]
        public string id_estado { get; set; }
        public string cc { get; set; }
    }

    public class proc_unidad_mnt
    {
        public string id_usuario { get; set; }
        public List<t_unidad> t_unidad { get; set; }
    }

        public class proc_unidad_mnt_retorno
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<t_unidad> t_unidad { get; set; }
        }
    }
}
