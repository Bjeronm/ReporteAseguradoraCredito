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

        Datos.Seguros verificar = new Datos.Seguros();
        public SegurosWFM()
        {
            InitializeComponent();
        }

        private DataTable obtenerDatos()
        {
            DataTable devolver = new DataTable();
            DataTable dt = verificar.searchSeguros();
        }

        private void btnPrueba_Click(object sender, EventArgs e)
        {
            obtenerDatos();
        }
    }
}
