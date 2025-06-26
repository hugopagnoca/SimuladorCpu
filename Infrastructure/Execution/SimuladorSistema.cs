using SimuladorCpu.Domain.Cpu;
using SimuladorCpu.Domain.Scheduler;

namespace SimuladorCpu.Infrastructure.Execution;

public class SimuladorSistema
{
    private readonly Cpu _cpu;
    private readonly EscalonadorRoundRobin _escalonador;

    public SimuladorSistema(Cpu cpu, EscalonadorRoundRobin escalonador)
    {
        _cpu = cpu;
        _escalonador = escalonador;
    }

    public void Executar()
    {
        while (true)
        {
            var processo = _escalonador.Proximo();
            if (processo is null)
                break;

            Console.WriteLine($"\n=== Executando processo {processo.Id} ===");

            var instrucoesExecutadas = 0;

            while (instrucoesExecutadas < _escalonador.Quantum)
            {
                if (processo.Finalizado)
                    break;

                _cpu.ExecutarCiclo(processo);
                instrucoesExecutadas++;
            }
        }
    }
}