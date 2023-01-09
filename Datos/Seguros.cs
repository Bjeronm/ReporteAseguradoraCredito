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
    public class Seguros
    {
        public DataSet searchSeguros()
        {
            string conn = ConfigurationManager.ConnectionStrings["ReporteAseguradoraCredito.Properties.Settings.Reportes"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand("USP_CAC_GET_VENTAS_ASEGURADORAS", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    DataTable result = new DataTable();
                    DataSet dataSet = new DataSet();

                    try
                    {
                        connection.Open();
                        SqlDataAdapter DA = new SqlDataAdapter();
                        dataSet.Tables.Add(result);
                        DA.Fill(dataSet);
                        return dataSet;
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
