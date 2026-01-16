using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES
{
    public abstract class Funcionario
    {
        protected Funcionario(
            int id,
            int nif,
            string nome,
            string morada,
            string contacto,
            decimal salarioBase,
            DateTime dataIniContrato,
            DateTime dataFimContrato,
            DateTime dataFimRegistoCrim,
            DateTime dataNascimento
        )
        {
            Id = id;
            Nif = nif;
            Nome = nome;
            Morada = morada;
            Contacto = contacto;
            SalarioBase = salarioBase;
            DataIniContrato = dataIniContrato;
            DataFimContrato = dataFimContrato;
            DataFimRegistoCrim = dataFimRegistoCrim;
            DataNascimento = dataNascimento;
        }

        public int Id { get; set; }
        public int Nif { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Contacto { get; set; }
        public decimal SalarioBase { get; set; }
        public DateTime DataIniContrato { get; set; }
        public DateTime DataFimContrato { get; set; }
        public DateTime DataFimRegistoCrim { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual decimal CalcularCustoMensal()
        {
            // Por padrão retorna o salário base
            return SalarioBase;
        }

        public bool ContratoValido(DateTime data)
        {
            return data >= DataIniContrato && data <= DataFimContrato;
        }

        public bool RegistoCriminalExpirado(DateTime data)
        {
            return data > DataFimRegistoCrim;
        }

        public override string ToString()
        {
            return $"ID: {Id} - {Nome} - NIF: {Nif}";
        }
    }
}
