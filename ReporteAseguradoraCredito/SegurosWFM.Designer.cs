namespace ReporteAseguradoraCredito
{
    partial class SegurosWFM
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SegurosWFM));
            this.segurosPanelHeader = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.panelSegurosBody = new System.Windows.Forms.Panel();
            this.bunifuDatePicker1 = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.segurosPanelRight = new System.Windows.Forms.Panel();
            this.rjTextBox1 = new ReporteAseguradoraCredito.Controls.RJTextBox();
            this.segurosPanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // segurosPanelHeader
            // 
            this.segurosPanelHeader.BackColor = System.Drawing.Color.Transparent;
            this.segurosPanelHeader.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("segurosPanelHeader.BackgroundImage")));
            this.segurosPanelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.segurosPanelHeader.BorderRadius = 1;
            this.segurosPanelHeader.Controls.Add(this.rjTextBox1);
            this.segurosPanelHeader.Controls.Add(this.bunifuDatePicker1);
            this.segurosPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.segurosPanelHeader.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.segurosPanelHeader.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(28)))));
            this.segurosPanelHeader.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(47)))), ((int)(((byte)(47)))));
            this.segurosPanelHeader.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(242)))), ((int)(((byte)(28)))));
            this.segurosPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.segurosPanelHeader.Name = "segurosPanelHeader";
            this.segurosPanelHeader.Quality = 10;
            this.segurosPanelHeader.Size = new System.Drawing.Size(1086, 144);
            this.segurosPanelHeader.TabIndex = 0;
            // 
            // panelSegurosBody
            // 
            this.panelSegurosBody.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSegurosBody.Location = new System.Drawing.Point(0, 144);
            this.panelSegurosBody.Name = "panelSegurosBody";
            this.panelSegurosBody.Size = new System.Drawing.Size(801, 466);
            this.panelSegurosBody.TabIndex = 1;
            this.panelSegurosBody.Paint += new System.Windows.Forms.PaintEventHandler(this.panelSegurosBody_Paint);
            // 
            // bunifuDatePicker1
            // 
            this.bunifuDatePicker1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDatePicker1.BorderColor = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.BorderRadius = 1;
            this.bunifuDatePicker1.Color = System.Drawing.Color.Silver;
            this.bunifuDatePicker1.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.bunifuDatePicker1.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuDatePicker1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.DisplayWeekNumbers = false;
            this.bunifuDatePicker1.DPHeight = 0;
            this.bunifuDatePicker1.FillDatePicker = false;
            this.bunifuDatePicker1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDatePicker1.ForeColor = System.Drawing.Color.White;
            this.bunifuDatePicker1.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuDatePicker1.Icon")));
            this.bunifuDatePicker1.IconColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuDatePicker1.LeftTextMargin = 5;
            this.bunifuDatePicker1.Location = new System.Drawing.Point(12, 42);
            this.bunifuDatePicker1.MinimumSize = new System.Drawing.Size(0, 32);
            this.bunifuDatePicker1.Name = "bunifuDatePicker1";
            this.bunifuDatePicker1.Size = new System.Drawing.Size(220, 32);
            this.bunifuDatePicker1.TabIndex = 0;
            // 
            // segurosPanelRight
            // 
            this.segurosPanelRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.segurosPanelRight.Location = new System.Drawing.Point(807, 144);
            this.segurosPanelRight.Name = "segurosPanelRight";
            this.segurosPanelRight.Size = new System.Drawing.Size(279, 466);
            this.segurosPanelRight.TabIndex = 2;
            // 
            // rjTextBox1
            // 
            this.rjTextBox1.BackColor = System.Drawing.Color.White;
            this.rjTextBox1.BorderColor = System.Drawing.Color.MediumSlateBlue;
            this.rjTextBox1.BorderFocusColor = System.Drawing.Color.HotPink;
            this.rjTextBox1.BorderRadius = 15;
            this.rjTextBox1.BorderSize = 2;
            this.rjTextBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rjTextBox1.Location = new System.Drawing.Point(285, 39);
            this.rjTextBox1.Multiline = false;
            this.rjTextBox1.Name = "rjTextBox1";
            this.rjTextBox1.Padding = new System.Windows.Forms.Padding(10, 7, 10, 10);
            this.rjTextBox1.PasswordChar = false;
            this.rjTextBox1.PlaceholderColor = System.Drawing.Color.DarkGray;
            this.rjTextBox1.PlaceholderText = "Ingrese Nit";
            this.rjTextBox1.Size = new System.Drawing.Size(250, 35);
            this.rjTextBox1.TabIndex = 1;
            this.rjTextBox1.Texts = "";
            this.rjTextBox1.UnderlinedStyle = false;
            // 
            // SegurosWFM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 610);
            this.Controls.Add(this.segurosPanelRight);
            this.Controls.Add(this.panelSegurosBody);
            this.Controls.Add(this.segurosPanelHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SegurosWFM";
            this.Text = "SegurosWFM";
            this.segurosPanelHeader.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuGradientPanel segurosPanelHeader;
        private System.Windows.Forms.Panel panelSegurosBody;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuDatePicker1;
        private System.Windows.Forms.Panel segurosPanelRight;
        private Controls.RJTextBox rjTextBox1;
    }
}