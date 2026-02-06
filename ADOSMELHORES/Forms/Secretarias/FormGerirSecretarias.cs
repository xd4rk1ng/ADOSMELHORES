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
using ADOSMELHORES.Validacoes;

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
            DateTimeHelper.DefinirValorSeguro(dtpDataFimContrato, DateTime.Now.AddYears(1));
            DateTimeHelper.DefinirValorSeguro(dtpDataRegistoCriminal, DateTime.Now.AddYears(1));

            secretariaSelecionada = null;
            btnInserir.Enabled = false;
        }


        private void CarregarDadosSecretaria(Secretaria secretaria)
        {
            
            txtNome.Text = secretaria.Nome;
            txtNIF.Text = secretaria.Nif.ToString();
            txtMorada.Text = secretaria.Morada;
            txtContacto.Text = secretaria.Contacto;
            numSalarioBase.Value = secretaria.SalarioBase;

            DateTimeHelper.DefinirValorSeguro(dtpDataFimContrato, secretaria.DataFimContrato);
            DateTimeHelper.DefinirValorSeguro(dtpDataRegistoCriminal, secretaria.DataFimRegistoCrim);
                                  


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
            DialogHelper.AtualizarStatusRegistoCriminal(
                txtStatusRegistoCriminal,
                secretaria,
                empresa.DataSimulada > DateTime.MinValue ? empresa.DataSimulada : (DateTime?)null
            );
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

                
        private bool ValidarCamposForm()
        {
            if (!ValidarCampos.ValidarEMostrar(
                ValidarCampos.ValidarCampoObrigatorio(txtNome.Text, "o nome da secretária"),
                ValidarCampos.ValidarNIF(txtNIF.Text, obrigatorio: true),
                ValidarCampos.ValidarContacto(txtContacto.Text, obrigatorio: true)
            ))
            {
                return false;
            }

            if (listBoxArea.SelectedItem == null)
            {
                DialogHelper.MostrarAviso("Por favor, selecione uma área de secretaria.", "Campo Obrigatório");
                listBoxArea.Focus();
                return false;
            }

            if (checkedListBoxIdiomas.CheckedItems.Count == 0)
            {
                DialogHelper.MostrarAviso("Por favor, selecione pelo menos um idioma.", "Campo Obrigatório");
                checkedListBoxIdiomas.Focus();
                return false;
            }

            var validacaoData = DateTimeHelper.ValidarDataFutura(
                dtpDataFimContrato.Value,
                DateTime.Now,
                "Data de fim de contrato"
            );

            if (!validacaoData.Valido)
            {
                validacaoData.MostrarMensagem();
                dtpDataFimContrato.Focus();
                return false;
            }

            return true;
        }


        // ==================== EVENTOS DE BOTÕES ====================

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposForm())
                return;

            // validar NIF com segurança
            if (!ValidarCampos.TentarObterNIF(txtNIF.Text, out int nif))
            {
                DialogHelper.MostrarAviso("NIF inválido.");
                txtNIF.Focus();
                return;
            }

            // verificar duplicado entre todos os funcionários da empresa
            if (empresa.NifDuplicado(nif))
            {
                DialogHelper.MostrarAviso("Já existe um funcionário com este NIF.", "NIF Duplicado");
                txtNIF.Focus();
                return;
            }

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
                    nif, // usa nif validado
                    txtNome.Text.Trim(),
                    txtMorada.Text.Trim(),
                    txtContacto.Text.Trim(),
                    numSalarioBase.Value,
                    dtpDataFimContrato.Value,
                    DateTime.Now, // DataIniContrato
                    dtpDataRegistoCriminal.Value,
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

                DialogHelper.MostrarSucesso($"Secretária '{novaSecretaria.Nome}' inserida com sucesso!");
            }
            catch (Exception ex)
            {
                DialogHelper.ErroOperacao("inserir secretária", ex);
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (secretariaSelecionada == null)
            {
                DialogHelper.AvisoSelecionarItem("alterar", "secretária");
                return;
            }

            if (!ValidarCamposForm())
                return;

            // validar NIF com segurança
            if (!ValidarCampos.TentarObterNIF(txtNIF.Text, out int nif))
            {
                DialogHelper.MostrarAviso("NIF inválido.");
                txtNIF.Focus();
                return;
            }

            // verificar duplicado excluindo a própria secretária, usando verificação centralizada na Empresa
            if (empresa.NifDuplicado(nif, secretariaSelecionada.Id))
            {
                DialogHelper.MostrarAviso("Outro registo já utiliza este NIF. Corrija o NIF.", "NIF Duplicado");
                txtNIF.Focus();
                return;
            }

            try
            {
                // Remover da lista do diretor antigo
                if (secretariaSelecionada.DiretorReporta != null)
                {
                    secretariaSelecionada.DiretorReporta.RemoverSecretaria(secretariaSelecionada);
                }

                secretariaSelecionada.Nome = txtNome.Text.Trim();
                secretariaSelecionada.Nif = nif; // usa nif validado
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

                DialogHelper.MostrarSucesso($"Secretária '{secretariaSelecionada.Nome}' alterada com sucesso!");
            }
            catch (Exception ex)
            {
                DialogHelper.ErroOperacao("alterar secretária", ex);
            }
        }
       
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (secretariaSelecionada == null)
            {
                DialogHelper.AvisoSelecionarItem("remover", "secretária"); 
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
                                        
                    bool removido = empresa.RemoverSecretariaPorId(secretariaSelecionada.Id);

                    if (removido)
                    {
                        AtualizarListaSecretarias();
                        LimparCampos();

                        DialogHelper.MostrarSucesso("Secretária removida com sucesso!");
                    }
                    else
                    {
                        DialogHelper.MostrarErro("Erro ao remover secretária.");
                    }
                }
                catch (Exception ex)
                {
                    DialogHelper.ErroOperacao("remover secretária", ex);
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
                DialogHelper.AvisoSelecionarItem("atualizar registo criminal", "secretária");
                return;
            }

            var novaData = DialogHelper.DialogoAtualizarRegistoCriminal(this);

            if (novaData.HasValue)
            {
                try
                {
                    secretariaSelecionada.DataFimRegistoCrim = novaData.Value;
                    dtpDataRegistoCriminal.Value = secretariaSelecionada.DataFimRegistoCrim;
                    AtualizarListaSecretarias();

                    VerificarStatusRegistoCriminal(secretariaSelecionada);

                    DialogHelper.MostrarSucesso("Registo criminal atualizado com sucesso!");
                }
                catch (Exception ex)
                {
                    DialogHelper.ErroOperacao("atualizar registo criminal", ex);
                }
            }
        }

        private void VerificarStatusRegistoCriminal(Secretaria secretaria)
        {
            if (secretaria == null) return;

            DialogHelper.AtualizarStatusRegistoCriminal(
                txtStatusRegistoCriminal,
                secretaria,
                empresa.DataSimulada > DateTime.MinValue ? empresa.DataSimulada : (DateTime?)null
            );
        }



        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
