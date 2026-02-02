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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblMes = new System.Windows.Forms.Label();
            this.lblAno = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.numAno = new System.Windows.Forms.NumericUpDown();
            this.btnVerAnoCompleto = new System.Windows.Forms.Button();
            this.panelResumo = new System.Windows.Forms.Panel();
            this.lblLabelDespesasFisicas = new System.Windows.Forms.Label();
            this.lblDespesasFisicas = new System.Windows.Forms.Label();
            this.lblDespesasFuncionarios = new System.Windows.Forms.Label();
            this.lblLabelDespesasFuncionarios = new System.Windows.Forms.Label();
            this.lblTotalDespesas = new System.Windows.Forms.Label();
            this.lblLabelTotal = new System.Windows.Forms.Label();
            this.panelGrafico = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.chartEvolucao = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelHistorico = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvHistorico = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnDetalhes = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).BeginInit();
            this.panelResumo.SuspendLayout();
            this.panelGrafico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEvolucao)).BeginInit();
            this.panelHistorico.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorico)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnVerAnoCompleto);
            this.panel1.Controls.Add(this.numAno);
            this.panel1.Controls.Add(this.cmbMes);
            this.panel1.Controls.Add(this.lblAno);
            this.panel1.Controls.Add(this.lblMes);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1046, 133);
            this.panel1.TabIndex = 0;
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
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(48, 85);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(45, 23);
            this.lblMes.TabIndex = 1;
            this.lblMes.Text = "Mês:";
            // 
            // lblAno
            // 
            this.lblAno.AutoSize = true;
            this.lblAno.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAno.Location = new System.Drawing.Point(403, 84);
            this.lblAno.Name = "lblAno";
            this.lblAno.Size = new System.Drawing.Size(45, 23);
            this.lblAno.TabIndex = 2;
            this.lblAno.Text = "Ano:";
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
            this.cmbMes.Location = new System.Drawing.Point(99, 82);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(122, 31);
            this.cmbMes.TabIndex = 3;
            // 
            // numAno
            // 
            this.numAno.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numAno.Location = new System.Drawing.Point(462, 83);
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
            // btnVerAnoCompleto
            // 
            this.btnVerAnoCompleto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerAnoCompleto.Location = new System.Drawing.Point(765, 81);
            this.btnVerAnoCompleto.Name = "btnVerAnoCompleto";
            this.btnVerAnoCompleto.Size = new System.Drawing.Size(211, 30);
            this.btnVerAnoCompleto.TabIndex = 5;
            this.btnVerAnoCompleto.Text = "📊 Ver Ano Completo";
            this.btnVerAnoCompleto.UseVisualStyleBackColor = true;
            // 
            // panelResumo
            // 
            this.panelResumo.BackColor = System.Drawing.Color.White;
            this.panelResumo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelResumo.Controls.Add(this.lblTotalDespesas);
            this.panelResumo.Controls.Add(this.lblLabelTotal);
            this.panelResumo.Controls.Add(this.lblDespesasFuncionarios);
            this.panelResumo.Controls.Add(this.lblLabelDespesasFuncionarios);
            this.panelResumo.Controls.Add(this.lblDespesasFisicas);
            this.panelResumo.Controls.Add(this.lblLabelDespesasFisicas);
            this.panelResumo.Location = new System.Drawing.Point(12, 156);
            this.panelResumo.Name = "panelResumo";
            this.panelResumo.Size = new System.Drawing.Size(402, 158);
            this.panelResumo.TabIndex = 1;
            // 
            // lblLabelDespesasFisicas
            // 
            this.lblLabelDespesasFisicas.AutoSize = true;
            this.lblLabelDespesasFisicas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelDespesasFisicas.Location = new System.Drawing.Point(32, 18);
            this.lblLabelDespesasFisicas.Name = "lblLabelDespesasFisicas";
            this.lblLabelDespesasFisicas.Size = new System.Drawing.Size(164, 23);
            this.lblLabelDespesasFisicas.TabIndex = 0;
            this.lblLabelDespesasFisicas.Text = "💰 Despesas Físicas:";
            // 
            // lblDespesasFisicas
            // 
            this.lblDespesasFisicas.AutoSize = true;
            this.lblDespesasFisicas.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDespesasFisicas.Location = new System.Drawing.Point(273, 18);
            this.lblDespesasFisicas.Name = "lblDespesasFisicas";
            this.lblDespesasFisicas.Size = new System.Drawing.Size(55, 23);
            this.lblDespesasFisicas.TabIndex = 1;
            this.lblDespesasFisicas.Text = "€ 0,00";
            this.lblDespesasFisicas.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDespesasFuncionarios
            // 
            this.lblDespesasFuncionarios.AutoSize = true;
            this.lblDespesasFuncionarios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDespesasFuncionarios.Location = new System.Drawing.Point(273, 61);
            this.lblDespesasFuncionarios.Name = "lblDespesasFuncionarios";
            this.lblDespesasFuncionarios.Size = new System.Drawing.Size(55, 23);
            this.lblDespesasFuncionarios.TabIndex = 3;
            this.lblDespesasFuncionarios.Text = "€ 0,00";
            this.lblDespesasFuncionarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLabelDespesasFuncionarios
            // 
            this.lblLabelDespesasFuncionarios.AutoSize = true;
            this.lblLabelDespesasFuncionarios.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLabelDespesasFuncionarios.Location = new System.Drawing.Point(32, 61);
            this.lblLabelDespesasFuncionarios.Name = "lblLabelDespesasFuncionarios";
            this.lblLabelDespesasFuncionarios.Size = new System.Drawing.Size(213, 23);
            this.lblLabelDespesasFuncionarios.TabIndex = 2;
            this.lblLabelDespesasFuncionarios.Text = "👥 Despesas Funcionários:";
            // 
            // lblTotalDespesas
            // 
            this.lblTotalDespesas.AutoSize = true;
            this.lblTotalDespesas.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDespesas.ForeColor = System.Drawing.Color.Red;
            this.lblTotalDespesas.Location = new System.Drawing.Point(273, 108);
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
            this.lblLabelTotal.Location = new System.Drawing.Point(32, 108);
            this.lblLabelTotal.Name = "lblLabelTotal";
            this.lblLabelTotal.Size = new System.Drawing.Size(111, 28);
            this.lblLabelTotal.TabIndex = 4;
            this.lblLabelTotal.Text = "💶 TOTAL:";
            // 
            // panelGrafico
            // 
            this.panelGrafico.BackColor = System.Drawing.Color.White;
            this.panelGrafico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelGrafico.Controls.Add(this.chartEvolucao);
            this.panelGrafico.Controls.Add(this.label7);
            this.panelGrafico.Location = new System.Drawing.Point(475, 156);
            this.panelGrafico.Name = "panelGrafico";
            this.panelGrafico.Size = new System.Drawing.Size(402, 158);
            this.panelGrafico.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(33, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(188, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Evolução das Despesas:";
            // 
            // chartEvolucao
            // 
            chartArea1.Name = "ChartArea1";
            this.chartEvolucao.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartEvolucao.Legends.Add(legend1);
            this.chartEvolucao.Location = new System.Drawing.Point(36, 43);
            this.chartEvolucao.Name = "chartEvolucao";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartEvolucao.Series.Add(series1);
            this.chartEvolucao.Size = new System.Drawing.Size(322, 114);
            this.chartEvolucao.TabIndex = 1;
            this.chartEvolucao.Text = "chart1";
            // 
            // panelHistorico
            // 
            this.panelHistorico.BackColor = System.Drawing.Color.White;
            this.panelHistorico.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelHistorico.Controls.Add(this.dgvHistorico);
            this.panelHistorico.Controls.Add(this.label2);
            this.panelHistorico.Location = new System.Drawing.Point(12, 344);
            this.panelHistorico.Name = "panelHistorico";
            this.panelHistorico.Size = new System.Drawing.Size(421, 206);
            this.panelHistorico.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = " 📊 Histórico de Despesas ";
            // 
            // dgvHistorico
            // 
            this.dgvHistorico.AllowUserToAddRows = false;
            this.dgvHistorico.AllowUserToDeleteRows = false;
            this.dgvHistorico.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorico.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorico.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dgvHistorico.Location = new System.Drawing.Point(50, 52);
            this.dgvHistorico.Name = "dgvHistorico";
            this.dgvHistorico.RowHeadersWidth = 51;
            this.dgvHistorico.RowTemplate.Height = 24;
            this.dgvHistorico.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorico.Size = new System.Drawing.Size(293, 141);
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
            // btnAdicionar
            // 
            this.btnAdicionar.BackColor = System.Drawing.Color.Green;
            this.btnAdicionar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionar.ForeColor = System.Drawing.Color.White;
            this.btnAdicionar.Location = new System.Drawing.Point(626, 357);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(193, 38);
            this.btnAdicionar.TabIndex = 8;
            this.btnAdicionar.Text = "➕ Adicionar Despesa";
            this.btnAdicionar.UseVisualStyleBackColor = false;
            // 
            // btnDetalhes
            // 
            this.btnDetalhes.BackColor = System.Drawing.Color.Blue;
            this.btnDetalhes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalhes.ForeColor = System.Drawing.Color.White;
            this.btnDetalhes.Location = new System.Drawing.Point(626, 413);
            this.btnDetalhes.Name = "btnDetalhes";
            this.btnDetalhes.Size = new System.Drawing.Size(193, 38);
            this.btnDetalhes.TabIndex = 9;
            this.btnDetalhes.Text = "📋 Ver Detalhes";
            this.btnDetalhes.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.Orange;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(626, 472);
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
            this.btnFechar.Location = new System.Drawing.Point(626, 536);
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
            this.ClientSize = new System.Drawing.Size(1070, 586);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnDetalhes);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.panelHistorico);
            this.Controls.Add(this.panelGrafico);
            this.Controls.Add(this.panelResumo);
            this.Controls.Add(this.panel1);
            this.Name = "FormDespesas";
            this.Text = "FormDespesas";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAno)).EndInit();
            this.panelResumo.ResumeLayout(false);
            this.panelResumo.PerformLayout();
            this.panelGrafico.ResumeLayout(false);
            this.panelGrafico.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartEvolucao)).EndInit();
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
        private System.Windows.Forms.Button btnVerAnoCompleto;
        private System.Windows.Forms.NumericUpDown numAno;
        private System.Windows.Forms.Panel panelResumo;
        private System.Windows.Forms.Label lblDespesasFuncionarios;
        private System.Windows.Forms.Label lblLabelDespesasFuncionarios;
        private System.Windows.Forms.Label lblDespesasFisicas;
        private System.Windows.Forms.Label lblLabelDespesasFisicas;
        private System.Windows.Forms.Label lblTotalDespesas;
        private System.Windows.Forms.Label lblLabelTotal;
        private System.Windows.Forms.Panel panelGrafico;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartEvolucao;
        private System.Windows.Forms.Panel panelHistorico;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvHistorico;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnDetalhes;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnFechar;
    }
}