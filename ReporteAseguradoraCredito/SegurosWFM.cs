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
                        if(txtSerieSeguro.Text == "")
                        {
                            connection.Open();
                            //command.Parameters.AddWithValue("@FECHA_INI",fechaIniSeguro.Value.Date.ToString("yyyyMMdd"));
                            //command.Parameters.AddWithValue("@FECHA_FIN",fechaFinSeguros.Value.Date.ToString("yyyyMMdd"));
                            SqlDataAdapter DA = new SqlDataAdapter(command);
                            DA.SelectCommand.Parameters.AddWithValue("@FECHA_INI", fechaIniSeguro.Value.Date.ToString("yyyyMMdd"));
                            DA.SelectCommand.Parameters.AddWithValue("@FECHA_FIN", fechaFinSeguros.Value.Date.ToString("yyyyMMdd"));
                            DA.Fill(dataSet);
                            dataSet.Tables.Add(result);
                            var totalFacAnul = dataSet.Tables[0];
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
                            consolidadoAseguradora.Rows.Add(new object[] { 0, "TOTAL", sumaConsolidadoAseguradora });

                            var totalAseguradora = dataSet.Tables[1];
                            lblTotalAseg.Text = totalAseguradora.Rows[0]["Total"].ToString();

                            //consolidado cliente
                            var totalCliente = dataSet.Tables[3];
                            lblTotalClie.Text = totalCliente.Rows[0]["Total"].ToString();

                            var ConsolidadoCliente = dataSet.Tables[4];
                            dataGridConsolidadoCliente.DataSource = ConsolidadoCliente;
                            var sumaConsolidadoCliente = ConsolidadoCliente.Compute("Sum(Total)", "");
                            ConsolidadoCliente.Rows.Add(new object[] { 0, "TOTAL", sumaConsolidadoCliente });

                        }
                        else
                        {
                            DataTable detalles = dataSet.Tables[0];
                            EnumerableRowCollection<DataRow> query = from res in detalles.AsEnumerable()
                                                                     where res.Field<string>(2) == txtSerieSeguro.Text
                                                                     select res;
                            DataView view = query.AsDataView();
                            dataGridDetalleSeguro.DataSource = view;

                        }


                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message, "Error Message");
                    }
                }
            }
        }

        private void getVentasAseguradoras()
        {
            //datagrid detalle seguros
            var fechaI = fechaIniSeguro.Value.Date.ToString("yyyyMMdd");
            var fechaF = fechaFinSeguros.Value.Date.ToString("yyyyMMdd");
            Seguros seguros = new Seguros();
            DataSet data = seguros.getSeguros("USP_CAC_GET_VENTAS_ASEGURADORAS",fechaI,fechaF);
            dataGridDetalleSeguro.DataSource = data.Tables[0];

            int c = dataGridDetalleSeguro.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                var nc = dataGridDetalleSeguro.Rows[i].Cells[11].Value.ToString();
                var na = dataGridDetalleSeguro.Rows[i].Cells[11].Value.ToString();
                var facAnulada = dataGridDetalleSeguro.Rows[i].Cells[26].Value.ToString();
                if(nc == "4" || na == "5" || facAnulada == "0")
                {
                    dataGridDetalleSeguro.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    dataGridDetalleSeguro.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(236, 72, 36);
                }
            }

            //total aseguradora
            var totalAseguradora = data.Tables[1];
            lblTotalAseg.Text = totalAseguradora.Rows[0]["Total"].ToString();

            //consolidado aseguradora
            var consolidadoAseguradora = data.Tables[2];
            dataGridConsolidadoSeguro.DataSource = consolidadoAseguradora;
            var sumaConsolidadoAseguradora = consolidadoAseguradora.Compute("Sum(Total)","");
            consolidadoAseguradora.Rows.Add(new object[] { 0, "TOTAL", sumaConsolidadoAseguradora });

            //total cliente
            var totalCliente = data.Tables[3];
            lblTotalClie.Text = totalCliente.Rows[0]["Total"].ToString();

            //consolidado Cliente
            var consolidadoCliente = data.Tables[4];
            dataGridConsolidadoCliente.DataSource = consolidadoCliente;
            var sumaConsolidadoCliente = consolidadoCliente.Compute("Sum(Total)", "");
            consolidadoCliente.Rows.Add(new object[] {0, "TOTAL" , sumaConsolidadoCliente });

            
            //filtro por serie
            DataTable filtro = data.Tables[0];
            EnumerableRowCollection<DataRow> query = from res in filtro.AsEnumerable()
                                                     where res.Field<string>(2).StartsWith(txtSerieSeguro.Text.ToUpper().ToString()) 
                                                     select res;
            DataView view = query.AsDataView();
            dataGridDetalleSeguro.DataSource = view;


            //filtro por No. Referencia 
           /* DataTable filtro2 = data.Tables[0];
            EnumerableRowCollection<DataRow> query2 = from res2 in filtro2.AsEnumerable()
                                                      where res2.Field<string>(23).StartsWith(txtClienteSeguros.Text.ToUpper().ToString())
                                                      select res2;
            DataView view2 = query2.AsDataView();
            dataGridDetalleSeguro.DataSource = view2;*/

        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            //obtenerDatos();
            getVentasAseguradoras();
        }

        private void txtSerieSeguro_TextChanged(object sender, EventArgs e)
        {
            /*Seguros verificar = new Seguros();
            DataSet data = verificar.searchSeguros();
            DataTable detalle = data.Tables[0];*/
            /* var fechaI = fechaIniSeguro.Value.Date.ToString("yyyyMMdd");
             var fechaF = fechaFinSeguros.Value.Date.ToString("yyyyMMdd");
             Seguros filtrarSeguros = new Seguros();
             DataSet tablaDetalle = filtrarSeguros.getSeguros("USP_CAC_GET_VENTAS_ASEGURADORAS", fechaI, fechaF);

             DataTable filtro = tablaDetalle.Tables[0];
             EnumerableRowCollection<DataRow> query = from res in filtro.AsEnumerable()
                                                      where res.Field<string>(2).StartsWith(txtSerieSeguro.Text.ToUpper().ToString())
                                                      select res;
             DataView view = query.AsDataView();
             dataGridDetalleSeguro.DataSource = view;*/

          //  getVentasAseguradoras();
        }
        

        private void txtSerieSeguro_Enter(object sender, EventArgs e)
        {
            getVentasAseguradoras();
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
