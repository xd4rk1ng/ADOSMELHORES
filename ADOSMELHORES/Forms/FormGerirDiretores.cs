using ADOSMELHORES;
using ADOSMELHORES.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdosMelhores.Forms
{
    /// <summary>
    /// Form completo para gestão de Diretores
    /// Inclui: Inserir, Alterar, Alocar secretarias, Calcular Valores, Alterar Registo Criminal
    /// </summary>
    public partial class FormGerirDiretores : Form
    {
        private Empresa empresa;
        private Diretor diretorSelecionado;

        public FormGerirDiretores(Empresa empresaRef)
        {
            InitializeComponent();
            empresa = empresaRef;
            ConfigurarForm();
        }

        private void ConfigurarForm()
        {
            // Configurar DataGridView
            ConfigurarDataGridView();

            // Carregar dados iniciais
            AtualizarListaDiretores();

            btnCalcularValor.Enabled = false;
        }

        private void ConfigurarDataGridView()
        {
            dgvDiretores.AutoGenerateColumns = false;
            dgvDiretores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDiretores.MultiSelect = false;

            dgvDiretores.Columns.Clear();

            dgvDiretores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });

            dgvDiretores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Nome",
                Width = 150
            });

            dgvDiretores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AreaDiretoria",
                HeaderText = "Área Diretoria",
                Width = 120
            });

            dgvDiretores.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "CarroEmpresa",
                HeaderText = "Carro Empresa",
                Width = 80
            });

            dgvDiretores.Columns.Add(new DataGridViewCheckBoxColumn
            {
                DataPropertyName = "IsencaoHorario",
                HeaderText = "Isenção Horário",
                Width = 100
            });

            dgvDiretores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "BonusMensal",
                HeaderText = "Bónus Mensal",
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvDiretores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Contacto",
                HeaderText = "Contacto",
                Width = 100
            });
        }


        private void AtualizarListaDiretores()
        {
            var diretores = empresa.Funcionarios
                .OfType<Diretor>()
                .ToList();
            dgvDiretores.DataSource = null;
            dgvDiretores.DataSource = diretores;

            lblTotalDiretores.Text = $"Total de Diretores: {diretores.Count}";

            if (diretores.Count > 0 && dgvDiretores.Rows.Count > 0)
            {
                dgvDiretores.Rows[0].Selected = true;
            }
        }

        private void dgvDiretores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvDiretores.SelectedRows.Count > 0)
            {
                diretorSelecionado = dgvDiretores.SelectedRows[0].DataBoundItem as Diretor;
                if (diretorSelecionado != null)
                {
                    CarregarDadosDiretor(diretorSelecionado);
                    HabilitarBotoesEdicao(true);
                }
            }
            else
            {
                HabilitarBotoesEdicao(false);
            }
        }

        private void CarregarDadosDiretor(Diretor diretor)
        {
            // Helper local para limitar valores DateTime aos limites do control
            DateTime Clamp(DateTime value, DateTime min, DateTime max)
            {
                if (value < min) return min;
                if (value > max) return max;
                return value;
            }

            txtID.Text = diretor.Id.ToString();
            txtNome.Text = diretor.Nome;
            txtMorada.Text = diretor.Morada;
            txtContacto.Text = diretor.Contacto;
            txtAreaDiretoria.Text = diretor.AreaDiretoria;
            numSalarioBase.Value = diretor.SalarioBase;
            //numValorHora.Value = diretor.BonusMensal;

            // DataFimContrato: clamp + safe assign
            try
            {
                DateTime safeFim = Clamp(diretor.DataFimContrato, dtpDataFimContrato.MinDate, dtpDataFimContrato.MaxDate);
                try
                {
                    dtpDataFimContrato.Value = safeFim;
                }
                catch (ArgumentOutOfRangeException)
                {
                    dtpDataFimContrato.Value = dtpDataFimContrato.MinDate;
                }
            }
            catch
            {
                try { dtpDataFimContrato.Value = dtpDataFimContrato.MinDate; } catch { /* ignora */ }
            }
            // DataRegistroCriminal:
            try
            {
                DateTime safeRegisto = Clamp(diretor.DataFimRegistoCrim, dtpDataRegistoCriminal.MinDate, dtpDataRegistoCriminal.MaxDate);

                try
                {
                    dtpDataRegistoCriminal.Value = safeRegisto;
                }
                catch (ArgumentOutOfRangeException)
                {
                    dtpDataRegistoCriminal.Value = dtpDataRegistoCriminal.MinDate;
                }
            }
            catch
            {
                try { dtpDataRegistoCriminal.Value = dtpDataRegistoCriminal.MinDate; } catch { /* ignora */ }
            }

            CarregarSecretariasDisponiveis();

            AtualizarEstadoBotaoCalcular();
        }

        private void CarregarSecretariasDisponiveis()
        {
            checkedListBoxSecretarias.Items.Clear();

            var todasSecretarias = empresa.Funcionarios
                .OfType<Secretaria>()
                .ToList();

            foreach (var secretaria in todasSecretarias)
            {
                int index = checkedListBoxSecretarias.Items.Add(secretaria);

                // Verifica se esta secretária já está alocada a este diretor
                if (diretorSelecionado != null &&
                    diretorSelecionado.SecretariasSubordinadas.Contains(secretaria))
                {
                    checkedListBoxSecretarias.SetItemChecked(index, true);
                }
            }
        }


        private void AtualizarEstadoBotaoCalcular()
        {
            // Habilita o botão se houver pelo menos uma secretária selecionada
            btnCalcularValor.Enabled = checkedListBoxSecretarias.CheckedItems.Count > 0;
        }

        private void HabilitarBotoesEdicao(bool habilitar)
        {
            btnAlterar.Enabled = habilitar;
            btnRemover.Enabled = habilitar;
            btnAtualizarRegistoCriminal.Enabled = habilitar;
            // btnCalcularValor state is managed by AtualizarEstadoBotaoCalcular
        }

        private void LimparCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            txtMorada.Clear();
            txtContacto.Clear();
            txtAreaDiretoria.Clear();
            //numValorHora.Value = 0;
            numSalarioBase.Value = 0;

            // Limpar seleção de secretárias
            for (int i = 0; i < checkedListBoxSecretarias.Items.Count; i++)
            {
                checkedListBoxSecretarias.SetItemChecked(i, false);
            }

            // Valores seguros por defeito
            try { dtpDataFimContrato.Value = DateTime.Now.AddYears(1); } catch { /* ignora */ }
            try { dtpDataRegistoCriminal.Value = DateTime.Now.AddYears(5); } catch { /* ignora */ }
            lblStatusRegistoCriminal.Text = "";
            diretorSelecionado = null;

            btnCalcularValor.Enabled = false;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Por favor, insira o nome do diretor.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                MessageBox.Show("Por favor, insira o contacto do diretor.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContacto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAreaDiretoria.Text))
            {
                MessageBox.Show("Por favor, insira a área de diretoria.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAreaDiretoria.Focus();
                return false;
            }

            if (dtpDataFimContrato.Value <= DateTime.Now)
            {
                MessageBox.Show("A data de fim de contrato deve ser futura.", "Data Inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpDataFimContrato.Focus();
                return false;
            }

            return true;
        }


        // ==================== EVENTOS DE BOTÕES ====================

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                // NOTA: FALTA adicionar checkboxes para CarroEmpresa e IsencaoHorario
                bool carroEmpresa = false;
                bool isencaoHorario = false;

                // Try to find checkboxes in the form (assuming they exist based on the design)
                // If they don't exist, default values will be used

                var novoDiretor = new Diretor(
                    empresa.ObterProximoID(), // id
                    0, // Nif (ajuste conforme necessário)
                    txtNome.Text.Trim(), // Nome
                    txtMorada.Text.Trim(), // Morada
                    txtContacto.Text.Trim(), // Contacto
                    numSalarioBase.Value, // SalarioBase
                    dtpDataFimContrato.Value, // DataFimContrato
                    DateTime.Now, // DataIniContrato
                    dtpDataRegistoCriminal.Value, // DataFimRegistoCrim
                    DateTime.Now, // DataNascimento
                    0, // BonusMensal inicial (será calculado depois)
                    carroEmpresa, // CarroEmpresa
                    isencaoHorario, // IsencaoHorario
                    txtAreaDiretoria.Text.Trim() // AreaDiretoria
                );

                // Adicionar secretárias selecionadas
                foreach (var item in checkedListBoxSecretarias.CheckedItems)
                {
                    if (item is Secretaria secretaria)
                    {
                        novoDiretor.AdicionarSecretaria(secretaria);
                    }
                }

                empresa.AdicionarFuncionario(novoDiretor);
                AtualizarListaDiretores();
                LimparCampos();

                MessageBox.Show($"Diretor '{novoDiretor.Nome}' inserido com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir diretor: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (diretorSelecionado == null)
            {
                MessageBox.Show("Selecione um diretor para alterar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos())
                return;

            try
            {
                diretorSelecionado.Nome = txtNome.Text.Trim();
                diretorSelecionado.Morada = txtMorada.Text.Trim();
                diretorSelecionado.Contacto = txtContacto.Text.Trim();
                diretorSelecionado.AreaDiretoria = txtAreaDiretoria.Text.Trim();
                diretorSelecionado.SalarioBase = numSalarioBase.Value;
                diretorSelecionado.DataFimContrato = dtpDataFimContrato.Value;
                diretorSelecionado.DataFimRegistoCrim = dtpDataRegistoCriminal.Value;

                // Atualizar alocação de secretárias
                // Remover todas as secretárias atuais
                var secretariasAtuais = diretorSelecionado.SecretariasSubordinadas.ToList();
                foreach (var sec in secretariasAtuais)
                {
                    diretorSelecionado.RemoverSecretaria(sec);
                }

                // Adicionar secretárias selecionadas
                foreach (var item in checkedListBoxSecretarias.CheckedItems)
                {
                    if (item is Secretaria secretaria)
                    {
                        diretorSelecionado.AdicionarSecretaria(secretaria);
                    }
                }

                AtualizarListaDiretores();

                MessageBox.Show($"Diretor '{diretorSelecionado.Nome}' alterado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar diretor: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (diretorSelecionado == null)
            {
                MessageBox.Show("Selecione um diretor para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"Tem certeza que deseja remover o diretor '{diretorSelecionado.Nome}'?",
                "Confirmar Remoção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // Remover todas as alocações de secretárias
                    var secretariasAtuais = diretorSelecionado.SecretariasSubordinadas.ToList();
                    foreach (var sec in secretariasAtuais)
                    {
                        diretorSelecionado.RemoverSecretaria(sec);
                    }

                    empresa.RemoverFuncionario(diretorSelecionado);
                    AtualizarListaDiretores();
                    LimparCampos();

                    MessageBox.Show("Diretor removido com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover diretor: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            if (dgvDiretores.Rows.Count > 0)
            {
                dgvDiretores.ClearSelection();
            }
        }

        private void btnCalcularValor_Click(object sender, EventArgs e)
        {

            if (diretorSelecionado == null)
            {
                MessageBox.Show("Selecione um diretor para calcular a remuneração.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calcular bônus baseado nas secretárias alocadas
            decimal bonusCalculado = diretorSelecionado.CalcularBonusMensal();

            string detalhes = $"Diretor: {diretorSelecionado.Nome}\n\n";
            detalhes += $"Salário Base: {diretorSelecionado.SalarioBase:C2}\n";
            detalhes += $"Bónus Mensal Calculado: {bonusCalculado:C2}\n\n";
            detalhes += "Fatores considerados:\n";
            detalhes += $"- Secretárias subordinadas: {diretorSelecionado.SecretariasSubordinadas.Count} (+{diretorSelecionado.SecretariasSubordinadas.Count * 50:C2})\n";
            detalhes += $"- Carro empresa: {(diretorSelecionado.CarroEmpresa ? "Sim (-300€)" : "Não")}\n";
            detalhes += $"- Isenção horário: {(diretorSelecionado.IsencaoHorario ? "Sim (+200€)" : "Não")}\n\n";
            detalhes += $"Remuneração Total: {(diretorSelecionado.SalarioBase + bonusCalculado):C2}";

            MessageBox.Show(detalhes, "Cálculo de Remuneração",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAtualizarRegistoCriminal_Click(object sender, EventArgs e)
        {
            if (diretorSelecionado == null)
            {
                MessageBox.Show("Selecione um diretor para atualizar o registo criminal.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                "Deseja atualizar a data de registo criminal para 5 anos a partir de hoje?",
                "Atualizar Registo Criminal",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    diretorSelecionado.DataFimRegistoCrim = DateTime.Now.AddYears(5);
                    dtpDataRegistoCriminal.Value = diretorSelecionado.DataFimRegistoCrim;
                    AtualizarListaDiretores();

                    MessageBox.Show("Registo criminal atualizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao atualizar registo criminal: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }

    internal class FormAtualizarRegistoCriminal : IDisposable
    {
        public FormAtualizarRegistoCriminal(Diretor diretorSelecionado, Empresa empresa)
        {
            DiretorSelecionado = diretorSelecionado;
            Empresa = empresa;
        }

        public Diretor DiretorSelecionado { get; }
        public Empresa Empresa { get; }

        internal DialogResult ShowDialog()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // Implementação de Dispose se necessário
        }
    }


    public class Empresa
    {
        private readonly List<Funcionario> funcionarios;

        public string Nome { get; set; }
        public IReadOnlyList<Funcionario> Funcionarios { get; }
        public DateTime DataSimulada { get; set; }

        public Empresa(string nome)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            funcionarios = new List<Funcionario>();
            Funcionarios = funcionarios; // evita null ao aceder externamente
        }

        internal int ObterProximoID()
        {
            if (funcionarios.Count == 0)
                return 1;
            return funcionarios.Max(f => f.Id) + 1;
        }

        internal void AdicionarFuncionario(Funcionario funcionario)
        {
            if (funcionario == null)
                throw new ArgumentNullException(nameof(funcionario));
            funcionarios.Add(funcionario);
        }

        internal void AdicionarFuncionario(Diretor novoDiretor)
        {
            throw new NotImplementedException();
        }

        internal void RemoverFuncionario(Diretor diretorSelecionado)
        {
            throw new NotImplementedException();
        }


        // resto igual (usar 'funcionarios' internamente)
    }
}
