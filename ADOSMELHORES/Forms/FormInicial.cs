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
        public FormInicial()
        {
            InitializeComponent();
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
            listBox1.DataSource = Empresa.Colaboradores; // or any list
        }

    }
}
