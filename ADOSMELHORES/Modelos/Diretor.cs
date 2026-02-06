using System;
using System.Collections.Generic;

namespace ADOSMELHORES.Modelos
{
    public class Diretor : Funcionario
    {
        public bool IsencaoHorario { get; set; }

        public decimal BonusMensal => CalcularBonusMensal();
        
        public bool CarroEmpresa { get; set; }

        //atributos adicionais
        public List<string> AreasDiretoria { get; set; } = new List<string>(); //para correlacionar com a secretaria

        public string AreasDiretoriaString
        {
            get
            {
                return AreasDiretoria != null && AreasDiretoria.Count > 0
                    ? string.Join(", ", AreasDiretoria)
                    : "Nenhuma";
            }
        }

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
                bool carroEmpresa,
                bool isencaoHorario

            ) : base (
                id,
                nif,
                nome,
                morada,
                contacto,
                salarioBase,
                dataIniContrato,
                dataFimContrato,
                dataFimRegistoCrim
                
            )
        {
            IsencaoHorario = isencaoHorario;            
            CarroEmpresa = carroEmpresa;          
            
            //AreaDiretoria = areaDiretoria;
            AreasDiretoria = new List<string>();
            SecretariasSubordinadas = new List<Secretaria>();
        }

        //implementar método de calcula de salario do diretor
        public override decimal CalcularCustoMensal()
        {
            return SalarioBase + BonusMensal;
        }

        //metodo para calcular bonus mensal(irá para FormsCalcularRemuneracao)
        public decimal CalcularBonusMensal()
        {
            decimal bonus = 0;

            //Fatores que influenciam no bonus
            // 1. Bônus por áreas de direção (200€ por área)
            bonus += (AreasDiretoria?.Count ?? 0) * 200;

            // 2. Bônus por secretárias subordinadas (30€ por secretária)
            bonus += (SecretariasSubordinadas?.Count ?? 0) * 30;

            //3. Se nao tem carro da empresa
            if (!CarroEmpresa)
            {
                bonus += 300; 
            }

            //4. Se tem isençao de horário
            if (IsencaoHorario)
            {
                bonus += 200; 
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

        public override string ToString()
        {
            return $"{base.ToString()} - Diretor - Bónus: {BonusMensal:C} - Carro: {(CarroEmpresa ? "Sim" : "Não")}";
        }
    }
}
