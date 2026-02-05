using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES.Validacoes
{
    /// Classe que representa o resultado de uma validação
    public class ResultadoValidacao
    {
        public bool Valido { get; set; }
        public string Mensagem { get; set; }
        public string Titulo { get; set; }

        public ResultadoValidacao()
        {
            Valido = true;
            Mensagem = string.Empty;
            Titulo = "Validação";
        }

        public ResultadoValidacao(bool valido, string mensagem = "", string titulo = "Validação")
        {
            Valido = valido;
            Mensagem = mensagem ?? string.Empty;
            Titulo = titulo ?? "Validação";
        }

        /// <summary>
        /// Cria um resultado de sucesso
        /// </summary>
        public static ResultadoValidacao Sucesso()
        {
            return new ResultadoValidacao(true);
        }

        /// <summary>
        /// Cria um resultado de erro
        /// </summary>
        public static ResultadoValidacao Erro(string mensagem, string titulo = "Aviso")
        {
            return new ResultadoValidacao(false, mensagem, titulo);
        }

        /// <summary>
        /// Mostra a mensagem de validação em um MessageBox (apenas se inválido)
        /// </summary>
        public void MostrarMensagem()
        {
            if (!Valido && !string.IsNullOrEmpty(Mensagem))
            {
                MessageBox.Show(Mensagem, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// Mostra a mensagem de validação em um MessageBox (sempre)
        /// </summary>
        public void MostrarMensagemSempre()
        {
            if (!string.IsNullOrEmpty(Mensagem))
            {
                MessageBox.Show(Mensagem, Titulo, MessageBoxButtons.OK,
                    Valido ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
            }
        }
    }
}
