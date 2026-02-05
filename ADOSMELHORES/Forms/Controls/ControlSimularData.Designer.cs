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
            this.label2 = new System.Windows.Forms.Label();
            this.lstFuncionarios = new System.Windows.Forms.ListView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.dtpDataDefinida = new System.Windows.Forms.DateTimePicker();
            this.lblLabelDespesasFisicas = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lblExpirados1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblExpirados2 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblNumTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
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
            this.Titulo.Location = new System.Drawing.Point(255, 31);
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
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lstFuncionarios);
            this.panel2.Location = new System.Drawing.Point(20, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(353, 394);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(2, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Funcionários com contratos inválidos:";
            // 
            // lstFuncionarios
            // 
            this.lstFuncionarios.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lstFuncionarios.HideSelection = false;
            this.lstFuncionarios.Location = new System.Drawing.Point(0, 39);
            this.lstFuncionarios.Name = "lstFuncionarios";
            this.lstFuncionarios.Size = new System.Drawing.Size(351, 353);
            this.lstFuncionarios.TabIndex = 0;
            this.lstFuncionarios.UseCompatibleStateImageBehavior = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.btnReset);
            this.panel3.Controls.Add(this.dtpDataDefinida);
            this.panel3.Controls.Add(this.lblLabelDespesasFisicas);
            this.panel3.Location = new System.Drawing.Point(379, 113);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(321, 83);
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
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.lblNumTotal);
            this.panel4.Controls.Add(this.lblTotal);
            this.panel4.Controls.Add(this.lblExpirados2);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.lblExpirados1);
            this.panel4.Location = new System.Drawing.Point(379, 202);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(321, 305);
            this.panel4.TabIndex = 5;
            // 
            // lblExpirados1
            // 
            this.lblExpirados1.AutoSize = true;
            this.lblExpirados1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirados1.Location = new System.Drawing.Point(149, 129);
            this.lblExpirados1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExpirados1.Name = "lblExpirados1";
            this.lblExpirados1.Size = new System.Drawing.Size(130, 19);
            this.lblExpirados1.TabIndex = 9;
            this.lblExpirados1.Text = "Contrato expirado -";
            this.lblExpirados1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(89, 97);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(190, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Contratos invalidados por:";
            // 
            // lblExpirados2
            // 
            this.lblExpirados2.AutoSize = true;
            this.lblExpirados2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpirados2.Location = new System.Drawing.Point(105, 161);
            this.lblExpirados2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExpirados2.Name = "lblExpirados2";
            this.lblExpirados2.Size = new System.Drawing.Size(174, 19);
            this.lblExpirados2.TabIndex = 10;
            this.lblExpirados2.Text = "Registo Criminal expirado -";
            this.lblExpirados2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(246, 193);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(42, 20);
            this.lblTotal.TabIndex = 13;
            this.lblTotal.Text = "Total";
            // 
            // lblNumTotal
            // 
            this.lblNumTotal.AutoSize = true;
            this.lblNumTotal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumTotal.Location = new System.Drawing.Point(271, 222);
            this.lblNumTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNumTotal.Name = "lblNumTotal";
            this.lblNumTotal.Size = new System.Drawing.Size(17, 19);
            this.lblNumTotal.TabIndex = 14;
            this.lblNumTotal.Text = "0";
            this.lblNumTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(45, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 28);
            this.label1.TabIndex = 19;
            this.label1.Text = "Estatísticas";
            // 
            // ControlSimularData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lstFuncionarios;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpDataDefinida;
        private System.Windows.Forms.Label lblLabelDespesasFisicas;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblExpirados2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblExpirados1;
        private System.Windows.Forms.Label lblNumTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label label1;
    }
}
