namespace SimuladorCpu.Domain.Memory;

public class Memoria
{
    private readonly Dictionary<int, int> _mem = new();

    public void Write(int endereco, int valor) => _mem[endereco] = valor;
    public int Read(int endereco) => _mem.GetValueOrDefault(endereco, 0);
}
