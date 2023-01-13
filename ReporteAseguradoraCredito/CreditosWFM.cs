using Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReporteAseguradoraCredito
{
    public partial class CreditosWFM : Form
    {
        DataTable dt = new DataTable();

        public CreditosWFM()
        {
            InitializeComponent();
        }
        
        private async Task getVentasCredito()
        {
            dt = new DataTable();

            var fechaInicio = fechaIniCreditos.Value.Date.ToString("yyyyMMdd");
            var fechaFinal = fechaFinCreditos.Value.Date.ToString("yyyyMMdd");

            Creditos creditos = new Creditos();
            DataSet data = await creditos.getVentasCredito("USP_CAC_GET_VENTAS_CREDITOS", fechaInicio, fechaFinal);

            dt = data.Tables[0];

            dataGridDetalleCreditos.DataSource = data.Tables[0];

            int c = dataGridDetalleCreditos.Rows.Count;
            for (int i = 0; i < c; i++)
            {
                var nc = dataGridDetalleCreditos.Rows[i].Cells[11].Value.ToString();
                var na = dataGridDetalleCreditos.Rows[i].Cells[11].Value.ToString();
                var fcAn = dataGridDetalleCreditos.Rows[i].Cells[15].Value.ToString();

                if (nc == "4" || na == "5" || fcAn == "0")
                {
                    dataGridDetalleCreditos.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    dataGridDetalleCreditos.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(236, 72, 36);
                }
            }

            //total creditos
            var totalVentasCredito = data.Tables[1];
            totalCreditos.Text = totalVentasCredito.Rows[0]["Total"].ToString();

            //consolidado creditos
            var consolidadoCreditos = data.Tables[2];
            dataGridConsolidadoCreditos.DataSource = consolidadoCreditos;
            var sumaConsolidadoCreditos = consolidadoCreditos.Compute("Sum(Total)", "");
            consolidadoCreditos.Rows.Add(new object[] { 0, "TOTAL", sumaConsolidadoCreditos });
        }
        

        private void txtSerieCredito_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleCreditos.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie] LIKE '%{0}%' AND [Numero] LIKE '%{1}%' 
                                                                                AND [Numero Fel] LIKE '%{2}%'
                                                                                AND [Nombre] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen] LIKE '%{5}%'
                                                                                AND [Numero Origen] LIKE '%{6}%'
                                                                                AND [Total] LIKE '%{7}%'", txtSerieCredito.Text.ToUpper().Trim()
                                                                                , txtReferenciaCredito.Text.Trim()
                                                                                , txtFelCredito.Text.Trim()
                                                                                , txtClienteCredito.Text.ToUpper().Trim()
                                                                                , txtConvenioCredito.Text.Trim()
                                                                                , txtSerieOrgCredito.Text.ToUpper().Trim()
                                                                                , txtNoOrgCredito.Text.Trim()
                                                                                , txtMontoCredito.Text.Trim());
                dataGridDetalleCreditos.DataSource = dt;
            }
            else
            {
                error.SetError(txtSerieCredito, "No hay datos para filtrar");
            }
            
        }

        private void txtReferenciaCredito_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleCreditos.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie] LIKE '%{0}%' AND [Numero] LIKE '%{1}%' 
                                                                                AND [Numero Fel] LIKE '%{2}%'
                                                                                AND [Nombre] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen] LIKE '%{5}%'
                                                                                AND [Numero Origen] LIKE '%{6}%'
                                                                                AND [Total] LIKE '%{7}%'", txtSerieCredito.Text.ToUpper().Trim()
                                                                                , txtReferenciaCredito.Text.Trim()
                                                                                , txtFelCredito.Text.Trim()
                                                                                , txtClienteCredito.Text.ToUpper().Trim()
                                                                                , txtConvenioCredito.Text.Trim()
                                                                                , txtSerieOrgCredito.Text.ToUpper().Trim()
                                                                                , txtNoOrgCredito.Text.Trim()
                                                                                , txtMontoCredito.Text.Trim());
                dataGridDetalleCreditos.DataSource = dt;
            }
            else
            {
                error.SetError(txtReferenciaCredito, "No hay datos para filtrar");
            }
            
        }

        private void txtFelCredito_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleCreditos.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie] LIKE '%{0}%' AND [Numero] LIKE '%{1}%' 
                                                                                AND [Numero Fel] LIKE '%{2}%'
                                                                                AND [Nombre] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen] LIKE '%{5}%'
                                                                                AND [Numero Origen] LIKE '%{6}%'
                                                                                AND [Total] LIKE '%{7}%'", txtSerieCredito.Text.ToUpper().Trim()
                                                                                , txtReferenciaCredito.Text.Trim()
                                                                                , txtFelCredito.Text.Trim()
                                                                                , txtClienteCredito.Text.ToUpper().Trim()
                                                                                , txtConvenioCredito.Text.Trim()
                                                                                , txtSerieOrgCredito.Text.ToUpper().Trim()
                                                                                , txtNoOrgCredito.Text.Trim()
                                                                                , txtMontoCredito.Text.Trim());
                dataGridDetalleCreditos.DataSource = dt;
            }
            else
            {
                error.SetError(txtFelCredito, "No hay datos para filtrar");
            }
        }

        private void txtClienteCredito_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleCreditos.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie] LIKE '%{0}%' AND [Numero] LIKE '%{1}%' 
                                                                                AND [Numero Fel] LIKE '%{2}%'
                                                                                AND [Nombre] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen] LIKE '%{5}%'
                                                                                AND [Numero Origen] LIKE '%{6}%'
                                                                                AND [Total] LIKE '%{7}%'", txtSerieCredito.Text.ToUpper().Trim()
                                                                                , txtReferenciaCredito.Text.Trim()
                                                                                , txtFelCredito.Text.Trim()
                                                                                , txtClienteCredito.Text.ToUpper().Trim()
                                                                                , txtConvenioCredito.Text.Trim()
                                                                                , txtSerieOrgCredito.Text.ToUpper().Trim()
                                                                                , txtNoOrgCredito.Text.Trim()
                                                                                , txtMontoCredito.Text.Trim());
                dataGridDetalleCreditos.DataSource = dt;
            }
            else
            {
                error.SetError(txtClienteCredito, "No hay datos para filtrar");
            }
        }

        private void txtConvenioCredito_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleCreditos.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie] LIKE '%{0}%' AND [Numero] LIKE '%{1}%' 
                                                                                AND [Numero Fel] LIKE '%{2}%'
                                                                                AND [Nombre] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen] LIKE '%{5}%'
                                                                                AND [Numero Origen] LIKE '%{6}%'
                                                                                AND [Total] LIKE '%{7}%'", txtSerieCredito.Text.ToUpper().Trim()
                                                                                , txtReferenciaCredito.Text.Trim()
                                                                                , txtFelCredito.Text.Trim()
                                                                                , txtClienteCredito.Text.ToUpper().Trim()
                                                                                , txtConvenioCredito.Text.Trim()
                                                                                , txtSerieOrgCredito.Text.ToUpper().Trim()
                                                                                , txtNoOrgCredito.Text.Trim()
                                                                                , txtMontoCredito.Text.Trim());
                dataGridDetalleCreditos.DataSource = dt;
            }
            else
            {
                error.SetError(txtConvenioCredito, "No hay datos para filtrar");
            }
        }

        private void txtSerieOrgCredito_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleCreditos.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie] LIKE '%{0}%' AND [Numero] LIKE '%{1}%' 
                                                                                AND [Numero Fel] LIKE '%{2}%'
                                                                                AND [Nombre] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen] LIKE '%{5}%'
                                                                                AND [Numero Origen] LIKE '%{6}%'
                                                                                AND [Total] LIKE '%{7}%'", txtSerieCredito.Text.ToUpper().Trim()
                                                                                , txtReferenciaCredito.Text.Trim()
                                                                                , txtFelCredito.Text.Trim()
                                                                                , txtClienteCredito.Text.ToUpper().Trim()
                                                                                , txtConvenioCredito.Text.Trim()
                                                                                , txtSerieOrgCredito.Text.ToUpper().Trim()
                                                                                , txtNoOrgCredito.Text.Trim()
                                                                                , txtMontoCredito.Text.Trim());
                dataGridDetalleCreditos.DataSource = dt;
            }
            else
            {
                error.SetError(txtSerieOrgCredito, "No hay datos para filtrar");
            }
        }

        private void txtNoOrgCredito_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleCreditos.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie] LIKE '%{0}%' AND [Numero] LIKE '%{1}%' 
                                                                                AND [Numero Fel] LIKE '%{2}%'
                                                                                AND [Nombre] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen] LIKE '%{5}%'
                                                                                AND [Numero Origen] LIKE '%{6}%'
                                                                                AND [Total] LIKE '%{7}%'", txtSerieCredito.Text.ToUpper().Trim()
                                                                                , txtReferenciaCredito.Text.Trim()
                                                                                , txtFelCredito.Text.Trim()
                                                                                , txtClienteCredito.Text.ToUpper().Trim()
                                                                                , txtConvenioCredito.Text.Trim()
                                                                                , txtSerieOrgCredito.Text.ToUpper().Trim()
                                                                                , txtNoOrgCredito.Text.Trim()
                                                                                , txtMontoCredito.Text.Trim());
                dataGridDetalleCreditos.DataSource = dt;
            }
            else
            {
                error.SetError(txtNoOrgCredito, "No hay datos para filtrar");
            }
        }

        private void txtMontoCredito_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleCreditos.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie] LIKE '%{0}%' AND [Numero] LIKE '%{1}%' 
                                                                                AND [Numero Fel] LIKE '%{2}%'
                                                                                AND [Nombre] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen] LIKE '%{5}%'
                                                                                AND [Numero Origen] LIKE '%{6}%'
                                                                                AND [Total] LIKE '%{7}%'", txtSerieCredito.Text.ToUpper().Trim()
                                                                                , txtReferenciaCredito.Text.Trim()
                                                                                , txtFelCredito.Text.Trim()
                                                                                , txtClienteCredito.Text.ToUpper().Trim()
                                                                                , txtConvenioCredito.Text.Trim()
                                                                                , txtSerieOrgCredito.Text.ToUpper().Trim()
                                                                                , txtNoOrgCredito.Text.Trim()
                                                                                , txtMontoCredito.Text.Trim());
                dataGridDetalleCreditos.DataSource = dt;
            }
            else
            {
                error.SetError(txtMontoCredito, "No hay datos para filtrar");
            }
            
        }

        private async void btnGenerarCreditos_Click(object sender, EventArgs e)
        {
            reload.Visible = true;
           await getVentasCredito();
            reload.Visible = false;
        }

        private void exportReporteCreditos(DataGridView dataGridView)
        {
            Microsoft.Office.Interop.Excel.Application exportExcel = new Microsoft.Office.Interop.Excel.Application();

            exportExcel.Application.Workbooks.Add(true);

            int indexColumn = 0;
            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                indexColumn++;
                exportExcel.Cells[1, indexColumn] = column.Name;
            }

            int indexFila = 0;
            foreach (DataGridViewRow fila in dataGridView.Rows)
            {
                indexFila++;
                indexColumn = 0;

                foreach (DataGridViewColumn column in dataGridView.Columns)
                {

                    indexColumn++;
                    exportExcel.Cells[indexFila + 1, indexColumn] = fila.Cells[column.Name].Value;
                }
            }
            exportExcel.Visible = true;
        }

        ErrorProvider error = new ErrorProvider();
        private async void btnExportarCreditos_Click(object sender, EventArgs e)
        {
            if(dataGridDetalleCreditos.Rows.Count != 0)
            {
                exportReload.Visible = true;
                error.Clear();
                await Task.Delay(5000);
                exportReporteCreditos(dataGridDetalleCreditos);
                exportReload.Visible = false;
            }
            else
            {
                error.SetError(btnExportarCreditos, "Genere Reporte");
            }
            
        }
    }
}
