# Estacionamento
Um projeto aplicado em Desktop para a criação de um controle de estacionamento, aqui está alguns comentários sobre esses códigos:


### Pasta Forms

Os seguintes formulários fazem parte do sistema de estacionamento simples:

1. **FormPrincipal**
   - **`btnRegistrarEntrada_Click`**: Registra a entrada de um veículo com base na placa informada, armazenando a data e hora de entrada. Exibe uma mensagem de confirmação.
   - **`btnRegistrarSaida_Click`**: Registra a saída do veículo, calcula o valor a pagar com base no tempo de permanência e na tabela de preços, e exibe uma mensagem com o valor total. Verifica se o veículo está registrado e calcula o valor conforme o tempo de permanência e tabela de preços.
   - **`CalcularValor`**: Calcula o valor total a pagar considerando o tempo de permanência do veículo, a tabela de preços, o valor da hora inicial e as horas adicionais.

   Os dados dos veículos e das tabelas de preço são gerenciados pelas classes `RepositorioVeiculo` e `RepositorioTabelaPreco`.

2. **FormTabelaPreco**
   - **`btnSalvar_Click`**: Coleta os dados da tabela de preços (vigência e valores de hora inicial e adicional) informados no formulário, cria uma instância de `TabelaPreco` e a adiciona ao repositório de tabelas de preços. Após a operação, exibe uma mensagem de confirmação indicando que a tabela de preços foi salva com sucesso.

   Os dados da tabela de preços são gerenciados através da classe `RepositorioTabelaPreco`.


