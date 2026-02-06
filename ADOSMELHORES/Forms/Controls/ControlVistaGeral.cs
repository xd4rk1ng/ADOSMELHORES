using ADOSMELHORES.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADOSMELHORES.Forms.Controls
{
    public partial class ControlVistaGeral : UserControl
    {
        private readonly Empresa _empresa;
        private Filtros _filtroSelecionado;

        public enum Filtros
        {
            Todos = 0,
            ContratosValidos,
            RegCrimExpirados,
            SituacaoRegular
        }
        private Dictionary<Filtros, string> filtros = new Dictionary<Filtros, string>
        {
            { Filtros.Todos,  "Todos"  },
            { Filtros.ContratosValidos,  "Contratos Válidos"  },
            { Filtros.RegCrimExpirados, "Reg. Criminais Expirados" },
            { Filtros.SituacaoRegular, "Situação Regularizada" }
        };

        public ControlVistaGeral(Empresa empresa)
        {
            _empresa = empresa;
            _filtroSelecionado = Filtros.Todos;
            InitializeComponent();

            cmbFiltros.DataSource = filtros.ToList();
            cmbFiltros.DisplayMember = "Value";
            cmbFiltros.ValueMember = "Key";



            lstFuncionarios.View = View.Details;
            lstFuncionarios.FullRowSelect = true;
            lstFuncionarios.GridLines = true;

            lblLista.Text = "Lista de Funcionários";
            lstFuncionarios.Columns.Add("ID", 60);
            lstFuncionarios.Columns.Add("Nome", 150);
            lstFuncionarios.Columns.Add("Função", 120);

            AtualizarDados();

        }
        public void AtualizarDados(Filtros filtroSelecionado = Filtros.Todos)
        {
            lstFuncionarios.Items.Clear();

            List<Funcionario> listaFiltrada = null;
            switch (filtroSelecionado)
            {
                case Filtros.Todos:
                    listaFiltrada = _empresa.Funcionarios.ToList();
                    break;
                case Filtros.ContratosValidos:
                    listaFiltrada = _empresa.Funcionarios.Where(f => f.ContratoValido(DateTime.Now)).ToList();
                    break;
                case Filtros.RegCrimExpirados:
                    listaFiltrada = _empresa.Funcionarios.Where(f => f.RegistoCriminalExpirado(DateTime.Now)).ToList();
                    break;
                case Filtros.SituacaoRegular:
                    listaFiltrada = _empresa.Funcionarios.Where(f => f.ContratoValido(DateTime.Now) && !f.RegistoCriminalExpirado(DateTime.Now)).ToList();
                    break;
            }

            foreach (var funcionario in listaFiltrada)
            {
                var item = new ListViewItem(funcionario.Id.ToString());
                item.SubItems.Add(funcionario.Nome);
                item.SubItems.Add(funcionario.GetType().Name);
                lstFuncionarios.Items.Add(item);
            }
        }

        private void frm_onClick(object sender, EventArgs e)
        {
            AtualizarDados(_filtroSelecionado);
        }

        private void btnCSV_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                sfd.FileName = "funcionarios_export.csv";
                sfd.Title = "Exportar Funcionários para CSV";

                if (sfd.ShowDialog(this) == DialogResult.OK)
                {
                    try
                    {
                        _empresa.ExportarFuncionariosParaCSV(sfd.FileName);
                        MessageBox.Show("Exportação concluída com sucesso.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erro ao exportar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void cmbFiltros_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFiltros.SelectedValue is Filtros filtro)
            {
                _filtroSelecionado = filtro;
                AtualizarDados(_filtroSelecionado);
            }
        }
    }
}
