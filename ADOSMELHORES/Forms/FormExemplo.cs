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
    public partial class FormExemplo : Form
    {
        private FormInicial _main;
        public FormExemplo(FormInicial main)
        {
            InitializeComponent();
            _main = main;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtBxNome.Text != string.Empty) // se a text box nao estiver vazia
            {
                // Corrigido: Faz cast para List<Funcionario> antes de chamar Add
                var colaboradores = Empresa.Colaboradores as List<Funcionario>;
                if (colaboradores != null)
                {
                    colaboradores.Add(new Exemplo(nome: txtBxNome.Text));
                    _main.UpdateListBox();
                }
                else
                {
                    MessageBox.Show("A lista de colaboradores não está inicializada corretamente.");
                }
            }
        }
    }
}
