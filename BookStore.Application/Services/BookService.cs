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
    public class BookService : IBookService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IMapper _mapper;

        public BookService(IDbRepository dbRepository, IMapper mapper)
        {
            _dbRepository = dbRepository;
            _mapper = mapper;
        }

        public async Task<BookModel> CreateBook (BookModel model)
        {
            var entity = _mapper.Map<BookEntity>(model);

            await _dbRepository.Add(entity);
            await _dbRepository.SaveChangesAsync();

            return model;
        }

        public async Task<BookModel> GetBookInfo(int id)
        {
            var entity = await _dbRepository.Get<BookEntity>().FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<BookModel>(entity);

            return model;
        }

        //public async Task<List<BookModel>> GetBooksByName(string name)
        //{
        //    var entitys = await _dbRepository.Get<BookEntity>().Where(x => x.Name == name).ToListAsync();
        //    var models = new List<BookModel>();

        //    foreach (var entity in entitys)
        //    {
        //        models.Add(_imapper.Map<BookModel>(entity));
        //    }

        //    return models;
        //}

        //public async Task<List<BookModel>> GetBooksByDate(DateTime date)
        //{
        //    var entitys = await _dbRepository.Get<BookEntity>().Where(x => x.PublishedAt.Equals(date)).ToListAsync();
        //    var models = new List<BookModel>();
           

        //    foreach (var entity in entitys)
        //    {
        //        models.Add(_imapper.Map<BookModel>(entity));
        //    }

        //    return models;
        //}

        public async Task<List<BookModel>> GetBooks(FilterModel filter)
        {
            var entities = _dbRepository.Get<BookEntity>();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                entities = entities.Where(x => x.Name == filter.Name);
            }

            if (filter.PublishedAtFrom != null)
            {
                entities = entities.Where(x => filter.PublishedAtFrom >= x.PublishedAt);
            }

            if (filter.PublishedAtTo != null)
            {
                entities = entities.Where(x => filter.PublishedAtTo <= x.PublishedAt);
            }

            var books = await entities.ToListAsync();
            var models = _mapper.Map<List<BookModel>>(books);

            //еслии маппиинг не сработает верни
            // foreach (var entity in books)
            // {
            //     models.Add(_mapper.Map<BookModel>(entity));
            // }

            return models;
        }
    }
}
