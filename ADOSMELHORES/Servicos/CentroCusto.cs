using System.Collections.Generic;
using System.Linq;
using ADOSMELHORES.Modelos;

namespace ADOSMELHORES.Servicos
{
    public class CentroCusto
    {
        // Para uso interno, segura membros correspondentes ao dado cargo "T"
        private List<Funcionario> _membros = new List<Funcionario>();

        public CentroCusto()
        {}

        // Para uso externo
        public IReadOnlyCollection<Funcionario> Membros => _membros;

        // Adiciona funcionario, quando este e criado ou reativado
        public void Adicionar(Funcionario f)
        {
            _membros.Add(f);
        }

        // Remove funcionario, quando este e desativado
        public void Remover(Funcionario f)
        {
            _membros.Remove(f);
        }

        // Realiza os calculos mensais para o agregado de funcionarios correspondente ao cargo
        public decimal CalcularCustoMensal()
        {
            return _membros.Sum(f => f.CustoMensal());
        }
    }
}
