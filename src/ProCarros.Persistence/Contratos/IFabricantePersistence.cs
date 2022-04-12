using System.Threading.Tasks;
using ProCarros.Domain;

namespace ProCarros.Persistence.Contratos
{
    public interface IFabricantePersistence
    {
        //Fabricantes
        Task<Fabricante[]> GetFabricantesAsync();
        Task<Fabricante> GetFabricanteIdAsync(int fabricanteId);
    }
}