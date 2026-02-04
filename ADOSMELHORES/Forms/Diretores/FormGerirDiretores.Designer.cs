namespace ADOSMELHORES.Forms.Diretores
{
    partial class FormGerirDiretores
    {
        private System.ComponentModel.IContainer components = null;

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
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.labelNIF = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnCalcularValor = new System.Windows.Forms.Button();
            this.checkedListBoxAreasDiretoria = new System.Windows.Forms.CheckedListBox();
            this.numSalarioBase = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.checkedListBoxSecretarias = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
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
            this.grpAcoes = new System.Windows.Forms.GroupBox();
            this.btnAtualizarRegistoCriminal = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.grpListaDiretores = new System.Windows.Forms.GroupBox();
            this.lblTotalDiretores = new System.Windows.Forms.Label();
            this.dgvDiretores = new System.Windows.Forms.DataGridView();
            this.btnFechar = new System.Windows.Forms.Button();
            this.grpDadosDiretor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioBase)).BeginInit();
            this.grpAcoes.SuspendLayout();
            this.grpListaDiretores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiretores)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDadosDiretor
            // 
            this.grpDadosDiretor.Controls.Add(this.txtNIF);
            this.grpDadosDiretor.Controls.Add(this.labelNIF);
            this.grpDadosDiretor.Controls.Add(this.label8);
            this.grpDadosDiretor.Controls.Add(this.checkedListBoxAreasDiretoria);
            this.grpDadosDiretor.Controls.Add(this.numSalarioBase);
            this.grpDadosDiretor.Controls.Add(this.label7);
            this.grpDadosDiretor.Controls.Add(this.checkedListBoxSecretarias);
            this.grpDadosDiretor.Controls.Add(this.label5);
            this.grpDadosDiretor.Controls.Add(this.lblStatusRegistoCriminal);
            this.grpDadosDiretor.Controls.Add(this.label11);
            this.grpDadosDiretor.Controls.Add(this.dtpDataRegistoCriminal);
            this.grpDadosDiretor.Controls.Add(this.label10);
            this.grpDadosDiretor.Controls.Add(this.dtpDataFimContrato);
            this.grpDadosDiretor.Controls.Add(this.label9);
            this.grpDadosDiretor.Controls.Add(this.txtContacto);
            this.grpDadosDiretor.Controls.Add(this.label4);
            this.grpDadosDiretor.Controls.Add(this.txtMorada);
            this.grpDadosDiretor.Controls.Add(this.label3);
            this.grpDadosDiretor.Controls.Add(this.txtNome);
            this.grpDadosDiretor.Controls.Add(this.label2);
            this.grpDadosDiretor.Location = new System.Drawing.Point(18, 22);
            this.grpDadosDiretor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.grpDadosDiretor.Name = "grpDadosDiretor";
            this.grpDadosDiretor.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.grpDadosDiretor.Size = new System.Drawing.Size(682, 558);
            this.grpDadosDiretor.TabIndex = 0;
            this.grpDadosDiretor.TabStop = false;
            this.grpDadosDiretor.Text = "Dados do Diretor";
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(218, 71);
            this.txtNIF.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(348, 30);
            this.txtNIF.TabIndex = 4;
            // 
            // labelNIF
            // 
            this.labelNIF.AutoSize = true;
            this.labelNIF.Location = new System.Drawing.Point(22, 78);
            this.labelNIF.Name = "labelNIF";
            this.labelNIF.Size = new System.Drawing.Size(40, 23);
            this.labelNIF.TabIndex = 3;
            this.labelNIF.Text = "NIF:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 323);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(143, 23);
            this.label8.TabIndex = 15;
            this.label8.Text = "Áreas de Direção:";
            // 
            // btnCalcularValor
            // 
            this.btnCalcularValor.Enabled = false;
            this.btnCalcularValor.Location = new System.Drawing.Point(30, 463);
            this.btnCalcularValor.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnCalcularValor.Name = "btnCalcularValor";
            this.btnCalcularValor.Size = new System.Drawing.Size(219, 62);
            this.btnCalcularValor.TabIndex = 19;
            this.btnCalcularValor.Text = "Calcular Remuneração";
            this.btnCalcularValor.UseVisualStyleBackColor = true;
            this.btnCalcularValor.Click += new System.EventHandler(this.btnCalcularValor_Click);
            // 
            // checkedListBoxAreasDiretoria
            // 
            this.checkedListBoxAreasDiretoria.FormattingEnabled = true;
            this.checkedListBoxAreasDiretoria.Items.AddRange(new object[] {
            "Recursos Humanos",
            "Financeiro",
            "Formação",
            "Comercial",
            "Direção-Geral"});
            this.checkedListBoxAreasDiretoria.Location = new System.Drawing.Point(218, 323);
            this.checkedListBoxAreasDiretoria.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.checkedListBoxAreasDiretoria.Name = "checkedListBoxAreasDiretoria";
            this.checkedListBoxAreasDiretoria.Size = new System.Drawing.Size(298, 129);
            this.checkedListBoxAreasDiretoria.TabIndex = 16;
            // 
            // numSalarioBase
            // 
            this.numSalarioBase.DecimalPlaces = 2;
            this.numSalarioBase.Location = new System.Drawing.Point(218, 197);
            this.numSalarioBase.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.numSalarioBase.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSalarioBase.Name = "numSalarioBase";
            this.numSalarioBase.Size = new System.Drawing.Size(180, 30);
            this.numSalarioBase.TabIndex = 10;
            this.numSalarioBase.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 204);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 23);
            this.label7.TabIndex = 9;
            this.label7.Text = "Salário Base:";
            // 
            // checkedListBoxSecretarias
            // 
            this.checkedListBoxSecretarias.FormattingEnabled = true;
            this.checkedListBoxSecretarias.Location = new System.Drawing.Point(218, 463);
            this.checkedListBoxSecretarias.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.checkedListBoxSecretarias.Name = "checkedListBoxSecretarias";
            this.checkedListBoxSecretarias.Size = new System.Drawing.Size(298, 79);
            this.checkedListBoxSecretarias.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 463);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 23);
            this.label5.TabIndex = 17;
            this.label5.Text = "Secretárias Alocadas:";
            // 
            // lblStatusRegistoCriminal
            // 
            this.lblStatusRegistoCriminal.AutoSize = true;
            this.lblStatusRegistoCriminal.Location = new System.Drawing.Point(225, 690);
            this.lblStatusRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusRegistoCriminal.Name = "lblStatusRegistoCriminal";
            this.lblStatusRegistoCriminal.Size = new System.Drawing.Size(17, 23);
            this.lblStatusRegistoCriminal.TabIndex = 20;
            this.lblStatusRegistoCriminal.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(30, 690);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(189, 23);
            this.label11.TabIndex = 19;
            this.label11.Text = "Status Registo Criminal:";
            // 
            // dtpDataRegistoCriminal
            // 
            this.dtpDataRegistoCriminal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataRegistoCriminal.Location = new System.Drawing.Point(218, 281);
            this.dtpDataRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dtpDataRegistoCriminal.Name = "dtpDataRegistoCriminal";
            this.dtpDataRegistoCriminal.Size = new System.Drawing.Size(178, 30);
            this.dtpDataRegistoCriminal.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(22, 288);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 23);
            this.label10.TabIndex = 13;
            this.label10.Text = "Data Registo Criminal:";
            // 
            // dtpDataFimContrato
            // 
            this.dtpDataFimContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFimContrato.Location = new System.Drawing.Point(218, 239);
            this.dtpDataFimContrato.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dtpDataFimContrato.Name = "dtpDataFimContrato";
            this.dtpDataFimContrato.Size = new System.Drawing.Size(178, 30);
            this.dtpDataFimContrato.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(21, 246);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 23);
            this.label9.TabIndex = 11;
            this.label9.Text = "Data Fim Contrato:";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(218, 155);
            this.txtContacto.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(260, 30);
            this.txtContacto.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 162);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 7;
            this.label4.Text = "Contacto:";
            // 
            // txtMorada
            // 
            this.txtMorada.Location = new System.Drawing.Point(218, 113);
            this.txtMorada.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(436, 30);
            this.txtMorada.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 120);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "Morada:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(218, 29);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(436, 30);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 36);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // grpAcoes
            // 
            this.grpAcoes.Controls.Add(this.btnAtualizarRegistoCriminal);
            this.grpAcoes.Controls.Add(this.btnLimpar);
            this.grpAcoes.Controls.Add(this.btnRemover);
            this.grpAcoes.Controls.Add(this.btnCalcularValor);
            this.grpAcoes.Controls.Add(this.btnAlterar);
            this.grpAcoes.Controls.Add(this.btnInserir);
            this.grpAcoes.Location = new System.Drawing.Point(723, 22);
            this.grpAcoes.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.grpAcoes.Name = "grpAcoes";
            this.grpAcoes.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.grpAcoes.Size = new System.Drawing.Size(278, 558);
            this.grpAcoes.TabIndex = 1;
            this.grpAcoes.TabStop = false;
            this.grpAcoes.Text = "Ações";
            // 
            // btnAtualizarRegistoCriminal
            // 
            this.btnAtualizarRegistoCriminal.Enabled = false;
            this.btnAtualizarRegistoCriminal.Location = new System.Drawing.Point(30, 378);
            this.btnAtualizarRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAtualizarRegistoCriminal.Name = "btnAtualizarRegistoCriminal";
            this.btnAtualizarRegistoCriminal.Size = new System.Drawing.Size(220, 62);
            this.btnAtualizarRegistoCriminal.TabIndex = 6;
            this.btnAtualizarRegistoCriminal.Text = "Atualizar Registo Criminal";
            this.btnAtualizarRegistoCriminal.UseVisualStyleBackColor = true;
            this.btnAtualizarRegistoCriminal.Click += new System.EventHandler(this.btnAtualizarRegistoCriminal_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(30, 292);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(220, 62);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Limpar Campos";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Enabled = false;
            this.btnRemover.Location = new System.Drawing.Point(30, 213);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(219, 62);
            this.btnRemover.TabIndex = 2;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Location = new System.Drawing.Point(30, 132);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(219, 62);
            this.btnAlterar.TabIndex = 1;
            this.btnAlterar.Text = "Alterar Selecionado";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(30, 53);
            this.btnInserir.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(219, 68);
            this.btnInserir.TabIndex = 0;
            this.btnInserir.Text = "Inserir Novo";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // grpListaDiretores
            // 
            this.grpListaDiretores.Controls.Add(this.lblTotalDiretores);
            this.grpListaDiretores.Controls.Add(this.dgvDiretores);
            this.grpListaDiretores.Location = new System.Drawing.Point(18, 592);
            this.grpListaDiretores.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.grpListaDiretores.Name = "grpListaDiretores";
            this.grpListaDiretores.Padding = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.grpListaDiretores.Size = new System.Drawing.Size(983, 230);
            this.grpListaDiretores.TabIndex = 2;
            this.grpListaDiretores.TabStop = false;
            this.grpListaDiretores.Text = "Lista de Diretores";
            // 
            // lblTotalDiretores
            // 
            this.lblTotalDiretores.AutoSize = true;
            this.lblTotalDiretores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalDiretores.Location = new System.Drawing.Point(22, 390);
            this.lblTotalDiretores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalDiretores.Name = "lblTotalDiretores";
            this.lblTotalDiretores.Size = new System.Drawing.Size(163, 18);
            this.lblTotalDiretores.TabIndex = 1;
            this.lblTotalDiretores.Text = "Total de Diretores: 0";
            // 
            // dgvDiretores
            // 
            this.dgvDiretores.AllowUserToAddRows = false;
            this.dgvDiretores.AllowUserToDeleteRows = false;
            this.dgvDiretores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDiretores.Location = new System.Drawing.Point(22, 45);
            this.dgvDiretores.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.dgvDiretores.Name = "dgvDiretores";
            this.dgvDiretores.ReadOnly = true;
            this.dgvDiretores.RowHeadersWidth = 51;
            this.dgvDiretores.Size = new System.Drawing.Size(933, 157);
            this.dgvDiretores.TabIndex = 0;
            this.dgvDiretores.SelectionChanged += new System.EventHandler(this.dgvDiretores_SelectionChanged);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(927, 1157);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(150, 53);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormGerirDiretores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(252)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1041, 850);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.grpListaDiretores);
            this.Controls.Add(this.grpAcoes);
            this.Controls.Add(this.grpDadosDiretor);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.MaximizeBox = false;
            this.Name = "FormGerirDiretores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Diretores - ADOSMELHORES";
            this.grpDadosDiretor.ResumeLayout(false);
            this.grpDadosDiretor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioBase)).EndInit();
            this.grpAcoes.ResumeLayout(false);
            this.grpListaDiretores.ResumeLayout(false);
            this.grpListaDiretores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDiretores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDadosDiretor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMorada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDataFimContrato;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDataRegistoCriminal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblStatusRegistoCriminal;

        private System.Windows.Forms.GroupBox grpAcoes;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCalcularValor;
        private System.Windows.Forms.Button btnAtualizarRegistoCriminal;
        private System.Windows.Forms.NumericUpDown numSalarioBase;
        private System.Windows.Forms.Label label7;


        private System.Windows.Forms.GroupBox grpListaDiretores;
        private System.Windows.Forms.DataGridView dgvDiretores;
        private System.Windows.Forms.Label lblTotalDiretores;

        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.CheckedListBox checkedListBoxAreasDiretoria;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox checkedListBoxSecretarias;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNIF;
        private System.Windows.Forms.Label labelNIF;
    }
}
