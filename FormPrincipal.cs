using EstacionamentoSimples.DAL;
using EstacionamentoSimples.Models;
using System;
using System.Windows.Forms;

namespace EstacionamentoSimples.Forms
{
    public partial class FormPrincipal : Form
    {
        private RepositorioVeiculo repositorioVeiculo = new RepositorioVeiculo();
        private RepositorioTabelaPreco repositorioTabelaPreco = new RepositorioTabelaPreco();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void btnRegistrarEntrada_Click(object sender, EventArgs e)
        {
            var veiculo = new Veiculo
            {
                Placa = txtPlaca.Text,
                DataEntrada = DateTime.Now
            };
            repositorioVeiculo.AdicionarVeiculo(veiculo);
            MessageBox.Show("Entrada registrada com sucesso!");
        }

        private void btnRegistrarSaida_Click(object sender, EventArgs e)
        {
            var veiculo = repositorioVeiculo.BuscarVeiculoPorPlaca(txtPlaca.Text);
            if (veiculo != null)
            {
                var tabelaPreco = repositorioTabelaPreco.BuscarTabelaPrecoPorData(veiculo.DataEntrada);
                var tempoPermanencia = DateTime.Now - veiculo.DataEntrada;

                decimal valorTotal = CalcularValor(tempoPermanencia, tabelaPreco);

                repositorioVeiculo.RegistrarSaida(veiculo.Placa, DateTime.Now);
                MessageBox.Show($"Saída registrada! Valor a pagar: R${valorTotal:F2}");
            }
            else
            {
                MessageBox.Show("Veículo não encontrado ou já saiu.");
            }
        }

        private decimal CalcularValor(TimeSpan tempoPermanencia, TabelaPreco tabelaPreco)
        {
            decimal valorTotal = 0;

            if (tempoPermanencia.TotalMinutes <= 30)
            {
                valorTotal = tabelaPreco.ValorHoraInicial / 2;
            }
            else
            {
                valorTotal = tabelaPreco.ValorHoraInicial;
                var horasAdicionais = Math.Ceiling((tempoPermanencia.TotalMinutes - 60) / 60);
                valorTotal += Math.Max(0, (decimal)horasAdicionais * tabelaPreco.ValorHoraAdicional);
            }

            return valorTotal;
        }
    }
}
