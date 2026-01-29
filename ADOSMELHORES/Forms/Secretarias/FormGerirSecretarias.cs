using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADOSMELHORES.Modelos;

namespace ADOSMELHORES.Forms.Secretarias
{    
    public partial class FormGerirSecretarias : Form
    {
        private Empresa empresa;
        private Secretaria secretariaSelecionada;
        public FormGerirSecretarias(Empresa empresaRef)
        {
            InitializeComponent();
            empresa = empresaRef;

            //ConfigurarForm(); estava sendo chamado muito cedo antes do InitializeComponent terminar,
            //substitui por um evento Load do form
            this.Load += FormGerirSecretarias_Load;
        }
        //novo
        private void FormGerirSecretarias_Load(object sender, EventArgs e)
        {
            ConfigurarForm();
        }

        private void ConfigurarForm()
        {
            // Configurar DataGridView
            ConfigurarDataGridView();

            // Configurar evento de mudança de área para carregar diretores
            listBoxArea.SelectedIndexChanged += listBoxArea_SelectedIndexChanged;

            // Eventos para validação em tempo real
            txtNome.TextChanged += ValidarCamposParaHabilitarInserir;
            txtNIF.TextChanged += ValidarCamposParaHabilitarInserir;
            txtMorada.TextChanged += ValidarCamposParaHabilitarInserir;
            txtContacto.TextChanged += ValidarCamposParaHabilitarInserir;
            numSalarioBase.ValueChanged += ValidarCamposParaHabilitarInserir;
            dtpDataFimContrato.ValueChanged += ValidarCamposParaHabilitarInserir;
            listBoxArea.SelectedIndexChanged += ValidarCamposParaHabilitarInserir;
            checkedListBoxIdiomas.ItemCheck += ValidarCamposParaHabilitarInserir;

            // Carregar dados iniciais
            AtualizarListaSecretarias();

            // Estado inicial dos botões
            btnInserir.Enabled = false;
        }

        private void ConfigurarDataGridView()
        {
            dgvSecretarias.AutoGenerateColumns = false;
            dgvSecretarias.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSecretarias.MultiSelect = false;
            dgvSecretarias.Columns.Clear();

            dgvSecretarias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",
                Width = 50
            });

