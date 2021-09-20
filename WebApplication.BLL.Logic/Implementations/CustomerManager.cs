using AutoMapper;
//using SEDCWebApplication12.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.BLL.Logic.Models;
//using WebApplication.DAL.Data.Interfaces;
//using WebApplicationEntityFramework.Interfaces;
//using WebApplicationEntityFramework.Entities;
using WebApplication.CodeFirst.Interfaces;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.BLL.Logic.Implementations
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerDAL _customerDAL;
        private readonly IMapper _mapper;
        private readonly IOrderDAL _orderDAL;
        public CustomerManager(ICustomerDAL customerDAL, IMapper mapper, IOrderDAL orderDAL)
        {
            _mapper = mapper;
            _customerDAL = customerDAL;
            _orderDAL = orderDAL;
        }
        public CustomerDTO Add(CustomerDTO customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            _customerDAL.Save(customerEntity);
            customer = _mapper.Map<CustomerDTO>(customerEntity);
            return customer;
        }

        public IEnumerable<CustomerDTO> GetAllCustomer()
        {
            return _mapper.Map<List<CustomerDTO>>(_customerDAL.GetAll(0, 50));
        }

        public CustomerDTO GetCustomerById(int id)
        {
            try
            {
                var customer = _customerDAL.GetById(id);
                if(customer == null)
                {
                    throw new Exception($"Customer with {id} id not found");
                }
                return _mapper.Map<CustomerDTO>(customer);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
