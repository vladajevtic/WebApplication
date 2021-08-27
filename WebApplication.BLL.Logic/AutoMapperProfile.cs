using AutoMapper;
using SEDCWebApplication.BLL.Logic.Models;
using System;
using WebApplication.DAL.Data.Entities;

namespace WebApplication.BLL.Logic
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email));

        }
    }
}
