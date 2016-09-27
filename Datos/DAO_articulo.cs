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

            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_articulo_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "unidad") retorno.unidad = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "grupo1") retorno.grupo1 = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "grupo2") retorno.grupo2 = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "grupo3") retorno.grupo3 = dr.MapData<EN_zero.datacombo>().ToList();
                    Result = dr.NextResult();
                }
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
                dr.Close();
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

        }





        public EN_articulo.proc_articulo_mnt_retorno proc_articulo_mnt(EN_articulo.proc_articulo_mnt parametros )
        {
            var retorno = new EN_articulo.proc_articulo_mnt_retorno();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            DataTable dt = DAO_zero.ListToData(parametros.t_articulo);


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_articulo_mnt";
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
                    if (name == "articulo") retorno.t_articulo = dr.MapData<EN_articulo.t_articulo>().ToList();
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
