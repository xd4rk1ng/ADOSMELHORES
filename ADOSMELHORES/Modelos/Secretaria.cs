using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES.Modelos
{
    public class Secretaria : Funcionario
    {
        //atributos pedidos na ficha
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
            DateTime dataFimContrato,
            DateTime dataIniContrato,
            DateTime dataFimRegistoCrim,
            DateTime dataNascimento,
            Diretor diretorReporta,
            string area
            //List<string> idiomas
            ) : base(
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
            //Idiomas = new List<string>();
            DiretorReporta = diretorReporta;
            Area = area;
            IdiomasFalados = new List<string>();
        }

        // Método para verificar se reporta a um diretor específico
        public bool ReportaAoDiretor(int idDiretor)
        {
            return DiretorReporta != null && DiretorReporta.Id == idDiretor;
        }

        // Método para obter informações de contato do diretor
        public string ObterContatoDiretor()
        {
            return DiretorReporta != null ?
                   $"Diretor: {DiretorReporta.Nome} - Contacto: {DiretorReporta.Contacto}" :
                   "Não reporta a nenhum diretor";
        }

        //NOVO: Método ToString para exibir no CheckedListBox
        public override string ToString()
        {
            return $"{Nome} - {Area}";
        }
    }
}
