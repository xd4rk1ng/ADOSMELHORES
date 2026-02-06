namespace ADOSMELHORES.Forms
{
    partial class FormInicialWIP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInicialWIP));
            this.controlPanel = new System.Windows.Forms.Panel();
            this.pictureLogo = new System.Windows.Forms.PictureBox();
            this.button7 = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnSimData = new System.Windows.Forms.Button();
            this.btnGerir = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.controlPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.button7);
            this.controlPanel.Controls.Add(this.btnStats);
            this.controlPanel.Controls.Add(this.btnGerir);
            this.controlPanel.Controls.Add(this.btnSimData);
            this.controlPanel.Controls.Add(this.btnInicio);
            this.controlPanel.Controls.Add(this.pictureLogo);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(142, 570);
            this.controlPanel.TabIndex = 0;
            // 
            // pictureLogo
            // 
            this.pictureLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureLogo.Image = global::ADOSMELHORES.Properties.Resources.color_circle_icon_layout;
            this.pictureLogo.InitialImage = global::ADOSMELHORES.Properties.Resources.a_dos_melhores_high_resolution_logo_small;
            this.pictureLogo.Location = new System.Drawing.Point(0, 0);
            this.pictureLogo.Name = "pictureLogo";
            this.pictureLogo.Size = new System.Drawing.Size(142, 137);
            this.pictureLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureLogo.TabIndex = 7;
            this.pictureLogo.TabStop = false;
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button7.Location = new System.Drawing.Point(0, 493);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(142, 77);
            this.button7.TabIndex = 6;
            this.button7.Text = "Logout";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // btnStats
            // 
            this.btnStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStats.Location = new System.Drawing.Point(0, 404);
            this.btnStats.Margin = new System.Windows.Forms.Padding(5);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(142, 89);
            this.btnStats.TabIndex = 3;
            this.btnStats.Text = "Despesas";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // btnSimData
            // 
            this.btnSimData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSimData.Location = new System.Drawing.Point(0, 226);
            this.btnSimData.Margin = new System.Windows.Forms.Padding(5);
            this.btnSimData.Name = "btnSimData";
            this.btnSimData.Size = new System.Drawing.Size(142, 89);
            this.btnSimData.TabIndex = 2;
            this.btnSimData.Text = "Simulador de Data";
            this.btnSimData.UseVisualStyleBackColor = true;
            this.btnSimData.Click += new System.EventHandler(this.btnSimData_Click);
            // 
            // btnGerir
            // 
            this.btnGerir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGerir.Location = new System.Drawing.Point(0, 315);
            this.btnGerir.Margin = new System.Windows.Forms.Padding(5);
            this.btnGerir.Name = "btnGerir";
            this.btnGerir.Size = new System.Drawing.Size(142, 89);
            this.btnGerir.TabIndex = 1;
            this.btnGerir.Text = "Gerir";
            this.btnGerir.UseVisualStyleBackColor = true;
            this.btnGerir.Click += new System.EventHandler(this.btnGerir_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.Location = new System.Drawing.Point(0, 137);
            this.btnInicio.Margin = new System.Windows.Forms.Padding(5);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(142, 89);
            this.btnInicio.TabIndex = 0;
            this.btnInicio.Text = "Vista Geral";
            this.btnInicio.UseVisualStyleBackColor = true;
            this.btnInicio.Click += new System.EventHandler(this.btnVistaGeral_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(143, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(778, 570);
            this.panel1.TabIndex = 1;
            // 
            // FormInicialWIP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(918, 570);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.controlPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormInicialWIP";
            this.Text = "FormInicialWIP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInicialWIP_FormClosing);
            this.controlPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLogo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnSimData;
        private System.Windows.Forms.Button btnGerir;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureLogo;
    }
}