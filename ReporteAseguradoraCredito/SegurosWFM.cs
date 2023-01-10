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
                        //var totalFacAnul = dataSet.Tables[0];
                        //var serie = totalFacAnul.Where(row => row.Equals("[Serie Aseguradora]") = txtSerieSeguro.Text);
                        //var resultSum = totalFacAnul.Compute("Sum([Total Aseguradora])", "Estado = 0 and [Tipo Documento] = 2");
                        //lblTotalAseg.Text = resultSum.ToString();
                        dataGridDetalleSeguro.DataSource = dataSet.Tables[0];
                        int c = dataGridDetalleSeguro.Rows.Count;
                        for (int i = 0; i < c; i++)
                        {
                            if (dataGridDetalleSeguro.Rows[i].Cells[11].Value.ToString() == "4" || dataGridDetalleSeguro.Rows[i].Cells[26].Value.ToString() == "0")
                            {
                                dataGridDetalleSeguro.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                                dataGridDetalleSeguro.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(236, 72, 36);
                            }
                            /*else if (dataGridDetalleSeguro.Rows[i].Cells[26].Value.ToString() == "0")
                            {
                                dataGridDetalleSeguro.Rows[i].DefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
                                dataGridDetalleSeguro.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(149, 145, 144);
                            }*/
                            /*else if(dataGridDetalleSeguro.Rows[i].Cells[26].Value.ToString() == "1")
                            {
                                dataGridDetalleSeguro.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(48, 189, 34);
                            }*/

                        }

                        var consolidadoAseguradora = dataSet.Tables[2];
                        dataGridConsolidadoSeguro.DataSource = consolidadoAseguradora;
                        var sumaConsolidadoAseguradora = consolidadoAseguradora.Compute("Sum(Total)", "");
                        consolidadoAseguradora.Rows.Add(new object[] {0, "TOTAL", sumaConsolidadoAseguradora});

                        var totalAseguradora = dataSet.Tables[1];
                        lblTotalAseg.Text = totalAseguradora.Rows[0]["Total"].ToString();
                        
                        //consolidado cliente
                        var totalCliente = dataSet.Tables[3];
                        lblTotalClie.Text = totalCliente.Rows[0]["Total"].ToString();
                        
                        var ConsolidadoCliente = dataSet.Tables[4];
                        dataGridConsolidadoCliente.DataSource = ConsolidadoCliente;
                        var sumaConsolidadoCliente = ConsolidadoCliente.Compute("Sum(Total)", "");
                        ConsolidadoCliente.Rows.Add(new object[] {0, "TOTAL", sumaConsolidadoCliente });
                                               
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

       /* private void txtSerieSeguro_TextChanged(object sender, EventArgs e)
        {
            if(txtSerieSeguro.Text != "")
            {
                dataGridDetalleSeguro.CurrentCell = null;
                foreach(DataGridViewRow c in dataGridDetalleSeguro.Rows)
                {
                    c.Visible = false;
                }
                foreach (DataGridViewRow c in dataGridDetalleSeguro.Rows)
                {
                    foreach(DataGridViewCell cel in c.Cells)
                    {
                        if ((cel.Value.ToString().ToUpper()).IndexOf(txtSerieSeguro.Text.ToUpper()) == 0)
                        {
                            c.Visible = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                obtenerDatos();
            }
        }

        private void txtReferenciaSeguro_TextChanged(object sender, EventArgs e)
        {
            if (txtReferenciaSeguro.Text != "")
            {
                dataGridDetalleSeguro.CurrentCell = null;
                foreach (DataGridViewRow c in dataGridDetalleSeguro.Rows)
                {
                    c.Visible = false;
                }
                foreach (DataGridViewRow c in dataGridDetalleSeguro.Rows)
                {
                    foreach (DataGridViewCell cel in c.Cells)
                    {
                        if ((cel.Value.ToString().ToUpper()).IndexOf(txtSerieSeguro.Text.ToUpper()) == 0)
                        {
                            c.Visible = true;
                            break;
                        }
                    }
                }
            }
            else
            {
                obtenerDatos();
            }
        }*/
    }
}
