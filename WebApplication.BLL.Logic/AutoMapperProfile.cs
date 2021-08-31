using AutoMapper;
using SEDCWebApplication.BLL.Logic.Models;
using SEDCWebApplication12.Models;
using System;
using WebApplication.BLL.Logic.Models;
using WebApplication.DAL.Data.Entities;

namespace WebApplication.BLL.Logic
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email))
                .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Role));
            CreateMap<Product, ProductDTO>();
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email));
        }
    }
}
