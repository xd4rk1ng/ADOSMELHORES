using ADOSMELHORES.Modelos.Despesas;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ADOSMELHORES.Modelos
{
    public class Empresa
    {
        private readonly List<Funcionario> funcionarios;

        // ⚠️ TEMPORÁRIO - Gestor de despesas em memória
        // 🔄 MIGRAÇÃO BD: Manter esta propriedade, mas o GestorDespesas buscará do BD
        private GestorDespesas gestorDespesas;

        public string Nome { get; set; }
        public DateTime DataSimulada { get; set; }

        // Expor apenas leitura
        public IReadOnlyList<Funcionario> Funcionarios => funcionarios.AsReadOnly();

        // Propriedade para acessar o gestor de despesas
        public GestorDespesas GestorDespesas => gestorDespesas;

        public Empresa(string nome)
        {
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            funcionarios = new List<Funcionario>();
            DataSimulada = DateTime.Now;

            // ⚠️ TEMPORÁRIO - Inicializa gestor em memória
            // 🔄 MIGRAÇÃO BD: Continuar inicializando, mas dados virão do BD
            gestorDespesas = new GestorDespesas(this);
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

        // ===== Métodos para gerir Formadores =====
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

        // ===== Métodos para gerir Diretores =====
        public List<Diretor> ObterDiretores()
        {
            return funcionarios.OfType<Diretor>().ToList();
        }

        public List<Coordenador> ObterCoordenadores()
        {
            return funcionarios.OfType<Coordenador>().ToList();
        }

        public Diretor BuscarDiretorPorId(int id)
        {
            return funcionarios.OfType<Diretor>().FirstOrDefault(d => d.Id == id);
        }

        public bool RemoverDiretorPorId(int id)
        {
            var d = BuscarDiretorPorId(id);
            if (d == null) return false;
            funcionarios.Remove(d);
            return true;
        }

        // ===== Métodos para gerir Secretárias =====
        public List<Secretaria> ObterSecretarias()
        {
            return funcionarios.OfType<Secretaria>().ToList();
        }

        public Secretaria BuscarSecretariaPorId(int id)
        {
            return funcionarios.OfType<Secretaria>().FirstOrDefault(s => s.Id == id);
        }

        public bool RemoverSecretariaPorId(int id)
        {
            var s = BuscarSecretariaPorId(id);
            if (s == null) return false;
            funcionarios.Remove(s);
            return true;
        }

        public List<Secretaria> FiltrarSecretariasPorArea(string area)
        {
            if (string.IsNullOrWhiteSpace(area)) return new List<Secretaria>();
            return funcionarios.OfType<Secretaria>()
                .Where(s => string.Equals(s.Area, area.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // ===== Fim dos Métodos para gerir Secretárias =====

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

        public void ExportarFuncionariosParaCSV(string caminhoFicheiro)
        {
            var funcionarios = Funcionarios;
            var sb = new StringBuilder();
            sb.AppendLine("Id,Nome,DataFimContrato,DataFimRegistoCrim");

            foreach (var f in funcionarios)
            {
                sb.AppendLine($"{f.Id},{EscapeCsv(f.Nome)},{f.DataFimContrato:yyyy-MM-dd},{f.DataFimRegistoCrim:yyyy-MM-dd}");
            }

            File.WriteAllText(caminhoFicheiro, sb.ToString(), Encoding.UTF8);
        }

        private string EscapeCsv(string s)
        {
            if (s.Contains(",") || s.Contains("\"") || s.Contains("\n"))
            {
                return $"\"{s.Replace("\"", "\"\"")}\"";
            }
            return s;
        }
    }
}




//ANTIGO antes da implementação dos mtodos de gestão de despesas
/*
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

        // ===== Métodos para gerir Formadores =====
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

        // ===== Métodos para gerir Diretores =====
        public List<Diretor> ObterDiretores()
        {
            return funcionarios.OfType<Diretor>().ToList();
        }

        public Diretor BuscarDiretorPorId(int id)
        {
            return funcionarios.OfType<Diretor>().FirstOrDefault(d => d.Id == id);
        }

        public bool RemoverDiretorPorId(int id)
        {
            var d = BuscarDiretorPorId(id);
            if (d == null) return false;
            funcionarios.Remove(d);
            return true;
        }

        // ===== Métodos para gerir Secretárias =====
        public List<Secretaria> ObterSecretarias()
        {
            return funcionarios.OfType<Secretaria>().ToList();
        }

        public Secretaria BuscarSecretariaPorId(int id)
        {
            return funcionarios.OfType<Secretaria>().FirstOrDefault(s => s.Id == id);
        }

        public bool RemoverSecretariaPorId(int id)
        {
            var s = BuscarSecretariaPorId(id);
            if (s == null) return false;
            funcionarios.Remove(s);
            return true;
        }

        public List<Secretaria> FiltrarSecretariasPorArea(string area)
        {
            if (string.IsNullOrWhiteSpace(area)) return new List<Secretaria>();
            return funcionarios.OfType<Secretaria>()
                .Where(s => string.Equals(s.Area, area.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // ===== Fim dos Métodos para gerir Secretárias =====

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
*/
