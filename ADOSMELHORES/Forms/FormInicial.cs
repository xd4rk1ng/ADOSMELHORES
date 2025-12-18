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
using AdosMelhores.Forms;


namespace ADOSMELHORES.Forms
{
    public partial class FormInicial : Form
    {
<<<<<<< HEAD
        private Empresa _empresa;
        public FormInicial(Empresa empresa)
        {
            InitializeComponent();
            _empresa = empresa;
=======
        // Altere o modificador de acesso do campo 'empresa' de 'private' para 'internal' ou 'public'
        internal Empresa empresa;

        // Modifique o construtor para receber a instância de Empresa
        public FormInicial(Empresa empresa)
        {
            InitializeComponent();
            this.empresa = empresa;
>>>>>>> Diego_branch
        }

        public void UpdateListBox()
        {
            listBox1.DataSource = null;                // reset binding
            listBox1.DataSource = empresa.Funcionarios; // use the correct property
        }

        private void btnExemplo_Click_1(object sender, EventArgs e)
        {
            FormExemplo f = new FormExemplo(this, _empresa);   // create the new form
            f.Show();                // show it (non-blocking)
        }

        private void btnFormador_Click(object sender, EventArgs e)
        {
            FormGerirFormadores f = new FormGerirFormadores(empresa); // passa a instância correta de Empresa
            f.Show(); // corrigido para "Show" com S maiúsculo
        }

        private void btnCoordenador_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            listBox1.DataSource = null;                // reset binding
            listBox1.DataSource = _empresa.Colaboradores; // or any list
=======
            FormGerirCoordenadores f = new FormGerirCoordenadores(empresa); // passa a instância correta de Empresa
            f.Show(); // corrigido para "Show" com S maiúsculo
>>>>>>> Diego_branch
        }
    }
}
