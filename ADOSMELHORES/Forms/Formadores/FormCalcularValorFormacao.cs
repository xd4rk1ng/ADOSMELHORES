using ADOSMELHORES.Modelos;
using ADOSMELHORES.Validacoes;
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

            // Definir valores seguros usando DateTimeHelper
            DateTimeHelper.DefinirValorSeguro(dtpDataInicio, DateTime.Now.Date);
            DateTimeHelper.DefinirValorSeguro(dtpDataFim, DateTime.Now.Date.AddDays(5));
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                // Normalizar datas (ignorar componente hora)
                var inicio = dtpDataInicio.Value.Date;
                var fim = dtpDataFim.Value.Date;

                // Validar ordem de datas (permitir igual, impedir fim anterior)
                ResultadoValidacao ordenacao;
                if (fim < inicio)
                {
                    ordenacao = ResultadoValidacao.Erro("Data final não pode ser anterior à data inicial", "Data Inválida");
                }
                else
                {
                    ordenacao = ResultadoValidacao.Sucesso();
                }

                if (!ordenacao.Valido)
                {
                    ordenacao.MostrarMensagem();
                    return;
                }

                // Calcular usando dias úteis (consistente com Formador.CalcularValorFormacao)
                int diasUteis = DateTimeHelper.CountBusinessDays(inicio, fim);
                int horas = diasUteis * 6;
                decimal valor = formador.CalcularValorFormacao(inicio, fim);

                txtResultado.Text = $"Período: {inicio:dd/MM/yyyy} a {fim:dd/MM/yyyy}\r\n" +
                                  $"Total de dias úteis: {diasUteis}\r\n" +
                                  $"Total de horas (6h/dia): {horas}\r\n" +
                                  $"Valor por hora: {formador.ValorHora:C}\r\n" +
                                  $"\r\nVALOR TOTAL: {valor:C}";
            }
            catch (Exception ex)
            {
                DialogHelper.ErroOperacao("calcular valor da formação", ex);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
