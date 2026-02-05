using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES.Validacoes
{
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
        /// <returns>True se conseguiu definir o valor, False se usou valor padrão</returns>
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
                    return true;
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

    }
