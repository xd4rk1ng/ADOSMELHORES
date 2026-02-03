using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES.Modelos
{
    
    public class DespesaFisica
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public TipoDespesaFisica Tipo { get; set; }
        public decimal Valor { get; set; }
        public string Descricao { get; set; }
        public string Fornecedor { get; set; }

        public DespesaFisica()
        {
            Data = DateTime.Now;
            Descricao = string.Empty;
            Fornecedor = string.Empty;
        }

        public DespesaFisica(int id, DateTime data, TipoDespesaFisica tipo, decimal valor, string descricao, string fornecedor)
        {
            Id = id;
            Data = data;
            Tipo = tipo;
            Valor = valor;
            Descricao = descricao ?? string.Empty;
            Fornecedor = fornecedor ?? string.Empty;
        }


        public string TipoDescricao => ObterDescricaoTipo(Tipo);


        public static string ObterDescricaoTipo(TipoDespesaFisica tipo)
        {
            switch (tipo)
            {
                case TipoDespesaFisica.Agua:
                    return "Água";
                case TipoDespesaFisica.Luz:
                    return "Eletricidade";
                case TipoDespesaFisica.Internet:
                    return "Internet";
                case TipoDespesaFisica.MaterialAdministrativo:
                    return "Material Administrativo";
                case TipoDespesaFisica.MaterialInformatico:
                    return "Material Informático";
                case TipoDespesaFisica.Limpeza:
                    return "Limpeza";
                case TipoDespesaFisica.Manutencao:
                    return "Manutenção";
                case TipoDespesaFisica.Seguranca:
                    return "Segurança";
                case TipoDespesaFisica.Aluguel:
                    return "Aluguel";
                case TipoDespesaFisica.Seguros:
                    return "Seguros";
                case TipoDespesaFisica.Marketing:
                    return "Marketing/Publicidade";
                case TipoDespesaFisica.Outros:
                    return "Outros";
                default:
                    return tipo.ToString();
            }
        }

        public override string ToString()
        {
            return $"{TipoDescricao} - €{Valor:N2} ({Data:dd/MM/yyyy})";
        }
    }


    public enum TipoDespesaFisica
    {
        Agua,
        Luz,
        Internet,      
        MaterialAdministrativo,
        MaterialInformatico,
        Limpeza,
        Manutencao,
        Seguranca,
        Aluguel,
        Seguros,
        Marketing,
        Outros
    }
}
