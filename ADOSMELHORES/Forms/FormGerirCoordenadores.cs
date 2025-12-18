using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADOSMELHORES.Modelos;

namespace ADOSMELHORES.Forms
{
    public partial class FormGerirCoordenadores : Form
    {
        private Empresa empresa;

        public FormGerirCoordenadores(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
            AtualizarListagem();
        }

        private void AtualizarListagem()
        {
            listViewCoordenadores.Items.Clear();

            foreach (var coordenador in empresa.ObterCoordenadores())
            {
                ListViewItem item = new ListViewItem(coordenador.Nome);
                item.SubItems.Add(coordenador.Id.ToString());
                item.SubItems.Add(coordenador.Morada);
                item.SubItems.Add(coordenador.Contacto);
                item.SubItems.Add(coordenador.Nif.ToString());
                item.SubItems.Add(coordenador.DataNascimento.ToShortDateString());
                item.SubItems.Add(coordenador.DataIniContrato.ToShortDateString());
                item.SubItems.Add(coordenador.SalarioBase.ToString("C"));
                item.SubItems.Add(coordenador.AreaCoordenacao);
                item.Tag = coordenador;
                listViewCoordenadores.Items.Add(item);
            }

            lblTotal.Text = $"Total de Coordenadores: {empresa.ObterCoordenadores().Count}";
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            FormAdicionarCoordenador form = new FormAdicionarCoordenador(empresa);
            if (form.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
                MessageBox.Show("Coordenador adicionado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (listViewCoordenadores.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um coordenador para editar.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Coordenador coordenador = (Coordenador)listViewCoordenadores.SelectedItems[0].Tag;
            FormEditarCoordenador form = new FormEditarCoordenador(coordenador);
            if (form.ShowDialog() == DialogResult.OK)
            {
                AtualizarListagem();
                MessageBox.Show("Coordenador atualizado com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (listViewCoordenadores.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um coordenador para remover.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Coordenador coordenador = (Coordenador)listViewCoordenadores.SelectedItems[0].Tag;

            DialogResult result = MessageBox.Show(
                $"Tem certeza que deseja remover o coordenador {coordenador.Nome}?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                empresa.ObterCoordenadores().Remove(coordenador);
                AtualizarListagem();
                MessageBox.Show("Coordenador removido com sucesso!", "Sucesso",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCalcularCusto_Click(object sender, EventArgs e)
        {
            if (listViewCoordenadores.SelectedItems.Count == 0)
            {
                MessageBox.Show("Selecione um coordenador.", "Aviso",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Coordenador coordenador = (Coordenador)listViewCoordenadores.SelectedItems[0].Tag;
            double custo = coordenador.CalcularCustoMensal();

            MessageBox.Show(
                $"Custo mensal do coordenador {coordenador.Nome}:\n" +
                $"Salário: {coordenador.SalarioBase:C}\n" +
                $"Total: {custo:C}",
                "Custo Mensal",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        //private void btnAtualizarRegistoCriminal_Click(object sender, EventArgs e)
        //{
        //    if (listViewCoordenadores.SelectedItems.Count == 0)
        //    {
        //        MessageBox.Show("Selecione um coordenador.", "Aviso",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    Coordenador coordenador = (Coordenador)listViewCoordenadores.SelectedItems[0].Tag;
        //    FormAtualizarRegistoCriminalCoordenador form = new FormAtualizarRegistoCriminalCoordenador(coordenador);
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        MessageBox.Show("Registo criminal atualizado com sucesso!", "Sucesso",
        //            MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}

        //private void btnFiltrar_Click(object sender, EventArgs e)
        //{
        //    FormFiltrarCoordenadores form = new FormFiltrarCoordenadores(empresa);
        //    if (form.ShowDialog() == DialogResult.OK)
        //    {
        //        // Aplicar filtros
        //        List<Coordenador> coordenadoresFiltrados = form.CoordenadoresFiltrados;

        //        listViewCoordenadores.Items.Clear();
        //        foreach (var coordenador in coordenadoresFiltrados)
        //        {
        //            ListViewItem item = new ListViewItem(coordenador.Nome);
        //            item.SubItems.Add(coordenador.Id.ToString());
        //            item.SubItems.Add(coordenador.Morada);
        //            item.SubItems.Add(coordenador.Contacto);
        //            item.SubItems.Add(coordenador.Nif.ToString());
        //            item.SubItems.Add(coordenador.DataNascimento.ToShortDateString());
        //            item.SubItems.Add(coordenador.DataIniContrato.ToShortDateString());
        //            item.SubItems.Add(coordenador.SalarioBase.ToString("C"));
        //            item.SubItems.Add(coordenador.AreaCoordenacao);
        //            item.Tag = coordenador;
        //            listViewCoordenadores.Items.Add(item);
        //        }

        //        lblTotal.Text = $"Coordenadores Filtrados: {coordenadoresFiltrados.Count} de {empresa.ObterCoordenadores().Count}";
        //    }
        //}

        private void btnLimparFiltro_Click(object sender, EventArgs e)
        {
            AtualizarListagem();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
