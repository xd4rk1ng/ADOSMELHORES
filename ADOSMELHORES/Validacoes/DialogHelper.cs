using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ADOSMELHORES.Validacoes;

namespace ADOSMELHORES.Validacoes
{
    /// <summary>
    /// Helper para diálogos e mensagens comuns
    /// </summary>
    public static class DialogHelper
    {
        #region Diálogos de Confirmação

        /// <summary>
        /// Mostra um diálogo de confirmação
        /// </summary>
        public static bool ConfirmarAcao(string mensagem, string titulo = "Confirmação")
        {
            var resultado = MessageBox.Show(
                mensagem,
                titulo,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return resultado == DialogResult.Yes;
        }

        /// <summary>
        /// Confirma remoção de item
        /// </summary>
        public static bool ConfirmarRemocao(string nomeItem, string tipoItem = "item")
        {
            return ConfirmarAcao(
                $"Tem certeza que deseja remover {tipoItem} '{nomeItem}'?",
                "Confirmar Remoção");
        }

        #endregion

        #region Mensagens de Aviso e Erro

        /// <summary>
        /// Mostra mensagem de aviso
        /// </summary>
        public static void MostrarAviso(string mensagem, string titulo = "Aviso")
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Mostra mensagem de erro
        /// </summary>
        public static void MostrarErro(string mensagem, string titulo = "Erro")
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Mostra mensagem de sucesso
        /// </summary>
        public static void MostrarSucesso(string mensagem, string titulo = "Sucesso")
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Mostra mensagem de erro para exceção
        /// </summary>
        public static void ErroOperacao(string operacao, Exception ex)
        {
            MostrarErro($"Erro ao {operacao}:{Environment.NewLine}{ex.Message}");
        }

        /// <summary>
        /// Aviso para selecionar item
        /// </summary>
        public static void AvisoSelecionarItem(string acao, string tipoItem = "item")
        {
            MostrarAviso($"Selecione um {tipoItem} para {acao}.");
        }

        #endregion

        #region Registo Criminal

        /// <summary>
        /// Classe que representa o status do registo criminal
        /// </summary>
        public class StatusRegistoCriminal
        {
            public bool Expirado { get; set; }
            public string Texto { get; set; }
            public Color CorTexto { get; set; }
            public Color CorFundo { get; set; }

            public StatusRegistoCriminal(bool expirado)
            {
                Expirado = expirado;

                if (expirado)
                {
                    Texto = "EXPIRADO";
                    CorTexto = Color.Red;
                    CorFundo = Color.LightYellow;
                }
                else
                {
                    Texto = "Válido";
                    CorTexto = Color.Green;
                    CorFundo = SystemColors.Window;
                }
            }
        }

        /// <summary>
        /// Mostra diálogo para atualizar data do registo criminal
        /// </summary>
        /// <param name="parent">Form pai para centralizar</param>
        /// <returns>Nova data se OK, null se cancelado</returns>
        public static DateTime? DialogoAtualizarRegistoCriminal(Form parent = null)
        {
            using (Form formData = new Form())
            {
                formData.Text = "Atualizar Registo Criminal";
                formData.Size = new Size(320, 180);
                formData.StartPosition = parent != null
                    ? FormStartPosition.CenterParent
                    : FormStartPosition.CenterScreen;
                formData.FormBorderStyle = FormBorderStyle.FixedDialog;
                formData.MaximizeBox = false;
                formData.MinimizeBox = false;

                Label lblInfo = new Label()
                {
                    Text = "Nova data de validade do registo criminal:",
                    Location = new Point(20, 20),
                    AutoSize = true,
                    MaximumSize = new Size(260, 0)
                };

                DateTimePicker dtp = new DateTimePicker()
                {
                    Location = new Point(20, 55),
                    Width = 260,
                    Format = DateTimePickerFormat.Short,
                    Value = DateTime.Now.AddYears(1)
                };

                Button btnOk = new Button()
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new Point(100, 95),
                    Size = new Size(75, 30)
                };

                Button btnCancelar = new Button()
                {
                    Text = "Cancelar",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(185, 95),
                    Size = new Size(75, 30)
                };

                formData.Controls.AddRange(new Control[] { lblInfo, dtp, btnOk, btnCancelar });
                formData.AcceptButton = btnOk;
                formData.CancelButton = btnCancelar;

                if (formData.ShowDialog(parent) == DialogResult.OK)
                {
                    return dtp.Value;
                }

                return null;
            }
        }

