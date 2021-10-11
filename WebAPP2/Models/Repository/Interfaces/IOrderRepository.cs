using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Models;

namespace WebAPP2.Models.Repository.Interfaces
{
    public interface IOrderRepository
    {
        OrderDTO GetById(int id);
        List<OrderDTO> GetByEmployeeId(int id);
        IEnumerable<OrderDTO> GetAll();
        OrderDTO Add(OrderDTO orderDTO);
        List<OrderDTO> GetByCustomerId(int id);
    }
}
