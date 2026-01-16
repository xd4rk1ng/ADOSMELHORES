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
                //Empresa.Colaboradores.Add(new Exemplo(nome: txtBxNome.Text));
                _main.UpdateListBox();
            }
        }
    }
}
