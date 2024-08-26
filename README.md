# Estacionamento
Um projeto aplicado em Desktop para a criação de um controle de estacionamento, aqui está alguns comentários sobre esses códigos:


# Pasta FORMS

Os seguintes formulários fazem parte do sistema de estacionamento simples:

1. **FormPrincipal**
   - **`btnRegistrarEntrada_Click`**: Registra a entrada de um veículo com base na placa informada, armazenando a data e hora de entrada. Exibe uma mensagem de confirmação.
   - **`btnRegistrarSaida_Click`**: Registra a saída do veículo, calcula o valor a pagar com base no tempo de permanência e na tabela de preços, e exibe uma mensagem com o valor total. Verifica se o veículo está registrado e calcula o valor conforme o tempo de permanência e tabela de preços.
   - **`CalcularValor`**: Calcula o valor total a pagar considerando o tempo de permanência do veículo, a tabela de preços, o valor da hora inicial e as horas adicionais.

   Os dados dos veículos e das tabelas de preço são gerenciados pelas classes `RepositorioVeiculo` e `RepositorioTabelaPreco`.

2. **FormTabelaPreco**
   - **`btnSalvar_Click`**: Coleta os dados da tabela de preços (vigência e valores de hora inicial e adicional) informados no formulário, cria uma instância de `TabelaPreco` e a adiciona ao repositório de tabelas de preços. Após a operação, exibe uma mensagem de confirmação indicando que a tabela de preços foi salva com sucesso.

   Os dados da tabela de preços são gerenciados através da classe `RepositorioTabelaPreco`.

   ### Pasta MODELS

As seguintes classes representam os modelos de dados no sistema de estacionamento simples:

1. **TabelaPreco**
   - **`VigenciaInicio`**: Data e hora de início da vigência da tabela de preços.
   - **`VigenciaFim`**: Data e hora de término da vigência da tabela de preços.
   - **`ValorHoraInicial`**: Valor cobrado pela primeira hora de estacionamento.
   - **`ValorHoraAdicional`**: Valor cobrado por cada hora adicional de estacionamento além da primeira.

   Esta classe é usada para gerenciar e armazenar as regras de preços aplicáveis durante um período específico.

2. **Veiculo**
   - **`Placa`**: A placa do veículo, usada para identificação e busca.
   - **`DataEntrada`**: Data e hora em que o veículo entrou no estacionamento.
   - **`DataSaida`**: Data e hora em que o veículo saiu do estacionamento. Esta propriedade é opcional e pode ser `null` se o veículo ainda estiver no estacionamento.

   Esta classe é usada para registrar e gerenciar o período de estacionamento de cada veículo.



