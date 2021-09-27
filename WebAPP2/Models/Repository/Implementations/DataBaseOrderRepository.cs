using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPP2.Models.Repository.Interfaces;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.BLL.Logic.Models;

namespace WebAPP2.Models.Repository.Implementations
{
    public class DataBaseOrderRepository : IOrderRepository
    {
        private readonly IOrderManager _orderManager;
        public DataBaseOrderRepository(IOrderManager orderManager){
            _orderManager = orderManager;
            }
        public IEnumerable<OrderDTO> GetAll()
        {
           return _orderManager.GetAll();
        }

        public List<OrderDTO> GetByEmployeeId(int id)
        {
           return _orderManager.GetByEmployeeId(id);
        }

        public OrderDTO GetById(int id)
        {
            return _orderManager.GetById(id);
        }
        public OrderDTO Add(OrderDTO orderDTO)
        {
            return _orderManager.Add(orderDTO);
        }
    }
}
