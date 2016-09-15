using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_proveedor
    {

        public EN_proveedor.proc_proveedor_mnt_combo proc_proveedor_mnt_combo()
        {
            var retorno = new EN_proveedor.proc_proveedor_mnt_combo();
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_proveedor_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Columns[0].ColumnName == "informe") { ds.Tables[i].TableName = "informe"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "gironegocio") { ds.Tables[i].TableName = "gironegocio"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "formapago") { ds.Tables[i].TableName = "formapago"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "pais") { ds.Tables[i].TableName = "pais"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "departamento") { ds.Tables[i].TableName = "departamento"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "zona ") { ds.Tables[i].TableName = "zona"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "postal") { ds.Tables[i].TableName = "postal"; }

                }

                retorno.informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                string Error = (from item in retorno.informe select item.Error).First().ToString();
                if (Error.Equals("1")) return retorno;


                retorno.gironegocio = ds.Tables["gironegocio"].DataTableToList<EN_zero.datacombo>().ToList();
                retorno.formapago = ds.Tables["formapago"].DataTableToList<EN_zero.datacombo>().ToList();
                retorno.pais= ds.Tables["grupo2"].DataTableToList<EN_zero.datacombo>().ToList();
                retorno.departamento = ds.Tables["grupo3"].DataTableToList<EN_zero.datacombo>().ToList();
                retorno.zona = ds.Tables["grupo3"].DataTableToList<EN_zero.datacombo>().ToList();
                retorno.postal = ds.Tables["grupo3"].DataTableToList<EN_zero.datacombo>().ToList();

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





        public EN_proveedor.proc_proveedor_mnt_retorno proc_proveedor_mnt(EN_proveedor.proc_proveedor_mnt parametros)
        {
            var retorno = new EN_proveedor.proc_proveedor_mnt_retorno();
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();


            DataTable dt = DAO_zero.ListToData(parametros.t_proveedor);


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_proveedor_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;

                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Columns[0].ColumnName == "informe") { ds.Tables[i].TableName = "informe"; }
                    if (ds.Tables[i].Columns[0].ColumnName == "proveedor") { ds.Tables[i].TableName = "proveedor"; }
                }

                retorno.informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                string Error = (from item in retorno.informe select item.Id).First().ToString();
                if (Error.Equals("1")) return retorno;

                retorno.t_proveedor = ds.Tables["proveedor"].DataTableToList<EN_proveedor.t_proveedor>().ToList();

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
