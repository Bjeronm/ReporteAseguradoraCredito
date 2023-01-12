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
        
        private void getVentasCredito()
        {
            dt = new DataTable();

            var fechaInicio = fechaIniCreditos.Value.Date.ToString("yyyyMMdd");
            var fechaFinal = fechaFinCreditos.Value.Date.ToString("yyyyMMdd");

            Creditos creditos = new Creditos();
            DataSet data = creditos.getVentasCredito("USP_CAC_GET_VENTAS_CREDITOS", fechaInicio, fechaFinal);

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

        private void iconButton1_Click(object sender, EventArgs e)
        {
            getVentasCredito();
        }

        private void txtSerieCredito_TextChanged(object sender, EventArgs e)
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

        private void txtReferenciaCredito_TextChanged(object sender, EventArgs e)
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

        private void txtFelCredito_TextChanged(object sender, EventArgs e)
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

        private void txtClienteCredito_TextChanged(object sender, EventArgs e)
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

        private void txtConvenioCredito_TextChanged(object sender, EventArgs e)
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

        private void txtSerieOrgCredito_TextChanged(object sender, EventArgs e)
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

        private void txtNoOrgCredito_TextChanged(object sender, EventArgs e)
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

        private void txtMontoCredito_TextChanged(object sender, EventArgs e)
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
    }
}
