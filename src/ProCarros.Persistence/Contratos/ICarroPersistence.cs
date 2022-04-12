using System.Threading.Tasks;
using ProCarros.Domain;

namespace ProCarros.Persistence.Contratos
{
    public interface ICarroPersistence
    {
        //Fabricantes
        Task<Carro[]> GetCarrosByFabricanteIdAsync(int fabricanteId);
        Task<Carro> GetCarroByIdsAsync(int fabricanteId, int carroId);
    }
}