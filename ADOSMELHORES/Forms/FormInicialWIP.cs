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
        private ControlVistaGeral _ctrlVistaGeral;
        private ControlGestao _ctrlGestao;
        private ControlSimularData _ctrlSimData;
        private ControlDespesas _ctrlDespesas;
        private Empresa _empresa;
        bool _logout;

        public FormInicialWIP(Empresa empresa)
        {
            InitializeComponent();
            _logout = false;
            controlPanel.BackColor = Color.FromArgb(246, 252, 249);
            pictureLogo.SizeMode = PictureBoxSizeMode.CenterImage;

            // Bloquear maximização / redimensionamento
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // impede redimensionamento pelas bordas
            this.MaximizeBox = false; // desativa botão de maximizar
            // opcional: fixa tamanho (impede redimensionamento por código ou sistema)
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            _empresa = empresa ?? throw new ArgumentNullException(nameof(empresa));

            // Inicialização de todos os user controls
            _ctrlBoasVindas = new ControlBoasVindas();
            _ctrlVistaGeral = new ControlVistaGeral(_empresa);
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
            MostrarControl(_ctrlVistaGeral);
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

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            _logout = true;
            this.Close();
        }

        private void FormInicialWIP_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing && _logout == false)
            {
                var result = MessageBox.Show("Tem certeza que deseja sair? Alterações não guardadas serão perdidas.", "Confirmação de Saída", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             
                if (result == DialogResult.Yes)
                    Application.Exit(); // Encerra a aplicação
                else
                    e.Cancel = true; // Cancela o fechamento do formulário
            }
        }
    }
}
