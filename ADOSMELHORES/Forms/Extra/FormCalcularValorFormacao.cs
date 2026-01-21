using ADOSMELHORES.Modelos;
using System;
using System.Windows.Forms;

namespace ADOSMELHORES.Forms
{
    public partial class FormCalcularValorFormacao : Form
    {
        private Formador formador;

        public FormCalcularValorFormacao(Formador formadorSelecionado)
        {
            InitializeComponent();
            this.formador = formadorSelecionado;
            ConfigurarForm();
        }

        private void ConfigurarForm()
        {
            this.Text = $"Calcular Valor Formação - {formador.Nome}";
            lblFormador.Text = $"Formador: {formador.Nome} ({formador.ValorHora:C}/hora)";
            dtpDataInicio.Value = DateTime.Now;
            dtpDataFim.Value = DateTime.Now.AddDays(5);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                decimal valor = formador.CalcularValorFormacao(dtpDataInicio.Value, dtpDataFim.Value);
                int dias = (dtpDataFim.Value - dtpDataInicio.Value).Days + 1;
                int horas = dias * 6;

                txtResultado.Text = $"Período: {dtpDataInicio.Value:dd/MM/yyyy} a {dtpDataFim.Value:dd/MM/yyyy}\r\n" +
                                  $"Total de dias: {dias}\r\n" +
                                  $"Total de horas (6h/dia): {horas}\r\n" +
                                  $"Valor por hora: {formador.ValorHora:C}\r\n" +
                                  $"\r\nVALOR TOTAL: {valor:C}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao calcular: {ex.Message}", "Erro",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
