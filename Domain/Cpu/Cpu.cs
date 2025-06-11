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

    public void Executar(ProcessoSimulado processo)
    {
        while (!processo.Finalizado)
        {
            var instrucao = processo.ProximaInstrucao();
            if (instrucao is null) break;

            Console.WriteLine($"[CPU] Executando: {instrucao.Opcode} {string.Join(", ", instrucao.Operandos)}");

            switch (instrucao.Opcode)
            {
                case Opcode.LOAD:
                    processo.Registradores[instrucao.Operandos[0]] = int.Parse(instrucao.Operandos[1]);
                    break;
                case Opcode.ADD:
                    processo.Registradores[instrucao.Operandos[0]] += int.Parse(instrucao.Operandos[1]);
                    break;
                case Opcode.STORE:
                    _memoria.Write(int.Parse(instrucao.Operandos[1]), processo.Registradores[instrucao.Operandos[0]]);
                    break;
                case Opcode.HALT:
                    Console.WriteLine("[CPU] HALT - Processo finalizado");
                    return;
            }
        }
    }
}
