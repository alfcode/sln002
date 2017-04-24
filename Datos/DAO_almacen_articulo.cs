using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_almacen_articulo
    {

        public EN_almacen_articulo.proc_almacen_articulo_mnt_combo proc_almacen_articulo_mnt_combo()
        {
            var retorno = new EN_almacen_articulo.proc_almacen_articulo_mnt_combo();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();
                cmd.CommandText = "inve.proc_almacen_articulo_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_almacen") retorno.lista_almacen = dr.MapData<EN_almacen_articulo.lista_almacen>().ToList();
                    if (name == "t_articulo") retorno.articulo = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_unidad") retorno.unidad = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_tipo_unidad_almacen") retorno.lista_tipo_unidad_almacen = dr.MapData<EN_almacen_articulo.lista_tipo_unidad_almacen>().ToList();
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





        public EN_almacen_articulo.proc_almacen_articulo_mnt_retorno proc_almacen_articulo_mnt(EN_almacen_articulo.proc_almacen_articulo_mnt parametros)
        {
            var retorno = new EN_almacen_articulo.proc_almacen_articulo_mnt_retorno();
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
                cmd.Parameters.AddWithValue("@tabla1", "inve.t_almacen_articulo");
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "t_almacen_articulo") dt = DAO_zero.estructura(dr, parametros.t_almacen_articulo);
                    Result = dr.NextResult();
                }
                dr.Close();

                cmd.CommandText = "inve.proc_almacen_articulo_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@id_almacen", parametros.id_almacen);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;
                dr = cmd.ExecuteReader();

                Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_almacen_articulo") retorno.t_almacen_articulo = dr.MapData<EN_almacen_articulo.t_almacen_articulo>().ToList();
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
