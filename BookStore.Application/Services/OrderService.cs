using BookStore.Domain.Repositories;
using BookStore.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using BookStore.Application.Models;
using System.Threading.Tasks;
using AutoMapper;
using System.Linq;
//using System.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _imapper;

        public OrderService(IDbRepository dbRepository,IMapper mapper)
        {
            _dbRepository = dbRepository;
            _imapper = mapper;
        }

        public async Task<OrderModel> CreateOrder(OrderModel model)
        {
            var entity = _imapper.Map<OrderEntity>(model); 

            await _dbRepository.Add(entity);
            await _dbRepository.SaveChangesAsync();

            return model;
        }

        //public async Task<List<OrderModel>> GetOrderById(int customerId)
        //{
        //    var entitys = await _dbRepository.Get<OrderEntity>().Where(x => x.CustomerId == customerId).ToListAsync();
        //    var models = new List<OrderModel>();

        //    foreach (var entity in entitys)
        //    {
        //        models.Add(_imapper.Map<OrderModel>(entity));
        //    }

        //    return models;
        //}

        //public async Task<List<OrderModel>> GetOrdersByDate(DateTime date)
        //{
        //    var entitys = await _dbRepository.Get<OrderEntity>().Where(x => x.CreateAt == date).ToListAsync();
        //    var models = new List<OrderModel>();

        //    foreach (var entity in entitys)
        //    {
        //        models.Add(_imapper.Map<OrderModel>(entity));
        //    }

        //    return models;
        //}

        public async Task<List<OrderModel>> GetOrdersByDateAndCustomerId(DateTime date, int customerId)
        {
            var entitys = await _dbRepository.Get<OrderEntity>()
                .Where(x => x.CreateAt == date && x.CustomerId == customerId)
                .ToListAsync();

            var models = new List<OrderModel>();

            foreach (var entity in entitys)
            {
                models.Add(_imapper.Map<OrderModel>(entity));
            }

            return models;
        }
    }
}
