using AdosMelhores.Forms;
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
using ADOSMELHORES.Forms;

namespace ADOSMELHORES.Forms
{
    public partial class FormInicial : Form
    {
        // Altere o modificador de acesso do campo 'empresa' de 'private' para 'internal' ou 'public'
        internal Empresa _empresa;

        // Modifique o construtor para receber a instância de Empresa
        public FormInicial(Empresa empresa)
        {
            InitializeComponent();
            _empresa = empresa;
        }

        public void UpdateListBox()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _empresa.Funcionarios; 
        }

        private void btnExemplo_Click_1(object sender, EventArgs e)
        {
            FormExemplo f = new FormExemplo(this);   // create the new form
            f.Show();                // show it
        }

        private void btnFormador_Click(object sender, EventArgs e)
        {
            // Usa a referência explícita ao namespace que contém o formulário completo.
            var f = new AdosMelhores.Forms.FormGerirFormadores(_empresa);
            f.Show();
        }

        private void btnCoordenador_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = null;                // reset binding
            //listBox1.DataSource = Empresa.Colaboradores; // or any list
        }

        private void btnDiretor_Click(object sender, EventArgs e)
        {
            try
            {
                // Crie uma instância do FormGerirDiretores passando a empresa
                var formDiretores = new FormGerirDiretores(_empresa);

                // Mostre o formulário
                // Use ShowDialog() se quiser bloquear até fechar
                // Use Show() se quiser permitir múltiplas janelas
                formDiretores.Show();

                // Ou se quiser modal (bloqueia até fechar):
                // formDiretores.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao abrir formulário de Diretores: {ex.Message}",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
