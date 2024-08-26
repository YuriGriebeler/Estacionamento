using EstacionamentoSimples.Models;
using MySql.Data.MySqlClient;
using System;

namespace EstacionamentoSimples.DAL
{
    public class RepositorioTabelaPreco
    {
      private string connectionString = "Server=localhost;Database=estacionamento;User ID=seu_usuario;Password=sua_senha;Pooling=true;";


        public TabelaPreco BuscarTabelaPrecoPorData(DateTime data)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM TabelaPreco WHERE @Data BETWEEN VigenciaInicio AND VigenciaFim";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Data", data);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new TabelaPreco
                        {
                            VigenciaInicio = DateTime.Parse(reader["VigenciaInicio"].ToString()),
                            VigenciaFim = DateTime.Parse(reader["VigenciaFim"].ToString()),
                            ValorHoraInicial = decimal.Parse(reader["ValorHoraInicial"].ToString()),
                            ValorHoraAdicional = decimal.Parse(reader["ValorHoraAdicional"].ToString())
                        };
                    }
                }
            }
            return null;
        }

        public void AdicionarTabelaPreco(TabelaPreco tabelaPreco)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO TabelaPreco (VigenciaInicio, VigenciaFim, ValorHoraInicial, ValorHoraAdicional) VALUES (@VigenciaInicio, @VigenciaFim, @ValorHoraInicial, @ValorHoraAdicional)";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@VigenciaInicio", tabelaPreco.VigenciaInicio);
                command.Parameters.AddWithValue("@VigenciaFim", tabelaPreco.VigenciaFim);
                command.Parameters.AddWithValue("@ValorHoraInicial", tabelaPreco.ValorHoraInicial);
                command.Parameters.AddWithValue("@ValorHoraAdicional", tabelaPreco.ValorHoraAdicional);
                command.ExecuteNonQuery();
            }
        }
    }
}
