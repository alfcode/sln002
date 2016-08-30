using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Data.SqlClient;
using System.Data;
using Conexion;
using _ExtensionMethods;
namespace Datos
{
    public class DAO_estado
    {

        public List<EN_zero.informe> proc_estado_mnt(EN_estado.param_estado parametros)
        {
            var retorno = new List<EN_zero.informe>();

            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();

            var dt = new DataTable();


            dt = DAO_zero.ObjectToData(parametros.t_estado);


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "conta.proc_estado_mtto";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@tarea", parametros.accion.tarea);
                cmd.Parameters.AddWithValue("@tdp_param1", SqlDbType.Structured).Value = dt;

                da.SelectCommand = cmd;
                da.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    if (ds.Tables[i].Columns[0].ColumnName == "informe") { ds.Tables[i].TableName = "informe"; }
                }

                List<EN_zero.informe> informe = ds.Tables["informe"].DataTableToList<EN_zero.informe>().ToList();


                retorno = informe;

                return retorno;

            }

            catch (Exception ex)
            {
                var error = new DAO_zero();
                return error.msg_exception(ex);
            }
            finally
            {
                cmd.Connection.Close();
                cmd.Connection.Dispose();
            }

        }

    }
}
