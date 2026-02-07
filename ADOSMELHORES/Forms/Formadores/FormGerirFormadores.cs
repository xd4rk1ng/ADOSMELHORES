using ADOSMELHORES;
using ADOSMELHORES.Modelos;
using ADOSMELHORES.Validacoes;
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
    /// Form completo para gestão de Formadores       
    public partial class FormGerirFormadores : Form
    {
        private readonly Empresa empresa;
        private Formador formadorSelecionado;
        private BindingSource bsFormadores;
        private bool inicializando;

        public FormGerirFormadores(Empresa empresaRef)
        {
            InitializeComponent();
            empresa = empresaRef;
            bsFormadores = new BindingSource();
            this.AutoValidate = AutoValidate.EnableAllowFocusChange;
            inicializando = true;
            ConfigurarForm();
            // LimparCampos() aqui no construtor é ignorado porque o Grid seleciona sozinho ao abrir.
            // Removemos daqui e passamos para o OnShown (ver abaixo).
            inicializando = false;
        }

        // --- CORREÇÃO IMPORTANTE: Garantir que inicia vazio APÓS o form aparecer ---
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // Isto corre depois do Windows Forms tentar selecionar a primeira linha automaticamente
            dgvFormadores.ClearSelection();
            dgvFormadores.CurrentCell = null;
            this.ActiveControl = null;
            LimparCampos();
        }
        // --------------------------------------------------------------------------

        private void ConfigurarForm()
        {
            // --- CORREÇÃO: Prevenir bindings automáticas que possam ter sobrado ---
            txtID.DataBindings.Clear();
            txtNIF.DataBindings.Clear();
            txtNome.DataBindings.Clear();
            txtMorada.DataBindings.Clear();
            txtContacto.DataBindings.Clear();
            txtAreaLeciona.DataBindings.Clear();
            cmbDisponibilidade.DataBindings.Clear();
            numValorHora.DataBindings.Clear();
            btnLimpar.CausesValidation = false;

            // ----------------------------------------------------------------------

            // Configurar ComboBox de Disponibilidade
            cmbDisponibilidade.DataSource = Enum.GetValues(typeof(Disponibilidade));

            // Usar validadores centralizados — NIF obrigatório para Formadores
            

            // Aplicar validação de contacto centralizada (agora obrigatória/handler)
            

            // Adicionar Validating handler para garantir validação completa do contacto
            txtContacto.Validating -= TxtContacto_Validating;
            txtContacto.Validating += TxtContacto_Validating;

            // Configurar DataGridView
            ConfigurarDataGridView();

            // usar BindingSource como DataSource do grid
            dgvFormadores.DataSource = bsFormadores;

            // Carregar dados iniciais
            AtualizarListaFormadores();
        }

        private void ConfigurarDataGridView()
        {
            dgvFormadores.AutoGenerateColumns = false;
            dgvFormadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFormadores.MultiSelect = false;
            // Impede que o TAB foque automaticamente numa célula
            dgvFormadores.StandardTab = true;
            dgvFormadores.CausesValidation = false;

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

            // Guardar o formador que estava selecionado antes de atualizar a lista
            var formadorAnterior = formadorSelecionado;

            // Desligar o evento para evitar seleção automática durante a carga
            dgvFormadores.SelectionChanged -= dgvFormadores_SelectionChanged;

            // Atualizar BindingSource
            bsFormadores.DataSource = formadores;

            lblTotalFormadores.Text = $"Total de Formadores: {formadores.Count}";

            // Lógica de preservação da seleção
            bool selecaoRestaurada = false;

            if (formadores.Count > 0)
            {
                if (formadorAnterior != null)
                {
                    // Tentar encontrar e selecionar o mesmo formador (cenário de edição)
                    int index = formadores.FindIndex(f => f.Id == formadorAnterior.Id);
                    if (index >= 0)
                    {
                        dgvFormadores.ClearSelection();
                        dgvFormadores.Rows[index].Selected = true;
                        try { dgvFormadores.CurrentCell = dgvFormadores.Rows[index].Cells[0]; } catch { /* ignora */ }

                        // Atualizar referência e carregar dados atualizados
                        formadorSelecionado = formadores[index];
                        CarregarDadosFormador(formadorSelecionado);
                        HabilitarBotoesEdicao(true);
                        selecaoRestaurada = true;
                    }
                }
            }

            // Se não conseguimos restaurar uma seleção (ex: início do form ou item removido), limpar tudo
            if (!selecaoRestaurada)
            {
                // --- CORREÇÃO: Forçar anulação da célula atual para não ficar com "borda" na linha 0
                dgvFormadores.ClearSelection();
                dgvFormadores.CurrentCell = null;
                LimparCampos();
            }

            // Voltar a ligar o evento
            dgvFormadores.SelectionChanged += new System.EventHandler(this.dgvFormadores_SelectionChanged);
        }

        private void dgvFormadores_SelectionChanged(object sender, EventArgs e)
        {
            // Ignorar eventos de seleção durante a inicialização do form
            if (inicializando)
                return;

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
                // Se o utilizador clicar no vazio ou a seleção for limpa programaticamente
                LimparCampos();
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

            // Proteção contra valores nulos no combo
            if (Enum.IsDefined(typeof(Disponibilidade), formador.Disponibilidade))
                cmbDisponibilidade.SelectedItem = formador.Disponibilidade;
            else
                cmbDisponibilidade.SelectedIndex = 0;

            numValorHora.Value = formador.ValorHora;

            // DataFimContrato: clamp + safe assign
            DateTime safeFim = Clamp(formador.DataFimContrato, dtpDataFimContrato.MinDate, dtpDataFimContrato.MaxDate);
            DateTimeHelper.DefinirValorSeguro(dtpDataFimContrato, safeFim);

            // DataRegistoCriminal
            DateTime fallbackRegisto = DateTime.Now.AddYears(5);
            DateTime dataRegistoCriminal;
            try
            {
                // Se for MinValue (não definida), usa fallback
                dataRegistoCriminal = formador.DataFimRegistoCrim == DateTime.MinValue ? fallbackRegisto : formador.DataFimRegistoCrim;
            }
            catch
            {
                dataRegistoCriminal = fallbackRegisto;
            }

            DateTime safeRegisto = Clamp(dataRegistoCriminal, dtpDataRegistoCriminal.MinDate, dtpDataRegistoCriminal.MaxDate);
            DateTimeHelper.DefinirValorSeguro(dtpDataRegistoCriminal, safeRegisto);

            // Verificar status do registo criminal
            VerificarStatusRegistoCriminal(formador);
        }

        private void VerificarStatusRegistoCriminal(Formador formador)
        {
            // Usar DataSimulada se estiver configurada; caso contrário, usar data actual.
            DateTime referencia = (empresa != null && empresa.DataSimulada > DateTime.MinValue)
                ? empresa.DataSimulada.Date
                : DateTime.Now.Date;

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

            // Opcional: Se quiser bloquear a inserção enquanto edita
            // btnInserir.Enabled = !habilitar; 
        }

        private void LimparCampos()
        {
            txtID.Clear();
            txtNIF.Clear();
            txtNome.Clear();
            txtMorada.Clear();
            txtContacto.Clear();
            txtAreaLeciona.Clear();

            if (cmbDisponibilidade.Items.Count > 0)
                cmbDisponibilidade.SelectedIndex = 0;

            numValorHora.Value = 0;

            // Valores seguros por defeito
            DateTimeHelper.DefinirValorSeguro(dtpDataFimContrato, DateTime.Now.AddYears(1));
            DateTimeHelper.DefinirValorSeguro(dtpDataRegistoCriminal, DateTime.Now.AddYears(5));
            lblStatusRegistoCriminal.Text = "";

            formadorSelecionado = null;
            HabilitarBotoesEdicao(false);
        }

        // ==================== EVENTOS DE BOTÕES ====================

        private void btnInserir_Click(object sender, EventArgs e)
        {
            // Validar campos usando o conjunto centralizado (contacto valida formato)
            if (!ValidarCampos.ValidarEMostrar(
                ValidarCampos.ValidarCampoObrigatorio(txtNome.Text, "o nome do formador"),
                ValidarCampos.ValidarContacto(txtContacto.Text, obrigatorio: true),
                ValidarCampos.ValidarCampoObrigatorio(txtAreaLeciona.Text, "a área que o formador leciona"),
                ValidarCampos.ValidarValorMaiorQueZero(numValorHora, "Valor por hora"),
                ValidarCampos.ValidarNIF(txtNIF.Text, obrigatorio: true)
            ))
            {
                return;
            }

            // obter NIF com segurança
            if (!ValidarCampos.TentarObterNIF(txtNIF.Text, out int nif))
            {
                DialogHelper.MostrarAviso("NIF inválido.");
                txtNIF.Focus();
                return;
            }

            // duplicado
            if (nif > 0 && empresa != null && empresa.NifDuplicado(nif))
            {
                DialogHelper.MostrarAviso("Já existe um funcionário com este NIF.", "NIF Duplicado");
                txtNIF.Focus();
                return;
            }

            // validar data
            var validacaoData = DateTimeHelper.ValidarDataFutura(dtpDataFimContrato.Value, DateTime.Now, "Data de fim de contrato");
            if (!validacaoData.Valido)
            {
                validacaoData.MostrarMensagem();
                return;
            }

            try
            {
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

                DialogHelper.MostrarSucesso($"Formador '{novoFormador.Nome}' inserido com sucesso!");
            }
            catch (Exception ex)
            {
                DialogHelper.ErroOperacao("inserir formador", ex);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (formadorSelecionado == null)
            {
                DialogHelper.AvisoSelecionarItem("alterar", "formador");
                return;
            }

            if (!ValidarCampos.ValidarEMostrar(
                ValidarCampos.ValidarCampoObrigatorio(txtNome.Text, "o nome do formador"),
                // Usar a validação centralizada de contacto (9 dígitos começando por 9)
                ValidarCampos.ValidarContacto(txtContacto.Text, obrigatorio: true),
                ValidarCampos.ValidarCampoObrigatorio(txtAreaLeciona.Text, "a área que o formador leciona"),
                ValidarCampos.ValidarValorMaiorQueZero(numValorHora, "Valor por hora"),
                ValidarCampos.ValidarNIF(txtNIF.Text, obrigatorio: true)
            ))
            {
                return;
            }

            // obter NIF com segurança
            if (!ValidarCampos.TentarObterNIF(txtNIF.Text, out int nif))
            {
                DialogHelper.MostrarAviso("NIF inválido.");
                txtNIF.Focus();
                return;
            }

            if (nif > 0 && empresa != null && empresa.NifDuplicado(nif, formadorSelecionado.Id))
            {
                DialogHelper.MostrarAviso("Outro formador já utiliza este NIF. Corrija o NIF.", "NIF Duplicado");
                txtNIF.Focus();
                return;
            }

            var validacaoData = DateTimeHelper.ValidarDataFutura(dtpDataFimContrato.Value, DateTime.Now, "Data de fim de contrato");
            if (!validacaoData.Valido)
            {
                validacaoData.MostrarMensagem();
                return;
            }

            // aplicar alterações ao objeto e persistir via Empresa
            try
            {
                formadorSelecionado.Nome = txtNome.Text.Trim();
                formadorSelecionado.Morada = txtMorada.Text.Trim();
                formadorSelecionado.Contacto = txtContacto.Text.Trim();
                formadorSelecionado.AreaLeciona = txtAreaLeciona.Text.Trim();
                formadorSelecionado.Disponibilidade = (Disponibilidade)cmbDisponibilidade.SelectedItem;
                formadorSelecionado.ValorHora = numValorHora.Value;
                formadorSelecionado.DataFimContrato = dtpDataFimContrato.Value;
                formadorSelecionado.DataFimRegistoCrim = dtpDataRegistoCriminal.Value;

                // actualizar NIF
                formadorSelecionado.Nif = nif;

                // Persistir via Empresa (se existir método especifico)
                empresa.AtualizarFormador(formadorSelecionado);

                AtualizarListaFormadores();

                DialogHelper.MostrarSucesso($"Formador '{formadorSelecionado.Nome}' alterado com sucesso!");
            }
            catch (Exception ex)
            {
                DialogHelper.ErroOperacao("alterar formador", ex);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (formadorSelecionado == null)
            {
                DialogHelper.AvisoSelecionarItem("remover", "formador");
                return;
            }

            if (!DialogHelper.ConfirmarRemocao(formadorSelecionado.Nome, "o formador"))
                return;

            try
            {
                empresa.RemoverFuncionario(formadorSelecionado);
                AtualizarListaFormadores();
                // O AtualizarListaFormadores já limpa se a lista ficar vazia, mas podemos forçar:
                if (dgvFormadores.Rows.Count == 0) LimparCampos();

                DialogHelper.MostrarSucesso("Formador removido com sucesso!");
            }
            catch (Exception ex)
            {
                DialogHelper.ErroOperacao("remover formador", ex);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            if (dgvFormadores.Rows.Count > 0)
            {
                dgvFormadores.ClearSelection();
                dgvFormadores.CurrentCell = null; // Remove foco
            }
        }

        private void btnCalcularValor_Click(object sender, EventArgs e)
        {
            if (formadorSelecionado == null)
            {
                DialogHelper.MostrarAviso("Selecione um formador para calcular o valor da formação.", "Aviso");
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
                DialogHelper.AvisoSelecionarItem("atualizar", "formador");
                return;
            }

            DateTime? novaData = DialogHelper.DialogoAtualizarRegistoCriminal(this);

            if (novaData.HasValue)
            {
                try
                {
                    formadorSelecionado.DataFimRegistoCrim = novaData.Value;
                    AtualizarListaFormadores();
                    // Como AtualizarListaFormadores tenta restaurar a seleção,
                    // devemos garantir que os detalhes na UI estão sincronizados
                    if (formadorSelecionado != null) CarregarDadosFormador(formadorSelecionado);

                    DialogHelper.MostrarSucesso("Registo criminal atualizado!");
                }
                catch (Exception ex)
                {
                    DialogHelper.ErroOperacao("atualizar registo criminal", ex);
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

        // Validating handler para contacto que usa a validação centralizada em ValidarCampos
        private void TxtContacto_Validating(object sender, CancelEventArgs e)
        {
            // Nota: Se o campo estiver vazio e não for obrigatório neste contexto, ajustar a validação.
            // Aqui assumimos obrigatório conforme definido no ConfigurarForm
            var resultado = ValidarCampos.ValidarContacto(txtContacto.Text, obrigatorio: true);
            if (!resultado.Valido)
            {
                e.Cancel = true;
                resultado.MostrarMensagem();
            }
        }
    }
}
