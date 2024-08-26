using System;

namespace EstacionamentoSimples.Models
{
    public class Veiculo
    {
        public string Placa { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
    }
}