using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES.Validacoes
{
    public static class DialogHelper
    {
        //Dialogo para Atualizar Registo Criminal
        /// </summary>
        /// <param name="parent">Form pai para centralizar</param>
        /// <returns>Nova data se OK, null se cancelado</returns>
        /// 
        public static DateTime? DialogoAtualizarRegistoCriminal(Form parent)
        {
            using (Form formData = new Form())
            {
                formData.Text = "Atualizar Registo Criminal";
                formData.Size = new Size(300, 150);
                formData.StartPosition = FormStartPosition.CenterParent;

                Label lblInfo = new Label()
                {
                    Text = "Nova data de validade:",
                    Location = new Point(20, 20),
                    AutoSize = true
                };

                DateTimePicker dtp = new DateTimePicker()
                {
                    Location = new Point(20, 50),
                    Width = 240,
                    Value = DateTime.Now  
                };

                Button btnOk = new Button()
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new Point(100, 80)
                };

                formData.Controls.Add(lblInfo);
                formData.Controls.Add(dtp);
                formData.Controls.Add(btnOk);
                formData.AcceptButton = btnOk;

                if (formData.ShowDialog(parent) == DialogResult.OK)
                {
                    return dtp.Value;
                }

                return null;
            }
        }


        /// Mostra mensagem para selecionar item        
        public static void AvisoSelecionarItem(string acao, string tipoItem = "item")
        {
            MostrarAviso($"Selecione um {tipoItem} para {acao}.");
        }
                

        // Mostra mensagem de sucesso
       
        public static void MostrarSucesso(string mensagem, string titulo = "Sucesso")
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

     

        // Mostra mensagem de aviso
       
        public static void MostrarAviso(string mensagem, string titulo = "Aviso")
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

       

        // Mostra mensagem de erro para operação
        
        public static void ErroOperacao(string operacao, Exception ex)
        {
            MostrarErro($"Erro ao {operacao}: {ex.Message}");
        }
               
        // Mostra mensagem de erro
        
        public static void MostrarErro(string mensagem, string titulo = "Erro")
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
