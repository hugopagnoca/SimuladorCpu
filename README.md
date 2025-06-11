# Simulador de CPU — Round-Robin

Este simulador representa uma CPU simplificada executando processos por meio de um escalonador do tipo **Round-Robin**, respeitando um quantum fixo de tempo.

---

## O que é um Opcode?

**Opcode** (Operation Code) = **código da operação** que a CPU deve executar.

É o "verbo" de cada instrução. Exemplo:

| Opcode | Descrição |
|--------|-----------|
| `LOAD` | Carrega um valor em um registrador |
| `ADD`  | Soma um valor a um registrador |
| `STORE` | Armazena o valor de um registrador na memória |
| `JMP` | Altera o fluxo de execução, pulando para outra instrução |
| `HALT` | Finaliza o processo atual |

No mundo real (ex: x86, ARM), cada opcode é representado por um **número binário** (ex: `00011010`).  
Neste simulador, usamos `enum` para manter as instruções legíveis.

---

## Estrutura de uma instrução

Cada instrução é composta por:

- **Opcode**: qual operação será realizada
- **Operandos**: os alvos da operação (registradores, constantes ou endereços de memória)

Exemplo:

```asm
LOAD R1, 10
```

> Interpretação: carregue o valor `10` no registrador `R1`.

---

## Ciclo de execução

A simulação segue o seguinte fluxo:

1. Um processo é selecionado pelo escalonador.
2. A CPU executa até **N instruções** (quantum).
3. O processo é interrompido (caso não finalize).
4. O próximo processo é executado.
5. Repete até que todos finalizem.
