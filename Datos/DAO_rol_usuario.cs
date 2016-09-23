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
            var ds = new DataSet();
            var da = new SqlDataAdapter();


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "rrhh.proc_rol_usuario_mnt_combo";

                cmd.CommandType = CommandType.StoredProcedure;
                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    string name = ds.Tables[i].Columns[0].ColumnName;
                    if (name == "informe") { ds.Tables[i].TableName = "informe"; }
                    if (name == "area") { ds.Tables[i].TableName = "area"; }
                    if (name == "usuario") { ds.Tables[i].TableName = "usuario"; }
                    if (name == "rol") { ds.Tables[i].TableName = "rol"; }

                    ds.Tables[i].Columns.RemoveAt(0);

                }

                retorno.informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                string Error = (from item in retorno.informe select item.Error).First().ToString();
                if (Error.Equals("1")) return retorno;


                retorno.area = ds.Tables["area"].DataTableToList<EN_zero.datacombo>().ToList();
                retorno.usuario = ds.Tables["usuario"].DataTableToList<EN_zero.datacombo>().ToList();
                retorno.rol = ds.Tables["rol"].DataTableToList<EN_zero.datacombo>().ToList();


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





        public EN_rol_usuario.proc_rol_usuario_mnt_retorno proc_rol_usuario_mnt(EN_rol_usuario.proc_rol_usuario_mnt parametros)
        {
            var retorno = new EN_rol_usuario.proc_rol_usuario_mnt_retorno();
            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();


            DataTable dt = DAO_zero.ListToData(parametros.t_rol_usuario);
                        dt.Columns.Remove("id_area");
                        //  dt.Columns.RemoveAt(0);

            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "rrhh.proc_rol_usuario_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id_usuario", parametros.id_usuario);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;

                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    string name = ds.Tables[i].Columns[0].ColumnName;
                    if (name == "informe") { ds.Tables[i].TableName = "informe"; }
                    if (name == "rol_usuario") { ds.Tables[i].TableName = "rol_usuario"; }
                    ds.Tables[i].Columns.RemoveAt(0);
                }

                retorno.informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();
                string Error = (from item in retorno.informe select item.Id).First().ToString();
                if (Error.Equals("1")) return retorno;

                retorno.t_rol_usuario = ds.Tables["rol_usuario"].DataTableToList<EN_rol_usuario.t_rol_usuario>().ToList();

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
