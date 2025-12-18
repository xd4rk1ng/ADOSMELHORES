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
        private Empresa _empresa;
        public FormExemplo(FormInicial main, Empresa empresa)
        {
            InitializeComponent();
            _main = main;
            _empresa = empresa;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtBxNome.Text != string.Empty) // se a text box nao estiver vazia
            {
                _empresa.AdicionarFuncionario(new Exemplo(nome: txtBxNome.Text));
                _main.UpdateListBox();
                }
            }
        }
    }
