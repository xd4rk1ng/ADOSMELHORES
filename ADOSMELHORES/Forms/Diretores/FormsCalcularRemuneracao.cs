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

namespace ADOSMELHORES.Forms.Diretores
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
                decimal bonusCalculado = diretor.CalcularBonusMensal();

                // Calcular o salário total
                decimal salarioTotal = diretor.SalarioBase + bonusCalculado;

                // Atualizar o bônus no objeto diretor
                diretor.BonusMensal = bonusCalculado;

                // Exibir o resultado detalhado
                ExibirResultado(bonusCalculado, salarioTotal);               
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao calcular remuneração: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
        private void ExibirResultado(decimal bonusCalculado, decimal salarioTotal)
        {
            StringBuilder resultado = new StringBuilder();
            
            resultado.AppendLine("═══════════════════════════════════════════════════════════════");
            resultado.AppendLine("       CÁLCULO DE REMUNERAÇÃO DO DIRETOR        ");
            resultado.AppendLine("═══════════════════════════════════════════════════════════════");
            resultado.AppendLine();
                        
            resultado.AppendLine("📋 DADOS DO DIRETOR:");            
            resultado.AppendLine($"   Nome: {diretor.Nome}");
            resultado.AppendLine($"   Áreas de Direção: {areasDiretoria} área(s)");
            resultado.AppendLine($"   Secretárias Subordinadas: {diretor.SecretariasSubordinadas.Count}");
            resultado.AppendLine();

            resultado.AppendLine("💰 SALÁRIO BASE:");
            resultado.AppendLine($"   $ {diretor.SalarioBase:N2}");
            resultado.AppendLine();

            resultado.AppendLine("➕ BÔNUS MENSAL CALCULADO:");

            int areas = diretor.AreasDiretoria?.Count ?? 0;
            int secretarias = diretor.SecretariasSubordinadas?.Count ?? 0;

            if (areas > 0)
            {
                resultado.AppendLine($"   • {areas} área(s) de direção:");
                resultado.AppendLine($"     {areas} × 200,00€ = + {areas * 200:N2} €");
            }

            if (secretarias > 0)
            {
                resultado.AppendLine($"   • {secretarias} secretária(s):");
                resultado.AppendLine($"     {secretarias} × 30,00 € = +{secretarias * 30:N2} €");
            }

            if (diretor.IsencaoHorario)
            {
                resultado.AppendLine($"   • Isenção de horário:");
                resultado.AppendLine($"     + 200,00 €");
            }

            if (!diretor.CarroEmpresa)
            {
                resultado.AppendLine($"   • Sem carro empresa (bônus):");
                resultado.AppendLine($"     + 300,00 €");
            }
            else
            {
                resultado.AppendLine($"   • Com carro empresa (sem bônus adicional):");                
            }

            resultado.AppendLine();
            resultado.AppendLine($"   Subtotal de Bônus: {bonusCalculado:N2} €");
            resultado.AppendLine();

            resultado.AppendLine("═══════════════════════════════════════════════════════");
            resultado.AppendLine($"  💶 REMUNERAÇÃO TOTAL: {salarioTotal:N2} €".PadRight(54) + "");
            resultado.AppendLine("═══════════════════════════════════════════════════════");
            resultado.AppendLine();

            txtResultado.Text = resultado.ToString();
        }               
              

        // Propriedade para acessar o número de áreas
        private int areasDiretoria
        {
            get { return diretor.AreasDiretoria?.Count ?? 0; }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar se já foi calculado
                if (diretor.BonusMensal == 0)
                {
                    MessageBox.Show("Por favor, calcule a remuneração primeiro!", "Aviso",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Confirmar se deseja gravar
                var resultado = MessageBox.Show(
                    $"Deseja gravar os valores de remuneração para o Diretor {diretor.Nome}?",
                    "Confirmar Remuneração",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Retornar OK para indicar que foi confirmado
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gravar remuneração: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {            
            this.Close();
        }
    }
}
