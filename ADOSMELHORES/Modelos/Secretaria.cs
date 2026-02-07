using System;
using System.Collections.Generic;

namespace ADOSMELHORES.Modelos
{
    public class Secretaria : Funcionario
    {
        public Diretor DiretorReporta { get; set; }
        public string Area { get; set; }

        //atributos adicionais
        public List<string> IdiomasFalados { get; set; }

        public string IdiomasFaladosString
        {
            get
            {
                return IdiomasFalados != null && IdiomasFalados.Count > 0
                    ? string.Join(", ", IdiomasFalados)
                    : "Nenhum";
            }
        }

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
                  dataFimRegistoCrim
            )
        {
            Area = area;
            DiretorReporta = diretorReporta;
            Area = area;
            IdiomasFalados = new List<string>();
        }

        // Método para verificar se reporta a um diretor específico
        public bool ReportaAoDiretor(int idDiretor)
        {
            return DiretorReporta != null && DiretorReporta.Id == idDiretor;
        }

        public override string ToString()
        {
            string diretor = DiretorReporta != null ? DiretorReporta.Nome : "Não atribuído";
            return $"{base.ToString()} - {Area} - Reporta a: {diretor}";
        }

    }
}
