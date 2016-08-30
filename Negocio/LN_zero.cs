using System;
using System.Collections.Generic;
using System.Linq;
using Entidad;
using System.Data;
using System.Reflection;
using Datos;

namespace Negocio
{
    public class LN_zero
    {

      


        public List<EN_zero.informe> MsgInformeCapaDatos(DataSet ds)
        {
            var informe = new List<EN_zero.informe>();
            informe = (from DataRow dr in ds.Tables["informe"].Rows
                       select new EN_zero.informe()
                       {
                           Id = dr["Id"].ToString(),
                           Error = Convert.ToInt32(dr["Error"]),
                           Procedure = dr["Procedure"].ToString(),
                           Linea = Convert.ToInt32(dr["Linea"]),
                           Mensaje = dr["Mensaje"].ToString()
                       }).ToList();

            return informe;
        }

        public List<EN_zero.informe> MsgInformeCapaDatos(DataSet ds, Exception ex)
        {
            string msg = " [Capa:Negocio] " + " [Clase:" + ex.TargetSite.Name + "] - " + " - " + ex.Message + "verifique que la cantida de tablas de retorno sea igual en datos y negocio";

            var informe = new List<EN_zero.informe>();
            informe = (from DataRow dr in ds.Tables["informe"].Rows
                       select new EN_zero.informe()
                       {
                           Id = "1",
                           Error = Convert.ToInt32(dr["Error"]),
                           Procedure = dr["Procedure"].ToString(),
                           Linea = Convert.ToInt32(dr["Linea"]),
                           Mensaje = dr["Mensaje"].ToString() + msg
                       }).ToList();


            return informe;
        }


        public bool PresentaError(DataSet ds)
        {

            bool valor = false;
            var rowColl = ds.Tables["informe"].AsEnumerable();
            string name = (from r in rowColl
                           select r.Field<string>("Id")).First<string>();

            if (name == "1")
            {
                valor = true;
            }

            return valor;
        }



    }
}
