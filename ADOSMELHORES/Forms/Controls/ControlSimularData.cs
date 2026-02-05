using ADOSMELHORES.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES.Forms.Controls
{
    public partial class ControlSimularData : UserControl
    {
        private readonly Empresa _empresa;
        private DateTime _dataSimulada;
        public ControlSimularData(Empresa empresa)
        {
            _empresa = empresa;
            _dataSimulada = DateTime.Now;

            InitializeComponent();

            dtpDataDefinida.Value = _dataSimulada;

            lstFuncionarios.View = View.Details;
            lstFuncionarios.FullRowSelect = true;
            lstFuncionarios.GridLines = true;

            lstFuncionarios.Columns.Add("ID", 60);
            lstFuncionarios.Columns.Add("Nome", 150);
            lstFuncionarios.Columns.Add("Função", 120);

            AtualizarDados();

        }
        public void AtualizarDados()
        {
            List<Funcionario> totalContratosExpirados;
            List<Funcionario> totalRegistosExpirados;

            VerificarAlertasData(out totalContratosExpirados, out totalRegistosExpirados);

            lstFuncionarios.Items.Clear();

            // insere na listview todos os funcionários com contrato inválido na data simulada ou registo criminal expirado
            foreach (var funcionario in totalContratosExpirados.Concat(totalRegistosExpirados).ToList())
            {
                var item = new ListViewItem(funcionario.Id.ToString());
                item.SubItems.Add(funcionario.Nome);
                item.SubItems.Add(funcionario.GetType().Name);
                lstFuncionarios.Items.Add(item);
            }


            lblExpirados1.Text = $"Contrato inválido: {totalContratosExpirados.Count}";
            lblExpirados2.Text = $"Registo criminal expirado: {totalRegistosExpirados.Count}";
            lblNumTotal.Text = $"{totalContratosExpirados.Count + totalRegistosExpirados.Count}";
        }
        private void VerificarAlertasData(out List<Funcionario> contratosQueTerminam, out List<Funcionario> registosAtingidos)
        {
            var funcionarios = _empresa.Funcionarios.ToList();

            contratosQueTerminam = funcionarios
                .Where(f => !f.ContratoValido(_dataSimulada))
                .ToList();

            registosAtingidos = funcionarios
                .Where(f => f.RegistoCriminalExpirado(_dataSimulada))
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
                MessageBox.Show($"Data simulada avançada para {_dataSimulada:dd/MM/yyyy}. Nenhum contrato ou registo atinge término nesta data.", "Sem alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _dataSimulada = DateTime.Now;
            dtpDataDefinida.Value = _dataSimulada;

            AtualizarDados();
        }

        private void btnDefinir_click(object sender, EventArgs e)
        {
            _dataSimulada = dtpDataDefinida.Value;

            AtualizarDados();
        }
    }
}
