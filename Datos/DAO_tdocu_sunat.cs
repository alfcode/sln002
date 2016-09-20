using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_tdocu_sunat
    {

        public EN_tdocu_sunat.proc_tdocu_sunat_mnt_retorno proc_tdocu_sunat_mnt(EN_tdocu_sunat.proc_tdocu_sunat_mnt parametros)
        {
            var retorno = new EN_tdocu_sunat.proc_tdocu_sunat_mnt_retorno();
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();


            DataTable dt = DAO_zero.ListToData(parametros.t_tdocu_sunat);


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "conta.proc_tdocu_sunat_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;

                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Columns[0].ColumnName == "informe") { ds.Tables[i].TableName = "informe"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "tdocu_sunat") { ds.Tables[i].TableName = "tdocu_sunat"; }
                }

                retorno.informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                string Error = (from item in retorno.informe select item.Id).First().ToString();
                if (Error.Equals("1")) return retorno;

                retorno.t_tdocu_sunat = ds.Tables["tdocu_sunat"].DataTableToList<EN_tdocu_sunat.t_tdocu_sunat>().ToList();

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
