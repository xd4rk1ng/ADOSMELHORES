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
using ADOSMELHORES.Modelos.Despesas;

namespace ADOSMELHORES.Forms.Despesas
{
    public partial class FormAdicionarDespesa : Form
    {
        private GestorDespesas gestorDespesas;
        public DespesaFisica DespesaAdicionada { get; private set; }

        /// <summary>
        /// Construtor - recebe instância da Empresa  
        /// Preparado para migração BD - não precisa mudar!
        /// </summary>
        public FormAdicionarDespesa(Empresa empresa)
        {
            InitializeComponent();

            if (empresa == null)
                throw new ArgumentNullException(nameof(empresa));

            // Obtém o GestorDespesas da Empresa
            // MIGRAÇÃO BD: Esta linha não muda!
            // A classe Empresa internamente decide se busca de memória ou BD
            gestorDespesas = empresa.GestorDespesas;

            ConfigurarFormulario();
            CarregarTiposDespesa();
        }

        /// Configura propriedades iniciais do formulário
        private void ConfigurarFormulario()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Configurar data padrão como hoje
            dtpData.Value = DateTime.Now;

            // Configurar valor padrão
            numValor.Value = 0;

            // Focar no primeiro campo
            cmbTipo.Focus();

            // Configurar eventos dos botões
            btnSalvar.Click += BtnSalvar_Click;
            btnCancelar.Click += BtnCancelar_Click;

            // Configurar DialogResult dos botões
            btnSalvar.DialogResult = DialogResult.None; // Controlado manualmente
            btnCancelar.DialogResult = DialogResult.Cancel;
        }

        /// Carrega os tipos de despesa no ComboBox
        private void CarregarTiposDespesa()
        {
            cmbTipo.Items.Clear();

            // Adicionar todos os tipos do enum
            foreach (TipoDespesaFisica tipo in Enum.GetValues(typeof(TipoDespesaFisica)))
            {
                cmbTipo.Items.Add(DespesaFisica.ObterDescricaoTipo(tipo));
            }

            // Selecionar primeiro item
            if (cmbTipo.Items.Count > 0)
                cmbTipo.SelectedIndex = 0;
        }

        /// Evento do botão Salvar
        private void BtnSalvar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                try
                {
                    // Criar nova despesa
                    var novaDespesa = new DespesaFisica
                    {
                        Data = dtpData.Value,
                        Tipo = ObterTipoSelecionado(),
                        Valor = numValor.Value,
                        Fornecedor = textBox1.Text.Trim(),
                        Descricao = txtDescricao.Text.Trim()
                    };

                    // Adicionar ao gestor
                    // MIGRAÇÃO BD: GestorDespesas internamente fará INSERT no BD
                    gestorDespesas.AdicionarDespesaFisica(novaDespesa);

                    // Guardar referência
                    DespesaAdicionada = novaDespesa;

                    // Mensagem de sucesso
                    MessageBox.Show(
                        "Despesa adicionada com sucesso!",
                        "Sucesso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Fechar formulário
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Erro ao adicionar despesa: {ex.Message}",
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
        }

        /// Evento do botão Cancelar
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            // Confirmar cancelamento se houver dados preenchidos
            if (CamposPreenchidos())
            {
                var resultado = MessageBox.Show(
                    "Deseja realmente cancelar? Os dados não serão salvos.",
                    "Confirmar Cancelamento",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.No)
                    return;
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// Valida todos os campos do formulário
        private bool ValidarCampos()
        {
            // Validar tipo selecionado
            if (cmbTipo.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Por favor, selecione um tipo de despesa.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                cmbTipo.Focus();
                return false;
            }

            // Validar data
            if (dtpData.Value > DateTime.Now)
            {
                var resultado = MessageBox.Show(
                    "A data selecionada é futura. Deseja continuar?",
                    "Validação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.No)
                {
                    dtpData.Focus();
                    return false;
                }
            }

            // Validar valor
            if (numValor.Value <= 0)
            {
                MessageBox.Show(
                    "O valor da despesa deve ser maior que zero.",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                numValor.Focus();
                return false;
            }

            // Validar fornecedor (opcional mas recomendado)
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                var resultado = MessageBox.Show(
                    "O campo Fornecedor está vazio. Deseja continuar sem preencher?",
                    "Validação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.No)
                {
                    textBox1.Focus();
                    return false;
                }
            }

            // Validar descrição (opcional)
            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                var resultado = MessageBox.Show(
                    "O campo Descrição está vazio. Deseja continuar sem preencher?",
                    "Validação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (resultado == DialogResult.No)
                {
                    txtDescricao.Focus();
                    return false;
                }
            }

            return true;
        }

        /// Verifica se há campos preenchidos
        private bool CamposPreenchidos()
        {
            return cmbTipo.SelectedIndex >= 0 ||
                   numValor.Value > 0 ||
                   !string.IsNullOrWhiteSpace(textBox1.Text) ||
                   !string.IsNullOrWhiteSpace(txtDescricao.Text);
        }

        /// Obtém o tipo de despesa selecionado no ComboBox
        private TipoDespesaFisica ObterTipoSelecionado()
        {
            // Obter descrição selecionada
            string descricaoSelecionada = cmbTipo.SelectedItem.ToString();

            // Procurar o enum correspondente
            foreach (TipoDespesaFisica tipo in Enum.GetValues(typeof(TipoDespesaFisica)))
            {
                if (DespesaFisica.ObterDescricaoTipo(tipo) == descricaoSelecionada)
                {
                    return tipo;
                }
            }
                        
            return TipoDespesaFisica.Outros;
        }
    }
}
