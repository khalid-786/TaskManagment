
using AutoMapper;
using Core.Entities;
using Domain.Dtos;


namespace Domain.Profiles
{
    public class EntityMapper : Profile
    {
        public EntityMapper()
        {
            CreateMap<TaskDto, TaskManage>().ReverseMap();


        }


    }
}
