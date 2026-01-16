using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ADOSMELHORES.Modelos
{
    public class Empresa
    {
        private readonly List<Funcionario> funcionarios;

        public string Nome { get; set; }
        public DateTime DataSimulada { get; set; }

        // Expor apenas leitura
        public IReadOnlyList<Funcionario> Funcionarios => funcionarios.AsReadOnly();

        public Empresa(string nome)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            funcionarios = new List<Funcionario>();
        }

        public int ObterProximoID()
        {
            if (funcionarios.Count == 0) return 1;
            return funcionarios.Max(f => f.Id) + 1;
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            if (funcionario == null) throw new ArgumentNullException(nameof(funcionario));
            funcionarios.Add(funcionario);
        }

        // Implementação específica para Formador (comodidade)
        public void AdicionarFuncionario(Formador novoFormador)
        {
            AdicionarFuncionario((Funcionario)novoFormador);
        }

        public void RemoverFuncionario(Funcionario funcionario)
        {
            if (funcionario == null) throw new ArgumentNullException(nameof(funcionario));
            funcionarios.Remove(funcionario);
        }

        public void RemoverFuncionario(Formador formadorSelecionado)
        {
            RemoverFuncionario((Funcionario)formadorSelecionado);
        }

        // Novos métodos para gerir formadores eficientemente

        public List<Formador> ObterFormadores()
        {
            return funcionarios.OfType<Formador>().ToList();
        }

        public Formador BuscarFormadorPorId(int id)
        {
            return funcionarios.OfType<Formador>().FirstOrDefault(f => f.Id == id);
        }

        public List<Formador> FiltrarFormadoresPorDisponibilidade(Disponibilidade disponibilidade)
        {
            return funcionarios.OfType<Formador>()
                .Where(f => f.Disponibilidade == disponibilidade)
                .ToList();
        }

        public List<Formador> FiltrarFormadoresPorArea(string areaLeciona)
        {
            if (string.IsNullOrWhiteSpace(areaLeciona)) return new List<Formador>();
            return funcionarios.OfType<Formador>()
                .Where(f => string.Equals(f.AreaLeciona, areaLeciona.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public bool RemoverFormadorPorId(int id)
        {
            var f = BuscarFormadorPorId(id);
            if (f == null) return false;
            funcionarios.Remove(f);
            return true;
        }

        public void AtualizarFormador(Formador atualizado)
        {
            if (atualizado == null) throw new ArgumentNullException(nameof(atualizado));
            var existente = BuscarFormadorPorId(atualizado.Id);
            if (existente == null) throw new InvalidOperationException("Formador não encontrado.");
            var idx = funcionarios.IndexOf(existente);
            funcionarios[idx] = atualizado;
        }

        public List<Funcionario> ObterFuncionariosContratoValido(DateTime data)
        {
            return funcionarios.Where(f => f.ContratoValido(data)).ToList();
        }

        public List<Funcionario> ObterFuncionariosRegistoCriminalExpirado(DateTime data)
        {
            return funcionarios.Where(f => f.RegistoCriminalExpirado(data)).ToList();
        }

        public decimal CalcularDespesaMensal()
        {
            return funcionarios.Sum(f => f.CalcularCustoMensal());
        }

        // Exemplo simples de exportar formadores para CSV (opcional)
        public void ExportarFormadoresParaCSV(string caminhoFicheiro)
        {
            var lines = new List<string> { "Id;Nome;Area;Disponibilidade;ValorHora;Contacto;DataFimRegistoCrim" };
            foreach (var f in ObterFormadores())
            {
                lines.Add(string.Join(";",
                    f.Id,
                    EscapeCsv(f.Nome),
                    EscapeCsv(f.AreaLeciona),
                    f.Disponibilidade,
                    f.ValorHora,
                    EscapeCsv(f.Contacto),
                    f.DataFimRegistoCrim.ToString("yyyy-MM-dd")
                ));
            }
            File.WriteAllLines(caminhoFicheiro, lines);
        }

        private string EscapeCsv(string s) => s?.Replace(";", ",") ?? string.Empty;
    }
}

