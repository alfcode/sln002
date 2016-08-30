using Conexion;
using Entidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _ExtensionMethods;
namespace Datos
{
    public class DAO_guia
    {
        public EN_guia.retorno_guia_mnt proc_guia_mnt (EN_guia.proc_guia_mnt parametros)
        {
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();

            var dt_cab = new DataTable();
            var dt_det = new DataTable();
          
            dt_cab = DAO_zero.ObjectToData(parametros.t_guia_cab);
            dt_det = DAO_zero.ListToData(parametros.t_guia_det);

            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "proc_guia_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_tarea", parametros.t_guia_tarea.tarea);
                cmd.Parameters.AddWithValue("@p_guia_cab", SqlDbType.Structured).Value = dt_cab;
                cmd.Parameters.AddWithValue("@p_guia_det", SqlDbType.Structured).Value = dt_det;

                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Columns[0].ColumnName == "informe") {  ds.Tables[i].TableName = "informe";}
                    if (ds.Tables[i].Columns[0].ColumnName == "t_guia_id_guia") { ds.Tables[i].TableName = "t_guia_id_guia"; }
                }
               
                List<EN_zero.informe> informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                List<EN_guia.t_guia_id_guia> t_guia_id_guia = ds.Tables["t_guia_id_guia"].DataTableToList<EN_guia.t_guia_id_guia>().ToList();

                var retorno = new EN_guia.retorno_guia_mnt();
                retorno.informe = informe;
                retorno.t_guia_id_guia = t_guia_id_guia;

                return retorno;

            }

            catch (Exception ex)
            {
                var ayuda = new DAO_zero();
                var retorno = new EN_guia.retorno_guia_mnt();
                retorno.informe = ayuda.MsgInformeCapaDatos(ayuda.MsgErrorCapaDatos(ex)); ;
                return retorno;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }


        public EN_guia.datos_consulta_guia proc_consulta_guia(EN_guia.proc_consulta_guia parametros)
        {
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();

            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "proc_consulta_guia";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_guia", parametros.id_guia);
                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Columns[0].ColumnName == "t_guia_cab") { ds.Tables[i].TableName = "t_guia_cab"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "t_guia_det") { ds.Tables[i].TableName = "t_guia_det"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "informe") { ds.Tables[i].TableName = "informe";}
                }
              
                var datos = new EN_guia.datos_consulta_guia();

                List<EN_guia.t_guia_cab> t_guia_cab = ds.Tables["t_guia_cab"].DataTableToList<EN_guia.t_guia_cab>().ToList();
                List<EN_guia.t_guia_det> t_guia_det = ds.Tables["t_guia_det"].DataTableToList<EN_guia.t_guia_det>().ToList();
                List<EN_zero.informe> informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();

                datos.informe = informe;
                datos.t_guia_cab = t_guia_cab;
                datos.t_guia_det = t_guia_det;

                return datos;

            }
            catch (Exception ex)
            {
                //help

                var ayuda = new DAO_zero();
                var datos = new EN_guia.datos_consulta_guia();
                datos.informe= ayuda.MsgInformeCapaDatos(ayuda.MsgErrorCapaDatos(ex));

                return datos;
                //fin help
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }
        }

    }
}
