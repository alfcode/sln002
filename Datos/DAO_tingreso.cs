using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using System.Data;
using System.Data.SqlClient;
using Conexion;
using _ExtensionMethods;
namespace Datos
{
    public class DAO_tingreso
    {

        public List<EN_zero.informe> prc_tingreso(EN_tingreso.param_tingreso parametros)
        {
            var retorno = new List<EN_zero.informe>();

            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();

            var dt = new DataTable();


            dt = DAO_zero.ObjectToData(parametros.t_ingreso);


            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "inve.proc_tingreso_mnt";
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
                var ayuda = new DAO_zero();
                retorno = ayuda.MsgInformeCapaDatos(ayuda.MsgErrorCapaDatos(ex)); ;
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
