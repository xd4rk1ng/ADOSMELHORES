using ADOSMELHORES;
using ADOSMELHORES.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES.Modelos
{
    public class Empresa
    {
        public string Nome { get; set; }
        public List<Funcionario> Funcionarios { get; set; }
        public DateTime DataSimulada { get; set; }
        public static object Colaboradores { get; internal set; }

        public Empresa(string nome)
        {
            Nome = nome;
            Funcionarios = new List<Funcionario>();
            DataSimulada = DateTime.Now.Date;
        }

        /// <summary>
        /// Adiciona um novo funcionário à empresa
        /// </summary>
        public void AdicionarFuncionario(Funcionario funcionario)
        {
            Funcionarios.Add(funcionario);
        }

        /// <summary>
        /// Remove um funcionário da empresa
        /// </summary>
        public void RemoverFuncionario(Funcionario funcionario)
        {
            Funcionarios.Remove(funcionario);
        }

        /// <summary>
        /// Retorna funcionários com contrato válido na data especificada
        /// </summary>
        public List<Funcionario> ObterFuncionariosContratoValido(DateTime data)
        {
            return Funcionarios.Where(f => f.ContratoValido(data)).ToList();
        }

        /// <summary>
        /// Retorna funcionários com registo criminal expirado
        /// </summary>
        public List<Funcionario> ObterFuncionariosRegistoCriminalExpirado(DateTime data)
        {
            return Funcionarios.Where(f => f.RegistoCriminalExpirado(data)).ToList();
        }

        /// <summary>
        /// Calcula o valor total de despesa mensal da empresa
        /// </summary>
        public decimal CalcularDespesaMensal()
        {
            return Funcionarios.Sum(f => f.CalcularCustoMensal());
        }

        /// <summary>
        /// Avança a data simulada em um dia e retorna alertas se necessário
        /// </summary>
        public List<string> AvancarDia()
        {
            DataSimulada = DataSimulada.AddDays(1);
            List<string> alertas = new List<string>();

            foreach (var funcionario in Funcionarios)
            {
                // Verifica se o contrato termina hoje
                if (funcionario.DataFimContrato.Date == DataSimulada)
                {
                    alertas.Add($"ALERTA: Contrato de {funcionario.Nome} termina hoje!");
                }

                // Verifica se o registo criminal expira hoje
                if (funcionario.DataRegistoCriminal is DateTime dataRegistoCriminal && dataRegistoCriminal.Date == DataSimulada)
                {
                    alertas.Add($"ALERTA: Registo criminal de {funcionario.Nome} expira hoje!");
                }
            }

            return alertas;
        }

        /// <summary>
        /// Exporta informação dos funcionários para ficheiro CSV
        /// </summary>
        public void ExportarParaCSV(string caminhoFicheiro)
        {
            StringBuilder csv = new StringBuilder();

            // Cabeçalho
            csv.AppendLine("ID;Nome;Tipo;Morada;Contacto;Data Fim Contrato;Data Registo Criminal;Salário Base;Informações Adicionais");

            foreach (var funcionario in Funcionarios)
            {
                string infoAdicional = "";

                if (funcionario is Diretor diretor)
                {
                    infoAdicional = $"Bónus: {diretor.BonusMensal}; Carro: {(diretor.CarroEmpresa ? "Sim" : "Não")}";
                }
                else if (funcionario is Secretaria secretaria)
                {
                    infoAdicional = $"Área: {secretaria.Area}; Reporta a: {secretaria.DiretorReporta?.Nome ?? "N/A"}";
                }
                else if (funcionario is Formador formador)
                {
                    infoAdicional = $"Área: {formador.AreaLeciona}; Disponibilidade: {formador.Disponibilidade}; Valor/Hora: {formador.ValorHora}";
                }
                else if (funcionario is Coordenador coordenador)
                {
                    infoAdicional = $"Área: {coordenador.AreaCoordenacao}; Formadores: {coordenador.NumeroFormadores}";
                }

                csv.AppendLine($"{funcionario.Id};{funcionario.Nome};{funcionario.GetType().Name};" +
                    $"{funcionario.Morada};{funcionario.Contacto};" +
                    $"{funcionario.DataFimContrato:dd/MM/yyyy};{funcionario.DataRegistoCriminal:dd/MM/yyyy};" +
                    $"{funcionario.SalarioBase};{infoAdicional}");
            }

            //File.WriteAllText(caminhoFicheiro, csv.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// Retorna todos os formadores da empresa
        /// </summary>
       // public List<Formador> ObterFormadores => Funcionarios.OfType<Formador>().ToList();

        /// <summary>
        /// Retorna próximo ID disponível
        /// </summary>
        public int ObterProximoID()
        {
            return Funcionarios.Any() ? Funcionarios.Max(f => f.Id) + 1 : 1;
        }
    }
}

public class Formador : Funcionario
{
    public Formador(int id, int nif, string nome, string morada, string contacto, decimal salarioBase, DateTime dataIniContrato, DateTime dataFimContrato, DateTime dataFimRegistoCrim, DateTime dataNascimento) : base(id, nif, nome, morada, contacto, salarioBase, dataIniContrato, dataFimContrato, dataFimRegistoCrim, dataNascimento)
    {
    }

    public string AreaLeciona { get; set; }
    public Disponibilidade Disponibilidade { get; set; }
    public decimal ValorHora { get; set; }

    // Implementação do método exigido pelo compilador
    public decimal CalcularValorFormacao(DateTime DataIniContrato, DateTime DataFimContrato)
    {
        // Exemplo de cálculo: total de dias * valor/hora * 8 horas/dia
        int dias = (DataFimContrato.Date - DataIniContrato.Date).Days + 1;
        return dias * ValorHora * 8;
    }

    public decimal CalcularCustoMensal(int horasMensais)
    {
        // Exemplo de cálculo: salário base + valor/hora * horas mensais
        return SalarioBase + (ValorHora * horasMensais);
    }

    public override string ToString()
    {
        return $"{Nome} - Área: {AreaLeciona}, Disponibilidade: {Disponibilidade}, Valor/Hora: {ValorHora}";
    }
}
