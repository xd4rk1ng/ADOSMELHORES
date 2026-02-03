using ADOSMELHORES;
using ADOSMELHORES.Forms;
using ADOSMELHORES.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADOSMELHORES.Forms.Despesas;
using ADOSMELHORES.Modelos.Despesas;

namespace ADOSMELHORES.Forms.Despesas
{
    public partial class FormDespesas : Form
    {
        private Empresa empresa;
        private GestorDespesas gestorDespesas;
        private int mesAtual;
        private int anoAtual;
        public FormDespesas(Modelos.Empresa empresaRef)
        {
            InitializeComponent();
            empresa = empresaRef ?? throw new ArgumentNullException(nameof(empresaRef));
            gestorDespesas = empresa.GestorDespesas;

            // Mês e ano atuais
            mesAtual = DateTime.Now.Month;
            anoAtual = DateTime.Now.Year;

            ConfigurarFormulario();
            CarregarMesesAnos();
            AtualizarDados();
        }
        private void ConfigurarFormulario()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            // eventos nos botoes
            if (btnAdicionar != null)
                btnAdicionar.Click += BtnAdicionar_Click;

            if (btnExportar != null)
                btnExportar.Click += BtnExportar_Click;

            if (btnFechar != null)
                btnFechar.Click += BtnFechar_Click;

            if (btnAtualizar != null)
                btnAtualizar.Click += BtnAtualizar_Click;

            // eventos dos seletores
            if (cmbMes != null)
                cmbMes.SelectedIndexChanged += CmbMesAno_SelectedIndexChanged;

            if (numAno != null)
                numAno.ValueChanged += CmbMesAno_SelectedIndexChanged;

            // Configurar DataGridView
            if (dgvHistorico != null)
                ConfigurarDataGridView();
        }
               
        private void CarregarMesesAnos()
        {
            // Carregar meses no ComboBox
            if (cmbMes != null)
            {
                cmbMes.Items.Clear();
                for (int mes = 1; mes <= 12; mes++)
                {
                    cmbMes.Items.Add(RelatorioDespesas.ObterNomeMes(mes));
                }
                cmbMes.SelectedIndex = mesAtual - 1; // Selecionar mês atual
            }

            // Configurar NumericUpDown de ano
            if (numAno != null)
            {
                numAno.Minimum = 2020;
                numAno.Maximum = 2030;
                numAno.Value = anoAtual; // Selecionar ano atual
            }
        }


