using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ADOSMELHORES.Modelos.Despesas
{
    // Gerencia todas as operações relacionadas a despesas
    // ARMAZENAMENTO TEMPORÁRIO EM MEMÓRIA (dados perdidos ao fechar)
    // MIGRAÇÃO BD: Substituir lista por consultas ao banco de dados

    public class GestorDespesas
    {
        private Empresa empresa;

        // TEMPORÁRIO - Lista em memória (será perdida ao fechar o programa)
        // MIGRAÇÃO BD: REMOVER esta lista e buscar do banco de dados
        private List<DespesaFisica> despesasFisicas;

        public GestorDespesas(Empresa empresaRef)
        {
            empresa = empresaRef ?? throw new ArgumentNullException(nameof(empresaRef));

            // TEMPORÁRIO - Inicializa lista vazia
            // MIGRAÇÃO BD: REMOVER esta linha, dados virão do BD
            despesasFisicas = new List<DespesaFisica>();
        }

        // ========== DESPESAS FÍSICAS (MANUAIS) ==========
               
        public void AdicionarDespesaFisica(DespesaFisica despesa)
        {
            if (despesa == null)
                throw new ArgumentNullException(nameof(despesa));

            // TEMPORÁRIO - Adiciona na lista em memória
            despesa.Id = ObterProximoIdDespesa();
            despesasFisicas.Add(despesa);

            // MIGRAÇÃO BD: Substituir por INSERT
            // using (var context = new DatabaseContext())
            // {
            //     context.DespesasFisicas.Add(despesa);
            //     context.SaveChanges();
            // }
        }

        // Remove uma despesa física
        public bool RemoverDespesaFisica(int id)
        {
            //TEMPORÁRIO - Remove da lista em memória
            var despesa = despesasFisicas.FirstOrDefault(d => d.Id == id);
            if (despesa != null)
            {
                despesasFisicas.Remove(despesa);
                return true;
            }
            return false;

            // MIGRAÇÃO BD: Substituir por DELETE
            // using (var context = new DatabaseContext())
            // {
            //     var despesa = context.DespesasFisicas.Find(id);
            //     if (despesa != null)
            //     {
            //         context.DespesasFisicas.Remove(despesa);
            //         context.SaveChanges();
            //         return true;
            //     }
            //     return false;
            // }
        }

        // Obtém todas as despesas físicas
        public List<DespesaFisica> ObterTodasDespesasFisicas()
        {
            // TEMPORÁRIO - Retorna da lista em memória
            return despesasFisicas.ToList();

            // MIGRAÇÃO BD: Substituir por SELECT
            // using (var context = new DatabaseContext())
            // {
            //     return context.DespesasFisicas.ToList();
            // }
        }

        // Obtém despesas físicas de um mês específico
        public List<DespesaFisica> ObterDespesasFisicasPorMes(int mes, int ano)
        {
            // TEMPORÁRIO - Filtra da lista em memória
            return despesasFisicas
                .Where(d => d.Data.Month == mes && d.Data.Year == ano)
                .OrderBy(d => d.Data)
                .ToList();

            // MIGRAÇÃO BD: Substituir por SELECT com WHERE
            // using (var context = new DatabaseContext())
            // {
            //     return context.DespesasFisicas
            //         .Where(d => d.Data.Month == mes && d.Data.Year == ano)
            //         .OrderBy(d => d.Data)
            //         .ToList();
            // }
        }

        // Calcula total de despesas físicas de um mês
        public decimal CalcularDespesasFisicasMes(int mes, int ano)
        {
            // TEMPORÁRIO - Calcula da lista em memória
            return despesasFisicas
                .Where(d => d.Data.Month == mes && d.Data.Year == ano)
                .Sum(d => d.Valor);

            // MIGRAÇÃO BD: Pode usar SUM diretamente no banco (mais eficiente)
            // using (var context = new DatabaseContext())
            // {
            //     return context.DespesasFisicas
            //         .Where(d => d.Data.Month == mes && d.Data.Year == ano)
            //         .Sum(d => (decimal?)d.Valor) ?? 0;
            // }
        }

        // Busca despesa física por ID
        public DespesaFisica BuscarDespesaFisicaPorId(int id)
        {
            // TEMPORÁRIO - Busca na lista em memória
            return despesasFisicas.FirstOrDefault(d => d.Id == id);

            // MIGRAÇÃO BD: Substituir por SELECT WHERE
            // using (var context = new DatabaseContext())
            // {
            //     return context.DespesasFisicas.Find(id);
            // }
        }

        // ========== DESPESAS COM FUNCIONÁRIOS (AUTOMÁTICO) ==========
        // Também precisa mudar com migração BD
        // Pois busca diretamente da lista de funcionários da Empresa

        // Calcula despesas com diretores do mês
        public decimal CalcularDespesasDiretores()
        {
            var diretores = empresa.ObterDiretores();
            return diretores.Sum(d => d.CalcularCustoMensal());
        }

        // Calcula despesas com secretárias do mês
        public decimal CalcularDespesasSecretarias()
        {
            var secretarias = empresa.ObterSecretarias();
            return secretarias.Sum(s => s.CalcularCustoMensal());
        }

        // Calcula despesas com coordenadores do mês
        public decimal CalcularDespesasCoordenadores()
        {
            // TODO: Implementar quando houver coordenadores na Empresa
            var coordenadores = empresa.ObterCoordenadores();
            return coordenadores.Sum(d => d.CalcularCustoMensal());
        }

        // Calcula despesas com formadores do mês (agora por mes/ano)
        public decimal CalcularDespesasFormadores(int mes, int ano)
        {
            var formadores = empresa.ObterFormadores();
            return formadores.Sum(f => f.CalcularCustoMensal(mes, ano));
        }

        // Calcula total de despesas com funcionários
        public decimal CalcularTotalFuncionarios(int mes, int ano)
        {
            return CalcularDespesasDiretores() +
                   CalcularDespesasSecretarias() +
                   CalcularDespesasCoordenadores() +
                   CalcularDespesasFormadores(mes, ano);
        }

        // ========== RELATÓRIOS ==========
        // Gera relatório completo de um mês
        public RelatorioDespesas GerarRelatorioMes(int mes, int ano)
        {
            return new RelatorioDespesas(mes, ano)
            {
                DespesasFisicas = CalcularDespesasFisicasMes(mes, ano),
                DespesasDiretores = CalcularDespesasDiretores(),
                DespesasSecretarias = CalcularDespesasSecretarias(),
                DespesasCoordenadores = CalcularDespesasCoordenadores(),
                DespesasFormadores = CalcularDespesasFormadores(mes, ano) // usa mês/ano solicitado
            };
        }

        // Gera relatório do mês atual
        public RelatorioDespesas GerarRelatorioMesAtual()
        {
            return GerarRelatorioMes(DateTime.Now.Month, DateTime.Now.Year);
        }

        // Gera relatório anual (todos os 12 meses)
        public List<RelatorioDespesas> GerarRelatorioAnual(int ano)
        {
            var relatorios = new List<RelatorioDespesas>();
            for (int mes = 1; mes <= 12; mes++)
            {
                relatorios.Add(GerarRelatorioMes(mes, ano));
            }
            return relatorios;
        }

        // Gera relatório dos últimos N meses
        public List<RelatorioDespesas> GerarRelatorioUltimosMeses(int quantidadeMeses)
        {
            var relatorios = new List<RelatorioDespesas>();
            var dataAtual = DateTime.Now;

            for (int i = quantidadeMeses - 1; i >= 0; i--)
            {
                var data = dataAtual.AddMonths(-i);
                relatorios.Add(GerarRelatorioMes(data.Month, data.Year));
            }

            return relatorios;
        }

        // ========== EXPORTAÇÃO CSV ==========
        //
        // Exporta relatório mensal para CSV
        public void ExportarRelatorioMensalCSV(int mes, int ano, string caminhoArquivo)
        {
            var relatorio = GerarRelatorioMes(mes, ano);
            var despesas = ObterDespesasFisicasPorMes(mes, ano);

            StringBuilder csv = new StringBuilder();
            csv.AppendLine($"RELATÓRIO DE DESPESAS - {relatorio.Periodo}");
            csv.AppendLine();
            csv.AppendLine("RESUMO");
            csv.AppendLine($"Despesas Físicas;€{relatorio.DespesasFisicas:N2}");
            csv.AppendLine($"Diretores;€{relatorio.DespesasDiretores:N2}");
            csv.AppendLine($"Secretárias;€{relatorio.DespesasSecretarias:N2}");
            csv.AppendLine($"Coordenadores;€{relatorio.DespesasCoordenadores:N2}");
            csv.AppendLine($"Formadores;€{relatorio.DespesasFormadores:N2}");
            csv.AppendLine($"TOTAL;€{relatorio.TotalDespesas:N2}");
            csv.AppendLine();
            csv.AppendLine("DESPESAS FÍSICAS DETALHADAS");
            csv.AppendLine("Data;Tipo;Valor;Fornecedor;Descrição");

            foreach (var d in despesas)
            {
                csv.AppendLine($"{d.Data:dd/MM/yyyy};{d.TipoDescricao};€{d.Valor:N2};{d.Fornecedor};{d.Descricao}");
            }

            File.WriteAllText(caminhoArquivo, csv.ToString(), Encoding.UTF8);
        }

        // Exporta relatório anual para CSV
        public void ExportarRelatorioAnualCSV(int ano, string caminhoArquivo)
        {
            var relatorios = GerarRelatorioAnual(ano);

            StringBuilder csv = new StringBuilder();
            csv.AppendLine($"RELATÓRIO ANUAL DE DESPESAS - {ano}");
            csv.AppendLine();
            csv.AppendLine("Mês;Despesas Físicas;Diretores;Secretárias;Coordenadores;Formadores;Total");

            foreach (var r in relatorios)
            {
                csv.AppendLine($"{r.NomeMes};€{r.DespesasFisicas:N2};€{r.DespesasDiretores:N2};€{r.DespesasSecretarias:N2};€{r.DespesasCoordenadores:N2};€{r.DespesasFormadores:N2};€{r.TotalDespesas:N2}");
            }

            csv.AppendLine();
            csv.AppendLine($"TOTAL DO ANO;;;;;€{CalcularTotalAno(ano):N2}");
            csv.AppendLine($"MÉDIA MENSAL;;;;;€{CalcularMediaMensalAno(ano):N2}");

            File.WriteAllText(caminhoArquivo, csv.ToString(), Encoding.UTF8);
        }

        // ========== ANÁLISES ==========

        public decimal CalcularMediaMensalAno(int ano)
        {
            var relatorios = GerarRelatorioAnual(ano);
            return relatorios.Average(r => r.TotalDespesas);
        }

        public decimal CalcularTotalAno(int ano)
        {
            var relatorios = GerarRelatorioAnual(ano);
            return relatorios.Sum(r => r.TotalDespesas);
        }

        // ========== MÉTODOS AUXILIARES ==========

        // Obtém próximo ID disponível para despesa física
        private int ObterProximoIdDespesa()
        {
            // TEMPORÁRIO - Calcula da lista em memória
            if (despesasFisicas.Count == 0)
                return 1;
            return despesasFisicas.Max(d => d.Id) + 1;

            // MIGRAÇÃO BD: Usar IDENTITY ou MAX(Id) + 1
            // using (var context = new DatabaseContext())
            // {
            //     if (!context.DespesasFisicas.Any())
            //         return 1;
            //     return context.DespesasFisicas.Max(d => d.Id) + 1;
            // }
        }

        // Limpa todas as despesas físicas (usar com cuidado!)
        public void LimparDespesasFisicas()
        {
            // TEMPORÁRIO - Limpa lista em memória
            despesasFisicas.Clear();

            // MIGRAÇÃO BD: DELETE FROM DespesasFisicas
            // using (var context = new DatabaseContext())
            // {
            //     context.DespesasFisicas.RemoveRange(context.DespesasFisicas);
            //     context.SaveChanges();
            // }
        }

        // Obtém quantidade de despesas físicas registradas
        public int ObterQuantidadeDespesasFisicas()
        {
            // TEMPORÁRIO - Conta da lista em memória
            return despesasFisicas.Count;

            // MIGRAÇÃO BD: SELECT COUNT(*)
            // using (var context = new DatabaseContext())
            // {
            //     return context.DespesasFisicas.Count();
            // }
        }

        // ========== DADOS DE EXEMPLO (REMOVER EM PRODUÇÃO) ==========
        // MÉTODO TEMPORÁRIO - Apenas para testes

        /// <summary>
        /// Carrega dados de exemplo para os meses:
        /// - Novembro 2025
        /// - Dezembro 2025  
        /// - Janeiro 2026
        /// REMOVER quando implementar Base de Dados
        /// </summary>
        public void CarregarDadosExemplo()
        {
            // ========== NOVEMBRO 2025 ==========
            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 11, 5),
                Tipo = TipoDespesaFisica.Luz,
                Valor = 320.00m,
                Fornecedor = "EDP Comercial",
                Descricao = "Consumo de energia elétrica - Novembro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 11, 5),
                Tipo = TipoDespesaFisica.Agua,
                Valor = 95.00m,
                Fornecedor = "EPAL",
                Descricao = "Consumo de água - Novembro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 11, 10),
                Tipo = TipoDespesaFisica.Internet,
                Valor = 79.90m,
                Fornecedor = "MEO",
                Descricao = "Internet fibra 1GB - Mensalidade Novembro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 11, 15),
                Tipo = TipoDespesaFisica.Limpeza,
                Valor = 550.00m,
                Fornecedor = "Limpeza Profissional Lda",
                Descricao = "Serviço de limpeza mensal - Novembro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 11, 20),
                Tipo = TipoDespesaFisica.MaterialAdministrativo,
                Valor = 125.00m,
                Fornecedor = "Staples Portugal",
                Descricao = "Papel A4, canetas, pastas, agrafos"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 11, 25),
                Tipo = TipoDespesaFisica.Seguros,
                Valor = 180.00m,
                Fornecedor = "Seguradora XYZ",
                Descricao = "Seguro das instalações - Mensalidade Novembro"
            });

            // ========== DEZEMBRO 2025 ==========
            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 12, 5),
                Tipo = TipoDespesaFisica.Luz,
                Valor = 380.00m,
                Fornecedor = "EDP Comercial",
                Descricao = "Consumo de energia elétrica - Dezembro (aumento por climatização)"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 12, 5),
                Tipo = TipoDespesaFisica.Agua,
                Valor = 105.00m,
                Fornecedor = "EPAL",
                Descricao = "Consumo de água - Dezembro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 12, 10),
                Tipo = TipoDespesaFisica.Internet,
                Valor = 79.90m,
                Fornecedor = "MEO",
                Descricao = "Internet fibra 1GB - Mensalidade Dezembro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 12, 15),
                Tipo = TipoDespesaFisica.Limpeza,
                Valor = 650.00m,
                Fornecedor = "Limpeza Profissional Lda",
                Descricao = "Serviço de limpeza mensal + limpeza especial fim de ano"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 12, 18),
                Tipo = TipoDespesaFisica.Manutencao,
                Valor = 420.00m,
                Fornecedor = "Manutenção Total Lda",
                Descricao = "Manutenção preventiva sistemas HVAC"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 12, 20),
                Tipo = TipoDespesaFisica.MaterialInformatico,
                Valor = 350.00m,
                Fornecedor = "Worten Empresas",
                Descricao = "Teclados, mouses, cabos HDMI, pen drives"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 12, 22),
                Tipo = TipoDespesaFisica.Marketing,
                Valor = 800.00m,
                Fornecedor = "Agência Criativa Lda",
                Descricao = "Campanha de marketing digital - Dezembro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2025, 12, 25),
                Tipo = TipoDespesaFisica.Seguros,
                Valor = 180.00m,
                Fornecedor = "Seguradora XYZ",
                Descricao = "Seguro das instalações - Mensalidade Dezembro"
            });

            // ========== JANEIRO 2026 ==========
            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2026, 1, 5),
                Tipo = TipoDespesaFisica.Luz,
                Valor = 410.00m,
                Fornecedor = "EDP Comercial",
                Descricao = "Consumo de energia elétrica - Janeiro (pico inverno)"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2026, 1, 5),
                Tipo = TipoDespesaFisica.Agua,
                Valor = 98.00m,
                Fornecedor = "EPAL",
                Descricao = "Consumo de água - Janeiro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2026, 1, 10),
                Tipo = TipoDespesaFisica.Internet,
                Valor = 79.90m,
                Fornecedor = "MEO",
                Descricao = "Internet fibra 1GB - Mensalidade Janeiro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2026, 1, 15),
                Tipo = TipoDespesaFisica.Limpeza,
                Valor = 550.00m,
                Fornecedor = "Limpeza Profissional Lda",
                Descricao = "Serviço de limpeza mensal - Janeiro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2026, 1, 20),
                Tipo = TipoDespesaFisica.MaterialAdministrativo,
                Valor = 200.00m,
                Fornecedor = "Staples Portugal",
                Descricao = "Stock anual: papel, envelopes, material escritório"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2026, 1, 22),
                Tipo = TipoDespesaFisica.Seguranca,
                Valor = 350.00m,
                Fornecedor = "Segurança 24h Lda",
                Descricao = "Serviço de segurança - Janeiro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2026, 1, 25),
                Tipo = TipoDespesaFisica.Seguros,
                Valor = 180.00m,
                Fornecedor = "Seguradora XYZ",
                Descricao = "Seguro das instalações - Mensalidade Janeiro"
            });

            AdicionarDespesaFisica(new DespesaFisica
            {
                Data = new DateTime(2026, 1, 28),
                Tipo = TipoDespesaFisica.Aluguel,
                Valor = 1500.00m,
                Fornecedor = "Imobiliária Central",
                Descricao = "Aluguel das instalações - Janeiro 2026"
            });
        }
    }
}
