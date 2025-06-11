using SimuladorCpu.Domain.Instruction;

namespace SimuladorCpu.Domain.SimProcess;

public class ProcessoSimulado
{
    public string Id { get; }
    public int Pc { get; set; }
    public Dictionary<string, int> Registradores { get; }
    public List<Instrucao> Instrucoes { get; }

    public bool Finalizado => Pc >= Instrucoes.Count;

    public ProcessoSimulado(string id, List<Instrucao> instrucoes)
    {
        Id = id;
        Pc = 0;
        Instrucoes = instrucoes;
        Registradores = new Dictionary<string, int> { { "AX", 0 }, { "BX", 0 } };
    }

    public Instrucao? ProximaInstrucao() =>
        Finalizado ? null : Instrucoes[Pc++];
}
