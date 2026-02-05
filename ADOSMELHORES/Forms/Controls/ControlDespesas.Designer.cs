namespace ADOSMELHORES.Forms.Controls
{
    partial class ControlDespesas
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
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnAtualizar = new System.Windows.Forms.Button();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.panelHistorico = new System.Windows.Forms.Panel();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.numAno = new System.Windows.Forms.NumericUpDown();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblAno = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.panelResumo.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Orange;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(393, 409);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(254, 31);
            this.btnExportar.TabIndex = 17;
            this.btnExportar.Text = "📄 Exportar CSV";
            this.btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnAtualizar
            // 
            this.btnAtualizar.BackColor = System.Drawing.Color.Blue;
            this.btnAtualizar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtualizar.ForeColor = System.Drawing.Color.White;
            this.btnAtualizar.Location = new System.Drawing.Point(393, 444);
            this.btnAtualizar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAtualizar.Name = "btnAtualizar";
            this.btnAtualizar.Size = new System.Drawing.Size(254, 31);
            this.btnAtualizar.TabIndex = 16;
            this.btnAtualizar.Text = "📋 Atualizar";
            this.btnAtualizar.UseVisualStyleBackColor = false;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.Green;
            this.btnAdicionar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(393, 374);
            this.btnAdicionar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(254, 31);
            this.btnAdicionar.TabIndex = 15;
            this.btnAdicionar.Text = "➕ Adicionar Despesa";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            // 
            // panelHistorico
            // 
            this.panelHistorico.BackColor = System.Drawing.Color.White;
            this.panelHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHistorico.Controls.Add(this.dgvHistorico);
            this.panelHistorico.Controls.Add(this.label2);
            this.panelHistorico.Location = new System.Drawing.Point(365, 125);
            this.panelHistorico.Margin = new System.Windows.Forms.Padding(2);
            this.panelHistorico.Name = "panelHistorico";
            this.panelHistorico.Size = new System.Drawing.Size(317, 240);
            this.panelHistorico.TabIndex = 14;
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
            this.dgvHistorico.Location = new System.Drawing.Point(2, 42);
            this.dgvHistorico.Margin = new System.Windows.Forms.Padding(2);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.RowHeadersWidth = 51;
            this.dgvHistorico.RowTemplate.Height = 24;
            this.dgvHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorico.Size = new System.Drawing.Size(340, 182);
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
            this.label2.Location = new System.Drawing.Point(85, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = " 📊 Histórico de Despesas ";
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
            this.panelResumo.Location = new System.Drawing.Point(2, 125);
            this.panelResumo.Margin = new System.Windows.Forms.Padding(2);
            this.panelResumo.Name = "panelResumo";
            this.panelResumo.Size = new System.Drawing.Size(357, 371);
            this.panelResumo.TabIndex = 13;
            // 
            // lstDespesasFisicas
            // 
            this.lstDespesasFisicas.BackColor = System.Drawing.Color.LightGray;
            this.lstDespesasFisicas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstDespesasFisicas.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstDespesasFisicas.FormattingEnabled = true;
            this.lstDespesasFisicas.ItemHeight = 14;
            this.lstDespesasFisicas.Location = new System.Drawing.Point(27, 42);
            this.lstDespesasFisicas.Margin = new System.Windows.Forms.Padding(2);
            this.lstDespesasFisicas.Name = "lstDespesasFisicas";
            this.lstDespesasFisicas.Size = new System.Drawing.Size(326, 84);
            this.lstDespesasFisicas.TabIndex = 18;
            // 
            // lblPeriodo
            // 
            this.lblPeriodo.AutoSize = true;
            this.lblPeriodo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPeriodo.Location = new System.Drawing.Point(163, 15);
            this.lblPeriodo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPeriodo.Name = "lblPeriodo";
            this.lblPeriodo.Size = new System.Drawing.Size(42, 19);
            this.lblPeriodo.TabIndex = 17;
            this.lblPeriodo.Text = "Total ";
            // 
            // labelDespesasFisicas
            // 
            this.labelDespesasFisicas.AutoSize = true;
            this.labelDespesasFisicas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDespesasFisicas.Location = new System.Drawing.Point(44, 138);
            this.labelDespesasFisicas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelDespesasFisicas.Name = "labelDespesasFisicas";
            this.labelDespesasFisicas.Size = new System.Drawing.Size(144, 19);
            this.labelDespesasFisicas.TabIndex = 16;
            this.labelDespesasFisicas.Text = "Total Despesas Físicas:";
            // 
            // lblTotalFormadores
            // 
            this.lblTotalFormadores.AutoSize = true;
            this.lblTotalFormadores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalFormadores.Location = new System.Drawing.Point(234, 277);
            this.lblTotalFormadores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalFormadores.Name = "lblTotalFormadores";
            this.lblTotalFormadores.Size = new System.Drawing.Size(48, 19);
            this.lblTotalFormadores.TabIndex = 15;
            this.lblTotalFormadores.Text = "€ 0,00";
            this.lblTotalFormadores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCoordenadores
            // 
            this.lblTotalCoordenadores.AutoSize = true;
            this.lblTotalCoordenadores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCoordenadores.Location = new System.Drawing.Point(234, 248);
            this.lblTotalCoordenadores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalCoordenadores.Name = "lblTotalCoordenadores";
            this.lblTotalCoordenadores.Size = new System.Drawing.Size(48, 19);
            this.lblTotalCoordenadores.TabIndex = 14;
            this.lblTotalCoordenadores.Text = "€ 0,00";
            this.lblTotalCoordenadores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalSecretarias
            // 
            this.lblTotalSecretarias.AutoSize = true;
            this.lblTotalSecretarias.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalSecretarias.Location = new System.Drawing.Point(234, 220);
            this.lblTotalSecretarias.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalSecretarias.Name = "lblTotalSecretarias";
            this.lblTotalSecretarias.Size = new System.Drawing.Size(48, 19);
            this.lblTotalSecretarias.TabIndex = 13;
            this.lblTotalSecretarias.Text = "€ 0,00";
            this.lblTotalSecretarias.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalDiretores
            // 
            this.lblTotalDiretores.AutoSize = true;
            this.lblTotalDiretores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDiretores.Location = new System.Drawing.Point(234, 193);
            this.lblTotalDiretores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalDiretores.Name = "lblTotalDiretores";
            this.lblTotalDiretores.Size = new System.Drawing.Size(48, 19);
            this.lblTotalDiretores.TabIndex = 12;
            this.lblTotalDiretores.Text = "€ 0,00";
            this.lblTotalDiretores.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCoordenadores
            // 
            this.lblCoordenadores.AutoSize = true;
            this.lblCoordenadores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoordenadores.Location = new System.Drawing.Point(61, 248);
            this.lblCoordenadores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCoordenadores.Name = "lblCoordenadores";
            this.lblCoordenadores.Size = new System.Drawing.Size(106, 19);
            this.lblCoordenadores.TabIndex = 11;
            this.lblCoordenadores.Text = "Coordenadores:";
            // 
            // lblFormadores
            // 
            this.lblFormadores.AutoSize = true;
            this.lblFormadores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFormadores.Location = new System.Drawing.Point(61, 277);
            this.lblFormadores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFormadores.Name = "lblFormadores";
            this.lblFormadores.Size = new System.Drawing.Size(85, 19);
            this.lblFormadores.TabIndex = 10;
            this.lblFormadores.Text = "Formadores:";
            // 
            // lblSecretárias
            // 
            this.lblSecretárias.AutoSize = true;
            this.lblSecretárias.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecretárias.Location = new System.Drawing.Point(61, 220);
            this.lblSecretárias.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSecretárias.Name = "lblSecretárias";
            this.lblSecretárias.Size = new System.Drawing.Size(77, 19);
            this.lblSecretárias.TabIndex = 9;
            this.lblSecretárias.Text = "Secretárias:";
            // 
            // lblDiretores
            // 
            this.lblDiretores.AutoSize = true;
            this.lblDiretores.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiretores.Location = new System.Drawing.Point(61, 193);
            this.lblDiretores.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDiretores.Name = "lblDiretores";
            this.lblDiretores.Size = new System.Drawing.Size(68, 19);
            this.lblDiretores.TabIndex = 8;
            this.lblDiretores.Text = "Diretores:";
            // 
            // LabelDespesasFuncionariosTotal
            // 
            this.LabelDespesasFuncionariosTotal.AutoSize = true;
            this.LabelDespesasFuncionariosTotal.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelDespesasFuncionariosTotal.Location = new System.Drawing.Point(44, 313);
            this.LabelDespesasFuncionariosTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.LabelDespesasFuncionariosTotal.Name = "LabelDespesasFuncionariosTotal";
            this.LabelDespesasFuncionariosTotal.Size = new System.Drawing.Size(183, 19);
            this.LabelDespesasFuncionariosTotal.TabIndex = 7;
            this.LabelDespesasFuncionariosTotal.Text = "Total Despesas Funcionários:";
            // 
            // lblTotalDespesas
            // 
            this.lblTotalDespesas.AutoSize = true;
            this.lblTotalDespesas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDespesas.ForeColor = System.Drawing.Color.Red;
            this.lblTotalDespesas.Location = new System.Drawing.Point(222, 340);
            this.lblTotalDespesas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalDespesas.Name = "lblTotalDespesas";
            this.lblTotalDespesas.Size = new System.Drawing.Size(54, 21);
            this.lblTotalDespesas.TabIndex = 5;
            this.lblTotalDespesas.Text = "€ 0,00";
            this.lblTotalDespesas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLabelTotal
            // 
            this.lblLabelTotal.AutoSize = true;
            this.lblLabelTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelTotal.Location = new System.Drawing.Point(23, 340);
            this.lblLabelTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLabelTotal.Name = "lblLabelTotal";
            this.lblLabelTotal.Size = new System.Drawing.Size(87, 21);
            this.lblLabelTotal.TabIndex = 4;
            this.lblLabelTotal.Text = "💶 TOTAL:";
            // 
            // lblDespesasFuncionarios
            // 
            this.lblDespesasFuncionarios.AutoSize = true;
            this.lblDespesasFuncionarios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDespesasFuncionarios.Location = new System.Drawing.Point(234, 313);
            this.lblDespesasFuncionarios.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDespesasFuncionarios.Name = "lblDespesasFuncionarios";
            this.lblDespesasFuncionarios.Size = new System.Drawing.Size(48, 19);
            this.lblDespesasFuncionarios.TabIndex = 3;
            this.lblDespesasFuncionarios.Text = "€ 0,00";
            this.lblDespesasFuncionarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lablDespesasFuncionarios
            // 
            this.lablDespesasFuncionarios.AutoSize = true;
            this.lablDespesasFuncionarios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lablDespesasFuncionarios.Location = new System.Drawing.Point(24, 164);
            this.lablDespesasFuncionarios.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lablDespesasFuncionarios.Name = "lablDespesasFuncionarios";
            this.lablDespesasFuncionarios.Size = new System.Drawing.Size(170, 19);
            this.lablDespesasFuncionarios.TabIndex = 2;
            this.lablDespesasFuncionarios.Text = "👥 Despesas Funcionários";
            // 
            // lblDespesasFisicas
            // 
            this.lblDespesasFisicas.AutoSize = true;
            this.lblDespesasFisicas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDespesasFisicas.Location = new System.Drawing.Point(234, 138);
            this.lblDespesasFisicas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDespesasFisicas.Name = "lblDespesasFisicas";
            this.lblDespesasFisicas.Size = new System.Drawing.Size(48, 19);
            this.lblDespesasFisicas.TabIndex = 1;
            this.lblDespesasFisicas.Text = "€ 0,00";
            this.lblDespesasFisicas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLabelDespesasFisicas
            // 
            this.lblLabelDespesasFisicas.AutoSize = true;
            this.lblLabelDespesasFisicas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelDespesasFisicas.Location = new System.Drawing.Point(24, 15);
            this.lblLabelDespesasFisicas.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblLabelDespesasFisicas.Name = "lblLabelDespesasFisicas";
            this.lblLabelDespesasFisicas.Size = new System.Drawing.Size(131, 19);
            this.lblLabelDespesasFisicas.TabIndex = 0;
            this.lblLabelDespesasFisicas.Text = "💰 Despesas Físicas";
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
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(680, 104);
            this.panel1.TabIndex = 12;
            // 
            // numAno
            // 
            this.numAno.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAno.Location = new System.Drawing.Point(430, 61);
            this.numAno.Margin = new System.Windows.Forms.Padding(2);
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
            this.numAno.Size = new System.Drawing.Size(77, 26);
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
            this.cmbMes.Location = new System.Drawing.Point(246, 59);
            this.cmbMes.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(92, 27);
            this.cmbMes.TabIndex = 3;
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAno.Location = new System.Drawing.Point(386, 62);
            this.lblAno.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(40, 19);
            this.lblAno.TabIndex = 2;
            this.lblAno.Text = "Ano:";
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(208, 61);
            this.lblMes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(40, 19);
            this.lblMes.TabIndex = 1;
            this.lblMes.Text = "Mês:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gestão de Despesas";
            // 
            // ControlDespesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnAtualizar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.panelHistorico);
            this.Controls.Add(this.panelResumo);
            this.Controls.Add(this.panel1);
            this.Name = "ControlDespesas";
            this.Size = new System.Drawing.Size(684, 525);
            this.panelHistorico.ResumeLayout(false);
            this.panelHistorico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).EndInit();
            this.panelResumo.ResumeLayout(false);
            this.panelResumo.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnAtualizar;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Panel panelHistorico;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelResumo;
        private System.Windows.Forms.ListBox lstDespesasFisicas;
        private System.Windows.Forms.Label lblPeriodo;
        private System.Windows.Forms.Label labelDespesasFisicas;
        private System.Windows.Forms.Label lblTotalFormadores;
        private System.Windows.Forms.Label lblTotalCoordenadores;
        private System.Windows.Forms.Label lblTotalSecretarias;
        private System.Windows.Forms.Label lblTotalDiretores;
        private System.Windows.Forms.Label lblCoordenadores;
        private System.Windows.Forms.Label lblFormadores;
        private System.Windows.Forms.Label lblSecretárias;
        private System.Windows.Forms.Label lblDiretores;
        private System.Windows.Forms.Label LabelDespesasFuncionariosTotal;
        private System.Windows.Forms.Label lblTotalDespesas;
        private System.Windows.Forms.Label lblLabelTotal;
        private System.Windows.Forms.Label lblDespesasFuncionarios;
        private System.Windows.Forms.Label lablDespesasFuncionarios;
        private System.Windows.Forms.Label lblDespesasFisicas;
        private System.Windows.Forms.Label lblLabelDespesasFisicas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.NumericUpDown numAno;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblAno;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Label label1;
    }
}
