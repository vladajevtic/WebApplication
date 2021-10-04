using AutoMapper;
using SEDCWebApplication.BLL.Logic.Models;
//using SEDCWebApplication12.Models;
using System;
using WebApplication.BLL.Logic.Helpers;
using WebApplication.BLL.Logic.Models;
//using WebApplication.DAL.Data.Entities;
//using WebApplicationEntityFramework.Entities;
using WebApplication.CodeFirst.Entities;


namespace WebApplication.BLL.Logic
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Email))
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
            CreateMap<Product, ProductDTO>()

                .ForMember(dest => dest.Price, src => src.MapFrom(src => src.UnitPrice));

            CreateMap<ProductDTO,Product>()

                .ForMember(dest => dest.UnitPrice, src => src.MapFrom(src => src.Price));
                

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.Email));
            CreateMap<WebApplicationEntityFramework.Entities.Customer, CustomerDTO>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => src.CustomerName))
                .ForMember(dest => dest.Id, src => src.MapFrom(src => src.CustomerId));
            CreateMap<CustomerDTO, WebApplicationEntityFramework.Entities.Customer>()
                .ForMember(dest => dest.CustomerName, src => src.MapFrom(src => src.Name))
                .ForMember(dest => dest.CustomerId, src => src.MapFrom(src => src.Id));
            CreateMap<Order, OrderDTO>();

            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.Role, src => src.MapFrom(src => EnumHelper.GetString<RoleEnum>(src.RoleId)));
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderDTO, Order>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<OrderItemDTO, OrderItem>();
        }
    }
}
