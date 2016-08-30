using System.Data.SqlClient;
using System.Configuration;
namespace Conexion
{
    public class AdoConn
    {
        public static string MiApp { get; set; }
        public static SqlConnection Conn()
        {
           // var cadena =  ConfigurationManager.ConnectionStrings["Server1"].ConnectionString;
            var cadena =  ConfigurationManager.ConnectionStrings["Server1"].ConnectionString ;

            var conecta = new SqlConnectionStringBuilder();
            conecta.ConnectionString = cadena;
            conecta.ApplicationName = MiApp ?? "Produccion";

            var Retorna = new SqlConnection();
            Retorna.ConnectionString = conecta.ToString();
            return Retorna;

        }


    }
}
