using EstacionamentoSimples.DAL;
using EstacionamentoSimples.Models;
using System;
using System.Windows.Forms;

namespace EstacionamentoSimples.Forms
{
    public partial class FormTabelaPreco : Form
    {
        private RepositorioTabelaPreco repositorioTabelaPreco = new RepositorioTabelaPreco();

        public FormTabelaPreco()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var tabelaPreco = new TabelaPreco
            {
                VigenciaInicio = dtpInicio.Value,
                VigenciaFim = dtpFim.Value,
                ValorHoraInicial = decimal.Parse(txtValorHoraInicial.Text),
                ValorHoraAdicional = decimal.Parse(txtValorHoraAdicional.Text)
            };
            repositorioTabelaPreco.AdicionarTabelaPreco(tabelaPreco);
            MessageBox.Show("Tabela de preços salva com sucesso!");
        }
    }
}
