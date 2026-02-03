using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ADOSMELHORES.Modelos;
using ADOSMELHORES.Forms.Formadores;
using ADOSMELHORES.Forms.Diretores;
using ADOSMELHORES.Forms.Secretarias;
using ADOSMELHORES.Forms.Coordenadores;

namespace ADOSMELHORES.Forms
{
    public partial class FormInicial : Form
    {
        private Empresa _empresa;

        public FormInicial(Empresa empresa)
        {
            InitializeComponent();
            _empresa = empresa ?? throw new ArgumentNullException(nameof(empresa));

            // Inicializar data simulada na primeira execução
            if (_empresa.DataSimulada == DateTime.MinValue)
            {
                _empresa.DataSimulada = DateTime.Now.Date;
            }

            AtualizarLabelDataSimulada();
        }

        private void AtualizarLabelDataSimulada()
        {
            lblDataSimulada.Text = $"Data simulada: {_empresa.DataSimulada:dd/MM/yyyy}";
            // opcional: atualizar título da janela
            this.Text = $"Form Inicial - Data simulada: {_empresa.DataSimulada:dd/MM/yyyy}";
        }

        private void btnExemplo_Click_1(object sender, EventArgs e)
        {
            FormExemplo f = new FormExemplo(this);   // create the new form
            f.Show();                // show it
        }

        private void btnFormador_Click(object sender, EventArgs e)
        {
            var f = new FormGerirFormadores(_empresa);
            f.Show();
        }

        private void btnCoordenador_Click(object sender, EventArgs e)
        {
            var f = new FormGerirCoordenadores(_empresa);
            f.Show();
        }

        private void btnDiretor_Click(object sender, EventArgs e)
        {
            try
            {
                var formDiretores = new FormGerirDiretores(_empresa);
                formDiretores.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulário de Diretores: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormInicialClose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnSecretaria_Click(object sender, EventArgs e)
        {
            using (var form = new FormGerirSecretarias(_empresa))
            {
                form.ShowDialog();
            }
        }

        // Avança 1 dia na DataSimulada e verifica alertas
        private void btnAvancarDia_Click(object sender, EventArgs e)
        {
            _empresa.DataSimulada = _empresa.DataSimulada.AddDays(1);
            AtualizarLabelDataSimulada();
            VerificarAlertasData(_empresa.DataSimulada);
        }

        // Verifica contratos e registos criminais atingidos na data simulada
        private void VerificarAlertasData(DateTime dataSimulada)
        {
            var funcionarios = _empresa.Funcionarios.ToList();

            var contratosQueTerminam = funcionarios
                .Where(f => f.DataFimContrato.Date == dataSimulada.Date)
                .ToList();

            var registosAtingidos = funcionarios
                .Where(f => f.DataFimRegistoCrim.Date == dataSimulada.Date)
                .ToList();

            StringBuilder sb = new StringBuilder();

            if (contratosQueTerminam.Any())
            {
                sb.AppendLine("Contratos com fim na data simulada:");
                foreach (var f in contratosQueTerminam)
                {
                    sb.AppendLine($" - {f.Nome} (ID: {f.Id}) termina contrato em {f.DataFimContrato:dd/MM/yyyy}");
                }
                sb.AppendLine();
            }

            if (registosAtingidos.Any())
            {
                sb.AppendLine("Registos criminais atingem validade na data simulada:");
                foreach (var f in registosAtingidos)
                {
                    sb.AppendLine($" - {f.Nome} (ID: {f.Id}) registo termina em {f.DataFimRegistoCrim:dd/MM/yyyy}");
                }
                sb.AppendLine();
            }

            if (sb.Length > 0)
            {
                MessageBox.Show(sb.ToString(), "Alerta - Data Simulada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Nenhum contrato ou registo criminal atinge término nesta data simulada.", "Sem alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
