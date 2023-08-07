using BookStore.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Services
{
    public interface IOrderService
    {
        Task<OrderModel> CreateOrder(OrderModel model);

        //Task<List<OrderModel>> GetOrderById(int customerId);

        //Task<List<OrderModel>> GetOrdersByDate(DateTime date);

        Task<List<OrderModel>> GetOrdersByDateAndCustomerId(DateTime date,int customerId);
    }
}
