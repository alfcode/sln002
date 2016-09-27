using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_usuario
    {

        public EN_usuario.proc_usuario_mnt_combo proc_usuario_mnt_combo()
        {
            var retorno = new EN_usuario.proc_usuario_mnt_combo();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "rrhh.proc_usuario_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "tipodocu_personal") retorno.tipodocu_personal = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "area") retorno.area = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "cargo") retorno.cargo = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "departamento") retorno.departamento = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "provincia") retorno.provincia = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "distrito") retorno.distrito = dr.MapData<EN_zero.datacombo>().ToList();
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





        public EN_usuario.proc_usuario_mnt_retorno proc_usuario_mnt(EN_usuario.proc_usuario_mnt parametros)
        {
            var retorno = new EN_usuario.proc_usuario_mnt_retorno();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            DataTable dt = DAO_zero.ListToData(parametros.t_usuario);


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "rrhh.proc_usuario_mnt";
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
                    if (name == "usuario") retorno.t_usuario = dr.MapData<EN_usuario.t_usuario>().ToList();
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
