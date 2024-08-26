using System;

namespace EstacionamentoSimples.Models
{
    public class TabelaPreco
    {
        public DateTime VigenciaInicio { get; set; }
        public DateTime VigenciaFim { get; set; }
        public decimal ValorHoraInicial { get; set; }
        public decimal ValorHoraAdicional { get; set; }
    }
}
