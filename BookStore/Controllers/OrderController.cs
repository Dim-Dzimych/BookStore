using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Application.Services;
using BookStore.Application.Models;

namespace BookStore.Web.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _iorderService;

        public OrderController (IOrderService orderService)
        {
            _iorderService = orderService;
        }
        /// <summary>
        /// Создание заказа (БД: книга + заказ)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult<OrderModel> CreateOrder (OrderModel model)
        {
            var result = _iorderService.CreateOrder(model);

            if (result == null)
            {
                BadRequest("Result null");
            }
            return Ok(result);
        }
        /// <summary>
        /// Получение книг по двум параметрам
        /// </summary>
        /// <param name="date"></param>
        /// <param name="customerId"></param>
        /// <returns></returns>
        [HttpGet]
        public Task<List<OrderModel>> GetOrdersByDateAndCustomerId(DateTime date,int customerId)
        {
            return _iorderService.GetOrdersByDateAndCustomerId(date, customerId);
        }
        
    }
}
