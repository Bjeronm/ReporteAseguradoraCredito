using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Datos
{
    public class Creditos
    {
        public DataSet getVentasCredito(string SpCreditos, string fechaIni, string fechafin)
        {
            string conn = ConfigurationManager.ConnectionStrings["ReporteAseguradoraCredito.Properties.Settings.Reportes"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conn))
            {
                using (SqlCommand command = new SqlCommand(SpCreditos, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    DataTable result = new DataTable();
                    DataSet dataSet = new DataSet();

                    try
                    {
                        connection.Open();
                        SqlDataAdapter DA = new SqlDataAdapter(command);
                        DA.SelectCommand.Parameters.AddWithValue("@FECHA_INI", fechaIni);
                        DA.SelectCommand.Parameters.AddWithValue("@FECHA_FIN", fechafin);
                        DA.Fill(dataSet);
                        dataSet.Tables.Add(result);
                        return dataSet;
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message, "Error Message");
                        return null;
                    }
                }
            }
        }
    }
}
