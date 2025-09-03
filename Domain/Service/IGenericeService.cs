using Core.Entities;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service
{
    public interface IGenericeService
    {
        public Task<int> AddAsync(TaskManage model);
        public Task<int> DeleteAsync(int id);
        public Task<int> Update(TaskManage model);
        public Task<TaskManage> FindAsync(int id);
        public Task< IEnumerable<TaskManage>> FindAllAsync(TaskFilterDto taskFilterDto);

    }
}
