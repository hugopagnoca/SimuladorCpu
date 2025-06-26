using SimuladorCpu.Domain.Instruction;
using SimuladorCpu.Domain.SimProcess;
using static System.Console;

namespace SimuladorCpu.Infrastructure.Logging;

public class LogConsoleHandler
{
    public static void AoExecutarInstrucao(ProcessoSimulado processo, Instrucao instrucao, string status)
    {
        switch (instrucao.OpCode)
        {
            case OpCode.HALT:
                ForegroundColor = ConsoleColor.Red;
                break;
            default:
                ForegroundColor = ConsoleColor.Green;
                break;
        }
        WriteLine($"[{processo.Id}] Instrução: {instrucao.OpCode} {string.Join(", ", instrucao.Operandos)}");
        ResetColor();
    }
}