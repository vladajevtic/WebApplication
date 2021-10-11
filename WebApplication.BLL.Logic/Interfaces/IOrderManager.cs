using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Models;

namespace WebApplication.BLL.Logic.Interfaces
{
    public interface IOrderManager
    {
        OrderDTO GetById(int id);
        List<OrderDTO> GetByEmployeeId(int id);
        OrderDTO Add(OrderDTO orderDTO);
        IEnumerable<OrderDTO> GetAll();
        IEnumerable<OrderDTO> GetByCustomerId(int id);
    }
}
