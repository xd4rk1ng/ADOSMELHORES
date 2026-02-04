namespace ADOSMELHORES.Forms.Coordenadores
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
            this.txtNIF = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
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
            this.btnAlocarFormador = new System.Windows.Forms.Button();
            this.btnListaFormadoresAlocados = new System.Windows.Forms.Button();
            this.btnAtualizarRegistoCriminal = new System.Windows.Forms.Button();
            this.groupBoxLista = new System.Windows.Forms.GroupBox();
            this.listViewCoordenadores = new System.Windows.Forms.ListView();
            this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderNome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderMorada = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderContacto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderAreaCoordenacao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSalarioBase = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDataFimContrato = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderDataRegistoCriminal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderStatusRegistoCriminal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTotal = new System.Windows.Forms.Label();
            this.btnFechar = new System.Windows.Forms.Button();
            this.groupBoxDados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioBase)).BeginInit();
            this.groupBoxAcoes.SuspendLayout();
            this.groupBoxLista.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxDados
            // 
            this.groupBoxDados.Controls.Add(this.txtNIF);
            this.groupBoxDados.Controls.Add(this.label1);
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
            this.groupBoxDados.Location = new System.Drawing.Point(16, 15);
            this.groupBoxDados.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxDados.Name = "groupBoxDados";
            this.groupBoxDados.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxDados.Size = new System.Drawing.Size(733, 468);
            this.groupBoxDados.TabIndex = 0;
            this.groupBoxDados.TabStop = false;
            this.groupBoxDados.Text = "Dados do Coordenador";
            this.groupBoxDados.Enter += new System.EventHandler(this.groupBoxDados_Enter);
            // 
            // txtNIF
            // 
            this.txtNIF.Location = new System.Drawing.Point(247, 86);
            this.txtNIF.Name = "txtNIF";
            this.txtNIF.Size = new System.Drawing.Size(159, 22);
            this.txtNIF.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 16);
            this.label1.TabIndex = 20;
            this.label1.Text = "NIF";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(27, 37);
            this.lblId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(23, 16);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Location = new System.Drawing.Point(247, 33);
            this.txtId.Margin = new System.Windows.Forms.Padding(4);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(448, 22);
            this.txtId.TabIndex = 1;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(27, 119);
            this.lblNome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(47, 16);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(247, 116);
            this.txtNome.Margin = new System.Windows.Forms.Padding(4);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(448, 22);
            this.txtNome.TabIndex = 3;
            // 
            // lblMorada
            // 
            this.lblMorada.AutoSize = true;
            this.lblMorada.Location = new System.Drawing.Point(27, 148);
            this.lblMorada.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMorada.Name = "lblMorada";
            this.lblMorada.Size = new System.Drawing.Size(57, 16);
            this.lblMorada.TabIndex = 4;
            this.lblMorada.Text = "Morada:";
            // 
            // txtMorada
            // 
            this.txtMorada.Location = new System.Drawing.Point(247, 145);
            this.txtMorada.Margin = new System.Windows.Forms.Padding(4);
            this.txtMorada.Name = "txtMorada";
            this.txtMorada.Size = new System.Drawing.Size(448, 22);
            this.txtMorada.TabIndex = 5;
            // 
            // lblContacto
            // 
            this.lblContacto.AutoSize = true;
            this.lblContacto.Location = new System.Drawing.Point(27, 184);
            this.lblContacto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContacto.Name = "lblContacto";
            this.lblContacto.Size = new System.Drawing.Size(63, 16);
            this.lblContacto.TabIndex = 6;
            this.lblContacto.Text = "Contacto:";
            // 
            // txtContacto
            // 
            this.txtContacto.Location = new System.Drawing.Point(247, 178);
            this.txtContacto.Margin = new System.Windows.Forms.Padding(4);
            this.txtContacto.Name = "txtContacto";
            this.txtContacto.Size = new System.Drawing.Size(269, 22);
            this.txtContacto.TabIndex = 7;
            // 
            // lblAreaCoordenacao
            // 
            this.lblAreaCoordenacao.AutoSize = true;
            this.lblAreaCoordenacao.Location = new System.Drawing.Point(27, 216);
            this.lblAreaCoordenacao.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAreaCoordenacao.Name = "lblAreaCoordenacao";
            this.lblAreaCoordenacao.Size = new System.Drawing.Size(125, 16);
            this.lblAreaCoordenacao.TabIndex = 8;
            this.lblAreaCoordenacao.Text = "Área Coordenação:";
            // 
            // txtAreaCoordenacao
            // 
            this.txtAreaCoordenacao.Location = new System.Drawing.Point(247, 210);
            this.txtAreaCoordenacao.Margin = new System.Windows.Forms.Padding(4);
            this.txtAreaCoordenacao.Name = "txtAreaCoordenacao";
            this.txtAreaCoordenacao.Size = new System.Drawing.Size(448, 22);
            this.txtAreaCoordenacao.TabIndex = 9;
            // 
            // lblSalarioBase
            // 
            this.lblSalarioBase.AutoSize = true;
            this.lblSalarioBase.Location = new System.Drawing.Point(27, 258);
            this.lblSalarioBase.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalarioBase.Name = "lblSalarioBase";
            this.lblSalarioBase.Size = new System.Drawing.Size(88, 16);
            this.lblSalarioBase.TabIndex = 12;
            this.lblSalarioBase.Text = "Salário Base:";
            // 
            // numSalarioBase
            // 
            this.numSalarioBase.DecimalPlaces = 2;
            this.numSalarioBase.Location = new System.Drawing.Point(247, 256);
            this.numSalarioBase.Margin = new System.Windows.Forms.Padding(4);
            this.numSalarioBase.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSalarioBase.Name = "numSalarioBase";
            this.numSalarioBase.Size = new System.Drawing.Size(160, 22);
            this.numSalarioBase.TabIndex = 13;
            // 
            // lblDataFimContrato
            // 
            this.lblDataFimContrato.AutoSize = true;
            this.lblDataFimContrato.Location = new System.Drawing.Point(27, 295);
            this.lblDataFimContrato.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataFimContrato.Name = "lblDataFimContrato";
            this.lblDataFimContrato.Size = new System.Drawing.Size(117, 16);
            this.lblDataFimContrato.TabIndex = 14;
            this.lblDataFimContrato.Text = "Data Fim Contrato:";
            // 
            // dtpDataFimContrato
            // 
            this.dtpDataFimContrato.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataFimContrato.Location = new System.Drawing.Point(247, 293);
            this.dtpDataFimContrato.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDataFimContrato.Name = "dtpDataFimContrato";
            this.dtpDataFimContrato.Size = new System.Drawing.Size(159, 22);
            this.dtpDataFimContrato.TabIndex = 15;
            // 
            // lblDataRegistoCriminal
            // 
            this.lblDataRegistoCriminal.AutoSize = true;
            this.lblDataRegistoCriminal.Location = new System.Drawing.Point(27, 332);
            this.lblDataRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDataRegistoCriminal.Name = "lblDataRegistoCriminal";
            this.lblDataRegistoCriminal.Size = new System.Drawing.Size(140, 16);
            this.lblDataRegistoCriminal.TabIndex = 16;
            this.lblDataRegistoCriminal.Text = "Data Registo Criminal:";
            // 
            // dtpDataRegistoCriminal
            // 
            this.dtpDataRegistoCriminal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDataRegistoCriminal.Location = new System.Drawing.Point(247, 330);
            this.dtpDataRegistoCriminal.Margin = new System.Windows.Forms.Padding(4);
            this.dtpDataRegistoCriminal.Name = "dtpDataRegistoCriminal";
            this.dtpDataRegistoCriminal.Size = new System.Drawing.Size(159, 22);
            this.dtpDataRegistoCriminal.TabIndex = 17;
            // 
            // lblStatusRegistoCriminal
            // 
            this.lblStatusRegistoCriminal.AutoSize = true;
            this.lblStatusRegistoCriminal.Location = new System.Drawing.Point(27, 369);
            this.lblStatusRegistoCriminal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatusRegistoCriminal.Name = "lblStatusRegistoCriminal";
            this.lblStatusRegistoCriminal.Size = new System.Drawing.Size(148, 16);
            this.lblStatusRegistoCriminal.TabIndex = 18;
            this.lblStatusRegistoCriminal.Text = "Status Registo Criminal:";
            // 
            // txtStatusRegistoCriminal
            // 
            this.txtStatusRegistoCriminal.Enabled = false;
            this.txtStatusRegistoCriminal.Location = new System.Drawing.Point(247, 366);
            this.txtStatusRegistoCriminal.Margin = new System.Windows.Forms.Padding(4);
            this.txtStatusRegistoCriminal.Name = "txtStatusRegistoCriminal";
            this.txtStatusRegistoCriminal.ReadOnly = true;
            this.txtStatusRegistoCriminal.Size = new System.Drawing.Size(132, 22);
            this.txtStatusRegistoCriminal.TabIndex = 19;
            // 
            // groupBoxAcoes
            // 
            this.groupBoxAcoes.Controls.Add(this.btnInserirNovo);
            this.groupBoxAcoes.Controls.Add(this.btnAlterarSelecionado);
            this.groupBoxAcoes.Controls.Add(this.btnRemover);
            this.groupBoxAcoes.Controls.Add(this.btnLimparCampos);
            this.groupBoxAcoes.Controls.Add(this.btnAlocarFormador);
            this.groupBoxAcoes.Controls.Add(this.btnListaFormadoresAlocados);
            this.groupBoxAcoes.Controls.Add(this.btnAtualizarRegistoCriminal);
            this.groupBoxAcoes.Location = new System.Drawing.Point(773, 15);
            this.groupBoxAcoes.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxAcoes.Name = "groupBoxAcoes";
            this.groupBoxAcoes.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxAcoes.Size = new System.Drawing.Size(240, 468);
            this.groupBoxAcoes.TabIndex = 1;
            this.groupBoxAcoes.TabStop = false;
            this.groupBoxAcoes.Text = "Ações";
            // 
            // btnInserirNovo
            // 
            this.btnInserirNovo.Location = new System.Drawing.Point(20, 37);
            this.btnInserirNovo.Margin = new System.Windows.Forms.Padding(4);
            this.btnInserirNovo.Name = "btnInserirNovo";
            this.btnInserirNovo.Size = new System.Drawing.Size(200, 43);
            this.btnInserirNovo.TabIndex = 0;
            this.btnInserirNovo.Text = "Inserir Novo";
            this.btnInserirNovo.UseVisualStyleBackColor = true;
            this.btnInserirNovo.Click += new System.EventHandler(this.btnInserirNovo_Click);
            // 
            // btnAlterarSelecionado
            // 
            this.btnAlterarSelecionado.Location = new System.Drawing.Point(20, 92);
            this.btnAlterarSelecionado.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlterarSelecionado.Name = "btnAlterarSelecionado";
            this.btnAlterarSelecionado.Size = new System.Drawing.Size(200, 43);
            this.btnAlterarSelecionado.TabIndex = 1;
            this.btnAlterarSelecionado.Text = "Alterar Selecionado";
            this.btnAlterarSelecionado.UseVisualStyleBackColor = true;
            this.btnAlterarSelecionado.Click += new System.EventHandler(this.btnAlterarSelecionado_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(20, 148);
            this.btnRemover.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(200, 43);
            this.btnRemover.TabIndex = 2;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnLimparCampos
            // 
            this.btnLimparCampos.Location = new System.Drawing.Point(20, 203);
            this.btnLimparCampos.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimparCampos.Name = "btnLimparCampos";
            this.btnLimparCampos.Size = new System.Drawing.Size(200, 43);
            this.btnLimparCampos.TabIndex = 3;
            this.btnLimparCampos.Text = "Limpar Campos";
            this.btnLimparCampos.UseVisualStyleBackColor = true;
            this.btnLimparCampos.Click += new System.EventHandler(this.btnLimparCampos_Click);
            // 
            // btnAlocarFormador
            // 
            this.btnAlocarFormador.Location = new System.Drawing.Point(20, 258);
            this.btnAlocarFormador.Margin = new System.Windows.Forms.Padding(4);
            this.btnAlocarFormador.Name = "btnAlocarFormador";
            this.btnAlocarFormador.Size = new System.Drawing.Size(200, 43);
            this.btnAlocarFormador.TabIndex = 5;
            this.btnAlocarFormador.Text = "Alocar formador";
            this.btnAlocarFormador.UseVisualStyleBackColor = true;
            this.btnAlocarFormador.Click += new System.EventHandler(this.btnAlocarFormador_Click);
            // 
            // btnListaFormadoresAlocados
            // 
            this.btnListaFormadoresAlocados.Location = new System.Drawing.Point(20, 314);
            this.btnListaFormadoresAlocados.Margin = new System.Windows.Forms.Padding(4);
            this.btnListaFormadoresAlocados.Name = "btnListaFormadoresAlocados";
            this.btnListaFormadoresAlocados.Size = new System.Drawing.Size(200, 43);
            this.btnListaFormadoresAlocados.TabIndex = 8;
            this.btnListaFormadoresAlocados.Text = "Lista de formadores alocados";
            this.btnListaFormadoresAlocados.UseVisualStyleBackColor = true;
            this.btnListaFormadoresAlocados.Click += new System.EventHandler(this.btnListaFormadoresAlocados_Click);
            // 
            // btnAtualizarRegistoCriminal
            // 
            this.btnAtualizarRegistoCriminal.Location = new System.Drawing.Point(20, 360);
            this.btnAtualizarRegistoCriminal.Margin = new System.Windows.Forms.Padding(4);
            this.btnAtualizarRegistoCriminal.Name = "btnAtualizarRegistoCriminal";
            this.btnAtualizarRegistoCriminal.Size = new System.Drawing.Size(200, 43);
            this.btnAtualizarRegistoCriminal.TabIndex = 6;
            this.btnAtualizarRegistoCriminal.Text = "Atualizar Registo Criminal";
            this.btnAtualizarRegistoCriminal.UseVisualStyleBackColor = true;
            this.btnAtualizarRegistoCriminal.Click += new System.EventHandler(this.btnAtualizarRegistoCriminal_Click);
            // 
            // groupBoxLista
            // 
            this.groupBoxLista.Controls.Add(this.listViewCoordenadores);
            this.groupBoxLista.Location = new System.Drawing.Point(16, 505);
            this.groupBoxLista.Margin = new System.Windows.Forms.Padding(4);
            this.groupBoxLista.Name = "groupBoxLista";
            this.groupBoxLista.Padding = new System.Windows.Forms.Padding(4);
            this.groupBoxLista.Size = new System.Drawing.Size(997, 308);
            this.groupBoxLista.TabIndex = 2;
            this.groupBoxLista.TabStop = false;
            this.groupBoxLista.Text = "Lista de Coordenadores";
            // 
            // listViewCoordenadores
            // 
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
            this.listViewCoordenadores.HideSelection = false;
            this.listViewCoordenadores.Location = new System.Drawing.Point(4, 19);
            this.listViewCoordenadores.Margin = new System.Windows.Forms.Padding(4);
            this.listViewCoordenadores.MultiSelect = false;
            this.listViewCoordenadores.Name = "listViewCoordenadores";
            this.listViewCoordenadores.Size = new System.Drawing.Size(989, 285);
            this.listViewCoordenadores.TabIndex = 0;
            this.listViewCoordenadores.UseCompatibleStateImageBehavior = false;
            this.listViewCoordenadores.View = System.Windows.Forms.View.Details;
            this.listViewCoordenadores.SelectedIndexChanged += new System.EventHandler(this.listViewCoordenadores_SelectedIndexChanged);
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            this.columnHeaderId.Width = 40;
            // 
            // columnHeaderNome
            // 
            this.columnHeaderNome.Text = "Nome";
            this.columnHeaderNome.Width = 150;
            // 
            // columnHeaderMorada
            // 
            this.columnHeaderMorada.Text = "Morada";
            this.columnHeaderMorada.Width = 120;
            // 
            // columnHeaderContacto
            // 
            this.columnHeaderContacto.Text = "Contacto";
            this.columnHeaderContacto.Width = 90;
            // 
            // columnHeaderAreaCoordenacao
            // 
            this.columnHeaderAreaCoordenacao.Text = "Área Coordenação";
            this.columnHeaderAreaCoordenacao.Width = 120;
            // 
            // columnHeaderSalarioBase
            // 
            this.columnHeaderSalarioBase.Text = "Salário Base";
            this.columnHeaderSalarioBase.Width = 80;
            // 
            // columnHeaderDataFimContrato
            // 
            this.columnHeaderDataFimContrato.Text = "Data Fim Contrato";
            this.columnHeaderDataFimContrato.Width = 110;
            // 
            // columnHeaderDataRegistoCriminal
            // 
            this.columnHeaderDataRegistoCriminal.Text = "Data Registo Criminal";
            this.columnHeaderDataRegistoCriminal.Width = 130;
            // 
            // columnHeaderStatusRegistoCriminal
            // 
            this.columnHeaderStatusRegistoCriminal.Text = "Status Registo Criminal";
            this.columnHeaderStatusRegistoCriminal.Width = 130;
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 825);
            this.lblTotal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(210, 18);
            this.lblTotal.TabIndex = 3;
            this.lblTotal.Text = "Total de Coordenadores: 0";
            // 
            // btnFechar
            // 
            this.btnFechar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFechar.Location = new System.Drawing.Point(880, 818);
            this.btnFechar.Margin = new System.Windows.Forms.Padding(4);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(133, 37);
            this.btnFechar.TabIndex = 4;
            this.btnFechar.Text = "Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // FormGerirCoordenadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 875);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.groupBoxLista);
            this.Controls.Add(this.groupBoxAcoes);
            this.Controls.Add(this.groupBoxDados);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
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
        private System.Windows.Forms.Button btnAlocarFormador;
        private System.Windows.Forms.Button btnListaFormadoresAlocados;
        private System.Windows.Forms.Button btnAtualizarRegistoCriminal;

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
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNIF;
    }
}
