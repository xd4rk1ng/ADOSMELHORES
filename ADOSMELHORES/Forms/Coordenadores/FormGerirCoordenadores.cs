using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using ADOSMELHORES.Modelos;
using System.ComponentModel;
using ADOSMELHORES.Validacoes;

namespace ADOSMELHORES.Forms.Coordenadores
{
    public partial class FormGerirCoordenadores : Form
    {
        private Empresa empresa;
        private Coordenador coordenadorSelecionado;             

        public FormGerirCoordenadores(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;

            // Desactivar validação automática ao mudar de foco.
            // Assim cliques na listView não irão disparar o evento Validating dos TextBoxes.
            this.AutoValidate = AutoValidate.Disable;

            // Evita que clicar na listView provoque validação dos TextBoxes (ex.: txtNIF)
            this.listViewCoordenadores.CausesValidation = false;

            ValidarCampos.ConfigurarTextBoxNIF(this.txtNIF, obrigatorio: true);
            ValidarCampos.ConfigurarTextBoxContacto(this.txtContacto, obrigatorio: false);

            AtualizarListagem();
            LimparCampos();
        }

        // Métodos de Atualização e Preenchimento
        private void AtualizarListagem()
        {
            listViewCoordenadores.Items.Clear();

            foreach (var coordenador in empresa.Funcionarios.OfType<Coordenador>())
            {
                ListViewItem item = new ListViewItem(coordenador.Id.ToString());
                item.SubItems.Add(coordenador.Nome);
                item.SubItems.Add(coordenador.Morada);
                item.SubItems.Add(coordenador.Contacto);
                item.SubItems.Add(coordenador.AreaCoordenacao);
                item.SubItems.Add(coordenador.SalarioBase.ToString("C"));
                item.SubItems.Add(coordenador.DataFimContrato.ToShortDateString());
                item.SubItems.Add(coordenador.DataFimRegistoCrim.ToShortDateString());

                string statusRegisto = coordenador.RegistoCriminalExpirado(DateTime.Now) ? "Expirado" : "Válido";
                item.SubItems.Add(statusRegisto);

                item.Tag = coordenador;
                listViewCoordenadores.Items.Add(item);
            }

            lblTotal.Text = $"Total de Coordenadores: {empresa.Funcionarios.OfType<Coordenador>().Count()}";
        }

        private void LimparCampos()
        {
            txtId.Clear();
            txtNIF.Clear();
            txtNome.Clear();
            txtMorada.Clear();
            txtContacto.Clear();
            txtAreaCoordenacao.Clear();
            numSalarioBase.Value = 0;            
            DateTimeHelper.DefinirValorSeguro(dtpDataFimContrato, DateTime.Now.AddYears(1));
            DateTimeHelper.DefinirValorSeguro(dtpDataRegistoCriminal, DateTime.Now.AddYears(1));
            txtStatusRegistoCriminal.Text = "-";
            coordenadorSelecionado = null;
        }

       
        private void PreencherCampos(Coordenador coordenador)
        {
            txtId.Text = coordenador.Id.ToString();
            txtNIF.Text = coordenador.Nif.ToString();
            txtNome.Text = coordenador.Nome;
            txtMorada.Text = coordenador.Morada;
            txtContacto.Text = coordenador.Contacto;
            txtAreaCoordenacao.Text = coordenador.AreaCoordenacao;
            numSalarioBase.Value = coordenador.SalarioBase;

            DateTimeHelper.DefinirValorSeguro(dtpDataFimContrato, coordenador.DataFimContrato);
            DateTimeHelper.DefinirValorSeguro(dtpDataRegistoCriminal, coordenador.DataFimRegistoCrim);

            VerificarStatusRegistoCriminal(coordenador);
        }

