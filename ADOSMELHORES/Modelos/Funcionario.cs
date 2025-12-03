using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES
{
    internal abstract class Funcionário
    {
        public int Id { get; set; }
        public int Nif { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string Contacto { get; set; }
        public DateTime DataFimContrato { get; set; }
        public DateTime DataFimRegistoCrim { get; set; }
    }
}
