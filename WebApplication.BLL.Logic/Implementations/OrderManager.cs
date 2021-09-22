using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.BLL.Logic.Models;
using WebApplication.CodeFirst.Interfaces;
//using WebApplicationEntityFramework.Entities;
//using WebApplicationEntityFramework.Interfaces;

namespace WebApplication.BLL.Logic.Implementations
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderDAL _orderDAL;
        private readonly IMapper _mapper;

        public OrderManager(IOrderDAL orderDAL, IMapper mapper)
        {
            _orderDAL = orderDAL;
            _mapper = mapper;
        }
        public IEnumerable<OrderDTO> GetAll()
        {
           return _mapper.Map<List<OrderDTO>>(_orderDAL.GetAll(0, 50));
        }

        public List<OrderDTO> GetByEmployeeId(int id)
        {
            return _mapper.Map<List<OrderDTO>>(_orderDAL.GetByEmployeeId(id));
        }

        public OrderDTO GetById(int id)
        {
            return _mapper.Map<OrderDTO>(_orderDAL.GetById(id));
        }
    }
}
