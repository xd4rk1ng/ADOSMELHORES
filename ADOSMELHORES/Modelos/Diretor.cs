using System;

namespace ADOSMELHORES.Modelos
{
    public class Diretor : Funcionario
    {
        public bool IsencaoHorario { get; set; }
        public decimal BonusMensal { get; set; }
        public bool CarroEmpresa { get; set; }

        public Diretor(
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
            bool isencaoHorario,
            decimal bonusMensal,
            bool carroEmpresa)
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
            IsencaoHorario = isencaoHorario;
            BonusMensal = bonusMensal;
            CarroEmpresa = carroEmpresa;
        }

        public override decimal CalcularCustoMensal()
        {
            return SalarioBase + BonusMensal;
        }

        public override string ToString()
        {
            return $"{base.ToString()} - Diretor - Bónus: {BonusMensal:C} - Carro: {(CarroEmpresa ? "Sim" : "Não")}";
        }
    }
}
