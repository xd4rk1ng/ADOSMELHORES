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
        private Empresa _empresa;
        public FormInicial(Empresa empresa)
        {
            InitializeComponent();
            _empresa = empresa;
        }
        private void btnExemplo_Click_1(object sender, EventArgs e)
        {
            FormExemplo f = new FormExemplo(this, _empresa);   // create the new form
            f.Show();                // show it (non-blocking)
        }

        private void btnFormador_Click(object sender, EventArgs e)
        {

        }

        public void UpdateListBox()
        {
            listBox1.DataSource = null;                // reset binding
            listBox1.DataSource = _empresa.Colaboradores; // or any list
        }

    }
}
