namespace ADOSMELHORES.Forms.Despesas
{
    partial class FormDespesas
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.numAno = new System.Windows.Forms.NumericUpDown();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblAno = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelResumo = new System.Windows.Forms.Panel();
            this.lstDespesasFisicas = new System.Windows.Forms.ListBox();
            this.lblPeriodo = new System.Windows.Forms.Label();
            this.labelDespesasFisicas = new System.Windows.Forms.Label();
            this.lblTotalFormadores = new System.Windows.Forms.Label();
            this.lblTotalCoordenadores = new System.Windows.Forms.Label();
            this.lblTotalSecretarias = new System.Windows.Forms.Label();
            this.lblTotalDiretores = new System.Windows.Forms.Label();
            this.lblCoordenadores = new System.Windows.Forms.Label();
            this.lblFormadores = new System.Windows.Forms.Label();
            this.lblSecretárias = new System.Windows.Forms.Label();
            this.lblDiretores = new System.Windows.Forms.Label();
            this.LabelDespesasFuncionariosTotal = new System.Windows.Forms.Label();
            this.lblTotalDespesas = new System.Windows.Forms.Label();
            this.lblLabelTotal = new System.Windows.Forms.Label();
            this.lblDespesasFuncionarios = new System.Windows.Forms.Label();
            this.lablDespesasFuncionarios = new System.Windows.Forms.Label();
            this.lblDespesasFisicas = new System.Windows.Forms.Label();
            this.lblLabelDespesasFisicas = new System.Windows.Forms.Label();
            this.panelHistorico = new System.Windows.Forms.Panel();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).BeginInit();
            this.panelResumo.SuspendLayout();
            this.panelHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numAno);
            this.panel1.Controls.Add(this.cmbMes);
            this.panel1.Controls.Add(this.lblAno);
            this.panel1.Controls.Add(this.lblMes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 127);
            this.panel1.TabIndex = 0;
            // 
            // numAno
            // 
            this.numAno.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAno.Location = new System.Drawing.Point(615, 75);
            this.numAno.Maximum = new decimal(new int[] {
            2030,
            0,
            0,
            0});
            this.numAno.Minimum = new decimal(new int[] {
            2020,
            0,
            0,
            0});
            this.numAno.Name = "numAno";
            this.numAno.Size = new System.Drawing.Size(103, 30);
            this.numAno.TabIndex = 4;
            this.numAno.Value = new decimal(new int[] {
            2026,
            0,
            0,
            0});
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Items.AddRange(new object[] {
            "Janeiro",
            "Fevereiro",
            "Março",
            "Abril",
            "Maio",
            "Junho",
            "Julho",
            "Agosto",
            "Setembro",
            "Outubro",
            "Novembro",
            "Dezembro"});
            this.cmbMes.Location = new System.Drawing.Point(373, 75);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(122, 31);
            this.cmbMes.TabIndex = 3;
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAno.Location = new System.Drawing.Point(556, 76);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(47, 23);
            this.lblAno.TabIndex = 2;
            this.lblAno.Text = "Ano:";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(322, 78);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(47, 23);
            this.lblMes.TabIndex = 1;
            this.lblMes.Text = "Mês:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(378, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 41);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestão de Despesas";
            // 
            // panelResumo
            // 
            this.panelResumo.BackColor = System.Drawing.Color.White;
            this.panelResumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResumo.Controls.Add(this.lstDespesasFisicas);
            this.panelResumo.Controls.Add(this.lblPeriodo);
            this.panelResumo.Controls.Add(this.labelDespesasFisicas);
            this.panelResumo.Controls.Add(this.lblTotalFormadores);
            this.panelResumo.Controls.Add(this.lblTotalCoordenadores);
            this.panelResumo.Controls.Add(this.lblTotalSecretarias);
            this.panelResumo.Controls.Add(this.lblTotalDiretores);
            this.panelResumo.Controls.Add(this.lblCoordenadores);
            this.panelResumo.Controls.Add(this.lblFormadores);
            this.panelResumo.Controls.Add(this.lblSecretárias);
            this.panelResumo.Controls.Add(this.lblDiretores);
            this.panelResumo.Controls.Add(this.LabelDespesasFuncionariosTotal);
            this.panelResumo.Controls.Add(this.lblTotalDespesas);
            this.panelResumo.Controls.Add(this.lblLabelTotal);
            this.panelResumo.Controls.Add(this.lblDespesasFuncionarios);
            this.panelResumo.Controls.Add(this.lablDespesasFuncionarios);
            this.panelResumo.Controls.Add(this.lblDespesasFisicas);
            this.panelResumo.Controls.Add(this.lblLabelDespesasFisicas);
            this.panelResumo.Location = new System.Drawing.Point(12, 164);
            this.panelResumo.Name = "panelResumo";
            this.panelResumo.Size = new System.Drawing.Size(511, 463);
            this.panelResumo.TabIndex = 1;
            // 
            // lstDespesasFisicas
            // 
            this.lstDespesasFisicas.BackColor = System.Drawing.Color.LightGray;
            this.lstDespesasFisicas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDespesasFisicas.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDespesasFisicas.FormattingEnabled = true;
            this.lstDespesasFisicas.ItemHeight = 18;
            this.lstDespesasFisicas.Location = new System.Drawing.Point(36, 52);
            this.lstDespesasFisicas.Name = "lstDespesasFisicas";
            this.lstDespesasFisicas.Size = new System.Drawing.Size(434, 108);
            this.lstDespesasFisicas.TabIndex = 18;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.Location = new System.Drawing.Point(217, 18);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(51, 23);
            this.lblPeriodo.TabIndex = 17;
            this.lblPeriodo.Text = "Total ";
            // 
            // labelDespesasFisicas
            // 
            this.labelDespesasFisicas.AutoSize = true;
            this.labelDespesasFisicas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDespesasFisicas.Location = new System.Drawing.Point(59, 170);
            this.labelDespesasFisicas.Name = "labelDespesasFisicas";
            this.labelDespesasFisicas.Size = new System.Drawing.Size(177, 23);
            this.labelDespesasFisicas.TabIndex = 16;
            this.labelDespesasFisicas.Text = "Total Despesas Físicas:";
            // 
            // lblTotalFormadores
            // 
            this.lblTotalFormadores.AutoSize = true;
            this.lblTotalFormadores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFormadores.Location = new System.Drawing.Point(312, 341);
            this.lblTotalFormadores.Name = "lblTotalFormadores";
            this.lblTotalFormadores.Size = new System.Drawing.Size(55, 23);
            this.lblTotalFormadores.TabIndex = 15;
            this.lblTotalFormadores.Text = "€ 0,00";
            this.lblTotalFormadores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCoordenadores
            // 
            this.lblTotalCoordenadores.AutoSize = true;
            this.lblTotalCoordenadores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCoordenadores.Location = new System.Drawing.Point(312, 305);
            this.lblTotalCoordenadores.Name = "lblTotalCoordenadores";
            this.lblTotalCoordenadores.Size = new System.Drawing.Size(55, 23);
            this.lblTotalCoordenadores.TabIndex = 14;
            this.lblTotalCoordenadores.Text = "€ 0,00";
            this.lblTotalCoordenadores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalSecretarias
            // 
            this.lblTotalSecretarias.AutoSize = true;
            this.lblTotalSecretarias.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSecretarias.Location = new System.Drawing.Point(312, 271);
            this.lblTotalSecretarias.Name = "lblTotalSecretarias";
            this.lblTotalSecretarias.Size = new System.Drawing.Size(55, 23);
            this.lblTotalSecretarias.TabIndex = 13;
            this.lblTotalSecretarias.Text = "€ 0,00";
            this.lblTotalSecretarias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDiretores
            // 
            this.lblTotalDiretores.AutoSize = true;
            this.lblTotalDiretores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiretores.Location = new System.Drawing.Point(312, 237);
            this.lblTotalDiretores.Name = "lblTotalDiretores";
            this.lblTotalDiretores.Size = new System.Drawing.Size(55, 23);
            this.lblTotalDiretores.TabIndex = 12;
            this.lblTotalDiretores.Text = "€ 0,00";
            this.lblTotalDiretores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCoordenadores
            // 
            this.lblCoordenadores.AutoSize = true;
            this.lblCoordenadores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordenadores.Location = new System.Drawing.Point(81, 305);
            this.lblCoordenadores.Name = "lblCoordenadores";
            this.lblCoordenadores.Size = new System.Drawing.Size(131, 23);
            this.lblCoordenadores.TabIndex = 11;
            this.lblCoordenadores.Text = "Coordenadores:";
            // 
            // lblFormadores
            // 
            this.lblFormadores.AutoSize = true;
            this.lblFormadores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormadores.Location = new System.Drawing.Point(81, 341);
            this.lblFormadores.Name = "lblFormadores";
            this.lblFormadores.Size = new System.Drawing.Size(104, 23);
            this.lblFormadores.TabIndex = 10;
            this.lblFormadores.Text = "Formadores:";
            // 
            // lblSecretárias
            // 
            this.lblSecretárias.AutoSize = true;
            this.lblSecretárias.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecretárias.Location = new System.Drawing.Point(81, 271);
            this.lblSecretárias.Name = "lblSecretárias";
            this.lblSecretárias.Size = new System.Drawing.Size(96, 23);
            this.lblSecretárias.TabIndex = 9;
            this.lblSecretárias.Text = "Secretárias:";
            // 
            // lblDiretores
            // 
            this.lblDiretores.AutoSize = true;
            this.lblDiretores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiretores.Location = new System.Drawing.Point(81, 237);
            this.lblDiretores.Name = "lblDiretores";
            this.lblDiretores.Size = new System.Drawing.Size(83, 23);
            this.lblDiretores.TabIndex = 8;
            this.lblDiretores.Text = "Diretores:";
            // 
            // LabelDespesasFuncionariosTotal
            // 
            this.LabelDespesasFuncionariosTotal.AutoSize = true;
            this.LabelDespesasFuncionariosTotal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDespesasFuncionariosTotal.Location = new System.Drawing.Point(59, 385);
            this.LabelDespesasFuncionariosTotal.Name = "LabelDespesasFuncionariosTotal";
            this.LabelDespesasFuncionariosTotal.Size = new System.Drawing.Size(226, 23);
            this.LabelDespesasFuncionariosTotal.TabIndex = 7;
            this.LabelDespesasFuncionariosTotal.Text = "Total Despesas Funcionários:";
            // 
            // lblTotalDespesas
            // 
            this.lblTotalDespesas.AutoSize = true;
            this.lblTotalDespesas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDespesas.ForeColor = System.Drawing.Color.Red;
            this.lblTotalDespesas.Location = new System.Drawing.Point(296, 419);
            this.lblTotalDespesas.Name = "lblTotalDespesas";
            this.lblTotalDespesas.Size = new System.Drawing.Size(71, 28);
            this.lblTotalDespesas.TabIndex = 5;
            this.lblTotalDespesas.Text = "€ 0,00";
            this.lblTotalDespesas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLabelTotal
            // 
            this.lblLabelTotal.AutoSize = true;
            this.lblLabelTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelTotal.Location = new System.Drawing.Point(31, 419);
            this.lblLabelTotal.Name = "lblLabelTotal";
            this.lblLabelTotal.Size = new System.Drawing.Size(111, 28);
            this.lblLabelTotal.TabIndex = 4;
            this.lblLabelTotal.Text = "💶 TOTAL:";
            // 
            // lblDespesasFuncionarios
            // 
            this.lblDespesasFuncionarios.AutoSize = true;
            this.lblDespesasFuncionarios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDespesasFuncionarios.Location = new System.Drawing.Point(312, 385);
            this.lblDespesasFuncionarios.Name = "lblDespesasFuncionarios";
            this.lblDespesasFuncionarios.Size = new System.Drawing.Size(55, 23);
            this.lblDespesasFuncionarios.TabIndex = 3;
            this.lblDespesasFuncionarios.Text = "€ 0,00";
            this.lblDespesasFuncionarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lablDespesasFuncionarios
            // 
            this.lablDespesasFuncionarios.AutoSize = true;
            this.lablDespesasFuncionarios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablDespesasFuncionarios.Location = new System.Drawing.Point(32, 202);
            this.lablDespesasFuncionarios.Name = "lablDespesasFuncionarios";
            this.lablDespesasFuncionarios.Size = new System.Drawing.Size(209, 23);
            this.lablDespesasFuncionarios.TabIndex = 2;
            this.lablDespesasFuncionarios.Text = "👥 Despesas Funcionários";
            // 
            // lblDespesasFisicas
            // 
            this.lblDespesasFisicas.AutoSize = true;
            this.lblDespesasFisicas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDespesasFisicas.Location = new System.Drawing.Point(312, 170);
            this.lblDespesasFisicas.Name = "lblDespesasFisicas";
            this.lblDespesasFisicas.Size = new System.Drawing.Size(55, 23);
            this.lblDespesasFisicas.TabIndex = 1;
            this.lblDespesasFisicas.Text = "€ 0,00";
            this.lblDespesasFisicas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLabelDespesasFisicas
            // 
            this.lblLabelDespesasFisicas.AutoSize = true;
            this.lblLabelDespesasFisicas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelDespesasFisicas.Location = new System.Drawing.Point(32, 18);
            this.lblLabelDespesasFisicas.Name = "lblLabelDespesasFisicas";
            this.lblLabelDespesasFisicas.Size = new System.Drawing.Size(160, 23);
            this.lblLabelDespesasFisicas.TabIndex = 0;
            this.lblLabelDespesasFisicas.Text = "💰 Despesas Físicas";
            // 
            // panelHistorico
            // 
            this.panelHistorico.BackColor = System.Drawing.Color.White;
            this.panelHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHistorico.Controls.Add(this.dgvHistorico);
            this.panelHistorico.Controls.Add(this.label2);
            this.panelHistorico.Location = new System.Drawing.Point(558, 164);
            this.panelHistorico.Name = "panelHistorico";
            this.panelHistorico.Size = new System.Drawing.Size(500, 295);
            this.panelHistorico.TabIndex = 7;
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AllowUserToDeleteRows = false;
            this.dgvHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorico.BackgroundColor = System.Drawing.Color.LightGray;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvHistorico.Location = new System.Drawing.Point(28, 52);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.RowHeadersWidth = 51;
            this.dgvHistorico.RowTemplate.Height = 24;
            this.dgvHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorico.Size = new System.Drawing.Size(453, 224);
            this.dgvHistorico.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Mês/Ano";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Despesas Físicas";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Funcionários";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Total";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = " 📊 Histórico de Despesas ";
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.Green;
            this.btnAdicionar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(628, 498);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(193, 38);
            this.btnAdicionar.TabIndex = 8;
            this.btnAdicionar.Text = "➕ Adicionar Despesa";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.Blue;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(628, 542);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(193, 38);
            this.btnAtualizar.TabIndex = 9;
            this.btnAtualizar.Text = "📋 Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Orange;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(847, 498);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(193, 38);
            this.btnExportar.TabIndex = 10;
            this.btnExportar.Text = "📄 Exportar CSV";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnFechar
            // 
            this.btnFechar.BackColor = System.Drawing.Color.Gray;
            this.btnFechar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFechar.ForeColor = System.Drawing.Color.White;
            this.btnFechar.Location = new System.Drawing.Point(847, 542);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(193, 38);
            this.btnFechar.TabIndex = 11;
            this.btnFechar.Text = "✖ Fechar";
            this.btnFechar.UseVisualStyleBackColor = false;
            // 
            // FormDespesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(252)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(1079, 639);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.panelHistorico);
            this.Controls.Add(this.panelResumo);
            this.Controls.Add(this.panel1);
            this.Name = "FormDespesas";
            this.Text = "FormDespesas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).EndInit();
            this.panelResumo.ResumeLayout(false);
            this.panelResumo.PerformLayout();
            this.panelHistorico.ResumeLayout(false);
            this.panelHistorico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.NumericUpDown numAno;
        private System.Windows.Forms.Panel panelResumo;
        private System.Windows.Forms.Label lblDespesasFuncionarios;
        private System.Windows.Forms.Label lablDespesasFuncionarios;
        private System.Windows.Forms.Label lblDespesasFisicas;
        private System.Windows.Forms.Label lblLabelDespesasFisicas;
        private System.Windows.Forms.Label lblTotalDespesas;
        private System.Windows.Forms.Label lblLabelTotal;
        private System.Windows.Forms.Panel panelHistorico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Label LabelDespesasFuncionariosTotal;
        private System.Windows.Forms.Label lblCoordenadores;
        private System.Windows.Forms.Label lblFormadores;
        private System.Windows.Forms.Label lblSecretárias;
        private System.Windows.Forms.Label lblDiretores;
        private System.Windows.Forms.Label labelDespesasFisicas;
        private System.Windows.Forms.Label lblTotalFormadores;
        private System.Windows.Forms.Label lblTotalCoordenadores;
        private System.Windows.Forms.Label lblTotalSecretarias;
        private System.Windows.Forms.Label lblTotalDiretores;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.ListBox lstDespesasFisicas;
    }
}