        // Método de Seleção
        private void listViewCoordenadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCoordenadores.SelectedItems.Count > 0)
            {
                coordenadorSelecionado = (Coordenador)listViewCoordenadores.SelectedItems[0].Tag;
                PreencherCampos(coordenadorSelecionado);
            }
        }

       // Botões de Ação
       
        private void btnInserirNovo_Click(object sender, EventArgs e)
        {
            // Validar todos os campos obrigatórios de uma vez
            if (!ValidarCampos.ValidarEMostrar(
                ValidarCampos.ValidarCampoObrigatorio(txtNome.Text, "o nome do coordenador"),
                ValidarCampos.ValidarCampoObrigatorio(txtAreaCoordenacao.Text, "a área de coordenação"),
                ValidarCampos.ValidarNIF(txtNIF.Text, obrigatorio: true),
                ValidarCampos.ValidarContacto(txtContacto.Text, obrigatorio: false),
                ValidarCampos.ValidarValorMaiorQueZero(numSalarioBase, "Salário base")
            ))
            {
                return; 
            }

            if (!ValidarCampos.TentarObterNIF(txtNIF.Text, out int nif))
            {
                DialogHelper.MostrarAviso("NIF inválido.");
                txtNIF.Focus();
                return;
            }

            if (empresa != null && empresa.NifDuplicado(nif))
            {
                DialogHelper.MostrarAviso("Já existe um funcionário com este NIF.", "NIF Duplicado");
                txtNIF.Focus();
                return;
            }

            
            var validacaoData = DateTimeHelper.ValidarDataFutura(
                dtpDataFimContrato.Value,
                DateTime.Now,
                "Data de fim de contrato"
            );

            if (!validacaoData.Valido)
            {
                validacaoData.MostrarMensagem();
                return;
            }

            try
            {
                int novoId = empresa.ObterProximoID();

                Coordenador novoCoordenador = new Coordenador(
                    id: novoId,
                    nif: nif,
                    nome: txtNome.Text.Trim(),
                    morada: txtMorada.Text.Trim(),
                    contacto: txtContacto.Text.Trim(),
                    salarioBase: numSalarioBase.Value,
                    dataIniContrato: DateTime.Now,
                    dataFimContrato: dtpDataFimContrato.Value,
                    dataFimRegistoCrim: dtpDataRegistoCriminal.Value,
                    areaCoordenacao: txtAreaCoordenacao.Text.Trim()
                );

                empresa.AdicionarFuncionario(novoCoordenador);
                AtualizarListagem();

                // Selecionar o novo item
                var item = listViewCoordenadores.Items
                    .Cast<ListViewItem>()
                    .FirstOrDefault(i => ((Coordenador)i.Tag).Id == novoCoordenador.Id);

                if (item != null)
                {
                    listViewCoordenadores.SelectedItems.Clear();
                    item.Selected = true;
                    listViewCoordenadores.EnsureVisible(item.Index);

                    coordenadorSelecionado = novoCoordenador;
                    PreencherCampos(coordenadorSelecionado);
                    listViewCoordenadores.Focus();
                }

                DialogHelper.MostrarSucesso("Coordenador adicionado com sucesso!");
            }
            catch (Exception ex)
            {                
                DialogHelper.ErroOperacao("adicionar coordenador", ex);
            }
        }


        private void btnAlterarSelecionado_Click(object sender, EventArgs e)
        {
            
            if (coordenadorSelecionado == null)
            {
                DialogHelper.AvisoSelecionarItem("alterar", "coordenador");
                return;
            }
                        
            if (!ValidarCampos.ValidarEMostrar(
                ValidarCampos.ValidarCampoObrigatorio(txtNome.Text, "o nome do coordenador"),
                ValidarCampos.ValidarCampoObrigatorio(txtAreaCoordenacao.Text, "a área de coordenação"),
                ValidarCampos.ValidarNIF(txtNIF.Text, obrigatorio: true),
                ValidarCampos.ValidarContacto(txtContacto.Text, obrigatorio: false)
            ))
            {
                return;
            }

            if (!ValidarCampos.TentarObterNIF(txtNIF.Text, out int nif))
            {
                DialogHelper.MostrarAviso("NIF inválido.");
                txtNIF.Focus();
                return;
            }

            // Verificar duplicação (excluindo o próprio coordenador)
            if (empresa != null && empresa.NifDuplicado(nif, coordenadorSelecionado.Id))
            {
                DialogHelper.MostrarAviso(
                    "Outro coordenador já utiliza este NIF. Corrija o NIF.",
                    "NIF Duplicado");
                txtNIF.Focus();
                return;
            }

            try
            {
                coordenadorSelecionado.Nif = nif;
                coordenadorSelecionado.Nome = txtNome.Text.Trim();
                coordenadorSelecionado.Morada = txtMorada.Text.Trim();
                coordenadorSelecionado.Contacto = txtContacto.Text.Trim();
                coordenadorSelecionado.AreaCoordenacao = txtAreaCoordenacao.Text.Trim();
                coordenadorSelecionado.SalarioBase = numSalarioBase.Value;
                coordenadorSelecionado.DataFimContrato = dtpDataFimContrato.Value;
                coordenadorSelecionado.DataFimRegistoCrim = dtpDataRegistoCriminal.Value;

                AtualizarListagem();
                DialogHelper.MostrarSucesso("Coordenador atualizado com sucesso!");
            }
            catch (Exception ex)
            {
                DialogHelper.ErroOperacao("atualizar coordenador", ex);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (coordenadorSelecionado == null)
            {
                DialogHelper.AvisoSelecionarItem("remover", "coordenador");
                return;
            }
                        
            if (!DialogHelper.ConfirmarRemocao(coordenadorSelecionado.Nome, "o coordenador"))
            {
                return;
            }

            try
            {
                empresa.RemoverFuncionario(coordenadorSelecionado);
                AtualizarListagem();
                LimparCampos();
                DialogHelper.MostrarSucesso("Coordenador removido com sucesso!");
            }
            catch (Exception ex)
            {
                DialogHelper.ErroOperacao("remover coordenador", ex);
            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        //Gestao de Formadores
        private void btnAlocarFormador_Click(object sender, EventArgs e)
        {
            if (coordenadorSelecionado == null)
            {
                MessageBox.Show("Selecione um coordenador.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var formadores = empresa.Funcionarios.OfType<Formador>().ToList();
            if (formadores.Count == 0)
            {
                MessageBox.Show("Não existem formadores disponíveis para alocar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Form formAlocar = new Form())
            {
                formAlocar.Text = "Alocar Formador";
                formAlocar.Size = new System.Drawing.Size(400, 200);
                formAlocar.StartPosition = FormStartPosition.CenterParent;

                Label lblInfo = new Label()
                {
                    Text = "Selecione um formador para alocar:",
                    Location = new System.Drawing.Point(20, 20),
                    AutoSize = true
                };

                ComboBox cboFormadores = new ComboBox()
                {
                    Location = new System.Drawing.Point(20, 50),
                    Width = 340,
                    DropDownStyle = ComboBoxStyle.DropDownList
                };

                foreach (var formador in formadores)
                {
                    cboFormadores.Items.Add(formador);
                }
                cboFormadores.DisplayMember = "Nome";

                Button btnOk = new Button()
                {
                    Text = "Alocar",
                    DialogResult = DialogResult.OK,
                    Location = new System.Drawing.Point(150, 120)
                };

                formAlocar.Controls.Add(lblInfo);
                formAlocar.Controls.Add(cboFormadores);
                formAlocar.Controls.Add(btnOk);
                formAlocar.AcceptButton = btnOk;

                if (formAlocar.ShowDialog() == DialogResult.OK && cboFormadores.SelectedItem != null)
                {
                    Formador formadorSelecionado = (Formador)cboFormadores.SelectedItem;

                    // Verifica se o formador já está alocado noutro coordenador
                    var outroCoordenador = empresa.Funcionarios
                        .OfType<Coordenador>()
                        .FirstOrDefault(c => c.FormadoresAssociados.Any(f => f.Id == formadorSelecionado.Id));

                    if (outroCoordenador != null && outroCoordenador.Id != coordenadorSelecionado.Id)
                    {
                        MessageBox.Show($"O formador {formadorSelecionado.Nome} já está alocado ao coordenador {outroCoordenador.Nome}.",
                            "Alocação Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Se já estiver alocado ao mesmo coordenador, avisar
                    if (coordenadorSelecionado.FormadoresAssociados.Any(f => f.Id == formadorSelecionado.Id))
                    {
                        MessageBox.Show($"O formador {formadorSelecionado.Nome} já está alocado a este coordenador.", "Informação",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    coordenadorSelecionado.AdicionarFormador(formadorSelecionado);
                    AtualizarListagem();
                    PreencherCampos(coordenadorSelecionado);
                    MessageBox.Show($"Formador {formadorSelecionado.Nome} alocado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
                
        private void btnListaFormadoresAlocados_Click(object sender, EventArgs e)
        {
            if (coordenadorSelecionado == null)
            {
                MessageBox.Show("Selecione um coordenador.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var associados = coordenadorSelecionado.FormadoresAssociados;
            if (associados == null || associados.Count == 0)
            {
                MessageBox.Show("Não existem formadores alocados a este coordenador.", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (Form listaForm = new Form())
            {
                listaForm.Text = $"Formadores alocados a {coordenadorSelecionado.Nome}";
                listaForm.Size = new System.Drawing.Size(500, 350);
                listaForm.StartPosition = FormStartPosition.CenterParent;

                ListBox lb = new ListBox()
                {
                    Dock = DockStyle.Top,
                    Height = 260
                };
                lb.DisplayMember = "Nome";
                foreach (var f in associados)
                {
                    lb.Items.Add(f);
                }

                Button btnOk = new Button()
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Dock = DockStyle.Bottom,
                    Height = 30
                };

                listaForm.Controls.Add(lb);
                listaForm.Controls.Add(btnOk);
                listaForm.AcceptButton = btnOk;

                listaForm.ShowDialog();
            }
        }

        private void btnFiltrarPorDisponibilidade_Click(object sender, EventArgs e)
        {
            var coordenadoresValidos = empresa.Funcionarios
                .OfType<Coordenador>()
                .Where(c => c.ContratoValido(DateTime.Now) && !c.RegistoCriminalExpirado(DateTime.Now))
                .ToList();

            listViewCoordenadores.Items.Clear();

            foreach (var coordenador in coordenadoresValidos)
            {
                ListViewItem item = new ListViewItem(coordenador.Id.ToString());
                item.SubItems.Add(coordenador.Nome);
                item.SubItems.Add(coordenador.Morada);
                item.SubItems.Add(coordenador.Contacto);
                item.SubItems.Add(coordenador.AreaCoordenacao);
                item.SubItems.Add(coordenador.SalarioBase.ToString("C"));
                item.SubItems.Add(coordenador.DataFimContrato.ToShortDateString());
                item.SubItems.Add(coordenador.DataFimRegistoCrim.ToShortDateString());
                item.SubItems.Add("Válido");
                item.Tag = coordenador;
                listViewCoordenadores.Items.Add(item);
            }

            lblTotal.Text = $"Coordenadores Válidos: {coordenadoresValidos.Count} de {empresa.Funcionarios.OfType<Coordenador>().Count()}";
        }

        //Registo criminal
        private void btnAtualizarRegistoCriminal_Click(object sender, EventArgs e)
        {
            if (coordenadorSelecionado == null)
            {
                DialogHelper.AvisoSelecionarItem("atualizar", "coordenador");
                return;
            }

            DateTime? novaData = DialogHelper.DialogoAtualizarRegistoCriminal(this);

            if (novaData.HasValue)
            {
                coordenadorSelecionado.DataFimRegistoCrim = novaData.Value;
                AtualizarListagem();
                PreencherCampos(coordenadorSelecionado);
                DialogHelper.MostrarSucesso("Registo criminal atualizado!");
            }
        }

        private void VerificarStatusRegistoCriminal(Coordenador coordenador)
        {
            DialogHelper.AtualizarStatusRegistoCriminal(
                txtStatusRegistoCriminal,
                coordenador,
                empresa.DataSimulada > DateTime.MinValue ? empresa.DataSimulada : (DateTime?)null
            );
        }


        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
