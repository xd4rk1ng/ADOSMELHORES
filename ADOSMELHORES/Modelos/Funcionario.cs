using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES.Modelos
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
        public abstract decimal CustoMensal();

        public int Id { get; set; }
        public int Nif { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }     
        public string Morada { get; set; }
        public string Contacto { get; set; }
        public decimal SalarioBase { get; set; }
        public DateTime DataIniContrato { get; set; }
        public DateTime DataFimContrato { get; set; }
        public DateTime DataFimRegistoCrim { get; set; }
        public DateTime DataNascimento { get; set; }



    }
}
