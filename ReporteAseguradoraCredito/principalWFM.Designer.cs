namespace ReporteAseguradoraCredito
{
    partial class principalWFM
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(principalWFM));
            this.bunifuGradientPanel1 = new Bunifu.UI.WinForms.BunifuGradientPanel();
            this.btnCreditos = new FontAwesome.Sharp.IconButton();
            this.btnSeguros = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.bunifuGradientPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // bunifuGradientPanel1
            // 
            this.bunifuGradientPanel1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuGradientPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuGradientPanel1.BackgroundImage")));
            this.bunifuGradientPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuGradientPanel1.BorderRadius = 1;
            this.bunifuGradientPanel1.Controls.Add(this.btnCreditos);
            this.bunifuGradientPanel1.Controls.Add(this.btnSeguros);
            this.bunifuGradientPanel1.Controls.Add(this.pictureBox1);
            this.bunifuGradientPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.bunifuGradientPanel1.GradientBottomLeft = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(0)))), ((int)(((byte)(168)))));
            this.bunifuGradientPanel1.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(1)))), ((int)(((byte)(54)))));
            this.bunifuGradientPanel1.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(7)))), ((int)(((byte)(1)))), ((int)(((byte)(54)))));
            this.bunifuGradientPanel1.GradientTopRight = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(0)))), ((int)(((byte)(168)))));
            this.bunifuGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.bunifuGradientPanel1.Name = "bunifuGradientPanel1";
            this.bunifuGradientPanel1.Quality = 10;
            this.bunifuGradientPanel1.Size = new System.Drawing.Size(227, 633);
            this.bunifuGradientPanel1.TabIndex = 0;
            // 
            // btnCreditos
            // 
            this.btnCreditos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreditos.FlatAppearance.BorderSize = 0;
            this.btnCreditos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnCreditos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnCreditos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreditos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditos.ForeColor = System.Drawing.SystemColors.Window;
            this.btnCreditos.Icon = FontAwesome.Sharp.IconChar.CreditCardAlt;
            this.btnCreditos.IconColor = System.Drawing.Color.White;
            this.btnCreditos.IconSize = 32;
            this.btnCreditos.Image = ((System.Drawing.Image)(resources.GetObject("btnCreditos.Image")));
            this.btnCreditos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreditos.Location = new System.Drawing.Point(0, 184);
            this.btnCreditos.Name = "btnCreditos";
            this.btnCreditos.Size = new System.Drawing.Size(227, 37);
            this.btnCreditos.TabIndex = 3;
            this.btnCreditos.Text = "CREDITOS";
            this.btnCreditos.UseVisualStyleBackColor = true;
            // 
            // btnSeguros
            // 
            this.btnSeguros.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeguros.FlatAppearance.BorderSize = 0;
            this.btnSeguros.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.btnSeguros.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btnSeguros.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeguros.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeguros.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSeguros.Icon = FontAwesome.Sharp.IconChar.HospitalO;
            this.btnSeguros.IconColor = System.Drawing.Color.White;
            this.btnSeguros.IconSize = 32;
            this.btnSeguros.Image = ((System.Drawing.Image)(resources.GetObject("btnSeguros.Image")));
            this.btnSeguros.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeguros.Location = new System.Drawing.Point(0, 141);
            this.btnSeguros.Name = "btnSeguros";
            this.btnSeguros.Size = new System.Drawing.Size(227, 37);
            this.btnSeguros.TabIndex = 2;
            this.btnSeguros.Text = "SEGUROS";
            this.btnSeguros.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(42, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(133, 78);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // principalWFM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1336, 633);
            this.Controls.Add(this.bunifuGradientPanel1);
            this.Name = "principalWFM";
            this.Text = "Reportes";
            this.bunifuGradientPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.UI.WinForms.BunifuGradientPanel bunifuGradientPanel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton btnSeguros;
        private FontAwesome.Sharp.IconButton btnCreditos;
    }
}

