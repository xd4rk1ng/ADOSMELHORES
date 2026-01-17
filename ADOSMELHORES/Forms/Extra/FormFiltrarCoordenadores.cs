using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ADOSMELHORES.Modelos;

namespace ADOSMELHORES.Forms
{
    public partial class FormFiltrarCoordenadores : Form
    {
        private Empresa empresa;
        public List<Coordenador> CoordenadoresFiltrados { get; private set; }

        public FormFiltrarCoordenadores(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
            CoordenadoresFiltrados = new List<Coordenador>();
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            CoordenadoresFiltrados = empresa.Funcionarios
                .OfType<Coordenador>()
                .Where(c =>
                {
                    bool filtrado = true;

                    // Filtrar por nome
                    if (!string.IsNullOrWhiteSpace(txtNome.Text))
                    {
                        filtrado = filtrado && c.Nome.ToLower().Contains(txtNome.Text.ToLower());
                    }

                    // Filtrar por área de formação
                    if (!string.IsNullOrWhiteSpace(txtAreaFormacao.Text))
                    {
                        filtrado = filtrado && c.AreaCoordenacao.ToLower().Contains(txtAreaFormacao.Text.ToLower());
                    }

                    // Filtrar por salário mínimo
                    if (checkBoxSalarioMin.Checked)
                    {
                        filtrado = filtrado && c.SalarioBase >= numericSalarioMin.Value;
                    }

                    // Filtrar por salário máximo
                    if (checkBoxSalarioMax.Checked)
                    {
                        filtrado = filtrado && c.SalarioBase <= numericSalarioMax.Value;
                    }

                    return filtrado;
                }).ToList();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
