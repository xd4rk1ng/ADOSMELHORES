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


namespace ADOSMELHORES.Forms
{
    public partial class FormInicial : Form
    {
        private Empresa empresa;
        public FormInicial()
        {
            InitializeComponent();
            empresa = new Empresa("A DOS MELHORES");
        }
        private void btnExemplo_Click_1(object sender, EventArgs e)
        {
            FormExemplo f = new FormExemplo(this);   // create the new form
            f.Show();                // show it (non-blocking)
        }

        private void btnFormador_Click(object sender, EventArgs e)
        {

        }

        public void UpdateListBox()
        {
            listBox1.DataSource = null;                // reset binding
            //listBox1.DataSource = Empresa.Colaboradores; // or any list
        }

        private void btnDiretor_Click(object sender, EventArgs e)
        {
            try
            {
                // Crie uma instância do FormGerirDiretores passando a empresa
                var formDiretores = new FormGerirDiretores(empresa);

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
