using System;
using System.Windows.Forms;
using ADOSMELHORES.Modelos;

namespace ADOSMELHORES.Forms
{
    public partial class FormAtualizarRegistoCriminalCoordenador : Form
    {
        private Coordenador coordenador;

        public FormAtualizarRegistoCriminalCoordenador(Coordenador coordenador)
        {
            InitializeComponent();
            this.coordenador = coordenador;
            CarregarDados();
        }

        private void CarregarDados()
        {
            lblNome.Text = $"Coordenador: {coordenador.Nome}";
            dateTimePickerValidade.Value = coordenador.ValidadeRegistoCriminal;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (dateTimePickerValidade.Value <= DateTime.Now)
            {
                MessageBox.Show("A data de validade deve ser futura.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            coordenador.ValidadeRegistoCriminal = dateTimePickerValidade.Value;
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
