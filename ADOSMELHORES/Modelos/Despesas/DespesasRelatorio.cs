using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES.Modelos.Despesas
{

    // Relatório consolidado de despesas mensais
    public class RelatorioDespesas
    {
        public int Mes { get; set; }
        public int Ano { get; set; }

        // Despesas Físicas (inseridas manualmente)
        public decimal DespesasFisicas { get; set; }

        // Despesas com Funcionários (inseridas automaticamente)
        public decimal DespesasDiretores { get; set; }
        public decimal DespesasSecretarias { get; set; }
        public decimal DespesasCoordenadores { get; set; }
        public decimal DespesasFormadores { get; set; }

        // Total de despesas com funcionários
        public decimal TotalFuncionarios => DespesasDiretores +
                                             DespesasSecretarias +
                                             DespesasCoordenadores +
                                             DespesasFormadores;

       
        public decimal TotalDespesas => DespesasFisicas + TotalFuncionarios;

        // Nome do mês (Janeiro, Fevereiro, etc.)
        public string NomeMes => ObterNomeMes(Mes);

        // Descrição do período (Dezembro 2024)
        public string Periodo => $"{NomeMes} {Ano}";

        public RelatorioDespesas()
        {
            Mes = DateTime.Now.Month;
            Ano = DateTime.Now.Year;
        }

        public RelatorioDespesas(int mes, int ano)
        {
            Mes = mes;
            Ano = ano;
        }


        public static string ObterNomeMes(int mes)
        {
            switch (mes)
            {
                case 1: return "Janeiro";
                case 2: return "Fevereiro";
                case 3: return "Março";
                case 4: return "Abril";
                case 5: return "Maio";
                case 6: return "Junho";
                case 7: return "Julho";
                case 8: return "Agosto";
                case 9: return "Setembro";
                case 10: return "Outubro";
                case 11: return "Novembro";
                case 12: return "Dezembro";
                default: return "Inválido";
            }
        }

        public override string ToString()
        {
            return $"{Periodo} - Total: €{TotalDespesas:N2}";
        }
    }
}
