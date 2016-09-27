using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_empresa
    {
       
        public EN_empresa.proc_empresa_mnt_retorno proc_empresa_mnt(EN_empresa.proc_empresa_mnt parametros)
        {
            var retorno = new EN_empresa.proc_empresa_mnt_retorno();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            DataTable dt = DAO_zero.ListToData(parametros.t_empresa);


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "conta.proc_empresa_mnt";
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
                    if (name == "empresa") retorno.t_empresa = dr.MapData<EN_empresa.t_empresa>().ToList();
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
