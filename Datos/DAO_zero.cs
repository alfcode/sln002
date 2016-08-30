﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Entidad;
namespace Datos
{
   public class DAO_zero
    {

        public List<EN_zero.informe> msg_exception (Exception ex)
        {
            var informe = new List<EN_zero.informe>();
            var item = new EN_zero.informe();

            item.Id = "1";
            item.Error = 0;
            item.Procedure = "";
            item.Linea = 0;
            item.Mensaje= "[Capa:Datos] " + " [Clase: " + ex.TargetSite.Name + "] - " + ex.Message;

            informe.Add(item);
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


        // desde una objeto class lista
        public static DataTable ListToData<T>(IList<T> list)
        {
            DataTable dt = new DataTable();
            PropertyInfo[] propiedades = typeof(T).GetProperties();
            foreach (PropertyInfo p in propiedades)
            {
                dt.Columns.Add(p.Name, p.PropertyType);
            }
            foreach (T item in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo p in propiedades)
                {
                    row[p.Name] = p.GetValue(item, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        // desde un objeto class simple
        public static DataTable ObjectToData(object o)
        {
            DataTable dt = new DataTable("OutputData");

            DataRow dr = dt.NewRow();
            dt.Rows.Add(dr);

            o.GetType().GetProperties().ToList().ForEach(f =>
            {
                try
                {
                    f.GetValue(o, null);
                    dt.Columns.Add(f.Name, f.PropertyType);
                    dt.Rows[0][f.Name] = f.GetValue(o, null);
                }
                catch { }
            });
            return dt;
        }

        ///mod para fechas por comprobar
        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (props[i].PropertyType == typeof(DateTime))
                    {
                        DateTime currDT = (DateTime)props[i].GetValue(item);
                        values[i] = currDT.ToUniversalTime();
                    }
                    else
                    {
                        values[i] = props[i].GetValue(item);
                    }
                }
                table.Rows.Add(values);
            }
            return table;
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
