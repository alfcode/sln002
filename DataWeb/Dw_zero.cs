using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entidad;
namespace DataWeb
{
    public class Dw_zero
    {

        public DataSet MsgErrorCapaDatos(String clase, String StatusCode, String ReasonPhrase)
        {

            var dst = new DataSet();
            var dt = new DataTable("informe");

            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            dt.Columns.Add(new DataColumn("Procedure", typeof(string)));
            dt.Columns.Add(new DataColumn("Linea", typeof(int)));
            dt.Columns.Add(new DataColumn("Mensaje", typeof(string)));

            DataRow dr = dt.NewRow();
            dr["Id"] = "1";
            dr["Error"] = 0;
            dr["Procedure"] = "";
            dr["Linea"] = 0;
            dr["Mensaje"] = "[Capa:DataWeb] " + " [Clase: " + clase + "] - " + StatusCode + " - "+ ReasonPhrase;

            dt.Rows.Add(dr);
            dst.Tables.Add(dt);
            return dst;


        }

        public List<EN_zero.informe> MsgInformeCapaDatos(String clase, String StatusCode, String ReasonPhrase)
        {
            var informe = new List<EN_zero.informe>();
            var data = new EN_zero.informe();

            data.Error = 0;
            data.Id = "1";
            data.Linea = 0;
            data.Mensaje = "[Capa:DataWeb] " + " [Clase: " + clase + "] - " + StatusCode + " - " + ReasonPhrase; ;
            data.Procedure = "";

            informe.Add(data);

            return informe;
        }



        public DataSet MsgErrorCapaDatos(Exception ex)
        {

            var dst = new DataSet();
            var dt = new DataTable("informe");

            dt.Columns.Add(new DataColumn("Id", typeof(int)));
            dt.Columns.Add(new DataColumn("Error", typeof(int)));
            dt.Columns.Add(new DataColumn("Procedure", typeof(string)));
            dt.Columns.Add(new DataColumn("Linea", typeof(int)));
            dt.Columns.Add(new DataColumn("Mensaje", typeof(string)));

            DataRow dr = dt.NewRow();
            dr["Id"] = "1";
            dr["Error"] = 0;
            dr["Procedure"] = "";
            dr["Linea"] = 0;
            dr["Mensaje"] = "[Capa:Datos] " + " [Clase: " + ex.TargetSite.Name + "] - " + ex.Message;

            dt.Rows.Add(dr);
            dst.Tables.Add(dt);
            return dst;


        }


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

    }
}
