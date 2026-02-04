namespace ADOSMELHORES.Controls
{
    partial class ControlFuncionario
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
            this.grpDadosPessoais = new System.Windows.Forms.GroupBox();
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numSalarioBase = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.lblStatusRegistoCriminal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpDataRegistoCriminal = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDataFimContrato = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMorada = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grpDadosPessoais.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioBase)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDadosSecretaria
            // 
            this.grpDadosPessoais.Controls.Add(this.txtNIF);
            this.grpDadosPessoais.Controls.Add(this.label6);
            this.grpDadosPessoais.Controls.Add(this.numSalarioBase);
            this.grpDadosPessoais.Controls.Add(this.label7);
            this.grpDadosPessoais.Controls.Add(this.lblStatusRegistoCriminal);
            this.grpDadosPessoais.Controls.Add(this.label11);
            this.grpDadosPessoais.Controls.Add(this.dtpDataRegistoCriminal);
            this.grpDadosPessoais.Controls.Add(this.label10);
            this.grpDadosPessoais.Controls.Add(this.dtpDataFimContrato);
            this.grpDadosPessoais.Controls.Add(this.label9);
            this.grpDadosPessoais.Controls.Add(this.txtContacto);
            this.grpDadosPessoais.Controls.Add(this.label4);
            this.grpDadosPessoais.Controls.Add(this.txtMorada);
            this.grpDadosPessoais.Controls.Add(this.label3);
            this.grpDadosPessoais.Controls.Add(this.txtNome);
            this.grpDadosPessoais.Controls.Add(this.label2);
            this.grpDadosPessoais.Location = new System.Drawing.Point(3, 3);
            this.grpDadosPessoais.Name = "grpDadosSecretaria";
            this.grpDadosPessoais.Size = new System.Drawing.Size(493, 218);
            this.grpDadosPessoais.TabIndex = 2;
            this.grpDadosPessoais.TabStop = false;
            this.grpDadosPessoais.Text = "Dados da Secretária";
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(138, 43);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(200, 20);
            this.txtNIF.TabIndex = 30;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "NIF:";
            // 
            // numSalarioBase
            // 
            this.numSalarioBase.DecimalPlaces = 2;
            this.numSalarioBase.Location = new System.Drawing.Point(138, 151);
            this.numSalarioBase.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSalarioBase.Name = "numSalarioBase";
            this.numSalarioBase.Size = new System.Drawing.Size(120, 20);
            this.numSalarioBase.TabIndex = 26;
            this.numSalarioBase.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Salário Base:";
            // 
            // lblStatusRegistoCriminal
            // 
            this.lblStatusRegistoCriminal.AutoSize = true;
            this.lblStatusRegistoCriminal.Location = new System.Drawing.Point(150, 390);
            this.lblStatusRegistoCriminal.Name = "lblStatusRegistoCriminal";
            this.lblStatusRegistoCriminal.Size = new System.Drawing.Size(10, 13);
            this.lblStatusRegistoCriminal.TabIndex = 20;
            this.lblStatusRegistoCriminal.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 390);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(118, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Status Registo Criminal:";
            // 
            // dtpDataRegistoCriminal
            // 
            this.dtpDataRegistoCriminal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataRegistoCriminal.Location = new System.Drawing.Point(139, 184);
            this.dtpDataRegistoCriminal.Name = "dtpDataRegistoCriminal";
            this.dtpDataRegistoCriminal.Size = new System.Drawing.Size(120, 20);
            this.dtpDataRegistoCriminal.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 187);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Data Registo Criminal:";
            // 
            // dtpDataFimContrato
            // 
            this.dtpDataFimContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFimContrato.Location = new System.Drawing.Point(138, 121);
            this.dtpDataFimContrato.Name = "dtpDataFimContrato";
            this.dtpDataFimContrato.Size = new System.Drawing.Size(120, 20);
            this.dtpDataFimContrato.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Data Fim Contrato:";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(138, 92);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(200, 20);
            this.txtContacto.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contacto:";
            // 
            // txtMorada
            // 
            this.txtMorada.Location = new System.Drawing.Point(138, 65);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(320, 20);
            this.txtMorada.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Morada:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(138, 19);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(320, 20);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // ControlFuncionario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpDadosPessoais);
            this.Name = "ControlFuncionario";
            this.Size = new System.Drawing.Size(500, 230);
            this.grpDadosPessoais.ResumeLayout(false);
            this.grpDadosPessoais.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioBase)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDadosPessoais;
        private System.Windows.Forms.TextBox txtNIF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numSalarioBase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblStatusRegistoCriminal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpDataRegistoCriminal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDataFimContrato;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMorada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label2;
    }
}
