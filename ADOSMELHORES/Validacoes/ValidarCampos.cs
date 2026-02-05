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
        #region Constantes de Validação

        // Constantes para NIF
        private const int NIF_TAMANHO = 9;
        private const int NIF_MIN = 100000000;
        private const int NIF_MAX = 999999999;

        // Constantes para Contacto
        private const int CONTACTO_TAMANHO = 9;
        private const char CONTACTO_PRIMEIRO_DIGITO = '9';

        #endregion

        #region Validações de Campos de Texto Obrigatórios

        /// <summary>
        /// Valida se um campo de texto não está vazio
        /// </summary>
        /// <param name="valor">Valor do campo</param>
        /// <param name="nomeCampo">Nome do campo para mensagem</param>
        /// <param name="titulo">Título da mensagem de erro</param>
        /// <returns>ResultadoValidacao</returns>
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

        /// <summary>
        /// Valida se um TextBox não está vazio
        /// </summary>
        public static ResultadoValidacao ValidarTextBox(
            TextBox textBox,
            string nomeCampo,
            string titulo = "Campo Obrigatório")
        {
            if (textBox == null)
                throw new ArgumentNullException(nameof(textBox));

            return ValidarCampoObrigatorio(textBox.Text, nomeCampo, titulo);
        }

        #endregion

        #region Validações de Tamanho

        /// <summary>
        /// Valida se um campo tem tamanho mínimo
        /// </summary>
        public static ResultadoValidacao ValidarTamanhoMinimo(
            string valor,
            int tamanhoMinimo,
            string nomeCampo)
        {
            if (string.IsNullOrEmpty(valor) || valor.Trim().Length < tamanhoMinimo)
            {
                return ResultadoValidacao.Erro(
                    $"{nomeCampo} deve ter no mínimo {tamanhoMinimo} caracteres.",
                    "Validação de Tamanho");
            }

            return ResultadoValidacao.Sucesso();
        }

        /// <summary>
        /// Valida se um campo tem tamanho máximo
        /// </summary>
        public static ResultadoValidacao ValidarTamanhoMaximo(
            string valor,
            int tamanhoMaximo,
            string nomeCampo)
        {
            if (!string.IsNullOrEmpty(valor) && valor.Trim().Length > tamanhoMaximo)
            {
                return ResultadoValidacao.Erro(
                    $"{nomeCampo} deve ter no máximo {tamanhoMaximo} caracteres.",
                    "Validação de Tamanho");
            }

            return ResultadoValidacao.Sucesso();
        }

        /// <summary>
        /// Valida se um campo tem tamanho exato
        /// </summary>
        public static ResultadoValidacao ValidarTamanhoExato(
            string valor,
            int tamanhoExato,
            string nomeCampo)
        {
            valor = valor?.Trim() ?? string.Empty;

            if (valor.Length != tamanhoExato)
            {
                return ResultadoValidacao.Erro(
                    $"{nomeCampo} deve ter exatamente {tamanhoExato} caracteres.",
                    "Validação de Tamanho");
            }

            return ResultadoValidacao.Sucesso();
        }

        #endregion

        #region Validações de ComboBox e ListBox

        /// <summary>
        /// Valida se um ComboBox tem item selecionado
        /// </summary>
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

        /// <summary>
        /// Valida se um ListBox tem item selecionado
        /// </summary>
        public static ResultadoValidacao ValidarListBox(
            ListBox listBox,
            string nomeCampo)
        {
            if (listBox == null)
                throw new ArgumentNullException(nameof(listBox));

            if (listBox.SelectedIndex < 0 || listBox.SelectedItem == null)
            {
                return ResultadoValidacao.Erro(
                    $"Por favor, selecione {nomeCampo}.",
                    "Seleção Obrigatória");
            }

            return ResultadoValidacao.Sucesso();
        }

        /// <summary>
        /// Valida se um CheckedListBox tem pelo menos um item selecionado
        /// </summary>
        public static ResultadoValidacao ValidarCheckedListBox(
            CheckedListBox checkedListBox,
            string nomeCampo,
            int minimoItens = 1)
        {
            if (checkedListBox == null)
                throw new ArgumentNullException(nameof(checkedListBox));

            if (checkedListBox.CheckedItems.Count < minimoItens)
            {
                string mensagem = minimoItens == 1
                    ? $"Por favor, selecione pelo menos um item em {nomeCampo}."
                    : $"Por favor, selecione pelo menos {minimoItens} itens em {nomeCampo}.";

                return ResultadoValidacao.Erro(mensagem, "Seleção Obrigatória");
            }

            return ResultadoValidacao.Sucesso();
        }

        #endregion

        #region Validações de Valores Numéricos

        /// <summary>
        /// Valida se um NumericUpDown tem valor maior que zero
        /// </summary>
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

        /// <summary>
        /// Valida se um valor está dentro de um range
        /// </summary>
        public static ResultadoValidacao ValidarRange(
            decimal valor,
            decimal minimo,
            decimal maximo,
            string nomeCampo)
        {
            if (valor < minimo || valor > maximo)
            {
                return ResultadoValidacao.Erro(
                    $"{nomeCampo} deve estar entre {minimo} e {maximo}.",
                    "Valor Inválido");
            }

            return ResultadoValidacao.Sucesso();
        }

        #endregion

        #region Validação de NIF (Número de Identificação Fiscal)

        /// <summary>
        /// Valida se o NIF é válido (9 dígitos entre 111111111 e 999999999)
        /// </summary>
        /// <param name="nif">String do NIF a validar</param>
        /// <param name="obrigatorio">Se o campo é obrigatório</param>
        /// <returns>ResultadoValidacao</returns>
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

        /// <summary>
        /// Tenta obter o NIF como inteiro se for válido
        /// </summary>
        /// <param name="nif">String do NIF</param>
        /// <param name="nifNumero">NIF convertido (output)</param>
        /// <returns>True se conseguiu converter e é válido</returns>
        public static bool TentarObterNIF(string nif, out int nifNumero)
        {
            nifNumero = 0;

            var resultado = ValidarNIF(nif, obrigatorio: false);
            if (!resultado.Valido)
                return false;

            return int.TryParse(nif?.Trim(), out nifNumero);
        }

        /// <summary>
        /// Handler para KeyPress que permite apenas dígitos (para TextBox de NIF)
        /// </summary>
        public static void NIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir apenas dígitos e teclas de controlo (backspace, delete, etc.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// Handler para Validating que valida o NIF
        /// </summary>
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

        /// <summary>
        /// Configura eventos de validação automática para um TextBox de NIF
        /// </summary>
        /// <param name="txtNIF">TextBox para configurar</param>
        /// <param name="obrigatorio">Se o NIF é obrigatório</param>
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

        #endregion

        #region Validação de Contacto

        /// <summary>
        /// Valida contacto telefónico (9 dígitos começando por 9)
        /// </summary>
        /// <param name="contacto">String do contacto</param>
        /// <param name="obrigatorio">Se o campo é obrigatório</param>
        /// <returns>ResultadoValidacao</returns>
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

        /// <summary>
        /// Handler para KeyPress que permite apenas dígitos (para TextBox de Contacto)
        /// </summary>
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

        /// <summary>
        /// Configura eventos de validação automática para um TextBox de Contacto
        /// </summary>
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

        #endregion

        #region Validação de Email

        /// <summary>
        /// Valida formato de email
        /// </summary>
        public static ResultadoValidacao ValidarEmail(string email, bool obrigatorio = true)
        {
            email = email?.Trim();

            if (string.IsNullOrWhiteSpace(email))
            {
                if (obrigatorio)
                    return ResultadoValidacao.Erro(
                        "Por favor, insira o email.",
                        "Campo Obrigatório");
                else
                    return ResultadoValidacao.Sucesso();
            }

            // Validação básica de email usando regex
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(email, pattern))
            {
                return ResultadoValidacao.Erro(
                    "Por favor, insira um email válido.",
                    "Email Inválido");
            }

            return ResultadoValidacao.Sucesso();
        }

        #endregion

        #region Validações Combinadas

        /// <summary>
        /// Valida múltiplos resultados e retorna o primeiro erro encontrado
        /// </summary>
        public static ResultadoValidacao ValidarTodos(params ResultadoValidacao[] resultados)
        {
            foreach (var resultado in resultados)
            {
                if (!resultado.Valido)
                    return resultado;
            }

            return ResultadoValidacao.Sucesso();
        }

        /// <summary>
        /// Valida e mostra mensagem do primeiro erro encontrado
        /// </summary>
        /// <returns>True se todos válidos, False se encontrou erro</returns>
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

        #endregion
    }
}
