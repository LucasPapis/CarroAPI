using System.Threading.Tasks;
using ProCarros.Application.Dtos;

namespace ProCarros.Application.Contratos
{
    public interface ICarroService
    {
        Task<CarroDto[]> SaveCarro(int fabricanteId, CarroDto[] models);
        Task<bool> DeleteCarro(int fabricanteId, int carroId);
        Task<CarroDto[]> GetCarrosByFabricanteIdAsync(int fabricanteId);
        Task<CarroDto> GetCarroByIdsAsync(int fabricanteId, int carroId);
    }
}