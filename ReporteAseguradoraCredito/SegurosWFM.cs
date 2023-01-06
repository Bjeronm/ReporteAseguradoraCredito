using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string conn = ConfigurationManager.ConnectionStrings["reportes"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conn);

            if (sqlCon.State == ConnectionState.Closed)
                sqlCon.Open();

            SqlCommand datareader = new SqlCommand("", sqlCon);
            SqlDataReader data = datareader.ExecuteReader();
            dataGridDetalleSeguro.DataSource = data;
            
        }
    }
}
