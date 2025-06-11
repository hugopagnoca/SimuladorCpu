using SimuladorCpu.Domain.SimProcess;

namespace SimuladorCpu.Domain.Scheduler;

public class EscalonadorRoundRobin
{
    private readonly Queue<ProcessoSimulado> _fila;

    public EscalonadorRoundRobin(IEnumerable<ProcessoSimulado> processos, int quantum)
    {
        _fila = new Queue<ProcessoSimulado>(processos);
        Quantum = quantum;
    }

    public int Quantum { get; }

    public ProcessoSimulado? Proximo()
    {
        while (_fila.Count is not 0)
        {
            var processo = _fila.Dequeue();

            if (processo.Finalizado)
                continue;

            _fila.Enqueue(processo);
            return processo;
        }

        return null;
    }
}