using System.Threading.Tasks;
using ProCarros.Application.Dtos;
using ProCarros.Domain;

namespace ProCarros.Application.Contratos
{
    public interface IFabricantesService
    {
        Task<FabricanteDto> AddFabricantes(FabricanteDto model);
        Task<FabricanteDto> UpdateFabricante(int fabricanteId,FabricanteDto model);
        Task<bool> DeleteFabricantes(int fabricanteId);
        Task<FabricanteDto[]> GetFabricantesAsync();
        Task<FabricanteDto> GetFabricanteIdAsync(int fabricanteId);
    }
}