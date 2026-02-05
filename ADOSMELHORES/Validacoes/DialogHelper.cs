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

        public class StatusRegistoCriminal
        {
            public bool Expirado { get; set; }
            public string Texto { get; set; }
            public System.Drawing.Color CorTexto { get; set; }
            public System.Drawing.Color CorFundo { get; set; }

            public StatusRegistoCriminal(bool expirado)
            {
                Expirado = expirado;

                if (expirado)
                {
                    Texto = "EXPIROU";
                    CorTexto = System.Drawing.Color.Red;
                    CorFundo = System.Drawing.Color.LightYellow;
                }
                else
                {
                    Texto = "Válido";
                    CorTexto = System.Drawing.Color.Green;
                    CorFundo = System.Drawing.SystemColors.Window;
                }
            }
        }

        /// Atualiza um TextBox com o status do registo criminal
        /// Usa o método RegistoCriminalExpirado() do Funcionario
        /// </summary>
        /// <param name="textBox">TextBox a atualizar</param>
        /// <param name="funcionario">Funcionário (deve ter método RegistoCriminalExpirado)</param>
        /// <param name="empresa">Instância da empresa (para obter DataSimulada)</param>
        public static void AtualizarTextBoxStatusRegistoCriminal(
            System.Windows.Forms.TextBox textBox,
            object funcionario,
            object empresa = null)
        {
            if (textBox == null)
                throw new ArgumentNullException(nameof(textBox));

            if (funcionario == null)
            {
                textBox.Text = "-";
                textBox.ForeColor = System.Drawing.SystemColors.ControlText;
                textBox.BackColor = System.Drawing.SystemColors.Window;
                return;
            }

            // Determinar data de referência
            DateTime referencia = DateTime.Now.Date;

            // Se empresa foi fornecida e tem DataSimulada configurada, usar ela
            if (empresa != null)
            {
                try
                {
                    var propriedade = empresa.GetType().GetProperty("DataSimulada");
                    if (propriedade != null)
                    {
                        var dataSimulada = (DateTime)propriedade.GetValue(empresa);
                        if (dataSimulada > DateTime.MinValue)
                        {
                            referencia = dataSimulada.Date;
                        }
                    }
                }
                catch
                {
                    // Se falhar, usa data atual
                    referencia = DateTime.Now.Date;
                }
            }

            // Usar o método RegistoCriminalExpirado do Funcionario
            bool expirado = false;
            try
            {
                var metodo = funcionario.GetType().GetMethod("RegistoCriminalExpirado");
                if (metodo != null)
                {
                    expirado = (bool)metodo.Invoke(funcionario, new object[] { referencia });
                }
            }
            catch
            {
                // Se falhar, considera não expirado
                expirado = false;
            }

            var status = new StatusRegistoCriminal(expirado);

            textBox.Text = status.Texto;
            textBox.ForeColor = status.CorTexto;
            textBox.BackColor = status.CorFundo;
        }

       
        /// Atualiza um Label com o status do registo criminal
        /// Usa o método RegistoCriminalExpirado() do Funcionario
        /// </summary>
        /// <param name="label">Label a atualizar</param>
        /// <param name="funcionario">Funcionário (deve ter método RegistoCriminalExpirado)</param>
        /// <param name="empresa">Instância da empresa (para obter DataSimulada)</param>
        public static void AtualizarLabelStatusRegistoCriminal(
            System.Windows.Forms.Label label,
            object funcionario,
            object empresa = null)
        {
            if (label == null)
                throw new ArgumentNullException(nameof(label));

            if (funcionario == null)
            {
                label.Text = "-";
                label.ForeColor = System.Drawing.SystemColors.ControlText;
                label.BackColor = System.Drawing.SystemColors.Window;
                return;
            }

            // Determinar data de referência
            DateTime referencia = DateTime.Now.Date;

            // Se empresa foi fornecida e tem DataSimulada configurada, usar ela
            if (empresa != null)
            {
                try
                {
                    var propriedade = empresa.GetType().GetProperty("DataSimulada");
                    if (propriedade != null)
                    {
                        var dataSimulada = (DateTime)propriedade.GetValue(empresa);
                        if (dataSimulada > DateTime.MinValue)
                        {
                            referencia = dataSimulada.Date;
                        }
                    }
                }
                catch
                {
                    // Se falhar, usa data atual
                    referencia = DateTime.Now.Date;
                }
            }

            // Usar o método RegistoCriminalExpirado do Funcionario
            bool expirado = false;
            try
            {
                var metodo = funcionario.GetType().GetMethod("RegistoCriminalExpirado");
                if (metodo != null)
                {
                    expirado = (bool)metodo.Invoke(funcionario, new object[] { referencia });
                }
            }
            catch
            {
                // Se falhar, considera não expirado
                expirado = false;
            }

            var status = new StatusRegistoCriminal(expirado);

            label.Text = status.Texto;
            label.ForeColor = status.CorTexto;
            label.BackColor = status.CorFundo;
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