        private void ConfigurarDataGridView()
        {
            if (dgvHistorico == null)
                return;

            dgvHistorico.Columns.Clear();
            dgvHistorico.AutoGenerateColumns = false;
            dgvHistorico.AllowUserToAddRows = false;
            dgvHistorico.AllowUserToDeleteRows = false;
            dgvHistorico.ReadOnly = true;
            dgvHistorico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistorico.MultiSelect = false;

            // Adicionar colunas
            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Período",
                DataPropertyName = "Periodo",
                Width = 150
            });

            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Despesas Físicas",
                DataPropertyName = "DespesasFisicasFormatado",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Funcionários",
                DataPropertyName = "TotalFuncionariosFormatado",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight }
            });

            dgvHistorico.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Total",
                DataPropertyName = "TotalDespesasFormatado",
                Width = 150,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight, Font = new Font(dgvHistorico.Font, FontStyle.Bold) }
            });
        }

         /// Atualiza todos os dados do formulário
   
        private void AtualizarDados()
        {
            try
            {
                // Obter mês e ano selecionados
                int mes = cmbMes != null ? cmbMes.SelectedIndex + 1 : mesAtual;
                int ano = numAno != null ? (int)numAno.Value : anoAtual;

                // Gerar relatório do mês
                var relatorio = gestorDespesas.GerarRelatorioMes(mes, ano);

                // Atualizar labels de resumo
                AtualizarResumo(relatorio);

                // Atualizar despesas na txtBoxDespesasFisicas
                AtualizarListBoxDespesasFisicas();

                // Atualizar histórico
                AtualizarHistorico(ano);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao atualizar dados: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// Atualiza a ListBox de despesas físicas
        private void AtualizarListBoxDespesasFisicas()
        {            
            if (lstDespesasFisicas == null)
                return;

            try
            {
                // Obter mês e ano selecionados
                int mes = cmbMes.SelectedIndex + 1;
                int ano = (int)numAno.Value;

                // Limpar ListBox
                lstDespesasFisicas.Items.Clear();

                // Obter despesas do mês
                var despesas = gestorDespesas.ObterDespesasFisicasPorMes(mes, ano);

                // Verificar se há despesas
                if (despesas.Count == 0)
                {
                    lstDespesasFisicas.Items.Add("Nenhuma despesa cadastrada.");
                    return;
                }

                // Adicionar cada despesa
                foreach (var d in despesas)
                {
                    string linha = $"{d.Data:dd/MM} │ {d.TipoDescricao,-24} │ €{d.Valor,8:N2}";
                    lstDespesasFisicas.Items.Add(linha);
                }

                // Total
                lstDespesasFisicas.Items.Add("".PadRight(55, '─'));
                decimal total = despesas.Sum(x => x.Valor);
                lstDespesasFisicas.Items.Add($"TOTAL: €{total:N2}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// Atualiza o painel de resumo com os dados do relatório
        /// </summary>
        private void AtualizarResumo(RelatorioDespesas relatorio)
        {
            // Atualizar labels (verificar se existem no Designer)
            if (lblPeriodo != null)
                lblPeriodo.Text = relatorio.Periodo;

            if (lblDespesasFisicas != null)
                lblDespesasFisicas.Text = $"€{relatorio.DespesasFisicas:N2}";

            if (lblTotalDiretores != null)
                lblTotalDiretores.Text = $"€{relatorio.DespesasDiretores:N2}";

            if (lblTotalSecretarias != null)
                lblTotalSecretarias.Text = $"€{relatorio.DespesasSecretarias:N2}";

            if (lblTotalFormadores != null)
                lblTotalFormadores.Text = $"€{relatorio.DespesasFormadores:N2}";

            if (lblTotalCoordenadores != null)
                lblTotalCoordenadores.Text = $"€{relatorio.DespesasCoordenadores:N2}";
            
            if (lblDespesasFuncionarios != null)
                lblDespesasFuncionarios.Text = $"€{relatorio.TotalFuncionarios:N2}";

            if (lblTotalDespesas != null)
            {
                lblTotalDespesas.Text = $"€{relatorio.TotalDespesas:N2}";
                lblTotalDespesas.ForeColor = Color.FromArgb(232, 17, 35); // Vermelho
            }
        }

        /// <summary>
        /// Atualiza o histórico de despesas dos últimos 12 meses
        /// </summary>
        private void AtualizarHistorico(int ano)
        {
            if (dgvHistorico == null)
                return;

            try
            {
                // Gerar relatório dos últimos 12 meses
                var relatorios = gestorDespesas.GerarRelatorioUltimosMeses(12);

                // Criar lista com propriedades formatadas
                var dadosFormatados = relatorios.Select(r => new
                {
                    Periodo = r.Periodo,
                    DespesasFisicasFormatado = $"€{r.DespesasFisicas:N2}",
                    TotalFuncionariosFormatado = $"€{r.TotalFuncionarios:N2}",
                    TotalDespesasFormatado = $"€{r.TotalDespesas:N2}"
                }).ToList();

                dgvHistorico.DataSource = dadosFormatados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao carregar histórico: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

 
        /// Evento quando mês ou ano é alterado
        private void CmbMesAno_SelectedIndexChanged(object sender, EventArgs e)
        {
            AtualizarDados();
        }

        /// Evento do botão Adicionar Despesa
        private void BtnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                // Abrir formulário de adicionar despesa
                var formAdicionar = new FormAdicionarDespesa(empresa);
                var resultado = formAdicionar.ShowDialog();

                if (resultado == DialogResult.OK)
                {
                    // Atualizar dados após adicionar
                    AtualizarDados();

                    MessageBox.Show(
                        "Despesa adicionada com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao abrir formulário: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        // Evento do botão Exportar CSV
        private void BtnExportar_Click(object sender, EventArgs e)
        {
            try
            {
                // Obter mês e ano selecionados
                int mes = cmbMes != null ? cmbMes.SelectedIndex + 1 : mesAtual;
                int ano = numAno != null ? (int)numAno.Value : anoAtual;

                // Criar SaveFileDialog
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "Arquivo CSV (*.csv)|*.csv";
                    sfd.Title = "Exportar Relatório de Despesas";
                    sfd.FileName = $"Despesas_{RelatorioDespesas.ObterNomeMes(mes)}_{ano}.csv";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Exportar para CSV
                        gestorDespesas.ExportarRelatorioMensalCSV(mes, ano, sfd.FileName);

                        // Perguntar se deseja abrir o arquivo
                        var resultado = MessageBox.Show(
                            "Relatório exportado com sucesso! Deseja abrir o arquivo?",
                            "Sucesso",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information
                        );

                        if (resultado == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(sfd.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Erro ao exportar relatório: {ex.Message}",
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        /// Evento do botão Atualizar
        private void BtnAtualizar_Click(object sender, EventArgs e)
        {
            AtualizarDados();
            MessageBox.Show(
                "Dados atualizados!",
                "Informação",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        /// Evento do botão Fechar
        private void BtnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
