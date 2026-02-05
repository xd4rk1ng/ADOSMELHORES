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

            lstInvalidos.View = View.Details;
            lstInvalidos.FullRowSelect = true;
            lstInvalidos.GridLines = true;

            lstInvalidos.Columns.Add("ID", 60);
            lstInvalidos.Columns.Add("Nome", 150);
            lstInvalidos.Columns.Add("Função", 120);


            lstExpirados.View = View.Details;
            lstExpirados.FullRowSelect = true;
            lstExpirados.GridLines = true;

            lstExpirados.Columns.Add("ID", 60);
            lstExpirados.Columns.Add("Nome", 150);
            lstExpirados.Columns.Add("Função", 120);

            AtualizarDados();

        }
        public void AtualizarDados()
        {
            List<Funcionario> contratosInvalidos;
            List<Funcionario> registosExpirados;

            VerificarAlertasData(out contratosInvalidos, out registosExpirados);

            lstInvalidos.Items.Clear();
            lstExpirados.Items.Clear();

            foreach (var funcionario in contratosInvalidos)
            {
                var item = new ListViewItem(funcionario.Id.ToString());
                item.SubItems.Add(funcionario.Nome);
                item.SubItems.Add(funcionario.GetType().Name);
                lstInvalidos.Items.Add(item);
            }

            foreach (var funcionario in registosExpirados)
            {
                var item = new ListViewItem(funcionario.Id.ToString());
                item.SubItems.Add(funcionario.Nome);
                item.SubItems.Add(funcionario.GetType().Name);
                lstExpirados.Items.Add(item);
            }

            var totalInvalidos = contratosInvalidos.Count;
            var totalExpirados = registosExpirados.Count;

            lblNumTotalInvalidos.Text = totalInvalidos.ToString();
            lblNumTotalExpirados.Text = totalExpirados.ToString();
            lblNumTotal.Text = (totalInvalidos + totalExpirados).ToString();
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
