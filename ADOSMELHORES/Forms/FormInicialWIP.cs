using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ADOSMELHORES.Controls;
using ADOSMELHORES.Modelos;
using System.Text; // necessário para StringBuilder

namespace ADOSMELHORES.Forms
{
    public partial class FormInicialWIP : Form
    {

        ControlVistaGeral _ctrlInicio;
        ControlGestao _ctrlGestao;
        private Empresa _empresa;

        public FormInicialWIP(Empresa empresa)
        {
            InitializeComponent();

            _empresa = empresa ?? throw new ArgumentNullException(nameof(empresa));

            // Inicialização de todos os user controls
            _ctrlInicio = new ControlVistaGeral(_empresa);
            _ctrlGestao = new ControlGestao(_empresa);
        }

        private void MostrarControl(UserControl userControl)
        {
            if (!panel1.Controls.Contains(userControl))
                panel1.Controls.Add(userControl);

            // Facilitar centralização
            userControl.Dock = DockStyle.None;
            userControl.Anchor = AnchorStyles.None;

            // Centrar controlo
            userControl.Location = new Point(
                (panel1.Width - userControl.Width) / 2,
                (panel1.Height - userControl.Height) / 2
                );

            userControl.BackColor = Color.FromArgb(246, 252, 249);

            userControl.BringToFront();

        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            MostrarControl(_ctrlInicio);
        }

        private void btnGerir_Click(object sender, EventArgs e)
        {
            MostrarControl(_ctrlGestao);
        }

        // Botão "Simular Data" (button3) — avança 1 dia na data simulada e verifica alertas
        private void button3_Click(object sender, EventArgs e)
        {
            if (_empresa == null) return;

            // garantir data inicial
            if (_empresa.DataSimulada == DateTime.MinValue)
                _empresa.DataSimulada = DateTime.Now.Date;

            _empresa.DataSimulada = _empresa.DataSimulada.AddDays(1);

            // Atualizar vista interna se necessário
            _ctrlInicio?.AtualizarDados();

            VerificarAlertasData(_empresa.DataSimulada);
        }

        // Reaproveita lógica semelhante ao FormInicial.VerificarAlertasData
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
                MessageBox.Show($"Data simulada avançada para {dataSimulada:dd/MM/yyyy}. Nenhum contrato ou registo atinge término nesta data.", "Sem alertas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
