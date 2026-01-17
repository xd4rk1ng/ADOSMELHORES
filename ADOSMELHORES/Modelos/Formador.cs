using System;

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
            DateTime dataNascimento,
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
                  dataFimRegistoCrim,
                  dataNascimento
            )
        {
            AreaLeciona = areaLeciona;
            Disponibilidade = disponibilidade;
            ValorHora = valorHora;
        }

        public decimal CalcularValorFormacao(DateTime dataInicio, DateTime dataFim)
        {
            if (dataFim < dataInicio)
            {
                throw new ArgumentException("Data final não pode ser anterior à data inicial");
            }

            int dias = (dataFim - dataInicio).Days + 1;
            int totalHoras = dias * 6; // 6 horas por dia conforme enunciado
            return totalHoras * ValorHora;
        }

        public override decimal CalcularCustoMensal()
        {
            // Formadores podem ter salário base + horas extras
            // Para simplificar, assumimos salário base mensal
            return SalarioBase;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - {AreaLeciona} - {Disponibilidade} - {ValorHora:C}/hora";
        }
    }
}
