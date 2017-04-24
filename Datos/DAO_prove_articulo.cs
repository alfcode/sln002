using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_prove_articulo
    {

        public EN_prove_articulo.proc_prove_articulo_mnt_combo proc_prove_articulo_mnt_combo()
        {
            var retorno = new EN_prove_articulo.proc_prove_articulo_mnt_combo();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();
                cmd.CommandText = "inve.proc_prove_articulo_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_proveedor") retorno.proveedor = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_articulo") retorno.articulo = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_moneda") retorno.moneda = dr.MapData<EN_zero.datacombo>().ToList();
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





        public EN_prove_articulo.proc_prove_articulo_mnt_retorno proc_prove_articulo_mnt(EN_prove_articulo.proc_prove_articulo_mnt parametros)
        {
            var retorno = new EN_prove_articulo.proc_prove_articulo_mnt_retorno();
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
                cmd.Parameters.AddWithValue("@tabla1", "inve.t_prove_articulo");
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "t_prove_articulo") dt = DAO_zero.estructura(dr, parametros.t_prove_articulo);
                    Result = dr.NextResult();
                }
                dr.Close();

                cmd.CommandText = "inve.proc_prove_articulo_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@id_proveedor", parametros.id_proveedor);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;
                dr = cmd.ExecuteReader();

                Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_prove_articulo") retorno.t_prove_articulo = dr.MapData<EN_prove_articulo.t_prove_articulo>().ToList();
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
