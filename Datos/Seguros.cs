using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    internal class Seguros
    {
        public DataTable searchSeguros()
        {
            string conn = ConfigurationManager.ConnectionStrings["ReporteAseguradoraCredito.Properties.Settings.Reportes"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("select top 50 * from CAC_HISTORIAL_DOCUMENTO with(nolock) where HISDOCAfectaInventario = 0", connection))
                {
                    command.CommandType = CommandType.Text;
                    DataTable result = new DataTable();

                    try
                    {
                        connection.Open();
                        SqlDataAdapter DA = new SqlDataAdapter();
                        DA.Fill(result);
                        return result;
                    }
                    catch
                    {
                        return null;
                    }
                }
            }
        }
    }
}
