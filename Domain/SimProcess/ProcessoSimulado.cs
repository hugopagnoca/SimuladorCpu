using SimuladorCpu.Domain.Instruction;

namespace SimuladorCpu.Domain.SimProcess;

public class ProcessoSimulado
{
    public string Id { get; }
    public Dictionary<string, int> Registradores { get; }
    public bool Finalizado => _encerrado || Pc >= Instrucoes.Count;

    private int Pc { get; set; }
    private List<Instrucao> Instrucoes { get; }
    private bool _encerrado = false;

    public ProcessoSimulado(string id, List<Instrucao> instrucoes)
    {
        Id = id;
        Pc = 0;
        Instrucoes = instrucoes;
        Registradores = new Dictionary<string, int> { { "AX", 0 }, { "BX", 0 } };
    }

    public Instrucao? InstrucaoAtual() =>
        Finalizado ? null : Instrucoes[Pc];

    public void Avancar()
    {
        if (!Finalizado)
            Pc++;
    }

    public void Finalizar()
    {
        _encerrado = true;
    }

    public void PularPara(int novoEndereco)
    {
        Pc = novoEndereco;
    }
}