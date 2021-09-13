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
            CreateMap<WebApplicationEntityFramework.Entities.Employee, EmployeeDTO>()
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.EmployeeId))
                .ForMember(dest => dest.Role, src => src.MapFrom(src => src.RoleId))
                 .ForMember(dest => dest.Name, src => src.MapFrom(src => src.EmployeeName));

            CreateMap<EmployeeDTO, WebApplicationEntityFramework.Entities.Employee >()
                .ForMember(dest => dest.EmployeeName, src => src.MapFrom(src => src.Email))
                    .ForMember(dest => dest.RoleId, src => src.MapFrom(src => src.Role))
                        .ForMember(dest => dest.Role, src => src.Ignore());
            
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<WebApplicationEntityFramework.Entities.Product, ProductDTO>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.Price, src => src.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.ProductId)); 
            CreateMap<ProductDTO, WebApplicationEntityFramework.Entities.Product>()
                .ForMember(dest => dest.ProductName, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(src => src.Price))
                .ForMember(dest => dest.ProductId, src => src.MapFrom(src => src.Id));
            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => src.Email));
            CreateMap<WebApplicationEntityFramework.Entities.Customer, CustomerDTO>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.CustomerId));
            CreateMap<CustomerDTO, WebApplicationEntityFramework.Entities.Customer>()
                .ForMember(dest => dest.CustomerName, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.CustomerId, src => src.MapFrom(src => src.Id));
        }
    }
}
