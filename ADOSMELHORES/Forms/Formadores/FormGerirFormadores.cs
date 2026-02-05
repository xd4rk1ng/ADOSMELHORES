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

namespace ADOSMELHORES.Forms.Formadores
{
    /// <summary>
    /// Form completo para gestão de Formadores
    /// Inclui: Inserir, Alterar, Alocar, Calcular Valores, Alterar Registo Criminal
    /// </summary>
    public partial class FormGerirFormadores : Form
    {
        private readonly Empresa empresa; // Corrigido aqui
        private Formador formadorSelecionado;
        private BindingSource bsFormadores;

        public FormGerirFormadores(Empresa empresaRef) // Corrigido aqui
        {
            InitializeComponent();
            empresa = empresaRef;
            bsFormadores = new BindingSource();
            ConfigurarForm();
        }

        private void ConfigurarForm()
        {
            // Configurar ComboBox de Disponibilidade
            cmbDisponibilidade.DataSource = Enum.GetValues(typeof(Disponibilidade));

            // Subscribes para validação do NIF
            txtNIF.KeyPress += TxtNIF_KeyPress;
            txtNIF.Validating += TxtNIF_Validating;

            // Configurar DataGridView
            ConfigurarDataGridView();

            // usar BindingSource como DataSource do grid
            dgvFormadores.DataSource = bsFormadores;

            // Carregar dados iniciais
            AtualizarListaFormadores();
        }

