namespace ADOSMELHORES.Forms.Controls
{
    partial class ControlSimularData
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Titulo = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblInvalidos = new System.Windows.Forms.Label();
            this.lstInvalidos = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtpDataDefinida = new System.Windows.Forms.DateTimePicker();
            this.lblLabelDespesasFisicas = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lstExpirados = new System.Windows.Forms.ListView();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblExpirados = new System.Windows.Forms.Label();
            this.lblTotalInvalidos = new System.Windows.Forms.Label();
            this.lblTotalExpirados = new System.Windows.Forms.Label();
            this.lblNumTotal = new System.Windows.Forms.Label();
            this.lblNumTotalInvalidos = new System.Windows.Forms.Label();
            this.lblNumTotalExpirados = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.Titulo);
            this.panel1.Location = new System.Drawing.Point(20, 13);
            this.panel1.MaximumSize = new System.Drawing.Size(680, 104);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 94);
            this.panel1.TabIndex = 0;
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo.Location = new System.Drawing.Point(223, 29);
            this.Titulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(226, 32);
            this.Titulo.TabIndex = 1;
            this.Titulo.Text = "Simulação de Data";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblInvalidos);
            this.panel2.Controls.Add(this.lstInvalidos);
            this.panel2.Location = new System.Drawing.Point(20, 203);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(337, 304);
            this.panel2.TabIndex = 1;
            // 
            // lblInvalidos
            // 
            this.lblInvalidos.AutoSize = true;
            this.lblInvalidos.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvalidos.Location = new System.Drawing.Point(2, 9);
            this.lblInvalidos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInvalidos.Name = "lblInvalidos";
            this.lblInvalidos.Size = new System.Drawing.Size(267, 20);
            this.lblInvalidos.TabIndex = 1;
            this.lblInvalidos.Text = "Funcionários com contratos inválidos:";
            // 
            // lstInvalidos
            // 
            this.lstInvalidos.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstInvalidos.HideSelection = false;
            this.lstInvalidos.Location = new System.Drawing.Point(0, 45);
            this.lstInvalidos.Name = "lstInvalidos";
            this.lstInvalidos.Size = new System.Drawing.Size(335, 257);
            this.lstInvalidos.TabIndex = 0;
            this.lstInvalidos.UseCompatibleStateImageBehavior = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnReset);
            this.panel3.Controls.Add(this.dtpDataDefinida);
            this.panel3.Controls.Add(this.lblLabelDespesasFisicas);
            this.panel3.Location = new System.Drawing.Point(363, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(337, 83);
            this.panel3.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(212, 41);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Definir Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnDefinir_click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(109, 41);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(97, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Restaurar Data";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // dtpDataDefinida
            // 
            this.dtpDataDefinida.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataDefinida.Location = new System.Drawing.Point(168, 15);
            this.dtpDataDefinida.Name = "dtpDataDefinida";
            this.dtpDataDefinida.Size = new System.Drawing.Size(141, 20);
            this.dtpDataDefinida.TabIndex = 2;
            // 
            // lblLabelDespesasFisicas
            // 
            this.lblLabelDespesasFisicas.AutoSize = true;
            this.lblLabelDespesasFisicas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelDespesasFisicas.Location = new System.Drawing.Point(16, 15);
            this.lblLabelDespesasFisicas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLabelDespesasFisicas.Name = "lblLabelDespesasFisicas";
            this.lblLabelDespesasFisicas.Size = new System.Drawing.Size(147, 19);
            this.lblLabelDespesasFisicas.TabIndex = 1;
            this.lblLabelDespesasFisicas.Text = "🕰️ Data definida para:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.lblExpirados);
            this.panel4.Controls.Add(this.lstExpirados);
            this.panel4.Location = new System.Drawing.Point(363, 202);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(337, 305);
            this.panel4.TabIndex = 5;
            // 
            // lstExpirados
            // 
            this.lstExpirados.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstExpirados.HideSelection = false;
            this.lstExpirados.Location = new System.Drawing.Point(0, 46);
            this.lstExpirados.Name = "lstExpirados";
            this.lstExpirados.Size = new System.Drawing.Size(335, 257);
            this.lstExpirados.TabIndex = 2;
            this.lstExpirados.UseCompatibleStateImageBehavior = false;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.lblNumTotalExpirados);
            this.panel5.Controls.Add(this.lblNumTotalInvalidos);
            this.panel5.Controls.Add(this.lblNumTotal);
            this.panel5.Controls.Add(this.lblTotalExpirados);
            this.panel5.Controls.Add(this.lblTotalInvalidos);
            this.panel5.Controls.Add(this.lblTotal);
            this.panel5.Location = new System.Drawing.Point(21, 113);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(336, 83);
            this.panel5.TabIndex = 5;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(16, 15);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(155, 20);
            this.lblTotal.TabIndex = 1;
            this.lblTotal.Text = "Total de invalidações:";
            // 
            // lblExpirados
            // 
            this.lblExpirados.AutoSize = true;
            this.lblExpirados.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirados.Location = new System.Drawing.Point(2, 10);
            this.lblExpirados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExpirados.Name = "lblExpirados";
            this.lblExpirados.Size = new System.Drawing.Size(327, 20);
            this.lblExpirados.TabIndex = 2;
            this.lblExpirados.Text = "Funcionários com registos criminais expirados:";
            // 
            // lblTotalInvalidos
            // 
            this.lblTotalInvalidos.AutoSize = true;
            this.lblTotalInvalidos.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalInvalidos.Location = new System.Drawing.Point(16, 34);
            this.lblTotalInvalidos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalInvalidos.Name = "lblTotalInvalidos";
            this.lblTotalInvalidos.Size = new System.Drawing.Size(139, 19);
            this.lblTotalInvalidos.TabIndex = 2;
            this.lblTotalInvalidos.Text = "Por contrato inválido:";
            // 
            // lblTotalExpirados
            // 
            this.lblTotalExpirados.AutoSize = true;
            this.lblTotalExpirados.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalExpirados.Location = new System.Drawing.Point(16, 53);
            this.lblTotalExpirados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalExpirados.Name = "lblTotalExpirados";
            this.lblTotalExpirados.Size = new System.Drawing.Size(166, 19);
            this.lblTotalExpirados.TabIndex = 3;
            this.lblTotalExpirados.Text = "Por reg. criminal expirado:";
            // 
            // lblNumTotal
            // 
            this.lblNumTotal.AutoSize = true;
            this.lblNumTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumTotal.Location = new System.Drawing.Point(308, 16);
            this.lblNumTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumTotal.Name = "lblNumTotal";
            this.lblNumTotal.Size = new System.Drawing.Size(17, 20);
            this.lblNumTotal.TabIndex = 4;
            this.lblNumTotal.Text = "0";
            // 
            // lblNumTotalInvalidos
            // 
            this.lblNumTotalInvalidos.AutoSize = true;
            this.lblNumTotalInvalidos.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumTotalInvalidos.Location = new System.Drawing.Point(308, 34);
            this.lblNumTotalInvalidos.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumTotalInvalidos.Name = "lblNumTotalInvalidos";
            this.lblNumTotalInvalidos.Size = new System.Drawing.Size(17, 19);
            this.lblNumTotalInvalidos.TabIndex = 5;
            this.lblNumTotalInvalidos.Text = "0";
            // 
            // lblNumTotalExpirados
            // 
            this.lblNumTotalExpirados.AutoSize = true;
            this.lblNumTotalExpirados.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumTotalExpirados.Location = new System.Drawing.Point(308, 53);
            this.lblNumTotalExpirados.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumTotalExpirados.Name = "lblNumTotalExpirados";
            this.lblNumTotalExpirados.Size = new System.Drawing.Size(17, 19);
            this.lblNumTotalExpirados.TabIndex = 6;
            this.lblNumTotalExpirados.Text = "0";
            // 
            // ControlSimularData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "ControlSimularData";
            this.Size = new System.Drawing.Size(717, 524);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lstInvalidos;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpDataDefinida;
        private System.Windows.Forms.Label lblLabelDespesasFisicas;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblInvalidos;
        private System.Windows.Forms.ListView lstExpirados;
        private System.Windows.Forms.Label lblExpirados;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lblTotalExpirados;
        private System.Windows.Forms.Label lblTotalInvalidos;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblNumTotalExpirados;
        private System.Windows.Forms.Label lblNumTotalInvalidos;
        private System.Windows.Forms.Label lblNumTotal;
    }
}
