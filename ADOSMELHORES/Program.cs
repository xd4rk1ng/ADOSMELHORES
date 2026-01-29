using ADOSMELHORES.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Corrigido: instanciando Empresa e passando para FormInicial
            var empresa = new Empresa("NomeDaEmpresa");

            //TEMPORÁRIO: Carregar dados de teste (remover quando implementar Base de Dados)
            CarregarDadosTeste(empresa);

            // Carregar dados da base de dados UTILIZAR ESTE MÉTODO QUANDO A BASE DE DADOS ESTIVER IMPLEMENTADA
            //CarregarDadosDaBaseDeDados(empresa);

            Application.Run(new Forms.FormLogin(empresa));
        }

        /// <summary>
        /// MÉTODO TEMPORÁRIO - Carrega dados de teste para desenvolvimento
        /// TODO: REMOVER este método quando a base de dados estiver implementada
        /// </summary>
        private static void CarregarDadosTeste(Empresa empresa)
        {
            // Data base para os contratos
            DateTime hoje = DateTime.Now;
            DateTime inicioContrato = hoje.AddMonths(-6);
            DateTime fimContrato = hoje.AddYears(2);
            DateTime fimRegistoCriminal = hoje.AddYears(1);

            // ========== CRIANDO 3 DIRETORES ==========

            var diretor1 = new Diretor(
                id: 1,
                nif: 111222333,
                nome: "Carlos Mendes",
                morada: "Rua das Flores, 123, Porto",
                contacto: "912345671",
                salarioBase: 3500m,
                dataFimContrato: fimContrato,
                dataIniContrato: inicioContrato,
                dataFimRegistoCrim: fimRegistoCriminal,
                dataNascimento: new DateTime(1975, 3, 15),
                bonusMensal: 800m,
                carroEmpresa: true,
                isencaoHorario: true
            );
            diretor1.AreasDiretoria.Add("Recursos Humanos");
            //diretor1.AreasDiretoria.Add("Financeiro");

            var diretor2 = new Diretor(
                id: 2,
                nif: 222333444,
                nome: "Ana Silva",
                morada: "Avenida Central, 456, Lisboa",
                contacto: "913456782",
                salarioBase: 4000m,
                dataFimContrato: fimContrato,
                dataIniContrato: inicioContrato,
                dataFimRegistoCrim: fimRegistoCriminal,
                dataNascimento: new DateTime(1980, 7, 22),
                bonusMensal: 1000m,
                carroEmpresa: true,
                isencaoHorario: true
            );
            diretor2.AreasDiretoria.Add("Formação");
            //diretor2.AreasDiretoria.Add("Qualidade");

            var diretor3 = new Diretor(
                id: 3,
                nif: 333444555,
                nome: "João Santos",
                morada: "Praça da República, 789, Braga",
                contacto: "914567893",
                salarioBase: 3200m,
                dataFimContrato: fimContrato,
                dataIniContrato: inicioContrato,
                dataFimRegistoCrim: fimRegistoCriminal,
                dataNascimento: new DateTime(1978, 11, 5),
                bonusMensal: 600m,
                carroEmpresa: false,
                isencaoHorario: true
            );
            diretor3.AreasDiretoria.Add("Financeiro");

            // Adicionar diretores à empresa
            empresa.AdicionarFuncionario(diretor1);
            empresa.AdicionarFuncionario(diretor2);
            empresa.AdicionarFuncionario(diretor3);

            // ========== CRIANDO 5 SECRETÁRIAS ==========

            var secretaria1 = new Secretaria(
                id: 4,
                nif: 444555666,
                nome: "Maria Costa",
                morada: "Rua do Comércio, 12, Porto",
                contacto: "915678904",
                salarioBase: 1200m,
                dataIniContrato: inicioContrato,
                dataFimContrato: fimContrato,
                dataFimRegistoCrim: fimRegistoCriminal,
                dataNascimento: new DateTime(1990, 2, 10),
                area: "Recursos Humanos",
                diretorReporta: diretor1
            );
            secretaria1.IdiomasFalados.Add("Português");
            secretaria1.IdiomasFalados.Add("Inglês");

            var secretaria2 = new Secretaria(
                id: 5,
                nif: 555666777,
                nome: "Sofia Pereira",
                morada: "Avenida da Liberdade, 34, Lisboa",
                contacto: "916789015",
                salarioBase: 1300m,
                dataIniContrato: inicioContrato,
                dataFimContrato: fimContrato,
                dataFimRegistoCrim: fimRegistoCriminal,
                dataNascimento: new DateTime(1988, 5, 18),
                area: "Financeiro",
                diretorReporta: diretor1
            );
            secretaria2.IdiomasFalados.Add("Português");
            secretaria2.IdiomasFalados.Add("Espanhol");

            var secretaria3 = new Secretaria(
                id: 6,
                nif: 666777888,
                nome: "Beatriz Fernandes",
                morada: "Rua dos Lusíadas, 56, Coimbra",
                contacto: "917890126",
                salarioBase: 1250m,
                dataIniContrato: inicioContrato,
                dataFimContrato: fimContrato,
                dataFimRegistoCrim: fimRegistoCriminal,
                dataNascimento: new DateTime(1992, 9, 25),
                area: "Formação",
                diretorReporta: diretor2
            );
            secretaria3.IdiomasFalados.Add("Português");
            secretaria3.IdiomasFalados.Add("Inglês");
            secretaria3.IdiomasFalados.Add("Francês");

            var secretaria4 = new Secretaria(
                id: 7,
                nif: 777888999,
                nome: "Catarina Lopes",
                morada: "Travessa das Palmeiras, 78, Faro",
                contacto: "918901237",
                salarioBase: 1150m,
                dataIniContrato: inicioContrato,
                dataFimContrato: fimContrato,
                dataFimRegistoCrim: fimRegistoCriminal,
                dataNascimento: new DateTime(1995, 1, 30),
                area: "Comercial"
                //diretorReporta: diretor2
            );
            secretaria4.IdiomasFalados.Add("Português");

            var secretaria5 = new Secretaria(
                id: 8,
                nif: 888999000,
                nome: "Isabel Rodrigues",
                morada: "Alameda dos Oceanos, 90, Setúbal",
                contacto: "919012348",
                salarioBase: 1280m,
                dataIniContrato: inicioContrato,
                dataFimContrato: fimContrato,
                dataFimRegistoCrim: fimRegistoCriminal,
                dataNascimento: new DateTime(1987, 12, 8),
                area: "Recursos Humanos"
                //diretorReporta: diretor3
            );
            secretaria5.IdiomasFalados.Add("Português");
            secretaria5.IdiomasFalados.Add("Alemão");

            // Adicionar secretárias à empresa
            empresa.AdicionarFuncionario(secretaria1);
            empresa.AdicionarFuncionario(secretaria2);
            empresa.AdicionarFuncionario(secretaria3);
            empresa.AdicionarFuncionario(secretaria4);
            empresa.AdicionarFuncionario(secretaria5);

            // Associar secretárias aos diretores (via método do Diretor)
            diretor1.AdicionarSecretaria(secretaria1);
            diretor1.AdicionarSecretaria(secretaria2);
            diretor2.AdicionarSecretaria(secretaria3);
            diretor2.AdicionarSecretaria(secretaria4);
            diretor3.AdicionarSecretaria(secretaria5);
        }
    }
}

