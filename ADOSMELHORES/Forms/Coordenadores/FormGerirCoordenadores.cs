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

        // constantes para validação do NIF
        private const int NIF_MIN = 100000000;
        private const int NIF_MAX = 999999999;

        public FormGerirCoordenadores(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;

            // Subscrever eventos do campo NIF (uso correto do txtNIF)
            this.txtNIF.KeyPress += TxtNIF_KeyPress;
            this.txtNIF.Validating += TxtNIF_Validating;

            AtualizarListagem();
            LimparCampos();
        }

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
            dtpDataFimContrato.Value = DateTime.Now.AddYears(1);
            dtpDataRegistoCriminal.Value = DateTime.Now.AddYears(1);
            txtStatusRegistoCriminal.Text = "-";
            coordenadorSelecionado = null;
        }

        private void listViewCoordenadores_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewCoordenadores.SelectedItems.Count > 0)
            {
                coordenadorSelecionado = (Coordenador)listViewCoordenadores.SelectedItems[0].Tag;
                PreencherCampos(coordenadorSelecionado);
            }
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
            dtpDataFimContrato.Value = coordenador.DataFimContrato;
            dtpDataRegistoCriminal.Value = coordenador.DataFimRegistoCrim;

            VerificarStatusRegistoCriminal(coordenador);

            //txtStatusRegistoCriminal.Text = coordenador.RegistoCriminalExpirado(DateTime.Now) ? "Expirado" : "Válido";
        }

        private void TxtNIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permitir apenas dígitos e teclas de controlo
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
                // Se optar por tornar NIF obrigatório, cancele e mostre mensagem.
                // Por agora permitimos vazio, mas se preenchido valida-se abaixo.
                return;
            }

            if (!text.All(char.IsDigit))
            {
                e.Cancel = true;
                MessageBox.Show("NIF deve conter apenas dígitos.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (text.Length != 9)
            {
                e.Cancel = true;
                MessageBox.Show("NIF deve ter 9 dígitos.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int nif;
            if (!int.TryParse(text, out nif) || nif < NIF_MIN || nif > NIF_MAX)
            {
                e.Cancel = true;
                MessageBox.Show($"NIF deve estar entre {NIF_MIN} e {NIF_MAX}.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Helper para verificar duplicação de NIF entre coordenadores
        private bool NifDuplicado(int nif, int? excludeId = null)
        {
            if (nif < NIF_MIN || nif > NIF_MAX) return false;
            return empresa.Funcionarios
                .OfType<Coordenador>()
                .Any(c => c.Nif == nif && (!excludeId.HasValue || c.Id != excludeId.Value));
        }

        private void btnInserirNovo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Por favor, insira o nome do coordenador.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAreaCoordenacao.Text))
            {
                MessageBox.Show("Por favor, insira a área de coordenação.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validar NIF (obrigatório para este fluxo)
            if (string.IsNullOrWhiteSpace(txtNIF.Text) || !txtNIF.Text.All(char.IsDigit) || txtNIF.Text.Length != 9)
            {
                MessageBox.Show("Por favor, insira um NIF válido de 9 dígitos.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIF.Focus();
                return;
            }

            int nif = int.Parse(txtNIF.Text);

            if (nif < NIF_MIN || nif > NIF_MAX)
            {
                MessageBox.Show($"NIF deve estar entre {NIF_MIN} e {NIF_MAX}.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIF.Focus();
                return;
            }

            if (NifDuplicado(nif))
            {
                MessageBox.Show("Já existe um coordenador com este NIF.", "NIF Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIF.Focus();
                return;
            }

            int novoId = empresa.ObterProximoID();

            Coordenador novoCoordenador = new Coordenador(
                id: novoId,
                nif: nif,
                nome: txtNome.Text,
                morada: txtMorada.Text,
                contacto: txtContacto.Text,
                salarioBase: numSalarioBase.Value,
                dataIniContrato: DateTime.Now,
                dataFimContrato: dtpDataFimContrato.Value,
                dataFimRegistoCrim: dtpDataRegistoCriminal.Value,
                dataNascimento: DateTime.Now.AddYears(-30),
                areaCoordenacao: txtAreaCoordenacao.Text
            );

            empresa.AdicionarFuncionario(novoCoordenador);
            AtualizarListagem();

            // selecionar o novo item na listView e preencher os campos para permitir uso imediato dos botões laterais
            var item = listViewCoordenadores.Items
                .Cast<ListViewItem>()
                .FirstOrDefault(i => ((Coordenador)i.Tag).Id == novoCoordenador.Id);

            if (item != null)
            {
                // garante seleção única e foco
                listViewCoordenadores.SelectedItems.Clear();
                item.Selected = true;
                listViewCoordenadores.EnsureVisible(item.Index);

                // atualizar estado interno e UI com os dados do novo coordenador
                coordenadorSelecionado = novoCoordenador;
                PreencherCampos(coordenadorSelecionado);
                listViewCoordenadores.Focus();
            }

            MessageBox.Show("Coordenador adicionado com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAlterarSelecionado_Click(object sender, EventArgs e)
        {
            if (coordenadorSelecionado == null)
            {
                MessageBox.Show("Selecione um coordenador para alterar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // validar NIF (obrigatório para alteração também)
            if (string.IsNullOrWhiteSpace(txtNIF.Text) || !txtNIF.Text.All(char.IsDigit) || txtNIF.Text.Length != 9)
            {
                MessageBox.Show("Por favor, insira um NIF válido de 9 dígitos.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIF.Focus();
                return;
            }

            int nif = int.Parse(txtNIF.Text);

            if (nif < NIF_MIN || nif > NIF_MAX)
            {
                MessageBox.Show($"NIF deve estar entre {NIF_MIN} e {NIF_MAX}.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIF.Focus();
                return;
            }

            if (NifDuplicado(nif, coordenadorSelecionado.Id))
            {
                MessageBox.Show("Outro coordenador já utiliza este NIF. Corrija o NIF.", "NIF Duplicado",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNIF.Focus();
                return;
            }

            coordenadorSelecionado.Nif = nif;
            coordenadorSelecionado.Nome = txtNome.Text;
            coordenadorSelecionado.Morada = txtMorada.Text;
            coordenadorSelecionado.Contacto = txtContacto.Text;
            coordenadorSelecionado.AreaCoordenacao = txtAreaCoordenacao.Text;
            coordenadorSelecionado.SalarioBase = numSalarioBase.Value;
            coordenadorSelecionado.DataFimContrato = dtpDataFimContrato.Value;
            coordenadorSelecionado.DataFimRegistoCrim = dtpDataRegistoCriminal.Value;

            AtualizarListagem();
            MessageBox.Show("Coordenador atualizado com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (coordenadorSelecionado == null)
            {
                MessageBox.Show("Selecione um coordenador para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Tem certeza que deseja remover o coordenador {coordenadorSelecionado.Nome}?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MethodInfo removerFuncionarioMetodo = empresa.GetType().GetMethod("RemoverFuncionario", new Type[] { typeof(Funcionario) });

                if (removerFuncionarioMetodo != null)
                {
                    removerFuncionarioMetodo.Invoke(empresa, new object[] { coordenadorSelecionado });
                }
                else
                {
                    FieldInfo fieldFuncionarios = empresa.GetType().GetField("funcionarios", BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
                    if (fieldFuncionarios != null)
                    {
                        var lista = fieldFuncionarios.GetValue(empresa) as List<Funcionario>;
                        if (lista != null)
                        {
                            lista.Remove(coordenadorSelecionado);
                        }
                        else
                        {
                            MessageBox.Show("Não foi possível remover o coordenador: lista interna não encontrada.", "Erro",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não foi possível remover o coordenador: método de remoção não encontrado.", "Erro",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                AtualizarListagem();
                LimparCampos();
                MessageBox.Show("Coordenador removido com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLimparCampos_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

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

        // Novo botão: lista de formadores alocados ao coordenador selecionado
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

        private void btnAtualizarRegistoCriminal_Click(object sender, EventArgs e)
        {
            if (coordenadorSelecionado == null)
            {
                DialogHelper.AvisoSelecionarItem("atualizar o registo criminal", "coordenador");
                return;
            }

            var novaData = DialogHelper.DialogoAtualizarRegistoCriminal(this);

            if (novaData.HasValue)
            {
                try
                {
                    coordenadorSelecionado.DataFimRegistoCrim = novaData.Value;
                    AtualizarListagem();
                    PreencherCampos(coordenadorSelecionado);

                    DialogHelper.MostrarSucesso("Registo criminal atualizado com sucesso!");
                }
                catch (Exception ex)
                {
                    DialogHelper.ErroOperacao("atualizar registo criminal", ex);
                }
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

        private void VerificarStatusRegistoCriminal(Coordenador coordenador)
        {
            if (coordenador == null) return;
                        
            DialogHelper.AtualizarTextBoxStatusRegistoCriminal(
                txtStatusRegistoCriminal,
                coordenador,  
                empresa
            );
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBoxDados_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
