using ADOSMELHORES;
using ADOSMELHORES.Forms;
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
using ADOSMELHORES.Validacoes;

namespace ADOSMELHORES.Forms.Diretores
{
    // Form completo para gestão de Diretores
    
    public partial class FormGerirDiretores : Form
    {
        private Empresa empresa;
        private Diretor diretorSelecionado;
        private Diretor diretorTemporario; //Armazenar o diretor para calcular a remuneração antes de inserir/salvar
        private bool remuneracaoCalculada = false; // Flag para controlar se a remuneração foi calculada

        public FormGerirDiretores(Empresa empresaRef)
        {
            InitializeComponent();
            empresa = empresaRef;

            //ConfigurarForm(); estava sendo chamado muito cedo antes do InitializeComponent terminar,
            //substitui por um evento Load do form
            this.Load += FormGerirDiretores_Load;
        }
            
        private void FormGerirDiretores_Load(object sender, EventArgs e)
        {
            ConfigurarForm();
        }

        private void ConfigurarForm()
        {
            //novo
            ValidarCampos.ConfigurarTextBoxNIF(txtNIF, obrigatorio: true);
            ValidarCampos.ConfigurarTextBoxContacto(txtContacto, obrigatorio: true);

            // Configurar DataGridView
            ConfigurarDataGridView();

            // Configurar evento para áreas de direção
            checkedListBoxAreasDiretoria.ItemCheck += checkedListBoxAreasDiretoria_ItemCheck;
                       
            // Eventos para validação em tempo real para habilitar o botão Calcular Remuneração
            txtNome.TextChanged += ValidarCamposParaCalcular;
            txtMorada.TextChanged += ValidarCamposParaCalcular;
            txtContacto.TextChanged += ValidarCamposParaCalcular;
            numSalarioBase.ValueChanged += ValidarCamposParaCalcular;
            dtpDataFimContrato.ValueChanged += ValidarCamposParaCalcular;
            checkedListBoxAreasDiretoria.ItemCheck += ValidarCamposParaCalcular;
            checkedListBoxSecretarias.ItemCheck += ValidarCamposParaCalcular;

            // Carregar dados iniciais
            AtualizarListaDiretores();

            //Estado inicial dos botões Calcular Remuneração e Inserir Novo Diretor
            btnCalcularValor.Enabled = false;
            btnInserir.Enabled = false;
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
                DataPropertyName = "AreasDiretoriaString",
                HeaderText = "Áreas",
                Width = 200
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

        // Eventos para secretarias e areas de direção
        private void checkedListBoxAreasDiretoria_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Este método será executado quando uma área for marcada/desmarcada
            // Usamos um timer para atualizar depois que a mudança for concluída
            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
            timer.Interval = 100;
            timer.Tick += (s, args) =>
            {
                CarregarSecretariasDisponiveis();
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void CarregarSecretariasDisponiveis()
        {
            checkedListBoxSecretarias.Items.Clear();

            var todasSecretarias = empresa.ObterSecretarias();

            // Obter as áreas selecionadas do diretor
            List<string> areasSelecionadas = new List<string>();
            foreach (var item in checkedListBoxAreasDiretoria.CheckedItems)
            {
                areasSelecionadas.Add(item.ToString());
            }

            // Se não houver áreas selecionadas, não mostrar secretárias
            if (areasSelecionadas.Count == 0)
            {
                return;
            }

            // Filtrar secretárias pelas áreas selecionadas
            // correspondência direta entre área do diretor e área da secretária
            foreach (var secretaria in todasSecretarias)
            {
                bool pertenceAreaSelecionada = false;

                foreach (string area in areasSelecionadas)
                {
                    // Verificar se a secretária pertence à mesma área do diretor
                    if (secretaria.Area == area)
                    {
                        pertenceAreaSelecionada = true;
                        break;
                    }
                }

                // Adicionar apenas secretárias que pertencem às áreas selecionadas
                if (pertenceAreaSelecionada)
                {
                    checkedListBoxSecretarias.Items.Add(secretaria);
                }
            }
            AtualizarEstadoBotoes();
        }

        // Atualização de dados

        private void AtualizarListaDiretores()
        {            
            var diretores = empresa.ObterDiretores();

            dgvDiretores.DataSource = null;
            dgvDiretores.DataSource = diretores;

            lblTotalDiretores.Text = $"Total de Diretores: {diretores.Count}";

            if (diretores.Count > 0 && dgvDiretores.Rows.Count > 0)
            {
                dgvDiretores.Rows[0].Selected = true;
            }
        }

       
        private void LimparCampos()
        {
            txtNIF.Clear();
            txtNome.Clear();
            txtMorada.Clear();
            txtContacto.Clear();
            numSalarioBase.Value = 0;

            // Limpar seleção de áreas
            for (int i = 0; i < checkedListBoxAreasDiretoria.Items.Count; i++)
            {
                checkedListBoxAreasDiretoria.SetItemChecked(i, false);
            }

            // Limpar seleção de secretárias
            checkedListBoxSecretarias.Items.Clear();

            // Valores seguros por defeito
            try { DateTimeHelper.DefinirValorSeguro(dtpDataFimContrato, DateTime.Now.AddYears(1)); } catch { }
            try { DateTimeHelper.DefinirValorSeguro(dtpDataRegistoCriminal, DateTime.Now.AddYears(1)); } catch { }
            lblStatusRegistoCriminal.Text = "";

            // Limpar estados
            diretorSelecionado = null;
            diretorTemporario = null;
            remuneracaoCalculada = false;

            btnCalcularValor.Enabled = false;
            btnInserir.Enabled = false;
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

        //Validação de Campos para Calcular Remuneração

        // Validar se todos os campos estão preenchidos para habilitar o botão Calcular
        private void ValidarCamposParaCalcular(object sender, EventArgs e)
        {
            // Usar BeginInvoke para processar depois da mudança no CheckedListBox
            this.BeginInvoke(new Action(() =>
            {
                AtualizarEstadoBotoes();
            }));
        }


        // Botão habilitado após calcular remuneração
        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (diretorTemporario == null)
            {
                DialogHelper.MostrarAviso("Por favor, calcule a remuneração primeiro.");                    
                return;
            }

            try
            {
                // Verificar NIF antes de inserir
                if (!ValidarCampos.TentarObterNIF(txtNIF.Text, out int nifNumero))
                {
                    DialogHelper.MostrarAviso("NIF inválido.", "Validação");
                    txtNIF.Focus();
                    return;
                }

                if (NifDuplicado(nifNumero))
                {
                    DialogHelper.MostrarAviso($"O NIF '{nifNumero}' já está registado por outro funcionário.", "NIF Duplicado");
                    txtNIF.Focus();
                    return;
                }

                // Atribuir NIF ao diretor temporário antes de adicionar
                diretorTemporario.Nif = nifNumero;

                empresa.AdicionarFuncionario(diretorTemporario);
                AtualizarListaDiretores();

                string nomeDiretor = diretorTemporario.Nome; // Guardar o nome antes de limpar
                LimparCampos();

                DialogHelper.MostrarSucesso($"Diretor '{nomeDiretor}' inserido com sucesso!");
            }
            catch (Exception ex)
            {
                DialogHelper.ErroOperacao("inserir diretor", ex);
            }
        }

        
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (diretorSelecionado == null)
            {
                DialogHelper.AvisoSelecionarItem("alterar", "diretor");
                return;
            }

            if (!ValidarCamposForm())
                return;

            // Validar NIF e duplicidade antes de aplicar alterações
            if (!ValidarCampos.TentarObterNIF(txtNIF.Text, out int nifNumero))
            {
                DialogHelper.MostrarAviso("NIF inválido.", "Validação");
                txtNIF.Focus();
                return;
            }

            if (NifDuplicado(nifNumero, diretorSelecionado.Id))
            {
                DialogHelper.MostrarAviso($"O NIF '{nifNumero}' já está registado por outro diretor.", "NIF Duplicado");
                txtNIF.Focus();
                return;
            }

            try
            {
                diretorSelecionado.Nif = nifNumero;
                diretorSelecionado.Nome = txtNome.Text.Trim();
                diretorSelecionado.Morada = txtMorada.Text.Trim();
                diretorSelecionado.Contacto = txtContacto.Text.Trim();
                diretorSelecionado.SalarioBase = numSalarioBase.Value;
                diretorSelecionado.DataFimContrato = dtpDataFimContrato.Value;
                diretorSelecionado.DataFimRegistoCrim = dtpDataRegistoCriminal.Value;

                // Atualizar Áreas de direção
                diretorSelecionado.AreasDiretoria.Clear();
                foreach (var area in checkedListBoxAreasDiretoria.CheckedItems)
                {
                    diretorSelecionado.AreasDiretoria.Add(area.ToString());
                }

                // Atualizar alocação de secretárias
                var secretariasAtuais = diretorSelecionado.SecretariasSubordinadas.ToList();
                foreach (var sec in secretariasAtuais)
                {
                    diretorSelecionado.RemoverSecretaria(sec);
                }

                foreach (var item in checkedListBoxSecretarias.CheckedItems)
                {
                    if (item is Secretaria secretaria)
                    {
                        diretorSelecionado.AdicionarSecretaria(secretaria);
                    }
                }

                AtualizarListaDiretores();

                DialogHelper.MostrarSucesso($"Diretor '{diretorSelecionado.Nome}' alterado com sucesso!");
            }
            catch (Exception ex)
            {
                DialogHelper.ErroOperacao("alterar diretor", ex);
            }
        }

        
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (diretorSelecionado == null)
            {
                DialogHelper.AvisoSelecionarItem("remover", "diretor");
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

                    // Usando método novo da Empresa
                    bool removido = empresa.RemoverDiretorPorId(diretorSelecionado.Id);

                    if (removido)
                    {
                        AtualizarListaDiretores();
                        LimparCampos();

                        DialogHelper.MostrarSucesso("Diretor removido com sucesso!");
                    }
                    else
                    {
                        DialogHelper.MostrarErro("Erro ao remover diretor.");
                    }
                }
                catch (Exception ex)
                {
                    DialogHelper.ErroOperacao("remover diretor", ex);
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



        // Criar um diretor temporário e abrir formulário de cálculo
        private void btnCalcularValor_Click(object sender, EventArgs e)
        {
            if (!ValidarCamposForm())
                return;

            try
            {
                //Criar diretor temporário com os dados preenchidos
                diretorTemporario = new Diretor(
                    empresa.ObterProximoID(),
                    0, // NIF
                    txtNome.Text.Trim(),
                    txtMorada.Text.Trim(),
                    txtContacto.Text.Trim(),
                    numSalarioBase.Value,
                    dtpDataFimContrato.Value,
                    DateTime.Now, // DataIniContrato
                    dtpDataRegistoCriminal.Value,
                    DateTime.Now, // DataNascimento
                    false, // CarroEmpresa - será definido no form de cálculo
                    false  // IsencaoHorario - será definido no form de cálculo
                );

                //Adicionar áreas de direção selecionadas
                foreach (var area in checkedListBoxAreasDiretoria.CheckedItems)
                {
                    diretorTemporario.AreasDiretoria.Add(area.ToString());
                }

                //Adicionar secretárias selecionadas
                foreach (var item in checkedListBoxSecretarias.CheckedItems)
                {
                    if (item is Secretaria secretaria)
                    {
                        diretorTemporario.AdicionarSecretaria(secretaria);
                    }
                }


                //Abrir formulário de cálculo
                using (var formCalculo = new FormsCalcularRemuneracao(diretorTemporario, empresa))
                {
                    DialogResult resultado = formCalculo.ShowDialog();

                    if (resultado == DialogResult.OK)
                    {
                        // IMPORTANTE: O diretor temporário JÁ FOI MODIFICADO pelo formulário
                        //O BonusMensal é calculado automaticamente quando acessado
                        // porque passamos a REFERÊNCIA do objeto
                        remuneracaoCalculada = true;

                        AtualizarEstadoBotoes();
                        
                        DialogHelper.MostrarSucesso(
                            "Remuneração calculada com sucesso!\n\n" +
                            "Agora você pode clicar em 'Inserir Novo' para salvar o diretor.");
                    }
                    else
                    {
                        //Se cancelou, limpa tudo
                        System.Diagnostics.Debug.WriteLine("Usuário cancelou o cálculo");
                        diretorTemporario = null;
                        remuneracaoCalculada = false;
                        AtualizarEstadoBotoes();
                    }
                }
            }
            catch (Exception ex)
            {
                DialogHelper.ErroOperacao("calcular remuneração", ex);                

                //Em caso de erro, limpa
                diretorTemporario = null;
                remuneracaoCalculada = false;
                AtualizarEstadoBotoes();
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
                        
            txtNome.Text = diretor.Nome;
            txtNIF.Text = diretor.Nif.ToString();
            txtMorada.Text = diretor.Morada;
            txtContacto.Text = diretor.Contacto;
            numSalarioBase.Value = diretor.SalarioBase;
            
            CarregarAreasDiretoria(diretor);

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
            MarcarSecretariasAlocadas(diretor);
            VerificarStatusRegistoCriminal(diretor);

            remuneracaoCalculada = true;
            AtualizarEstadoBotoes();            
        }

        private void CarregarAreasDiretoria(Diretor diretor)
        {
            // Limpar todas as seleções
            for (int i = 0; i < checkedListBoxAreasDiretoria.Items.Count; i++)
            {
                checkedListBoxAreasDiretoria.SetItemChecked(i, false);
            }

            // Marcar as áreas do diretor
            foreach (string area in diretor.AreasDiretoria)
            {
                int index = checkedListBoxAreasDiretoria.Items.IndexOf(area);
                if (index >= 0)
                {
                    checkedListBoxAreasDiretoria.SetItemChecked(index, true);
                }
            }
        }
                


        // Marcar secretárias já alocadas ao diretor 
        private void MarcarSecretariasAlocadas(Diretor diretor)
        {
            if (diretor == null || diretor.SecretariasSubordinadas == null)
                return;

            for (int i = 0; i < checkedListBoxSecretarias.Items.Count; i++)
            {
                if (checkedListBoxSecretarias.Items[i] is Secretaria secretaria)
                {
                    bool estaAlocada = diretor.SecretariasSubordinadas.Contains(secretaria);
                    checkedListBoxSecretarias.SetItemChecked(i, estaAlocada);
                }
            }
        }
               

        //Controla o estado de TODOS os botões
        private void AtualizarEstadoBotoes()
        {
            // Verificar se todos os campos obrigatórios estão preenchidos
            bool camposPreenchidos = !string.IsNullOrWhiteSpace(txtNome.Text) &&
                                      !string.IsNullOrWhiteSpace(txtMorada.Text) &&
                                      !string.IsNullOrWhiteSpace(txtContacto.Text) &&
                                      numSalarioBase.Value > 0 &&
                                      dtpDataFimContrato.Value > DateTime.Now &&
                                      checkedListBoxAreasDiretoria.CheckedItems.Count > 0 &&
                                      checkedListBoxSecretarias.CheckedItems.Count > 0;

            // Botão Calcular: habilitado se campos estão preenchidos E remuneração ainda não foi calculada
            btnCalcularValor.Enabled = camposPreenchidos && !remuneracaoCalculada;

            // Botão Inserir: habilitado APENAS se a remuneração foi calculada
            btnInserir.Enabled = remuneracaoCalculada && diretorTemporario != null;
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
                ValidarCampos.ValidarCampoObrigatorio(txtNome.Text, "o nome do diretor"),
                ValidarCampos.ValidarNIF(txtNIF.Text, obrigatorio: true),
                ValidarCampos.ValidarContacto(txtContacto.Text, obrigatorio: true)
                ))
            {   
                return false; 
            }

            if (checkedListBoxAreasDiretoria.CheckedItems.Count == 0)
            {
                DialogHelper.MostrarAviso("Selecione pelo menos uma área de direção.", "Campo Obrigatório");
                checkedListBoxAreasDiretoria.Focus();
                return false;
            }

            //Verificar duplicidade de áreas com outros diretores
            foreach (var areaSelecionada in checkedListBoxAreasDiretoria.CheckedItems)
            {
                string area = areaSelecionada.ToString();
                bool areaOcupada = empresa.Funcionarios.OfType<Diretor>()
                    .Where(d => d.Id != (diretorSelecionado?.Id ?? 0)) // Excluir o próprio diretor em edição
                    .Any(d => d.AreasDiretoria.Contains(area));

                if (areaOcupada)
                {
                    DialogHelper.MostrarAviso(
                        $"A área '{area}' já está ocupada por outro diretor!",
                        "Área Ocupada");
                    return false;
                }
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


        //Registo criminal: atualizar data e verificar status

        private void btnAtualizarRegistoCriminal_Click(object sender, EventArgs e)
        {
            if (diretorSelecionado == null)
            {
                DialogHelper.AvisoSelecionarItem("atualizar o registo criminal", "diretor");
                return;
            }

            var novaData = DialogHelper.DialogoAtualizarRegistoCriminal(this);

            if (novaData.HasValue)
            {
                try
                {
                    diretorSelecionado.DataFimRegistoCrim = novaData.Value;
                    dtpDataRegistoCriminal.Value = diretorSelecionado.DataFimRegistoCrim;
                    AtualizarListaDiretores();
                    VerificarStatusRegistoCriminal(diretorSelecionado);

                    DialogHelper.MostrarSucesso("Registo criminal atualizado com sucesso!");
                }
                catch (Exception ex)
                {
                    DialogHelper.ErroOperacao("atualizar registo criminal", ex);
                }
            }
        }


        private void VerificarStatusRegistoCriminal(Diretor diretor)
        {
            if (diretor == null) return;

            DialogHelper.AtualizarStatusRegistoCriminal(
                txtStatusRegistoCriminal,
                diretor,
                empresa.DataSimulada > DateTime.MinValue ? empresa.DataSimulada : (DateTime?)null
            );
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool NifDuplicado(int nif, int? excludeId = null)
        {
            return empresa.Funcionarios
                .OfType<Diretor>()
                .Any(d => d.Nif == nif && (!excludeId.HasValue || d.Id != excludeId.Value));
        }
    }
        
}
