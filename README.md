# Estacionamento
Um projeto aplicado em Desktop para a criação de um controle de estacionamento, aqui está alguns comentários sobre esses códigos:


## Pasta FORMS

Os seguintes formulários fazem parte do sistema de estacionamento simples:

1. **FormPrincipal**
   - **`btnRegistrarEntrada_Click`**: Registra a entrada de um veículo com base na placa informada, armazenando a data e hora de entrada. Exibe uma mensagem de confirmação.
   - **`btnRegistrarSaida_Click`**: Registra a saída do veículo, calcula o valor a pagar com base no tempo de permanência e na tabela de preços, e exibe uma mensagem com o valor total. Verifica se o veículo está registrado e calcula o valor conforme o tempo de permanência e tabela de preços.
   - **`CalcularValor`**: Calcula o valor total a pagar considerando o tempo de permanência do veículo, a tabela de preços, o valor da hora inicial e as horas adicionais.

   Os dados dos veículos e das tabelas de preço são gerenciados pelas classes `RepositorioVeiculo` e `RepositorioTabelaPreco`.

2. **FormTabelaPreco**
   - **`btnSalvar_Click`**: Coleta os dados da tabela de preços (vigência e valores de hora inicial e adicional) informados no formulário, cria uma instância de `TabelaPreco` e a adiciona ao repositório de tabelas de preços. Após a operação, exibe uma mensagem de confirmação indicando que a tabela de preços foi salva com sucesso.

   Os dados da tabela de preços são gerenciados através da classe `RepositorioTabelaPreco`.



   ## Pasta MODELS

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


  
## Pasta PROGRAM

A classe `Program` é o ponto de entrada principal para a aplicação de Windows Forms no sistema de estacionamento simples. Ela contém:

- **Método `Main`**: O método principal da aplicação, que é o ponto de entrada quando o aplicativo é iniciado.
  - **`Application.EnableVisualStyles()`**: Habilita os estilos visuais do Windows para melhorar a aparência dos controles da interface do usuário.
  - **`Application.SetCompatibleTextRenderingDefault(false)`**: Define o método de renderização de texto compatível para os controles da interface do usuário.
  - **`Application.Run(new FormPrincipal())`**: Inicia a aplicação e exibe o formulário principal (`FormPrincipal`), que é a janela principal da aplicação.

   Este código configura a aplicação para usar os recursos visuais do Windows e inicia o formulário principal da aplicação.
   Esta classe é usada para registrar e gerenciar o período de estacionamento de cada veículo.



   ## Pasta REPOSITORIO

As seguintes classes gerenciam a interação com o banco de dados para o sistema de estacionamento:

1. **RepositorioTabelaPreco**
   - **`connectionString`**: Configura a conexão com o banco de dados MySQL.
   - **`BuscarTabelaPrecoPorData(DateTime data)`**: Recupera uma tabela de preços com base na data fornecida, retornando um objeto `TabelaPreco` se a data estiver dentro do período de vigência.
   - **`AdicionarTabelaPreco(TabelaPreco tabelaPreco)`**: Insere uma nova tabela de preços no banco de dados com os valores especificados.

2. **RepositorioVeiculo**
   - **`connectionString`**: Configura a conexão com o banco de dados MySQL.
   - **`AdicionarVeiculo(Veiculo veiculo)`**: Adiciona um novo veículo ao banco de dados, registrando a placa e a data de entrada.
   - **`RegistrarSaida(string placa, DateTime dataSaida)`**: Atualiza o registro de um veículo para definir a data e hora de saída.
   - **`BuscarVeiculoPorPlaca(string placa)`**: Busca um veículo no banco de dados pela placa, retornando um objeto `Veiculo` se o veículo estiver presente e não tiver saído.

Ambas as classes utilizam a instrução `using` para garantir que a conexão com o banco de dados seja corretamente fechada após o uso, prevenindo vazamentos de recursos.



### MySQL

Para integrar o MySQL ao projeto, siga estas etapas para criar e implementar a pasta `MySQL`:

1. **Criar a Pasta `MySQL`**
   - No seu projeto, crie uma nova pasta chamada `MySQL` (ou `DAL`, se preferir um nome mais genérico) para armazenar as classes responsáveis pela interação com o banco de dados MySQL.
   - Esta pasta conterá classes que gerenciam a conexão e operações com o banco de dados.

2. **Implementar Classes na Pasta `MySQL`**
   - **`RepositorioTabelaPreco`** e **`RepositorioVeiculo`**: Coloque essas classes na pasta `MySQL` para gerenciar as tabelas de preços e veículos no banco de dados.

   **Exemplo de Estrutura de Pastas:**

3. **Configuração do MySQL**
- **Instalar o MySQL Connector**: Certifique-se de que o MySQL Connector para .NET está instalado no seu projeto. Você pode instalar o pacote NuGet `MySql.Data` através do Package Manager Console com o comando:
  ```bash
  Install-Package MySql.Data
  ```
- **Configurar a String de Conexão**: Ajuste a string de conexão em suas classes `RepositorioTabelaPreco` e `RepositorioVeiculo` para corresponder às suas configurações de banco de dados MySQL (servidor, banco de dados, usuário e senha).

4. **Criar o Banco de Dados e Tabelas**
- **Banco de Dados**: No MySQL, crie um banco de dados, por exemplo, `estacionamento`.
- **Tabelas**: Crie as tabelas `Veiculos` e `TabelaPreco` com os esquemas apropriados para armazenar os dados.

**Exemplo de SQL para Criar Tabelas:**
```sql
CREATE TABLE Veiculos (
    Placa VARCHAR(10) PRIMARY KEY,
    DataEntrada DATETIME,
    DataSaida DATETIME
);

CREATE TABLE TabelaPreco (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    VigenciaInicio DATETIME,
    VigenciaFim DATETIME,
    ValorHoraInicial DECIMAL(10, 2),
    ValorHoraAdicional DECIMAL(10, 2)
);





