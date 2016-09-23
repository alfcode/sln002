using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_grupo3
    {

        public EN_grupo3.proc_grupo3_mnt_combo proc_grupo3_mnt_combo()
        {
            var retorno = new EN_grupo3.proc_grupo3_mnt_combo();
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_grupo3_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    string name = ds.Tables[i].Columns[0].ColumnName;
                    if (name == "informe") { ds.Tables[i].TableName = "informe"; }
                    if (name == "grupo1") { ds.Tables[i].TableName = "grupo1"; }
                    if (name == "grupo2") { ds.Tables[i].TableName = "grupo2"; }
                    ds.Tables[i].Columns.RemoveAt(0);
                }

                retorno.informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                string Error = (from item in retorno.informe select item.Error).First().ToString();
                if (Error.Equals("1")) return retorno;

                retorno.grupo1 = ds.Tables["grupo1"].DataTableToList<EN_zero.datacombo>().ToList();
                retorno.grupo2 = ds.Tables["grupo2"].DataTableToList<EN_zero.datacombo>().ToList();
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



        public EN_grupo3.proc_grupo3_mnt_retorno proc_grupo3_mnt(EN_grupo3.proc_grupo3_mnt parametros)
        {
            var retorno = new EN_grupo3.proc_grupo3_mnt_retorno();
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();


            DataTable dt = DAO_zero.ListToData(parametros.t_grupo3);


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_grupo3_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@id_grupo2", parametros.id_grupo2);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;

                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    string name = ds.Tables[i].Columns[0].ColumnName;
                    if (name == "informe") { ds.Tables[i].TableName = "informe"; }
                    if (name == "grupo3") { ds.Tables[i].TableName = "grupo3"; }
                    ds.Tables[i].Columns.RemoveAt(0);
                }
 
                retorno.informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                string Error = (from item in retorno.informe select item.Id).First().ToString();
                if (Error.Equals("1")) return retorno;

                retorno.t_grupo3 = ds.Tables["grupo3"].DataTableToList<EN_grupo3.t_grupo3>().ToList();

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
