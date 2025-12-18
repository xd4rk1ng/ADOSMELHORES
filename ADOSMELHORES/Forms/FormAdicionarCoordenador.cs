using System;
using System.Windows.Forms;
using ADOSMELHORES.Modelos;

namespace ADOSMELHORES.Forms
{
    public partial class FormAdicionarCoordenador : Form
    {
        private Empresa empresa;

        public FormAdicionarCoordenador(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validações
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Por favor, insira o nome.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMorada.Text))
            {
                MessageBox.Show("Por favor, insira a morada.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefone.Text))
            {
                MessageBox.Show("Por favor, insira o telefone.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Por favor, insira o email.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNIF.Text))
            {
                MessageBox.Show("Por favor, insira o NIF.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numericSalario.Value <= 0)
            {
                MessageBox.Show("O salário deve ser maior que zero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAreaFormacao.Text))
            {
                MessageBox.Show("Por favor, insira a área de formação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var proximoId = empresa.ObterProximoID;
                Coordenador coordenador = new Coordenador(
                    proximoId,
                    int.Parse(txtNIF.Text),
                    txtNome.Text,
                    txtMorada.Text,
                    txtTelefone.Text,
                    (decimal)numericSalario.Value,
                    dateTimePickerNascimento.Value,
                    dateTimePickerContrato.Value,
                    DateTime.MaxValue, // DataFimContrato (ajuste conforme necessário)
                    DateTime.MaxValue, // DataFimRegistoCrim (ajuste conforme necessário)
                    txtAreaFormacao.Text // areaCoordenacao
                );

                empresa.AdicionarFuncionario(coordenador);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao adicionar coordenador: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
