using System;
using ADOSMELHORES.Validacoes;

namespace ADOSMELHORES.Modelos
{
    public enum Disponibilidade
    {
        Laboral,
        PosLaboral,
        Ambas
    }

    public class Formador : Funcionario
    {
        public string AreaLeciona { get; set; }
        public Disponibilidade Disponibilidade { get; set; }
        public decimal ValorHora { get; set; }

        public Formador(
            int id,
            int nif,
            string nome,
            string morada,
            string contacto,
            decimal salarioBase,
            DateTime dataIniContrato,
            DateTime dataFimContrato,
            DateTime dataFimRegistoCrim,
            string areaLeciona,
            Disponibilidade disponibilidade,
            decimal valorHora)
            : base(
                  id,
                  nif,
                  nome,
                  morada,
                  contacto,
                  salarioBase,
                  dataIniContrato,
                  dataFimContrato,
                  dataFimRegistoCrim
            )
        {
            AreaLeciona = areaLeciona;
            Disponibilidade = disponibilidade;
            ValorHora = valorHora;
        }

        public decimal CalcularValorFormacao(DateTime dataInicio, DateTime dataFim)
        {
            // Normalizar para datas (ignorar componente hora)
            var inicio = dataInicio.Date;
            var fim = dataFim.Date;

            if (fim < inicio)
            {
                throw new ArgumentException("Data final não pode ser anterior à data inicial");
            }

            // Usar dias úteis em vez de todos os dias
            int diasUteis = DateTimeHelper.CountBusinessDays(inicio, fim);
            int totalHoras = diasUteis * 6; // 6 horas por dia
            return totalHoras * ValorHora;
        }

        // NOVO: calcula custo do formador para um mês/ano específico (dias úteis do mês)
        public decimal CalcularCustoMensal(int mes, int ano)
        {
            if (mes < 1 || mes > 12) throw new ArgumentOutOfRangeException(nameof(mes));
            if (ano < 1) throw new ArgumentOutOfRangeException(nameof(ano));

            var anyDateInMonth = new DateTime(ano, mes, 1);
            int diasUteisMes = DateTimeHelper.CountBusinessDaysInMonth(anyDateInMonth);
            int horasPorDia = 6;
            int totalHoras = diasUteisMes * horasPorDia;
            return ValorHora * totalHoras;
        }

        // Mantém o método existente para compatibilidade (usa DateTime.Now)
        public override decimal CalcularCustoMensal()
        {
            // Calcular com base nos dias úteis do mês atual
            var hoje = DateTime.Now.Date;
            int diasUteisMes = DateTimeHelper.CountBusinessDaysInMonth(hoje);
            int horasPorDia = 6;
            int totalHoras = diasUteisMes * horasPorDia;
            return ValorHora * totalHoras;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - {AreaLeciona} - {Disponibilidade} - {ValorHora:C}/hora";
        }
    }
}
