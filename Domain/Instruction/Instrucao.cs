namespace SimuladorCpu.Domain.Instruction;

public class Instrucao
{
    public Opcode Opcode { get; }
    public string[] Operandos { get; }

    public Instrucao(Opcode opcode, params string[] operandos)
    {
        Opcode = opcode;
        Operandos = operandos;
    }
}
