using ADOSMELHORES.Forms;
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
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //instanciando Empresa e passando para FormInicial
            var empresa = new Empresa("ADOSMELHORES");

            CarregarDadosTeste(empresa);
            CarregarDadosDespesasExemplo(empresa);

            var login = new FormLogin();

            while (true) {
                // mostra o form de login, espera validação
                if (login.ShowDialog() == DialogResult.OK)
                    Application.Run(new Forms.FormInicialWIP(empresa));
                // se tentar novamente, reabre o form de login
                else if (login.DialogResult == DialogResult.Retry)
                    continue;
                // se sair do form, termina execução
                else if (login.DialogResult == DialogResult.Cancel)
                    break;
            }
        }
                      

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
            //diretor3.AdicionarSecretaria(secretaria5);

            // ========== CRIANDO 2 COORDENADORES ==========
            var coordenador1 = new Coordenador(
                id: 9,
                nif: 308111222,
                nome: "Rui Almeida",
                morada: "Rua do Mercado, 10, Porto",
                contacto: "920111222",
                salarioBase: 1800m,
                dataIniContrato: inicioContrato,
                dataFimContrato: fimContrato,
                dataFimRegistoCrim: fimRegistoCriminal,
                areaCoordenacao: "Formação"
            );

            var coordenador2 = new Coordenador(
                id: 10,
                nif: 299333444,
                nome: "Patrícia Gomes",
                morada: "Rua das Acácias, 45, Coimbra",
                contacto: "921333444",
                salarioBase: 1750m,
                dataIniContrato: inicioContrato,
                dataFimContrato: fimContrato,
                dataFimRegistoCrim: fimRegistoCriminal,
                areaCoordenacao: "Comercial"
            );

            empresa.AdicionarFuncionario(coordenador1);
            empresa.AdicionarFuncionario(coordenador2);

            // ========== CRIANDO 5 FORMADORES ==========
            var formadores = new List<Formador>
            {
                new Formador(
                    id: 11,
                    nif: 101101101,
                    nome: "Pedro Nunes",
                    morada: "Rua da Alegria, 1, Braga",
                    contacto: "930111222",
                    salarioBase: 0m,
                    dataIniContrato: inicioContrato,
                    dataFimContrato: fimContrato,
                    dataFimRegistoCrim: fimRegistoCriminal,
                    areaLeciona: "Programação C#",
                    disponibilidade: Disponibilidade.Laboral,
                    valorHora: 25m
                ),
                new Formador(
                    id: 12,
                    nif: 202202202,
                    nome: "Marta Oliveira",
                    morada: "Largo do Carmo, 5, Lisboa",
                    contacto: "931222333",
                    salarioBase: 0m,
                    dataIniContrato: inicioContrato,
                    dataFimContrato: fimContrato,
                    dataFimRegistoCrim: fimRegistoCriminal,
                    areaLeciona: "Gestão de Projetos",
                    disponibilidade: Disponibilidade.PosLaboral,
                    valorHora: 30m
                ),
                new Formador(
                    id: 13,
                    nif: 303303303,
                    nome: "Bruno Costa",
                    morada: "Av. do Sol, 77, Faro",
                    contacto: "932333444",
                    salarioBase: 0m,
                    dataIniContrato: inicioContrato,
                    dataFimContrato: fimContrato,
                    dataFimRegistoCrim: fimRegistoCriminal,
                    areaLeciona: "Marketing Digital",
                    disponibilidade: Disponibilidade.Ambas,
                    valorHora: 28m
                ),
                new Formador(
                    id: 14,
                    nif: 247404404,
                    nome: "Inês Ferreira",
                    morada: "Rua Nova, 9, Setúbal",
                    contacto: "933444555",
                    salarioBase: 0m,
                    dataIniContrato: inicioContrato,
                    dataFimContrato: fimContrato,
                    dataFimRegistoCrim: fimRegistoCriminal,
                    areaLeciona: "Qualidade e Auditoria",
                    disponibilidade: Disponibilidade.Laboral,
                    valorHora: 22.5m
                ),
                new Formador(
                    id: 15,
                    nif: 189505505,
                    nome: "Rita Marques",
                    morada: "Rua das Oliveiras, 20, Porto",
                    contacto: "934555666",
                    salarioBase: 0m,
                    dataIniContrato: inicioContrato,
                    dataFimContrato: fimContrato,
                    dataFimRegistoCrim: fimRegistoCriminal,
                    areaLeciona: "Excel Avançado",
                    disponibilidade: Disponibilidade.PosLaboral,
                    valorHora: 20m
                )
            };

            foreach (var f in formadores)
            {
                empresa.AdicionarFuncionario(f);
            }

            // ========== ALOCAR FORMADORES AOS COORDENADORES (aleatório) ==========
            var coordenadores = empresa.Funcionarios.OfType<Coordenador>().ToList();
            var rng = new Random();

            foreach (var f in formadores)
            {
                // escolhe aleatoriamente um dos coordenadores e adiciona
                var escolhido = coordenadores[rng.Next(coordenadores.Count)];
                escolhido.AdicionarFormador(f);
            }
        }

        
        /// Meses: Novembro 2025, Dezembro 2025, Janeiro 2026
        private static void CarregarDadosDespesasExemplo(Empresa empresa)
        {
            empresa.GestorDespesas.CarregarDadosExemplo();
        }
    }
}

