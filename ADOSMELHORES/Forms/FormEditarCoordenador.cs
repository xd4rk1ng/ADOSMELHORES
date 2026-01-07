using System;
using System.Windows.Forms;
using ADOSMELHORES.Modelos;

namespace ADOSMELHORES.Forms
{
    public partial class FormEditarCoordenador : Form
    {
        private Coordenador coordenador;

        public FormEditarCoordenador(Coordenador coordenador)
        {
            InitializeComponent();
            this.coordenador = coordenador;
            CarregarDados();
        }

        private void CarregarDados()
        {
            txtNome.Text = coordenador.Nome;
            txtMorada.Text = coordenador.Morada;
            txtTelefone.Text = coordenador.Contacto; // Corrigido de Telefone para Contacto
            txtEmail.Text = coordenador.Contacto;
            txtNIF.Text = coordenador.Nif.ToString(); // Corrigido de NIF para Nif e convertido para string
            dateTimePickerNascimento.Value = coordenador.DataNascimento;
            dateTimePickerContrato.Value = coordenador.DataIniContrato; // Corrigido de DataContrato para DataIniContrato
            numericSalario.Value = coordenador.SalarioBase; // Corrigido de Salario para SalarioBase
            txtAreaFormacao.Text = coordenador.AreaCoordenacao;
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
                coordenador.Nome = txtNome.Text;
                coordenador.Morada = txtMorada.Text;
                coordenador.Contacto = txtEmail.Text;
                coordenador.Nif = int.Parse(txtNIF.Text); // Corrigido de NIF para Nif e convertido para int
                coordenador.DataNascimento = dateTimePickerNascimento.Value;
                coordenador.DataIniContrato = dateTimePickerContrato.Value; // Corrigido de DataContrato para DataIniContrato
                coordenador.SalarioBase = numericSalario.Value; // Corrigido de Salario para SalarioBase
                coordenador.AreaCoordenacao = txtAreaFormacao.Text;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao editar coordenador: {ex.Message}", "Erro",
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
