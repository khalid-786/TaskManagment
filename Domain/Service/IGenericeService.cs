using Core.Entities;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IGenericeService<T> where T : class
    {
        public Task<int> AddAsync(T entity);
        public Task<int> DeleteAsync(T entity);
        public Task<int> Update(T entity);
        public Task<T> GetByIdAsync(int id);
        public Task<(IEnumerable<T> Items, int TotalCount)> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip);

    }
}
