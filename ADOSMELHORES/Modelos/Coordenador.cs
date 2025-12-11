using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES.Modelos
{
    internal class Coordenador : Funcionario
    {
        public List<Formador> FormadoresAssociados { get; set; }
        public string AreaCoordenacao { get; set; }

        //construtor com parametros
        public Coordenador(int id,
                int nif,
                string nome,
                string morada,
                string contacto,
                decimal salarioBase,
                DateTime dataIniContrato,
                DateTime dataFimContrato,
                DateTime dataFimRegistoCrim,
                DateTime dataNascimento,

                string areaCoordenacao)
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

            AreaCoordenacao = areaCoordenacao;
            FormadoresAssociados = new List<Formador>();
        }

        public override decimal CustoMensal()
        {
            throw new NotImplementedException();
        }
        public void AdicionarFormador(Formador formador)
        {
            if (!FormadoresAssociados.Contains(formador))
            {
                FormadoresAssociados.Add(formador);
            }
        }
        public void RemoverFormador(Formador formador)
        {
            FormadoresAssociados.Remove(formador);
        }
        //public override decimal CalcularCustoMensal()
        //{
        //    return SalarioBase;
        //}
        public int NumeroFormadores => FormadoresAssociados.Count;

        public override string ToString()
        {
            return $"{base.ToString()} - {AreaCoordenacao} - {NumeroFormadores} formadores";
        }
    }
}
