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
            // Helper local para limitar valores
            DateTime Clamp(DateTime value, DateTime min, DateTime max)
            {
                if (value < min) return min;
                if (value > max) return max;
                return value;
            }

            if (coordenador == null)
                return;

            txtNome.Text = coordenador.Nome;
            txtMorada.Text = coordenador.Morada;
            txtTelefone.Text = coordenador.Contacto; // Corrigido de Telefone para Contacto
            txtEmail.Text = ""; // Coordenador não possui propriedade Email, ajuste conforme necessário
            txtNIF.Text = coordenador.Nif.ToString(); // Corrigido de NIF para Nif (int para string)

                // DataNascimento: preferir utilitário do modelo se existir, senão fazer clamp manual
            try
            {
                DateTime safeNascimento;
                try
                {
                    // Usar GetSafeDataNascimento caso o método exista e esteja implementado
                    safeNascimento = coordenador.GetSafeDataNascimento(dateTimePickerNascimento.MinDate, dateTimePickerNascimento.MaxDate, DateTime.Now.AddYears(-30));
                }
                catch
                {
                    // Fallback: clamp manual
                    safeNascimento = Clamp(coordenador.DataNascimento, dateTimePickerNascimento.MinDate, dateTimePickerNascimento.MaxDate);
                }

                // Por segurança, envolver em try/catch ao atribuir Value
                try
                {
                    dateTimePickerNascimento.Value = safeNascimento;
                }
                catch (ArgumentOutOfRangeException)
                {
                    dateTimePickerNascimento.Value = dateTimePickerNascimento.MinDate;
                }
            }
            catch
            {
                // Em caso de qualquer erro não bloquear a UI; definir fallback
                try { dateTimePickerNascimento.Value = dateTimePickerNascimento.MinDate; } catch { /* ignora */ }
            }

            // DataIniContrato: clamp manual usando MinDate/MaxDate do control
            try
            {
                DateTime safeContrato = Clamp(coordenador.DataIniContrato, dateTimePickerContrato.MinDate, dateTimePickerContrato.MaxDate);
                try
                {
                    dateTimePickerContrato.Value = safeContrato;
                }
                catch (ArgumentOutOfRangeException)
                {
                    dateTimePickerContrato.Value = dateTimePickerContrato.MinDate;
                }
            }
            catch
            {
                try { dateTimePickerContrato.Value = dateTimePickerContrato.MinDate; } catch { /* ignora */ }
            }

            numericSalario.Value = coordenador.SalarioBase; // Corrigido de Salario para SalarioBase
            txtAreaFormacao.Text = ""; // Coordenador não possui propriedade AreaFormacao, ajuste conforme necessário
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

            // Removido txtEmail e txtAreaFormacao das validações, pois não existem nas propriedades

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

            try
            {
                coordenador.Nome = txtNome.Text;
                coordenador.Morada = txtMorada.Text;
                coordenador.Contacto = txtTelefone.Text;
                // coordenador.Email = ...; // Não existe propriedade Email
                if (int.TryParse(txtNIF.Text, out int nif))
                    coordenador.Nif = nif;

                // Ao gravar, podemos simplesmente usar os valores atuais dos DateTimePickers.
                // Eles já foram inicializados com valores válidos (clampados).
                coordenador.DataNascimento = dateTimePickerNascimento.Value;
                coordenador.DataIniContrato = dateTimePickerContrato.Value;
                coordenador.SalarioBase = numericSalario.Value;
                // coordenador.AreaFormacao = ...; // Não existe propriedade AreaFormacao

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
