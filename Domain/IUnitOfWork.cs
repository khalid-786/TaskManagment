

using Domain.Service;

namespace Domain
{
    public interface IUnitOfWork
    {
       
     
        IGenericeService GenericeService { get; }
     


        
        //



        int Save();
        Task<int> SaveAsync(); 
    }
}