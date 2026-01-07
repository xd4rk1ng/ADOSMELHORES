using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ADOSMELHORES.Modelos
{
    public class Empresa
    {
        public List<Funcionario> funcionarios;
        public string Nome { get; set; }
        public DateTime DataSimulada { get; set; }

        public List<Coordenador> Coordenadores => Funcionarios.OfType<Coordenador>().ToList();
        public List<Formador> Formadores => Funcionarios.OfType<Formador>().ToList();

        public Empresa(string nome)
        {
            Nome = nome;
            funcionarios = new List<Funcionario>();
            DataSimulada = DateTime.Now.Date;
        }

        public int ObterProximoID()
        {
            return funcionarios.Any() ? funcionarios.Max(f => f.Id) + 1 : 1;
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            funcionarios.Add(funcionario);
        }

        public void AdicionarFuncionario(Formador novoFormador)
        {
            funcionarios.Add(novoFormador);
        }

        public void RemoverFuncionario(Formador formadorSelecionado)
        {
            funcionarios.Remove(formadorSelecionado);
        }

        public void RemoverFuncionario(Funcionario funcionario)
        {
            if (funcionario == null)
                return;

            // Tenta remover por referência da lista interna
            if (this.funcionarios != null)
            {
                bool removed = this.funcionarios.Remove(funcionario);

                // Se não removeu por referência, tenta localizar pelo Id e remover
                if (!removed)
                {
                    for (int i = this.funcionarios.Count - 1; i >= 0; i--)
                    {
                        if (this.funcionarios[i].Id == funcionario.Id)
                        {
                            this.funcionarios.RemoveAt(i);
                            removed = true;
                            break;
                        }
                    }
                }
            }

            // Se houver listas específicas mantenha-as sincronizadas
            if (funcionario is Coordenador coord && this.Coordenadores != null)
            {
                this.Coordenadores.Remove(coord);
            }
            else if (funcionario is Formador form && this.Formadores != null)
            {
                this.Formadores.Remove(form);
            }
        }

        public List<Funcionario> ObterFuncionariosContratoValido(DateTime data)
        {
            return funcionarios.Where(f => f.ContratoValido(data)).ToList();
        }

        public List<Funcionario> ObterFuncionariosRegistoCriminalExpirado(DateTime data)
        {
            return funcionarios.Where(f => f.RegistoCriminalExpirado(data)).ToList();
        }

        public List<Coordenador> ObterCoordenadores()
        {
            // Considerando que Coordenador herda de Funcionario
            return funcionarios.OfType<Coordenador>().ToList();
        }

        public decimal CalcularDespesaMensal()
        {
            return funcionarios.Sum(f => f.CalcularCustoMensal());
        }

        public List<string> AvancarDia()
        {
            DataSimulada = DataSimulada.AddDays(1);
            List<string> alertas = new List<string>();

            foreach (var funcionario in funcionarios)
            {
                if (funcionario.DataFimContrato.Date == DataSimulada)
                {
                    alertas.Add($"ALERTA: Contrato de {funcionario.Nome} termina hoje!");
                }

                if (funcionario.DataFimRegistoCrim.Date == DataSimulada)
                {
                    alertas.Add($"ALERTA: Registo criminal de {funcionario.Nome} expira hoje!");
                }
            }

            return alertas;
        }

        public void ExportarParaCSV(string caminhoFicheiro)
        {
            StringBuilder csv = new StringBuilder();

            csv.AppendLine("ID;Nome;Tipo;Morada;Contacto;Data Fim Contrato;Data Registo Criminal;Salário Base;Informações Adicionais");

            foreach (var funcionario in funcionarios)
            {
                string infoAdicional = "";

                if (funcionario is Diretor diretor)
                {
                    infoAdicional = $"Bónus: {diretor.BonusMensal}; Carro: {(diretor.CarroEmpresa ? "Sim" : "Não")}";
                }
                else if (funcionario is Secretaria secretaria)
                {
                    infoAdicional = $"Área: {secretaria.Area}; Reporta a: {secretaria.DiretorReporta?.Nome ?? "N/A"}";
                }
                else if (funcionario is Formador formador)
                {
                    infoAdicional = $"Área: {formador.AreaLeciona}; Disponibilidade: {formador.Disponibilidade}; Valor/Hora: {formador.ValorHora}";
                }
                else if (funcionario is Coordenador coordenador)
                {
                    infoAdicional = $"Área: {coordenador.AreaCoordenacao}; Formadores: {coordenador.NumeroFormadores}";
                }

                csv.AppendLine($"{funcionario.Id};{funcionario.Nome};{funcionario.GetType().Name};" +
                    $"{funcionario.Morada};{funcionario.Contacto};" +
                    $"{funcionario.DataFimContrato:dd/MM/yyyy};{funcionario.DataFimRegistoCrim:dd/MM/yyyy};" +
                    $"{funcionario.SalarioBase};{infoAdicional}");
            }

            File.WriteAllText(caminhoFicheiro, csv.ToString(), Encoding.UTF8);
        }

        public List<Funcionario> Funcionarios
        {
            get { return funcionarios; }
        }
    }
}
