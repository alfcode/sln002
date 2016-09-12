using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entidad
{
    public class EN_articulo
    {

       

        public class t_articulo
        {

            public string id_articulo { get; set; }
            [Display(Description = "Articulo", Order = 100)]
            public string nombre { get; set; }
            [Display(Description = "Obsercación", Order = 100)]
            public string observacion { get; set; }
            [Display(Description = "Unidad 1", Order = 40)]
            public string id_unidad1 { get; set; }
            [Display(Description = "Unidad 2", Order = 40)]
            public string id_unidad2 { get; set; }
            [Display(Description = "Factor U.M.", Order = 30,Prompt ="1")]
            public decimal factor { get; set; }
            [Display(Description = "Linea", Order = 70)]
            public string id_grupo1 { get; set; }
            [Display(Description = "Familia", Order = 50)]
            public string id_grupo2 { get; set; }
            [Display(Description = "Categoria", Order = 50)]
            public string id_grupo3 { get; set; }

            [Display(Description = "", Order = 0, Prompt = "GRU0000001")]
            public string id_grupo4 { get; set; }
            [Display(Description = "", Order = 0, Prompt = "GRU0000001")]
            public string id_grupo5 { get; set; }
            public string imagen { get; set; }

            public string id_usuario_inicia { get; set; }
            [Display(Description = "", Order = 0, Prompt = "nuevo")]
            public string id_usuario_ultimo { get; set; }
            [Display(Description = "", Order = 40, Prompt = "01/01/2016")]
            public DateTime fecha_inicia { get; set; }
            [Display(Description = "", Order = 40, Prompt = "01/01/2016")]
            public DateTime fecha_ultimo { get; set; }
           
            [Display(Description = "Estado", Order = 50, Prompt = "EST0000001")]
            public string id_estado { get; set; }
            [Display(Description = "Activo", Order = 30, Prompt = "true")]
            public bool activo { get; set; }

        }


        public class proc_articulo_mnt_combo
        {
            public List<EN_zero.informe> informe { get; set; }
            public List<EN_zero.datacombo> unidad { get; set; }
            public List<EN_zero.datacombo> grupo1 { get; set; }
            public List<EN_zero.datacombo> grupo2 { get; set; }
            public List<EN_zero.datacombo> grupo3 { get; set; }
            public List<EN_zero.datacombo> estado { get; set; }
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
        }


    }
}
