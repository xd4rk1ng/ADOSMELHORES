using ADOSMELHORES.Forms;
namespace ADOSMELHORES.Forms.Formadores
{
    partial class FormGerirFormadores
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
            this.grpDadosFormador = new System.Windows.Forms.GroupBox();
            this.lblStatusRegistoCriminal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dtpDataRegistoCriminal = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDataFimContrato = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.numValorHora = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDisponibilidade = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAreaLeciona = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtMorada = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.labelNIF = new System.Windows.Forms.Label();
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpAcoes = new System.Windows.Forms.GroupBox();
            this.btnAtualizarRegistoCriminal = new System.Windows.Forms.Button();
            this.btnCalcularValor = new System.Windows.Forms.Button();
            this.btnFiltrarDisponibilidade = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnInserir = new System.Windows.Forms.Button();
            this.grpListaFormadores = new System.Windows.Forms.GroupBox();
            this.lblTotalFormadores = new System.Windows.Forms.Label();
            this.dgvFormadores = new System.Windows.Forms.DataGridView();
            this.grpDadosFormador.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValorHora)).BeginInit();
            this.grpAcoes.SuspendLayout();
            this.grpListaFormadores.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormadores)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDadosFormador
            // 
            this.grpDadosFormador.Controls.Add(this.lblStatusRegistoCriminal);
            this.grpDadosFormador.Controls.Add(this.label11);
            this.grpDadosFormador.Controls.Add(this.dtpDataRegistoCriminal);
            this.grpDadosFormador.Controls.Add(this.label10);
            this.grpDadosFormador.Controls.Add(this.dtpDataFimContrato);
            this.grpDadosFormador.Controls.Add(this.label9);
            this.grpDadosFormador.Controls.Add(this.numValorHora);
            this.grpDadosFormador.Controls.Add(this.label7);
            this.grpDadosFormador.Controls.Add(this.cmbDisponibilidade);
            this.grpDadosFormador.Controls.Add(this.label6);
            this.grpDadosFormador.Controls.Add(this.txtAreaLeciona);
            this.grpDadosFormador.Controls.Add(this.label5);
            this.grpDadosFormador.Controls.Add(this.txtContacto);
            this.grpDadosFormador.Controls.Add(this.label4);
            this.grpDadosFormador.Controls.Add(this.txtMorada);
            this.grpDadosFormador.Controls.Add(this.label3);
            this.grpDadosFormador.Controls.Add(this.txtNome);
            this.grpDadosFormador.Controls.Add(this.label2);
            this.grpDadosFormador.Controls.Add(this.txtID);
            this.grpDadosFormador.Controls.Add(this.labelNIF);
            this.grpDadosFormador.Controls.Add(this.txtNIF);
            this.grpDadosFormador.Controls.Add(this.label1);
            this.grpDadosFormador.Location = new System.Drawing.Point(16, 19);
            this.grpDadosFormador.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDadosFormador.Name = "grpDadosFormador";
            this.grpDadosFormador.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpDadosFormador.Size = new System.Drawing.Size(667, 433);
            this.grpDadosFormador.TabIndex = 0;
            this.grpDadosFormador.TabStop = false;
            this.grpDadosFormador.Text = "Dados do Formador";
            // 
            // lblStatusRegistoCriminal
            // 
            this.lblStatusRegistoCriminal.AutoSize = true;
            this.lblStatusRegistoCriminal.Location = new System.Drawing.Point(200, 400);
            this.lblStatusRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusRegistoCriminal.Name = "lblStatusRegistoCriminal";
            this.lblStatusRegistoCriminal.Size = new System.Drawing.Size(15, 20);
            this.lblStatusRegistoCriminal.TabIndex = 21;
            this.lblStatusRegistoCriminal.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(27, 401);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(165, 20);
            this.label11.TabIndex = 20;
            this.label11.Text = "Status Registo Criminal:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // dtpDataRegistoCriminal
            // 
            this.dtpDataRegistoCriminal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataRegistoCriminal.Location = new System.Drawing.Point(199, 363);
            this.dtpDataRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDataRegistoCriminal.Name = "dtpDataRegistoCriminal";
            this.dtpDataRegistoCriminal.Size = new System.Drawing.Size(159, 27);
            this.dtpDataRegistoCriminal.TabIndex = 19;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(27, 370);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(157, 20);
            this.label10.TabIndex = 18;
            this.label10.Text = "Data Registo Criminal:";
            // 
            // dtpDataFimContrato
            // 
            this.dtpDataFimContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFimContrato.Location = new System.Drawing.Point(199, 326);
            this.dtpDataFimContrato.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpDataFimContrato.Name = "dtpDataFimContrato";
            this.dtpDataFimContrato.Size = new System.Drawing.Size(159, 27);
            this.dtpDataFimContrato.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(27, 334);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 20);
            this.label9.TabIndex = 16;
            this.label9.Text = "Data Fim Contrato:";
            // 
            // numValorHora
            // 
            this.numValorHora.DecimalPlaces = 2;
            this.numValorHora.Location = new System.Drawing.Point(199, 289);
            this.numValorHora.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numValorHora.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numValorHora.Name = "numValorHora";
            this.numValorHora.Size = new System.Drawing.Size(160, 27);
            this.numValorHora.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 296);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 20);
            this.label7.TabIndex = 12;
            this.label7.Text = "Valor/Hora:";
            // 
            // cmbDisponibilidade
            // 
            this.cmbDisponibilidade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDisponibilidade.FormattingEnabled = true;
            this.cmbDisponibilidade.Location = new System.Drawing.Point(199, 251);
            this.cmbDisponibilidade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbDisponibilidade.Name = "cmbDisponibilidade";
            this.cmbDisponibilidade.Size = new System.Drawing.Size(265, 28);
            this.cmbDisponibilidade.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 259);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Disponibilidade:";
            // 
            // txtAreaLeciona
            // 
            this.txtAreaLeciona.Location = new System.Drawing.Point(199, 214);
            this.txtAreaLeciona.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtAreaLeciona.Name = "txtAreaLeciona";
            this.txtAreaLeciona.Size = new System.Drawing.Size(425, 27);
            this.txtAreaLeciona.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 221);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "Área Leciona:";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(199, 177);
            this.txtContacto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(265, 27);
            this.txtContacto.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 184);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Contacto:";
            // 
            // txtMorada
            // 
            this.txtMorada.Location = new System.Drawing.Point(199, 140);
            this.txtMorada.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(425, 27);
            this.txtMorada.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 147);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Morada:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(199, 103);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(425, 27);
            this.txtNome.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 110);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nome:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.SystemColors.Control;
            this.txtID.Location = new System.Drawing.Point(199, 29);
            this.txtID.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(132, 27);
            this.txtID.TabIndex = 1;
            // 
            // labelNIF
            // 
            this.labelNIF.AutoSize = true;
            this.labelNIF.Location = new System.Drawing.Point(27, 73);
            this.labelNIF.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNIF.Name = "labelNIF";
            this.labelNIF.Size = new System.Drawing.Size(34, 20);
            this.labelNIF.TabIndex = 22;
            this.labelNIF.Text = "NIF:";
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(200, 66);
            this.txtNIF.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(265, 27);
            this.txtNIF.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID:";
            // 
            // grpAcoes
            // 
            this.grpAcoes.Controls.Add(this.btnAtualizarRegistoCriminal);
            this.grpAcoes.Controls.Add(this.btnCalcularValor);
            this.grpAcoes.Controls.Add(this.btnFiltrarDisponibilidade);
            this.grpAcoes.Controls.Add(this.btnLimpar);
            this.grpAcoes.Controls.Add(this.btnRemover);
            this.grpAcoes.Controls.Add(this.btnAlterar);
            this.grpAcoes.Controls.Add(this.btnInserir);
            this.grpAcoes.Location = new System.Drawing.Point(691, 19);
            this.grpAcoes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAcoes.Name = "grpAcoes";
            this.grpAcoes.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpAcoes.Size = new System.Drawing.Size(267, 433);
            this.grpAcoes.TabIndex = 1;
            this.grpAcoes.TabStop = false;
            this.grpAcoes.Text = "Ações";
            // 
            // btnAtualizarRegistoCriminal
            // 
            this.btnAtualizarRegistoCriminal.Enabled = false;
            this.btnAtualizarRegistoCriminal.Location = new System.Drawing.Point(36, 303);
            this.btnAtualizarRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAtualizarRegistoCriminal.Name = "btnAtualizarRegistoCriminal";
            this.btnAtualizarRegistoCriminal.Size = new System.Drawing.Size(194, 46);
            this.btnAtualizarRegistoCriminal.TabIndex = 6;
            this.btnAtualizarRegistoCriminal.Text = "Atualizar Registo Criminal";
            this.btnAtualizarRegistoCriminal.UseVisualStyleBackColor = true;
            this.btnAtualizarRegistoCriminal.Click += new System.EventHandler(this.btnAtualizarRegistoCriminal_Click);
            // 
            // btnCalcularValor
            // 
            this.btnCalcularValor.Enabled = false;
            this.btnCalcularValor.Location = new System.Drawing.Point(36, 247);
            this.btnCalcularValor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCalcularValor.Name = "btnCalcularValor";
            this.btnCalcularValor.Size = new System.Drawing.Size(194, 46);
            this.btnCalcularValor.TabIndex = 4;
            this.btnCalcularValor.Text = "Calcular Valor Formação";
            this.btnCalcularValor.UseVisualStyleBackColor = true;
            this.btnCalcularValor.Click += new System.EventHandler(this.btnCalcularValor_Click);
            // 
            // btnFiltrarDisponibilidade
            // 
            this.btnFiltrarDisponibilidade.Location = new System.Drawing.Point(36, 359);
            this.btnFiltrarDisponibilidade.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFiltrarDisponibilidade.Name = "btnFiltrarDisponibilidade";
            this.btnFiltrarDisponibilidade.Size = new System.Drawing.Size(194, 46);
            this.btnFiltrarDisponibilidade.TabIndex = 7;
            this.btnFiltrarDisponibilidade.Text = "Filtrar por Disponibilidade";
            this.btnFiltrarDisponibilidade.UseVisualStyleBackColor = true;
            this.btnFiltrarDisponibilidade.Click += new System.EventHandler(this.btnFiltrarDisponibilidade_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(36, 191);
            this.btnLimpar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(194, 46);
            this.btnLimpar.TabIndex = 3;
            this.btnLimpar.Text = "Limpar Campos";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Enabled = false;
            this.btnRemover.Location = new System.Drawing.Point(36, 135);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(194, 46);
            this.btnRemover.TabIndex = 2;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnAlterar
            // 
            this.btnAlterar.Enabled = false;
            this.btnAlterar.Location = new System.Drawing.Point(36, 79);
            this.btnAlterar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(194, 46);
            this.btnAlterar.TabIndex = 1;
            this.btnAlterar.Text = "Alterar Selecionado";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(36, 23);
            this.btnInserir.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(194, 46);
            this.btnInserir.TabIndex = 0;
            this.btnInserir.Text = "Inserir Novo";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // grpListaFormadores
            // 
            this.grpListaFormadores.Controls.Add(this.lblTotalFormadores);
            this.grpListaFormadores.Controls.Add(this.dgvFormadores);
            this.grpListaFormadores.Location = new System.Drawing.Point(17, 462);
            this.grpListaFormadores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpListaFormadores.Name = "grpListaFormadores";
            this.grpListaFormadores.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.grpListaFormadores.Size = new System.Drawing.Size(941, 256);
            this.grpListaFormadores.TabIndex = 2;
            this.grpListaFormadores.TabStop = false;
            this.grpListaFormadores.Text = "Lista de Formadores";
            // 
            // lblTotalFormadores
            // 
            this.lblTotalFormadores.AutoSize = true;
            this.lblTotalFormadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotalFormadores.Location = new System.Drawing.Point(20, 218);
            this.lblTotalFormadores.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotalFormadores.Name = "lblTotalFormadores";
            this.lblTotalFormadores.Size = new System.Drawing.Size(185, 18);
            this.lblTotalFormadores.TabIndex = 1;
            this.lblTotalFormadores.Text = "Total de Formadores: 0";
            // 
            // dgvFormadores
            // 
            this.dgvFormadores.AllowUserToAddRows = false;
            this.dgvFormadores.AllowUserToDeleteRows = false;
            this.dgvFormadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFormadores.Location = new System.Drawing.Point(23, 30);
            this.dgvFormadores.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvFormadores.MultiSelect = false;
            this.dgvFormadores.Name = "dgvFormadores";
            this.dgvFormadores.ReadOnly = true;
            this.dgvFormadores.RowHeadersWidth = 51;
            this.dgvFormadores.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFormadores.Size = new System.Drawing.Size(900, 183);
            this.dgvFormadores.TabIndex = 0;
            this.dgvFormadores.SelectionChanged += new System.EventHandler(this.dgvFormadores_SelectionChanged);
            // 
            // FormGerirFormadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(252)))), ((int)(((byte)(249)))));
            this.ClientSize = new System.Drawing.Size(973, 743);
            this.Controls.Add(this.grpListaFormadores);
            this.Controls.Add(this.grpAcoes);
            this.Controls.Add(this.grpDadosFormador);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "FormGerirFormadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Formadores - ADOSMELHORES";
            this.grpDadosFormador.ResumeLayout(false);
            this.grpDadosFormador.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numValorHora)).EndInit();
            this.grpAcoes.ResumeLayout(false);
            this.grpListaFormadores.ResumeLayout(false);
            this.grpListaFormadores.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFormadores)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpDadosFormador;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMorada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAreaLeciona;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbDisponibilidade;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numValorHora;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpDataFimContrato;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpDataRegistoCriminal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblStatusRegistoCriminal;

        // Novos campos NIF
        private System.Windows.Forms.Label labelNIF;
        private System.Windows.Forms.TextBox txtNIF;

        private System.Windows.Forms.GroupBox grpAcoes;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnLimpar;
        private System.Windows.Forms.Button btnCalcularValor;
        private System.Windows.Forms.Button btnAtualizarRegistoCriminal;
        private System.Windows.Forms.Button btnFiltrarDisponibilidade;

        private System.Windows.Forms.GroupBox grpListaFormadores;
        private System.Windows.Forms.DataGridView dgvFormadores;
        private System.Windows.Forms.Label lblTotalFormadores;
    }
}
