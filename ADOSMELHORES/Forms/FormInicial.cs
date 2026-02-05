using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ADOSMELHORES.Modelos;
using ADOSMELHORES.Forms.Formadores;
using ADOSMELHORES.Forms.Diretores;
using ADOSMELHORES.Forms.Secretarias;
using ADOSMELHORES.Forms.Coordenadores;
using System.Text;

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

        // Novo: handler para exportar TODOS os funcionários para CSV a partir do menu inicial
        private void btnExportarFuncionarios_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FileName = "funcionarios_export.csv";
                sfd.Title = "Exportar Funcionários para CSV";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        _empresa.ExportarFuncionariosParaCSV(sfd.FileName);
                        MessageBox.Show("Exportação concluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao exportar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
