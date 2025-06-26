using SimuladorCpu.Domain.Instruction;
using SimuladorCpu.Domain.Memory;
using SimuladorCpu.Domain.SimProcess;

namespace SimuladorCpu.Domain.Cpu;

public class Cpu
{
    private readonly Memoria _memoria;

    public delegate void InstrucaoExecutadaHandler(ProcessoSimulado processo, Instrucao instrucao, string status);
    public event InstrucaoExecutadaHandler? OnInstrucaoExecutada;

    public Cpu(Memoria memoria)
    {
        _memoria = memoria;
    }

    public void ExecutarCiclo(ProcessoSimulado processo)
    {
        if (processo.Finalizado)
            return;

        var instrucao = processo.InstrucaoAtual();
        if (instrucao is null)
            return;

        // Only invoke for non-HALT instructions
        if (instrucao.OpCode != OpCode.HALT)
            OnInstrucaoExecutada?.Invoke(processo, instrucao, "Executando");

        switch (instrucao.OpCode)
        {
            case OpCode.HALT:
                OnInstrucaoExecutada?.Invoke(processo, instrucao, "Finalizado");
                processo.Finalizar();
                return;
            
            case OpCode.LOAD:
                ExecutarLoad(processo, instrucao);
                break;

            case OpCode.ADD:
                ExecutarAdd(processo, instrucao);
                break;

            case OpCode.STORE:
                ExecutarStore(processo, instrucao);
                break;

            case OpCode.JMP:
                ExecutarJump(processo, instrucao);
                break;
        }
    }

    private static void ExecutarLoad(ProcessoSimulado processo, Instrucao instrucao)
    {
        var valor = ResolverOperando(processo, instrucao.Operandos[1]);
        processo.Registradores[instrucao.Operandos[0]] = valor;
        processo.Avancar();
    }

    private static void ExecutarAdd(ProcessoSimulado processo, Instrucao instrucao)
    {
        var valor = ResolverOperando(processo, instrucao.Operandos[1]);
        processo.Registradores[instrucao.Operandos[0]] += valor;
        processo.Avancar();
    }

    private void ExecutarStore(ProcessoSimulado processo, Instrucao instrucao)
    {
        var valor = processo.Registradores[instrucao.Operandos[0]];
        var endereco = ResolverOperando(processo, instrucao.Operandos[1]);
        _memoria.Write(endereco, valor);
        processo.Avancar();
    }
    
    private static void ExecutarJump(ProcessoSimulado processo, Instrucao instrucao)
    {
        var novoEndereco = ResolverOperando(processo, instrucao.Operandos[0]);
        processo.PularPara(novoEndereco);
    }
    
    private static int ResolverOperando(ProcessoSimulado processo, string operando)
    {
        if (int.TryParse(operando, out var valorLiteral))
            return valorLiteral;

        if (processo.Registradores.TryGetValue(operando, out var valorRegistrador))
            return valorRegistrador;

        throw new ArgumentException($"Operando ou registrador inválido: '{operando}'");
    }
}
