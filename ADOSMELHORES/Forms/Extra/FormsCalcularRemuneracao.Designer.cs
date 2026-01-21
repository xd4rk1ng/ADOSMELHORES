namespace ADOSMELHORES.Forms
{
    partial class FormsCalcularRemuneracao
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

        private void InitializeComponent()
        {
            this.grpDadosDiretor = new System.Windows.Forms.GroupBox();
            this.lblAreasDiretoria = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSecretarias = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSalarioBase = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblNomeDiretor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpConfiguracoes = new System.Windows.Forms.GroupBox();
            this.chkIsencaoHorario = new System.Windows.Forms.CheckBox();
            this.chkCarroEmpresa = new System.Windows.Forms.CheckBox();
            this.grpCalculo = new System.Windows.Forms.GroupBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.txtResultado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.grpDadosDiretor.SuspendLayout();
            this.grpConfiguracoes.SuspendLayout();
            this.grpCalculo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDadosDiretor
            // 
            this.grpDadosDiretor.Controls.Add(this.lblAreasDiretoria);
            this.grpDadosDiretor.Controls.Add(this.label4);
            this.grpDadosDiretor.Controls.Add(this.lblSecretarias);
            this.grpDadosDiretor.Controls.Add(this.label3);
            this.grpDadosDiretor.Controls.Add(this.lblSalarioBase);
            this.grpDadosDiretor.Controls.Add(this.label2);
            this.grpDadosDiretor.Controls.Add(this.lblNomeDiretor);
            this.grpDadosDiretor.Controls.Add(this.label1);
            this.grpDadosDiretor.Location = new System.Drawing.Point(16, 15);
            this.grpDadosDiretor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDadosDiretor.Name = "grpDadosDiretor";
            this.grpDadosDiretor.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpDadosDiretor.Size = new System.Drawing.Size(747, 155);
            this.grpDadosDiretor.TabIndex = 0;
            this.grpDadosDiretor.TabStop = false;
            this.grpDadosDiretor.Text = "Dados do Diretor";
            // 
            // lblAreasDiretoria
            // 
            this.lblAreasDiretoria.AutoSize = true;
            this.lblAreasDiretoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAreasDiretoria.Location = new System.Drawing.Point(200, 118);
            this.lblAreasDiretoria.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAreasDiretoria.Name = "lblAreasDiretoria";
            this.lblAreasDiretoria.Size = new System.Drawing.Size(103, 18);
            this.lblAreasDiretoria.TabIndex = 7;
            this.lblAreasDiretoria.Text = "Recursos H.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 120);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Áreas de Direção:";
            // 
            // lblSecretarias
            // 
            this.lblSecretarias.AutoSize = true;
            this.lblSecretarias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecretarias.Location = new System.Drawing.Point(200, 91);
            this.lblSecretarias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSecretarias.Name = "lblSecretarias";
            this.lblSecretarias.Size = new System.Drawing.Size(17, 18);
            this.lblSecretarias.TabIndex = 5;
            this.lblSecretarias.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 91);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(167, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Secretárias Subordinadas:";
            // 
            // lblSalarioBase
            // 
            this.lblSalarioBase.AutoSize = true;
            this.lblSalarioBase.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalarioBase.Location = new System.Drawing.Point(200, 60);
            this.lblSalarioBase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalarioBase.Name = "lblSalarioBase";
            this.lblSalarioBase.Size = new System.Drawing.Size(76, 18);
            this.lblSalarioBase.TabIndex = 3;
            this.lblSalarioBase.Text = "1500,00€";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 62);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Salário Base:";
            // 
            // lblNomeDiretor
            // 
            this.lblNomeDiretor.AutoSize = true;
            this.lblNomeDiretor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeDiretor.Location = new System.Drawing.Point(200, 31);
            this.lblNomeDiretor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNomeDiretor.Name = "lblNomeDiretor";
            this.lblNomeDiretor.Size = new System.Drawing.Size(134, 18);
            this.lblNomeDiretor.TabIndex = 1;
            this.lblNomeDiretor.Text = "Nome do Diretor";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome:";
            // 
            // grpConfiguracoes
            // 
            this.grpConfiguracoes.Controls.Add(this.chkIsencaoHorario);
            this.grpConfiguracoes.Controls.Add(this.chkCarroEmpresa);
            this.grpConfiguracoes.Location = new System.Drawing.Point(16, 178);
            this.grpConfiguracoes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpConfiguracoes.Name = "grpConfiguracoes";
            this.grpConfiguracoes.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpConfiguracoes.Size = new System.Drawing.Size(747, 68);
            this.grpConfiguracoes.TabIndex = 1;
            this.grpConfiguracoes.TabStop = false;
            this.grpConfiguracoes.Text = "Configurações de Remuneração";
            // 
            // chkIsencaoHorario
            // 
            this.chkIsencaoHorario.AutoSize = true;
            this.chkIsencaoHorario.Checked = true;
            this.chkIsencaoHorario.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsencaoHorario.Location = new System.Drawing.Point(267, 33);
            this.chkIsencaoHorario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkIsencaoHorario.Name = "chkIsencaoHorario";
            this.chkIsencaoHorario.Size = new System.Drawing.Size(125, 20);
            this.chkIsencaoHorario.TabIndex = 1;
            this.chkIsencaoHorario.Text = "Isenção Horário";
            this.chkIsencaoHorario.UseVisualStyleBackColor = true;
            // 
            // chkCarroEmpresa
            // 
            this.chkCarroEmpresa.AutoSize = true;
            this.chkCarroEmpresa.Location = new System.Drawing.Point(28, 33);
            this.chkCarroEmpresa.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chkCarroEmpresa.Name = "chkCarroEmpresa";
            this.chkCarroEmpresa.Size = new System.Drawing.Size(120, 20);
            this.chkCarroEmpresa.TabIndex = 0;
            this.chkCarroEmpresa.Text = "Carro Empresa";
            this.chkCarroEmpresa.UseVisualStyleBackColor = true;
            // 
            // grpCalculo
            // 
            this.grpCalculo.Controls.Add(this.btnCalcular);
            this.grpCalculo.Controls.Add(this.txtResultado);
            this.grpCalculo.Controls.Add(this.label5);
            this.grpCalculo.Location = new System.Drawing.Point(16, 254);
            this.grpCalculo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCalculo.Name = "grpCalculo";
            this.grpCalculo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grpCalculo.Size = new System.Drawing.Size(747, 315);
            this.grpCalculo.TabIndex = 2;
            this.grpCalculo.TabStop = false;
            this.grpCalculo.Text = "Cálculo da Remuneração";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcular.Location = new System.Drawing.Point(31, 264);
            this.btnCalcular.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(695, 43);
            this.btnCalcular.TabIndex = 2;
            this.btnCalcular.Text = "CALCULAR SALÁRIO";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // txtResultado
            // 
            this.txtResultado.BackColor = System.Drawing.SystemColors.Info;
            this.txtResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.Location = new System.Drawing.Point(31, 48);
            this.txtResultado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtResultado.Multiline = true;
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.ReadOnly = true;
            this.txtResultado.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultado.Size = new System.Drawing.Size(693, 208);
            this.txtResultado.TabIndex = 1;
            this.txtResultado.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(28, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "Resultado:";
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(663, 577);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 28);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormsCalcularRemuneracao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 636);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.grpCalculo);
            this.Controls.Add(this.grpConfiguracoes);
            this.Controls.Add(this.grpDadosDiretor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormsCalcularRemuneracao";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cálculo de Remuneração - ADOSMELHORES";
            this.grpDadosDiretor.ResumeLayout(false);
            this.grpDadosDiretor.PerformLayout();
            this.grpConfiguracoes.ResumeLayout(false);
            this.grpConfiguracoes.PerformLayout();
            this.grpCalculo.ResumeLayout(false);
            this.grpCalculo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDadosDiretor;
        private System.Windows.Forms.Label lblNomeDiretor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSalarioBase;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSecretarias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblAreasDiretoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grpConfiguracoes;
        private System.Windows.Forms.CheckBox chkIsencaoHorario;
        private System.Windows.Forms.CheckBox chkCarroEmpresa;
        private System.Windows.Forms.GroupBox grpCalculo;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.TextBox txtResultado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnFechar;
    }
}