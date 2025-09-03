

using Application.Implementation;
using Domain;
using Domain.Service;
using Infrastructure;

namespace Peers.Application
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
     
  

        public IGenericeService GenericeService { get; }
        public UnitOfWork(AppDbContext context )
        {
            _context = context;

            GenericeService = new GenericService(_context);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {

            return await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
