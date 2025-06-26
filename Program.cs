using SimuladorCpu.Domain.Cpu;
using SimuladorCpu.Domain.Instruction;
using SimuladorCpu.Domain.Memory;
using SimuladorCpu.Domain.Scheduler;
using SimuladorCpu.Domain.SimProcess;
using SimuladorCpu.Infrastructure.Execution;
using SimuladorCpu.Infrastructure.Logging;

var memoria = new Memoria();
var cpu = new Cpu(memoria);

cpu.OnInstrucaoExecutada += LogConsoleHandler.AoExecutarInstrucao;

// carga de Processos 
var processo1 = new ProcessoSimulado("P1",
[
    new Instrucao(OpCode.LOAD, ["AX", "10"]),
    new Instrucao(OpCode.ADD, ["AX", "5"]),
    new Instrucao(OpCode.STORE, ["AX", "100"]),
    new Instrucao(OpCode.HALT)
]);

var processo2 = new ProcessoSimulado("P2",
[
    new Instrucao(OpCode.LOAD, ["BX", "99"]),
    new Instrucao(OpCode.STORE, ["BX", "101"]),
    new Instrucao(OpCode.HALT)
]);

var processos = new[] { processo1, processo2 };

var escalonador = new EscalonadorRoundRobin(processos, quantum: 2);
var simulador = new SimuladorSistema(cpu, escalonador);

simulador.Executar();
Console.WriteLine("\n--- Finalizado ---");

Console.WriteLine($"\nValor na memória [100]: {memoria.Read(100)}");
Console.WriteLine($"Valor na memória [101]: {memoria.Read(101)}");