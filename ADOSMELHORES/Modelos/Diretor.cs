using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADOSMELHORES.Modelos
{
    internal class Diretor : Funcionario
    {
        //atributos pedidos na ficha
        public decimal BonusMensal { get; set; }
        public bool CarroEmpresa { get; set; }
        public bool IsencaoHorario { get; set; } //bool faz sentido?

        //atributos adicionais
        public string AreaDiretoria { get; set; } //para correlacionar com a secretaria

        //lista de secretárias que trabalham com o diretor
        public List<Secretaria> SecretariasSubordinadas { get; set; }

        public Diretor(
                int id,
                int nif,
                string nome,
                string morada,
                string contacto,
                decimal salarioBase,
                DateTime dataFimContrato,
                DateTime dataIniContrato,
                DateTime dataFimRegistoCrim,
                DateTime dataNascimento,
                decimal bonusMensal,
                bool carroEmpresa,
                bool isencaoHorario,
                string areaDiretoria

            ) : base (
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
            BonusMensal = bonusMensal;
            CarroEmpresa = carroEmpresa;
            IsencaoHorario = isencaoHorario;
            AreaDiretoria = areaDiretoria;
            
            SecretariasSubordinadas = new List<Secretaria>();
        }

        //implementar método de calcula de salario do diretor
        //public override decimal CalcularSalario() => SalarioBase + BonusMensal;

        //metodo para calcular bonus mensal
        public decimal CalcularBonusMensal()
        {
            decimal bonus = 0;

            //Fatores que influenciam no bonus
            //1. Número de secretárias subordinadas
            bonus += SecretariasSubordinadas.Count * 50; //exemplo: 50 por secretária

            //2. Tempo na empresa
            //int anosNaEmpresa = DateTime.Now.Year - DataIniContrato.Year;
            //bonus += anosNaEmpresa * 100; //exemplo: 100 por ano na empresa

            //3. Se tem carro da empresa
            if (CarroEmpresa)
            {                
                bonus -= 300; //desconta 300 do bonus se tiver carro da empresa
            }
            

            //4. Se tem isençao de horário
            if (IsencaoHorario)
            {
                bonus += 200; //adiciona 200 ao bonus se tiver isenção de horário
            }

            return Math.Max(bonus, 0);//garante que o bonus não seja negativo

        }

        //      ----  Métodos para gerenciar secretarias subordinadas  ----
        // Ao adicionar uma secretaria
        public void AdicionarSecretaria(Secretaria secretaria)
        {
            secretaria.DiretorReporta = this;
            SecretariasSubordinadas.Add(secretaria);
        }

        // Ao remover uma secretaria
        public void RemoverSecretaria(Secretaria secretaria)
        {
            if (SecretariasSubordinadas.Contains(secretaria))
            {
                secretaria.DiretorReporta = null;
                SecretariasSubordinadas.Remove(secretaria);
            }
        }

        // Obter todas as secretarias de um diretor
        public List<Secretaria> ObterSecretarias()
        {
            return SecretariasSubordinadas;
        }


    }
}
