using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ADOSMELHORES.Modelos
{
    public class Empresa
    {
        public string Nome { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public DateTime DataSimulada { get; set; }

        private List<Funcionario> funcionarios; // Adicione este campo privado à classe Empresa para corrigir o erro CS0103

        public Empresa(string nome)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            funcionarios = new List<Funcionario>();
        }

        public IReadOnlyList<Funcionario> ObterFuncionarios() => funcionarios.AsReadOnly();

        // Retorna lista concreta de coordenadores (clone da lista interna)
        public List<Coordenador> ObterCoordenadores()
        {
            return funcionarios.OfType<Coordenador>().ToList();
        }

        public void AdicionarFuncionario(Funcionario f)
        {
            if (f == null) throw new ArgumentNullException(nameof(f));
            if (funcionarios.Any(x => x.Id == f.Id))
                throw new InvalidOperationException($"Já existe um funcionário com Id {f.Id}.");

            funcionarios.Add(f);
        }

        public void RemoverFuncionario(Funcionario f)
        {
            if (f == null) throw new ArgumentNullException(nameof(f));
            funcionarios.Remove(f);
        }

        // Gera próximo ID simples (1 + max) — tolera lista vazia
        public int ObterProximoID()
        {
            if (!funcionarios.Any()) return 1;
            return funcionarios.Max(f => f.Id) + 1;
        }

        // Opções de procura/filtragem úteis
        public Coordenador ObterCoordenadorPorId(int id)
        {
            return funcionarios.OfType<Coordenador>().FirstOrDefault(c => c.Id == id);
        }

        // Métodos de persistência não implementados aqui (placeholder)
        // public void CarregarDeArquivo(...) { ... }
        // public void GuardarEmArquivo(...) { ... }
    }
}
