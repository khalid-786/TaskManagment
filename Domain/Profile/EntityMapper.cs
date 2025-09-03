using AutoMapper;
using Core.Entities;
using Domain.Dtos;


namespace Peers.Domain.Profiles
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<TaskDto, TaskManage>().ReverseMap();
         

        }


    }
}