            dgvSecretarias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Nome",
                Width = 200
            });

            dgvSecretarias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataFimContrato",
                HeaderText = "Data Fim Contrato",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvSecretarias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataFimRegistoCrim",
                HeaderText = "Registo Criminal",
                Width = 120,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" }
            });

            dgvSecretarias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Area",
                HeaderText = "Área de Secretaria",
                Width = 150
            });

            dgvSecretarias.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Contacto",
                HeaderText = "Contacto",
                Width = 100
            });
        }

        //NOVO AtualizarListaSecretarias
        private void AtualizarListaSecretarias()
        {
            // Usando método novo da Empresa - facilita migração para BD
            var secretarias = empresa.ObterSecretarias();

            dgvSecretarias.DataSource = null;
            dgvSecretarias.DataSource = secretarias;

            lblTotalSecretarias.Text = $"Total de Secretárias: {secretarias.Count}";

            if (secretarias.Count > 0 && dgvSecretarias.Rows.Count > 0)
            {
                dgvSecretarias.Rows[0].Selected = true;
            }
        }
                

        private void dgvSecretarias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSecretarias.SelectedRows.Count > 0)
            {
                secretariaSelecionada = dgvSecretarias.SelectedRows[0].DataBoundItem as Secretaria;
                if (secretariaSelecionada != null)
                {
                    CarregarDadosSecretaria(secretariaSelecionada);
                    HabilitarBotoesEdicao(true);
                }
            }
            else
            {
                HabilitarBotoesEdicao(false);
            }
        }

        private void CarregarDadosSecretaria(Secretaria secretaria)
        {
            // Helper para limitar valores DateTime
            DateTime Clamp(DateTime value, DateTime min, DateTime max)
            {
                if (value < min) return min;
                if (value > max) return max;
                return value;
            }

            txtNome.Text = secretaria.Nome;
            txtNIF.Text = secretaria.Nif.ToString();
            txtMorada.Text = secretaria.Morada;
            txtContacto.Text = secretaria.Contacto;
            numSalarioBase.Value = secretaria.SalarioBase;

            // Selecionar área
            if (!string.IsNullOrEmpty(secretaria.Area))
            {
                int index = listBoxArea.Items.IndexOf(secretaria.Area);
                if (index >= 0)
                {
                    listBoxArea.SelectedIndex = index;
                }
            }

            // Marcar idiomas
            CarregarIdiomas(secretaria);

            // Datas
            try
            {
                DateTime safeFim = Clamp(secretaria.DataFimContrato, dtpDataFimContrato.MinDate, dtpDataFimContrato.MaxDate);
                dtpDataFimContrato.Value = safeFim;
            }
            catch
            {
                dtpDataFimContrato.Value = dtpDataFimContrato.MinDate;
            }

            try
            {
                DateTime safeRegisto = Clamp(secretaria.DataFimRegistoCrim, dtpDataRegistoCriminal.MinDate, dtpDataRegistoCriminal.MaxDate);
                dtpDataRegistoCriminal.Value = safeRegisto;
            }
            catch
            {
                dtpDataRegistoCriminal.Value = dtpDataRegistoCriminal.MinDate;
            }

            // Carregar diretor responsável
            CarregarDiretoresDisponiveis();
            if (secretaria.DiretorReporta != null)
            {
                for (int i = 0; i < checkedListBoxDiretores.Items.Count; i++)
                {
                    if (checkedListBoxDiretores.Items[i] is Diretor diretor)
                    {
                        if (diretor.Id == secretaria.DiretorReporta.Id)
                        {
                            checkedListBoxDiretores.SetItemChecked(i, true);
                            break;
                        }
                    }
                }
            }
        }

        private void CarregarIdiomas(Secretaria secretaria)
        {
            // Limpar seleções
            for (int i = 0; i < checkedListBoxIdiomas.Items.Count; i++)
            {
                checkedListBoxIdiomas.SetItemChecked(i, false);
            }

            // Marcar idiomas da secretária
            if (secretaria.IdiomasFalados != null)
            {
                foreach (string idioma in secretaria.IdiomasFalados)
                {
                    int index = checkedListBoxIdiomas.Items.IndexOf(idioma);
                    if (index >= 0)
                    {
                        checkedListBoxIdiomas.SetItemChecked(index, true);
                    }
                }
            }
        }

        private void listBoxArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarDiretoresDisponiveis();
        }

        
        private void CarregarDiretoresDisponiveis()
        {
            checkedListBoxDiretores.Items.Clear();

            if (listBoxArea.SelectedItem == null)
                return;

            string areaSelecionada = listBoxArea.SelectedItem.ToString();
                        
            var todosDiretores = empresa.ObterDiretores();

            // Filtrar diretores pela área selecionada (correspondência direta)
            foreach (var diretor in todosDiretores)
            {
                bool podeSerResponsavel = false;

                if (diretor.AreasDiretoria != null)
                {
                    // Verificar se o diretor tem a mesma área que a secretária                    
                    podeSerResponsavel = diretor.AreasDiretoria.Contains(areaSelecionada);
                }

                if (podeSerResponsavel)
                {
                    checkedListBoxDiretores.Items.Add(diretor);
                }
            }
        }

       
        private void ValidarCamposParaHabilitarInserir(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                bool camposPreenchidos = !string.IsNullOrWhiteSpace(txtNome.Text) &&
                                          !string.IsNullOrWhiteSpace(txtNIF.Text) &&
                                          !string.IsNullOrWhiteSpace(txtMorada.Text) &&
                                          !string.IsNullOrWhiteSpace(txtContacto.Text) &&
                                          numSalarioBase.Value > 0 &&
                                          dtpDataFimContrato.Value > DateTime.Now &&
                                          listBoxArea.SelectedItem != null &&
                                          checkedListBoxIdiomas.CheckedItems.Count > 0;

                btnInserir.Enabled = camposPreenchidos;
            }));
        }

        private void HabilitarBotoesEdicao(bool habilitar)
        {
            btnAlterar.Enabled = habilitar;
            btnRemover.Enabled = habilitar;
            btnAtualizarRegistoCriminal.Enabled = habilitar;
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtNIF.Clear();
            txtMorada.Clear();
            txtContacto.Clear();
            numSalarioBase.Value = 0;

            // Limpar seleção de área
            listBoxArea.SelectedIndex = -1;

            // Limpar seleção de idiomas
            for (int i = 0; i < checkedListBoxIdiomas.Items.Count; i++)
            {
                checkedListBoxIdiomas.SetItemChecked(i, false);
            }

            // Limpar diretores
            checkedListBoxDiretores.Items.Clear();

            // Valores padrão
            try { dtpDataFimContrato.Value = DateTime.Now.AddYears(1); } catch { }
            try { dtpDataRegistoCriminal.Value = DateTime.Now.AddYears(5); } catch { }

            secretariaSelecionada = null;
            btnInserir.Enabled = false;
        }

        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Por favor, insira o nome da secretária.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNome.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNIF.Text) || !int.TryParse(txtNIF.Text, out _))
            {
                MessageBox.Show("Por favor, insira um NIF válido.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIF.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtContacto.Text))
            {
                MessageBox.Show("Por favor, insira o contacto.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContacto.Focus();
                return false;
            }

            if (listBoxArea.SelectedItem == null)
            {
                MessageBox.Show("Por favor, selecione uma área de secretaria.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                listBoxArea.Focus();
                return false;
            }

            if (checkedListBoxIdiomas.CheckedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecione pelo menos um idioma.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                checkedListBoxIdiomas.Focus();
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
                // Obter diretor selecionado (apenas 1)
                Diretor diretorSelecionado = null;
                foreach (var item in checkedListBoxDiretores.CheckedItems)
                {
                    diretorSelecionado = item as Diretor;
                    break; // Pega apenas o primeiro
                }

                var novaSecretaria = new Secretaria(
                    empresa.ObterProximoID(),
                    int.Parse(txtNIF.Text),
                    txtNome.Text.Trim(),
                    txtMorada.Text.Trim(),
                    txtContacto.Text.Trim(),
                    numSalarioBase.Value,
                    dtpDataFimContrato.Value,
                    DateTime.Now, // DataIniContrato
                    dtpDataRegistoCriminal.Value,
                    DateTime.Now, // DataNascimento - você pode adicionar um campo se necessário
                    listBoxArea.SelectedItem.ToString(),
                    diretorSelecionado
                );

                // Adicionar idiomas selecionados
                foreach (var idioma in checkedListBoxIdiomas.CheckedItems)
                {
                    novaSecretaria.IdiomasFalados.Add(idioma.ToString());
                }

                // Se tiver diretor, adicionar à lista de subordinadas do diretor
                if (diretorSelecionado != null)
                {
                    diretorSelecionado.AdicionarSecretaria(novaSecretaria);
                }

                empresa.AdicionarFuncionario(novaSecretaria);
                AtualizarListaSecretarias();
                LimparCampos();

                MessageBox.Show($"Secretária '{novaSecretaria.Nome}' inserida com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir secretária: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (secretariaSelecionada == null)
            {
                MessageBox.Show("Selecione uma secretária para alterar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!ValidarCampos())
                return;

            try
            {
                // Remover da lista do diretor antigo
                if (secretariaSelecionada.DiretorReporta != null)
                {
                    secretariaSelecionada.DiretorReporta.RemoverSecretaria(secretariaSelecionada);
                }

                secretariaSelecionada.Nome = txtNome.Text.Trim();
                secretariaSelecionada.Nif = int.Parse(txtNIF.Text);
                secretariaSelecionada.Morada = txtMorada.Text.Trim();
                secretariaSelecionada.Contacto = txtContacto.Text.Trim();
                secretariaSelecionada.SalarioBase = numSalarioBase.Value;
                secretariaSelecionada.DataFimContrato = dtpDataFimContrato.Value;
                secretariaSelecionada.DataFimRegistoCrim = dtpDataRegistoCriminal.Value;
                secretariaSelecionada.Area = listBoxArea.SelectedItem.ToString();

                // Atualizar idiomas
                secretariaSelecionada.IdiomasFalados.Clear();
                foreach (var idioma in checkedListBoxIdiomas.CheckedItems)
                {
                    secretariaSelecionada.IdiomasFalados.Add(idioma.ToString());
                }

                // Atualizar diretor responsável
                Diretor novoDiretor = null;
                foreach (var item in checkedListBoxDiretores.CheckedItems)
                {
                    novoDiretor = item as Diretor;
                    break;
                }

                if (novoDiretor != null)
                {
                    novoDiretor.AdicionarSecretaria(secretariaSelecionada);
                }
                else
                {
                    secretariaSelecionada.DiretorReporta = null;
                }

                AtualizarListaSecretarias();

                MessageBox.Show($"Secretária '{secretariaSelecionada.Nome}' alterada com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao alterar secretária: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (secretariaSelecionada == null)
            {
                MessageBox.Show("Selecione uma secretária para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                $"Tem certeza que deseja remover a secretária '{secretariaSelecionada.Nome}'?",
                "Confirmar Remoção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    // Remover da lista do diretor
                    if (secretariaSelecionada.DiretorReporta != null)
                    {
                        secretariaSelecionada.DiretorReporta.RemoverSecretaria(secretariaSelecionada);
                    }

                    // ✅ Usando método novo da Empresa
                    bool removido = empresa.RemoverSecretariaPorId(secretariaSelecionada.Id);

                    if (removido)
                    {
                        AtualizarListaSecretarias();
                        LimparCampos();

                        MessageBox.Show("Secretária removida com sucesso!", "Sucesso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Erro ao remover secretária.", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao remover secretária: {ex.Message}", "Erro",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
            if (dgvSecretarias.Rows.Count > 0)
            {
                dgvSecretarias.ClearSelection();
            }
        }

        private void btnAtualizarRegistoCriminal_Click(object sender, EventArgs e)
        {
            if (secretariaSelecionada == null)
            {
                MessageBox.Show("Selecione uma secretária para atualizar o registo criminal.", "Aviso",
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
                    secretariaSelecionada.DataFimRegistoCrim = DateTime.Now.AddYears(5);
                    dtpDataRegistoCriminal.Value = secretariaSelecionada.DataFimRegistoCrim;
                    AtualizarListaSecretarias();

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
}
