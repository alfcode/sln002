using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_orden_compra
    {

        public EN_orden_compra.proc_orden_compra_mnt_combo proc_orden_compra_mnt_combo()
        {
            var retorno = new EN_orden_compra.proc_orden_compra_mnt_combo();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();
                cmd.CommandText = "inve.proc_orden_compra_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_almacen") retorno.almacen = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_articulo") retorno.articulo = dr.MapData<EN_orden_compra.lista_articulo>().ToList();
                    if (name == "t_centro_costo") retorno.centro_costo = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_empresa") retorno.empresa = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_moneda") retorno.moneda = dr.MapData<EN_zero.datacombo>().ToList();
                    if (name == "t_proveedor") retorno.proveedor = dr.MapData<EN_zero.datacombo>().ToList();


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


        public EN_orden_compra.proc_orden_compra_mnt_busca_retorno proc_orden_compra_mnt_busca(EN_orden_compra.proc_orden_compra_mnt_busca parametros)
        {
            var retorno = new EN_orden_compra.proc_orden_compra_mnt_busca_retorno();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();
                cmd.CommandText = "inve.proc_orden_compra_mnt_busca";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@numero", parametros.numero);
                cmd.Parameters.AddWithValue("@fecha_ini", parametros.fecha_ini);
                cmd.Parameters.AddWithValue("@fecha_fin", parametros.fecha_fin);
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_orden_cab") retorno.t_orden_compra_busca_cab = dr.MapData<EN_orden_compra.t_orden_compra_busca_cab>().ToList();
                    if (name == "t_orden_det") retorno.t_orden_compra_busca_det = dr.MapData<EN_orden_compra.t_orden_compra_busca_det>().ToList();

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



        public EN_orden_compra.proc_orden_compra_mnt_retorno proc_orden_compra_mnt(EN_orden_compra.proc_orden_compra_mnt parametros)
        {
            var retorno = new EN_orden_compra.proc_orden_compra_mnt_retorno();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;
            var dt = new DataTable();
            var dt2 = new DataTable();
            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();


                cmd.CommandText = "p_tabla_estructura";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tabla1", "inve.t_orden_compra");
                cmd.Parameters.AddWithValue("@tabla2", "inve.t_orden_compra_det");
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "t_orden_compra") dt = DAO_zero.estructura(dr, parametros.t_orden_compra);
                    if (name == "t_orden_compra_det") dt2 = DAO_zero.estructura(dr, parametros.t_orden_compra_det);

                    Result = dr.NextResult();
                }
                dr.Close();

                cmd.CommandText = "inve.proc_orden_compra_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@id_orden_compra", parametros.id_orden_compra);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;
                cmd.Parameters.AddWithValue("@tdp_param2", SqlDbType.Structured).Value = dt2;

                dr = cmd.ExecuteReader();

                Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_orden_compra") retorno.t_orden_compra = dr.MapData<EN_orden_compra.t_orden_compra>().ToList();
                    if (name == "t_orden_compra_det") retorno.t_orden_compra_det = dr.MapData<EN_orden_compra.t_orden_compra_det>().ToList();

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
