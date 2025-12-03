using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES.Modelos
{
    internal class Empresa
    {
        List<Funcionário> Colaboradores { get; set; } = new List<Funcionário>();
    }
}
