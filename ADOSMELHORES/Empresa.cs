using ADOSMELHORES.Servicos;
using ADOSMELHORES.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES
{
    public class Empresa
    {
        // Para uso interno, estes atributos permitem modificacoes vindas da propria classe Empresa
        // -    _centrosCusto e um dicionario, ou seja, neste caso, usado para mapear cada subclasse de Funcionario a um CentroCusto proprio
        //      isto permite fazer analises financeiras ao agregado. Por exemplo, teremos CentroCusto para Formador, outro para Coordenador.
        private Dictionary<Type, CentroCusto> _centrosCusto;
        private List<Funcionario> _colaboradores;
        private string _nome;

        // Para uso externo, mas exclui metodos que modificariam os conteudos. Forca o uso dos metodos da empresa para fazer alteracoes, e apenas permite operacoes do tipo "read" ao atributo em si.
        public IReadOnlyDictionary<Type, CentroCusto> CentrosCustos { get => (IReadOnlyDictionary<Type, CentroCusto>)_centrosCusto; }
        public IReadOnlyCollection<Funcionario> Colaboradores { get => (IReadOnlyCollection<Funcionario>)_colaboradores;}
        public string Nome { get => _nome; }

        public Empresa(Dictionary<Type, CentroCusto> centrosCustos, List<Funcionario> colaboradores, string nome)
        {
            // lanca excecao se argumentos forem null
            _colaboradores = colaboradores ?? throw new ArgumentNullException(nameof(colaboradores));
            _centrosCusto = centrosCustos ?? throw new ArgumentNullException(nameof(centrosCustos));
            _nome = nome ?? throw new ArgumentNullException(nameof(nome));
        }

        #region Gestao de Funcionarios
        // Retorna o funcionario se o encontrar na lista de colaboradores, usando o Nif.
        //  -   isto e usado para prevenir dupla insercao de funcionario, caso este ja tenha trabalhado na empresa, pois os ids serao autogerados
        private Funcionario FuncionarioExiste(int nif)
        {
            return _colaboradores.FirstOrDefault(f => f.Nif == nif);
        }

        //  Para uso durante registo de funcionario, precisa verificar Nif, se ja existe nos registos da empresa.
        // Se sim, evita duplicacao da pessoa, e entende-se pessoa pretende ser reativa na empresa, mantendo a continuidade do
        // historico.
        // Adiciona Funcionario, lanca excecao se f for null
        //  -   por questoes de historico de custos e evitar duplicacao na reativacao de Funcionario's, nao implementamos este metodo
        //  -   public void RemoverFuncionario(Funcionario f){}
        public void AdicionarFuncionario(Funcionario func)
        {
            if(func == null)
                throw new ArgumentNullException(nameof(func));

            if(FuncionarioExiste(func.Nif) != null)
                throw new ArgumentException("Funcionário com NIF idêntico já existente.");

            _colaboradores.Add(func);
            _centrosCusto[func.GetType()].Adicionar(func);
        }

        // Retorna o funcionario correspondente ao id ou null se nao encontrar
        public Funcionario EncontraFuncionarioId(int id)
        {
            return _colaboradores.FirstOrDefault(f => f.Id == id);
        }

        // Retorna colecao de funcionarios com nomes correspondentes ou null se nao encontrar
        public ICollection<Funcionario> EncontraFuncionariosNome(string nome)
        {
            return _colaboradores.Where(f =>  f.Nome == nome).ToList();
        }

        // Retorna colecao de funcionarios correspondestes ao tipoFuncionario (Diretor, Coordenador...)
        public ICollection<Type> EncontraFuncionariosTipo<Type>()
        {
            return _colaboradores.OfType<Type>().ToList();
        }

        // Ativa funcionario, do ponto de vista que este e recontratado
        public void AtivarFuncionario(int id)
        {
            var f = EncontraFuncionarioId(id);
            f.Ativo = true;
        }

        // Desativa funcionario, do ponto de vista que este e recontratado

        public void DesativarFuncionario(int id)
        {
            var f = EncontraFuncionarioId(id);
            f.Ativo = false;
        }
        #endregion
        #region Gestao de Custos

        // Retorna a soma de todos os centros de custo
        public decimal ObterCustoMensalTotal()
        {
            return _centrosCusto.Sum(cc => cc.Value.CalcularCustoMensal());
        }

        // TODO: Adicionar mais metodos aqui

        #endregion
    }
}
