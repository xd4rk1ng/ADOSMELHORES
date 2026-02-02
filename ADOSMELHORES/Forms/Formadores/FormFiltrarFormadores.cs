using ADOSMELHORES.Modelos;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ADOSMELHORES.Forms
{
    public partial class FormFiltrarFormadores : Form
    {
        private Empresa empresa;

        public FormFiltrarFormadores(Empresa empresaRef)
        {
            InitializeComponent();
            this.empresa = empresaRef;
            ConfigurarForm();
        }

        private void ConfigurarForm()
        {
            cmbDisponibilidade.DataSource = Enum.GetValues(typeof(Disponibilidade));
            ConfigurarDataGridView();
        }

        private void ConfigurarDataGridView()
        {
            dgvResultados.AutoGenerateColumns = false;
            dgvResultados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Nome",
                Width = 150
            });

            dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "AreaLeciona",
                HeaderText = "Área",
                Width = 120
            });

            dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Disponibilidade",
                HeaderText = "Disponibilidade",
                Width = 100
            });

            dgvResultados.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "ValorHora",
                HeaderText = "Valor/Hora",
                Width = 80,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" }
            });
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            Disponibilidade disponibilidade = (Disponibilidade)cmbDisponibilidade.SelectedItem;

            var formadoresFiltrados = empresa.Funcionarios
                .OfType<Formador>()
                .Where(f => f.Disponibilidade == disponibilidade)
                .ToList();

            dgvResultados.DataSource = formadoresFiltrados;
            lblResultado.Text = $"Encontrados {formadoresFiltrados.Count} formadores com disponibilidade: {disponibilidade}";
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
