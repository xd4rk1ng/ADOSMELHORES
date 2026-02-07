using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES.Validacoes
{
    // VALIDACOES DE CAMPOS DE TEXTO
    public static class ValidarCampos
    {        

        // Constantes para NIF
        private const int NIF_TAMANHO = 9;
        private const int NIF_MIN = 100000000;
        private const int NIF_MAX = 999999999;

        // Constantes para Contacto
        private const int CONTACTO_TAMANHO = 9;
        private const char CONTACTO_PRIMEIRO_DIGITO = '9';

       
        // Valida se um campo de texto não está vazio
        // <param name="valor">Valor do campo</param>
        // <param name="nomeCampo">Nome do campo para mensagem</param>
        // <param name="titulo">Título da mensagem de erro</param>
        // <returns>ResultadoValidacao</returns>
        public static ResultadoValidacao ValidarCampoObrigatorio(
            string valor,
            string nomeCampo,
            string titulo = "Campo Obrigatório")
        {
            if (string.IsNullOrWhiteSpace(valor))
            {
                return ResultadoValidacao.Erro(
                    $"Por favor, insira {nomeCampo}.",
                    titulo);
            }

            return ResultadoValidacao.Sucesso();
        }

        // Valida se um TextBox não está vazio
        public static ResultadoValidacao ValidarTextBox(
            TextBox textBox,
            string nomeCampo,
            string titulo = "Campo Obrigatório")
        {
            if (textBox == null)
                throw new ArgumentNullException(nameof(textBox));

            return ValidarCampoObrigatorio(textBox.Text, nomeCampo, titulo);
        }

        


                

        // Valida se um ComboBox tem item selecionado
        public static ResultadoValidacao ValidarComboBox(
            ComboBox comboBox,
            string nomeCampo)
        {
            if (comboBox == null)
                throw new ArgumentNullException(nameof(comboBox));

            if (comboBox.SelectedIndex < 0 || comboBox.SelectedItem == null)
            {
                return ResultadoValidacao.Erro(
                    $"Por favor, selecione {nomeCampo}.",
                    "Seleção Obrigatória");
            }

            return ResultadoValidacao.Sucesso();
        }



      
        // Valida se um NumericUpDown tem valor maior que zero      
        public static ResultadoValidacao ValidarValorMaiorQueZero(
            NumericUpDown numericUpDown,
            string nomeCampo)
        {
            if (numericUpDown == null)
                throw new ArgumentNullException(nameof(numericUpDown));

            if (numericUpDown.Value <= 0)
            {
                return ResultadoValidacao.Erro(
                    $"{nomeCampo} deve ser maior que zero.",
                    "Valor Inválido");
            }

            return ResultadoValidacao.Sucesso();
        }


        public static ResultadoValidacao ValidarNIF(string nif, bool obrigatorio = true)
        {
            // Remover espaços em branco
            nif = nif?.Trim();

            // Verificar se está vazio
            if (string.IsNullOrWhiteSpace(nif))
            {
                if (obrigatorio)
                {
                    return ResultadoValidacao.Erro(
                        "Por favor, insira o NIF.",
                        "Campo Obrigatório");
                }
                return ResultadoValidacao.Sucesso();
            }

            // Verificar se tem exatamente 9 caracteres
            if (nif.Length != NIF_TAMANHO)
            {
                return ResultadoValidacao.Erro(
                    $"NIF inválido! O NIF deve ter {NIF_TAMANHO} dígitos.",
                    "NIF Inválido");
            }

            // Verificar se são todos dígitos
            if (!nif.All(char.IsDigit))
            {
                return ResultadoValidacao.Erro(
                    "NIF deve conter apenas números.",
                    "NIF Inválido");
            }

            // Converter para número e verificar intervalo
            if (int.TryParse(nif, out int nifNumero))
            {
                if (nifNumero >= NIF_MIN && nifNumero <= NIF_MAX)
                {
                    return ResultadoValidacao.Sucesso();
                }
            }

            return ResultadoValidacao.Erro(
                $"NIF inválido! O NIF deve estar entre {NIF_MIN} e {NIF_MAX}.",
                "NIF Inválido");
        }

        // Tenta obter o NIF como inteiro se for válido        
        public static bool TentarObterNIF(string nif, out int nifNumero)
        {
            nifNumero = 0;

            var resultado = ValidarNIF(nif, obrigatorio: false);
            if (!resultado.Valido)
                return false;

            return int.TryParse(nif?.Trim(), out nifNumero);
        }


        // Handler para KeyPress que permite apenas dígitos (para TextBox de NIF)
        public static void NIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas dígitos e teclas de controlo (backspace, delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // Handler para Validating que valida o NIF
        public static void NIF_Validating(object sender, CancelEventArgs e, bool obrigatorio = true)
        {
            if (sender is TextBox textBox)
            {
                var resultado = ValidarNIF(textBox.Text, obrigatorio);

                if (!resultado.Valido)
                {
                    e.Cancel = true;
                    resultado.MostrarMensagem();
                }
            }
        }

       // Configura eventos de validação automática para um TextBox de NIF       
        public static void ConfigurarTextBoxNIF(TextBox txtNIF, bool obrigatorio = true)
        {
            if (txtNIF == null)
                throw new ArgumentNullException(nameof(txtNIF));

            // Configurar MaxLength
            txtNIF.MaxLength = NIF_TAMANHO;

            // Remover handlers antigos para evitar duplicação
            txtNIF.KeyPress -= NIF_KeyPress;
            txtNIF.KeyPress += NIF_KeyPress;

            // Configurar Validating com closure para capturar obrigatorio
            KeyPressEventHandler validatingHandler = (s, ev) =>
            {
                //if (ev is CancelEventArgs cancelEv)
                //    NIF_Validating(s, cancelEv, obrigatorio);
            };

            // Note: Isto não funcionará corretamente, vou criar uma abordagem melhor
            txtNIF.Validating -= (s, ev) => NIF_Validating(s, ev, obrigatorio);
            txtNIF.Validating += (s, ev) => NIF_Validating(s, ev, obrigatorio);
        }

       // Validação de Contacto

        // Valida contacto telefónico (9 dígitos começando por 9)       
        public static ResultadoValidacao ValidarContacto(
            string contacto,
            bool obrigatorio = true)
        {
            contacto = contacto?.Trim() ?? string.Empty;

            // Verificar se está vazio
            if (string.IsNullOrWhiteSpace(contacto))
            {
                if (obrigatorio)
                    return ResultadoValidacao.Erro(
                        "Por favor, insira o contacto.",
                        "Campo Obrigatório");
                else
                    return ResultadoValidacao.Sucesso();
            }

            // Remove espaços e caracteres especiais para validação
            string contactoLimpo = contacto.Replace(" ", "")
                                          .Replace("-", "")
                                          .Replace("+", "");

            // Verifica se tem apenas dígitos
            if (!contactoLimpo.All(char.IsDigit))
            {
                return ResultadoValidacao.Erro(
                    "Contacto deve conter apenas números.",
                    "Entrada Inválida");
            }

            // Valida tamanho (9 dígitos para PT)
            if (contactoLimpo.Length != CONTACTO_TAMANHO)
            {
                return ResultadoValidacao.Erro(
                    $"Contacto deve ter {CONTACTO_TAMANHO} dígitos.",
                    "Entrada Inválida");
            }

            // Verifica se começa com 9 (números de telemóvel em Portugal)
            if (contactoLimpo[0] != CONTACTO_PRIMEIRO_DIGITO)
            {
                return ResultadoValidacao.Erro(
                    "Contacto deve começar com 9.",
                    "Entrada Inválida");
            }

            return ResultadoValidacao.Sucesso();
        }

        // Handler para KeyPress que permite apenas dígitos (para TextBox de Contacto)
        public static void Contacto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas dígitos, espaços, hífens e teclas de controlo
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                e.KeyChar != ' ' &&
                e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        // Configura eventos de validação automática para um TextBox de Contacto
        public static void ConfigurarTextBoxContacto(TextBox txtContacto, bool obrigatorio = true)
        {
            if (txtContacto == null)
                throw new ArgumentNullException(nameof(txtContacto));

            // Configurar MaxLength (9 dígitos + 2 espaços possíveis)
            txtContacto.MaxLength = 11;

            // Remover handlers antigos
            txtContacto.KeyPress -= Contacto_KeyPress;
            txtContacto.KeyPress += Contacto_KeyPress;
        }

       // Validações Combinadas

        /// Valida múltiplos resultados e retorna o primeiro erro encontrado
        public static ResultadoValidacao ValidarTodos(params ResultadoValidacao[] resultados)
        {
            foreach (var resultado in resultados)
            {
                if (!resultado.Valido)
                    return resultado;
            }

            return ResultadoValidacao.Sucesso();
        }

        // Valida e mostra mensagem do primeiro erro encontrado
        // <returns>True se todos válidos, False se encontrou erro</returns>
        public static bool ValidarEMostrar(params ResultadoValidacao[] resultados)
        {
            var resultado = ValidarTodos(resultados);

            if (!resultado.Valido)
            {
                resultado.MostrarMensagem();
                return false;
            }

            return true;
        }               
    }
}
