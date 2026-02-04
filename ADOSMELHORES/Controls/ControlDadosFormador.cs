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

namespace ADOSMELHORES.Controls
{
    public partial class ControlDadosFormador : UserControl
    {
        private Formador _selecionado = null;
        public bool CamposPreenchidos { get; private set; } = false;
        public Formador FuncionarioSelecionado
        {
            get => _selecionado;
            set
            {
                _selecionado = value;

                AtualizarCampos();
            }
        }

        public ControlDadosFormador()
        {
            InitializeComponent();

            // Eventos para validação em tempo real
            txtAreaLeciona.TextChanged += ValidarCamposPreenchidos;
            cmbDisponibilidade.SelectedValueChanged += ValidarCamposPreenchidos;
        }

        private void ValidarCamposPreenchidos(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                // TODO: para ja so valida se tem algo dentro, nao valida 100%
                CamposPreenchidos = !string.IsNullOrWhiteSpace(txtAreaLeciona.Text) &&
                            !string.IsNullOrWhiteSpace(cmbDisponibilidade.Text);
            }));
        }

        private void AtualizarCampos()
        {
            if (_selecionado is null)
            {
                txtAreaLeciona.Text = _selecionado.AreaLeciona;
                cmbDisponibilidade.SelectedItem = _selecionado.AreaLeciona;

            }

            txtAreaLeciona.Text = _selecionado.AreaLeciona;
            cmbDisponibilidade.SelectedItem = _selecionado.AreaLeciona;
        }
    }
}
