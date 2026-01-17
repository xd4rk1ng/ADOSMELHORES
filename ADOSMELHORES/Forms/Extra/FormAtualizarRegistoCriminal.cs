using ADOSMELHORES.Modelos;
using System;
using System.Windows.Forms;

namespace ADOSMELHORES.Forms
{
    public partial class FormAtualizarRegistoCriminal : Form
    {
        private Formador formador;
        private Empresa empresa;

        public FormAtualizarRegistoCriminal(Formador formadorSelecionado, Empresa empresaRef)
        {
            InitializeComponent();
            this.formador = formadorSelecionado;
            this.empresa = empresaRef;
            ConfigurarForm();
        }

        private void ConfigurarForm()
        {
            this.Text = $"Atualizar Registo Criminal - {formador.Nome}";
            lblFormador.Text = $"Formador: {formador.Nome}";
            lblDataAtual.Text = $"Data Atual do Registo: {formador.DataFimRegistoCrim:dd/MM/yyyy}";
            dtpNovaData.Value = formador.DataFimRegistoCrim.AddYears(5);

            VerificarStatus();
        }

        private void VerificarStatus()
        {
            if (formador.RegistoCriminalExpirado(empresa.DataSimulada))
            {
                lblStatus.Text = "Status: EXPIRADO";
                lblStatus.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                lblStatus.Text = "Status: Válido";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (dtpNovaData.Value <= DateTime.Now)
            {
                MessageBox.Show("A nova data deve ser futura.", "Data Inválida",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            formador.DataFimRegistoCrim = dtpNovaData.Value;

            MessageBox.Show($"Registo criminal atualizado para {dtpNovaData.Value:dd/MM/yyyy}!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
