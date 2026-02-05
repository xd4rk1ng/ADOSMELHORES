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
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnStats = new System.Windows.Forms.Button();
            this.btnSimData = new System.Windows.Forms.Button();
            this.btnGerir = new System.Windows.Forms.Button();
            this.btnInicio = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.controlPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // controlPanel
            // 
            this.controlPanel.Controls.Add(this.button7);
            this.controlPanel.Controls.Add(this.button6);
            this.controlPanel.Controls.Add(this.button5);
            this.controlPanel.Controls.Add(this.btnStats);
            this.controlPanel.Controls.Add(this.btnSimData);
            this.controlPanel.Controls.Add(this.btnGerir);
            this.controlPanel.Controls.Add(this.btnInicio);
            this.controlPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.controlPanel.Location = new System.Drawing.Point(0, 0);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(143, 570);
            this.controlPanel.TabIndex = 0;
            // 
            // button7
            // 
            this.button7.Dock = System.Windows.Forms.DockStyle.Top;
            this.button7.Location = new System.Drawing.Point(0, 359);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(143, 58);
            this.button7.TabIndex = 6;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            this.button6.Dock = System.Windows.Forms.DockStyle.Top;
            this.button6.Location = new System.Drawing.Point(0, 290);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(143, 69);
            this.button6.TabIndex = 5;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Dock = System.Windows.Forms.DockStyle.Top;
            this.button5.Location = new System.Drawing.Point(0, 232);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(143, 58);
            this.button5.TabIndex = 4;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // btnStats
            // 
            this.btnStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStats.Location = new System.Drawing.Point(0, 174);
            this.btnStats.Name = "btnStats";
            this.btnStats.Size = new System.Drawing.Size(143, 58);
            this.btnStats.TabIndex = 3;
            this.btnStats.Text = "Despesas";
            this.btnStats.UseVisualStyleBackColor = true;
            this.btnStats.Click += new System.EventHandler(this.btnStats_Click);
            // 
            // btnSimData
            // 
            this.btnSimData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSimData.Location = new System.Drawing.Point(0, 116);
            this.btnSimData.Name = "btnSimData";
            this.btnSimData.Size = new System.Drawing.Size(143, 58);
            this.btnSimData.TabIndex = 2;
            this.btnSimData.Text = "Simulador de Data";
            this.btnSimData.UseVisualStyleBackColor = true;
            this.btnSimData.Click += new System.EventHandler(this.btnSimData_Click);
            // 
            // btnGerir
            // 
            this.btnGerir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGerir.Location = new System.Drawing.Point(0, 58);
            this.btnGerir.Name = "btnGerir";
            this.btnGerir.Size = new System.Drawing.Size(143, 58);
            this.btnGerir.TabIndex = 1;
            this.btnGerir.Text = "Gerir";
            this.btnGerir.UseVisualStyleBackColor = true;
            this.btnGerir.Click += new System.EventHandler(this.btnGerir_Click);
            // 
            // btnInicio
            // 
            this.btnInicio.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInicio.Location = new System.Drawing.Point(0, 0);
            this.btnInicio.Name = "btnInicio";
            this.btnInicio.Size = new System.Drawing.Size(143, 58);
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
            this.controlPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnStats;
        private System.Windows.Forms.Button btnSimData;
        private System.Windows.Forms.Button btnGerir;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Panel panel1;
    }
}