# Estacionamento
Um projeto aplicado em Desktop para a criação de um controle de estacionamento, aqui está alguns comentários sobre esses códigos:

###FORMS

## Comentário sobre o Código

Este código implementa a funcionalidade principal de um formulário para registrar a entrada e saída de veículos em um sistema de estacionamento simples. Ele inclui:

- **`btnRegistrarEntrada_Click`**: Registra a entrada de um veículo com base na placa informada e armazena a data e hora de entrada.
- **`btnRegistrarSaida_Click`**: Registra a saída do veículo, calcula o valor a pagar com base no tempo de permanência e na tabela de preços, e exibe uma mensagem com o valor total.
- **`CalcularValor`**: Calcula o valor total a pagar com base no tempo de permanência do veículo e na tabela de preços, considerando o valor da hora inicial e as horas adicionais.

Os dados dos veículos e das tabelas de preço são gerenciados através das classes `RepositorioVeiculo` e `RepositorioTabelaPreco`.

