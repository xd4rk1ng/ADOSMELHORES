using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES.Validacoes
{
    // Validaçoes para operações com DateTime e DateTimePicker
    public static class DateTimeHelper
    {
       
        public static DateTime Clamp(DateTime value, DateTime min, DateTime max)
        {
            if (value < min) return min;
            if (value > max) return max;
            return value;
        }

        
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

        
        //public static ResultadoValidacao ValidarIntervalo(
        //    DateTime data,
        //    DateTime dataMinima,
        //    DateTime dataMaxima,
        //    string nomeCampo = "Data")
        //{
        //    if (data < dataMinima || data > dataMaxima)
        //    {
        //        return ResultadoValidacao.Erro(
        //            $"{nomeCampo} deve estar entre {dataMinima:dd/MM/yyyy} e {dataMaxima:dd/MM/yyyy}.",
        //            "Data Inválida");
        //    }

        //    return ResultadoValidacao.Sucesso();
        //}

        ///// <summary>
        ///// Valida se a data de início é anterior à data de fim
        ///// </summary>
        //public static ResultadoValidacao ValidarOrdemDatas(
        //    DateTime dataInicio,
        //    DateTime dataFim,
        //    string nomeCampoInicio = "Data de início",
        //    string nomeCampoFim = "Data de fim")
        //{
        //    if (dataInicio >= dataFim)
        //    {
        //        return ResultadoValidacao.Erro(
        //            $"{nomeCampoInicio} deve ser anterior a {nomeCampoFim}.",
        //            "Datas Inválidas");
        //    }

        //    return ResultadoValidacao.Sucesso();
        //}

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

        ///// <summary>
        ///// Valida se uma data não está no futuro
        ///// </summary>
        //public static ResultadoValidacao ValidarDataPassada(
        //    DateTime data,
        //    DateTime? dataReferencia = null,
        //    string nomeCampo = "Data")
        //{
        //    DateTime referencia = dataReferencia ?? DateTime.Now;

        //    if (data.Date > referencia.Date)
        //    {
        //        return ResultadoValidacao.Erro(
        //            $"{nomeCampo} não pode estar no futuro.",
        //            "Data Inválida");
        //    }

        //    return ResultadoValidacao.Sucesso();
        //}

        // Conta os dias úteis (segunda a sexta) entre duas datas inclusivas.
        // Não considera feriados.
        public static int CountBusinessDays(DateTime start, DateTime end)
        {
            if (end < start) return 0;

            int count = 0;
            for (var date = start.Date; date <= end.Date; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday &&
                    date.DayOfWeek != DayOfWeek.Sunday)
                {
                    count++;
                }
            }
            return count;
        }

        // Conta os dias úteis do mês de uma data (do 1º ao último dia do mês).
        public static int CountBusinessDaysInMonth(DateTime anyDateInMonth)
        {
            var first = new DateTime(anyDateInMonth.Year, anyDateInMonth.Month, 1);
            var last = first.AddMonths(1).AddDays(-1);
            return CountBusinessDays(first, last);
        }
    }
}