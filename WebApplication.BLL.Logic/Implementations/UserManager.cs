using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.BLL.Logic.Models;
using WebApplication.CodeFirst.Entities;
using WebApplication.CodeFirst.Interfaces;

namespace WebApplication.BLL.Logic.Implementations
{
    public class UserManager : IUserManager
    {
        private readonly IUserDAL _userDAL;
        //private readonly IOrderDAL _orderDAL;
        private readonly IMapper _mapper;
        public UserManager(IUserDAL userDAL, IMapper mapper)
        {
            _userDAL = userDAL;
            _mapper = mapper;
            //_orderDAL = orderDAL;
        }
        public UserDTO GetUserByUserNameAndPassword(string userName, string password)
        {
            try
            {
                User user = _userDAL.GetUserByUserNameAndPassword(userName, password);
                if(user == null)
                {
                    throw new Exception("User not found");
                }
                UserDTO userDTO = _mapper.Map<UserDTO>(user);
                return userDTO;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public UserDTO GetById(int id)
        {
            try
            {
                User user = _userDAL.GetById(id);
                if (user == null)
                {
                    throw new Exception($"Employee with {id} not found");
                }
                UserDTO userDTO = _mapper.Map<UserDTO>(_userDAL.GetById(id));
                //employeeDTO.Orders = _orderDAL.GetByEmployeeId(employee.Id);
                return userDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
