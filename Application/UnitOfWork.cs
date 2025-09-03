

using Application.Implementation;
using Core.Entities;
using Domain;
using Domain.Service;
using Infrastructure;

namespace Peers.Application
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
     
  

        public IGenericeService<TaskManage> TaskManageService { get; }
        public UnitOfWork(AppDbContext context )
        {
            _context = context;

            TaskManageService = new GenericService<TaskManage>(_context);
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
