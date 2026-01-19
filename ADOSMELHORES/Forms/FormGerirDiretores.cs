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
        private Diretor diretorTemporario; //Armazenar o diretor para calcular a remuneração antes de inserir/salvar
        private bool remuneracaoCalculada = false; // Flag para controlar se a remuneração foi calculada

        public FormGerirDiretores(Empresa empresaRef)
        {
            InitializeComponent();
            empresa = empresaRef;

            //Criar Secretárias de exemplo (se não existirem). APAGAR DEPOIS
            //CriarSecretariasExemplo();

            ConfigurarForm();
        }

        //Podemos apagar isso depois, é só para termos secretárias para alocar
        //private void CriarSecretariasExemplo()
        //{
        //    // Verificar se já existem secretárias
        //    var secretariasExistentes = empresa.Funcionarios.OfType<Secretaria>().Count();

        //    if (secretariasExistentes == 0)
        //    {
        //        // Criar algumas secretárias de exemplo
        //        var secretariasExemplo = new List<Secretaria>
        //        {
        //            new Secretaria(
        //                id: empresa.ObterProximoID(),
        //                nif: 100000001,
        //                nome: "Ana Silva",
        //                morada: "Rua das Flores, 123",
        //                contacto: "912345678",
        //                salarioBase: 900m,
        //                dataFimContrato: DateTime.Now.AddYears(2),
        //                dataIniContrato: DateTime.Now,
        //                dataFimRegistoCrim: DateTime.Now.AddYears(5),
        //                dataNascimento: new DateTime(1990, 5, 15),
        //                diretorReporta: null,
        //                area: "Administração"
        //            ),
        //            new Secretaria(
        //                id: empresa.ObterProximoID(),
        //                nif: 100000002,
        //                nome: "Maria Santos",
        //                morada: "Avenida Central, 456",
        //                contacto: "923456789",
        //                salarioBase: 950m,
        //                dataFimContrato: DateTime.Now.AddYears(3),
        //                dataIniContrato: DateTime.Now.AddMonths(-6),
        //                dataFimRegistoCrim: DateTime.Now.AddYears(4),
        //                dataNascimento: new DateTime(1988, 8, 22),
        //                diretorReporta: null,
        //                area: "Recursos Humanos"
        //            ),
        //            new Secretaria(
        //                id: empresa.ObterProximoID(),
        //                nif: 100000003,
        //                nome: "Carla Oliveira",
        //                morada: "Travessa do Comércio, 789",
        //                contacto: "934567890",
        //                salarioBase: 850m,
        //                dataFimContrato: DateTime.Now.AddYears(1),
        //                dataIniContrato: DateTime.Now.AddMonths(-3),
        //                dataFimRegistoCrim: DateTime.Now.AddYears(3),
        //                dataNascimento: new DateTime(1995, 3, 10),
        //                diretorReporta: null,
        //                area: "Financeiro"
        //            )
        //        };

        //        // Adicionar à empresa
        //        foreach (var secretaria in secretariasExemplo)
        //        {
        //            empresa.AdicionarFuncionario(secretaria);
        //        }
        //    }
        //}
        

        private void ConfigurarForm()
        {
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
                DataPropertyName = "AreasDiretoriaString", // Precisaremos desta propriedade
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
            MarcarSecretariasAlocadas(diretor);//Marcar as secretárias já alocadas ao diretor
                        
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

        //novo
        private void CarregarSecretariasDisponiveis()
        {
            checkedListBoxSecretarias.Items.Clear();

            // Obter todas as secretárias disponíveis
            var todasSecretarias = empresa.Funcionarios
                .OfType<Secretaria>()
                .ToList();

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
            // AGORA: correspondência direta entre área do diretor e área da secretária
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




        //antigo
        //private void CarregarSecretariasDisponiveis()
        //{
        //    checkedListBoxSecretarias.Items.Clear();

        //    // Obter todas as secretárias disponíveis
        //    var todasSecretarias = empresa.Funcionarios
        //        .OfType<Secretaria>()
        //        .ToList();

        //    // Obter as áreas selecionadas do diretor
        //    List<string> areasSelecionadas = new List<string>();
        //    foreach (var item in checkedListBoxAreasDiretoria.CheckedItems)
        //    {
        //        areasSelecionadas.Add(item.ToString());
        //    }

        //    //Se não houver áreas selecionadas, não mostrar secretárias
        //    if (areasSelecionadas.Count == 0)
        //    {
        //        return;
        //    }

        //    //Filtrar secretárias pelas áreas selecionadas ATUALIZAR DEPOIS
        //    foreach (var secretaria in todasSecretarias)
        //    {
        //        bool pertenceAreaSelecionada = false;

        //        foreach (string area in areasSelecionadas)
        //        {
        //            if (area == "Direção-Geral")
        //            {
        //                // Direção-Geral pode ter acesso a todas as secretárias de Administração
        //                if (secretaria.Area == "Administração")
        //                {
        //                    pertenceAreaSelecionada = true;
        //                    break;
        //                }
        //            }
        //            else if (area == "Comercial")
        //            {
        //                // Comercial pode ter acesso a secretárias de Comercial e Administração
        //                if (secretaria.Area == "Comercial" || secretaria.Area == "Administração")
        //                {
        //                    pertenceAreaSelecionada = true;
        //                    break;
        //                }
        //            }
        //            else if (area == "Formação")
        //            {
        //                // Formação pode ter acesso a secretárias de Administração
        //                if (secretaria.Area == "Administração")
        //                {
        //                    pertenceAreaSelecionada = true;
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                // Para outras áreas (Recursos Humanos, Financeiro), correspondência direta
        //                if (secretaria.Area == area)
        //                {
        //                    pertenceAreaSelecionada = true;
        //                    break;
        //                }
        //            }
        //        }

        //        //Adicionar apenas secretárias que pertencem às áreas selecionadas
        //        if (pertenceAreaSelecionada)
        //        {
        //            checkedListBoxSecretarias.Items.Add(secretaria);
        //        }
        //    }
        //    AtualizarEstadoBotoes();            
        //}

        // Marcar secretárias já alocadas ao diretor VERIFICAR SE ISSO É UTIL
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

        // Validar se todos os campos estão preenchidos para habilitar o botão Calcular
        private void ValidarCamposParaCalcular(object sender, EventArgs e)
        {
            // Usar BeginInvoke para processar depois da mudança no CheckedListBox
            this.BeginInvoke(new Action(() =>
            {
                AtualizarEstadoBotoes();                
            }));
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

        private void LimparCampos()
        {
            txtID.Clear();
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
            try { dtpDataFimContrato.Value = DateTime.Now.AddYears(1); } catch { }
            try { dtpDataRegistoCriminal.Value = DateTime.Now.AddYears(5); } catch { }
            lblStatusRegistoCriminal.Text = "";

            // Limpar estados
            diretorSelecionado = null;
            diretorTemporario = null;
            remuneracaoCalculada = false;

            btnCalcularValor.Enabled = false;
            btnInserir.Enabled = false;
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
                      
            if (checkedListBoxAreasDiretoria.CheckedItems.Count == 0)
            {
                MessageBox.Show("Selecione pelo menos uma área de direção.", "Campo Obrigatório",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    MessageBox.Show($"A área '{area}' já está ocupada por outro diretor!",
                        "Área Ocupada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


        // ==================== EVENTOS DE BOTÕES ====================

        // Botão habilitado após calcular remuneração
        private void btnInserir_Click(object sender, EventArgs e)
        {            
            if (diretorTemporario == null)
            {
                MessageBox.Show("Por favor, calcule a remuneração primeiro.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Verificação adicional antes de adicionar
                if (diretorTemporario == null)
                {
                    throw new InvalidOperationException("O diretor temporário está null!");
                }

                empresa.AdicionarFuncionario(diretorTemporario);
                AtualizarListaDiretores();

                string nomeDiretor = diretorTemporario.Nome; // Guardar o nome antes de limpar
                LimparCampos();

                MessageBox.Show($"Diretor '{nomeDiretor}' inserido com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao inserir diretor: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Erro",
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

        // Criar um diretor temporário e abrir formulário de cálculo
        private void btnCalcularValor_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
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
                    0, // BonusMensal será calculado
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
                        // porque passamos a REFERÊNCIA do objeto
                        remuneracaoCalculada = true;                                               

                        AtualizarEstadoBotoes();

                        MessageBox.Show(
                            "Remuneração calculada com sucesso!\n\n" +
                            "Agora você pode clicar em 'Inserir Novo' para salvar o diretor.",
                            "Sucesso",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
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
                MessageBox.Show($"Erro ao calcular remuneração: {ex.Message}\n\n{ex.StackTrace}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                //Em caso de erro, limpa
                diretorTemporario = null;
                remuneracaoCalculada = false;
                AtualizarEstadoBotoes();
            }
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

    //internal class FormAtualizarRegistoCriminal : IDisposable
    //{
    //    public FormAtualizarRegistoCriminal(Diretor diretorSelecionado, Empresa empresa)
    //    {
    //        DiretorSelecionado = diretorSelecionado;
    //        Empresa = empresa;
    //    }

    //    public Diretor DiretorSelecionado { get; }
    //    public Empresa Empresa { get; }

    //    internal DialogResult ShowDialog()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public void Dispose()
    //    {
    //        // Implementação de Dispose se necessário
    //    }
    //}


    
    //    // resto igual (usar 'funcionarios' internamente)
    //}
}
