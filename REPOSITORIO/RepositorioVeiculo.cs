using EstacionamentoSimples.Models;
using MySql.Data.MySqlClient;
using System;

namespace EstacionamentoSimples.DAL
{
    public class RepositorioVeiculo
    {
        private string connectionString = "Server=localhost;Database=estacionamento;User ID=seu_usuario;Password=sua_senha;Pooling=true;";

        public void AdicionarVeiculo(Veiculo veiculo)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Veiculos (Placa, DataEntrada) VALUES (@Placa, @DataEntrada)";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Placa", veiculo.Placa);
                command.Parameters.AddWithValue("@DataEntrada", veiculo.DataEntrada);
                command.ExecuteNonQuery();
            }
        }

        public void RegistrarSaida(string placa, DateTime dataSaida)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Veiculos SET DataSaida = @DataSaida WHERE Placa = @Placa";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@DataSaida", dataSaida);
                command.Parameters.AddWithValue("@Placa", placa);
                command.ExecuteNonQuery();
            }
        }

        public Veiculo BuscarVeiculoPorPlaca(string placa)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Veiculos WHERE Placa = @Placa AND DataSaida IS NULL";
                var command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Placa", placa);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Veiculo
                        {
                            Placa = reader["Placa"].ToString(),
                            DataEntrada = DateTime.Parse(reader["DataEntrada"].ToString())
                        };
                    }
                }
            }
            return null;
        }
    }
}