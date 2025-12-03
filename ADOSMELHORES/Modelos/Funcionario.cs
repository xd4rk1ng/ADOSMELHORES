using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES
{
    internal abstract class Funcionario
    {
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
    }
}
