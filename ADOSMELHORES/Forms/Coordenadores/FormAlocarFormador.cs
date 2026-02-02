using ADOSMELHORES.Modelos;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ADOSMELHORES.Forms
{
    public partial class FormAlocarFormador : Form
    {
        private Formador formador;
        private Empresa empresa;

        public FormAlocarFormador(Formador formadorSelecionado, Empresa empresaRef)
        {
            InitializeComponent();
            this.formador = formadorSelecionado;
            this.empresa = empresaRef;
            ConfigurarForm();
        }

        private void ConfigurarForm()
        {
            this.Text = $"Alocar Formador - {formador.Nome}";
            lblFormador.Text = $"Formador: {formador.Nome} - Área: {formador.AreaLeciona}";

            CarregarCoordenadores();
        }

        private void CarregarCoordenadores()
        {
            // Filtra os funcionários do tipo Coordenador
            var coordenadores = empresa.Funcionarios
                .OfType<Coordenador>()
                .ToList();
            cmbCoordenadores.DataSource = coordenadores;
            cmbCoordenadores.DisplayMember = "Nome";
            cmbCoordenadores.ValueMember = "Id";

            if (coordenadores.Count == 0)
            {
                btnAlocar.Enabled = false;
                lblAviso.Text = "Não há coordenadores disponíveis!";
                lblAviso.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void btnAlocar_Click(object sender, EventArgs e)
        {
            if (cmbCoordenadores.SelectedItem == null)
            {
                MessageBox.Show("Selecione um coordenador.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var coordenador = cmbCoordenadores.SelectedItem as Coordenador;

            if (coordenador.FormadoresAssociados.Contains(formador))
            {
                MessageBox.Show($"Este formador já está alocado a {coordenador.Nome}!", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            coordenador.AdicionarFormador(formador);

            MessageBox.Show($"Formador '{formador.Nome}' alocado a '{coordenador.Nome}' com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
