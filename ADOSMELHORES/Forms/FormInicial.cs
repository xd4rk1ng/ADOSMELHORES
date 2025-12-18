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
    public partial class FormInicial : Form
    {
        private Empresa _empresa;
        public FormInicial(Empresa empresa)
        {
            InitializeComponent();
            _empresa = empresa;
        }

        public void UpdateListBox()
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _empresa.Colaboradores;
        }

        private void btnExemplo_Click_1(object sender, EventArgs e)
        {
            FormExemplo f = new FormExemplo(this, _empresa);
            f.Show();
        }

        private void btnFormador_Click(object sender, EventArgs e)
        {
            FormGerirFormadores f = new FormGerirFormadores(_empresa); 
            f.Show();   
        }

        private void btnCoordenador_Click(object sender, EventArgs e)
        {
            FormGerirCoordenadores f = new FormGerirCoordenadores(_empresa); // passa a instância correta de Empresa
            f.Show(); // corrigido para "Show" com S maiúsculo
        }
    }
}
