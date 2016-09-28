using System;
using System.Linq;
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
            SqlDataReader dr = null;
            
            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();
                cmd.CommandText = "inve.proc_articulo_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_unidad") retorno.unidad = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_grupo1") retorno.grupo1 = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_grupo2") retorno.grupo2 = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_grupo3") retorno.grupo3 = dr.MapData<EN_zero.datacombo>().ToList();
                    Result = dr.NextResult();
                }

                dr.Close();
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
            SqlDataReader dr = null;
            var dt = new DataTable();

            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();


                cmd.CommandText = "p_tabla_estructura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tabla1", "inve.t_articulo");
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "t_articulo") dt = DAO_zero.estructura(dr, parametros.t_articulo);
                    Result = dr.NextResult();
                }
                dr.Close();

                cmd.CommandText = "inve.proc_articulo_mnt";
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
                    if (name == "t_articulo") retorno.t_articulo = dr.MapData<EN_articulo.t_articulo>().ToList();
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
