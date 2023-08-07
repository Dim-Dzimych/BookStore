using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Application.Models
{
   public  class BookModel
    {
        public string Name { get; set; }
        public int PageCount { get; set; }
        public string Author { get; set; }
        public DateTime PublishedAt { get; set; }
        public decimal Price { get; set; }
    }
}
