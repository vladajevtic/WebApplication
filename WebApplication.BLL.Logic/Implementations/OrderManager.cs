using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.BLL.Logic.Models;
using WebApplication.CodeFirst.Entities;
using WebApplication.CodeFirst.Interfaces;
//using WebApplicationEntityFramework.Entities;
//using WebApplicationEntityFramework.Interfaces;

namespace WebApplication.BLL.Logic.Implementations
{
    public class OrderManager : IOrderManager
    {
        private readonly IOrderDAL _orderDAL;
        private readonly IProductDAL _productDAL;
        private readonly IMapper _mapper;

        public OrderManager(IOrderDAL orderDAL, IMapper mapper, IProductDAL productDAL)
        {
            _orderDAL = orderDAL;
            _mapper = mapper;
            _productDAL = productDAL;
        }

        public OrderDTO Add(OrderDTO orderDTO)
        {
            
            Order orderEntity = new Order();
            orderEntity.TotalAmount = 0;
            orderEntity.OrderItems = new List<OrderItem>();
            DateTime date = DateTime.Now;
            
            orderEntity.Number = "N" + date;
            orderEntity.Date = date;
            orderEntity.Status = 1;
            foreach (var order in orderDTO.OrderItems)
            {
                Product product = _productDAL.GetById(order.ProductId);
                orderEntity.TotalAmount += (decimal)(product.UnitPrice * order.Quantity);
                OrderItem orderItems = new OrderItem();
                orderItems.ProductId = product.Id;
                orderItems.Quantity = order.Quantity;

                orderEntity.OrderItems.Add(orderItems);
            }
            
            
            _orderDAL.Save(orderEntity);
            
            
            return orderDTO;

        }

        public IEnumerable<OrderDTO> GetAll()
        {
           return _mapper.Map<List<OrderDTO>>(_orderDAL.GetAll(0, 50));
        }

        public IEnumerable<OrderDTO> GetByCustomerId(int id)
        {
           List<OrderDTO> orderDTOs = _mapper.Map<List<OrderDTO>>(_orderDAL.GetByCustomerId(id,0,5));
            return orderDTOs;
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
