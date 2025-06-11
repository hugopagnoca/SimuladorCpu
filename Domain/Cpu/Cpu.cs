using SimuladorCpu.Domain.Instruction;
using SimuladorCpu.Domain.Memory;
using SimuladorCpu.Domain.SimProcess;

namespace SimuladorCpu.Domain.Cpu;

public class Cpu
{
    private readonly Memoria _memoria;

    public Cpu(Memoria memoria)
    {
        _memoria = memoria;
    }
    
    public void ExecutarCiclo(ProcessoSimulado processo)
    {
        var instrucao = processo.ProximaInstrucao();
        if (instrucao is null) return;

        Console.WriteLine($"[{processo.Id}] Executando: {instrucao.Opcode} {string.Join(", ", instrucao.Operandos)}");

        switch (instrucao.Opcode)
        {
            case Opcode.LOAD:
                processo.Registradores[instrucao.Operandos[0]] = int.Parse(instrucao.Operandos[1]);
                break;

            case Opcode.ADD:
                processo.Registradores[instrucao.Operandos[0]] += int.Parse(instrucao.Operandos[1]);
                break;

            case Opcode.STORE:
                var valor = processo.Registradores[instrucao.Operandos[0]];
                _memoria.Write(int.Parse(instrucao.Operandos[1]), valor);
                break;

            case Opcode.HALT:
                Console.WriteLine($"[{processo.Id}] HALT - Finalizado");
                break;
        }
    }
}
