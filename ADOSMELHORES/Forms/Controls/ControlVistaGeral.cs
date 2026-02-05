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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ADOSMELHORES.Forms.Controls
{
    public partial class ControlVistaGeral : UserControl
    {
        private readonly Empresa _empresa;
        public ControlVistaGeral(Empresa empresa)
        {
            _empresa = empresa;
            InitializeComponent();

            lstFuncionarios.View = View.Details;
            lstFuncionarios.FullRowSelect = true;
            lstFuncionarios.GridLines = true;

            lblLista.Text = "Lista de Funcioários";
            lstFuncionarios.Columns.Add("ID", 60);
            lstFuncionarios.Columns.Add("Nome", 150);
            lstFuncionarios.Columns.Add("Função", 120);
            lstFuncionarios.Columns.Add("Ativo", 80);

            AtualizarDados();

        }
        public void AtualizarDados()
        {
            lstFuncionarios.Items.Clear();
            foreach (var funcionario in _empresa.Funcionarios)
            {
                var item = new ListViewItem(funcionario.Id.ToString());
                item.SubItems.Add(funcionario.Nome);
                item.SubItems.Add(funcionario.GetType().Name);
                item.SubItems.Add(funcionario.ContratoValido(DateTime.Now) ? "Sim" : "Não");
                lstFuncionarios.Items.Add(item);
            }
        }

        private void frm_onClick(object sender, EventArgs e)
        {
            AtualizarDados();
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
    }
}
