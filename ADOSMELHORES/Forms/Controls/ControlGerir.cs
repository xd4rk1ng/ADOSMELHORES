using ADOSMELHORES.Forms;
using ADOSMELHORES.Forms.Coordenadores;
using ADOSMELHORES.Forms.Diretores;
using ADOSMELHORES.Forms.Formadores;
using ADOSMELHORES.Forms.Secretarias;
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

namespace ADOSMELHORES.Controls
{
    public partial class ControlGestao : UserControl
    {
        private readonly Empresa _empresa;
        
        public ControlGestao(Empresa empresa)
        {
            _empresa = empresa;
            InitializeComponent();
        }

        private void btnFormadores_Click(object sender, EventArgs e)
        {
            var f = new FormGerirFormadores(_empresa);
            f.Show();
        }

        private void btnCoordenadores_Click(object sender, EventArgs e)
        {
            var f = new FormGerirCoordenadores(_empresa);
            f.Show();
        }

        private void btnSecretarias_Click(object sender, EventArgs e)
        {
            var f = new FormGerirSecretarias(_empresa);
            f.Show();
        }

        private void btnDiretores_Click(object sender, EventArgs e)
        {
            var f = new FormGerirDiretores(_empresa);
            f.Show();
        }
    }
}
