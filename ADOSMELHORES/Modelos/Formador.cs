using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES.Modelos
{

    public enum Disponibilidade
    {
        Laboral,
        PosLaboral,
        Ambas
    }
    public class Formador : Funcionario
    {

        public string AreaLeciona { get; set; }

        public Disponibilidade Disponibilidade { get; set; }

        public decimal ValorHora { get; set; }

        //Construtor com parametros
        public Formador(
            int id,
            int nif,
            string nome,
            string morada,
            string contacto,
            DateTime dataFimContrato,
            DateTime dataIniContrato,
            DateTime dataFimRegistoCrim,
            decimal salarioBase,
            DateTime dataNascimento,
            string areaLeciona,
            Disponibilidade disponibilidade,
            decimal valorHora)
            : base(
                  id,
                  nif,
                  nome,
                  morada,
                  contacto,
                  salarioBase,
                  dataIniContrato,
                  dataFimContrato,
                  dataFimRegistoCrim,
                  dataNascimento
            )
        {
            AreaLeciona = areaLeciona;
            Disponibilidade = disponibilidade;
            ValorHora = valorHora;
        }

        public override decimal CustoMensal()
        {
            throw new NotImplementedException();
        }
        public decimal CalcularValorFormacao(DateTime DataIniContrato, DateTime DataFimContrato)
        {
            if (DataFimContrato < DataIniContrato)
            {
                throw new ArgumentException("Data final não pode ser anterior à data inicial");
            }
            
            // + 1 pois inclui o dia final de trabalho que tb conta para o calculo
            int dias = (DataFimContrato - DataIniContrato).Days + 1;
            //Assumindo 6 hrs de formação por dia conforme enunciado
            int totalHoras = dias * 6; 
            return totalHoras * ValorHora;
        }

        public decimal CalcularCustoMensal(int horasMensais)
        {
            return horasMensais * ValorHora;
        }
      

        public override string ToString()
        {
            return $"{base.ToString()} - {AreaLeciona} - {Disponibilidade} - {ValorHora:C}/hora";
        }




    }
}
