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
            SqlDataReader dr = null;

            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_grupo3_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "grupo1") retorno.grupo1 = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "grupo2") retorno.grupo2 = dr.MapData<EN_zero.datacombo>().ToList();
                    Result = dr.NextResult();
                }
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
                dr.Close();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

        }



        public EN_grupo3.proc_grupo3_mnt_retorno proc_grupo3_mnt(EN_grupo3.proc_grupo3_mnt parametros)
        {
            var retorno = new EN_grupo3.proc_grupo3_mnt_retorno();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

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
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "grupo3") retorno.t_grupo3 = dr.MapData<EN_grupo3.t_grupo3>().ToList();
                    Result = dr.NextResult();
                }
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
                dr.Close();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

        }

    }
}
