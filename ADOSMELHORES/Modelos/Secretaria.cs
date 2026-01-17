using System;

namespace ADOSMELHORES.Modelos
{
    public class Secretaria : Funcionario
    {
        public Diretor DiretorReporta { get; set; }
        public string Area { get; set; }

        public Secretaria(
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
            string area,
            Diretor diretorReporta = null)
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
            Area = area;
            DiretorReporta = diretorReporta;
        }

        public override string ToString()
        {
            string diretor = DiretorReporta != null ? DiretorReporta.Nome : "Não atribuído";
            return $"{base.ToString()} - {Area} - Reporta a: {diretor}";
        }
    }
}
