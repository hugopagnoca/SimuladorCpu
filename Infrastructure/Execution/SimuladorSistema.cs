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
            if (processo == null)
                break;

            Console.WriteLine($"\n=== Executando processo {processo.Id} ===");

            for (var i = 0; i < _escalonador.Quantum && !processo.Finalizado; i++)
            {
                _cpu.ExecutarCiclo(processo);
            }
        }

        Console.WriteLine("\n--- Fim da simulação ---");
    }
}