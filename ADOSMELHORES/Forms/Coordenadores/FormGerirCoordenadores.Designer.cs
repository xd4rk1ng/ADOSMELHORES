namespace ADOSMELHORES.Forms
{
    partial class FormGerirCoordenadores
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

        private void InitializeComponent()
        {
            this.groupBoxDados = new System.Windows.Forms.GroupBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblMorada = new System.Windows.Forms.Label();
            this.txtMorada = new System.Windows.Forms.TextBox();
            this.lblContacto = new System.Windows.Forms.Label();
            this.txtContacto = new System.Windows.Forms.TextBox();
            this.lblAreaCoordenacao = new System.Windows.Forms.Label();
            this.txtAreaCoordenacao = new System.Windows.Forms.TextBox();
            this.lblSalarioBase = new System.Windows.Forms.Label();
            this.numSalarioBase = new System.Windows.Forms.NumericUpDown();
            this.lblDataFimContrato = new System.Windows.Forms.Label();
            this.dtpDataFimContrato = new System.Windows.Forms.DateTimePicker();
            this.lblDataRegistoCriminal = new System.Windows.Forms.Label();
            this.dtpDataRegistoCriminal = new System.Windows.Forms.DateTimePicker();
            this.lblStatusRegistoCriminal = new System.Windows.Forms.Label();
            this.txtStatusRegistoCriminal = new System.Windows.Forms.TextBox();

            this.groupBoxAcoes = new System.Windows.Forms.GroupBox();
            this.btnInserirNovo = new System.Windows.Forms.Button();
            this.btnAlterarSelecionado = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnLimparCampos = new System.Windows.Forms.Button();
            this.btnCalcularValorFormacao = new System.Windows.Forms.Button();
            this.btnAlocarFormador = new System.Windows.Forms.Button();
            this.btnAtualizarRegistoCriminal = new System.Windows.Forms.Button();
            this.btnFiltrarPorDisponibilidade = new System.Windows.Forms.Button();

            this.groupBoxLista = new System.Windows.Forms.GroupBox();
            this.listViewCoordenadores = new System.Windows.Forms.ListView();
            this.columnHeaderId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderNome = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderMorada = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderContacto = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAreaCoordenacao = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderSalarioBase = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDataFimContrato = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDataRegistoCriminal = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderStatusRegistoCriminal = new System.Windows.Forms.ColumnHeader();

            this.lblTotal = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();

            this.groupBoxDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioBase)).BeginInit();
            this.groupBoxAcoes.SuspendLayout();
            this.groupBoxLista.SuspendLayout();
            this.SuspendLayout();

            // groupBoxDados
            this.groupBoxDados.Controls.Add(this.lblId);
            this.groupBoxDados.Controls.Add(this.txtId);
            this.groupBoxDados.Controls.Add(this.lblNome);
            this.groupBoxDados.Controls.Add(this.txtNome);
            this.groupBoxDados.Controls.Add(this.lblMorada);
            this.groupBoxDados.Controls.Add(this.txtMorada);
            this.groupBoxDados.Controls.Add(this.lblContacto);
            this.groupBoxDados.Controls.Add(this.txtContacto);
            this.groupBoxDados.Controls.Add(this.lblAreaCoordenacao);
            this.groupBoxDados.Controls.Add(this.txtAreaCoordenacao);
            this.groupBoxDados.Controls.Add(this.lblSalarioBase);
            this.groupBoxDados.Controls.Add(this.numSalarioBase);
            this.groupBoxDados.Controls.Add(this.lblDataFimContrato);
            this.groupBoxDados.Controls.Add(this.dtpDataFimContrato);
            this.groupBoxDados.Controls.Add(this.lblDataRegistoCriminal);
            this.groupBoxDados.Controls.Add(this.dtpDataRegistoCriminal);
            this.groupBoxDados.Controls.Add(this.lblStatusRegistoCriminal);
            this.groupBoxDados.Controls.Add(this.txtStatusRegistoCriminal);
            this.groupBoxDados.Location = new System.Drawing.Point(12, 12);
            this.groupBoxDados.Name = "groupBoxDados";
            this.groupBoxDados.Size = new System.Drawing.Size(550, 380);
            this.groupBoxDados.TabIndex = 0;
            this.groupBoxDados.TabStop = false;
            this.groupBoxDados.Text = "Dados do Coordenador";

            // lblId
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(20, 30);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";

            // txtId
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(185, 27);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(337, 20);
            this.txtId.TabIndex = 1;

            // lblNome
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(20, 60);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome:";

            // txtNome
            this.txtNome.Location = new System.Drawing.Point(185, 57);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(337, 20);
            this.txtNome.TabIndex = 3;

            // lblMorada
            this.lblMorada.AutoSize = true;
            this.lblMorada.Location = new System.Drawing.Point(20, 90);
            this.lblMorada.Name = "lblMorada";
            this.lblMorada.Size = new System.Drawing.Size(46, 13);
            this.lblMorada.TabIndex = 4;
            this.lblMorada.Text = "Morada:";

            // txtMorada
            this.txtMorada.Location = new System.Drawing.Point(185, 87);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(337, 20);
            this.txtMorada.TabIndex = 5;

            // lblContacto
            this.lblContacto.AutoSize = true;
            this.lblContacto.Location = new System.Drawing.Point(20, 120);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(53, 13);
            this.lblContacto.TabIndex = 6;
            this.lblContacto.Text = "Contacto:";

            // txtContacto
            this.txtContacto.Location = new System.Drawing.Point(185, 117);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(203, 20);
            this.txtContacto.TabIndex = 7;

            // lblAreaCoordenacao
            this.lblAreaCoordenacao.AutoSize = true;
            this.lblAreaCoordenacao.Location = new System.Drawing.Point(20, 150);
            this.lblAreaCoordenacao.Name = "lblAreaCoordenacao";
            this.lblAreaCoordenacao.Size = new System.Drawing.Size(103, 13);
            this.lblAreaCoordenacao.TabIndex = 8;
            this.lblAreaCoordenacao.Text = "Área Coordenação:";

            // txtAreaCoordenacao
            this.txtAreaCoordenacao.Location = new System.Drawing.Point(185, 147);
            this.txtAreaCoordenacao.Name = "txtAreaCoordenacao";
            this.txtAreaCoordenacao.Size = new System.Drawing.Size(337, 20);
            this.txtAreaCoordenacao.TabIndex = 9;

            // lblSalarioBase
            this.lblSalarioBase.AutoSize = true;
            this.lblSalarioBase.Location = new System.Drawing.Point(20, 210);
            this.lblSalarioBase.Name = "lblSalarioBase";
            this.lblSalarioBase.Size = new System.Drawing.Size(71, 13);
            this.lblSalarioBase.TabIndex = 12;
            this.lblSalarioBase.Text = "Salário Base:";

            // numSalarioBase
            this.numSalarioBase.DecimalPlaces = 2;
            this.numSalarioBase.Location = new System.Drawing.Point(185, 208);
            this.numSalarioBase.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            this.numSalarioBase.Name = "numSalarioBase";
            this.numSalarioBase.Size = new System.Drawing.Size(120, 20);
            this.numSalarioBase.TabIndex = 13;

            // lblDataFimContrato
            this.lblDataFimContrato.AutoSize = true;
            this.lblDataFimContrato.Location = new System.Drawing.Point(20, 240);
            this.lblDataFimContrato.Name = "lblDataFimContrato";
            this.lblDataFimContrato.Size = new System.Drawing.Size(95, 13);
            this.lblDataFimContrato.TabIndex = 14;
            this.lblDataFimContrato.Text = "Data Fim Contrato:";

            // dtpDataFimContrato
            this.dtpDataFimContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFimContrato.Location = new System.Drawing.Point(185, 238);
            this.dtpDataFimContrato.Name = "dtpDataFimContrato";
            this.dtpDataFimContrato.Size = new System.Drawing.Size(120, 20);
            this.dtpDataFimContrato.TabIndex = 15;

            // lblDataRegistoCriminal
            this.lblDataRegistoCriminal.AutoSize = true;
            this.lblDataRegistoCriminal.Location = new System.Drawing.Point(20, 270);
            this.lblDataRegistoCriminal.Name = "lblDataRegistoCriminal";
            this.lblDataRegistoCriminal.Size = new System.Drawing.Size(117, 13);
            this.lblDataRegistoCriminal.TabIndex = 16;
            this.lblDataRegistoCriminal.Text = "Data Registo Criminal:";

            // dtpDataRegistoCriminal
            this.dtpDataRegistoCriminal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataRegistoCriminal.Location = new System.Drawing.Point(185, 268);
            this.dtpDataRegistoCriminal.Name = "dtpDataRegistoCriminal";
            this.dtpDataRegistoCriminal.Size = new System.Drawing.Size(120, 20);
            this.dtpDataRegistoCriminal.TabIndex = 17;

            // lblStatusRegistoCriminal
            this.lblStatusRegistoCriminal.AutoSize = true;
            this.lblStatusRegistoCriminal.Location = new System.Drawing.Point(20, 300);
            this.lblStatusRegistoCriminal.Name = "lblStatusRegistoCriminal";
            this.lblStatusRegistoCriminal.Size = new System.Drawing.Size(128, 13);
            this.lblStatusRegistoCriminal.TabIndex = 18;
            this.lblStatusRegistoCriminal.Text = "Status Registo Criminal:";

            // txtStatusRegistoCriminal
            this.txtStatusRegistoCriminal.Enabled = false;
            this.txtStatusRegistoCriminal.Location = new System.Drawing.Point(185, 297);
            this.txtStatusRegistoCriminal.Name = "txtStatusRegistoCriminal";
            this.txtStatusRegistoCriminal.ReadOnly = true;
            this.txtStatusRegistoCriminal.Size = new System.Drawing.Size(100, 20);
            this.txtStatusRegistoCriminal.TabIndex = 19;

            // groupBoxAcoes
            this.groupBoxAcoes.Controls.Add(this.btnInserirNovo);
            this.groupBoxAcoes.Controls.Add(this.btnAlterarSelecionado);
            this.groupBoxAcoes.Controls.Add(this.btnRemover);
            this.groupBoxAcoes.Controls.Add(this.btnLimparCampos);
            this.groupBoxAcoes.Controls.Add(this.btnCalcularValorFormacao);
            this.groupBoxAcoes.Controls.Add(this.btnAlocarFormador);
            this.groupBoxAcoes.Controls.Add(this.btnAtualizarRegistoCriminal);
            this.groupBoxAcoes.Controls.Add(this.btnFiltrarPorDisponibilidade);
            this.groupBoxAcoes.Location = new System.Drawing.Point(580, 12);
            this.groupBoxAcoes.Name = "groupBoxAcoes";
            this.groupBoxAcoes.Size = new System.Drawing.Size(180, 380);
            this.groupBoxAcoes.TabIndex = 1;
            this.groupBoxAcoes.TabStop = false;
            this.groupBoxAcoes.Text = "Ações";

            // btnInserirNovo
            this.btnInserirNovo.Location = new System.Drawing.Point(15, 30);
            this.btnInserirNovo.Name = "btnInserirNovo";
            this.btnInserirNovo.Size = new System.Drawing.Size(150, 35);
            this.btnInserirNovo.TabIndex = 0;
            this.btnInserirNovo.Text = "Inserir Novo";
            this.btnInserirNovo.UseVisualStyleBackColor = true;
            this.btnInserirNovo.Click += new System.EventHandler(this.btnInserirNovo_Click);

            // btnAlterarSelecionado
            this.btnAlterarSelecionado.Location = new System.Drawing.Point(15, 75);
            this.btnAlterarSelecionado.Name = "btnAlterarSelecionado";
            this.btnAlterarSelecionado.Size = new System.Drawing.Size(150, 35);
            this.btnAlterarSelecionado.TabIndex = 1;
            this.btnAlterarSelecionado.Text = "Alterar Selecionado";
            this.btnAlterarSelecionado.UseVisualStyleBackColor = true;
            this.btnAlterarSelecionado.Click += new System.EventHandler(this.btnAlterarSelecionado_Click);

            // btnRemover
            this.btnRemover.Location = new System.Drawing.Point(15, 120);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(150, 35);
            this.btnRemover.TabIndex = 2;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);

            // btnLimparCampos
            this.btnLimparCampos.Location = new System.Drawing.Point(15, 165);
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.Size = new System.Drawing.Size(150, 35);
            this.btnLimparCampos.TabIndex = 3;
            this.btnLimparCampos.Text = "Limpar Campos";
            this.btnLimparCampos.UseVisualStyleBackColor = true;
            this.btnLimparCampos.Click += new System.EventHandler(this.btnLimparCampos_Click);

            // btnCalcularValorFormacao
            this.btnCalcularValorFormacao.Location = new System.Drawing.Point(15, 210);
            this.btnCalcularValorFormacao.Name = "btnCalcularValorFormacao";
            this.btnCalcularValorFormacao.Size = new System.Drawing.Size(150, 35);
            this.btnCalcularValorFormacao.TabIndex = 4;
            this.btnCalcularValorFormacao.Text = "Calcular Valor Formação";
            this.btnCalcularValorFormacao.UseVisualStyleBackColor = true;
            this.btnCalcularValorFormacao.Click += new System.EventHandler(this.btnCalcularValorFormacao_Click);

            // btnAlocarFormador
            this.btnAlocarFormador.Location = new System.Drawing.Point(15, 255);
            this.btnAlocarFormador.Name = "btnAlocarFormador";
            this.btnAlocarFormador.Size = new System.Drawing.Size(150, 35);
            this.btnAlocarFormador.TabIndex = 5;
            this.btnAlocarFormador.Text = "Alocar a Coordenador";
            this.btnAlocarFormador.UseVisualStyleBackColor = true;
            this.btnAlocarFormador.Click += new System.EventHandler(this.btnAlocarFormador_Click);

            // btnAtualizarRegistoCriminal
            this.btnAtualizarRegistoCriminal.Location = new System.Drawing.Point(15, 300);
            this.btnAtualizarRegistoCriminal.Name = "btnAtualizarRegistoCriminal";
            this.btnAtualizarRegistoCriminal.Size = new System.Drawing.Size(150, 35);
            this.btnAtualizarRegistoCriminal.TabIndex = 6;
            this.btnAtualizarRegistoCriminal.Text = "Atualizar Registo Criminal";
            this.btnAtualizarRegistoCriminal.UseVisualStyleBackColor = true;
            this.btnAtualizarRegistoCriminal.Click += new System.EventHandler(this.btnAtualizarRegistoCriminal_Click);

            // btnFiltrarPorDisponibilidade
            this.btnFiltrarPorDisponibilidade.Location = new System.Drawing.Point(15, 345);
            this.btnFiltrarPorDisponibilidade.Name = "btnFiltrarPorDisponibilidade";
            this.btnFiltrarPorDisponibilidade.Size = new System.Drawing.Size(150, 35);
            this.btnFiltrarPorDisponibilidade.TabIndex = 7;
            this.btnFiltrarPorDisponibilidade.Text = "Filtrar por Disponibilidade";
            this.btnFiltrarPorDisponibilidade.UseVisualStyleBackColor = true;
            this.btnFiltrarPorDisponibilidade.Click += new System.EventHandler(this.btnFiltrarPorDisponibilidade_Click);

            // groupBoxLista
            this.groupBoxLista.Controls.Add(this.listViewCoordenadores);
            this.groupBoxLista.Location = new System.Drawing.Point(12, 410);
            this.groupBoxLista.Name = "groupBoxLista";
            this.groupBoxLista.Size = new System.Drawing.Size(748, 250);
            this.groupBoxLista.TabIndex = 2;
            this.groupBoxLista.TabStop = false;
            this.groupBoxLista.Text = "Lista de Coordenadores";

            // listViewCoordenadores
            this.listViewCoordenadores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                this.columnHeaderId,
                this.columnHeaderNome,
                this.columnHeaderMorada,
                this.columnHeaderContacto,
                this.columnHeaderAreaCoordenacao,
                this.columnHeaderSalarioBase,
                this.columnHeaderDataFimContrato,
                this.columnHeaderDataRegistoCriminal,
                this.columnHeaderStatusRegistoCriminal});
            this.listViewCoordenadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewCoordenadores.FullRowSelect = true;
            this.listViewCoordenadores.GridLines = true;
            this.listViewCoordenadores.Location = new System.Drawing.Point(3, 16);
            this.listViewCoordenadores.MultiSelect = false;
            this.listViewCoordenadores.Name = "listViewCoordenadores";
            this.listViewCoordenadores.Size = new System.Drawing.Size(742, 231);
            this.listViewCoordenadores.TabIndex = 0;
            this.listViewCoordenadores.UseCompatibleStateImageBehavior = false;
            this.listViewCoordenadores.View = System.Windows.Forms.View.Details;
            this.listViewCoordenadores.SelectedIndexChanged += new System.EventHandler(this.listViewCoordenadores_SelectedIndexChanged);

            // columnHeaderId
            this.columnHeaderId.Text = "ID";
            this.columnHeaderId.Width = 40;

            // columnHeaderNome
            this.columnHeaderNome.Text = "Nome";
            this.columnHeaderNome.Width = 150;

            // columnHeaderMorada
            this.columnHeaderMorada.Text = "Morada";
            this.columnHeaderMorada.Width = 120;

            // columnHeaderContacto
            this.columnHeaderContacto.Text = "Contacto";
            this.columnHeaderContacto.Width = 90;

            // columnHeaderAreaCoordenacao
            this.columnHeaderAreaCoordenacao.Text = "Área Coordenação";
            this.columnHeaderAreaCoordenacao.Width = 120;

            // columnHeaderSalarioBase
            this.columnHeaderSalarioBase.Text = "Salário Base";
            this.columnHeaderSalarioBase.Width = 80;

            // columnHeaderDataFimContrato
            this.columnHeaderDataFimContrato.Text = "Data Fim Contrato";
            this.columnHeaderDataFimContrato.Width = 110;

            // columnHeaderDataRegistoCriminal
            this.columnHeaderDataRegistoCriminal.Text = "Data Registo Criminal";
            this.columnHeaderDataRegistoCriminal.Width = 130;

            // columnHeaderStatusRegistoCriminal
            this.columnHeaderStatusRegistoCriminal.Text = "Status Registo Criminal";
            this.columnHeaderStatusRegistoCriminal.Width = 130;

            // lblTotal
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(15, 670);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(170, 15);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total de Coordenadores: 0";

            // btnFechar
            this.btnFechar.Location = new System.Drawing.Point(660, 665);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(100, 30);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);

            // FormGerirCoordenadores
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 711);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.groupBoxLista);
            this.Controls.Add(this.groupBoxAcoes);
            this.Controls.Add(this.groupBoxDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormGerirCoordenadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestão de Coordenadores - ADOSMELHORES";
            this.groupBoxDados.ResumeLayout(false);
            this.groupBoxDados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioBase)).EndInit();
            this.groupBoxAcoes.ResumeLayout(false);
            this.groupBoxLista.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox groupBoxDados;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblMorada;
        private System.Windows.Forms.TextBox txtMorada;
        private System.Windows.Forms.Label lblContacto;
        private System.Windows.Forms.TextBox txtContacto;
        private System.Windows.Forms.Label lblAreaCoordenacao;
        private System.Windows.Forms.TextBox txtAreaCoordenacao;
        private System.Windows.Forms.Label lblSalarioBase;
        private System.Windows.Forms.NumericUpDown numSalarioBase;
        private System.Windows.Forms.Label lblDataFimContrato;
        private System.Windows.Forms.DateTimePicker dtpDataFimContrato;
        private System.Windows.Forms.Label lblDataRegistoCriminal;
        private System.Windows.Forms.DateTimePicker dtpDataRegistoCriminal;
        private System.Windows.Forms.Label lblStatusRegistoCriminal;
        private System.Windows.Forms.TextBox txtStatusRegistoCriminal;

        private System.Windows.Forms.GroupBox groupBoxAcoes;
        private System.Windows.Forms.Button btnInserirNovo;
        private System.Windows.Forms.Button btnAlterarSelecionado;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnLimparCampos;
        private System.Windows.Forms.Button btnCalcularValorFormacao;
        private System.Windows.Forms.Button btnAlocarFormador;
        private System.Windows.Forms.Button btnAtualizarRegistoCriminal;
        private System.Windows.Forms.Button btnFiltrarPorDisponibilidade;

        private System.Windows.Forms.GroupBox groupBoxLista;
        private System.Windows.Forms.ListView listViewCoordenadores;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderNome;
        private System.Windows.Forms.ColumnHeader columnHeaderMorada;
        private System.Windows.Forms.ColumnHeader columnHeaderContacto;
        private System.Windows.Forms.ColumnHeader columnHeaderAreaCoordenacao;
        private System.Windows.Forms.ColumnHeader columnHeaderSalarioBase;
        private System.Windows.Forms.ColumnHeader columnHeaderDataFimContrato;
        private System.Windows.Forms.ColumnHeader columnHeaderDataRegistoCriminal;
        private System.Windows.Forms.ColumnHeader columnHeaderStatusRegistoCriminal;

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Button btnFechar;
    }
}
