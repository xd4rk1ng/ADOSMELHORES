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
            this.grpDadosSecretaria = new System.Windows.Forms.GroupBox();
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
            this.label8 = new System.Windows.Forms.Label();
            this.checkedListBoxDiretores = new System.Windows.Forms.CheckedListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.grpAcoes = new System.Windows.Forms.GroupBox();
            this.btnAtualizarRegistoCriminal = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.grpListaSecretarias = new System.Windows.Forms.GroupBox();
            this.lblTotalSecretarias = new System.Windows.Forms.Label();
            this.dgvSecretarias = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBoxArea = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkedListBoxIdiomas = new System.Windows.Forms.CheckedListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtStatusRegistoCriminal = new System.Windows.Forms.TextBox();
            this.grpDadosSecretaria.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioBase)).BeginInit();
            this.grpAcoes.SuspendLayout();
            this.grpListaSecretarias.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecretarias)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpDadosSecretaria
            // 
            this.grpDadosSecretaria.Controls.Add(this.txtStatusRegistoCriminal);
            this.grpDadosSecretaria.Controls.Add(this.txtNIF);
            this.grpDadosSecretaria.Controls.Add(this.label13);
            this.grpDadosSecretaria.Controls.Add(this.label6);
            this.grpDadosSecretaria.Controls.Add(this.numSalarioBase);
            this.grpDadosSecretaria.Controls.Add(this.label7);
            this.grpDadosSecretaria.Controls.Add(this.lblStatusRegistoCriminal);
            this.grpDadosSecretaria.Controls.Add(this.label11);
            this.grpDadosSecretaria.Controls.Add(this.dtpDataRegistoCriminal);
            this.grpDadosSecretaria.Controls.Add(this.label10);
            this.grpDadosSecretaria.Controls.Add(this.dtpDataFimContrato);
            this.grpDadosSecretaria.Controls.Add(this.label9);
            this.grpDadosSecretaria.Controls.Add(this.txtContacto);
            this.grpDadosSecretaria.Controls.Add(this.label4);
            this.grpDadosSecretaria.Controls.Add(this.txtMorada);
            this.grpDadosSecretaria.Controls.Add(this.label3);
            this.grpDadosSecretaria.Controls.Add(this.txtNome);
            this.grpDadosSecretaria.Controls.Add(this.label2);
            this.grpDadosSecretaria.Location = new System.Drawing.Point(13, 14);
            this.grpDadosSecretaria.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDadosSecretaria.Name = "grpDadosSecretaria";
            this.grpDadosSecretaria.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDadosSecretaria.Size = new System.Drawing.Size(647, 287);
            this.grpDadosSecretaria.TabIndex = 1;
            this.grpDadosSecretaria.TabStop = false;
            this.grpDadosSecretaria.Text = "Dados da Secretária";
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(184, 59);
            this.txtNIF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(265, 27);
            this.txtNIF.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 65);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 20);
            this.label6.TabIndex = 2;
            this.label6.Text = "NIF:";
            // 
            // numSalarioBase
            // 
            this.numSalarioBase.DecimalPlaces = 2;
            this.numSalarioBase.Location = new System.Drawing.Point(183, 207);
            this.numSalarioBase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numSalarioBase.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSalarioBase.Name = "numSalarioBase";
            this.numSalarioBase.Size = new System.Drawing.Size(160, 27);
            this.numSalarioBase.TabIndex = 11;
            this.numSalarioBase.ThousandsSeparator = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 214);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "Salário Base:";
            // 
            // lblStatusRegistoCriminal
            // 
            this.lblStatusRegistoCriminal.AutoSize = true;
            this.lblStatusRegistoCriminal.Location = new System.Drawing.Point(200, 600);
            this.lblStatusRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusRegistoCriminal.Name = "lblStatusRegistoCriminal";
            this.lblStatusRegistoCriminal.Size = new System.Drawing.Size(15, 20);
            this.lblStatusRegistoCriminal.TabIndex = 20;
            this.lblStatusRegistoCriminal.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 600);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 20);
            this.label11.TabIndex = 19;
            this.label11.Text = "Status Registo Criminal:";
            // 
            // dtpDataRegistoCriminal
            // 
            this.dtpDataRegistoCriminal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataRegistoCriminal.Location = new System.Drawing.Point(183, 244);
            this.dtpDataRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDataRegistoCriminal.Name = "dtpDataRegistoCriminal";
            this.dtpDataRegistoCriminal.Size = new System.Drawing.Size(159, 27);
            this.dtpDataRegistoCriminal.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 251);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 20);
            this.label10.TabIndex = 12;
            this.label10.Text = "Data Registo Criminal:";
            // 
            // dtpDataFimContrato
            // 
            this.dtpDataFimContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFimContrato.Location = new System.Drawing.Point(184, 170);
            this.dtpDataFimContrato.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDataFimContrato.Name = "dtpDataFimContrato";
            this.dtpDataFimContrato.Size = new System.Drawing.Size(159, 27);
            this.dtpDataFimContrato.TabIndex = 9;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 177);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 20);
            this.label9.TabIndex = 8;
            this.label9.Text = "Data Fim Contrato:";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(184, 133);
            this.txtContacto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(265, 27);
            this.txtContacto.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contacto:";
            // 
            // txtMorada
            // 
            this.txtMorada.Location = new System.Drawing.Point(184, 96);
            this.txtMorada.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(407, 27);
            this.txtMorada.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Morada:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(184, 22);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(407, 27);
            this.txtNome.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 29);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Nome:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(19, 24);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(140, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "Áreas de Secretaria:";
            // 
            // checkedListBoxDiretores
            // 
            this.checkedListBoxDiretores.FormattingEnabled = true;
            this.checkedListBoxDiretores.Location = new System.Drawing.Point(184, 117);
            this.checkedListBoxDiretores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkedListBoxDiretores.Name = "checkedListBoxDiretores";
            this.checkedListBoxDiretores.Size = new System.Drawing.Size(188, 48);
            this.checkedListBoxDiretores.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 117);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(165, 20);
            this.label5.TabIndex = 2;
            this.label5.Text = "Diretores Responsáveis:";
            // 
            // grpAcoes
            // 
            this.grpAcoes.Controls.Add(this.btnAtualizarRegistoCriminal);
            this.grpAcoes.Controls.Add(this.btnLimpar);
            this.grpAcoes.Controls.Add(this.btnRemover);
            this.grpAcoes.Controls.Add(this.btnAlterar);
            this.grpAcoes.Controls.Add(this.btnInserir);
            this.grpAcoes.Location = new System.Drawing.Point(676, 14);
            this.grpAcoes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAcoes.Name = "grpAcoes";
            this.grpAcoes.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAcoes.Size = new System.Drawing.Size(267, 481);
            this.grpAcoes.TabIndex = 2;
            this.grpAcoes.TabStop = false;
            this.grpAcoes.Text = "Ações";
            // 
            // btnAtualizarRegistoCriminal
            // 
            this.btnAtualizarRegistoCriminal.Enabled = false;
            this.btnAtualizarRegistoCriminal.Location = new System.Drawing.Point(27, 329);
            this.btnAtualizarRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAtualizarRegistoCriminal.Name = "btnAtualizarRegistoCriminal";
            this.btnAtualizarRegistoCriminal.Size = new System.Drawing.Size(213, 54);
            this.btnAtualizarRegistoCriminal.TabIndex = 6;
            this.btnAtualizarRegistoCriminal.Text = "Atualizar Registo Criminal";
            this.btnAtualizarRegistoCriminal.UseVisualStyleBackColor = true;
            this.btnAtualizarRegistoCriminal.Click += new System.EventHandler(this.btnAtualizarRegistoCriminal_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(27, 254);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(213, 54);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Limpar Campos";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Enabled = false;
            this.btnRemover.Location = new System.Drawing.Point(27, 185);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(213, 54);
            this.btnRemover.TabIndex = 2;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Location = new System.Drawing.Point(27, 115);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(213, 54);
            this.btnAlterar.TabIndex = 1;
            this.btnAlterar.Text = "Alterar Selecionado";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(27, 46);
            this.btnInserir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(213, 54);
            this.btnInserir.TabIndex = 0;
            this.btnInserir.Text = "Inserir Novo";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // grpListaSecretarias
            // 
            this.grpListaSecretarias.Controls.Add(this.lblTotalSecretarias);
            this.grpListaSecretarias.Controls.Add(this.dgvSecretarias);
            this.grpListaSecretarias.Location = new System.Drawing.Point(13, 504);
            this.grpListaSecretarias.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpListaSecretarias.Name = "grpListaSecretarias";
            this.grpListaSecretarias.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpListaSecretarias.Size = new System.Drawing.Size(930, 234);
            this.grpListaSecretarias.TabIndex = 7;
            this.grpListaSecretarias.TabStop = false;
            this.grpListaSecretarias.Text = "Lista de Secretárias";
            // 
            // lblTotalSecretarias
            // 
            this.lblTotalSecretarias.AutoSize = true;
            this.lblTotalSecretarias.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalSecretarias.Location = new System.Drawing.Point(17, 201);
            this.lblTotalSecretarias.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalSecretarias.Name = "lblTotalSecretarias";
            this.lblTotalSecretarias.Size = new System.Drawing.Size(179, 18);
            this.lblTotalSecretarias.TabIndex = 1;
            this.lblTotalSecretarias.Text = "Total de Secretárias: 0";
            // 
            // dgvSecretarias
            // 
            this.dgvSecretarias.AllowUserToAddRows = false;
            this.dgvSecretarias.AllowUserToDeleteRows = false;
            this.dgvSecretarias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSecretarias.Location = new System.Drawing.Point(20, 39);
            this.dgvSecretarias.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvSecretarias.Name = "dgvSecretarias";
            this.dgvSecretarias.ReadOnly = true;
            this.dgvSecretarias.RowHeadersWidth = 51;
            this.dgvSecretarias.Size = new System.Drawing.Size(898, 157);
            this.dgvSecretarias.TabIndex = 0;
            this.dgvSecretarias.SelectionChanged += new System.EventHandler(this.dgvSecretarias_SelectionChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBoxArea);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.checkedListBoxDiretores);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(13, 310);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(406, 185);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dados da Direção";
            // 
            // listBoxArea
            // 
            this.listBoxArea.FormattingEnabled = true;
            this.listBoxArea.ItemHeight = 20;
            this.listBoxArea.Items.AddRange(new object[] {
            "Recursos Humanos",
            "Financeiro",
            "Formação",
            "Comercial",
            "Direção-Geral"});
            this.listBoxArea.Location = new System.Drawing.Point(186, 24);
            this.listBoxArea.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBoxArea.Name = "listBoxArea";
            this.listBoxArea.Size = new System.Drawing.Size(186, 84);
            this.listBoxArea.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Idiomas falados:";
            // 
            // checkedListBoxIdiomas
            // 
            this.checkedListBoxIdiomas.FormattingEnabled = true;
            this.checkedListBoxIdiomas.Items.AddRange(new object[] {
            "Português",
            "Inglês",
            "Espanhol",
            "Francês",
            "Alemão"});
            this.checkedListBoxIdiomas.Location = new System.Drawing.Point(25, 48);
            this.checkedListBoxIdiomas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkedListBoxIdiomas.Name = "checkedListBoxIdiomas";
            this.checkedListBoxIdiomas.Size = new System.Drawing.Size(172, 92);
            this.checkedListBoxIdiomas.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkedListBoxIdiomas);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(429, 310);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(231, 185);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Dados Profissionais";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(365, 249);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(165, 20);
            this.label13.TabIndex = 22;
            this.label13.Text = "Status Registo Criminal:";
            // 
            // txtStatusRegistoCriminal
            // 
            this.txtStatusRegistoCriminal.Enabled = false;
            this.txtStatusRegistoCriminal.Location = new System.Drawing.Point(533, 244);
            this.txtStatusRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtStatusRegistoCriminal.Name = "txtStatusRegistoCriminal";
            this.txtStatusRegistoCriminal.ReadOnly = true;
            this.txtStatusRegistoCriminal.Size = new System.Drawing.Size(106, 27);
            this.txtStatusRegistoCriminal.TabIndex = 23;
            // 
            // FormGerirSecretarias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(252)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(973, 753);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpListaSecretarias);
            this.Controls.Add(this.grpAcoes);
            this.Controls.Add(this.grpDadosSecretaria);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormGerirSecretarias";
            this.Text = "FormGerirSecretarias";
            this.grpDadosSecretaria.ResumeLayout(false);
            this.grpDadosSecretaria.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioBase)).EndInit();
            this.grpAcoes.ResumeLayout(false);
            this.grpListaSecretarias.ResumeLayout(false);
            this.grpListaSecretarias.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecretarias)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDadosSecretaria;
        private System.Windows.Forms.Label label8;
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
        private System.Windows.Forms.GroupBox grpAcoes;
        private System.Windows.Forms.Button btnAtualizarRegistoCriminal;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.GroupBox grpListaSecretarias;
        private System.Windows.Forms.Label lblTotalSecretarias;
        private System.Windows.Forms.DataGridView dgvSecretarias;
        private System.Windows.Forms.TextBox txtNIF;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBoxArea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox checkedListBoxIdiomas;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtStatusRegistoCriminal;
    }
}