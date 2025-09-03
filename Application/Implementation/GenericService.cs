using Core.Entities;
using Domain.Dtos;
using Domain.Service;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementation
{
    public class GenericService<T> : IGenericeService<T> where T : class
    {
        protected AppDbContext _db { get; set; }
        public GenericService(AppDbContext db) {
          _db = db;
        }

        public  async Task<int> AddAsync(T entiy)
        {
          await  _db.AddAsync(entiy);
            var done = await _db.SaveChangesAsync();
            return done;
        }

        public async Task<int> DeleteAsync(T entity)
        {
            
                _db.Remove(entity);
                var done = await _db.SaveChangesAsync(); 
                return done;
        }

       

        public async Task<int> Update(T entity)
        {
            _db.Update(entity);
            var done = await _db.SaveChangesAsync();
            return done;
        }


      
        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }
        public async Task<(IEnumerable<T> Items, int TotalCount)> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip)
        {
            IQueryable<T> query = _db.Set<T>();
            query = query.Where(criteria);
            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (take.HasValue)
                query = query.Take(take.Value);
            var totalCount = await query.CountAsync();
            var items = await query.ToListAsync();

            return (items, totalCount);
        }
    }
}
