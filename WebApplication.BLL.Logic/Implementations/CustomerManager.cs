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
using WebApplication.BLL.Logic.Helpers;

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
        public CustomerDTO Add(NewCustomerModel customer)
        {
            //Customer customerEntity = _mapper.Map<Customer>(customer);
            Customer customerEntity = new Customer();
            Contact contactEntity = new Contact();
            
            contactEntity.Email = customer.Email;
            contactEntity.Address = customer.Address;
            contactEntity.Phone = customer.Phone;
            customerEntity.Name = customer.Name;
            customerEntity.ImagePath = customer.ImagePath;           
            customerEntity.Contact = contactEntity;
            _customerDAL.Save(customerEntity);
            CustomerDTO customerDto = _mapper.Map<CustomerDTO>(customerEntity);
            return customerDto;
        }

        public CustomerDTO Delete(CustomerDTO customer)
        {
            Customer customer1 = _mapper.Map<Customer>(customer);
            if (customer1.IsDeleted == true)
            {
                return customer;
            }
            else
            {
                //var delete = 3;
                //product1.EntityState = (EntityStateEnum)delete;
                customer1.IsDeleted = true;
                _customerDAL.Update(customer1);

                return _mapper.Map<CustomerDTO>(customer1);
            }
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

        public CustomerDTO Update(int id, NewCustomerModel customer)
        {
            Customer customerEntity = _customerDAL.GetById(id);
            //Contact contactEntity = new Contact();
            customerEntity.Contact.Email = customer.Email;
            //contactEntity.Email = customer.Email;
            customerEntity.Contact.Address = customer.Address;
            //contactEntity.Address = customer.Address;
            customerEntity.Contact.Phone = customer.Phone;
            //contactEntity.Phone = customer.Phone;
            customerEntity.Name = customer.Name;
            //customerEntity.ImagePath = customer.ImagePath;
            customerEntity.ImagePath = customer.ImagePath;
            //customerEntity.Contact = contactEntity;
            //_customerDAL.Save(customerEntity);
            //CustomerDTO customerDto = _mapper.Map<CustomerDTO>(customerEntity);
            // return customerDto;
            //customerEntity = _mapper.Map<Customer>(customer);
            _customerDAL.Update(customerEntity);
            CustomerDTO customer1 = _mapper.Map<CustomerDTO>(customerEntity);

            return customer1;
        }
    }
}
