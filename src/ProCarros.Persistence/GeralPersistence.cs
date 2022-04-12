using System.Threading.Tasks;
using ProCarros.Persistence.Contextos;
using ProCarros.Persistence.Contratos;

namespace ProCarros.Persistence
{
    public class GeralPersistence : IGeralPersistence
    {
        private readonly ProCarrosContext _context;
        public GeralPersistence(ProCarrosContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}