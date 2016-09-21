using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_provincia
    {

        public EN_provincia.proc_provincia_mnt_combo proc_provincia_mnt_combo()
        {
            var retorno = new EN_provincia.proc_provincia_mnt_combo();
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "rrhh.proc_provincia_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Columns[0].ColumnName == "informe") { ds.Tables[i].TableName = "informe"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "departamento") { ds.Tables[i].TableName = "departamento"; }
                }

                retorno.informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                string Error = (from item in retorno.informe select item.Error).First().ToString();
                if (Error.Equals("1")) return retorno;


                retorno.departamento= ds.Tables["departamento"].DataTableToList<EN_zero.datacombo>().ToList();
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





        public EN_provincia.proc_provincia_mnt_retorno proc_provincia_mnt(EN_provincia.proc_provincia_mnt parametros)
        {
            var retorno = new EN_provincia.proc_provincia_mnt_retorno();
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();


            DataTable dt = DAO_zero.ListToData(parametros.t_provincia);


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "rrhh.proc_provincia_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@id_departamento", parametros.id_departamento);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;

                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Columns[0].ColumnName == "informe") { ds.Tables[i].TableName = "informe"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "provincia") { ds.Tables[i].TableName = "provincia"; }
                }

                retorno.informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                string Error = (from item in retorno.informe select item.Id).First().ToString();
                if (Error.Equals("1")) return retorno;

                retorno.t_provincia = ds.Tables["provincia"].DataTableToList<EN_provincia.t_provincia>().ToList();

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
