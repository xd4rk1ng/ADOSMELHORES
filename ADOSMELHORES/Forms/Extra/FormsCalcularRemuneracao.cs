using ADOSMELHORES.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ADOSMELHORES.Forms
{
    public partial class FormsCalcularRemuneracao : Form
    {
        private Diretor diretor;
        private Empresa empresa;

        public FormsCalcularRemuneracao(Empresa empresa)
        {
            this.empresa = empresa;
        }

        public FormsCalcularRemuneracao(Diretor diretorSelecionado, Empresa empresaRef)
        {
            InitializeComponent();
            diretor = diretorSelecionado;
            empresa = empresaRef;
            CarregarDadosDiretor();
        }

        private void CarregarDadosDiretor()
        {
            if (diretor == null)
            {
                MessageBox.Show("Nenhum diretor selecionado.", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            // Carregar dados básicos
            lblNomeDiretor.Text = diretor.Nome;
            lblSalarioBase.Text = $"{diretor.SalarioBase:C2}";
            lblSecretarias.Text = diretor.SecretariasSubordinadas.Count.ToString();

            // Carregar áreas de direção
            lblAreasDiretoria.Text = diretor.AreasDiretoria != null && diretor.AreasDiretoria.Count > 0
                ? string.Join(", ", diretor.AreasDiretoria)
                : "Nenhuma área atribuída";

            // Carregar configurações atuais
            chkCarroEmpresa.Checked = diretor.CarroEmpresa;
            chkIsencaoHorario.Checked = diretor.IsencaoHorario;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Atualizar as configurações no objeto diretor
                diretor.CarroEmpresa = chkCarroEmpresa.Checked;
                diretor.IsencaoHorario = chkIsencaoHorario.Checked;

                // Calcular o bônus mensal
                decimal bonusCalculado = CalcularBonusMensal();

                // Calcular o salário total
                decimal salarioTotal = diretor.SalarioBase + bonusCalculado;

                // Atualizar o bônus no objeto diretor
                diretor.BonusMensal = bonusCalculado;

                // Exibir o resultado detalhado
                ExibirResultado(bonusCalculado, salarioTotal);

                // Atualizar na empresa (se necessário)
                // empresa.AtualizarDiretor(diretor);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao calcular remuneração: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private decimal CalcularBonusMensal()
        {
            decimal bonus = 0;

            // 1. Bônus por áreas de direção (200€ por área)
            int areasDiretoria = diretor.AreasDiretoria?.Count ?? 0;
            bonus += areasDiretoria * 200;

            // 2. Bônus por secretárias subordinadas (30€ por secretária)
            int secretariasSubordinadas = diretor.SecretariasSubordinadas?.Count ?? 0;
            bonus += secretariasSubordinadas * 30;

            // 3. Desconto por carro da empresa (-300€)
            if (diretor.CarroEmpresa)
            {
                bonus -= 300;
            }

            // 4. Bônus por isenção de horário (+200€)
            if (diretor.IsencaoHorario)
            {
                bonus += 200;
            }

            // Garantir que o bônus não seja negativo
            return Math.Max(bonus, 0);
        }

        private void ExibirResultado(decimal bonusCalculado, decimal salarioTotal)
        {
            string resultado = "═══════════════════════════════════════════════\n";
            resultado += "            CÁLCULO DE REMUNERAÇÃO\n";
            resultado += "═══════════════════════════════════════════════\n\n";

            resultado += $"📋 DADOS DO DIRETOR:\n";
            resultado += $"   • Nome: {diretor.Nome}\n";
            resultado += $"   • Áreas de Direção: {areasDiretoria} área(s)\n";
            resultado += $"   • Secretárias Subordinadas: {diretor.SecretariasSubordinadas.Count}\n\n";

            resultado += $"💰 SALÁRIO BASE: {diretor.SalarioBase:C2}\n\n";

            resultado += $"➕ BÔNUS CALCULADO: {bonusCalculado:C2}\n";
            resultado += $"   └── Detalhamento:\n";

            // Detalhamento do bônus
            int areas = diretor.AreasDiretoria?.Count ?? 0;
            int secretarias = diretor.SecretariasSubordinadas?.Count ?? 0;

            if (areas > 0)
                resultado += $"       • {areas} área(s) de direção: +{areas * 200:C2}\n";

            if (secretarias > 0)
                resultado += $"       • {secretarias} secretária(s): +{secretarias * 30:C2}\n";

            if (diretor.CarroEmpresa)
                resultado += $"       • Carro empresa: -300,00€\n";

            if (diretor.IsencaoHorario)
                resultado += $"       • Isenção horário: +200,00€\n";

            resultado += $"\n";
            resultado += $"═══════════════════════════════════════════════\n";
            resultado += $"💶 REMUNERAÇÃO TOTAL: {salarioTotal:C2}\n";
            resultado += $"═══════════════════════════════════════════════\n\n";

            resultado += $"⚙️ CONFIGURAÇÕES APLICADAS:\n";
            resultado += $"   • Carro empresa: {(diretor.CarroEmpresa ? "SIM" : "NÃO")}\n";
            resultado += $"   • Isenção horário: {(diretor.IsencaoHorario ? "SIM" : "NÃO")}\n";

            txtResultado.Text = resultado;
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Propriedade para acessar o número de áreas
        private int areasDiretoria
        {
            get { return diretor.AreasDiretoria?.Count ?? 0; }
        }
    }
}
