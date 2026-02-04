using ADOSMELHORES.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES.Controls
{
    public partial class ControlFuncionario : UserControl
    {
        private Funcionario _selecionado = null;
        public bool CamposPreenchidos { get; private set; } = false;
        public Funcionario FuncionarioSelecionado
        {
            get => _selecionado;
            set
            {
                _selecionado = value;

                grpDadosPessoais.Text = $"Dados {(_selecionado is null ? "Funcionário" : _selecionado.GetType().Name)}";
                AtualizarCampos();
            }
        }

        public ControlFuncionario()
        {
            InitializeComponent();

            // Eventos para validação em tempo real
            txtNome.TextChanged += ValidarCamposPreenchidos;
            txtNIF.TextChanged += ValidarCamposPreenchidos;
            txtMorada.TextChanged += ValidarCamposPreenchidos;
            txtContacto.TextChanged += ValidarCamposPreenchidos;
            numSalarioBase.ValueChanged += ValidarCamposPreenchidos;
            dtpDataFimContrato.ValueChanged += ValidarCamposPreenchidos;
        }
        private void ValidarCamposPreenchidos(object sender, EventArgs e)
        {
            BeginInvoke(new Action(() =>
            {
                // TODO: para ja so valida se tem algo dentro, nao valida 100%
                CamposPreenchidos =  !string.IsNullOrWhiteSpace(txtNome.Text) &&
                            !string.IsNullOrWhiteSpace(txtNIF.Text) &&
                            !string.IsNullOrWhiteSpace(txtMorada.Text) &&
                            !string.IsNullOrWhiteSpace(txtContacto.Text) &&
                            numSalarioBase.Value > 0 &&
                            dtpDataFimContrato.Value > DateTime.Now;
            }));
        }

        private void AtualizarCampos()
        {
            if(_selecionado is null)
            {
                txtNome.Text = default;
                txtNIF.Text = default;
                txtMorada.Text = default;
                txtContacto.Text = default;
                numSalarioBase.Value = default;
                dtpDataFimContrato.Value = default;
            }

            txtNome.Text = _selecionado.Nome;
            txtNIF.Text = _selecionado.Nif.ToString();
            txtMorada.Text = _selecionado.Morada;
            txtContacto.Text = _selecionado.Contacto;
            numSalarioBase.Value = _selecionado.SalarioBase;
            dtpDataFimContrato.Value = _selecionado.DataFimContrato;
        }
    }
}
