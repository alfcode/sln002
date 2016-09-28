using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.Reflection;

namespace Datos
{
    public class DAO_proveedor
    {

        public EN_proveedor.proc_proveedor_mnt_combo proc_proveedor_mnt_combo()
        {
            var retorno = new EN_proveedor.proc_proveedor_mnt_combo();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;
            
            try
            {
                cmd.Connection = AdoConn.Conn();
                cmd.Connection.Open();

                cmd.CommandText = "inve.proc_proveedor_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                        var  name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                        if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                        if (name == "t_gironegocio") retorno.gironegocio = dr.MapData<EN_zero.datacombo>().ToList(); 
                        if (name == "t_formapago") retorno.formapago = dr.MapData<EN_zero.datacombo>().ToList();
                        if (name == "t_pais") retorno.pais = dr.MapData<EN_zero.datacombo>().ToList(); 
                        if (name == "t_departamento") retorno.departamento=dr.MapData<EN_zero.datacombo>().ToList();
                        if (name == "t_provincia") retorno.provincia = dr.MapData<EN_zero.datacombo>().ToList(); 
                        if (name == "t_distrito") retorno.distrito = dr.MapData<EN_zero.datacombo>().ToList(); 
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



        
        public EN_proveedor.proc_proveedor_mnt_retorno proc_proveedor_mnt(EN_proveedor.proc_proveedor_mnt parametros)
        {
            var retorno = new EN_proveedor.proc_proveedor_mnt_retorno();
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
                cmd.Parameters.AddWithValue("@tabla1", "inve.t_proveedor");
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "t_proveedor") dt = DAO_zero.estructura(dr, parametros.t_proveedor);
                    Result = dr.NextResult();
                }
                dr.Close();

                cmd.CommandText = "inve.proc_proveedor_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;
                dr= cmd.ExecuteReader();
                
                Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe")  retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "t_proveedor") retorno.t_proveedor = dr.MapData<EN_proveedor.t_proveedor>().ToList();
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
