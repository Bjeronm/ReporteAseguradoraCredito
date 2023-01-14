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
        DataTable dt = new DataTable();
        public List<SegurosViewModel> dataSeguros { get; set; }

        public SegurosWFM()
        {
            InitializeComponent();
        }
        
        private async Task getVentasAseguradoras()
        {
            dt = new DataTable();

            //datagrid detalle seguros
            var fechaI = fechaIniSeguro.Value.Date.ToString("yyyyMMdd");
            var fechaF = fechaFinSeguros.Value.Date.ToString("yyyyMMdd");
            var nitAseguradora = txtNitAseguradora.Texts.Trim();
            Seguros seguros = new Seguros();
            DataSet data = await seguros.getSeguros("USP_CAC_GET_VENTAS_ASEGURADORAS",fechaI,fechaF,nitAseguradora);
            dt = data.Tables[0];
            var tablaSeguros = data.Tables[0];
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
            
            dataSeguros = new List<SegurosViewModel>();

            foreach (DataRow rows in tablaSeguros.Rows)
            {
                var segurosModel = new SegurosViewModel()
                {
                    Fecha = Convert.ToString(rows[0]),
                    Sucursal = Convert.ToString(rows[1]),
                    Serie = Convert.ToString(rows[2]),
                    Numero = Convert.ToString(rows[3]),
                    SerieOrigen = Convert.ToString(rows[4]),
                    NumeroOrigen = Convert.ToString(rows[5]),
                    SerieFel = Convert.ToString(rows[6]),
                    NumeroFel = Convert.ToString(rows[7]),
                    RequestId = Convert.ToString(rows[8]),
                    Convenio = Convert.ToString(rows[9]),
                    Autorizacion = Convert.ToString(rows[10]),
                    TipoDocumentoAs = Convert.ToString(rows[11]),
                    NombreA = Convert.ToString(rows[12]),
                    NitA = Convert.ToString(rows[13]),
                    CanalVenta = Convert.ToString(rows[14]),
                    TotalA = Convert.ToDecimal(rows[15]),
                    SerieB = Convert.ToString(rows[16]),
                    NumeroB = Convert.ToString(rows[17]),
                    SerieOrigenB = Convert.ToString(rows[18]),
                    NumeroOrigenB = Convert.ToString(rows[19]),
                    SerieFelB = Convert.ToString(rows[20]),
                    NumeroFelB = Convert.ToString(rows[21]),
                    RequestIdB = Convert.ToString(rows[22]),
                    NombreB = Convert.ToString(rows[23]),
                    NitB = Convert.ToString(rows[24]),
                    TotalB = Convert.ToDecimal(rows[25]),
                    Estado = Convert.ToInt32(rows[26])
                };

                dataSeguros.Add(segurosModel);
            }
            

        }
        

        private void txtSerieSeguro_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleSeguro.Rows.Count > 0)
            {
                error.Clear();
                dt.DefaultView.RowFilter = string.Format(@"[Serie Aseguradora] LIKE '%{0}%' AND [Numero Aseguradora] LIKE '%{1}%' 
                                                                                AND [Numero Fel Asegu] LIKE '%{2}%'
                                                                                AND [Nombre Cliente] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen Asegu] LIKE '%{5}%'
                                                                                AND [Numero Origen Asegu] LIKE '%{6}%'
                                                                                AND [Total Aseguradora] LIKE '%{7}%'", txtSerieSeguro.Text.ToUpper().Trim()
                                                                                , txtReferenciaSeguro.Text.Trim()
                                                                                , txtNoFelSeguros.Text.Trim()
                                                                                , txtClienteSeguros.Text.ToUpper().Trim()
                                                                                , txtConvenioSeguro.Text.Trim()
                                                                                , txtSerieOrgSeguro.Text.ToUpper().Trim()
                                                                                , txtNoOrgSeguro.Text.Trim()
                                                                                , txtMontoSeguro.Text.Trim());
                dataGridDetalleSeguro.DataSource = dt;
            }
            else
            {
                error.SetError(txtSerieSeguro, "No hay Datos para filtrar");
            }
            
        }

        private void txtReferenciaSeguro_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleSeguro.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie Aseguradora] LIKE '%{0}%' AND [Numero Aseguradora] LIKE '%{1}%' 
                                                                                AND [Numero Fel Asegu] LIKE '%{2}%'
                                                                                AND [Nombre Cliente] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen Asegu] LIKE '%{5}%'
                                                                                AND [Numero Origen Asegu] LIKE '%{6}%'
                                                                                AND [Total Aseguradora] LIKE '%{7}%'", txtSerieSeguro.Text.ToUpper().Trim()
                                                                                , txtReferenciaSeguro.Text.Trim()
                                                                                , txtNoFelSeguros.Text.Trim()
                                                                                , txtClienteSeguros.Text.ToUpper().Trim()
                                                                                , txtConvenioSeguro.Text.Trim()
                                                                                , txtSerieOrgSeguro.Text.ToUpper().Trim()
                                                                                , txtNoOrgSeguro.Text.Trim()
                                                                                , txtMontoSeguro.Text.Trim());
                dataGridDetalleSeguro.DataSource = dt;
            }
            else
            {
                error.SetError(txtReferenciaSeguro, "No hay datos para filtrar");
            }
            
        }

        private void txtClienteSeguros_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleSeguro.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie Aseguradora] LIKE '%{0}%' AND [Numero Aseguradora] LIKE '%{1}%' 
                                                                                AND [Numero Fel Asegu] LIKE '%{2}%'
                                                                                AND [Nombre Cliente] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen Asegu] LIKE '%{5}%'
                                                                                AND [Numero Origen Asegu] LIKE '%{6}%'
                                                                                AND [Total Aseguradora] LIKE '%{7}%'", txtSerieSeguro.Text.ToUpper().Trim()
                                                                                , txtReferenciaSeguro.Text.Trim()
                                                                                , txtNoFelSeguros.Text.Trim()
                                                                                , txtClienteSeguros.Text.ToUpper().Trim()
                                                                                , txtConvenioSeguro.Text.Trim()
                                                                                , txtSerieOrgSeguro.Text.ToUpper().Trim()
                                                                                , txtNoOrgSeguro.Text.Trim()
                                                                                , txtMontoSeguro.Text.Trim());
                dataGridDetalleSeguro.DataSource = dt;
            }
            else
            {
                error.SetError(txtClienteSeguros, "No hay datos para filtrar");
            }
            
        }

        private void txtNoFelSeguros_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleSeguro.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie Aseguradora] LIKE '%{0}%' AND [Numero Aseguradora] LIKE '%{1}%' 
                                                                                AND [Numero Fel Asegu] LIKE '%{2}%'
                                                                                AND [Nombre Cliente] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen Asegu] LIKE '%{5}%'
                                                                                AND [Numero Origen Asegu] LIKE '%{6}%'
                                                                                AND [Total Aseguradora] LIKE '%{7}%'", txtSerieSeguro.Text.ToUpper().Trim()
                                                                                , txtReferenciaSeguro.Text.Trim()
                                                                                , txtNoFelSeguros.Text.Trim()
                                                                                , txtClienteSeguros.Text.ToUpper().Trim()
                                                                                , txtConvenioSeguro.Text.Trim()
                                                                                , txtSerieOrgSeguro.Text.ToUpper().Trim()
                                                                                , txtNoOrgSeguro.Text.Trim()
                                                                                , txtMontoSeguro.Text.Trim());
                dataGridDetalleSeguro.DataSource = dt;
            }
            else
            {
                error.SetError(txtNoFelSeguros, "No hay datos para filtrar");
            }
            
        }

        private void txtConvenioSeguro_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleSeguro.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie Aseguradora] LIKE '%{0}%' AND [Numero Aseguradora] LIKE '%{1}%' 
                                                                                AND [Numero Fel Asegu] LIKE '%{2}%'
                                                                                AND [Nombre Cliente] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen Asegu] LIKE '%{5}%'
                                                                                AND [Numero Origen Asegu] LIKE '%{6}%'
                                                                                AND [Total Aseguradora] LIKE '%{7}%'", txtSerieSeguro.Text.ToUpper().Trim()
                                                                                , txtReferenciaSeguro.Text.Trim()
                                                                                , txtNoFelSeguros.Text.Trim()
                                                                                , txtClienteSeguros.Text.ToUpper().Trim()
                                                                                , txtConvenioSeguro.Text.Trim()
                                                                                , txtSerieOrgSeguro.Text.ToUpper().Trim()
                                                                                , txtNoOrgSeguro.Text.Trim()
                                                                                , txtMontoSeguro.Text.Trim());
                dataGridDetalleSeguro.DataSource = dt;
            }
            else
            {
                error.SetError(txtConvenioSeguro, "No hay datos para filtar");
            }
            
        }

        private void txtSerieOrgSeguro_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleSeguro.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie Aseguradora] LIKE '%{0}%' AND [Numero Aseguradora] LIKE '%{1}%' 
                                                                                AND [Numero Fel Asegu] LIKE '%{2}%'
                                                                                AND [Nombre Cliente] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen Asegu] LIKE '%{5}%'
                                                                                AND [Numero Origen Asegu] LIKE '%{6}%'
                                                                                AND [Total Aseguradora] LIKE '%{7}%'", txtSerieSeguro.Text.ToUpper().Trim()
                                                                                , txtReferenciaSeguro.Text.Trim()
                                                                                , txtNoFelSeguros.Text.Trim()
                                                                                , txtClienteSeguros.Text.ToUpper().Trim()
                                                                                , txtConvenioSeguro.Text.Trim()
                                                                                , txtSerieOrgSeguro.Text.ToUpper().Trim()
                                                                                , txtNoOrgSeguro.Text.Trim()
                                                                                , txtMontoSeguro.Text.Trim());
                dataGridDetalleSeguro.DataSource = dt;
            }
            else
            {
                error.SetError(txtSerieOrgSeguro, "No hay datos para filtrar");
            }
            
        }

        private void txtNoOrgSeguro_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleSeguro.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie Aseguradora] LIKE '%{0}%' AND [Numero Aseguradora] LIKE '%{1}%' 
                                                                                AND [Numero Fel Asegu] LIKE '%{2}%'
                                                                                AND [Nombre Cliente] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen Asegu] LIKE '%{5}%'
                                                                                AND [Numero Origen Asegu] LIKE '%{6}%'
                                                                                AND [Total Aseguradora] LIKE '%{7}%'", txtSerieSeguro.Text.ToUpper().Trim()
                                                                                , txtReferenciaSeguro.Text.Trim()
                                                                                , txtNoFelSeguros.Text.Trim()
                                                                                , txtClienteSeguros.Text.ToUpper().Trim()
                                                                                , txtConvenioSeguro.Text.Trim()
                                                                                , txtSerieOrgSeguro.Text.ToUpper().Trim()
                                                                                , txtNoOrgSeguro.Text.Trim()
                                                                                , txtMontoSeguro.Text.Trim());
                dataGridDetalleSeguro.DataSource = dt;
            }
            else
            {
                error.SetError(txtNoOrgSeguro, "No hay datos para filtrar");
            }
            
        }

        private void txtMontoSeguro_TextChanged(object sender, EventArgs e)
        {
            if(dataGridDetalleSeguro.Rows.Count > 0)
            {
                dt.DefaultView.RowFilter = string.Format(@"[Serie Aseguradora] LIKE '%{0}%' AND [Numero Aseguradora] LIKE '%{1}%' 
                                                                                AND [Numero Fel Asegu] LIKE '%{2}%'
                                                                                AND [Nombre Cliente] LIKE '%{3}%'
                                                                                AND [Convenio] LIKE '%{4}%'
                                                                                AND [Serie Origen Asegu] LIKE '%{5}%'
                                                                                AND [Numero Origen Asegu] LIKE '%{6}%'
                                                                                AND [Total Aseguradora] LIKE '%{7}%'", txtSerieSeguro.Text.ToUpper().Trim()
                                                                                , txtReferenciaSeguro.Text.Trim()
                                                                                , txtNoFelSeguros.Text.Trim()
                                                                                , txtClienteSeguros.Text.ToUpper().Trim()
                                                                                , txtConvenioSeguro.Text.Trim()
                                                                                , txtSerieOrgSeguro.Text.ToUpper().Trim()
                                                                                , txtNoOrgSeguro.Text.Trim()
                                                                                , txtMontoSeguro.Text.Trim());
                dataGridDetalleSeguro.DataSource = dt;
            }
            else
            {
                error.SetError(txtMontoSeguro, "No hay datos para filtar");
            }
            
        }

        ErrorProvider error = new ErrorProvider();
        private async void btnGenerarSeguro_Click(object sender, EventArgs e)
        {
            if(txtNitAseguradora.Texts != "")
            {
                reloadSeguro.Visible = true;
                error.Clear();
                await getVentasAseguradoras();
                reloadSeguro.Visible = false;
            }
            else
            {
                error.SetError(txtNitAseguradora, "Ingrese Nit");
            }
        }

        private void exportReporteSeguros(DataGridView dataGridView)
        {
            Microsoft.Office.Interop.Excel.Application exportExcel = new Microsoft.Office.Interop.Excel.Application();

            exportExcel.Application.Workbooks.Add(true);

            int indexColumn = 0;
            foreach(DataGridViewColumn column in dataGridView.Columns)
            {
                indexColumn++;
                exportExcel.Cells[1, indexColumn] = column.Name;
            }

            int indexFila = 0;
            foreach(DataGridViewRow fila in dataGridView.Rows)
            {
                indexFila++;
                indexColumn = 0;

                foreach(DataGridViewColumn column in dataGridView.Columns)
                {
                   
                    indexColumn++;
                    exportExcel.Cells[indexFila + 1, indexColumn] = fila.Cells[column.Name].Value;
                }
            }
            exportExcel.Visible = true;
        }

        private async void btnExportarSeguro_Click(object sender, EventArgs e)
        {
            if(dataGridDetalleSeguro.Rows.Count != 0)
            {
                exReload.Visible = true;
                error.Clear();
                await timeOut();
                exportReporteSeguros(dataGridDetalleSeguro);
                exReload.Visible = false;
            }
            else
            {
                error.SetError(btnExportarSeguro, "Genere un Reporte");
            }
        }

        private void txtNitAseguradora_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 44) || (e.KeyChar >= 46 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 106) || (e.KeyChar >= 108 && e.KeyChar <= 255))
            {
                error.SetError(txtNitAseguradora, "Ingrese un nit valido");
                btnGenerarSeguro.Enabled = false;
            }
            else
            {
                error.Clear();
                btnGenerarSeguro.Enabled = true;
            }
        }

        public async Task timeOut()
        {
            int time = dataGridDetalleSeguro.Rows.Count;
            for(int i = 0; i < time/2; i++)
            {
                await Task.Delay(i);
            }
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
