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
    public class DAO_usuario
    {

        public List<EN_zero.informe> prc_usuario_mnt(EN_usuario.prc_usuario_mnt parametros)
        {
            var retorno = new List<EN_zero.informe>();

            var cmd = new SqlCommand();
            var ds = new DataSet();
            var da = new SqlDataAdapter();

            var dt = new DataTable();
            

            dt = DAO_zero.ObjectToData(parametros.t_usuario);
            

            cmd.Connection = AdoConn.Conn();
            cmd.Connection.Open();
            try
            {
                cmd.CommandText = "proc_usuario_mnt";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_tarea", parametros.t_usuario_tarea.tarea);
                cmd.Parameters.AddWithValue("@p_usuario", SqlDbType.Structured).Value = dt;

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
