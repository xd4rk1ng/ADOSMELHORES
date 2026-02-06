using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES.Modelos
{
    internal class Exemplo : Funcionario
    {
        public Exemplo(
            string nome, // Este e o unico atributo que estou a fazer, porque tive preguica :P
            int id = default,
            int nif = default,
            string morada = default,
            string contacto = default,
            decimal salarioBase = default,
            DateTime dataIniContrato = default,
            DateTime dataFimContrato = default,
            DateTime dataFimRegistoCrim = default,
            DateTime dataNascimento = default
            ) : base(
                id,
                nif,
                nome,
                morada,
                contacto,
                salarioBase,
                dataIniContrato,
                dataFimContrato,
                dataFimRegistoCrim)
        {

        }
    }
}
