using SimuladorCpu.Domain.Instruction;
using SimuladorCpu.Domain.SimProcess;
using SimuladorCpu.Domain.Memory;
using SimuladorCpu.Domain.Cpu;

var memoria = new Memoria();

var instrucoes = new List<Instrucao>
{
    new(Opcode.LOAD, "AX", "10"),
    new(Opcode.ADD, "AX", "5"),
    new(Opcode.STORE, "AX", "100"),
    new(Opcode.HALT)
};

var processo = new ProcessoSimulado("P1", instrucoes);

var cpu = new Cpu(memoria);
cpu.Executar(processo);

Console.WriteLine($"[MEMÓRIA] Endereço 100 => {memoria.Read(100)}");