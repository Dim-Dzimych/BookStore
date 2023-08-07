using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BookStore.Domain.Entity;
using BookStore.Application.Models;

namespace BookStore.Application
{
    public class BookMapper : Profile
    {
        public BookMapper()
        {
            CreateMap<BookModel, BookEntity>().ReverseMap();
        }
    }
}
