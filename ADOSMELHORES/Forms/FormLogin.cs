using ADOSMELHORES.Modelos;
using System;
using System.Windows.Forms;

namespace ADOSMELHORES.Forms
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                MessageBox.Show("Login efetuado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Login falhou! Tente outra vez", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.Retry;
            }

        }

        private bool ValidarCampos()
        {
            // Para ser facil
            //return true;

            if (txtPassword.Text == "admin123")
                return true;
            else
                return false;
        }

        private void frm_onClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
