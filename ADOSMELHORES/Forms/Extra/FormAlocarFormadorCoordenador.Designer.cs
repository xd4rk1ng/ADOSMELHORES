using System;
using System.Linq;
using System.Windows.Forms;
using ADOSMELHORES.Modelos;

namespace ADOSMELHORES.Forms
{
    public partial class FormAlocarFormadorCoordenador : Form
    {
        private Empresa empresa;
        private Coordenador coordenador;

        public FormAlocarFormadorCoordenador(Empresa empresa, Coordenador coordenador)
        {
            InitializeComponent();
            this.empresa = empresa;
            this.coordenador = coordenador;
            CarregarFormadores();
        }

        private void InitializeComponent()
        {
            this.Text = "Alocar Formador ao Coordenador";
            this.Size = new System.Drawing.Size(500, 400);
            this.StartPosition = FormStartPosition.CenterParent;

            Label lblTitulo = new Label()
            {
                Text = $"Coordenador: {coordenador.Nome}",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true,
                Font = new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold)
            };

            Label lblFormadores = new Label()
            {
                Text = "Formadores Disponíveis:",
                Location = new System.Drawing.Point(20, 50),
                AutoSize = true
            };

            ListBox listBoxFormadores = new ListBox()
            {
                Name = "listBoxFormadores",
                Location = new System.Drawing.Point(20, 75),
                Size = new System.Drawing.Size(440, 200)
            };

            Button btnAlocar = new Button()
            {
                Text = "Alocar",
                Location = new System.Drawing.Point(280, 290),
                Size = new System.Drawing.Size(90, 30)
            };
            btnAlocar.Click += BtnAlocar_Click;

            Button btnCancelar = new Button()
            {
                Text = "Cancelar",
                DialogResult = DialogResult.Cancel,
                Location = new System.Drawing.Point(380, 290),
                Size = new System.Drawing.Size(90, 30)
            };

            this.Controls.AddRange(new Control[] {
                lblTitulo, lblFormadores, listBoxFormadores, btnAlocar, btnCancelar
            });
            this.CancelButton = btnCancelar;
        }

        private void CarregarFormadores()
        {
            ListBox listBox = (ListBox)this.Controls["listBoxFormadores"];
            listBox.Items.Clear();

            // Corrigido: acessar todos os funcionários do tipo Formador
            foreach (var formador in empresa.Funcionarios.OfType<Formador>())
            {
                bool jaAlocado = coordenador.FormadoresAssociados.Contains(formador);
                string status = jaAlocado ? " (Já alocado)" : "";
                listBox.Items.Add(new { Formador = formador, Display = $"{formador.Nome} - {formador.AreaLeciona}{status}" });
            }
            listBox.DisplayMember = "Display";
        }

        private void BtnAlocar_Click(object sender, EventArgs e)
        {
            ListBox listBox = (ListBox)this.Controls["listBoxFormadores"];

            if (listBox.SelectedItem == null)
            {
                MessageBox.Show("Selecione um formador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dynamic item = listBox.SelectedItem;
            Formador formador = item.Formador;

            if (coordenador.FormadoresAssociados.Contains(formador))
            {
                MessageBox.Show("Este formador já está alocado a este coordenador.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            coordenador.AdicionarFormador(formador);
            MessageBox.Show($"Formador {formador.Nome} alocado com sucesso!", "Sucesso",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
