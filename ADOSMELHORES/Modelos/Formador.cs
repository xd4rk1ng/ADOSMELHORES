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
            // Normalizar para datas (ignorar componente hora) e garantir inclusão do dia final
            var inicio = dataInicio.Date;
            var fim = dataFim.Date;

            if (fim < inicio)
            {
                throw new ArgumentException("Data final não pode ser anterior à data inicial");
            }

            int dias = (fim - inicio).Days + 1; // inclui o dia final
            int totalHoras = dias * 6; // 6 horas por dia conforme enunciado
            return totalHoras * ValorHora;
        }

        public override decimal CalcularCustoMensal()
        {
           
            // Usamos aqui uma aproximação: 6 horas/dia * 20 dias úteis * ValorHora.
            int diasUteisMensais = 20;
            int horasPorDia = 6;
            return ValorHora * horasPorDia * diasUteisMensais;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - {AreaLeciona} - {Disponibilidade} - {ValorHora:C}/hora";
        }
    }
}
