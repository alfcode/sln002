using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using System.Collections;

namespace Datos
{
    public class DAO_ingreso
    {

        public EN_ingreso.proc_ingreso_mnt_combo proc_ingreso_mnt_combo()
        {
            var retorno = new EN_ingreso.proc_ingreso_mnt_combo();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();
                cmd.CommandText = "inve.proc_ingreso_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;

                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_empresa") retorno.empresa = dr.MapData<EN_zero.datacombo_simple>().ToList();
                    if (name == "t_centro_costo") retorno.centro_costo = dr.MapData<EN_zero.datacombo_simple>().ToList();
                    if (name == "t_almacen") retorno.almacen = dr.MapData<EN_ingreso.lista_almacen>().ToList();
                    if (name == "t_proveedor") retorno.proveedor = dr.MapData<EN_zero.datacombo_simple>().ToList();
                    if (name == "t_tdocu_sunat") retorno.tdocu_sunat = dr.MapData<EN_zero.datacombo_simple>().ToList();
                    if (name == "t_tingreso") retorno.tingreso = dr.MapData<EN_ingreso.lista_tipo_ingreso>().ToList();
                    if (name == "t_moneda") retorno.moneda = dr.MapData<EN_zero.datacombo_simple>().ToList();
                    if (name == "t_articulo") retorno.lista_articulo = dr.MapData<EN_ingreso.lista_articulo>().ToList();
                    if (name == "t_unidad") retorno.unidad = dr.MapData<EN_zero.datacombo_simple>().ToList();

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



        public EN_ingreso.proc_ingreso_mnt_tipo_unidad_almacen proc_ingreso_mnt_tipo_unidad_almacen(EN_ingreso.proc_ingreso_mnt_tipo_unidad_almacen_parametros parametros)
        {
            var retorno = new EN_ingreso.proc_ingreso_mnt_tipo_unidad_almacen();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();
                cmd.CommandText = "inve.proc_ingreso_mnt_tipo_unidad_almacen";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_almacen", parametros.id_almacen);
                cmd.Parameters.AddWithValue("@id_almacen2", parametros.id_almacen2);

                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_tipo_unidad_almacen") retorno.lista_tipo_unidad_almacen = dr.MapData<EN_ingreso.lista_tipo_unidad_almacen>().ToList();
                    if (name == "t_articulo") retorno.lista_articulo = dr.MapData<EN_ingreso.lista_articulo>().ToList();

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





        public EN_ingreso.proc_ingreso_mnt_busca_retorno proc_ingreso_mnt_busca(EN_ingreso.proc_ingreso_mnt_busca parametros)
        {
            var retorno = new EN_ingreso.proc_ingreso_mnt_busca_retorno();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();
                cmd.CommandText = "inve.proc_ingreso_mnt_busca";
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
                    if (name == "t_orden_cab") retorno.t_ingreso_busca_cab = dr.MapData<EN_ingreso.t_ingreso_busca_cab>().ToList();
                    if (name == "t_orden_det") retorno.t_ingreso_busca_det = dr.MapData<EN_ingreso.t_ingreso_busca_det>().ToList();

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



        public EN_ingreso.proc_ingreso_mnt_retorno proc_ingreso_mnt(EN_ingreso.proc_ingreso_mnt parametros)
        {
            var retorno = new EN_ingreso.proc_ingreso_mnt_retorno();
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
                cmd.Parameters.AddWithValue("@tabla1", "inve.t_ingreso");
                cmd.Parameters.AddWithValue("@tabla2", "inve.t_ingreso_det");
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "t_ingreso") dt = DAO_zero.estructura(dr, parametros.t_ingreso);
                    if (name == "t_ingreso_det") dt2 = DAO_zero.estructura(dr, parametros.t_ingreso_det);

                    Result = dr.NextResult();
                }
                dr.Close();

                cmd.CommandText = "inve.proc_ingreso_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@id_ingreso", parametros.id_ingreso);
                cmd.Parameters.AddWithValue("@id_salida", parametros.id_salida);
                cmd.Parameters.AddWithValue("@transferencia", parametros.transferencia);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;
                cmd.Parameters.AddWithValue("@tdp_param2", SqlDbType.Structured).Value = dt2;

                //var demo = DataTable2String(dt2);

                dr = cmd.ExecuteReader();

                Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_ingreso") retorno.t_ingreso = dr.MapData<EN_ingreso.t_ingreso>().ToList();
                    if (name == "t_ingreso_det") retorno.t_ingreso_det = dr.MapData<EN_ingreso.t_ingreso_det>().ToList();

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



        public static string DataTable2String(DataTable dataTable)
        {
            StringBuilder sb = new StringBuilder();
            if (dataTable != null)
            {
                string seperator = " | ";

                #region get min length for columns
                Hashtable hash = new Hashtable();
                foreach (DataColumn col in dataTable.Columns)
                    hash[col.ColumnName] = col.ColumnName.Length;
                foreach (DataRow row in dataTable.Rows)
                    for (int i = 0; i < row.ItemArray.Length; i++)
                        if (row[i] != null)
                            if (((string)row[i].ToString()).Length > (int)hash[dataTable.Columns[i].ColumnName])
                                hash[dataTable.Columns[i].ColumnName] = ((string)row[i].ToString()).Length;
                int rowLength = (hash.Values.Count + 1) * seperator.Length;
                foreach (object o in hash.Values)
                    rowLength += (int)o;
                #endregion get min length for columns

                sb.Append(new string('=', (rowLength - " DataTable ".Length) / 2));
                sb.Append(" DataTable ");
                sb.AppendLine(new string('=', (rowLength - " DataTable ".Length) / 2));
                if (!string.IsNullOrEmpty(dataTable.TableName))
                    sb.AppendLine(String.Format("{0,-" + rowLength + "}", String.Format("{0," + ((rowLength + dataTable.TableName.Length) / 2).ToString() + "}", dataTable.TableName)));

                #region write values
                foreach (DataColumn col in dataTable.Columns)
                    sb.Append(seperator + String.Format("{0,-" + hash[col.ColumnName] + "}", col.ColumnName));
                sb.AppendLine(seperator);
                sb.AppendLine(new string('-', rowLength));
                foreach (DataRow row in dataTable.Rows)
                {
                    for (int i = 0; i < row.ItemArray.Length; i++)
                    {
                        sb.Append(seperator + String.Format("{0," + hash[dataTable.Columns[i].ColumnName] + "}", row[i]));
                        if (i == row.ItemArray.Length - 1)
                            sb.AppendLine(seperator);
                    }
                }
                #endregion write values

                sb.AppendLine(new string('=', rowLength));
            }
            else
                sb.AppendLine("================ DataTable is NULL ================");

            return sb.ToString();
        }


    }
}
