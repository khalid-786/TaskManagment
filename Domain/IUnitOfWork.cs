

using Core.Entities;
using Domain.Service;

namespace Domain
{
    public interface IUnitOfWork
    {
       
     
        IGenericeService<TaskManage> TaskManageService { get; }
     


        
        //



        int Save();
        Task<int> SaveAsync(); 
    }
}