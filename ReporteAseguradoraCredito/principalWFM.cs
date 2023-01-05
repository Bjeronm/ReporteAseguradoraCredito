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
    public partial class principalWFM : Form
    {
        public principalWFM()
        {
            InitializeComponent();
        }

        private void openSegurosForm(object formSeguros)
        {
            if (this.panelMain.Controls.Count > 0)
                this.panelMain.Controls.RemoveAt(0);
            Form seguros = formSeguros as Form;
            seguros.TopLevel = false;
            seguros.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(seguros);
            this.panelMain.Tag = seguros;
            seguros.Show();
        }

        private void openCreditosForm(object formCreditos)
        {
            if (this.panelMain.Controls.Count > 0)
                this.panelMain.Controls.RemoveAt(0);
            Form creditos = formCreditos as Form;
            creditos.TopLevel = false;
            creditos.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(creditos);
            this.panelMain.Tag = creditos;
            creditos.Show();
        }

        private void btnSeguros_Click(object sender, EventArgs e)
        {
            openSegurosForm(new SegurosWFM());
        }

        private void btnCreditos_Click(object sender, EventArgs e)
        {
            openCreditosForm(new CreditosWFM());
        }

        private void bunifuGradientPanel1_Click(object sender, EventArgs e)
        {

        }

        int lx, ly;
        int sw, sh;

        public void pantallaCompleta()
        {
            lx = this.Location.X;
            ly = this.Location.Y;
            sw = this.Size.Width;
            sh = this.Size.Height;
            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }

        private void principalWFM_Load(object sender, EventArgs e)
        {
            pantallaCompleta();
        }
    }
}
