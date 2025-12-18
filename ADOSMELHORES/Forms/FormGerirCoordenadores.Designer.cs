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
            this.listViewCoordenadores = new System.Windows.Forms.ListView();
            this.columnHeaderNome = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderId = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderMorada = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderTelefone = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderEmail = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderNIF = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDataNascimento = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderDataContrato = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderSalario = new System.Windows.Forms.ColumnHeader();
            this.columnHeaderAreaFormacao = new System.Windows.Forms.ColumnHeader();
            this.btnAdicionar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnCalcularCusto = new System.Windows.Forms.Button();
            this.btnAtualizarRegistoCriminal = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimparFiltro = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewCoordenadores
            // 
            this.listViewCoordenadores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderNome,
            this.columnHeaderId,
            this.columnHeaderMorada,
            this.columnHeaderTelefone,
            this.columnHeaderEmail,
            this.columnHeaderNIF,
            this.columnHeaderDataNascimento,
            this.columnHeaderDataContrato,
            this.columnHeaderSalario,
            this.columnHeaderAreaFormacao});
            this.listViewCoordenadores.FullRowSelect = true;
            this.listViewCoordenadores.GridLines = true;
            this.listViewCoordenadores.Location = new System.Drawing.Point(12, 50);
            this.listViewCoordenadores.Name = "listViewCoordenadores";
            this.listViewCoordenadores.Size = new System.Drawing.Size(960, 400);
            this.listViewCoordenadores.TabIndex = 0;
            this.listViewCoordenadores.UseCompatibleStateImageBehavior = false;
            this.listViewCoordenadores.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderNome
            // 
            this.columnHeaderNome.Text = "Nome";
            this.columnHeaderNome.Width = 150;
            // 
            // columnHeaderId
            // 
            this.columnHeaderId.Text = "ID";
            this.columnHeaderId.Width = 50;
            // 
            // columnHeaderMorada
            // 
            this.columnHeaderMorada.Text = "Morada";
            this.columnHeaderMorada.Width = 120;
            // 
            // columnHeaderTelefone
            // 
            this.columnHeaderTelefone.Text = "Telefone";
            this.columnHeaderTelefone.Width = 100;
            // 
            // columnHeaderEmail
            // 
            this.columnHeaderEmail.Text = "Email";
            this.columnHeaderEmail.Width = 150;
            // 
            // columnHeaderNIF
            // 
            this.columnHeaderNIF.Text = "NIF";
            this.columnHeaderNIF.Width = 90;
            // 
            // columnHeaderDataNascimento
            // 
            this.columnHeaderDataNascimento.Text = "Data Nascimento";
            this.columnHeaderDataNascimento.Width = 110;
            // 
            // columnHeaderDataContrato
            // 
            this.columnHeaderDataContrato.Text = "Data Contrato";
            this.columnHeaderDataContrato.Width = 100;
            // 
            // columnHeaderSalario
            // 
            this.columnHeaderSalario.Text = "Salário";
            this.columnHeaderSalario.Width = 90;
            // 
            // columnHeaderAreaFormacao
            // 
            this.columnHeaderAreaFormacao.Text = "Área Formação";
            this.columnHeaderAreaFormacao.Width = 120;
            // 
            // btnAdicionar
            // 
            this.btnAdicionar.Location = new System.Drawing.Point(12, 460);
            this.btnAdicionar.Name = "btnAdicionar";
            this.btnAdicionar.Size = new System.Drawing.Size(110, 30);
            this.btnAdicionar.TabIndex = 1;
            this.btnAdicionar.Text = "Adicionar";
            this.btnAdicionar.UseVisualStyleBackColor = true;
            this.btnAdicionar.Click += new System.EventHandler(this.btnAdicionar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(128, 460);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(110, 30);
            this.btnEditar.TabIndex = 2;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(244, 460);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(110, 30);
            this.btnRemover.TabIndex = 3;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnCalcularCusto
            // 
            this.btnCalcularCusto.Location = new System.Drawing.Point(360, 460);
            this.btnCalcularCusto.Name = "btnCalcularCusto";
            this.btnCalcularCusto.Size = new System.Drawing.Size(130, 30);
            this.btnCalcularCusto.TabIndex = 4;
            this.btnCalcularCusto.Text = "Calcular Custo";
            this.btnCalcularCusto.UseVisualStyleBackColor = true;
            this.btnCalcularCusto.Click += new System.EventHandler(this.btnCalcularCusto_Click);
            // 
            // btnAtualizarRegistoCriminal
            // 
            this.btnAtualizarRegistoCriminal.Location = new System.Drawing.Point(496, 460);
            this.btnAtualizarRegistoCriminal.Name = "btnAtualizarRegistoCriminal";
            this.btnAtualizarRegistoCriminal.Size = new System.Drawing.Size(180, 30);
            this.btnAtualizarRegistoCriminal.TabIndex = 5;
            this.btnAtualizarRegistoCriminal.Text = "Atualizar Registo Criminal";
            this.btnAtualizarRegistoCriminal.UseVisualStyleBackColor = true;
            //this.btnAtualizarRegistoCriminal.Click += new System.EventHandler(this.btnAtualizarRegistoCriminal_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(12, 496);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(110, 30);
            this.btnFiltrar.TabIndex = 6;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            //this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnLimparFiltro
            // 
            this.btnLimparFiltro.Location = new System.Drawing.Point(128, 496);
            this.btnLimparFiltro.Name = "btnLimparFiltro";
            this.btnLimparFiltro.Size = new System.Drawing.Size(110, 30);
            this.btnLimparFiltro.TabIndex = 7;
            this.btnLimparFiltro.Text = "Limpar Filtro";
            this.btnLimparFiltro.UseVisualStyleBackColor = true;
            this.btnLimparFiltro.Click += new System.EventHandler(this.btnLimparFiltro_Click);
            // 
            // btnVoltar
            // 
            this.btnVoltar.Location = new System.Drawing.Point(862, 496);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(110, 30);
            this.btnVoltar.TabIndex = 8;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(12, 535);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(200, 15);
            this.lblTotal.TabIndex = 9;
            this.lblTotal.Text = "Total de Coordenadores: 0";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(217, 24);
            this.lblTitulo.TabIndex = 10;
            this.lblTitulo.Text = "Gerir Coordenadores";
            // 
            // FormGerirCoordenadores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnVoltar);
            this.Controls.Add(this.btnLimparFiltro);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnAtualizarRegistoCriminal);
            this.Controls.Add(this.btnCalcularCusto);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnAdicionar);
            this.Controls.Add(this.listViewCoordenadores);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormGerirCoordenadores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerir Coordenadores - ADOS MELHORES";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ListView listViewCoordenadores;
        private System.Windows.Forms.ColumnHeader columnHeaderNome;
        private System.Windows.Forms.ColumnHeader columnHeaderId;
        private System.Windows.Forms.ColumnHeader columnHeaderMorada;
        private System.Windows.Forms.ColumnHeader columnHeaderTelefone;
        private System.Windows.Forms.ColumnHeader columnHeaderEmail;
        private System.Windows.Forms.ColumnHeader columnHeaderNIF;
        private System.Windows.Forms.ColumnHeader columnHeaderDataNascimento;
        private System.Windows.Forms.ColumnHeader columnHeaderDataContrato;
        private System.Windows.Forms.ColumnHeader columnHeaderSalario;
        private System.Windows.Forms.ColumnHeader columnHeaderAreaFormacao;
        private System.Windows.Forms.Button btnAdicionar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnCalcularCusto;
        private System.Windows.Forms.Button btnAtualizarRegistoCriminal;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimparFiltro;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTitulo;
    }
}