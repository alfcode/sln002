﻿using System;
using System.Linq;
using Conexion;
using _ExtensionMethods;
using Entidad;
using System.Data.SqlClient;
using System.Data;
namespace Datos
{
    public class DAO_tdocu_sunat
    {

        public EN_tdocu_sunat.proc_tdocu_sunat_mnt_retorno proc_tdocu_sunat_mnt(EN_tdocu_sunat.proc_tdocu_sunat_mnt parametros)
        {
            var retorno = new EN_tdocu_sunat.proc_tdocu_sunat_mnt_retorno();
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
                cmd.Parameters.AddWithValue("@tabla1", "conta.t_tdocu_sunat");
                dr = cmd.ExecuteReader();

                var Result = true;
                while (Result)
                {
                    var name = (dr.GetSchemaTable().Rows.Cast<DataRow>().Select(r => (string)r[0]).ToList()).First().ToString();
                    if (name == "t_tdocu_sunat") dt = DAO_zero.estructura(dr, parametros.t_tdocu_sunat);
                    Result = dr.NextResult();
                }
                dr.Close();

                cmd.CommandText = "conta.proc_tdocu_sunat_mnt";
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
                    if (name == "t_tdocu_sunat") retorno.t_tdocu_sunat = dr.MapData<EN_tdocu_sunat.t_tdocu_sunat>().ToList();
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
