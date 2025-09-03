using Core.Entities;
using Domain.Dtos;
using Domain.Service;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Implementation
{
    public class GenericService : IGenericeService
    {
        protected AppDbContext _db { get; set; }
        public GenericService(AppDbContext db) {
          _db = db;
        }

        public  async Task<int> AddAsync(TaskManage model)
        {
          await  _db.TaskManages.AddAsync(model);
            var done = await _db.SaveChangesAsync();
            return done;
        }

        public async Task<int> DeleteAsync(int id)
        {
            var task = await _db.TaskManages.FindAsync(id);
            if (task != null)
            {
                _db.TaskManages.Remove(task);
                var done = await _db.SaveChangesAsync(); 
                return done;
            }else
            {
                return 404;
            }
        }

        public async Task<int> Update(TaskManage model)
        {
            var task = await _db.TaskManages.FindAsync(model.Id);
            if (task != null)
            {
                _db.TaskManages.Update(task);
                var done = await _db.SaveChangesAsync();
                return done;
            }
            else
            {
                return 404;
            }
        }

        public async Task<TaskManage> FindAsync(int id)
        {
            return await _db.TaskManages.FindAsync( id);
        }

        public async Task<IEnumerable<TaskManage>> FindAllAsync(TaskFilterDto taskFilterDto)
        {
            return await _db.TaskManages.Where(t => t.Title.Contains(taskFilterDto.Title) && t.Status == taskFilterDto.Status )
                .Skip(taskFilterDto.Skip).Take(taskFilterDto.Take).ToListAsync();
        }
    }
}
