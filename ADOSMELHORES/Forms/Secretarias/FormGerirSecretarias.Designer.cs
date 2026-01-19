namespace ADOSMELHORES.Forms.Secretarias
{
    partial class FormGerirSecretarias
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
            this.grpDadosDiretor = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.checkedListBoxAreasDiretoria = new System.Windows.Forms.CheckedListBox();
            this.numSalarioBase = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.checkedListBoxDiretores = new System.Windows.Forms.CheckedListBox();
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
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.grpDadosDiretor.Controls.Add(this.label8);
            this.grpDadosDiretor.Controls.Add(this.checkedListBoxAreasDiretoria);
            this.grpDadosDiretor.Controls.Add(this.numSalarioBase);
            this.grpDadosDiretor.Controls.Add(this.label7);
            this.grpDadosDiretor.Controls.Add(this.checkedListBoxDiretores);
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
            this.grpDadosDiretor.Controls.Add(this.txtID);
            this.grpDadosDiretor.Controls.Add(this.label1);
            this.grpDadosDiretor.Location = new System.Drawing.Point(13, 13);
            this.grpDadosDiretor.Margin = new System.Windows.Forms.Padding(4);
            this.grpDadosDiretor.Name = "grpDadosDiretor";
            this.grpDadosDiretor.Padding = new System.Windows.Forms.Padding(4);
            this.grpDadosDiretor.Size = new System.Drawing.Size(667, 468);
            this.grpDadosDiretor.TabIndex = 1;
            this.grpDadosDiretor.TabStop = false;
            this.grpDadosDiretor.Text = "Dados da Secretária";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 333);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 16);
            this.label8.TabIndex = 28;
            this.label8.Text = "Áreas de Secretaria:";
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
            this.checkedListBoxAreasDiretoria.Location = new System.Drawing.Point(200, 333);
            this.checkedListBoxAreasDiretoria.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBoxAreasDiretoria.Name = "checkedListBoxAreasDiretoria";
            this.checkedListBoxAreasDiretoria.Size = new System.Drawing.Size(200, 106);
            this.checkedListBoxAreasDiretoria.TabIndex = 27;
            // 
            // numSalarioBase
            // 
            this.numSalarioBase.DecimalPlaces = 2;
            this.numSalarioBase.Location = new System.Drawing.Point(200, 186);
            this.numSalarioBase.Margin = new System.Windows.Forms.Padding(4);
            this.numSalarioBase.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSalarioBase.Name = "numSalarioBase";
            this.numSalarioBase.Size = new System.Drawing.Size(160, 22);
            this.numSalarioBase.TabIndex = 26;
            this.numSalarioBase.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 188);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Salário Base:";
            // 
            // checkedListBoxDiretores
            // 
            this.checkedListBoxDiretores.FormattingEnabled = true;
            this.checkedListBoxDiretores.Location = new System.Drawing.Point(459, 276);
            this.checkedListBoxDiretores.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBoxDiretores.Name = "checkedListBoxDiretores";
            this.checkedListBoxDiretores.Size = new System.Drawing.Size(200, 89);
            this.checkedListBoxDiretores.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(408, 256);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(156, 16);
            this.label5.TabIndex = 21;
            this.label5.Text = "Diretores Responsáveis:";
            // 
            // lblStatusRegistoCriminal
            // 
            this.lblStatusRegistoCriminal.AutoSize = true;
            this.lblStatusRegistoCriminal.Location = new System.Drawing.Point(200, 480);
            this.lblStatusRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusRegistoCriminal.Name = "lblStatusRegistoCriminal";
            this.lblStatusRegistoCriminal.Size = new System.Drawing.Size(11, 16);
            this.lblStatusRegistoCriminal.TabIndex = 20;
            this.lblStatusRegistoCriminal.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 480);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Status Registo Criminal:";
            // 
            // dtpDataRegistoCriminal
            // 
            this.dtpDataRegistoCriminal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataRegistoCriminal.Location = new System.Drawing.Point(200, 230);
            this.dtpDataRegistoCriminal.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDataRegistoCriminal.Name = "dtpDataRegistoCriminal";
            this.dtpDataRegistoCriminal.Size = new System.Drawing.Size(159, 22);
            this.dtpDataRegistoCriminal.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 230);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(140, 16);
            this.label10.TabIndex = 18;
            this.label10.Text = "Data Registo Criminal:";
            // 
            // dtpDataFimContrato
            // 
            this.dtpDataFimContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFimContrato.Location = new System.Drawing.Point(200, 144);
            this.dtpDataFimContrato.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDataFimContrato.Name = "dtpDataFimContrato";
            this.dtpDataFimContrato.Size = new System.Drawing.Size(159, 22);
            this.dtpDataFimContrato.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 148);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Data Fim Contrato:";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(200, 107);
            this.txtContacto.Margin = new System.Windows.Forms.Padding(4);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(265, 22);
            this.txtContacto.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 111);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 16);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contacto:";
            // 
            // txtMorada
            // 
            this.txtMorada.Location = new System.Drawing.Point(200, 70);
            this.txtMorada.Margin = new System.Windows.Forms.Padding(4);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(425, 22);
            this.txtMorada.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Morada:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(200, 33);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(425, 22);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 37);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.Location = new System.Drawing.Point(200, 33);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(132, 22);
            this.txtID.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // grpAcoes
            // 
            this.grpAcoes.Controls.Add(this.btnAtualizarRegistoCriminal);
            this.grpAcoes.Controls.Add(this.btnLimpar);
            this.grpAcoes.Controls.Add(this.btnRemover);
            this.grpAcoes.Controls.Add(this.btnAlterar);
            this.grpAcoes.Controls.Add(this.btnInserir);
            this.grpAcoes.Location = new System.Drawing.Point(714, 13);
            this.grpAcoes.Margin = new System.Windows.Forms.Padding(4);
            this.grpAcoes.Name = "grpAcoes";
            this.grpAcoes.Padding = new System.Windows.Forms.Padding(4);
            this.grpAcoes.Size = new System.Drawing.Size(267, 468);
            this.grpAcoes.TabIndex = 2;
            this.grpAcoes.TabStop = false;
            this.grpAcoes.Text = "Ações";
            // 
            // btnAtualizarRegistoCriminal
            // 
            this.btnAtualizarRegistoCriminal.Enabled = false;
            this.btnAtualizarRegistoCriminal.Location = new System.Drawing.Point(27, 263);
            this.btnAtualizarRegistoCriminal.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtualizarRegistoCriminal.Name = "btnAtualizarRegistoCriminal";
            this.btnAtualizarRegistoCriminal.Size = new System.Drawing.Size(213, 43);
            this.btnAtualizarRegistoCriminal.TabIndex = 6;
            this.btnAtualizarRegistoCriminal.Text = "Atualizar Registo Criminal";
            this.btnAtualizarRegistoCriminal.UseVisualStyleBackColor = true;
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(27, 203);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(213, 43);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Limpar Campos";
            this.btnLimpar.UseVisualStyleBackColor = true;
            // 
            // btnRemover
            // 
            this.btnRemover.Enabled = false;
            this.btnRemover.Location = new System.Drawing.Point(27, 148);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(213, 43);
            this.btnRemover.TabIndex = 2;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Location = new System.Drawing.Point(27, 92);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(213, 43);
            this.btnAlterar.TabIndex = 1;
            this.btnAlterar.Text = "Alterar Selecionado";
            this.btnAlterar.UseVisualStyleBackColor = true;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(27, 37);
            this.btnInserir.Margin = new System.Windows.Forms.Padding(4);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(213, 43);
            this.btnInserir.TabIndex = 0;
            this.btnInserir.Text = "Inserir Novo";
            this.btnInserir.UseVisualStyleBackColor = true;
            // 
            // grpListaDiretores
            // 
            this.grpListaDiretores.Controls.Add(this.lblTotalDiretores);
            this.grpListaDiretores.Controls.Add(this.dgvDiretores);
            this.grpListaDiretores.Location = new System.Drawing.Point(23, 493);
            this.grpListaDiretores.Margin = new System.Windows.Forms.Padding(4);
            this.grpListaDiretores.Name = "grpListaDiretores";
            this.grpListaDiretores.Padding = new System.Windows.Forms.Padding(4);
            this.grpListaDiretores.Size = new System.Drawing.Size(941, 308);
            this.grpListaDiretores.TabIndex = 7;
            this.grpListaDiretores.TabStop = false;
            this.grpListaDiretores.Text = "Lista de Secretárias";
            // 
            // lblTotalDiretores
            // 
            this.lblTotalDiretores.AutoSize = true;
            this.lblTotalDiretores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalDiretores.Location = new System.Drawing.Point(20, 271);
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
            this.dgvDiretores.Location = new System.Drawing.Point(20, 31);
            this.dgvDiretores.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDiretores.Name = "dgvDiretores";
            this.dgvDiretores.ReadOnly = true;
            this.dgvDiretores.RowHeadersWidth = 51;
            this.dgvDiretores.Size = new System.Drawing.Size(900, 228);
            this.dgvDiretores.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(860, 809);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(133, 37);
            this.btnFechar.TabIndex = 8;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            // 
            // FormGerirSecretarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 854);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.grpListaDiretores);
            this.Controls.Add(this.grpAcoes);
            this.Controls.Add(this.grpDadosDiretor);
            this.Name = "FormGerirSecretarias";
            this.Text = "FormGerirSecretarias";
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox checkedListBoxAreasDiretoria;
        private System.Windows.Forms.NumericUpDown numSalarioBase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox checkedListBoxDiretores;
        private System.Windows.Forms.Label label5;
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
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpAcoes;
        private System.Windows.Forms.Button btnAtualizarRegistoCriminal;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.GroupBox grpListaDiretores;
        private System.Windows.Forms.Label lblTotalDiretores;
        private System.Windows.Forms.DataGridView dgvDiretores;
        private System.Windows.Forms.Button btnFechar;
    }
}