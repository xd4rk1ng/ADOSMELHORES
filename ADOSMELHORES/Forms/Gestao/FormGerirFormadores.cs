using ADOSMELHORES.Modelos;
using System.Windows.Forms;

namespace ADOSMELHORES.Forms.Gestao
{
    public class FormGerirFormadores : Form
    {
        private Empresa empresa;

        public FormGerirFormadores(Empresa empresa)
        {
            this.empresa = empresa;
        }
    }
}