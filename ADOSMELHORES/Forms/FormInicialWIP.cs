using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ADOSMELHORES.Forms.Controls;
using ADOSMELHORES.Modelos;

namespace ADOSMELHORES.Forms
{
    public partial class FormInicialWIP : Form
    {
        private ControlBoasVindas _ctrlBoasVindas;
        private ControlVistaGeral _ctrlInicio;
        private ControlGestao _ctrlGestao;
        private ControlSimularData _ctrlSimData;
        private ControlDespesas _ctrlDespesas;
        private Empresa _empresa;

        public FormInicialWIP(Empresa empresa)
        {
            InitializeComponent();

            _empresa = empresa ?? throw new ArgumentNullException(nameof(empresa));

            // Inicialização de todos os user controls
            _ctrlBoasVindas = new ControlBoasVindas();
            _ctrlInicio = new ControlVistaGeral(_empresa);
            _ctrlGestao = new ControlGestao(_empresa);
            _ctrlSimData = new ControlSimularData(_empresa);
            _ctrlDespesas = new ControlDespesas(_empresa);

            MostrarControl(_ctrlBoasVindas);
        }

        private void MostrarControl(UserControl userControl)
        {
            // Limpar o painel e adicionar o novo controlo
            panel1.Controls.Clear();
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

        private void btnVistaGeral_Click(object sender, EventArgs e)
        {
            MostrarControl(_ctrlInicio);
        }

        private void btnGerir_Click(object sender, EventArgs e)
        {
            MostrarControl(_ctrlGestao);
        }

        // Botão "Simular Data" (button3) — avança 1 dia na data simulada e verifica alertas
        private void btnSimData_Click(object sender, EventArgs e)
        {
            MostrarControl(_ctrlSimData);

        }

        // Reaproveita lógica semelhante ao FormInicial.VerificarAlertasData


        private void btnStats_Click(object sender, EventArgs e)
        {
            MostrarControl(_ctrlDespesas);
        }
    }
}
