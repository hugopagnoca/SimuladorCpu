using System.ComponentModel;

namespace SimuladorCpu.Domain.Instruction;

public enum OpCode
{
    [Description("Parar")]
    HALT = 0,
    [Description("No Operation")]
    NOP = 1,
    [Description("Carregar")]
    LOAD = 2,
    [Description("Armazenar")]
    STORE = 3,
    [Description("Adicionar")]
    ADD = 4,
    [Description("Subtrair")]  
    SUB = 5,
    [Description("Pular")]
    JMP = 6,
    [Description("Pular se Zero")]
    JZ = 7,
    [Description("Pular se Não Zero")]
    JNZ = 8
}