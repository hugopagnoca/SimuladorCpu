namespace SimuladorCpu.Domain.Instruction;

public class Instrucao
{
    public OpCode OpCode { get; }
    public string[] Operandos { get; }

    public Instrucao(OpCode opCode, params string[] operandos)
    {
        OpCode = opCode;
        Operandos = operandos;
    }
}
