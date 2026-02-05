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

namespace ADOSMELHORES.Forms
{
    public partial class FormInicialWIP : Form
    {

        ControlVistaGeral _ctrlInicio;
        ControlGestao _ctrlGestao;
        public FormInicialWIP(Empresa empresa)
        {
            InitializeComponent();

            // Inicialização de todos os user controls
            _ctrlInicio = new ControlVistaGeral(empresa);
            _ctrlGestao = new ControlGestao(empresa);
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
    }
}
