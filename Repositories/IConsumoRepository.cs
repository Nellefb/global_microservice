using GlobalSolution.Models;

namespace GlobalSolution.Repositories
{
    public interface IConsumoRepository
    {
        Task<IEnumerable<Consumo>> GetConsumo();
        Task PostConsumo(Consumo consumo);

    }
}
