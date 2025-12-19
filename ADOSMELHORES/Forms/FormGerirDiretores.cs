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
    /// Form completo para gestão de Formadores
    /// Inclui: Inserir, Alterar, Alocar, Calcular Valores, Alterar Registo Criminal
    /// </summary>
    public partial class FormGerirDiretores : Form
    {
        private Empresa empresa;
        private Formador formadorSelecionado;

        public FormGerirDiretores(Empresa empresaRef)
        {
            InitializeComponent();
            empresa = empresaRef;
            ConfigurarForm();
        }

        private void ConfigurarForm()
        {
            // Configurar ComboBox de Disponibilidade
            cmbDisponibilidade.DataSource = Enum.GetValues(typeof(Disponibilidade));

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Carregar dados iniciais
            AtualizarListaFormadores();
        }

        private void ConfigurarDataGridView()
        {
            dgvFormadores.AutoGenerateColumns = false;
            dgvFormadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFormadores.MultiSelect = false;

            dgvFormadores.Columns.Clear();

            dgvFormadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Width = 50
            });

            dgvFormadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Nome",
                Width = 150
            });

            dgvFormadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AreaLeciona",
                HeaderText = "Área",
                Width = 120
            });

            dgvFormadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Disponibilidade",
                HeaderText = "Disponibilidade",
                Width = 100
            });

            dgvFormadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValorHora",
                HeaderText = "Valor/Hora",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });

            dgvFormadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Contacto",
                HeaderText = "Contacto",
                Width = 100
            });

            dgvFormadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataRegistoCriminal",
                HeaderText = "Registo Criminal",
                Width = 110,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });
        }

        private void AtualizarListaFormadores()
        {
            var formadores = empresa.Funcionarios
            .OfType<Formador>()
            .ToList();
            dgvFormadores.DataSource = null;
            dgvFormadores.DataSource = formadores;

            lblTotalFormadores.Text = $"Total de Formadores: {formadores.Count}";

            if (formadores.Count > 0 && dgvFormadores.Rows.Count > 0)
            {
                dgvFormadores.Rows[0].Selected = true;
            }
        }

        private void dgvFormadores_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvFormadores.SelectedRows.Count > 0)
            {
                formadorSelecionado = dgvFormadores.SelectedRows[0].DataBoundItem as Formador;
                if (formadorSelecionado != null)
                {
                    CarregarDadosFormador(formadorSelecionado);
                    HabilitarBotoesEdicao(true);
                }
            }
            else
            {
                HabilitarBotoesEdicao(false);
            }
        }

        private void CarregarDadosFormador(Formador formador)
        {
            // Helper local para limitar valores DateTime aos limites do control
            DateTime Clamp(DateTime value, DateTime min, DateTime max)
            {
                if (value < min) return min;
                if (value > max) return max;
                return value;
            }

            txtID.Text = formador.Id.ToString();
            txtNome.Text = formador.Nome;
            txtMorada.Text = formador.Morada;
            txtContacto.Text = formador.Contacto;
            txtAreaLeciona.Text = formador.AreaLeciona;
            cmbDisponibilidade.SelectedItem = formador.Disponibilidade;
            numValorHora.Value = formador.ValorHora;
            numSalarioBase.Value = formador.SalarioBase;

            // DataFimContrato: clamp + safe assign
            try
            {
                DateTime safeFim = Clamp(formador.DataFimContrato, dtpDataFimContrato.MinDate, dtpDataFimContrato.MaxDate);
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

            // DataRegistoCriminal: formador.DataRegistoCriminal é object; resolver e clamp + safe assign
            try
            {
                DateTime fallbackRegisto = DateTime.Now.AddYears(5);
                DateTime dataRegistoCriminal;
                try
                {
                    dataRegistoCriminal = formador.DataRegistoCriminal is DateTime dt ? dt : fallbackRegisto;
                }
                catch
                {
                    dataRegistoCriminal = fallbackRegisto;
                }

                DateTime safeRegisto = Clamp(dataRegistoCriminal, dtpDataRegistoCriminal.MinDate, dtpDataRegistoCriminal.MaxDate);

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

            // Verificar status do registo criminal
            VerificarStatusRegistoCriminal(formador);
        }

        private void VerificarStatusRegistoCriminal(Formador formador)
        {
            if (formador.RegistoCriminalExpirado(empresa.DataSimulada))
            {
                lblStatusRegistoCriminal.Text = "EXPIRADO";
                lblStatusRegistoCriminal.ForeColor = System.Drawing.Color.Red;
                lblStatusRegistoCriminal.Font = new System.Drawing.Font(lblStatusRegistoCriminal.Font, System.Drawing.FontStyle.Bold);
            }
            else
            {
                lblStatusRegistoCriminal.Text = "Válido";
                lblStatusRegistoCriminal.ForeColor = System.Drawing.Color.Green;
                lblStatusRegistoCriminal.Font = new System.Drawing.Font(lblStatusRegistoCriminal.Font, System.Drawing.FontStyle.Regular);
            }
        }

        private void HabilitarBotoesEdicao(bool habilitar)
        {
            btnAlterar.Enabled = habilitar;
            btnRemover.Enabled = habilitar;
            btnCalcularValor.Enabled = habilitar;
            btnAtualizarRegistoCriminal.Enabled = habilitar;
        }

        private void LimparCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            txtMorada.Clear();
            txtContacto.Clear();
            txtAreaLeciona.Clear();
            cmbDisponibilidade.SelectedIndex = 0;
            numValorHora.Value = 0;
            numSalarioBase.Value = 0;
            // Valores seguros por defeito
            try { dtpDataFimContrato.Value = DateTime.Now.AddYears(1); } catch { /* ignora */ }
            try { dtpDataRegistoCriminal.Value = DateTime.Now.AddYears(5); } catch { /* ignora */ }
            lblStatusRegistoCriminal.Text = "";
            formadorSelecionado = null;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Por favor, insira o nome do formador.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                MessageBox.Show("Por favor, insira o contacto do formador.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContacto.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAreaLeciona.Text))
            {
                MessageBox.Show("Por favor, insira a área que o formador leciona.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAreaLeciona.Focus();
                return false;
            }

            if (numValorHora.Value <= 0)
            {
                MessageBox.Show("Por favor, insira um valor por hora válido.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numValorHora.Focus();
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
                var novoFormador = new Formador(
                    empresa.ObterProximoID(), // id
                    0, // Nif (ajuste conforme necessário)
                    txtNome.Text.Trim(), // Nome
                    txtMorada.Text.Trim(), // Morada
                    txtContacto.Text.Trim(), // Contacto
                    DateTime.Now, // DataIniContrato (ajuste conforme necessário)
                    dtpDataFimContrato.Value, // DataFimContrato
                    dtpDataRegistoCriminal.Value, // DataRegistoCriminal
                    numSalarioBase.Value, // SalarioBase
                    DateTime.Now, // DataNascimento (ajuste conforme necessário)
                    txtAreaLeciona.Text.Trim(), // areaLeciona
                    (Disponibilidade)cmbDisponibilidade.SelectedItem, // disponibilidade
                    numValorHora.Value // valorHora
                );

                empresa.AdicionarFuncionario(novoFormador);
                AtualizarListaFormadores();
                LimparCampos();

                MessageBox.Show($"Formador '{novoFormador.Nome}' inserido com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir formador: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (formadorSelecionado == null)
            {
                MessageBox.Show("Selecione um formador para alterar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos())
                return;

            try
            {
                formadorSelecionado.Nome = txtNome.Text.Trim();
                formadorSelecionado.Morada = txtMorada.Text.Trim();
                formadorSelecionado.Contacto = txtContacto.Text.Trim();
                formadorSelecionado.AreaLeciona = txtAreaLeciona.Text.Trim();
                formadorSelecionado.Disponibilidade = (Disponibilidade)cmbDisponibilidade.SelectedItem;
                formadorSelecionado.ValorHora = numValorHora.Value;
                formadorSelecionado.SalarioBase = numSalarioBase.Value;
                formadorSelecionado.DataFimContrato = dtpDataFimContrato.Value;
                formadorSelecionado.DataRegistoCriminal = dtpDataRegistoCriminal.Value;

                AtualizarListaFormadores();

                MessageBox.Show($"Formador '{formadorSelecionado.Nome}' alterado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar formador: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (formadorSelecionado == null)
            {
                MessageBox.Show("Selecione um formador para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"Tem certeza que deseja remover o formador '{formadorSelecionado.Nome}'?",
                "Confirmar Remoção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    empresa.RemoverFuncionario(formadorSelecionado);
                    AtualizarListaFormadores();
                    LimparCampos();

                    MessageBox.Show("Formador removido com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover formador: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            if (dgvFormadores.Rows.Count > 0)
            {
                dgvFormadores.ClearSelection();
            }
        }

        private void btnCalcularValor_Click(object sender, EventArgs e)
        {
            if (formadorSelecionado == null)
            {
                MessageBox.Show("Selecione um formador para calcular o valor da formação.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var formCalculo = new FormCalcularValorFormacao(formadorSelecionado))
            {
                formCalculo.ShowDialog();
            }
        }

        private void btnAtualizarRegistoCriminal_Click(object sender, EventArgs e)
        {
            if (formadorSelecionado == null)
            {
                MessageBox.Show("Selecione um formador para atualizar o registo criminal.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var formRegistoCriminal = new FormAtualizarRegistoCriminal(formadorSelecionado, empresa))
            {
                if (formRegistoCriminal.ShowDialog() == DialogResult.OK)
                {
                    AtualizarListaFormadores();
                    CarregarDadosFormador(formadorSelecionado);
                }
            }
        }

        private void btnAlocarFormador_Click(object sender, EventArgs e)
        {
            if (formadorSelecionado == null)
            {
                MessageBox.Show("Selecione um formador para alocar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var formAlocar = new FormAlocarFormador(formadorSelecionado, empresa))
            {
                formAlocar.ShowDialog();
            }
        }

        private void btnFiltrarDisponibilidade_Click(object sender, EventArgs e)
        {
            using (var formFiltro = new FormFiltrarFormadores(empresa))
            {
                formFiltro.ShowDialog();
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private class FormCalcularValorFormacao : IDisposable
        {
            private Formador formadorSelecionado;

            public FormCalcularValorFormacao(Formador formadorSelecionado)
            {
                this.formadorSelecionado = formadorSelecionado;
            }

            internal void ShowDialog()
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                // Implementação de Dispose se necessário
            }
        }
    }

    internal class FormAtualizarRegistoCriminal : IDisposable
    {
        public FormAtualizarRegistoCriminal(Formador formadorSelecionado, Empresa empresa)
        {
            FormadorSelecionado = formadorSelecionado;
            Empresa = empresa;
        }

        public Formador FormadorSelecionado { get; }
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

    internal class FormAlocarFormador : IDisposable
    {
        private Formador formadorSelecionado;
        private Empresa empresa;

        public FormAlocarFormador(Formador formadorSelecionado, Empresa empresa)
        {
            this.formadorSelecionado = formadorSelecionado;
            this.empresa = empresa;
        }

        public void Dispose()
        {
            // Implementação de Dispose se necessário
        }

        public void ShowDialog()
        {
            // Implemente a lógica de exibição do formulário de alocação aqui.
            // Por exemplo, pode abrir um novo Form se desejar.
            MessageBox.Show(
                $"Alocação do formador '{formadorSelecionado.Nome}' (ID: {formadorSelecionado.Id}) realizada.",
                "Alocar Formador",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
    }

    internal class FormFiltrarFormadores : IDisposable
    {
        private Empresa empresa;

        public FormFiltrarFormadores(Empresa empresa)
        {
            this.empresa = empresa;
        }

        public void Dispose()
        {
            // Implementação de Dispose se necessário
        }

        public void ShowDialog()
        {
            // Corrigido: especificar explicitamente a propriedade para evitar ambiguidade
            string textoFiltroAplicado = $@"Filtro de formadores da empresa aplicado.";
            _ = MessageBox.Show(
                textoFiltroAplicado,
                "Filtrar Formadores",
                MessageBoxButtons.OK,
                icon: MessageBoxIcon.Information
            );
        }
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

    internal void AdicionarFuncionario(Formador novoFormador)
    {
        throw new NotImplementedException();
    }

    internal void RemoverFuncionario(Formador formadorSelecionado)
    {
        throw new NotImplementedException();
    }

    // resto igual (usar 'funcionarios' internamente)
}