        /// <summary>
        /// Atualiza um TextBox com o status do registo criminal
        /// </summary>
        /// <param name="textBox">TextBox a atualizar</param>
        /// <param name="funcionario">Funcionário (deve ter método RegistoCriminalExpirado)</param>
        /// <param name="dataReferencia">Data de referência (usa DateTime.Now se não fornecida)</param>
        public static void AtualizarStatusRegistoCriminal(
            TextBox textBox,
            object funcionario,
            DateTime? dataReferencia = null)
        {
            if (textBox == null)
                throw new ArgumentNullException(nameof(textBox));

            if (funcionario == null)
            {
                textBox.Text = "-";
                textBox.ForeColor = SystemColors.ControlText;
                textBox.BackColor = SystemColors.Window;
                return;
            }

            DateTime referencia = (dataReferencia ?? DateTime.Now).Date;
            bool expirado = VerificarRegistoCriminalExpirado(funcionario, referencia);

            var status = new StatusRegistoCriminal(expirado);
            AplicarStatusEmControl(textBox, status);
        }

        /// <summary>
        /// Atualiza um Label com o status do registo criminal
        /// </summary>
        public static void AtualizarStatusRegistoCriminal(
            Label label,
            object funcionario,
            DateTime? dataReferencia = null)
        {
            if (label == null)
                throw new ArgumentNullException(nameof(label));

            if (funcionario == null)
            {
                label.Text = "-";
                label.ForeColor = SystemColors.ControlText;
                label.BackColor = SystemColors.Control;
                return;
            }

            DateTime referencia = (dataReferencia ?? DateTime.Now).Date;
            bool expirado = VerificarRegistoCriminalExpirado(funcionario, referencia);

            var status = new StatusRegistoCriminal(expirado);
            AplicarStatusEmControl(label, status);
        }

        /// <summary>
        /// Verifica se o registo criminal está expirado usando reflexão
        /// </summary>
        private static bool VerificarRegistoCriminalExpirado(object funcionario, DateTime dataReferencia)
        {
            try
            {
                var metodo = funcionario.GetType().GetMethod("RegistoCriminalExpirado");
                if (metodo != null)
                {
                    return (bool)metodo.Invoke(funcionario, new object[] { dataReferencia });
                }
            }
            catch
            {
                // Se falhar, considera não expirado por segurança
            }

            return false;
        }

        /// <summary>
        /// Aplica o status visual em um control (TextBox ou Label)
        /// </summary>
        private static void AplicarStatusEmControl(Control control, StatusRegistoCriminal status)
        {
            if (control is TextBox textBox)
            {
                textBox.Text = status.Texto;
                textBox.ForeColor = status.CorTexto;
                textBox.BackColor = status.CorFundo;
            }
            else if (control is Label label)
            {
                label.Text = status.Texto;
                label.ForeColor = status.CorTexto;
                label.BackColor = status.CorFundo;
            }
        }

        #endregion

        #region Diálogos de Entrada

        /// <summary>
        /// Mostra diálogo para entrada de texto simples
        /// </summary>
        public static string DialogoEntradaTexto(
            string titulo,
            string mensagem,
            string valorPadrao = "",
            Form parent = null)
        {
            using (Form formInput = new Form())
            {
                formInput.Text = titulo;
                formInput.Size = new Size(400, 150);
                formInput.StartPosition = parent != null
                    ? FormStartPosition.CenterParent
                    : FormStartPosition.CenterScreen;
                formInput.FormBorderStyle = FormBorderStyle.FixedDialog;
                formInput.MaximizeBox = false;
                formInput.MinimizeBox = false;

                Label lblMensagem = new Label()
                {
                    Text = mensagem,
                    Location = new Point(20, 20),
                    AutoSize = true,
                    MaximumSize = new Size(340, 0)
                };

                TextBox txtInput = new TextBox()
                {
                    Location = new Point(20, 50),
                    Width = 340,
                    Text = valorPadrao
                };

                Button btnOk = new Button()
                {
                    Text = "OK",
                    DialogResult = DialogResult.OK,
                    Location = new Point(200, 80),
                    Size = new Size(75, 30)
                };

                Button btnCancelar = new Button()
                {
                    Text = "Cancelar",
                    DialogResult = DialogResult.Cancel,
                    Location = new Point(285, 80),
                    Size = new Size(75, 30)
                };

                formInput.Controls.AddRange(new Control[] { lblMensagem, txtInput, btnOk, btnCancelar });
                formInput.AcceptButton = btnOk;
                formInput.CancelButton = btnCancelar;

                if (formInput.ShowDialog(parent) == DialogResult.OK)
                {
                    return txtInput.Text;
                }

                return null;
            }
        }

        #endregion
    }
}
