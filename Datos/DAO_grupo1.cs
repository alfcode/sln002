using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_grupo1
    {

        public EN_grupo1.proc_grupo1_mnt_retorno proc_grupo1_mnt(EN_grupo1.proc_grupo1_mnt parametros)
        {
            var retorno = new EN_grupo1.proc_grupo1_mnt_retorno();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            DataTable dt = DAO_zero.ListToData(parametros.t_grupo1);


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_grupo1_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "grupo1")  retorno.t_grupo1 = dr.MapData<EN_grupo1.t_grupo1>().ToList();
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
