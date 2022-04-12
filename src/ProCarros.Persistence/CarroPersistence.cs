using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProCarros.Domain;
using ProCarros.Persistence.Contextos;
using ProCarros.Persistence.Contratos;

namespace ProCarros.Persistence
{
    public class CarroPersistence : ICarroPersistence
    {
        private readonly ProCarrosContext _context;
        public CarroPersistence(ProCarrosContext context)
        {
            _context = context;
        }

        public async Task<Carro> GetCarroByIdsAsync(int fabricanteId, int carroId)
        {
            IQueryable<Carro> query = _context.Carros;
            query = query.AsNoTracking().Where(carro => carro.FabricanteId == fabricanteId && 
            carro.Id_carro == carroId);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Carro[]> GetCarrosByFabricanteIdAsync(int fabricanteId)
        {
            IQueryable<Carro> query = _context.Carros;
            query = query.AsNoTracking().Where(carro => carro.FabricanteId == fabricanteId);
            return await query.ToArrayAsync();
        }
    }
}