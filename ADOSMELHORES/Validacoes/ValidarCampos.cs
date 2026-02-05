using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*
namespace ADOSMELHORES.Validacoes
{
    
    public static class ValidarCampos
    {
        // VALIDACOES DE CAMPOS DE TEXTO

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



        // Validação de ComboBox e ListBox

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

       
        // Valida se um ListBox tem item selecionado

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

        // Valida se um CheckedListBox tem pelo menos um item selecionado

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



        // Validação de Valores Numéricos
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

 
        // Valida se um valor está dentro de um range

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



        // Validação de Datas
        // Valida se uma data não está no passado

        public static ResultadoValidacao ValidarDataFutura(
            DateTime data,
            string nomeCampo,
            bool incluirHoje = true)
        {
            DateTime hoje = DateTime.Today;
            DateTime comparacao = incluirHoje ? hoje : hoje.AddDays(1);

            if (data < comparacao)
            {
                string mensagem = incluirHoje
                    ? $"{nomeCampo} não pode ser anterior a hoje."
                    : $"{nomeCampo} deve ser posterior a hoje.";

                return ResultadoValidacao.Erro(mensagem, "Data Inválida");
            }

            return ResultadoValidacao.Sucesso();
        }


        // Valida se uma data está dentro de um período
        public static ResultadoValidacao ValidarPeriodoData(
            DateTime data,
            DateTime dataInicio,
            DateTime dataFim,
            string nomeCampo)
        {
            if (data < dataInicio || data > dataFim)
            {
                return ResultadoValidacao.Erro(
                    $"{nomeCampo} deve estar entre {dataInicio:dd/MM/yyyy} e {dataFim:dd/MM/yyyy}.",
                    "Data Inválida");
            }

            return ResultadoValidacao.Sucesso();
        }


        // Validação de Contacto telemovel 
     
        public static ResultadoValidacao ValidarContacto(
            string contacto,
            bool obrigatorio = true)
        {
            contacto = contacto?.Trim() ?? string.Empty;

            if (string.IsNullOrEmpty(contacto))
            {
                if (obrigatorio)
                    return ResultadoValidacao.Erro("Por favor, insira o contacto.", "Campo Obrigatório");
                else
                    return ResultadoValidacao.Sucesso();
            }

            // Remove espaços e caracteres especiais para validação
            string contactoLimpo = contacto.Replace(" ", "").Replace("-", "").Replace("+", "");

            // Verifica se tem apenas dígitos
            if (!contactoLimpo.All(char.IsDigit))
            {
                return ResultadoValidacao.Erro(
                    "Contacto deve conter apenas números.",
                    "Entrada Inválida");
            }

            // Valida tamanho (9 dígitos para PT)
            if (contactoLimpo.Length != 9 && contactoLimpo.Length != 12) // 9 local ou 12 com código país
            {
                return ResultadoValidacao.Erro(
                    "Contacto deve ter 9 dígitos.",
                    "Entrada Inválida");
            }

            return ResultadoValidacao.Sucesso();
        }

        // Validação do NIF
        // Constantes para validação do NIF
        private const int NIF_TAMANHO = 9;
        private const int NIF_MIN = 111111111;
        private const int NIF_MAX = 999999999;
        /// Valida se o NIF é válido (9 dígitos entre 111111111 e 999999999)    
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
                    $"NIF inválido! O NIF deve ter {NIF_TAMANHO} dígitos (entre {NIF_MIN} e {NIF_MAX}).",
                    "NIF Inválido");
            }

            // Verificar se são todos dígitos
            if (!nif.All(char.IsDigit))
            {
                return ResultadoValidacao.Erro(
                    $"NIF inválido! O NIF deve ter {NIF_TAMANHO} dígitos (entre {NIF_MIN} e {NIF_MAX}).",
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
                $"NIF inválido! O NIF deve ter {NIF_TAMANHO} dígitos (entre {NIF_MIN} e {NIF_MAX}).",
                "NIF Inválido");
        }

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

        /// Configura eventos de validação automática para um TextBox de NIF
        /// </summary>
        /// <param name="txtNIF">TextBox para configurar</param>
        /// <param name="obrigatorio">Se o NIF é obrigatório</param>
        public static void ConfigurarTextBoxNIF(System.Windows.Forms.TextBox txtNIF, bool obrigatorio = true)
        {
            if (txtNIF == null)
                throw new ArgumentNullException(nameof(txtNIF));

            // Configurar MaxLength
            txtNIF.MaxLength = NIF_TAMANHO;
                       

            // Subscrever evento Validating
            txtNIF.Validating -= (s, e) => NIF_Validating(s, e, obrigatorio);
            txtNIF.Validating += (s, e) => NIF_Validating(s, e, obrigatorio);
        }





        /// Valida e mostra mensagem do primeiro erro encontrado
        /// </summary>
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

    */
