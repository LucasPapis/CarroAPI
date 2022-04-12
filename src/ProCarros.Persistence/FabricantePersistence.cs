using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProCarros.Domain;
using ProCarros.Persistence.Contextos;
using ProCarros.Persistence.Contratos;

namespace ProCarros.Persistence
{
    public class FabricantePersistence : IFabricantePersistence
    {
        private readonly ProCarrosContext _context;
        public FabricantePersistence(ProCarrosContext context)
        {
            _context = context;
        }
        
        public async Task<Fabricante[]> GetFabricantesAsync()
        {
            IQueryable<Fabricante> query = _context.Fabricantes.Include(f => f.Carros);
            query = query.AsNoTracking().OrderBy(f => f.Id_Fabricante);
            return await query.ToArrayAsync();
        }

        public async Task<Fabricante> GetFabricanteIdAsync(int fabricanteId)
        {
            IQueryable<Fabricante> query = _context.Fabricantes.Include(f => f.Carros);
            query = query.AsNoTracking().OrderBy(f => f.Id_Fabricante).Where(f => f.Id_Fabricante == fabricanteId);
            return await query.FirstOrDefaultAsync();
        }
    }
}