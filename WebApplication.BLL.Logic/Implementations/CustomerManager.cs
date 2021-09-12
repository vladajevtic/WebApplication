using AutoMapper;
using SEDCWebApplication12.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.BLL.Logic.Models;
//using WebApplication.DAL.Data.Interfaces;
using WebApplicationEntityFramework.Interfaces;

namespace WebApplication.BLL.Logic.Implementations
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ICustomerDAL _customerDAL;
        private readonly IMapper _mapper;
        public CustomerManager(ICustomerDAL customerDAL, IMapper mapper)
        {
            _mapper = mapper;
            _customerDAL = customerDAL;
        }
        public CustomerDTO Add(CustomerDTO customer)
        {
            Customer customerEntity = _mapper.Map<Customer>(customer);
            //_customerDAL.Save(customerEntity);
            return customer;
        }

        public IEnumerable<CustomerDTO> GetAllCustomer()
        {
            return _mapper.Map<List<CustomerDTO>>(_customerDAL.GetAll(0, 5));
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
