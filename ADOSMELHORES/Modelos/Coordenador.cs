using System;
using System.Collections.Generic;

namespace ADOSMELHORES.Modelos
{
    public class Coordenador : Funcionario
    {
        public List<Formador> FormadoresAssociados { get; set; }
        public string AreaCoordenacao { get; set; }
        public int NumeroFormadores => FormadoresAssociados?.Count ?? 0;

        // Construtor conforme assinatura fornecida
        public Coordenador(
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
                  dataNascimento)
        {
            AreaCoordenacao = areaCoordenacao;
            FormadoresAssociados = new List<Formador>();
        }

        public void AdicionarFormador(Formador formador)
        {
            if (formador == null) throw new ArgumentNullException(nameof(formador));
            if (FormadoresAssociados == null) FormadoresAssociados = new List<Formador>();
            if (!FormadoresAssociados.Contains(formador))
                FormadoresAssociados.Add(formador);
        }

        public void RemoverFormador(Formador formador)
        {
            if (formador == null) throw new ArgumentNullException(nameof(formador));
            FormadoresAssociados?.Remove(formador);
        }

        // Implementação simples: custo mensal como salário base (pode ser extendida)
        public override string ToString()
        {
            return $"{Nome} (NIF: {Nif}) - Área: {AreaCoordenacao}";
        }

        // Utilitários para lidar com sentinela DateTime.MaxValue usado noutros pontos do projeto
        public bool HasDataNascimento()
        {
            return DataNascimento != DateTime.MinValue && DataNascimento != DateTime.MaxValue;
        }

        // Retorna um valor seguro para utilizar em controls (clamp + fallback)
        public DateTime GetSafeDataNascimento(DateTime minAllowed, DateTime maxAllowed, DateTime fallback)
        {
            var d = DataNascimento;
            if (d < minAllowed || d > maxAllowed) return fallback;
            return d;
        }
    }
}