        private void TxtNIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas dígitos e teclas de controlo (backspace, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtNIF_Validating(object sender, CancelEventArgs e)
        {
            string text = txtNIF.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(text))
            {
                // Se NIF for obrigatório descomente abaixo:
                // e.Cancel = true;
                // MessageBox.Show("Por favor, insira o NIF.", "Campo Obrigatório", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!text.All(char.IsDigit))
            {
                e.Cancel = true;
                MessageBox.Show("NIF deve conter apenas dígitos.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validação opcional de comprimento (NIF PT tem 9 dígitos)
            if (text.Length != 9)
            {
                e.Cancel = true;
                MessageBox.Show("NIF deve ter 9 dígitos.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvFormadores.AutoGenerateColumns = false;
            dgvFormadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFormadores.MultiSelect = false;

            dgvFormadores.Columns.Clear();

            dgvFormadores.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
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
                DataPropertyName = "DataFimRegistoCrim",
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

            // Atualizar BindingSource — DataGridView atualiza automaticamente
            bsFormadores.DataSource = formadores;

            lblTotalFormadores.Text = $"Total de Formadores: {formadores.Count}";

            // Tentar preservar seleção atual (se existir) ou selecionar o primeiro
            if (formadores.Count > 0 && dgvFormadores.Rows.Count > 0)
            {
                dgvFormadores.ClearSelection();

                int indexToSelect = 0;
                if (formadorSelecionado != null)
                {
                    int found = formadores.FindIndex(f => f.Id == formadorSelecionado.Id);
                    if (found >= 0)
                        indexToSelect = found;
                }

                dgvFormadores.Rows[indexToSelect].Selected = true;
                try { dgvFormadores.CurrentCell = dgvFormadores.Rows[indexToSelect].Cells[0]; } catch { /* ignora */ }

                // Atualizar estado interno e campos visuais
                formadorSelecionado = dgvFormadores.SelectedRows.Count > 0
                    ? dgvFormadores.SelectedRows[0].DataBoundItem as Formador
                    : null;

                if (formadorSelecionado != null)
                {
                    CarregarDadosFormador(formadorSelecionado);
                    HabilitarBotoesEdicao(true);
                }
                else
                {
                    HabilitarBotoesEdicao(false);
                }
            }
            else
            {
                HabilitarBotoesEdicao(false);
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
            // Preencher NIF (novo campo)
            try { txtNIF.Text = formador.Nif.ToString(); } catch { txtNIF.Text = string.Empty; }

            txtNome.Text = formador.Nome;
            txtMorada.Text = formador.Morada;
            txtContacto.Text = formador.Contacto;
            txtAreaLeciona.Text = formador.AreaLeciona;
            cmbDisponibilidade.SelectedItem = formador.Disponibilidade;
            numValorHora.Value = formador.ValorHora;
            // numSalarioBase.Value = formador.SalarioBase; // removido: não preencher salário base para formadores

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

            // DataRegistoCriminal
            try
            {
                DateTime fallbackRegisto = DateTime.Now;
                DateTime dataRegistoCriminal;
                try
                {
                    dataRegistoCriminal = formador.DataFimRegistoCrim;
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
            // Usar DataSimulada se estiver configurada; caso contrário, usar data actual.
            DateTime referencia = (empresa != null && empresa.DataSimulada > DateTime.MinValue)
                ? empresa.DataSimulada.Date
                : DateTime.Now.Date;

            // Normalizar comparação para ignorar componente hora
            if (formador.RegistoCriminalExpirado(referencia))
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
            txtNIF.Clear(); // limpar NIF
            txtNome.Clear();
            txtMorada.Clear();
            txtContacto.Clear();
            txtAreaLeciona.Clear();
            cmbDisponibilidade.SelectedIndex = 0;
            numValorHora.Value = 0;
            // Valores seguros por defeito
            try { dtpDataFimContrato.Value = DateTime.Now.AddYears(1); } catch { /* ignora */ }
            try { dtpDataRegistoCriminal.Value = DateTime.Now; } catch { /* ignora */ }
            lblStatusRegistoCriminal.Text = "";
            formadorSelecionado = null;
            HabilitarBotoesEdicao(false);
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

            // Verifica NIF (se preenchido deve conter apenas dígitos)
            if (!string.IsNullOrWhiteSpace(txtNIF.Text) && !txtNIF.Text.Trim().All(char.IsDigit))
            {
                MessageBox.Show("O NIF deve conter apenas números.", "Campo Inválido",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIF.Focus();
                return false;
            }

            // Se quiser tornar NIF obrigatório:
            // if (string.IsNullOrWhiteSpace(txtNIF.Text)) { ... }

            if (numValorHora.Value <= 0)
            {
                MessageBox.Show("Por favor, insira um valor por hora válido.", "Campo Obligatório",
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
                // ler NIF com parsing seguro
                int nif = 0;
                int.TryParse(txtNIF.Text?.Trim(), out nif);

                // Impedir duplicação de NIF
                if (nif > 0 && NifDuplicado(nif))
                {
                    MessageBox.Show("Já existe um formador com este NIF.", "NIF Duplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNIF.Focus();
                    return;
                }

                var novoFormador = new Formador(
                    empresa.ObterProximoID(), // id
                    nif, // Nif agora vindo do campo
                    txtNome.Text.Trim(), // Nome
                    txtMorada.Text.Trim(), // Morada
                    txtContacto.Text.Trim(), // Contacto
                    0m, // SalarioBase removido para formadores -> passa-se 0
                    DateTime.Now, // DataIniContrato
                    dtpDataFimContrato.Value, // DataFimContrato
                    dtpDataRegistoCriminal.Value, // DataFimRegistoCrim
                    DateTime.Now.AddYears(-30), // DataNascimento (valor por defeito)
                    txtAreaLeciona.Text.Trim(), // areaLeciona
                    (Disponibilidade)cmbDisponibilidade.SelectedItem, // disponibilidade
                    numValorHora.Value // valorHora
                );

                empresa.AdicionarFuncionario(novoFormador);

                // Atualiza a lista e seleciona o novo formador imediatamente
                AtualizarListaFormadores();

                // Forçar seleção do novo formador (caso não selecionado pela AtualizarListaFormadores)
                var lista = bsFormadores.DataSource as List<Formador>;
                if (lista != null)
                {
                    int index = lista.FindIndex(f => f.Id == novoFormador.Id);
                    if (index >= 0 && index < dgvFormadores.Rows.Count)
                    {
                        dgvFormadores.ClearSelection();
                        dgvFormadores.Rows[index].Selected = true;
                        try { dgvFormadores.CurrentCell = dgvFormadores.Rows[index].Cells[0]; } catch { }
                        formadorSelecionado = novoFormador;
                        CarregarDadosFormador(formadorSelecionado);
                        HabilitarBotoesEdicao(true);
                    }
                }

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
                // validar/parsar NIF do campo
                int nif;
                int.TryParse(txtNIF.Text?.Trim(), out nif);

                // Impedir duplicação (excluir o próprio formador da verificação)
                if (nif > 0 && NifDuplicado(nif, formadorSelecionado.Id))
                {
                    MessageBox.Show("Outro formador já utiliza este NIF. Corrija o NIF.", "NIF Duplicado",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNIF.Focus();
                    return;
                }

                formadorSelecionado.Nome = txtNome.Text.Trim();
                formadorSelecionado.Morada = txtMorada.Text.Trim();
                formadorSelecionado.Contacto = txtContacto.Text.Trim();
                formadorSelecionado.AreaLeciona = txtAreaLeciona.Text.Trim();
                formadorSelecionado.Disponibilidade = (Disponibilidade)cmbDisponibilidade.SelectedItem;
                formadorSelecionado.ValorHora = numValorHora.Value;
                formadorSelecionado.DataFimContrato = dtpDataFimContrato.Value;
                formadorSelecionado.DataFimRegistoCrim = dtpDataRegistoCriminal.Value;

                // actualizar NIF se o campo estiver presente e for válido
                if (nif > 0)
                {
                    formadorSelecionado.Nif = nif;
                }

                // Persistir via Empresa (se existir método especifico)
                empresa.AtualizarFormador(formadorSelecionado);

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

            // Usar o Form real do projecto (evita classes placeholder internas)
            using (var formCalculo = new ADOSMELHORES.Forms.FormCalcularValorFormacao(formadorSelecionado))
            {
                // Passar 'this' como owner para centralizar modal sobre este form
                formCalculo.ShowDialog(this);
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

            // Mesma lógica usada no FormGerirCoordenadores: abrir diálogo simples com DateTimePicker
            using (Form formData = new Form())
            {
                formData.Text = "Atualizar Registo Criminal";
                formData.Size = new System.Drawing.Size(300, 150);
                formData.StartPosition = FormStartPosition.CenterParent;

                Label lblInfo = new Label()
                {
                    Text = "Nova data de validade:",
                    Location = new System.Drawing.Point(20, 20),
                    AutoSize = true
                };
                DateTimePicker dtp = new DateTimePicker()
                {
                    Location = new System.Drawing.Point(20, 50),
                    Width = 240,
                    Value = DateTime.Now.AddYears(1)
                };
                Button btnOk = new Button()
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new System.Drawing.Point(100, 80)
                };

                formData.Controls.Add(lblInfo);
                formData.Controls.Add(dtp);
                formData.Controls.Add(btnOk);
                formData.AcceptButton = btnOk;

                if (formData.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        formadorSelecionado.DataFimRegistoCrim = dtp.Value;
                        AtualizarListaFormadores();
                        CarregarDadosFormador(formadorSelecionado);

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
        }

        private void btnFiltrarDisponibilidade_Click(object sender, EventArgs e)
        {
            using (var formFiltro = new ADOSMELHORES.Forms.FormFiltrarFormadores(empresa))
            {
                // Se o form de filtro devolver OK, actualizar a lista (supondo que aplica filtros à empresa ou retorna resultado)
                if (formFiltro.ShowDialog(this) == DialogResult.OK)
                {
                    AtualizarListaFormadores();
                }
                else
                {
                    // Mesmo que não devolva OK, pode ser útil refrescar a lista para garantir estado consistente
                    AtualizarListaFormadores();
                }
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        // novo helper para verificar duplicados de NIF
        private bool NifDuplicado(int nif, int? excludeId = null)
        {
            if (nif <= 0) return false; // NIF inválido não conta como duplicado
            return empresa.Funcionarios
                .OfType<Formador>()
                .Any(f => f.Nif == nif && (!excludeId.HasValue || f.Id != excludeId.Value));
        }
    }
}