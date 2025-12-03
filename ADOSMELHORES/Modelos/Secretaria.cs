using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES.Modelos
{
    internal class Secretaria : Funcionário
    {
        //atributos pedidos na ficha
        public Diretor DiretorReporta { get; set; }
        public string Area { get; set; }

        //atributos adicionais
        public List<string> Idiomas { get; set; }

        public Secretaria() 
        {
            Idiomas = new List<string>();
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
    }
}
