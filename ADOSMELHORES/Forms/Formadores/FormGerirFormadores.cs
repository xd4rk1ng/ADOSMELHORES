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

        public FormGerirFormadores(Empresa empresaRef) 
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

            // Usar validadores centralizados — NIF obrigatório para Formadores
            ValidarCampos.ConfigurarTextBoxNIF(txtNIF, obrigatorio: true);

            // Aplicar validação de contacto centralizada (agora obrigatória/handler)
            ValidarCampos.ConfigurarTextBoxContacto(txtContacto, obrigatorio: true);

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
            DateTime safeFim = Clamp(formador.DataFimContrato, dtpDataFimContrato.MinDate, dtpDataFimContrato.MaxDate);
            DateTimeHelper.DefinirValorSeguro(dtpDataFimContrato, safeFim);

            // DataRegistoCriminal
            DateTime fallbackRegisto = DateTime.Now.AddYears(5);
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
            txtNIF.Clear(); 
            txtNome.Clear();
            txtMorada.Clear();
            txtContacto.Clear();
            txtAreaLeciona.Clear();
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
            if (nif > 0 && NifDuplicado(nif, /* excludeId quando alterar */ null))
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

            if (nif > 0 && NifDuplicado(nif, formadorSelecionado.Id))
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
                LimparCampos();

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
                    CarregarDadosFormador(formadorSelecionado);
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

       
        // novo helper para verificar duplicados de NIF
        private bool NifDuplicado(int nif, int? excludeId = null)
        {
            if (nif <= 0) return false; // mantém a regra original
            return empresa != null && empresa.NifDuplicado(nif, excludeId);
        }

        // Validating handler para contacto que usa a validação centralizada em ValidarCampos
        private void TxtContacto_Validating(object sender, CancelEventArgs e)
        {
            var resultado = ValidarCampos.ValidarContacto(txtContacto.Text, obrigatorio: true);
            if (!resultado.Valido)
            {
                e.Cancel = true;
                resultado.MostrarMensagem();
            }
        }
    }
}