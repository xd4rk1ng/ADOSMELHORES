using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using ADOSMELHORES.Modelos;

namespace ADOSMELHORES.Forms
{
    public partial class FormGerirCoordenadores : Form
    {
        private Empresa empresa;
        private Coordenador coordenadorSelecionado;

        public FormGerirCoordenadores(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
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
            txtNome.Text = coordenador.Nome;
            txtMorada.Text = coordenador.Morada;
            txtContacto.Text = coordenador.Contacto;
            txtAreaCoordenacao.Text = coordenador.AreaCoordenacao;
            numSalarioBase.Value = coordenador.SalarioBase;
            dtpDataFimContrato.Value = coordenador.DataFimContrato;
            dtpDataRegistoCriminal.Value = coordenador.DataFimRegistoCrim;

            txtStatusRegistoCriminal.Text = coordenador.RegistoCriminalExpirado(DateTime.Now) ? "Expirado" : "Válido";
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

            int novoId = empresa.ObterProximoID();

            Coordenador novoCoordenador = new Coordenador(
                id: novoId,
                nif: 0,
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
            LimparCampos();

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
                // Tentativa segura de invocar o método RemoverFuncionario que aceite um Funcionario.
                // Em alguns cenários a sobrecarga visível por compilador pode ser apenas para Formador,
                // causando erro de compilação ao passar um Coordenador. Usamos reflexão com fallback.
                MethodInfo removerFuncionarioMetodo = empresa.GetType().GetMethod("RemoverFuncionario", new Type[] { typeof(Funcionario) });

                if (removerFuncionarioMetodo != null)
                {
                    removerFuncionarioMetodo.Invoke(empresa, new object[] { coordenadorSelecionado });
                }
                else
                {
                    // Fallback: tentar remover diretamente da lista interna 'funcionarios' se existir (reflectivamente)
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

        private void btnCalcularValorFormacao_Click(object sender, EventArgs e)
        {
            if (coordenadorSelecionado == null)
            {
                MessageBox.Show("Selecione um coordenador.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal custoMensal = coordenadorSelecionado.CalcularCustoMensal();

            MessageBox.Show(
                $"Custo mensal do Coordenador {coordenadorSelecionado.Nome}:\n\n" +
                $"Salário Base: {coordenadorSelecionado.SalarioBase:C}\n" +
                $"Formadores Associados: {coordenadorSelecionado.NumeroFormadores}\n" +
                $"Área: {coordenadorSelecionado.AreaCoordenacao}",
                "Informação do Coordenador",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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

            // Criar form simples inline para alocar formadores
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
                    coordenadorSelecionado.AdicionarFormador(formadorSelecionado);
                    AtualizarListagem();
                    PreencherCampos(coordenadorSelecionado);
                    MessageBox.Show($"Formador {formadorSelecionado.Nome} alocado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnAtualizarRegistoCriminal_Click(object sender, EventArgs e)
        {
            if (coordenadorSelecionado == null)
            {
                MessageBox.Show("Selecione um coordenador.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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

                if (formData.ShowDialog() == DialogResult.OK)
                {
                    coordenadorSelecionado.DataFimRegistoCrim = dtp.Value;
                    AtualizarListagem();
                    PreencherCampos(coordenadorSelecionado);
                    MessageBox.Show("Registo criminal atualizado com sucesso!", "Sucesso",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
