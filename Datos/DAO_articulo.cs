using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_articulo
    {

        public EN_articulo.proc_articulo_mnt_combo proc_articulo_mnt_combo()
        {
            var retorno = new EN_articulo.proc_articulo_mnt_combo();
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();
            

            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_articulo_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
 
                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Columns[0].ColumnName == "informe") { ds.Tables[i].TableName = "informe"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "unidad") { ds.Tables[i].TableName = "unidad"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "grupo1") { ds.Tables[i].TableName = "grupo1"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "grupo2") { ds.Tables[i].TableName = "grupo2"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "grupo3") { ds.Tables[i].TableName = "grupo3"; }
                    
                }

                retorno.informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                string Error = (from item in retorno.informe select item.Error).First().ToString();
                if (Error.Equals("1")) return retorno;
                

                retorno.unidad = ds.Tables["unidad"].DataTableToList<EN_zero.datacombo>().ToList();
                retorno.grupo1 = ds.Tables["grupo1"].DataTableToList<EN_zero.datacombo>().ToList();
                retorno.grupo2 = ds.Tables["grupo2"].DataTableToList<EN_zero.datacombo>().ToList();
                retorno.grupo3 = ds.Tables["grupo3"].DataTableToList<EN_zero.datacombo>().ToList();

                return retorno;

            }

            catch (Exception ex)
            {
                var error = new DAO_zero();
                retorno.informe= error.msg_exception(ex);
                return retorno;
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

        }





        public EN_articulo.proc_articulo_mnt_retorno proc_articulo_mnt(EN_articulo.proc_articulo_mnt parametros )
        {
            var retorno = new EN_articulo.proc_articulo_mnt_retorno();
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();


            DataTable dt = DAO_zero.ListToData(parametros.t_articulo);


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_articulo_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;

                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Columns[0].ColumnName == "informe") { ds.Tables[i].TableName = "informe"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "articulo") { ds.Tables[i].TableName = "articulo"; }
                }

                retorno.informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                string Error = (from item in retorno.informe select item.Id).First().ToString();
                if (Error.Equals("1")) return retorno;

                retorno.t_articulo= ds.Tables["articulo"].DataTableToList<EN_articulo.t_articulo>().ToList();

                return retorno;

            }

            catch (Exception ex)
            {
                var error = new DAO_zero();
                retorno.informe = error.msg_exception(ex);
                return retorno;

            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

        }






    }
}
