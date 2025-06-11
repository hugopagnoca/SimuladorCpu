using SimuladorCpu.Domain.Cpu;
using SimuladorCpu.Domain.Instruction;
using SimuladorCpu.Domain.Memory;
using SimuladorCpu.Domain.Scheduler;
using SimuladorCpu.Domain.SimProcess;
using SimuladorCpu.Infrastructure.Execution;

// criar memória
var memoria = new Memoria();

// criar CPU
var cpu = new Cpu(memoria);

// criar processos com instruções
var processo1 = new ProcessoSimulado("P1", new List<Instrucao>
{
    new Instrucao(Opcode.LOAD, ["R1", "10"]),
    new Instrucao(Opcode.ADD, ["R1", "5"]),
    new Instrucao(Opcode.STORE, ["R1", "0"]),
    new Instrucao(Opcode.HALT)
});

var processo2 = new ProcessoSimulado("P2", new List<Instrucao>
{
    new Instrucao(Opcode.LOAD, ["R2", "20"]),
    new Instrucao(Opcode.ADD, ["R2", "10"]),
    new Instrucao(Opcode.STORE, ["R2", "1"]),
    new Instrucao(Opcode.HALT)
});

// criar escalonador com quantum de 2
var escalonador = new EscalonadorRoundRobin(new[] { processo1, processo2 }, quantum: 2);

// criar simulador de sistema
var simulador = new SimuladorSistema(cpu, escalonador);

// executar simulação
simulador.Executar();