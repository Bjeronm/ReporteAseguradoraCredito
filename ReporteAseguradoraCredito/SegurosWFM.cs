using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace ReporteAseguradoraCredito
{
    public partial class SegurosWFM : Form
    {
        public SegurosWFM()
        {
            InitializeComponent();
        }

        private void obtenerDatos()
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
                        //command.Parameters.AddWithValue("@FECHA_INI",fechaIniSeguro.Value.Date.ToString("yyyyMMdd"));
                        //command.Parameters.AddWithValue("@FECHA_FIN",fechaFinSeguros.Value.Date.ToString("yyyyMMdd"));
                        SqlDataAdapter DA = new SqlDataAdapter(command);
                        DA.SelectCommand.Parameters.AddWithValue("@FECHA_INI",fechaIniSeguro.Value.Date.ToString("yyyyMMdd"));
                        DA.SelectCommand.Parameters.AddWithValue("@FECHA_FIN", fechaFinSeguros.Value.Date.ToString("yyyyMMdd"));
                        DA.Fill(dataSet);
                        dataSet.Tables.Add(result);
                        dataGridDetalleSeguro.DataSource = dataSet.Tables[0];
                        dataGridConsolidadoSeguro.DataSource = dataSet.Tables[2];
                        var totalAseguradora = dataSet.Tables[1];
                        lblTotalAseg.Text = totalAseguradora.Rows[0]["Total"].ToString();
                        //consolidado cliente
                        dataGridConsolidadoCliente.DataSource = dataSet.Tables[4];
                        var totalCliente = dataSet.Tables[3];
                        lblTotalClie.Text = totalCliente.Rows[0]["Total"].ToString();

                        var tabla4 = dataSet.Tables[4];
                        var suma = tabla4.Compute("Sum(Total)", "");
                        dataSet.Tables[4].Rows.Add(new object[] {0, "Total",suma});

                        
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message, "Error Message");
                    }
                }
            }
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            obtenerDatos();
        }
    }
}
