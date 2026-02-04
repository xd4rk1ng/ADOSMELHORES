using ADOSMELHORES.Modelos;
using System;
using System.Windows.Forms;

namespace ADOSMELHORES.Forms
{
    public partial class FormLogin : Form
    {
        private Empresa _empresa;
        public FormLogin(Empresa empresa)
        {
            _empresa = empresa;
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                var mainForm = new FormInicialWIP(_empresa);
                mainForm.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Password Incorreta");
            }

        }

        private bool ValidarCampos()
        {
            // Para ser facil
            return true;

            if (txtPassword.Text == "admin123")
                return true;
            else
                return false;
        }
    }
}
