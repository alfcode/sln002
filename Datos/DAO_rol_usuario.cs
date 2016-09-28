using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_rol_usuario
    {


        public EN_rol_usuario.proc_rol_usuario_mnt_combo proc_rol_usuario_mnt_combo()
        {
            var retorno = new EN_rol_usuario.proc_rol_usuario_mnt_combo();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;
            
            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();

                cmd.CommandText = "rrhh.proc_rol_usuario_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_area") retorno.area = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_usuario") retorno.usuario = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_rol") retorno.rol = dr.MapData<EN_zero.datacombo>().ToList();
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





        public EN_rol_usuario.proc_rol_usuario_mnt_retorno proc_rol_usuario_mnt(EN_rol_usuario.proc_rol_usuario_mnt parametros)
        {
            var retorno = new EN_rol_usuario.proc_rol_usuario_mnt_retorno();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;
            var dt = new DataTable();

            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();

                cmd.CommandText = "p_tabla_estructura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tabla1", "rrhh.t_rol_usuario");
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "t_rol_usuario") dt = DAO_zero.estructura(dr, parametros.t_rol_usuario);
                    Result = dr.NextResult();
                }
                dr.Close();

                cmd.CommandText = "rrhh.proc_rol_usuario_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;
                dr = cmd.ExecuteReader();

                Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_rol_usuario") retorno.t_rol_usuario = dr.MapData<EN_rol_usuario.t_rol_usuario>().ToList();
                    Result = dr.NextResult();
                }

                dr.Close();
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
