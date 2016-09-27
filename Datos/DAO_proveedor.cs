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

            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_proveedor_mnt_combo";
                cmd.CommandType = CommandType.StoredProcedure;
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                        var  name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                        if (name == "informe") retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                        if (name == "gironegocio") retorno.gironegocio = dr.MapData<EN_zero.datacombo>().ToList(); 
                        if (name == "formapago") retorno.formapago = dr.MapData<EN_zero.datacombo>().ToList();
                        if (name == "pais") retorno.pais = dr.MapData<EN_zero.datacombo>().ToList(); 
                        if (name == "departamento") retorno.departamento=dr.MapData<EN_zero.datacombo>().ToList();
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



        
        public EN_proveedor.proc_proveedor_mnt_retorno proc_proveedor_mnt(EN_proveedor.proc_proveedor_mnt parametros)
        {
            var retorno = new EN_proveedor.proc_proveedor_mnt_retorno();
            var cmd = new SqlCommand();
            SqlDataReader dr = null;

            DataTable dt = DAO_zero.ListToData(parametros.t_proveedor);

            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_proveedor_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;
                dr= cmd.ExecuteReader();

                System.DateTime start = DateTime.Now;
                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "informe")  retorno.informe = dr.MapData<EN_zero.informe>().ToList();
                    if (name == "proveedor") retorno.t_proveedor = dr.MapData<EN_proveedor.t_proveedor>().ToList();
                    Result = dr.NextResult();
                }
                
                System.DateTime stop = DateTime.Now;
                System.TimeSpan ts = new TimeSpan(stop.Ticks - start.Ticks);
                string tiempo= "Finished in " + ts.TotalMilliseconds + " milliseconds";

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
