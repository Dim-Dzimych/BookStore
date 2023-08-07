using System.Collections.Generic;
using System.Threading.Tasks;
using BookStore.Application.Models;

namespace BookStore.Application.Services
{
    public interface IBookService
    {
        Task<BookModel> CreateBook (BookModel model);

        Task<BookModel> GetBookInfo (int id);

        //Task<List<BookModel>> GetBooksByName(string name);

        //Task<List<BookModel>> GetBooksByDate(DateTime time);

        Task<List<BookModel>> GetBooks(FilterModel filter);

    }
}
