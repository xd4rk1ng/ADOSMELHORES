using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES.Validacoes
{
    /// <summary>
    /// Helper para operações com DateTime e DateTimePicker
    /// </summary>
    public static class DateTimeHelper
    {
        /// <summary>
        /// Limita um valor DateTime dentro de um range mínimo e máximo
        /// </summary>
        /// <param name="value">Valor a limitar</param>
        /// <param name="min">Valor mínimo</param>
        /// <param name="max">Valor máximo</param>
        /// <returns>Valor limitado dentro do range</returns>
        public static DateTime Clamp(DateTime value, DateTime min, DateTime max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        /// <summary>
        /// Define o valor de um DateTimePicker de forma segura, fazendo clamp se necessário
        /// </summary>
        /// <param name="dateTimePicker">DateTimePicker a configurar</param>
        /// <param name="value">Valor desejado</param>
        /// <returns>True se conseguiu definir o valor exato, False se usou valor ajustado</returns>
        public static bool DefinirValorSeguro(DateTimePicker dateTimePicker, DateTime value)
        {
            if (dateTimePicker == null)
                throw new ArgumentNullException(nameof(dateTimePicker));

            try
            {
                DateTime safeValue = Clamp(value, dateTimePicker.MinDate, dateTimePicker.MaxDate);

                try
                {
                    dateTimePicker.Value = safeValue;
                    return value == safeValue; // Retorna true apenas se não precisou ajustar
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Se ainda assim falhar, usar MinDate
                    dateTimePicker.Value = dateTimePicker.MinDate;
                    return false;
                }
            }
            catch
            {
                try
                {
                    dateTimePicker.Value = dateTimePicker.MinDate;
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Valida se uma data está dentro de um intervalo
        /// </summary>
        public static ResultadoValidacao ValidarIntervalo(
            DateTime data,
            DateTime dataMinima,
            DateTime dataMaxima,
            string nomeCampo = "Data")
        {
            if (data < dataMinima || data > dataMaxima)
            {
                return ResultadoValidacao.Erro(
                    $"{nomeCampo} deve estar entre {dataMinima:dd/MM/yyyy} e {dataMaxima:dd/MM/yyyy}.",
                    "Data Inválida");
            }

            return ResultadoValidacao.Sucesso();
        }

        /// <summary>
        /// Valida se a data de início é anterior à data de fim
        /// </summary>
        public static ResultadoValidacao ValidarOrdemDatas(
            DateTime dataInicio,
            DateTime dataFim,
            string nomeCampoInicio = "Data de início",
            string nomeCampoFim = "Data de fim")
        {
            if (dataInicio >= dataFim)
            {
                return ResultadoValidacao.Erro(
                    $"{nomeCampoInicio} deve ser anterior a {nomeCampoFim}.",
                    "Datas Inválidas");
            }

            return ResultadoValidacao.Sucesso();
        }

        /// <summary>
        /// Valida se uma data não está no passado
        /// </summary>
        public static ResultadoValidacao ValidarDataFutura(
            DateTime data,
            DateTime? dataReferencia = null,
            string nomeCampo = "Data")
        {
            DateTime referencia = dataReferencia ?? DateTime.Now;

            if (data.Date < referencia.Date)
            {
                return ResultadoValidacao.Erro(
                    $"{nomeCampo} não pode estar no passado.",
                    "Data Inválida");
            }

            return ResultadoValidacao.Sucesso();
        }

        /// <summary>
        /// Valida se uma data não está no futuro
        /// </summary>
        public static ResultadoValidacao ValidarDataPassada(
            DateTime data,
            DateTime? dataReferencia = null,
            string nomeCampo = "Data")
        {
            DateTime referencia = dataReferencia ?? DateTime.Now;

            if (data.Date > referencia.Date)
            {
                return ResultadoValidacao.Erro(
                    $"{nomeCampo} não pode estar no futuro.",
                    "Data Inválida");
            }

            return ResultadoValidacao.Sucesso();
        }
    }
}