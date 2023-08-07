using BookStore.Application.Models;
using BookStore.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookStore.Web.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// Получение всех книг с фильтрацией
        /// </summary>
        /// <param name="filter">параметры фильтрации</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBooks([FromQuery]FilterModel filter)
        {
            var result = await _bookService.GetBooks(filter);
            return Ok(result);
        }

        /// <summary>
        /// Получений книги по передаваемому айди
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBookInfoById(int id)
        {
            var result = await _bookService.GetBookInfo(id);

            if (result == null)
            {
                BadRequest("Book null");
            }

            return Ok(result);
          
        }
        /// <summary>
        /// Создание книги
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> CreateBook(BookModel model)
        {
            var result = await _bookService.CreateBook(model);

            if(result == null)
            {
                BadRequest("Book null");
            }

            return Ok(result);
        }

    }
}
